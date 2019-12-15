using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using Xunit;

namespace TonNurakoTest.X11 {
    public class WindowTest : IClassFixture<DisplayFixture> {

        DisplayFixture fix;
        Window window;
        delegate void NopDelegaty();
        Unity unity = new Unity();

        public WindowTest(DisplayFixture fixture) {
            fix = fixture;
        }

        void Close() {
            unity.Asset();
            if (null != window) {
                window.DestroyWindow();
                window = null;
            }
        }

        [Fact]
        void StandardWindwTest() {
            CreateWindow(
               BeforeCreateWindow: ()=>{
                },
                BeforeMapWindow:()=>{
                    Assert.Empty(window.GetWMProtocols());
                },
                AfterMapWindow: ()=>{}
            );
            Close();
        }

        [Fact]
        void StdProps() {
            CreateWindow(
               BeforeCreateWindow: ()=>{
                },
                BeforeMapWindow:() =>{ },
                AfterMapWindow: () =>{
                    Assert.Equal(XStatus.True, window.StoreName("UNKO"));
                    Assert.Equal("UNKO", window.FetchName());

                    Assert.Equal(XStatus.True, window.SetIconName("UNKO"));
                    Assert.Equal("UNKO", window.GetIconName());

                    var color = Color.AllocNamedColor(fix.Display, fix.Display.DefaultColormap, "green");
                    Assert.NotNull(color);

                    Assert.Equal(XStatus.True, window.SetWindowBackground(color));
                    Assert.Equal(XStatus.True, window.SetWindowBorder(color));

                    var pm = new Pixmap(fix.Display, window, 100, 100, fix.Display.DefaultDepth);
                    Assert.Equal(XStatus.True, window.SetWindowBackgroundPixmap(pm));
                    Assert.Equal(XStatus.True, window.SetWindowBorderPixmap(pm));
                    unity.Store(pm);

                    Assert.Equal(XStatus.True, window.MoveWindow(0, 0));
                    Assert.Equal(XStatus.True, window.ResizeWindow(10, 10));
                    Assert.Equal(XStatus.True, window.MoveResizeWindow(10,10, 20, 20));
                    Assert.Equal(XStatus.True, window.SetWindowBorderWidth(10));
                    Assert.NotNull(window.GetWindowAttributes());
                    Assert.NotNull(window.GetGeometry());
                }
            );
            Close();
        }

        [Fact]
        void Protocols() {
            var atom = TonNurako.X11.Atom.InternAtom(fix.Display, "WM_DELETE_WINDOW", false);
            Assert.NotNull(atom);
            Assert.Equal("WM_DELETE_WINDOW", atom.Name);

            var atom1 = TonNurako.X11.Atom.InternAtom(fix.Display, "WM_DELETE_WINDOW", false);
            Assert.NotNull(atom1);
            Assert.True(atom.Equals(atom1));

            var atom2 = TonNurako.X11.Atom.InternAtom(fix.Display, "俺様の考えた最強のﾌﾟﾛﾄｺﾙ", false);
            Assert.NotNull(atom2);
            Assert.False(atom.Equals(atom2));
            Assert.Equal("俺様の考えた最強のﾌﾟﾛﾄｺﾙ", atom2.Name);

            var ass = TonNurako.X11.Atom.InternAtoms(fix.Display, new[]{"WM_DELETE_WINDOW", "WM_CLOSE", "WM_FOREACH"}, false);
            Assert.NotNull(ass);

            CreateWindow(
               BeforeCreateWindow: ()=>{
                },
                BeforeMapWindow:()=>{
                    var attr = new TonNurako.X11.XSetWindowAttributes();
                    attr.BackingStore = TonNurako.X11.BackingStoreHint.WhenMapped;
                    Assert.Equal(XStatus.True, window.ChangeWindowAttributes(TonNurako.X11.ChangeWindowAttributes.CWBackingStore, attr));

                    Assert.Empty(window.GetWMProtocols());

                    Assert.Equal(XStatus.True, window.SetWMProtocols(new TonNurako.X11.Atom[] { atom, atom2 }));
                    Assert.NotEmpty(window.GetWMProtocols());

                    using(var rpr = TonNurako.X11.XTextProperty.TextListToTextProperty(
                        fix.Display, new string[] { "たいとる" }, TonNurako.X11.XICCEncodingStyle.XCompoundTextStyle)) {
                        Assert.NotNull(rpr);
                        window.SetWMName(rpr);
                    }
                    using(var rpr = TonNurako.X11.XTextProperty.TextListToTextProperty(
                        fix.Display, new string[] { "エイコン" }, TonNurako.X11.XICCEncodingStyle.XCompoundTextStyle)) {
                        Assert.NotNull(rpr);
                        window.SetWMIconName(rpr);
                    }

                    using(var prpr = window.GetWMName()) {
                        Assert.NotNull(prpr);
                        var r = prpr.TextPropertyToTextList(fix.Display);
                        Assert.NotNull(r);
                        Assert.Single(r);
                    }
                    using(var prpr = window.GetWMIconName()) {
                        Assert.NotNull(prpr);
                        var r = prpr.TextPropertyToTextList(fix.Display);
                        Assert.NotNull(r);
                        Assert.Single(r);
                    }

                },
                AfterMapWindow: ()=>{}
            );
            Close();
        }

        void CreateWindow(
            NopDelegaty BeforeCreateWindow, NopDelegaty BeforeMapWindow, NopDelegaty AfterMapWindow) {
            var visual = fix.Display.DefaultVisual;
            Assert.NotNull(visual);

            var wsa = new TonNurako.X11.XSetWindowAttributes();
            wsa.BackgroundPixel = fix.Display.WhitePixel;
            var wam = TonNurako.X11.ChangeWindowAttributes.CWBackPixel;

            BeforeCreateWindow();

            this.window = fix.Display.CreateWindow(
                fix.Display.DefaultRootWindow, 50, 50, 50, 50, 0,
                fix.Display.DefaultDepth, TonNurako.X11.WindowClass.InputOutput, visual, wam, wsa);
            Assert.NotNull(this.window);

            BeforeMapWindow();

            Assert.Equal(XStatus.True, this.window.MapWindow());
            Assert.Equal(XStatus.True, fix.Display.Flush());

            AfterMapWindow();
        }


    }
}
