using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XftDemo {
    static class Extensions {
        public static IEnumerable<int> GetUTF32CodePoints(this string s) {
            for (int i = 0; i < s.Length; i++) {
                int unicodeCodePoint = char.ConvertToUtf32(s, i);
                if (unicodeCodePoint > 0xffff) {
                    i++;
                }
                yield return unicodeCodePoint;
            }
        }
    }

    class Program : TonNurako.Widgets.Shell.TopLevel {
        TonNurako.Inutility.Unity unity;
        TonNurako.X11.Extension.Xft.XftFont[] font;
        TonNurako.X11.Extension.Xft.XftDraw xftDraw;
        TonNurako.X11.Extension.Xft.XftColor blue;
        TonNurako.X11.Extension.Xft.XftColor green;
        public Program() : base() {
            unity = new TonNurako.Inutility.Unity();
        }



        public override void ShellCreated() {

            this.XServerEvent.ExposeEvent += XServerEvent_ExposeEvent;
            this.ToolkitResources.Add(TonNurako.Xt.ResourceId.XtNwidth, 480);
            this.ToolkitResources.Add(TonNurako.Xt.ResourceId.XtNheight, 480);
            this.ToolkitResources.SetWidget(true);

            this.DestroyEvent += Program_DestroyEvent;
            this.RealizedEvent += Program_RealizedEvent;

            var dpy = this.Handle.Display;

            font = new TonNurako.X11.Extension.Xft.XftFont[4];
            for (int i = 1; i < font.Length + 1; ++i) {
                font[i - 1] =
                    TonNurako.X11.Extension.Xft.XftFont.OpenName(dpy, dpy.DefaultScreen, $":size={16 * i}");
            }
            unity.Store<TonNurako.X11.Extension.Xft.XftFont>(font);

            blue = TonNurako.X11.Extension.Xft.XftColor.AllocName(dpy, dpy.DefaultVisual, dpy.DefaultColormap, "blue");
            green = TonNurako.X11.Extension.Xft.XftColor.AllocValue(
                dpy, dpy.DefaultVisual, dpy.DefaultColormap, new TonNurako.X11.Extension.XRenderColor(0x0000, 0xffff, 0x0000, 0xffff));
            unity.Store(blue);
            unity.Store(green);

            using (var charset = TonNurako.X11.Extension.Xft.FcCharSet.Create()) {
                foreach (var u in "ゆゆ式".GetUTF32CodePoints()) {
                    var r = charset.AddChar((uint)u);
                    Console.WriteLine($"res={r} Count={charset.Count()}");
                }
            }
        }

        private void Program_RealizedEvent(object sender, TonNurako.Events.TnkEventArgs e) {
            var dpy = this.Handle.Display;
            xftDraw = TonNurako.X11.Extension.Xft.XftDraw.Create(dpy, this.Handle, dpy.DefaultVisual, dpy.DefaultColormap.Handle);
            if (null == xftDraw) {
                Console.WriteLine("XftDrawCreate Failed");
                return;
            }
            unity.Store(xftDraw);
        }

        private void Program_DestroyEvent(object sender, TonNurako.Events.TnkEventArgs e) {
            unity.Asset();
        }

        private void XServerEvent_ExposeEvent(object sender, TonNurako.Events.Server.ExposeEventArgs e) {
            int y = 30;
            for (int i = 0; i < font.Length; ++i) {
                y += font[i].Height;
                xftDraw.DrawString(blue, font[i], 10, y, "ゆゆ式");
            }
        }

        static void Main(string[] args) {
            //System.Diagnostics.Debug.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(Console.Out));

            var app = new TonNurako.ApplicationContext();
            TonNurako.Application.Run(app, new Program(), args);
        }
    }
}

