using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonNurako.X11;
using TonNurako.X11.Event;
using Xunit;

namespace TonNurakoTest.X11 {
    public class DrawCallContainer {

        public delegate void VoldNopDelegaty();
        public delegate void VoldWindowDelegaty(Window window);

        public void Run(Display display,
            VoldNopDelegaty BeforeCreateWindow,
            VoldNopDelegaty BeforeMapWindow,
            VoldWindowDelegaty AfterMapWindow,
            VoldWindowDelegaty OnCreate,
            VoldWindowDelegaty OnExpose) {
            Assert.NotNull(display);

            var visual = display.DefaultVisual;
            Assert.NotNull(visual);

            var wsa = new TonNurako.X11.XSetWindowAttributes();
            wsa.BackgroundPixel = display.WhitePixel;
            wsa.EventMask = TonNurako.X11.EventMask.ExposureMask;
            var wam = TonNurako.X11.ChangeWindowAttributes.CWEventMask | TonNurako.X11.ChangeWindowAttributes.CWBackPixel;

            BeforeCreateWindow?.Invoke();

            var window = display.CreateWindow(
                display.DefaultRootWindow, 0, 0, 512, 512, 0,
                display.DefaultDepth, TonNurako.X11.WindowClass.InputOutput, visual, wam, wsa);
            Assert.NotNull(window);

            var atom = TonNurako.X11.Atom.InternAtom(display, "WM_DELETE_WINDOW", true);
            if (null != atom) {
                Assert.Equal(XStatus.True, window.SetWMProtocols(new TonNurako.X11.Atom[] { atom }));
            }
            Assert.Equal(XStatus.True, window.SelectInput(
                TonNurako.X11.EventMask.StructureNotifyMask | TonNurako.X11.EventMask.ExposureMask));

            BeforeMapWindow?.Invoke();

            Assert.Equal(XStatus.True, window.MapWindow());
            Assert.Equal(XStatus.True, display.Flush());
            window.ClearWindow();

            AfterMapWindow?.Invoke(window);

            var ev = new XEventArg();
            while (true) {
                display.NextEvent(ev);
                switch (ev.Type) {
                    case XEventType.CreateNotify:
                        window.ClearWindow();
                        display.Flush();
                        OnCreate?.Invoke(window);
                        break;
                    case XEventType.Expose:
                        OnExpose?.Invoke(window);
                        window.DestroyWindow();
                        return;
                    case XEventType.ClientMessage:
                        if (atom.Equals(ev.ClientMessage.Data.L[0])) {
                            window.DestroyWindow();
                            break;
                        }
                        break;
                    case XEventType.DestroyNotify:
                        return;
                }
            }
        }
    }
}
