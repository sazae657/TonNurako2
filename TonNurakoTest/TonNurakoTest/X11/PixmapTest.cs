using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using Xunit;

namespace TonNurakoTest.X11 {
    public class PixmapTest : IClassFixture<WindowFixture> {

        WindowFixture fix;

        public PixmapTest(WindowFixture fixture) {
            fix = fixture;
        }

        [Fact]
        public void StandardPixmap() {
            using (var pm = new Pixmap(fix.Display, fix.Window, 100, 100, fix.Display.DefaultDepth)) {
            }
            using (var pm = new Pixmap(fix.Window, 100, 100, fix.Display.DefaultDepth)) {
            }
        }
    }
}
