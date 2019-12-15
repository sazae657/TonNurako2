using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.X11;
using TonNurako.X11.Event;
using Xunit;


namespace TonNurakoTest.X11 {
    public class DisplayFixture : IDisposable {

        public Display Display { get; private set; }

        public DisplayFixture() {
           // Console.WriteLine("DisplayFixture#construct");
            TonNurako.Application.RegisterGlobals();
            /*Xi.SetIOErrorHandler((dpy) => throw new Exception("IOE"));
            Xi.SetErrorHandler((dpy, ev) => throw new Exception($"XError {ev.error_code}"));*/

            Assert.NotNull(TonNurako.X11.Xi.SetLocale(TonNurako.X11.XLocale.LC_ALL, ""));
            Display = TonNurako.X11.Display.Open(null);
            Assert.NotNull(Display);
        }
        void ProcessMessage(string t) {
            Display.Sync(false);
            using (var ev = new XEventArg()) {
                //var tk = DateTime.Now.Ticks;
                while (Display.Pending() > 0) {
                    Display.NextEvent(ev);
                    //Console.WriteLine($"{tk}: DisplayFixture<{t}> {Display.Pending()} as {ev.Type}");
                    Thread.Sleep(1);
                }
            }
        }

        public void Dispose() {
            // Console.WriteLine("DisplayFixture#Dispose");
            ProcessMessage("1");
            if (Display != null) {
                Display.SetCloseDownMode(TonNurako.X11.CloseDownMode.DestroyAll);
                //Display.Sync(true);
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

