using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using TonNurako.X11.Event;
using Xunit;

namespace TonNurakoTest.X11 {

    public class WindowFixture :IDisposable {
        public Window Window { get; private set; }
        public Display Display { get; private set; }
        private Unity Unity;

        public WindowFixture() {
            Unity = new Unity();
            TonNurako.Application.RegisterGlobals();
            /*TonNurako.X11.Xi.SetIOErrorHandler((dpy) => throw new Exception("IOE"));
            TonNurako.X11.Xi.SetErrorHandler((dpy, ev) => {
                throw new Exception($"XError {ev.error_code}");
            });*/

            Assert.NotNull(TonNurako.X11.Xi.SetLocale(TonNurako.X11.XLocale.LC_ALL, ""));
            Assert.True(TonNurako.X11.Xi.SupportsLocale());
            Assert.NotNull(TonNurako.X11.Xi.SetLocaleModifiers(""));

            this.Display = TonNurako.X11.Display.Open(null);
            Assert.NotNull(this.Display);

            var visual = this.Display.DefaultVisual;
            Assert.NotNull(visual);

            var wsa = new TonNurako.X11.XSetWindowAttributes();
            wsa.BackgroundPixel = this.Display.WhitePixel;
            wsa.EventMask = TonNurako.X11.EventMask.ExposureMask| TonNurako.X11.EventMask.StructureNotifyMask;
            var wam = TonNurako.X11.ChangeWindowAttributes.CWEventMask | TonNurako.X11.ChangeWindowAttributes.CWBackPixel;

            this.Window = this.Display.CreateWindow(
                this.Display.DefaultRootWindow, 50, 50, 320, 240, 0,
                this.Display.DefaultDepth, TonNurako.X11.WindowClass.InputOutput, visual, wam, wsa);
            Assert.NotNull(this.Display);

            Assert.Equal(XStatus.True, Window.SelectInput(TonNurako.X11.EventMask.ExposureMask| TonNurako.X11.EventMask.StructureNotifyMask));

            Assert.Equal(XStatus.True, this.Window.MapWindow());
            Assert.Equal(XStatus.True, Display.Flush());
            Window.ClearWindow();
            using (var ev = new XEventArg()) {
                while (true) {
                    Display.NextEvent(ev);
                    switch (ev.Type) {
                        case XEventType.Expose:
                            return;
                        default:
                            break;
                    }
                }
            }

        }

        void ProcessMessage(string t) {
            using (var ev = new XEventArg()) {
                //var tk = DateTime.Now.Ticks;
                Display.Sync(false);
                while (Display.Pending() > 0) {
                    Display.NextEvent(ev);
                    //Console.WriteLine($"{tk}: WindowFixture<{t}> {Display.Pending()} as {ev.Type}");
                    Thread.Sleep(1);
                }
            }
        }

        public void Dispose() {
            // Thread.Sleep(2000);
            //Console.WriteLine("WindowFixture#Dispose");
            Unity.Asset();
            if (null != this.Window) {
                this.Window.DestroyWindow();
                this.Window = null;
            }
            ProcessMessage("1");

            if (Display != null) {
                Display.SetCloseDownMode(TonNurako.X11.CloseDownMode.DestroyAll);
                ProcessMessage("2");
                Assert.True(Display.Close() >= 0);
                Display = null;
            }
            TonNurako.X11.Xi.SetErrorHandler(null);
            TonNurako.X11.Xi.SetIOErrorHandler(null);
            //Thread.Sleep(100);
            TonNurako.Application.UnregisterGlobals();
        }
    }
}
