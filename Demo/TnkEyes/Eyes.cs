//
// Eyes.cからの移植
//
// https://cgit.freedesktop.org/xorg/app/xeyes/tree/Eyes.c?id=XORG-7_1
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Widgets;
using TonNurako.X11;
using TonNurako.Xt;

namespace TnkEyes {

    enum EyesPart : int {
        PART_CLEAR = -1,

        PART_OUTLINE,
        PART_CENTER,
        PART_PUPIL,

        PART_SHAPE,
        PART_MAX
    };

    public class EyesOptions {
        public string geometry { get; set; } = null;
        public string fg { get; set; } = null;
        public string bg { get; set; } = null;
        public string bd { get; set; } = null;
        public string bw { get; set; } = null;
        public bool shape { get; set; } = true;
        public string outline { get; set; } = null;
        public string center { get; set; } = null;
        public bool distance { get; set; } = false;
        public bool render { get; set; } = true;
    }

    class EyesRec {
        public Color[] Pixel = new Color[(int)EyesPart.PART_MAX]; //Pixel
        public TonNurako.X11.GC[] GC = new TonNurako.X11.GC[(int)EyesPart.PART_MAX];
        public int BackingStore = 0;
        public bool ReverseVideo = false;
        public bool ShapeWindow = true;
        public int Update = 100;
        public TPoint Mouse = new TPoint();
        public TPoint[] Pupil = new TPoint[2];
        public Transform Transform = new Transform();
        public Transform Maskt = new Transform();
        public ulong IntervalId = 0;
        public TonNurako.X11.Pixmap ShapeMask = null;
        public bool Render = true;
        public TonNurako.X11.Extension.Picture Picture = null;
        public TonNurako.X11.Extension.Picture[] Fill = new TonNurako.X11.Extension.Picture[(int)EyesPart.PART_SHAPE];
        public bool Distance = true;
    }


    class Eyes : TonNurako.Xt.Core.CoreWidgetClass {

        #region EyesP.hのﾏｸﾛ
        const double TPOINT_NONE = (-1000);
        double EYE_X(double n) => ((n) * 2.0);
        double EYE_Y(double n) => (0.0);
        double Tx(double x, double y, Transform t) => ((((double)(x)) - t.Bx) / t.Mx);
        double Ty(double x, double y, Transform t) => ((((double)(y)) - t.By) / t.My);

        double Twidth(double w, double h, Transform t) => (((double)(w)) / t.Mx);
        double Theight(double w, double h, Transform t) => (((double)(h)) / t.My);

        short Xx(double x, double y, Transform t) => ((short)(t.Mx * (x) + t.Bx + 0.5));
        short Xy(double x, double y, Transform t) => ((short)(t.My * (y) + t.By + 0.5));
        short Xwidth(double w, double h, Transform t) => ((short)(t.Mx * (w) + 0.5));
        short Xheight(double w, double h, Transform t) => ((short)(t.My * (h) + 0.5));

        bool TEqual(double a, double b) => (Math.Abs(a - b) <= Double.Epsilon * Math.Max(1, Math.Max(Math.Abs(a), Math.Abs(b))));

        bool TPointEqual(TPoint a, TPoint b) => (TEqual(a.X, b.X) && TEqual(a.Y, b.Y));
        bool XPointEqual(XPoint a, XPoint b) => (a.x == b.x && a.y == b.y);
        bool AngleBetween(double A, double A0, double A1) => (A0 <= A1 ? A0 <= A && A <= A1 : A0 <= A || A <= A1);


        const double EYE_OFFSET = (0.1);
        const double EYE_THICK = (0.175);
        const double BALL_DIAM = (0.3);
        const double BALL_PAD = (0.175);
        const double EYE_DIAM = (2.0 - (EYE_THICK + EYE_OFFSET) * 2);
        const double BALL_DIST = ((EYE_DIAM - BALL_DIAM) / 2.0 - BALL_PAD);
        const double W_MIN_X = (-1.0 + EYE_OFFSET);
        const double W_MAX_X = (3.0 - EYE_OFFSET);
        const double W_MIN_Y = (-1.0 + EYE_OFFSET);
        const double W_MAX_Y = (1.0 - EYE_OFFSET);
        #endregion

        static int[] delays = { 50, 100, 200, 400, 0 };

        TonNurako.Inutility.Unity unity;
        XtAppContext applicationContext;
        EyesRec eyes = new EyesRec();
        IWidget widgetSelf = null;
        TonNurako.Xt.Core.WidgetRecAccessor widgetRec = null;

        TonNurako.X11.Color OptionToColor(Display dpy, string option, TonNurako.X11.Color def) {
            if (null == option) {
                return def;
            }
            return TonNurako.X11.Color.AllocNamedColor(dpy, dpy.DefaultColormap, option);
        }

        public Eyes(EyesOptions option, TonNurako.ApplicationContext app) : base() {
            unity = new TonNurako.Inutility.Unity();

            applicationContext = app.Handle.Context;

            this.ClassInited = 0;
            this.CompressMotion = true;
            this.CompressExposure = 1;
            this.CompressEnterleave = true;
            this.VisibleInterest = false;
            this.SuperClass = TonNurako.Xt.Core.CoreWidgetClass.GetDefaultSuperClass();
            this.ClassName = "EyesTnk";
            this.ClassPartInitialize = (w) => Console.WriteLine("ClassPartInitialize");
            this.ClassInitialize = () => Console.WriteLine("ClassInitialize");
            this.ClassPartInitialize = (w) => Console.WriteLine("ClassPartInitialize");
            this.SetValues = (old, request, xnew, args) => false;
            this.SetValuesAlmost = (old, xnew, geom) => null;

            this.Initialize = (request, xnew, args) => {
                widgetSelf = xnew;
                var win = xnew.Handle.Window;
                var dpy = xnew.Handle.Display;
                widgetRec = xnew.Handle.WidgetRecAccessor;
                //TonNurako.Inutility.Dumper.DumpProperty(widgetRec, (s) => Console.WriteLine($"WidgetRec: {s}"));

                Console.WriteLine("=== options ===");
                foreach (var prpr in typeof(EyesOptions).GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)) {
                    var v = prpr.GetValue(option);
                    if (null == v) {
                        v = (object)"(default)";
                    }
                    Console.WriteLine($"{prpr.Name} = {v}");
                }
                Console.WriteLine("======");

                var dfg = new TonNurako.X11.Color((ulong)widgetSelf.ToolkitResources.GetLongValue(TonNurako.Motif.ResourceId.XmNforeground));
                var dbg = new TonNurako.X11.Color((ulong)widgetSelf.ToolkitResources.GetLongValue(TonNurako.Motif.ResourceId.XmNbackground));

                eyes.Pixel[(int)EyesPart.PART_PUPIL] = OptionToColor(dpy, option.fg, dfg);
                eyes.Pixel[(int)EyesPart.PART_OUTLINE] = OptionToColor(dpy, option.outline, dfg);
                eyes.Pixel[(int)EyesPart.PART_CENTER] = OptionToColor(dpy, option.center, dbg);
                eyes.Render = option.render;
                eyes.ShapeWindow = option.shape;
                eyes.Distance = option.distance;

                var values = new TonNurako.X11.XGCValues();

                if (eyes.ReverseVideo) {
                    var xfg = eyes.Pixel[(int)EyesPart.PART_PUPIL];
                    var xbg = dbg;

                    if (widgetRec.BorderPixel.PixelEquals(xfg)) {
                        widgetRec.BorderPixel = xbg;
                    }

                    if (eyes.Pixel[(int)EyesPart.PART_OUTLINE].PixelEquals(xfg)) {
                        eyes.Pixel[(int)EyesPart.PART_OUTLINE] = xbg;
                    }
                    if (eyes.Pixel[(int)EyesPart.PART_CENTER].PixelEquals(xbg)) {
                        eyes.Pixel[(int)EyesPart.PART_CENTER] = xfg;
                    }
                    eyes.Pixel[(int)EyesPart.PART_PUPIL] = xbg;
                    widgetRec.BackgroundPixel = xfg;
                }

                values.Foreground = eyes.Pixel[(int)EyesPart.PART_PUPIL].Pixel;
                values.Background = widgetRec.BackgroundPixel.Pixel;
                eyes.GC[(int)EyesPart.PART_PUPIL] =
                    XtSports.XtGetGC(xnew, TonNurako.X11.GCMask.GCForeground | TonNurako.X11.GCMask.GCBackground, values);

                values.Foreground = eyes.Pixel[(int)EyesPart.PART_OUTLINE].Pixel;
                eyes.GC[(int)EyesPart.PART_OUTLINE] =
                    XtSports.XtGetGC(xnew, TonNurako.X11.GCMask.GCForeground | TonNurako.X11.GCMask.GCBackground, values);

                //PART_CENTER
                values.Foreground = eyes.Pixel[(int)EyesPart.PART_CENTER].Pixel;
                values.Background = eyes.Pixel[(int)EyesPart.PART_PUPIL].Pixel;
                eyes.GC[(int)EyesPart.PART_CENTER] =
                    XtSports.XtGetGC(xnew, TonNurako.X11.GCMask.GCForeground | TonNurako.X11.GCMask.GCBackground, values);

                eyes.Update = 0;
                eyes.IntervalId = 0;

                eyes.Pupil[0] = new TPoint();
                eyes.Pupil[1] = new TPoint();

                eyes.Pupil[0].X = eyes.Pupil[1].X = TPOINT_NONE;
                eyes.Pupil[0].Y = eyes.Pupil[1].Y = TPOINT_NONE;

                eyes.Mouse.X = eyes.Mouse.Y = TPOINT_NONE;

                eyes.ShapeMask = null;

                eyes.GC[(int)EyesPart.PART_SHAPE] = null;

                unity.Store<TonNurako.X11.GC>(eyes.GC);

                if (eyes.Render) {
                    for (int i = 0; i < (int)EyesPart.PART_SHAPE; i++) {
                        XColor c = new XColor();
                        c.Pixel = eyes.Pixel[i].Pixel;
                        var q = Color.QueryColor(dpy, widgetRec.Colormap, c);

                        eyes.Fill[i] = TonNurako.X11.Extension.XRender.CreateSolidFill(dpy, new TonNurako.X11.Extension.XRenderColor(q, 0xFFFF));
                    }
                    unity.Store<TonNurako.X11.Extension.Picture> (eyes.Fill);
                }

                Console.WriteLine("Initialize");
            };
            this.Realize = (widget, mask, attr) => {
                mask = TonNurako.X11.ChangeWindowAttributes.CWBackPixel |
                    TonNurako.X11.ChangeWindowAttributes.CWBorderPixel |
                    TonNurako.X11.ChangeWindowAttributes.CWEventMask |
                    TonNurako.X11.ChangeWindowAttributes.CWBackingStore;

                var dpy = widget.Handle.Display;
                attr.Colormap = widgetRec.Colormap.Handle;
                attr.BackingStore = TonNurako.X11.BackingStoreHint.NotUseful;
                Console.WriteLine($"Realize: M={mask}");
                //TonNurako.Inutility.Dumper.DumpProperty(attr, (s) => Console.WriteLine($"Realize: {s}"));
                XtSports.XtCreateWindow(widget, TonNurako.X11.WindowClass.InputOutput, TonNurako.X11.Visual.CopyFromParent, mask, attr);

                this.Resize(widget);

                eyes.IntervalId = applicationContext.AddTimeOut(delays[eyes.Update], DrawIt);
                Console.WriteLine($"Realize timeoutId={eyes.IntervalId}");
            };

            this.Destroy = (self) => {
                applicationContext.RemoveTimeOut(eyes.IntervalId);
                if (null != eyes.Picture) {
                    eyes.Picture.Dispose();
                    eyes.Picture = null;
                }
                unity.Asset();
                Console.WriteLine("Destroy");
            };

            this.Resize = (self) => {
                if (!TonNurako.Xt.XtSports.XtIsRealized(self)) {
                    return;
                }
                var win = self.Handle.Window;
                win.ClearWindow();
                var geom = win.GetGeometry();
                var dpy = self.Handle.Display;
                var screen = self.Handle.Screen;

                SetTransform(eyes.Transform,
                        0, geom.Width,
                        geom.Height, 0,
                        W_MIN_X, W_MAX_X,
                        W_MIN_Y, W_MAX_Y);

                if (null != eyes.Picture) {
                    eyes.Picture.Dispose();
                    eyes.Picture = null;
                }

                if (eyes.ShapeWindow) {
                    using (eyes.ShapeMask =
                        new TonNurako.X11.Pixmap(self.Handle.Display, self.Handle.Window, geom.Width, geom.Height, 1)) {
                        if (null == eyes.GC[(int)EyesPart.PART_SHAPE]) {
                            eyes.GC[(int)EyesPart.PART_SHAPE] =
                                unity.Store(TonNurako.X11.GC.Create(eyes.ShapeMask, GCMask.GCNone, new XGCValues()));
                        }

                        eyes.GC[(int)EyesPart.PART_SHAPE].SetForeground(0);
                        eyes.GC[(int)EyesPart.PART_SHAPE].FillRectangle(eyes.ShapeMask, 0, 0, geom.Width, geom.Height);
                        eyes.GC[(int)EyesPart.PART_SHAPE].SetForeground(1);
                        EyeLiner(false, 0);
                        EyeLiner(false, 1);
                        int x = 0;
                        int y = 0;
                        IWidget parent = self;
                        for (; null != XtSports.XtParent(parent); parent = XtSports.XtParent(parent)) {
                            var g = parent.Handle.Window.GetGeometry();
                            x += g.X + g.BorderWidth;
                            x += g.Y + g.BorderWidth;
                        }
                        TonNurako.X11.Extension.XShape.CombineMask(
                            parent.Handle.Display, parent.Handle.Window, TonNurako.X11.Extension.ShapeKind.ShapeBounding,
                                    x, y, eyes.ShapeMask, TonNurako.X11.Extension.ShapeOp.ShapeSet);
                    }
                    eyes.ShapeMask = null;
                }

                if (eyes.Render) {
                    var pa = new TonNurako.X11.Extension.XRenderPictureAttributes();
                    var pf = TonNurako.X11.Extension.XRender.FindVisualFormat(dpy, screen.DefaultVisualOfScreen);
                    if (null != pf) {
                        eyes.Picture =
                            TonNurako.X11.Extension.XRender.CreatePicture(
                                dpy, win, pf, TonNurako.X11.Extension.CreatePictureMask.None, pa);
                        if (null == eyes.Picture) {
                            throw new Exception("XRender.CreatePicture Failed");
                        }
                    }
                    else {
                        throw new Exception("FindVisualFormat Failed");
                    }
                }
                Console.WriteLine("Resize");
            };

            this.Expose = (self, xevent, region) => {
                eyes.Pupil[0].X = TPOINT_NONE;
                eyes.Pupil[0].Y = TPOINT_NONE;
                eyes.Pupil[1].X = TPOINT_NONE;
                eyes.Pupil[1].Y = TPOINT_NONE;
                RepaintWindow();
                Console.WriteLine("Expose");
            };


        }

        TPoint ComputePupil(int num, TPoint mouse, TRectangle screen) {
            double cx, cy;
            double dist;
            double angle;
            double dx, dy;
            double cosa, sina;
            TPoint ret = new TPoint();

            cx = EYE_X(num); dx = mouse.X - cx;
            cy = EYE_Y(num); dy = mouse.Y - cy;
            if (dx != 0 || dy != 0) {
                angle = Math.Atan2((double)dy, (double)dx);
                cosa = Math.Cos(angle);
                sina = Math.Sin(angle);
                dist = BALL_DIST;
                if (null != screen) {
                    double x0, y0, x1, y1;
                    var a = new double[4];
                    x0 = screen.X - cx;
                    y0 = screen.Y - cy;
                    x1 = x0 + screen.Width;
                    y1 = y0 + screen.Height;
                    a[0] = Math.Atan2(y0, x0);
                    a[1] = Math.Atan2(y1, x0);
                    a[2] = Math.Atan2(y1, x1);
                    a[3] = Math.Atan2(y0, x1);
                    if (AngleBetween(angle, a[0], a[1])) {
                        dist *= dx / x0;
                    }
                    else if (AngleBetween(angle, a[1], a[2])) {
                        dist *= dy / y1;
                    }
                    else if (AngleBetween(angle, a[2], a[3])) {
                        dist *= dx / x1;
                    }
                    else if (AngleBetween(angle, a[3], a[0])) {
                        dist *= dy / y0;
                    }
                    if (dist > BALL_DIST)
                        dist = BALL_DIST;
                }

                if (dist > Math.Sqrt(Math.Pow(dx, 2.0) + Math.Pow(dy, 2.0))) {
                    cx += dx;
                    cy += dy;
                }
                else {
                    cx += dist * cosa;
                    cy += dist * sina;
                }
            }
            ret.X = cx;
            ret.Y = cy;
            return ret;
        }

        void ComputePupils(TPoint mouse, TPoint[] pupils) {
            TRectangle screen, sp;
            screen = new TRectangle();
            sp = null;

            if (eyes.Distance) {
                var scr = widgetSelf.Handle.Screen;
                var r = widgetSelf.Handle.Screen.RootWindowOfScreen;
                var cod = new TonNurako.X11.XCoordinates();
                widgetSelf.Handle.Display.TranslateCoordinates(widgetSelf.Handle.Window, r, 0, 0, cod);

                screen.X = Tx(-cod.DestX, -cod.DestY, eyes.Transform);
                screen.Y = Ty(-cod.DestX, -cod.DestY, eyes.Transform);
                screen.Width = Twidth(scr.WidthOfScreen, scr.HeightOfScreen,
                            eyes.Transform);
                screen.Height = Theight(scr.WidthOfScreen, scr.HeightOfScreen,
                            eyes.Transform);
                sp = screen;
            }
            pupils[0] = ComputePupil(0, mouse, sp);
            pupils[1] = ComputePupil(1, mouse, sp);
        }

        void RepaintWindow() {
            if (!TonNurako.Xt.XtSports.XtIsRealized(widgetSelf)) {
                return;
            }
            EyeLiner(true, 0);
            EyeLiner(true, 1);
            ComputePupils(eyes.Mouse, eyes.Pupil);
            EyeBall(true, null, 0);
            EyeBall(true, null, 1);

        }

        void EyeBall(bool draw, TPoint old, int num) {
            DrawEllipse(draw ? EyesPart.PART_PUPIL : EyesPart.PART_CLEAR,
                eyes.Pupil[num].X, eyes.Pupil[num].Y,
                (old != null) ? old.X : TPOINT_NONE,
                (old != null) ? old.Y : TPOINT_NONE,
                BALL_DIAM);
        }

        void EyeLiner(bool draw, int num) {
            DrawEllipse(draw ? EyesPart.PART_OUTLINE : EyesPart.PART_SHAPE,
                EYE_X(num), EYE_Y(num),
                TPOINT_NONE, TPOINT_NONE,
                EYE_DIAM + 2.0 * EYE_THICK);
            if (draw) {
                DrawEllipse(EyesPart.PART_CENTER, EYE_X(num), EYE_Y(num),
                        TPOINT_NONE, TPOINT_NONE,
                        EYE_DIAM);
            }
        }

        void DrawEye(TPoint newpupil, int num) {
            XPoint xnewpupil, xpupil;

            xpupil.x = Xx(eyes.Pupil[num].X, eyes.Pupil[num].Y, eyes.Transform);
            xpupil.y = Xy(eyes.Pupil[num].X, eyes.Pupil[num].Y, eyes.Transform);
            xnewpupil.x = Xx(newpupil.X, newpupil.Y, eyes.Transform);
            xnewpupil.y = Xy(newpupil.X, newpupil.Y, eyes.Transform);
            if ((null != eyes.Picture) ?
                !TPointEqual(eyes.Pupil[num], newpupil) :
                !XPointEqual(xpupil, xnewpupil)) {
                TPoint oldpupil = eyes.Pupil[num];
                eyes.Pupil[num] = newpupil;
                EyeBall(true, oldpupil, num);
            }
        }

        void DrawEyes(TPoint mouse) {
            var newpupil = new[] { new TPoint(), new TPoint() };
            int num;

            if (TPointEqual(mouse, eyes.Mouse)) {
                if (delays[eyes.Update + 1] != 0)
                    ++eyes.Update;
                return;
            }
            ComputePupils(mouse, newpupil);
            for (num = 0; num < 2; num++) {
                DrawEye(newpupil[num], num);
            }

            eyes.Mouse = mouse;
            eyes.Update = 0;
        }

        void DrawItCore() {
            TPoint mouse = new TPoint();
            var dpy = widgetSelf.Handle.Display;
            var win = widgetSelf.Handle.Window;

            var pi = new XPointerInfo();
            win.QueryPointer(pi);
            mouse.X = Tx(pi.WinX, pi.WinY, eyes.Transform);
            mouse.Y = Ty(pi.WinX, pi.WinY, eyes.Transform);
            DrawEyes(mouse);
        }

        void DrawIt(ulong time) {
            if (TonNurako.Xt.XtSports.XtIsRealized(widgetSelf)) {
                DrawItCore();
            }
            eyes.IntervalId =
                applicationContext.AddTimeOut(delays[eyes.Update], DrawIt);
        }

        void DrawEllipse(EyesPart part,
            double centerx, double centery,
            double oldx, double oldy,
            double diam) {
            TRectangle tpos = new TRectangle(
                centerx - diam / 2.0,
                centery - diam / 2.0,
                diam, diam);

            TRectangle pos = new TRectangle();
            Trectangle(eyes.Transform, tpos, pos);
            if (part == EyesPart.PART_CLEAR) {
                eyes.GC[(int)EyesPart.PART_CENTER].FillRectangle(
                        widgetSelf.Handle,
                        (int)pos.X, (int)pos.Y,
                        (int)pos.Width + 2, (int)pos.Height + 2);
                return;
            }

            if (eyes.Render && part != EyesPart.PART_SHAPE &&
                (!eyes.ShapeWindow || part != EyesPart.PART_OUTLINE) &&
                null != eyes.Picture) {

                int n, i;
                double hd, c, s, sx, sy, x, y, px, py;


                pos.X = pos.X + pos.Width / 2.0;
                pos.Y = pos.Y + pos.Height / 2.0;

                hd = Math.Sqrt(Math.Pow(pos.Width, 2.0) + Math.Pow(pos.Height, 2.0)) / 2;
                n = (int)((Math.PI / Math.Acos(hd / (hd + 1.0))) + 0.5);
                if (n < 2) {
                    n = 2;
                }

                c = Math.Cos(Math.PI / n);
                s = Math.Sin(Math.PI / n);
                sx = -(pos.Width * s) / pos.Height;
                sy = (pos.Height * s) / pos.Width;

                n *= 2;

                var p = new TonNurako.X11.Extension.XPointDouble[n];
                x = 0;
                y = pos.Height / 2.0;
                for (i = 0; i < n; i++) {
                    p[i].X = x + pos.X;
                    p[i].Y = y + pos.Y;
                    px = x;
                    py = y;
                    x = c * px + sx * py;
                    y = c * py + sy * px;
                }

                if (!TEqual(oldx, TPOINT_NONE) || !TEqual(oldy, TPOINT_NONE)) {
                    DrawEllipse(EyesPart.PART_CLEAR, oldx, oldy, TPOINT_NONE, TPOINT_NONE, diam);
                }

                TonNurako.X11.Extension.XRender.CompositeDoublePoly(
                    widgetSelf.Handle.Display, TonNurako.X11.Extension.PictOp.Over,
                                eyes.Fill[(int)part], eyes.Picture,
                                TonNurako.X11.Extension.XRender.FindStandardFormat(widgetSelf.Handle.Display, TonNurako.X11.Extension.PictStandard.A8),
                                0, 0, 0, 0, p, 0);

                p = null;
                return;
            }


            if (!TEqual(oldx, TPOINT_NONE) || !TEqual(oldy, TPOINT_NONE)) {
                DrawEllipse(EyesPart.PART_CLEAR, oldx, oldy, TPOINT_NONE, TPOINT_NONE, diam);
            }

            var dst = (part == EyesPart.PART_SHAPE) ? eyes.ShapeMask : (IDrawable)widgetSelf.Handle;
            eyes.GC[(int)part].FillArc(
                 dst,
                 (int)(pos.X + 0.5), (int)(pos.Y + 0.5),
                 (int)(pos.Width + 0.0), (int)(pos.Height + 0.0),
                 90 * 64, 360 * 64);
        }

        void Trectangle(Transform t, TRectangle i, TRectangle o) {
            o.X = t.Mx * i.X + t.Bx;
            o.Y = t.My * i.Y + t.By;
            o.Width = t.Mx * i.Width;
            o.Height = t.My * i.Height;
            if (o.Width < 0) {
                o.X += o.Width;
                o.Width = -o.Width;
            }
            if (o.Height < 0) {
                o.Y += o.Height;
                o.Height = -o.Height;
            }
        }

        void SetTransform(Transform t,
                  int xx1, int xx2, int xy1, int xy2,
                  double tx1, double tx2, double ty1, double ty2) {
            t.Mx = ((double)xx2 - xx1) / (tx2 - tx1);
            t.Bx = ((double)xx1) - t.Mx * tx1;
            t.My = ((double)xy2 - xy1) / (ty2 - ty1);
            t.By = ((double)xy1) - t.My * ty1;
        }
    }
}
