using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.Native;

namespace TonNurako.X11.Extension {

    public enum PictFormat :int {
        ID = TonNurako.X11.Constant.PictFormatID,
        Type = TonNurako.X11.Constant.PictFormatType,
        Depth = TonNurako.X11.Constant.PictFormatDepth,
        Red = TonNurako.X11.Constant.PictFormatRed,
        RedMask = TonNurako.X11.Constant.PictFormatRedMask,
        FormatGreen = TonNurako.X11.Constant.PictFormatGreen,
        GreenMask = TonNurako.X11.Constant.PictFormatGreenMask,
        Blue = TonNurako.X11.Constant.PictFormatBlue,
        BlueMask = TonNurako.X11.Constant.PictFormatBlueMask,
        Alpha = TonNurako.X11.Constant.PictFormatAlpha,
        AlphaMask = TonNurako.X11.Constant.PictFormatAlphaMask,
        Colormap = TonNurako.X11.Constant.PictFormatColormap,
    }

    public enum PictStandard :int {
        ARGB32 = TonNurako.X11.Constant.PictStandardARGB32,
        RGB24 = TonNurako.X11.Constant.PictStandardRGB24,
        A8 = TonNurako.X11.Constant.PictStandardA8,
        A4 = TonNurako.X11.Constant.PictStandardA4,
        A1 = TonNurako.X11.Constant.PictStandardA1,
        NUM = TonNurako.X11.Constant.PictStandardNUM,
    }

    [Flags]
    public enum CreatePictureMask : ulong {
        None = 0,
        CPRepeat = TonNurako.X11.Constant.CPRepeat,
        CPAlphaMap = TonNurako.X11.Constant.CPAlphaMap,
        CPAlphaXOrigin = TonNurako.X11.Constant.CPAlphaXOrigin,
        CPAlphaYOrigin = TonNurako.X11.Constant.CPAlphaYOrigin,
        CPClipXOrigin = TonNurako.X11.Constant.CPClipXOrigin,
        CPClipYOrigin = TonNurako.X11.Constant.CPClipYOrigin,
        CPClipMask = TonNurako.X11.Constant.CPClipMask,
        CPGraphicsExposure = TonNurako.X11.Constant.CPGraphicsExposure,
        CPSubwindowMode = TonNurako.X11.Constant.CPSubwindowMode,
        CPPolyEdge = TonNurako.X11.Constant.CPPolyEdge,
        CPPolyMode = TonNurako.X11.Constant.CPPolyMode,
        CPDither = TonNurako.X11.Constant.CPDither,
        CPComponentAlpha = TonNurako.X11.Constant.CPComponentAlpha,
        CPLastBit = TonNurako.X11.Constant.CPLastBit,
    }

    public enum PictOp :int {
        Minimum = TonNurako.X11.Constant.PictOpMinimum,
        Clear = TonNurako.X11.Constant.PictOpClear,
        Src = TonNurako.X11.Constant.PictOpSrc,
        Dst = TonNurako.X11.Constant.PictOpDst,
        Over = TonNurako.X11.Constant.PictOpOver,
        OverReverse = TonNurako.X11.Constant.PictOpOverReverse,
        In = TonNurako.X11.Constant.PictOpIn,
        InReverse = TonNurako.X11.Constant.PictOpInReverse,
        Out = TonNurako.X11.Constant.PictOpOut,
        OutReverse = TonNurako.X11.Constant.PictOpOutReverse,
        Atop = TonNurako.X11.Constant.PictOpAtop,
        AtopReverse = TonNurako.X11.Constant.PictOpAtopReverse,
        Xor = TonNurako.X11.Constant.PictOpXor,
        Add = TonNurako.X11.Constant.PictOpAdd,
        Saturate = TonNurako.X11.Constant.PictOpSaturate,
        Maximum = TonNurako.X11.Constant.PictOpMaximum,
        DisjointMinimum = TonNurako.X11.Constant.PictOpDisjointMinimum,
        DisjointClear = TonNurako.X11.Constant.PictOpDisjointClear,
        DisjointSrc = TonNurako.X11.Constant.PictOpDisjointSrc,
        DisjointDst = TonNurako.X11.Constant.PictOpDisjointDst,
        DisjointOver = TonNurako.X11.Constant.PictOpDisjointOver,
        DisjointOverReverse = TonNurako.X11.Constant.PictOpDisjointOverReverse,
        DisjointIn = TonNurako.X11.Constant.PictOpDisjointIn,
        DisjointInReverse = TonNurako.X11.Constant.PictOpDisjointInReverse,
        DisjointOut = TonNurako.X11.Constant.PictOpDisjointOut,
        DisjointOutReverse = TonNurako.X11.Constant.PictOpDisjointOutReverse,
        DisjointAtop = TonNurako.X11.Constant.PictOpDisjointAtop,
        DisjointAtopReverse = TonNurako.X11.Constant.PictOpDisjointAtopReverse,
        DisjointXor = TonNurako.X11.Constant.PictOpDisjointXor,
        DisjointMaximum = TonNurako.X11.Constant.PictOpDisjointMaximum,
        ConjointMinimum = TonNurako.X11.Constant.PictOpConjointMinimum,
        ConjointClear = TonNurako.X11.Constant.PictOpConjointClear,
        ConjointSrc = TonNurako.X11.Constant.PictOpConjointSrc,
        ConjointDst = TonNurako.X11.Constant.PictOpConjointDst,
        ConjointOver = TonNurako.X11.Constant.PictOpConjointOver,
        ConjointOverReverse = TonNurako.X11.Constant.PictOpConjointOverReverse,
        ConjointIn = TonNurako.X11.Constant.PictOpConjointIn,
        ConjointInReverse = TonNurako.X11.Constant.PictOpConjointInReverse,
        ConjointOut = TonNurako.X11.Constant.PictOpConjointOut,
        ConjointOutReverse = TonNurako.X11.Constant.PictOpConjointOutReverse,
        ConjointAtop = TonNurako.X11.Constant.PictOpConjointAtop,
        ConjointAtopReverse = TonNurako.X11.Constant.PictOpConjointAtopReverse,
        ConjointXor = TonNurako.X11.Constant.PictOpConjointXor,
        ConjointMaximum = TonNurako.X11.Constant.PictOpConjointMaximum,
        BlendMinimum = TonNurako.X11.Constant.PictOpBlendMinimum,
        Multiply = TonNurako.X11.Constant.PictOpMultiply,
        Screen = TonNurako.X11.Constant.PictOpScreen,
        Overlay = TonNurako.X11.Constant.PictOpOverlay,
        Darken = TonNurako.X11.Constant.PictOpDarken,
        Lighten = TonNurako.X11.Constant.PictOpLighten,
        ColorDodge = TonNurako.X11.Constant.PictOpColorDodge,
        ColorBurn = TonNurako.X11.Constant.PictOpColorBurn,
        HardLight = TonNurako.X11.Constant.PictOpHardLight,
        SoftLight = TonNurako.X11.Constant.PictOpSoftLight,
        Difference = TonNurako.X11.Constant.PictOpDifference,
        Exclusion = TonNurako.X11.Constant.PictOpExclusion,
        HSLHue = TonNurako.X11.Constant.PictOpHSLHue,
        HSLSaturation = TonNurako.X11.Constant.PictOpHSLSaturation,
        HSLColor = TonNurako.X11.Constant.PictOpHSLColor,
        HSLLuminosity = TonNurako.X11.Constant.PictOpHSLLuminosity,
        BlendMaximum = TonNurako.X11.Constant.PictOpBlendMaximum,
    }

    public enum SubPixel : int {
        SubPixelUnknown = TonNurako.X11.Constant.SubPixelUnknown,
        SubPixelHorizontalRGB = TonNurako.X11.Constant.SubPixelHorizontalRGB,
        SubPixelHorizontalBGR = TonNurako.X11.Constant.SubPixelHorizontalBGR,
        SubPixelVerticalRGB = TonNurako.X11.Constant.SubPixelVerticalRGB,
        SubPixelVerticalBGR = TonNurako.X11.Constant.SubPixelVerticalBGR,
        SubPixelNone = TonNurako.X11.Constant.SubPixelNone,
    }

    public enum Filter {
        FilterNearest,
        FilterBilinear,
        FilterConvolution,
        FilterFast,
        FilterGood,
        FilterBest
    }
    public static class FilterExt {
        public static string AsString(this Filter value) {
            string[] values = {
                StringConstant.FilterNearest,
                StringConstant.FilterBilinear,
                StringConstant.FilterConvolution,
                StringConstant.FilterFast,
                StringConstant.FilterGood,
                StringConstant.FilterBest,
            };
            return values[(int)value];
        }
    }


    public class Picture : IX11Interop<int> , IDisposable {
        bool disposable = true;

        int handle;
        public int Handle => (delegaty == null) ? handle : delegaty();

        Display display;
        internal Display Display => display;

        public Picture(Display display, int pic) {
            handle = pic;
            this.display = display;
        }

        public Picture(Display display, int pic, bool disposable) {
            handle = pic;
            this.display = display;
            this.disposable = disposable;
        }

        ReturnPointerDelegaty<int> delegaty;
        public Picture(ReturnPointerDelegaty<int> pic, bool disposable) {
            delegaty = pic;
            this.disposable = disposable;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (0 != handle) {
                    if (disposable) {
                        // TODO: 微妙にダサイのであとで考える
                        XRender.FreePicture(this);
                    }
                    handle = 0;
                }
                disposedValue = true;
            }
        }
        #if RLE
        ~Picture() {
            if (0 != handle && disposable) {
                throw new ResourceLeakException(this.GetType());
            }
            Dispose(false);
        }
        #endif

        public void Dispose() {
            Dispose(true);
            #if RLE
            System.GC.SuppressFinalize(this);
            #endif
        }
        #endregion

    }

    public class XRender {
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderQueryExtension_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XRenderQueryExtension(IntPtr dpy, out int event_basep, out int error_basep);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderQueryVersion_TNK", CharSet = CharSet.Auto)]
            internal static extern int XRenderQueryVersion(IntPtr dpy, out int major_versionp, out int minor_versionp);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderFindVisualFormat_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XRenderFindVisualFormat([In]IntPtr dpy, [In] IntPtr visual);

            // XRenderPictFormat*: XRenderFindFormat Display*:dpy unsigned long:mask XRenderPictFormat*:templ int:count
            //[DllImport(ExtremeSports.Lib, EntryPoint = "XRenderFindFormat_TNK", CharSet = CharSet.Auto)]
            //internal static extern IntPtr XRenderFindFormat([In]IntPtr dpy, ulong mask, IntPtr templ, int count);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderFindStandardFormat_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XRenderFindStandardFormat([In]IntPtr dpy, PictStandard format);

            // Status: XRenderQueryFormats Display*:dpy
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderQueryFormats_TNK", CharSet = CharSet.Auto)]
            internal static extern int XRenderQueryFormats(IntPtr dpy);

            // int: XRenderQuerySubpixelOrder Display*:dpy int:screen
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderQuerySubpixelOrder_TNK", CharSet = CharSet.Auto)]
            internal static extern SubPixel XRenderQuerySubpixelOrder(IntPtr dpy, int screen);

            // Bool: XRenderSetSubpixelOrder Display*:dpy int:screen int:subpixel
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderSetSubpixelOrder_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XRenderSetSubpixelOrder(IntPtr dpy, int screen, SubPixel subpixel);


            // void: XRenderFreePicture Display*:dpy Picture:picture
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderFreePicture_TNK", CharSet = CharSet.Auto)]
            internal static extern void XRenderFreePicture([In]IntPtr dpy, int picture);

            // Picture: XRenderCreatePicture Display*:dpy Drawable:drawable XRenderPictFormat*:format unsigned long:valuemask XRenderPictureAttributes*:attributes
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderCreatePicture_TNK", CharSet = CharSet.Auto)]
            internal static extern int XRenderCreatePicture([In]IntPtr dpy, [In]IntPtr drawable, ref XRenderPictFormatRec format, CreatePictureMask valuemask, ref XRenderPictureAttributesRec attributes);

            // void: XRenderChangePicture Display*:dpy Picture:picture unsigned long:valuemask XRenderPictureAttributes*:attributes
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderChangePicture_TNK", CharSet = CharSet.Auto)]
            internal static extern void XRenderChangePicture(IntPtr dpy, int picture, CreatePictureMask valuemask, ref XRenderPictureAttributesRec attributes);

            // void: XRenderSetPictureFilter Display*:dpy Picture:picture char*:filter XFixed*:params int:nparams
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderSetPictureFilter_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern void XRenderSetPictureFilter(IntPtr dpy, int picture, [MarshalAs(UnmanagedType.LPStr)] string filter, int[] fk_params, int nparams);

            // void: XRenderSetPictureClipRectangles Display*:dpy Picture:picture int:xOrigin int:yOrigin XRectangle*:rects int:n
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderSetPictureClipRectangles_TNK", CharSet = CharSet.Auto)]
            internal static extern void XRenderSetPictureClipRectangles(IntPtr dpy, int picture, int xOrigin, int yOrigin, [In, MarshalAs(UnmanagedType.LPArray)]TonNurako.X11.XRectangle[] rects, int n);

            // void: XRenderSetPictureClipRegion Display*:dpy Picture:picture Region:r
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderSetPictureClipRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern void XRenderSetPictureClipRegion(IntPtr dpy, int picture, [In]IntPtr r);

            // void: XRenderSetPictureTransform Display*:dpy Picture:picture XTransform*:transform
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderSetPictureTransform_TNK", CharSet = CharSet.Auto)]
            internal static extern void XRenderSetPictureTransform(IntPtr dpy, int picture, ref XTransform transform);

            // void: XRenderFillRectangle Display*:dpy int:op Picture:dst XRenderColor*:color int:x int:y unsigned int:width unsigned int:height
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderFillRectangle_TNK", CharSet = CharSet.Auto)]
            internal static extern void XRenderFillRectangle(IntPtr dpy, PictOp op, int dst, ref XRenderColor color, int x, int y, uint width, uint height);


            // void: XRenderFillRectangles Display*:dpy int:op Picture:dst XRenderColor*:color XRectangle*:rectangles int:n_rects
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderFillRectangles_TNK", CharSet = CharSet.Auto)]
            internal static extern void XRenderFillRectangles(
                IntPtr dpy, PictOp op, int dst, ref XRenderColor color, [In, MarshalAs(UnmanagedType.LPArray)]TonNurako.X11.XRectangle[] rectangles, int n_rects);

            // void: XRenderCompositeTrapezoids Display*:dpy int:op Picture:src Picture:dst XRenderPictFormat*:maskFormat int:xSrc int:ySrc XTrapezoid*:traps int:ntrap
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderCompositeTrapezoids_TNK", CharSet = CharSet.Auto)]
            internal static extern void XRenderCompositeTrapezoid(
                IntPtr dpy, PictOp op, int src, int dst, ref XRenderPictFormatRec maskFormat, int xSrc, int ySrc, ref XTrapezoid traps, int ntrap);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderCompositeTrapezoids_TNK", CharSet = CharSet.Auto)]
            internal static extern void XRenderCompositeTrapezoids(
                 IntPtr dpy, PictOp op, int src, int dst, ref XRenderPictFormatRec maskFormat, int xSrc, int ySrc, [In, MarshalAs(UnmanagedType.LPArray)]XTrapezoid[] traps, int ntrap);

            // void: XRenderComposite Display*:dpy int:op Picture:src Picture:mask Picture:dst int:src_x int:src_y int:mask_x int:mask_y int:dst_x int:dst_y unsigned int:width unsigned int:height
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderComposite_TNK", CharSet = CharSet.Auto)]
            internal static extern void XRenderComposite(IntPtr dpy, PictOp op, int src, int mask, int dst, int src_x, int src_y, int mask_x, int mask_y, int dst_x, int dst_y, uint width, uint height);

            // Picture: XRenderCreateSolidFill Display*:dpy XRenderColor*:color
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderCreateSolidFill_TNK", CharSet = CharSet.Auto)]
            internal static extern int XRenderCreateSolidFill(IntPtr dpy, ref XRenderColor color);

            // Picture: XRenderCreateLinearGradient Display*:dpy XLinearGradient*:gradient XFixed*:stops XRenderColor*:colors int:nstops
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderCreateLinearGradient_TNK", CharSet = CharSet.Auto)]
            internal static extern int XRenderCreateLinearGradient(
                IntPtr dpy, ref XLinearGradient gradient, int[] stops, [In]XRenderColor[] colors, int nstops);

            // Picture: XRenderCreateRadialGradient Display*:dpy XRadialGradient*:gradient XFixed*:stops XRenderColor*:colors int:nstops
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderCreateRadialGradient_TNK", CharSet = CharSet.Auto)]
            internal static extern int XRenderCreateRadialGradient(
                IntPtr dpy, ref XRadialGradient gradient, int[] stops, [In]XRenderColor[] colors, int nstops);

            // Picture: XRenderCreateConicalGradient Display*:dpy XConicalGradient*:gradient XFixed*:stops XRenderColor*:colors int:nstops
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderCreateConicalGradient_TNK", CharSet = CharSet.Auto)]
            internal static extern int XRenderCreateConicalGradient(
                IntPtr dpy, ref XConicalGradient gradient, int[] stops, [In]XRenderColor[] colors, int nstops);

            // Status: XRenderParseColor Display*:dpy char*:spec XRenderColor*:def
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderParseColor_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern XStatus XRenderParseColor(IntPtr dpy, [MarshalAs(UnmanagedType.LPStr)] string spec, ref XRenderColor def);

            // XIndexValue*: XRenderQueryPictIndexValues Display*:dpy XRenderPictFormat*:format int*:num
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderQueryPictIndexValues_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XRenderQueryPictIndexValues(IntPtr dpy, ref XRenderPictFormatRec format, out int num);

            // XFilters*: XRenderQueryFilters Display*:dpy Drawable:drawable
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderQueryFilters_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XRenderQueryFilters(IntPtr dpy, IntPtr drawable);


            // void: XRenderCompositeTriangles Display*:dpy int:op Picture:src Picture:dst XRenderPictFormat*:maskFormat int:xSrc int:ySrc XTriangle*:triangles int:ntriangle
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderCompositeTriangles_TNK", CharSet = CharSet.Auto)]
            internal static extern void XRenderCompositeTriangles(
                IntPtr dpy, PictOp op, int src, int dst, ref XRenderPictFormatRec maskFormat, int xSrc, int ySrc, [In, MarshalAs(UnmanagedType.LPArray)]XTriangle[] triangles, int ntriangle);

            // void: XRenderCompositeTriStrip Display*:dpy int:op Picture:src Picture:dst XRenderPictFormat*:maskFormat int:xSrc int:ySrc XPointFixed*:points int:npoint
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderCompositeTriStrip_TNK", CharSet = CharSet.Auto)]
            internal static extern void XRenderCompositeTriStrip(
                IntPtr dpy, PictOp op, int src, int dst, ref XRenderPictFormatRec maskFormat, int xSrc, int ySrc, [In, MarshalAs(UnmanagedType.LPArray)]XPointFixed[] points, int npoint);

            // void: XRenderCompositeTriFan Display*:dpy int:op Picture:src Picture:dst XRenderPictFormat*:maskFormat int:xSrc int:ySrc XPointFixed*:points int:npoint
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderCompositeTriFan_TNK", CharSet = CharSet.Auto)]
            internal static extern void XRenderCompositeTriFan(
                IntPtr dpy, PictOp op, int src, int dst, ref XRenderPictFormatRec maskFormat, int xSrc, int ySrc, [In, MarshalAs(UnmanagedType.LPArray)]XPointFixed[] points, int npoint);

            // void: XRenderCompositeDoublePoly Display*:dpy int:op Picture:src Picture:dst XRenderPictFormat*:maskFormat int:xSrc int:ySrc int:xDst int:yDst XPointDouble*:fpoints int:npoints int:winding
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRenderCompositeDoublePoly_TNK", CharSet = CharSet.Auto)]
            internal static extern void XRenderCompositeDoublePoly(
                IntPtr dpy, PictOp op, int src, int dst, ref XRenderPictFormatRec maskFormat, int xSrc, int ySrc, int xDst, int yDst, [In, MarshalAs(UnmanagedType.LPArray)]XPointDouble [] fpoints, int npoints, int winding);
        }

        public static bool QueryExtension(Display display) {
            int ev, er;
            return NativeMethods.XRenderQueryExtension(display.Handle, out ev, out er);
        }

        public static ExtensionVersion QueryVersion(Display display) {
            var n = new ExtensionVersion();
            if (!NativeMethods.XRenderQueryExtension(display.Handle, out n.Major, out n.Minor)) {
                return null;
            }
            return n;
        }

        public static int QueryFormats(Display dpy) =>
                    NativeMethods.XRenderQueryFormats(dpy.Handle);

        public static SubPixel QuerySubpixelOrder(Display dpy, int screen) =>
            NativeMethods.XRenderQuerySubpixelOrder(dpy.Handle, screen);


        public static bool SetSubpixelOrder(Display dpy, int screen, SubPixel subpixel) =>
            NativeMethods.XRenderSetSubpixelOrder(dpy.Handle, screen, subpixel);


        public static XRenderPictFormat FindVisualFormat(Display display, Visual visual) {
            var p = NativeMethods.XRenderFindVisualFormat(display.Handle, visual.Handle);
            if (IntPtr.Zero == p) {
                return null;
            }
            return (new XRenderPictFormat(display, p));
        }

        public static XRenderPictFormat FindStandardFormat(Display display, PictStandard format) {
            var p = NativeMethods.XRenderFindStandardFormat(display.Handle, format);
            if (IntPtr.Zero == p) {
                return null;
            }
            return (new XRenderPictFormat(display, p));
        }

        public static XIndexValue [] QueryPictIndexValues(Display display, XRenderPictFormat format) {
            var f = format.Assemble();
            var k = NativeMethods.XRenderQueryPictIndexValues(display.Handle, ref f, out int num);
            if (0 == num) {
                return (new XIndexValue[0]);
            }
            return MarshalHelper.ToStructArray<XIndexValue>(k, num);
        }

        public static XFilters QueryFilters(Display display, IDrawable drawable) {
            var r = NativeMethods.XRenderQueryFilters(display.Handle, drawable.Drawable);
            if (IntPtr.Zero == r) {
                return null;
            }
            return (new XFilters(Marshal.PtrToStructure<XFiltersRec>(r)));
        }

        public static Picture CreatePicture(Display dpy, IDrawable drawable, XRenderPictFormat format, CreatePictureMask valuemask, XRenderPictureAttributes attributes) {
            var p = NativeMethods.XRenderCreatePicture(dpy.Handle, drawable.Drawable, ref format.Record, valuemask, ref attributes.Record);
            if (p == 0) {
                return null;
            }
            return new Picture(dpy, p);
        }

        public static void ChangePicture(Display dpy, Picture picture, CreatePictureMask valuemask, XRenderPictureAttributes attributes) {
            NativeMethods.XRenderChangePicture(dpy.Handle, picture.Handle, valuemask, ref attributes.Record);
        }


        public static void FreePicture(Picture picture) {
            NativeMethods.XRenderFreePicture(picture.Display.Handle, picture.Handle);
        }

        public static void SetPictureFilter(Display display, Picture picture, Filter filter, int[] fk_params) {
            NativeMethods.XRenderSetPictureFilter(display.Handle, picture.Handle, filter.AsString(), fk_params, fk_params.Length);
        }

        public static void SetPictureClipRectangles(Display display, Picture picture, int xOrigin, int yOrigin, XRectangle[] rects) {
            NativeMethods.XRenderSetPictureClipRectangles(display.Handle, picture.Handle, xOrigin, yOrigin, rects, rects.Length);
        }

        public static void SetPictureClipRegion(Display display, Picture picture, Region region) {
            NativeMethods.XRenderSetPictureClipRegion(display.Handle, picture.Handle, region.Handle);
        }

        public static void SetPictureTransform(Display display, Picture picture, XTransform transform) {
            NativeMethods.XRenderSetPictureTransform(display.Handle, picture.Handle, ref transform);
        }


        public static void FillRectangle(Display display, PictOp op, Picture dst, XRenderColor color, int x, int y, int width, int height) {
            NativeMethods.XRenderFillRectangle(display.Handle, op, dst.Handle, ref color, x, y, (uint)width, (uint)height);
        }

        public static void FillRectangles(Display display, PictOp op, Picture dst, XRenderColor color, TonNurako.X11.XRectangle[] rectangles) {
            NativeMethods.XRenderFillRectangles(display.Handle, op, dst.Handle, ref color, rectangles, rectangles.Length);
        }

        public static XRenderColor ParseColor(Display display, string spec) {
            var def = new XRenderColor();
            if(XStatus.False == NativeMethods.XRenderParseColor(display.Handle, spec, ref def)) {
                throw new Exception("XRenderParseColor == False");
            }
            return def;
        }


        public static void CompositeTrapezoid(Display display, PictOp op, Picture src, Picture dst, XRenderPictFormat maskFormat, int xSrc, int ySrc, XTrapezoid trap) {
            NativeMethods.XRenderCompositeTrapezoid(
                display.Handle, op, src.Handle, dst.Handle, ref maskFormat.Record, xSrc, ySrc, ref trap, 1);
        }

        public static void CompositeTrapezoids(Display display, PictOp op, Picture src, Picture dst, XRenderPictFormat maskFormat, int xSrc, int ySrc, XTrapezoid [] trap) {
            NativeMethods.XRenderCompositeTrapezoids(
                display.Handle, op, src.Handle, dst.Handle, ref maskFormat.Record, xSrc, ySrc, trap, trap.Length);
        }

        public static void CompositeTriangles(Display display, PictOp op, Picture src, Picture dst, XRenderPictFormat maskFormat, int xSrc, int ySrc, XTriangle[] triangles) {
            NativeMethods.XRenderCompositeTriangles(
                display.Handle, op, src.Handle, dst.Handle, ref maskFormat.Record, xSrc, ySrc, triangles, triangles.Length);
        }

        public static void CompositeTriStrip(Display display, PictOp op, Picture src, Picture dst, XRenderPictFormat maskFormat, int xSrc, int ySrc, XPointFixed[] points) {
            NativeMethods.XRenderCompositeTriStrip(
                display.Handle, op, src.Handle, dst.Handle, ref maskFormat.Record, xSrc, ySrc,  points, points.Length);
        }

        public static void CompositeTriFan(Display display, PictOp op, Picture src, Picture dst, XRenderPictFormat maskFormat, int xSrc, int ySrc, XPointFixed[] points) {
            NativeMethods.XRenderCompositeTriFan(
                display.Handle, op, src.Handle, dst.Handle, ref maskFormat.Record, xSrc, ySrc, points, points.Length);
        }

        public static void CompositeDoublePoly(
            Display display, PictOp op, Picture src, Picture dst, XRenderPictFormat maskFormat, int xSrc, int ySrc, int xDst, int yDst, XPointDouble[] points, int winding) {
            NativeMethods.XRenderCompositeDoublePoly(
                display.Handle, op, src.Handle, dst.Handle, ref maskFormat.Record, xSrc, ySrc, xDst, yDst, points, points.Length, winding);
        }

        public static void Composite(
            Display display, PictOp op, Picture src, Picture mask, Picture dst, int src_x, int src_y, int mask_x, int mask_y, int dst_x, int dst_y, int width, int height) {
            NativeMethods.XRenderComposite(display.Handle, op, src.Handle, mask.Handle, dst.Handle, src_x, src_y, mask_x, mask_y, dst_x, dst_y, (uint)width, (uint)height);
        }

        private static Picture BindReturn(Display d, int p) => (new Picture(d, p));


        public static Picture CreateSolidFill(Display dpy, XRenderColor color) =>
            BindReturn(dpy, NativeMethods.XRenderCreateSolidFill(dpy.Handle, ref color));

        public static Picture CreateLinearGradient(Display dpy, XLinearGradient gradient, int[] stops, XRenderColor[] colors) =>
            BindReturn(dpy, NativeMethods.XRenderCreateLinearGradient(dpy.Handle, ref gradient, stops, colors, stops.Length));

        public static Picture CreateRadialGradient(Display dpy, XRadialGradient gradient, int[] stops, XRenderColor[] colors) =>
            BindReturn(dpy, NativeMethods.XRenderCreateRadialGradient(dpy.Handle, ref gradient, stops, colors, stops.Length));

        public static Picture CreateConicalGradient(Display dpy, XConicalGradient gradient, int[] stops, XRenderColor[] colors) =>
            BindReturn(dpy, NativeMethods.XRenderCreateConicalGradient(dpy.Handle, ref gradient, stops, colors, stops.Length));


    }
}
