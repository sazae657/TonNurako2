using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonNurako.X11;
using Xunit;

namespace TonNurakoTest.X11 {
    public class XFontTest : IClassFixture<DisplayFixture> {
        DisplayFixture display;
        public XFontTest(DisplayFixture fixture) {
            display = fixture;
        }

        [Fact]
        public void FontSetTest() {           
            Assert.ThrowsAny<System.Exception>(() => FontSet.ListFonts(display.Display, "【神】俺様が考えたすごいフォント【降臨】", 100));
            Assert.NotNull(FontSet.ListFonts(display.Display, "*", 10));

            Assert.ThrowsAny<System.Exception>(() => {
                using (FontSet.CreateFontSet(display.Display, "【神】俺様が考えたすごいフォント【降臨】")) {};
            });
            var fs = TonNurako.X11.FontSet.CreateFontSet(display.Display, "-*-fixed-medium-r-normal--*-*-*-*");
            Assert.NotNull(fs);

            var rc1 = new TonNurako.X11.TextExtents();
            Assert.NotEqual(ErrorCode.BadFont, fs.TextExtentsMultiByte("A", rc1));
            

            var rc2 = new TonNurako.X11.TextExtents();
            Assert.NotEqual(ErrorCode.BadFont, fs.TextExtents("A", rc2));

            using (var xe = fs.XExtentsOfFontSet()) {
                Assert.NotNull(xe);
            }

            fs.Dispose();
        }

    }
}
