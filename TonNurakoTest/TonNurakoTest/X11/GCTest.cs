using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using Xunit;

namespace TonNurakoTest.X11 {
    public class GCTest : IClassFixture<WindowFixture> {
        WindowFixture fix;

        public GCTest(WindowFixture fixture) {
            fix = fixture;
        }


        [Fact]
        public void GcTest() {
            using (var gc = TonNurako.X11.GC.Create(fix.Window)) {
                Assert.NotNull(gc);
            }

            var v = new XGCValues();
            v.Background = Color.AllocNamedColor(fix.Display, fix.Display.DefaultColormap, "white").Pixel;
            using (var gc = TonNurako.X11.GC.Create(fix.Window, GCMask.GCBackground, v)) {
                Assert.NotNull(gc);
                Assert.NotNull(gc.GetGCValues(GCMask.GCBackground));
            }
        }

        [Fact]
        public void TextCallTest() {
            using (var gc = TonNurako.X11.GC.Create(fix.Window)) {
                Assert.NotNull(gc);
                DrawText(gc);
            }
        }

        [Fact]
        public void DrawCallTest() {
            using (var gc = TonNurako.X11.GC.Create(fix.Window)) {
                Assert.NotNull(gc);
                DrawText(gc);

                DrawPrimitive(gc);

                Assert.Equal(XStatus.True, gc.SetLineAttributes(10, LineStyle.Solid, CapStyle.Round, JoinStyle.Bevel));
                DrawPrimitive(gc);
                Assert.Equal(XStatus.True, gc.SetDashes(0, new byte[] { 20, 10, 5, 10 }));
                DrawPrimitive(gc);
            }
        }

        [Fact]
        public void DrawOffscreenTest() {
            using (var pixmap = new Pixmap(fix.Window, 100, 100, 24))
            using (var gc = TonNurako.X11.GC.Create(pixmap)) 
            {
                Assert.NotNull(gc);
                DrawText(gc);

                DrawPrimitive(gc);

                Assert.Equal(XStatus.True, gc.SetLineAttributes(10, LineStyle.Solid, CapStyle.Round, JoinStyle.Bevel));
                DrawPrimitive(gc);
                Assert.Equal(XStatus.True, gc.SetDashes(0, new byte[] { 20, 10, 5, 10 }));
                DrawPrimitive(gc);
            }
        }

        [Fact]
        public void ColorTest() {
                Assert.NotNull(Color.AllocNamedColor(fix.Display, fix.Display.DefaultColormap, "Green"));
                Assert.Throws<System.ArgumentException>(
                    () => Color.AllocNamedColor(fix.Display, fix.Display.DefaultColormap, "【神】俺様が考えた最強カラー【降臨】"));

                Assert.NotNull(Color.AllocColor(fix.Display, fix.Display.DefaultColormap, 0xff, 0xff, 0xff));
                Assert.NotNull(Color.LookupColor(fix.Display, fix.Display.DefaultColormap, "black"));
                var xc = new XColor();
                xc.Pixel = 0x00;
                Assert.NotNull(Color.QueryColor(fix.Display, fix.Display.DefaultColormap, xc));

                var arr = new[] { xc, xc, xc };
                var cs = Color.QueryColors(fix.Display, fix.Display.DefaultColormap, arr);
                Assert.NotNull(cs);
                Assert.Equal(arr.Length, cs.Length);

                Assert.NotNull(Color.ParseColor(fix.Display, fix.Display.DefaultColormap, "white"));

        }

        void DrawText(TonNurako.X11.GC gc) {
            using (var fs = FontSet.CreateFontSet(fix.Display, "*misc*")) {
                Assert.NotNull(fs);

                gc.DrawStringMultiByte(fs, 0, 0, "【神】俺様の文字列【降臨");
                gc.DrawString(fs, 0, 0, "【神】俺様の文字列【降臨");
                gc.DrawImageString(fs, 0, 0, "【神】俺様の文字列【降臨");
            }
        }

        void DrawPrimitive(TonNurako.X11.GC gc) {
            gc.DrawPoint(0, 0);
            gc.DrawPoints(new[] { new XPoint(0, 0), new XPoint(10, 10) }, CoordMode.Origin);

            gc.DrawLine(0, 0, 300, 300);
            gc.DrawLines(new[] { new XPoint(0, 0), new XPoint(300, 300) }, CoordMode.Origin);

            gc.DrawRectangle(0, 0, 300, 300);
            gc.DrawRectangle(new[] { new XRectangle(10, 10, 100, 100), new XRectangle(100, 100, 200, 200) });

            gc.FillRectangle(0, 0, 300, 300);
            gc.FillRectangles(new[] { new XRectangle(10, 10, 100, 100), new XRectangle(100, 100, 200, 200) });

            gc.DrawArc(0, 0, 100, 100, 64, 90 * 64);
            gc.DrawArcs(new[] { new XArc(0, 0, 100, 100, 64, 90 * 64), new XArc(100, 100, 100, 100, 64, 90 * 64) });

            gc.FillArc(0, 0, 100, 100, 64, 90 * 64);
            gc.FillArcs(new[] { new XArc(0, 0, 100, 100, 64, 90 * 64), new XArc(100, 100, 100, 100, 64, 90 * 64) });
        }


    }
}

