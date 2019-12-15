using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XShape {
    class Program {
        static void Main(string[] args) {
            TonNurako.Application.RegisterGlobals();
            // ごみボックス
            var unity = new TonNurako.Inutility.Unity();

            System.Drawing.Bitmap maskImage = Properties.Resources.fallback; 
            if (args.Length > 0) {
                maskImage = unity.Store(new System.Drawing.Bitmap(args[0]));
            }
            

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
            
            TonNurako.X11.Xi.SetErrorHandler((d, e) => {
                Console.WriteLine("*** E ***");
                TonNurako.Inutility.Dumper.DumpStruct(e, (s) => {
                    Console.WriteLine($"XERR: {s}");
                });
                Console.WriteLine("******");
                return -1;
            });

            var dpy = TonNurako.X11.Display.Open(null);
            if (dpy.Handle == IntPtr.Zero) {
                Console.WriteLine("cannot open display");
                return;
            }

            var fs = unity.Store(TonNurako.X11.FontSet.CreateFontSet(dpy, "-*-fixed-medium-r-normal--14-*-*-*"));

            var rw = dpy.DefaultRootWindow;

            var atom = TonNurako.X11.Atom.InternAtom(dpy, "WM_DELETE_WINDOW", true);         

            var win = dpy.CreateSimpleWindow(
                rw, 0, 0, maskImage.Width + 32, maskImage.Height + 32, 0,
                TonNurako.X11.Color.AllocNamedColor(dpy, dpy.DefaultColormap, "white"),
                TonNurako.X11.Color.AllocNamedColor(dpy, dpy.DefaultColormap, "black"));

            win.SetWMProtocols(new TonNurako.X11.Atom[] { atom });
            win.SelectInput(TonNurako.X11.EventMask.StructureNotifyMask |
                TonNurako.X11.EventMask.ExposureMask |
                TonNurako.X11.EventMask.ButtonPressMask |
                TonNurako.X11.EventMask.KeyPressMask);

            var attr = new TonNurako.X11.XSetWindowAttributes();
            attr.BackingStore = TonNurako.X11.BackingStoreHint.WhenMapped;
            win.ChangeWindowAttributes(TonNurako.X11.ChangeWindowAttributes.CWBackingStore, attr);

            //win.StoreName("shapew");

            var rpr = TonNurako.X11.XTextProperty.TextListToTextProperty(
                dpy, new string[] { "たいとる" }, TonNurako.X11.XICCEncodingStyle.XCompoundTextStyle);
            win.SetWMName(rpr);

            var rpr2 = TonNurako.X11.XTextProperty.TextListToTextProperty(
                dpy, new string[] { "エイコン" }, TonNurako.X11.XICCEncodingStyle.XCompoundTextStyle);
            win.SetWMIconName(rpr2);
            var bms = new List<System.Drawing.Bitmap>();
            if (maskImage.Width != maskImage.Height) {
                int kmr = maskImage.Width % maskImage.Height;

                int avg = (maskImage.Width-kmr) / maskImage.Height;
                int amr = (maskImage.Width-kmr) / avg;
                int cx = 0;
                for (int i = 0; i < avg; ++i) {
                    var rect = new System.Drawing.Rectangle(cx, 0, amr, maskImage.Height);
                    bms.Add(unity.Store(maskImage.Clone(rect, maskImage.PixelFormat)));
                    Console.WriteLine($"i={rect}");
                    cx += amr;
                }
                if (0!= kmr) {
                    var k = maskImage.Width - cx;
                    var nb = new System.Drawing.Bitmap(amr, maskImage.Height);
                    var rect = new System.Drawing.Rectangle(cx, 0, k, maskImage.Height);
                    using(var g = System.Drawing.Graphics.FromImage(nb)) {
                        var km = maskImage.Clone(rect, maskImage.PixelFormat);
                        g.Clear(System.Drawing.Color.FromArgb(0x00,0,0,0));
                        g.DrawImage(km, new System.Drawing.Point(0,0));
                        km.Dispose();
                    }
                    bms.Add(unity.Store(nb));
                    Console.WriteLine($"AM={rect}");
                }
            }
            else {
                bms.Add(maskImage);
            }
            int bmx = 8;
            foreach (var bm in bms) {
                // αﾁｬﾈﾙからﾏｽｸ生成
                var oim = TonNurako.XImageFormat.Xi.おやさい.ぉに変換(bm);
                var o = TonNurako.XImageFormat.Xi.おやさい.XBM配列に変換(bm.Width, bm.Height, TonNurako.XImageFormat.Xi.ぉ.画素.A, false, oim);
                var bitmap = unity.Store(TonNurako.X11.Pixmap.FromBitmapData(rw, bm.Width, bm.Height, o));
                TonNurako.X11.Extension.XShape.CombineMask(dpy, win,
                    TonNurako.X11.Extension.ShapeKind.ShapeBounding,
                    bmx, 8, bitmap, bmx == 8 ? TonNurako.X11.Extension.ShapeOp.ShapeSet:TonNurako.X11.Extension.ShapeOp.ShapeUnion);
                bmx += bm.Width;
            }

            // 背景設定
            var bg = unity.Store(TonNurako.GC.XImage.FromBitmap(win, maskImage));
            //win.SetWindowBackgroundPixmap(bg);

            win.MapWindow();
            dpy.Flush();
            TonNurako.GC.GraphicsContext gc = null;
            var ev = new TonNurako.X11.Event.XEventArg();
            while (true) {
                dpy.NextEvent(ev);
                Console.WriteLine($"NextEvent ev={ev.Type}");
                switch (ev.Type) {
                    case TonNurako.X11.Event.XEventType.CreateNotify:
                        break;
                    case TonNurako.X11.Event.XEventType.Expose:
                        //win.ClearWindow();
                        if(null == gc) {
                            gc = unity.Store(new TonNurako.GC.GraphicsContext(win));
                        }
                        if(ev.Expose.Count ==0) {
                            gc.PutImage(bg, 0, 0, 8,8);
                        }
                        //dpy.Flush();
                        break;

                    case TonNurako.X11.Event.XEventType.ClientMessage:
                        if (atom.Equals(ev.ClientMessage.Data.L[0])) {
                            win.DestroyWindow();
                            break;
                        }
                        break;
                    case TonNurako.X11.Event.XEventType.DestroyNotify:
                        unity.Asset();
                        dpy.SetCloseDownMode(TonNurako.X11.CloseDownMode.DestroyAll);
                        dpy.Close();
                        return;

                    case TonNurako.X11.Event.XEventType.ButtonPress:
                        break;

                    case TonNurako.X11.Event.XEventType.KeyPress:
                        var ks = dpy.KeycodeToKeysym(ev.Key.KeyCode, 0, 0);
                        if (ks == TonNurako.X11.KeySym.XK_Escape) {
                            win.DestroyWindow();
                        }
                        break;
                    
                    default:
                        break;
                }
            }
        }
    }
}
