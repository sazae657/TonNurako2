using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using TonNurako.X11.Extension;
using Xunit;

namespace TonNurakoTestEx {
    public class ShapeTest : IClassFixture<WindowFixture>, IDisposable {
        WindowFixture fix;
        Unity unity;
        public ShapeTest(WindowFixture fixture) {
            fix = fixture;
            unity = new Unity();
        }

        public void Dispose() {
            unity.Asset();
        }

        [Fact]
        public void StandardRule() {
            Assert.True(XShape.QueryExtension(fix.Display));
            Assert.NotNull(XShape.QueryVersion(fix.Display));
            using(var pm = new Pixmap(fix.Window, 80, 80, 1)) {
                XShape.CombineMask(fix.Display, fix.Window, ShapeKind.ShapeBounding, 0, 0, pm, ShapeOp.ShapeSet);
            }
            XShape.CombineRectangles(fix.Display, fix.Window, ShapeKind.ShapeBounding, 0, 0,
                new[]{new XRectangle(0, 0, 10, 10), new XRectangle(10, 10, 10, 10)}, ShapeOp.ShapeSet, Ordering.Unsorted);
            XShape.OffsetShape(fix.Display, fix.Window, ShapeKind.ShapeBounding, 0, 0);
            Assert.Equal(ShapeEventMask.None, XShape.InputSelected(fix.Display, fix.Window));
            XShape.SelectInput(fix.Display, fix.Window, ShapeEventMask.ShapeNotifyMask);
            Assert.Equal(ShapeEventMask.ShapeNotifyMask, XShape.InputSelected(fix.Display, fix.Window));
        }
    }
}
