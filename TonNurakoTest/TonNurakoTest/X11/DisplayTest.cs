using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonNurako.X11;
using TonNurako.X11.Event;
using Xunit;

namespace TonNurakoTest.X11 {
    public class DisplayTest : IDisposable {

        TonNurako.X11.Display display;

        public DisplayTest() {
            display = null;

            TonNurako.Application.RegisterGlobals();
            TonNurako.X11.Xi.SetIOErrorHandler((dpy) => throw new Exception("IOE"));
            TonNurako.X11.Xi.SetErrorHandler((dpy, ev) => throw new Exception($"XError {ev.ErrorCode}"));
        }

        void Open() {
            Assert.NotNull(TonNurako.X11.Xi.SetLocale(TonNurako.X11.XLocale.LC_ALL, ""));

            display = TonNurako.X11.Display.Open(null);
            Assert.NotNull(display);
        }

        public void Dispose() {
            if (display != null) {
                display.SetCloseDownMode(TonNurako.X11.CloseDownMode.DestroyAll);
                display.Close();
            }
            TonNurako.X11.Xi.SetIOErrorHandler(null);
            TonNurako.X11.Xi.SetErrorHandler(null);
            TonNurako.Application.UnregisterGlobals();
        }

        [Fact]
        public void StandardSqeuence() {
            Assert.NotNull(TonNurako.X11.Xi.SetLocale(TonNurako.X11.XLocale.LC_ALL, ""));
            Assert.True(TonNurako.X11.Xi.SupportsLocale());
            Assert.NotNull(TonNurako.X11.Xi.SetLocaleModifiers(""));

            var dpy = TonNurako.X11.Display.Open(null);
            Assert.NotNull(dpy);
            Assert.True(dpy.Close() >= 0);
        }

        [Fact]
        public void DisplayContext() {
            Open();

            var dpy = display;

            Assert.NotNull(dpy.GetDisplayName());
            Assert.NotNull(dpy.DefaultColormap);
            Assert.NotNull(dpy.GetDefaultColormap(0));
            Assert.NotNull(dpy.GetRootWindow(0));
            Assert.NotNull(dpy.DefaultRootWindow);

            Assert.NotNull(dpy.GetScreenOfDisplay(0));
            Assert.NotNull(dpy.DefaultScreenOfDisplay);

            Assert.NotNull(dpy.DefaultVisual);
            Assert.NotNull(dpy.GetDefaultVisual(0));

            Assert.NotNull(dpy.ServerVendor);
            Assert.NotNull(dpy.DisplayString);

            var ks = dpy.KeysymToKeycode(TonNurako.X11.KeySym.XK_F5);
            Assert.NotEqual<uint>(0, ks);

            Assert.Equal(TonNurako.X11.KeySym.XK_F5, dpy.KeycodeToKeysym(ks, 0, 0));

            Assert.Equal(TonNurako.X11.KeySym.XK_F5, dpy.StringToKeysym("F5"));
            Assert.Equal("F5", dpy.KeysymToString(TonNurako.X11.KeySym.XK_F5));


        }

        [Fact]
        public void AbnormalSqeuence() {
            Assert.NotNull(TonNurako.X11.Xi.SetLocale(TonNurako.X11.XLocale.LC_ALL, ""));
            Assert.True(TonNurako.X11.Xi.SupportsLocale());
            Assert.NotNull(TonNurako.X11.Xi.SetLocaleModifiers(""));

            var dpy = TonNurako.X11.Display.Open(@"ｳﾁｮﾑーﾁｮ");
            Assert.Null(dpy);
        }

        [Fact]
        public void TextPropertyTest() {
            Open();

            using (var p = XTextProperty.Create(display, "ﾌﾟﾛﾊﾟﾁー")) {
                Assert.NotNull(p);
            }

            using (var p = XTextProperty.TextListToTextProperty(display, new[] { "ﾌﾟﾛﾊﾟﾁー" }, XICCEncodingStyle.XCompoundTextStyle)) {
                Assert.NotNull(p);
            }

            using (var p = XTextProperty.TextListToTextProperty(display, new[] { "ﾌﾟﾛﾊﾟﾁー" }, XICCEncodingStyle.XCompoundTextStyle)) {
                Assert.NotNull(p);
                Assert.NotNull(p.TextPropertyToTextList(display));
            }

        }

        [Fact]
        public void StandardOperation() {
            Open();
            var dpy = display;
            Assert.Equal(XStatus.True, dpy.GrabServer());
            Assert.Equal(XStatus.True, dpy.UngrabServer());
            using (var arg = new XEventArg()) {
                Assert.False(dpy.CheckMaskEvent(EventMask.ExposureMask, arg));
                Assert.False(dpy.CheckTypedEvent(XEventType.Expose, arg));
            }
            KeySym upper, lower;
            dpy.ConvertCase(KeySym.XK_A, out lower, out upper);
            Assert.Equal(KeySym.XK_A, upper);
            Assert.Equal(KeySym.XK_a, lower);

            int min, max;
            Assert.Equal(XStatus.True, dpy.DisplayKeycodes(out min, out max));

            using (var mod = dpy.GetModifierMapping()) {
                Assert.NotNull(mod);
            }

        }
    }
}
