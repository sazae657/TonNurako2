using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11 {

    /*[StructLayout(LayoutKind.Sequential)]
    public struct BOX {
        public short x1, x2, y1, y2;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct RECTANGLE {
        public short x, y, width, height;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XRegionRec {
        public long size;
        public long numRects;
        public IntPtr rects; //BOX*
        public BOX extents;
    }*/

    public enum RectInRegion : int {
        RectangleOut = TonNurako.X11.Constant.RectangleOut,
        RectangleIn = TonNurako.X11.Constant.RectangleIn,
        RectanglePart = TonNurako.X11.Constant.RectanglePart,
    }

    public class Region : IX11Interop, IEquatable<Region>, IDisposable {
        internal static class NativeMethods {
            // Region: XCreateRegion []
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCreateRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XCreateRegion();

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSetRegion(IntPtr display, IntPtr gc, IntPtr r);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDestroyRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern int XDestroyRegion(IntPtr r);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XEmptyRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XEmptyRegion(IntPtr r);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XEqualRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XEqualRegion(IntPtr r1, IntPtr r2);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XPointInRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XPointInRegion(IntPtr r, int x, int y);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XRectInRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern RectInRegion XRectInRegion(IntPtr r, int x, int y, uint width, uint height);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XIntersectRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern int XIntersectRegion(IntPtr sra, IntPtr srb, out IntPtr dr_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XUnionRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern int XUnionRegion(IntPtr sra, IntPtr srb, IntPtr dr_return);

            // int: XUnionRectWithRegion XRectangle*:rectangle Region:src_region Region:dest_region_return
            [DllImport(ExtremeSports.Lib, EntryPoint = "XUnionRectWithRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern int XUnionRectWithRegion(TonNurako.X11.XRectangle[] rectangle, IntPtr src_region, out IntPtr dest_region_return);

            // int: XSubtractRegion Region:sra Region:srb Region:dr_return
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSubtractRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSubtractRegion(IntPtr sra, IntPtr srb, out IntPtr dr_return);

            // int: XXorRegion Region:sra Region:srb Region:dr_return
            [DllImport(ExtremeSports.Lib, EntryPoint = "XXorRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern int XXorRegion(IntPtr sra, IntPtr srb, out IntPtr dr_return);

            // int: XOffsetRegion Region:r int:dx int:dy
            [DllImport(ExtremeSports.Lib, EntryPoint = "XOffsetRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern int XOffsetRegion(IntPtr r, int dx, int dy);

            // int: XShrinkRegion Region:r int:dx int:dy
            [DllImport(ExtremeSports.Lib, EntryPoint = "XShrinkRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern int XShrinkRegion(IntPtr r, int dx, int dy);

            // Region: XPolygonRegion XPoint:points[] int:n int:fill_rule
            [DllImport(ExtremeSports.Lib, EntryPoint = "XPolygonRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XPolygonRegion(XPoint[] points, int n, FillRule fill_rule);

            // int: XClipBox Region:r XRectangle*:rect_return
            [DllImport(ExtremeSports.Lib, EntryPoint = "XClipBox_TNK", CharSet = CharSet.Auto)]
            internal static extern int XClipBox(IntPtr r, out XRectangle rect_return);
        }

        object obzekt = new object();

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        bool isReference = false;

        public Region() {
        }

        public Region(IntPtr r) {
            isReference = true;
            handle = r;
        }

        public Region(IntPtr r, bool isa) {
            isReference = isa;
            handle = r;
        }

        public static Region Create() {
            var r = new Region();
            r.handle = NativeMethods.XCreateRegion();
            return r;
        }

        public bool EmptyRegion() =>
            NativeMethods.XEmptyRegion(Handle);


        public bool EqualRegion(Region r) =>
            NativeMethods.XEqualRegion(Handle, r.Handle);


        public bool PointInRegion(int x, int y) =>
            NativeMethods.XPointInRegion(Handle, x, y);


        public RectInRegion RectInRegion(int x, int y, int w, int h) =>
            NativeMethods.XRectInRegion(Handle, x, y, (uint)w, (uint)h);

        public int OffsetRegion(int x, int y) =>
            NativeMethods.XOffsetRegion(Handle, x, y);

        public int ShrinkRegion(int x, int y) =>
            NativeMethods.XShrinkRegion(Handle, x, y);

        public XRectangle ClipBox() {
            var r = new XRectangle();
            NativeMethods.XClipBox(Handle, out r);
            return r;
        }


        public static Region PolygonRegion(XPoint[] points, FillRule fill_rule) {
            var r = NativeMethods.XPolygonRegion(points, points.Length, fill_rule);
            return WrapReturn(r);
        }


        static Region WrapReturn(IntPtr r) => new Region(r, false);

        public static Region IntersectRegion(Region sra, Region srb) {
            IntPtr dr;
            NativeMethods.XIntersectRegion(sra.handle, srb.Handle, out dr);
            return WrapReturn(dr);
        }

        public static Region UnionRegion(Region sra, Region srb) {
            IntPtr dr;
            NativeMethods.XIntersectRegion(sra.Handle, srb.Handle, out dr);
            return WrapReturn(dr);
        }

        public static Region UnionRegion(TonNurako.X11.XRectangle[] rectangle, Region src) {
            IntPtr dr;
            NativeMethods.XUnionRectWithRegion(rectangle, src.Handle, out dr);
            return WrapReturn(dr);
        }

        public static Region SubtractRegion(Region sra, Region srb) {
            IntPtr dr;
            NativeMethods.XSubtractRegion(sra.Handle, srb.Handle, out dr);
            return WrapReturn(dr);
        }

        public static Region XorRegion(Region sra, Region srb) {
            IntPtr dr;
            NativeMethods.XXorRegion(sra.Handle, srb.Handle, out dr);
            return WrapReturn(dr);
        }

        // TODO: DisplayかGCに移動
        public int SetRegion(Display dpy, GC gc) {
            return NativeMethods.XSetRegion(dpy.Handle, gc.Handle, handle);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                if (!isReference && IntPtr.Zero != handle) {
                    NativeMethods.XDestroyRegion(handle);
                    handle = IntPtr.Zero;
                }
            }
        }

        #if RLE
        ~Region() {
            if (!isReference && IntPtr.Zero != handle) {
                throw new ResourceLeakException(this);
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

        #region IEqualityComparer

        public override int GetHashCode() {
            return obzekt.GetHashCode();
        }

        bool IEquatable<Region>.Equals(Region other) {
            return this.EqualRegion(other);
        }
        #endregion
    }

}
