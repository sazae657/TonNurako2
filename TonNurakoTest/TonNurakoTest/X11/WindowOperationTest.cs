using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using TonNurako.X11.Event;
using Xunit;

namespace TonNurakoTest.X11 {
    public class WindowOperationTest : IClassFixture<WindowFixture>, IDisposable {
        WindowFixture fix;
        Unity unity;
        public WindowOperationTest(WindowFixture fixture) {
            fix = fixture;
            unity = new Unity();
        }

        public void Dispose() {
            unity.Asset();
        }

        [Fact]
        public void InputFocus() {
            Assert.Equal(XStatus.True, fix.Window.RaiseWindow());
            Assert.Equal(XStatus.True, fix.Display.SetInputFocus(fix.Window, RevertTo.None, 0));
            var f = fix.Display.GetInputFocus();
            Assert.NotNull(f);
            Assert.Equal(fix.Window.Handle, f.Window.Handle);

            using (var arg = new XEventArg()) {
                Assert.False(fix.Window.CheckWindowEvent(EventMask.ExposureMask, arg));
                Assert.False(fix.Window.CheckTypedWindowEvent(XEventType.Expose, arg));
            }

            Assert.Equal(XStatus.True, fix.Display.WarpPointer(null, fix.Window, 0, 0, 0, 0, 100, 100));

            Assert.NotNull(fix.Window.GetMotionEvents(0, 0));
        }

        [Fact]
        public void CursorTest() {
            var window = fix.Window;
            Assert.NotNull(window);
            using (var c = Cursor.CreateFontCursor(fix.Display, XCursorShape.XC_arrow)) {
                Assert.NotNull(c);
                Assert.Equal(XStatus.True, window.DefineCursor(c));
                Assert.Equal(XStatus.True, window.UndefineCursor());
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        struct SmallStruct {
            byte b;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct LargeStrucy {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5800)]
            byte b;
        }

        int ProcessEvent(XEventType check) {
            var dpy = fix.Display;
            int cn = 0;
            using (var e = new XEventArg()) {
                dpy.Sync(false);
                while (dpy.Pending() > 0) {
                    dpy.NextEvent(e);
                    if (e.Type == check) {
                        cn++;
                    }
                }
            }
            return cn;
        }

        [Fact]
        public void EventTest() {
            var window = fix.Window;
            var dpy = fix.Display;
            Assert.NotNull(window);
            Assert.NotNull(dpy);

            var ev = new XSendEventArg();
            ev.Window = window;
            ev.Display = dpy;
            ev.Type = XEventType.KeyPress;

            Assert.NotEqual(0, dpy.SendEvent(window, false, EventMask.NoEventMask, ev));
            Assert.NotEqual(0, ProcessEvent(XEventType.KeyPress));

            Assert.Throws<ArgumentOutOfRangeException>(() => dpy.SendEvent(window, false, EventMask.NoEventMask, new SmallStruct()));
            Assert.Throws<ArgumentOutOfRangeException>(() => dpy.SendEvent(window, false, EventMask.NoEventMask, new LargeStrucy()));

            var atom = Atom.InternAtom(dpy, "トンヌラジェット", false);
            Assert.NotNull(atom);

            var ev2 = new XClientMessageEvent();
            ev2.Display = (ulong)dpy.Handle;
            ev2.Window = (ulong)window.Handle;
            ev2.Type = XEventType.ClientMessage;
            ev2.Format = 32;
            ev2.MessageType = atom.Integer;
            Assert.NotEqual(0, dpy.SendEvent(window, false, EventMask.NoEventMask, ev2));
            Assert.NotEqual(0, ProcessEvent(XEventType.ClientMessage));

        }
    }
}
