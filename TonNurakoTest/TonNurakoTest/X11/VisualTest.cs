using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using Xunit;

namespace TonNurakoTest.X11 {
    public class VisualTest : IClassFixture<WindowFixture> {

        WindowFixture fix;
        public VisualTest(WindowFixture fixture)  {
            fix = fixture;
        }

        [Fact]
        public void ServerProps() {
            var v = fix.Display.DefaultVisual;
            Assert.NotNull(v);
        }
    }
}
