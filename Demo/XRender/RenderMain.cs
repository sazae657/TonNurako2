using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TonNurako.X11.Extension;

namespace XRender {
    class RenderMain {
        static void Main(string[] args) {
            //System.Diagnostics.Debug.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(Console.Out));
            TonNurako.Application.RegisterGlobals();
            // ごみボックス
            var unity = new TonNurako.Inutility.Unity();

            var loc = TonNurako.X11.Xi.SetLocale(TonNurako.X11.XLocale.LC_ALL, "");
            if (null == loc) {
                Console.WriteLine("Cannot set the locale.\n");
                return;
            }

            if (!TonNurako.X11.Xi.SupportsLocale()) {
                Console.WriteLine("Current locale is not supported");
                return;
            }

            TonNurako.X11.Xi.SetIOErrorHandler((d) => {
                Console.WriteLine("IOE");
                return -1;
            });
            /*TonNurako.X11.X11Sports.SetErrorHandler((d, e) => {
                Console.WriteLine("*** E ***");
                TonNurako.Inutility.Dumper.DumpStruct(e, (s) => {
                    Console.WriteLine($"XERR: {s}");
                });
                Console.WriteLine("******");
                return -1;
            });*/

            var dpy = TonNurako.X11.Display.Open(null);
            if (dpy.Handle == IntPtr.Zero) {
                Console.WriteLine("cannot open display");
                return;
            }

            if (!TonNurako.X11.Extension.XRender.QueryExtension(dpy)) {
                Console.WriteLine("Xrender not found");
                dpy.Close();
                return;
            }

            var ver = TonNurako.X11.Extension.XRender.QueryVersion(dpy);
            Console.WriteLine($"XRender: Major:{ver.Major} Minor:{ver.Minor}");

            dpy.Synchronize(true);

            var visual = dpy.DefaultVisual;

            var wsa = new TonNurako.X11.XSetWindowAttributes();
            wsa.BackgroundPixel = dpy.WhitePixel;
            wsa.EventMask = TonNurako.X11.EventMask.KeyPressMask | TonNurako.X11.EventMask.ExposureMask;
            var wam = TonNurako.X11.ChangeWindowAttributes.CWEventMask | TonNurako.X11.ChangeWindowAttributes.CWBackPixel;

            var window = dpy.CreateWindow(dpy.DefaultRootWindow, 50, 50, 
                Properties.Resources.combined.Width, 
                Properties.Resources.combined.Height, 0,
                dpy.DefaultDepth, TonNurako.X11.WindowClass.InputOutput, visual, wam, wsa);

            window.SelectInput(TonNurako.X11.EventMask.KeyPressMask | TonNurako.X11.EventMask.ExposureMask);

            var rpr = TonNurako.X11.XTextProperty.TextListToTextProperty(
                dpy, new string[] { "たいとる" }, TonNurako.X11.XICCEncodingStyle.XCompoundTextStyle);
            window.SetWMName(rpr);


            window.MapWindow();

            var w = Properties.Resources.combined.Width;
            var h = Properties.Resources.combined.Width;


            var ev = new TonNurako.X11.Event.XEventArg();
            bool broke = false;
            int grad = (int)GradientToDraw.CONICAL;
            while (!broke) {
                dpy.NextEvent(ev);
                Console.WriteLine($"NextEvent ev={ev.Type}");
                switch (ev.Type) {
                    case TonNurako.X11.Event.XEventType.KeyPress:
                        var ks = dpy.KeycodeToKeysym(ev.Key.KeyCode, 0, 0);
                        if (ks == TonNurako.X11.KeySym.XK_Escape) {
                            broke = true;
                        }
                        else {
                            grad++;
                            if (grad > (int)GradientToDraw.MAX) {
                                grad = 0;
                            }
                            Console.WriteLine($"grad={grad}({(GradientToDraw)grad})");
                            //window.ClearWindow();
                            Repaint(dpy, window, visual, w, h, (GradientToDraw)grad);
                        }
                        break;
                    case TonNurako.X11.Event.XEventType.Expose:
                        var e = ev.Expose;
                        TonNurako.Inutility.Dumper.DumpStruct(e, (s)=>Console.WriteLine($"Expose: {s}"));
                        if (e.Count < 1) {
                            Repaint(dpy, window, visual, e.Width, e.Height, (GradientToDraw)grad);
                        }
                        break;
                }
            }
            window.UnmapWindow();
            window.DestroyWindow();
            // ゴミの始末
            unity.Asset();
            dpy.Close();
        }
        enum GradientToDraw {
            RADIAL = 0,
            LINEAR,
            CONICAL,
            MAX
        }

        static void Repaint(
            TonNurako.X11.Display display,
            TonNurako.X11.Window window,
            TonNurako.X11.Visual visual,
            int width,
            int height,
            GradientToDraw grad)
        {
            var unity = new TonNurako.Inutility.Unity();

            var formatDefault = TonNurako.X11.Extension.XRender.FindVisualFormat(display, visual);
            TonNurako.Inutility.Dumper.DumpProperty(formatDefault, (s) => Console.WriteLine($"formatDefault: {s}"));

            var formatA8 = TonNurako.X11.Extension.XRender.FindStandardFormat(display, PictStandard.A8);
            TonNurako.Inutility.Dumper.DumpProperty(formatA8, (s) => Console.WriteLine($"formatA8: {s}"));

            var attributes = new XRenderPictureAttributes();
            var destPict = TonNurako.X11.Extension.XRender.CreatePicture(display, window, formatDefault, CreatePictureMask.None, attributes);
            unity.Store(destPict);

            var colorTrans = new XRenderColor { Red = 0x0000, Green = 0x0000, Blue = 0x0000, Alpha = 0xAAAA };
            var colorWhite = new XRenderColor { Red = 0xffff, Green = 0xffff, Blue = 0xffff, Alpha = 0xffff };
            var solidPict = CreateA8(display, window, colorWhite, width, height, true);
            var maskPict = CreateA8(display, window, colorTrans, width, height, false);
            unity.Store(solidPict);
            unity.Store(maskPict);


            var trapezoid = new XTrapezoid(
                TonNurako.X11.Xi.DoubleToFixed(30.0f),
                TonNurako.X11.Xi.DoubleToFixed((double)height - 30.0f),
                new XLineFixed(
                    new XPointFixed(
                        TonNurako.X11.Xi.DoubleToFixed(30.0f),
                        TonNurako.X11.Xi.DoubleToFixed(30.0f)),
                    new XPointFixed(
                        TonNurako.X11.Xi.DoubleToFixed(30.0f), 
                        TonNurako.X11.Xi.DoubleToFixed((double)height - 30.0f))),
                new XLineFixed(
                    new XPointFixed(
                        TonNurako.X11.Xi.DoubleToFixed((double)width - 30.0f),
                        TonNurako.X11.Xi.DoubleToFixed(30.0f)),
                    new XPointFixed(
                        TonNurako.X11.Xi.DoubleToFixed((double)width -  30.0f),
                        TonNurako.X11.Xi.DoubleToFixed((double)height - 30.0f)))
            );

            TonNurako.X11.Extension.XRender.CompositeTrapezoid(
                display, PictOp.Over, solidPict, maskPict, formatA8,0, 0, trapezoid);

            var colors = new XRenderColor[] {
                new XRenderColor(0xffff, 0x0000, 0x0000, 0xffff),
                new XRenderColor(0x0000, 0xffff, 0x0000, 0xffff),
                new XRenderColor(0x0000, 0x0000, 0xffff, 0xffff),
            };

            var linearGradient = new XLinearGradient(
                new XPointFixed(TonNurako.X11.Xi.DoubleToFixed(0.0f), TonNurako.X11.Xi.DoubleToFixed(0.0f)),
                new XPointFixed(TonNurako.X11.Xi.DoubleToFixed(0.0f), TonNurako.X11.Xi.DoubleToFixed((double)height/10))
            );

            var conicalGradient = new XConicalGradient(
                    new XPointFixed(TonNurako.X11.Xi.DoubleToFixed((double)width/2), TonNurako.X11.Xi.DoubleToFixed((double)height/2)),
                    TonNurako.X11.Xi.DoubleToFixed(123.0f)
                );

            var radialGradient = new XRadialGradient(
                new XCircle(TonNurako.X11.Xi.DoubleToFixed(50.0f), TonNurako.X11.Xi.DoubleToFixed(50.0f), TonNurako.X11.Xi.DoubleToFixed(45.0f)),
                new XCircle(TonNurako.X11.Xi.DoubleToFixed(100.0f), TonNurako.X11.Xi.DoubleToFixed(75.0f), TonNurako.X11.Xi.DoubleToFixed(200.0f))
            );

            var colorStops = new int[] {
                TonNurako.X11.Xi.DoubleToFixed(0.0f),
                TonNurako.X11.Xi.DoubleToFixed(0.33f),
                TonNurako.X11.Xi.DoubleToFixed(0.66f),
                TonNurako.X11.Xi.DoubleToFixed(1.0f)
            };

            Picture gradientPict = null;
            switch (grad) {
                case GradientToDraw.CONICAL:
                    gradientPict = TonNurako.X11.Extension.XRender.CreateConicalGradient(display, conicalGradient, colorStops, colors);
                    break;
                case GradientToDraw.LINEAR:
                    gradientPict = TonNurako.X11.Extension.XRender.CreateLinearGradient(display, linearGradient, colorStops, colors);
                    break;
                case GradientToDraw.RADIAL:
                    gradientPict = TonNurako.X11.Extension.XRender.CreateRadialGradient(display, radialGradient, colorStops, colors);
                    break;
                case GradientToDraw.MAX:
                    gradientPict = CreateBM(display, window);
                    break;
            }
            attributes.Repeat = true;
            TonNurako.X11.Extension.XRender.ChangePicture(display, gradientPict, CreatePictureMask.CPRepeat, attributes);
            unity.Store(gradientPict);

            //var convolution = CreateGaussianKernel2D(10);
            //TonNurako.X11.Extension.XRender.SetPictureFilter(display, maskPict, Filter.FilterConvolution, convolution);

            TonNurako.X11.Extension.XRender.Composite(
                display, PictOp.Src, gradientPict, maskPict, destPict, 0, 0, 0, 0, 0, 0, width, height);

            unity.Asset();
        }    

        static Picture CreateA8(
            TonNurako.X11.Display display,
            TonNurako.X11.IDrawable drawable,
            XRenderColor color,
            int width,
            int height,
            bool repeat) 
        {

            var mask = CreatePictureMask.None;
            var pixmap = new TonNurako.X11.Pixmap(drawable, width <= 0 ? 1 : width, height <= 0 ? 1 : height, 8);

            var pa = new XRenderPictureAttributes();
            if (repeat) {
                pa.Repeat = true;
                mask = CreatePictureMask.CPRepeat;
            }
            var picture = TonNurako.X11.Extension.XRender.CreatePicture(
                display, pixmap,
                TonNurako.X11.Extension.XRender.FindStandardFormat(display, PictStandard.A8), mask, pa);

            TonNurako.X11.Extension.XRender.FillRectangles(
                display, PictOp.Src, picture, color,
                    new[]{ new TonNurako.X11.XRectangle(0, 0, (ushort)width, (ushort)height) }
                );

            pixmap.Dispose();
            return picture;
        }

        static Picture CreateBM(
            TonNurako.X11.Display display,
            TonNurako.X11.IDrawable drawable) {

            var mask = CreatePictureMask.None;
            var pixmap = TonNurako.GC.PixmapFactory.FromBitmap(drawable, Properties.Resources.combined);

            var pa = new XRenderPictureAttributes();

            var picture = TonNurako.X11.Extension.XRender.CreatePicture(
                display, pixmap,
                TonNurako.X11.Extension.XRender.FindStandardFormat(display, PictStandard.RGB24), mask, pa);

            pixmap.Dispose();
            return picture;
        }

        static int[]
        CreateGaussianKernel2D(int radius) {
            double fU;
            double fV;
            int iX;
            int iY;
            double fSum = 0.0f;

            double fSigma = (double)radius / 2.0f;
            var fScale2 = 2.0f * fSigma * fSigma;
            var fScale1 = 1.0f / (Math.PI * fScale2);

            var size = 4 * radius * radius;
            var pTmpKernel = new double[size];

            for (iX = 0; iX < 2 * radius; iX++) {
                for (iY = 0; iY < 2 * radius; iY++) {
                    fU = (double)iX;
                    fV = (double)iY;
                    pTmpKernel[iX + iY * 2 * radius] = fScale1 *
                                    Math.Exp(-(fU * fU + fV * fV) / fScale2);
                }
            }

            for (iX = 0; iX < radius; iX++)
                fSum += pTmpKernel[iX];

            for (iX = 0; iX < radius; iX++)
                pTmpKernel[iX] /= fSum;

            var pKernel = new int[size + 2];

            for (iX = 0; iX < size; iX++)
                pKernel[iX + 2] = TonNurako.X11.Xi.DoubleToFixed(pTmpKernel[iX]);

            //*piSize += 2;
            pKernel[0] = TonNurako.X11.Xi.DoubleToFixed(2 * radius);
            pKernel[1] = TonNurako.X11.Xi.DoubleToFixed(2 * radius);

            return pKernel;
        }
    }
}
