using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Inutility;

namespace TonNurako.X11.Extension {
    [StructLayout(LayoutKind.Sequential)]
    internal struct XRenderDirectFormatRec {
        public short Red;
        public short RedMask;
        public short Green;
        public short GreenMask;
        public short Blue;
        public short BlueMask;
        public short Alpha;
        public short AlphaMask;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class XRenderDirectFormat {
        internal XRenderDirectFormatRec Record;

        public XRenderDirectFormat() {
            Record = new XRenderDirectFormatRec();
        }

        internal XRenderDirectFormat(XRenderDirectFormatRec rec) {
            Record = rec;
        }

        public short Red {
            get => Record.Red;
            set => Record.Red = value;
        }
        public short RedMask {
            get => Record.RedMask;
            set => Record.RedMask = value;
        }
        public short Green {
            get => Record.Green;
            set => Record.Green = value;
        }
        public short GreenMask {
            get => Record.GreenMask;
            set => Record.GreenMask = value;
        }
        public short Blue {
            get => Record.Blue;
            set => Record.Blue = value;
        }
        public short BlueMask {
            get => Record.BlueMask;
            set => Record.BlueMask = value;
        }
        public short Alpha {
            get => Record.Alpha;
            set => Record.Alpha = value;
        }
        public short AlphaMask {
            get => Record.AlphaMask;
            set => Record.AlphaMask = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XRenderPictFormatRec {
        public PictFormat id;
        public int type;
        public int depth;
        public XRenderDirectFormatRec direct;
        public int colormap; //Colormap
    }

    public class XRenderPictFormat {
        internal XRenderPictFormatRec Record;
        internal XRenderDirectFormat direct;
        IntPtr ptr;

        Display display;
        internal Display Display => display;
        Colormap colormap;

        public XRenderPictFormat(Display dpy, IntPtr p) {
            ptr = p;
            display = dpy;
            Record = Marshal.PtrToStructure<XRenderPictFormatRec>(ptr);
            colormap = new Colormap(Record.colormap, dpy);
            direct = new XRenderDirectFormat(Record.direct);
        }

        internal XRenderPictFormatRec Assemble() {
            var r = new XRenderPictFormatRec();
            r.colormap = (null != colormap) ? colormap.Handle : 0;
            r.direct = direct.Record;
            return r;
        }

        public XRenderPictFormat() {
            Record = new XRenderPictFormatRec();
            direct = new XRenderDirectFormat();
        }

        public PictFormat Id {
            get => Record.id;
            set => Record.id = value;
        }
        public int Type {
            get => Record.type;
            set => Record.type = value;
        }
        public int Depth {
            get => Record.depth;
            set => Record.depth = value;
        }
        public XRenderDirectFormat Direct {
            get => direct;
            set {
                direct = value;
                Record.direct = value.Record;
            }
        }
        public Colormap Colormap {
            get => colormap;
            set {
                colormap = value;
                Record.colormap = value.Handle;
            }
        }

    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XRenderPictureAttributesRec {
        public bool repeat;
        public int alpha_map; // Picture = XID
        public int alpha_x_origin;
        public int alpha_y_origin;
        public int clip_x_origin;
        public int clip_y_origin;
        public IntPtr clip_mask; //Pixmap
        public bool graphics_exposures;
        public int subwindow_mode;
        public int poly_edge;
        public int poly_mode;
        public IntPtr dither; //Atom
        public bool component_alpha;
    }
    public class XRenderPictureAttributes {
        internal XRenderPictureAttributesRec Record;
        Pixmap clip_mask;
        Atom dither;

        public XRenderPictureAttributes() {
            Record = new XRenderPictureAttributesRec();
        }

        internal void Assign() {
            clip_mask = new Pixmap(Record.clip_mask, null);
            dither = new Atom(Record.dither);
        }

        public bool Repeat {
            get => Record.repeat;
            set => Record.repeat = value;
        }
        public int AlphaMap {
            get => Record.alpha_map; // Picture
            set => Record.alpha_map = value;
        }

        public int AlphaXOrigin {
            get => Record.alpha_x_origin;
            set => Record.alpha_x_origin = value;
        }

        public int AlphaYOrigin {
            get => Record.alpha_y_origin;
            set => Record.alpha_y_origin = value;
        }

        public int ClipXOrigin {
            get => Record.clip_x_origin;
            set => Record.clip_x_origin = value;
        }

        public int ClipYOrigin {
            get => Record.clip_y_origin;
            set => Record.clip_y_origin = value;
        }

        public Pixmap ClipMask {
            get => clip_mask;
            set {
                clip_mask = value;
                Record.clip_mask = value.Handle;
            }
        }

        public bool GraphicsExposures {
            get => Record.graphics_exposures;
            set => Record.graphics_exposures = value;
        }

        public int SubwindowMode {
            get => Record.subwindow_mode;
            set => Record.subwindow_mode = value;
        }

        public int PolyEdge {
            get => Record.poly_edge;
            set => Record.poly_edge = value;
        }

        public int PolyMode {
            get => Record.poly_mode;
            set => Record.poly_mode = value;
        }


        public Atom Dither {
            get => dither;
            set {
                dither = value;
                Record.dither = value.Handle;
            }
        }
        public bool ComponentAlpha {
            get => Record.component_alpha;
            set => Record.component_alpha = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XRenderColor {
        public ushort Red;
        public ushort Green;
        public ushort Blue;
        public ushort Alpha;

        public XRenderColor(ushort r, ushort g, ushort b, ushort a) {
            Red     = r;
            Green   = g;
            Blue    = b;
            Alpha   = a;
        }
        public XRenderColor(Color color, ushort alpha) {
            Red = color.Red;
            Green = color.Green;
            Blue = color.Blue;
            Alpha = alpha;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XGlyphInfo {
        public ushort width;
        public ushort height;
        public short x;
        public short y;
        public short xOff;
        public short yOff;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XGlyphElt8 {
        public int glyphset; //GlyphSet=XID
        internal IntPtr chars; // _Xconst char*
        public int nchars;
        public int xOff;
        public int yOff;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XGlyphElt16 {
        public int glyphset; //GlyphSet=XID
        public IntPtr chars; //unsigned short*
        public int nchars;
        public int xOff;
        public int yOff;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XGlyphElt32 {
        public int glyphset; //GlyphSet=XID
        public IntPtr chars; //int*
        public int nchars;
        public int xOff;
        public int yOff;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XPointDouble {
        public double X, Y;
        public XPointDouble(double x, double y) {
            X = x;
            Y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XPointFixed {
        public int X;
        public int Y;
        public XPointFixed(int x, int y) {
            X = x;
            Y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XLineFixed {
        public XPointFixed P1;
        public XPointFixed P2;

        public XLineFixed(XPointFixed p1, XPointFixed p2) {
            P1 = p1;
            P2 = p2;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XTriangle {
        public XPointFixed P1, P2, P3;
        public XTriangle(XPointFixed p1,XPointFixed p2,XPointFixed p3) {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XCircle {
        public int X;
        public int Y;
        public int Radius;
        public XCircle(int x, int y, int radius) {
            X = x;
            Y = y;
            Radius = radius;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XTrapezoid {
        public int Top;
        public int Bottom;
        public XLineFixed Left;
        public XLineFixed Right;

        public XTrapezoid(int top, int bottom, XLineFixed left, XLineFixed right) {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XTransform {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public int[] Matrix; //matrix[3][3]
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct XFiltersRec {
        public int nfilter;
        internal IntPtr filter; //char**
        public int nalias;
        internal IntPtr alias; //short*
    }

    public class XFilters {

        internal XFiltersRec Record;
        string[] filters = null;
        short[] aliases = null;

        internal XFilters(XFiltersRec rec) {
            if (0 != rec.nfilter) {
                filters = MarshalHelper.ToStringArray(rec.filter, rec.nfilter);
            }
            if (0 != rec.nalias) {
                aliases = new short[rec.nalias];
                Marshal.Copy(rec.alias, aliases, 0, rec.nalias);
            }
        }

        public int FilterCount {
            get => Record.nfilter;
            set => Record.nfilter = value;
        }
        public string[] Filter {
            get => filters;
            //set => Record.filter = value;
        }
        public int AliasCount {
            get => Record.nalias;
            set => Record.nalias = value;
        }
        public short [] Alias {
            get => aliases;
            //set => Record.alias = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XIndexValue {
        public ulong Pixel;
        public ushort Red;
        public ushort Green;
        public ushort Blue;
        public ushort Alpha;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XAnimCursor {
        public int cursor; //Cursor
        public long delay;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XSpanFix {
        public int left, right, y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XTrap {
        public XSpanFix top, bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XLinearGradient {
        public XPointFixed P1;
        public XPointFixed P2;

        public XLinearGradient(XPointFixed x1, XPointFixed x2) {
            P1 = x1;
            P2 = x2;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XRadialGradient {
        public XCircle Inner;
        public XCircle Outer;

        public XRadialGradient(XCircle inner, XCircle outer) {
            Inner = inner;
            Outer = outer;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XConicalGradient {
        public XPointFixed Center;
        public int Angle; /* in degrees */

        public XConicalGradient(XPointFixed center, int angle) {
            Center = center;
            Angle = angle;
        }
    }
}
