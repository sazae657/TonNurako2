using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Extension {
    public enum ShapeKind : int {
        ShapeBounding = TonNurako.X11.Constant.ShapeBounding,
        ShapeClip = TonNurako.X11.Constant.ShapeClip,
        ShapeInput = TonNurako.X11.Constant.ShapeInput,
    }

    public enum ShapeOp : int {
        ShapeSet = TonNurako.X11.Constant.ShapeSet,
        ShapeUnion = TonNurako.X11.Constant.ShapeUnion,
        ShapeIntersect = TonNurako.X11.Constant.ShapeIntersect,
        ShapeSubtract = TonNurako.X11.Constant.ShapeSubtract,
        ShapeInvert = TonNurako.X11.Constant.ShapeInvert,
    }

    [Flags]
    public enum ShapeEventMask : ulong {
        None = 0,
        ShapeNotifyMask = TonNurako.X11.Constant.ShapeNotifyMask
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XShapeEvent {
        public int type; // int
        public ulong serial; // unsigned long
        [MarshalAs(UnmanagedType.U1)]  public  bool send_event; // Bool
        internal IntPtr display; // Display*
        internal IntPtr window; // Window
        public int kind; // int
        public int x; // int
        public int y; // int
        public uint width; // unsigned int
        public uint height; // unsigned int
        public uint time; // Time
        [MarshalAs(UnmanagedType.U1)] public  bool shaped; // Bool
    }


    public class XShape {
        internal static class NativeMethods {

            [DllImport(ExtremeSports.Lib, EntryPoint = "XShapeQueryExtension_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XShapeQueryExtension(IntPtr dpy, out int event_basep, out int error_basep);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XShapeQueryVersion_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XShapeQueryVersion(IntPtr dpy, out int major_versionp, out int minor_versionp);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XShapeCombineRegion_TNK", CharSet = CharSet.Auto)]
            internal static extern void XShapeCombineRegion(IntPtr dpy, IntPtr dest, ShapeKind destKind, int xOff, int yOff, IntPtr r, ShapeOp op);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XShapeCombineRectangles_TNK", CharSet = CharSet.Auto)]
            internal static extern void XShapeCombineRectangles(IntPtr dpy, IntPtr dest, ShapeKind destKind, int xOff, int yOff, XRectangle[] rects, int n_rects, ShapeOp op, Ordering ordering);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XShapeCombineMask_TNK", CharSet = CharSet.Auto)]
            internal static extern void XShapeCombineMask(IntPtr dpy, IntPtr dest, ShapeKind destKind, int xOff, int yOff, IntPtr src, ShapeOp op);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XShapeCombineShape_TNK", CharSet = CharSet.Auto)]
            internal static extern void XShapeCombineShape(IntPtr dpy, IntPtr dest, ShapeKind destKind, int xOff, int yOff, IntPtr src, ShapeKind srcKind, ShapeOp op);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XShapeOffsetShape_TNK", CharSet = CharSet.Auto)]
            internal static extern void XShapeOffsetShape(IntPtr dpy, IntPtr dest, ShapeKind destKind, int xOff, int yOff);

            // Status: XShapeQueryExtents [{'type': 'Display*', 'name': 'dpy'}, {'type': 'Window', 'name': 'window'}, {'type': 'int*', 'name': 'bShaped'}, {'type': 'int*', 'name': 'xbs'}, {'type': 'int*', 'name': 'ybs'}, {'type': 'unsigned int*', 'name': 'wbs'}, {'type': 'unsigned int*', 'name': 'hbs'}, {'type': 'int*', 'name': 'cShaped'}, {'type': 'int*', 'name': 'xcs'}, {'type': 'int*', 'name': 'ycs'}, {'type': 'unsigned int*', 'name': 'wcs'}, {'type': 'unsigned int*', 'name': 'hcs'}]
            //[DllImport(ExtremeSports.Lib, EntryPoint = "XShapeQueryExtents_TNK", CharSet = CharSet.Auto)]
            //internal static extern int XShapeQueryExtents(IntPtr dpy, IntPtr window, out IntPtr bShaped, out IntPtr xbs, out IntPtr ybs, out IntPtr wbs, out IntPtr hbs, out IntPtr cShaped, out IntPtr xcs, out IntPtr ycs, out IntPtr wcs, out IntPtr hcs);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XShapeSelectInput_TNK", CharSet = CharSet.Auto)]
            internal static extern void XShapeSelectInput(IntPtr dpy, IntPtr window, ShapeEventMask mask);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XShapeInputSelected_TNK", CharSet = CharSet.Auto)]
            internal static extern ShapeEventMask XShapeInputSelected(IntPtr dpy, IntPtr window);

            // XRectangle*
            //[DllImport(ExtremeSports.Lib, EntryPoint = "XShapeGetRectangles_TNK", CharSet = CharSet.Auto)]
            //internal static extern IntPtr XShapeGetRectangles(IntPtr dpy, IntPtr window, ShapeKind kind, out int count, out Ordering ordering);
        }

        public static bool QueryExtension(Display display) {
            int ev, er;
            return NativeMethods.XShapeQueryExtension(display.Handle, out ev, out er);
        }

        public static ExtensionVersion QueryVersion(Display display) {
            var n = new ExtensionVersion();
            if (XStatus.True != NativeMethods.XShapeQueryVersion(display.Handle, out n.Major, out n.Minor)) {
                return null;
            }
            return n;
        }

        public static void CombineMask(Display display, Window window, ShapeKind destKind, int xOff, int yOff, TonNurako.X11.Pixmap pixmap, ShapeOp op) {
            NativeMethods.XShapeCombineMask(display.Handle, window.Handle, destKind, xOff, yOff, pixmap.Drawable, op);
        }
        public static void CombineShape(Display display, Window window, ShapeKind destKind, int xOff, int yOff, Window src, ShapeKind srcKind, ShapeOp op) {
            NativeMethods.XShapeCombineShape(display.Handle, window.Handle, destKind, xOff, yOff, src.Handle, srcKind, op);
        }

        public static void CombineRegion(Display display, Window window, ShapeKind destKind, int xOff, int yOff, Region r, ShapeOp op) {
            NativeMethods.XShapeCombineRegion(display.Handle, window.Handle, destKind, xOff, yOff, r.Handle, op);
        }

        public static void CombineRectangles(Display display, Window window, ShapeKind destKind, int xOff, int yOff, XRectangle[] rects, ShapeOp op, Ordering ordering) {
            NativeMethods.XShapeCombineRectangles(display.Handle, window.Handle, destKind, xOff, yOff, rects, rects.Length, op, ordering);
        }

        public static void OffsetShape(Display display, Window window, ShapeKind destKind, int xOff, int yOff) {
            NativeMethods.XShapeOffsetShape(display.Handle, window.Handle, destKind, xOff, yOff);
        }

        public static void SelectInput(Display display, Window window, ShapeEventMask mask) {
            NativeMethods.XShapeSelectInput(display.Handle, window.Handle, mask);
        }

        public static ShapeEventMask InputSelected(Display display, Window window) {
            return NativeMethods.XShapeInputSelected(display.Handle, window.Handle);
        }
    }
}
