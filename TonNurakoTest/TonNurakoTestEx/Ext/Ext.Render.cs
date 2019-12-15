using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using Xunit;
using TonNurako.X11.Extension;
using System;

namespace TonNurakoTestEx {
    public class RenderTest : IClassFixture<WindowFixture>, IDisposable {
        WindowFixture fix;
        Unity unity;
        public RenderTest(WindowFixture fixture) {
            fix = fixture;
            unity = new Unity();
        }

        public void Dispose() {
            unity.Asset();
        }

        [Fact]
        public void StandardFunction() {
            Assert.True(XRender.QueryExtension(fix.Display));
            Assert.NotNull(XRender.QueryVersion(fix.Display));
            Assert.NotEqual(0, XRender.QueryFormats(fix.Display));

            var spo = XRender.QuerySubpixelOrder(fix.Display, fix.Display.DefaultScreen);
            Assert.True(XRender.SetSubpixelOrder(fix.Display, fix.Display.DefaultScreen, SubPixel.SubPixelVerticalRGB));
            Assert.Equal(SubPixel.SubPixelVerticalRGB, XRender.QuerySubpixelOrder(fix.Display, fix.Display.DefaultScreen));
            Assert.True(XRender.SetSubpixelOrder(fix.Display, fix.Display.DefaultScreen, spo));
            Assert.Equal(spo, XRender.QuerySubpixelOrder(fix.Display, fix.Display.DefaultScreen));

            Assert.NotNull(XRender.FindVisualFormat(fix.Display, fix.Display.DefaultVisual));
            Assert.NotNull(XRender.FindStandardFormat(fix.Display, PictStandard.ARGB32));

            //Assert.NotNull(XRender.QueryPictIndexValues(fix.Display, null));
            Assert.NotNull(XRender.QueryFilters(fix.Display, fix.Window));

            XRender.ParseColor(fix.Display, "green");
            Assert.ThrowsAny<System.Exception>(()=>XRender.ParseColor(fix.Display, "うんこ色"));
        }

        [Fact]
        public void Picture() {
            using (var pm = new Pixmap(fix.Window, 100, 100, 8)) {
                Assert.NotNull(pm);
                using(var pic = XRender.CreatePicture(
                    fix.Display, pm, XRender.FindStandardFormat(fix.Display, PictStandard.A8), CreatePictureMask.None, new XRenderPictureAttributes()))
                {
                    Assert.NotNull(pic);
                }
            }
        }

        [Fact]
        public void StdDraw() {
            var pm = new Pixmap(fix.Window, 100, 100, 8);
            Assert.NotNull(pm);
            using(var src = XRender.CreatePicture(
                fix.Display, pm, XRender.FindStandardFormat(fix.Display, PictStandard.A8), CreatePictureMask.None, new XRenderPictureAttributes()))
            using(var dest = XRender.CreatePicture(
                fix.Display, pm, XRender.FindStandardFormat(fix.Display, PictStandard.A8), CreatePictureMask.None, new XRenderPictureAttributes()))
            {
                Assert.NotNull(src);
                Assert.NotNull(dest);
                DrawFunc(pm, dest);
                FillFunc(100, 100);
                CompositeFunc(src, dest, 100, 100);
            }
            pm.Dispose();
        }

        void DrawFunc(Pixmap pixmap, Picture picture) {
            XRender.ChangePicture(fix.Display, picture, CreatePictureMask.None, new XRenderPictureAttributes());
            XRender.SetPictureFilter(fix.Display, picture, Filter.FilterConvolution, CreateGaussianKernel2D(10));
            XRender.SetPictureClipRectangles(fix.Display, picture, 0, 0, new[]{new XRectangle(5,5,5,5)});
            using(var rgn = Region.Create()) {
                XRender.SetPictureClipRegion(fix.Display, picture, rgn);
            }
            var xt = new XTransform();
            XRender.SetPictureTransform(fix.Display, picture, xt);
            var color = XRender.ParseColor(fix.Display, "green");
            XRender.FillRectangle(fix.Display, PictOp.Over, picture, color, 0, 0, 100, 100);
            XRender.FillRectangles(fix.Display, PictOp.Over, picture, color, new[]{new XRectangle(0,0,100,100)});
        }

        void CompositeFunc(Picture src, Picture dest, int width, int height) {
            var trapezoid = new XTrapezoid(
                TonNurako.X11.Xi.DoubleToFixed(30.0f),
                TonNurako.X11.Xi.DoubleToFixed((double)height - 30.0f),
                new XLineFixed(
                    new XPointFixed(
                        TonNurako.X11.Xi.DoubleToFixed(30.0f),
                        TonNurako.X11.Xi.DoubleToFixed(30.0f)),
                    new XPointFixed(
                        TonNurako.X11.Xi.DoubleToFixed(30.0f),
                        TonNurako.X11.Xi.DoubleToFixed((double)height - 30.0f))),
                new XLineFixed(
                    new XPointFixed(
                        TonNurako.X11.Xi.DoubleToFixed((double)width - 30.0f),
                        TonNurako.X11.Xi.DoubleToFixed(30.0f)),
                    new XPointFixed(
                        TonNurako.X11.Xi.DoubleToFixed((double)width -  30.0f),
                        TonNurako.X11.Xi.DoubleToFixed((double)height - 30.0f)))
            );

            var pfm = XRender.FindStandardFormat(fix.Display, PictStandard.A8);
            XRender.CompositeTrapezoid(fix.Display, PictOp.Over, src, dest, pfm, 0, 0, trapezoid);
            XRender.CompositeTrapezoids(fix.Display, PictOp.Over, src, dest, pfm, 0, 0, new[]{trapezoid, trapezoid});

            var triangle = new XTriangle(new XPointFixed(50, 0), new XPointFixed(100, 100), new XPointFixed(0, 100));
            XRender.CompositeTriangles(
                fix.Display, PictOp.Over, src, dest, pfm, 0, 0, new[]{triangle});

            XRender.CompositeTriStrip(
                fix.Display, PictOp.Over, src, dest, pfm, 0, 0, new[]{new XPointFixed(50, 0), new XPointFixed(100, 100), new XPointFixed(0, 100)});
            XRender.CompositeTriFan(
                fix.Display, PictOp.Over, src, dest, pfm, 0, 0, new[]{new XPointFixed(50, 0), new XPointFixed(100, 100), new XPointFixed(0, 100)});

            XRender.CompositeDoublePoly(
                fix.Display, PictOp.Over, src, dest, pfm, 0, 0, 0, 0, new[]{new XPointDouble(50, 0), new XPointDouble(100, 100), new XPointDouble(0, 100)}, 0);

            using(var pm = new Pixmap(fix.Display, fix.Window, width, height, 8))
            using(var mask = XRender.CreatePicture(
                    fix.Display, pm, XRender.FindStandardFormat(fix.Display, PictStandard.A8), CreatePictureMask.None, new XRenderPictureAttributes()))
            {
                XRender.Composite(fix.Display, PictOp.Src, src, mask, dest, 0, 0, 0, 0, 0, 0, width, height);
            }

        }

        void FillFunc(int width, int height) {
            var colors = new XRenderColor[] {
                new XRenderColor(0xffff, 0x0000, 0x0000, 0xffff),
                new XRenderColor(0x0000, 0xffff, 0x0000, 0xffff),
                new XRenderColor(0x0000, 0x0000, 0xffff, 0xffff),
            };

            var linearGradient = new XLinearGradient(
                new XPointFixed(TonNurako.X11.Xi.DoubleToFixed(0.0f), TonNurako.X11.Xi.DoubleToFixed(0.0f)),
                new XPointFixed(TonNurako.X11.Xi.DoubleToFixed(0.0f), TonNurako.X11.Xi.DoubleToFixed((double)height/10))
            );

            var conicalGradient = new XConicalGradient(
                    new XPointFixed(TonNurako.X11.Xi.DoubleToFixed((double)width/2), TonNurako.X11.Xi.DoubleToFixed((double)height/2)),
                    TonNurako.X11.Xi.DoubleToFixed(123.0f)
                );

            var radialGradient = new XRadialGradient(
                new XCircle(TonNurako.X11.Xi.DoubleToFixed(50.0f), TonNurako.X11.Xi.DoubleToFixed(50.0f), TonNurako.X11.Xi.DoubleToFixed(45.0f)),
                new XCircle(TonNurako.X11.Xi.DoubleToFixed(100.0f), TonNurako.X11.Xi.DoubleToFixed(75.0f), TonNurako.X11.Xi.DoubleToFixed(200.0f))
            );

            var colorStops = new int[] {
                TonNurako.X11.Xi.DoubleToFixed(0.0f),
                TonNurako.X11.Xi.DoubleToFixed(0.33f),
                TonNurako.X11.Xi.DoubleToFixed(0.66f),
                TonNurako.X11.Xi.DoubleToFixed(1.0f)
            };

            using(var g  = TonNurako.X11.Extension.XRender.CreateSolidFill(fix.Display, colors[0])) {
                Assert.NotNull(g);
            }

            using(var g  = TonNurako.X11.Extension.XRender.CreateConicalGradient(fix.Display, conicalGradient, colorStops, colors)) {
                Assert.NotNull(g);
            }
            using(var g  = TonNurako.X11.Extension.XRender.CreateLinearGradient(fix.Display, linearGradient, colorStops, colors)) {
                Assert.NotNull(g);
            }
            using(var g  = TonNurako.X11.Extension.XRender.CreateRadialGradient(fix.Display, radialGradient, colorStops, colors)) {
                Assert.NotNull(g);
            }
        }


         int[] CreateGaussianKernel2D(int radius) {
            double fU;
            double fV;
            int iX;
            int iY;
            double fSum = 0.0f;

            double fSigma = (double)radius / 2.0f;
            var fScale2 = 2.0f * fSigma * fSigma;
            var fScale1 = 1.0f / (Math.PI * fScale2);

            var size = 4 * radius * radius;
            var pTmpKernel = new double[size];

            for (iX = 0; iX < 2 * radius; iX++) {
                for (iY = 0; iY < 2 * radius; iY++) {
                    fU = (double)iX;
                    fV = (double)iY;
                    pTmpKernel[iX + iY * 2 * radius] = fScale1 *
                                    Math.Exp(-(fU * fU + fV * fV) / fScale2);
                }
            }

            for (iX = 0; iX < radius; iX++)
                fSum += pTmpKernel[iX];

            for (iX = 0; iX < radius; iX++)
                pTmpKernel[iX] /= fSum;

            var pKernel = new int[size + 2];

            for (iX = 0; iX < size; iX++)
                pKernel[iX + 2] = TonNurako.X11.Xi.DoubleToFixed(pTmpKernel[iX]);

            //*piSize += 2;
            pKernel[0] = TonNurako.X11.Xi.DoubleToFixed(2 * radius);
            pKernel[1] = TonNurako.X11.Xi.DoubleToFixed(2 * radius);

            return pKernel;
        }
    }
}
