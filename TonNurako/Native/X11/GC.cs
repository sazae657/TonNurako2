//
// ﾄﾝﾇﾗｺ
//
// Xlibﾗｯﾊﾟー
//

using System;
using System.Runtime.InteropServices;
using System.Text;
using TonNurako.Native;

namespace TonNurako.X11
{
	/// <summary>
	/// GCのﾏｽｸ
	/// </summary>
    [System.Flags]
    public enum GCMask : ulong {
        GCNone          = 0,
        GCFunction      = TonNurako.X11.Constant.GCFunction,
        GCPlaneMask     = TonNurako.X11.Constant.GCPlaneMask,
        GCForeground    = TonNurako.X11.Constant.GCForeground,
        GCBackground    = TonNurako.X11.Constant.GCBackground,
        GCLineWidth     = TonNurako.X11.Constant.GCLineWidth,
        GCLineStyle     = TonNurako.X11.Constant.GCLineStyle,
        GCCapStyle      = TonNurako.X11.Constant.GCCapStyle,
        GCJoinStyle     = TonNurako.X11.Constant.GCJoinStyle,
        GCFillStyle     = TonNurako.X11.Constant.GCFillStyle,
        GCFillRule      = TonNurako.X11.Constant.GCFillRule,
        GCTile          = TonNurako.X11.Constant.GCTile,
        GCStipple       = TonNurako.X11.Constant.GCStipple,
        GCTileStipXOrigin = TonNurako.X11.Constant.GCTileStipXOrigin,
        GCTileStipYOrigin = TonNurako.X11.Constant.GCTileStipYOrigin,
        GCFont          = TonNurako.X11.Constant.GCFont,
        GCSubwindowMode = TonNurako.X11.Constant.GCSubwindowMode,
        GCGraphicsExposures = TonNurako.X11.Constant.GCGraphicsExposures,
        GCClipXOrigin   = TonNurako.X11.Constant.GCClipXOrigin,
        GCClipYOrigin   = TonNurako.X11.Constant.GCClipYOrigin,
        GCClipMask      = TonNurako.X11.Constant.GCClipMask,
        GCDashOffset    = TonNurako.X11.Constant.GCDashOffset,
        GCDashList      = TonNurako.X11.Constant.GCDashList,
        GCArcMode       = TonNurako.X11.Constant.GCArcMode,
        GCLastBit       = TonNurako.X11.Constant.GCLastBit
    }

    /// <summary>
    /// ﾊﾞｲﾄｵーﾀﾞー
    /// </summary>
    public enum ByteOrder : int {
        LSBFirst = TonNurako.X11.Constant.LSBFirst,
        MSBFirst = TonNurako.X11.Constant.MSBFirst,
    }

	/// <summary>
	/// 点の定義(XPointに対応)
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct XPoint
	{
		/// <summary>
		/// X座標
		/// </summary>
        public short x;
		/// <summary>
		/// Y座標
		/// </summary>
		public short y;
        public XPoint(short X, short Y) {
            x = X;
            y = Y;
        }
	}

    [StructLayout(LayoutKind.Sequential)]
    public struct XSegment {
        int noop;
    }

	/// <summary>
	/// 矩形の定義(XRectangleに対応)
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct XRectangle
	{
		/// <summary>
		/// 左上角のX座標
		/// </summary>
		public short X;
		/// <summary>
		/// 左上角のY座標
		/// </summary>
		public short Y;
		/// <summary>
		/// 幅
		/// </summary>
		public ushort W;
		/// <summary>
		/// 高さ
		/// </summary>
		public ushort H;

        public XRectangle(short x, short y, ushort w, ushort h) {
            this.X = x;
            this.Y = y;
            this.W = w;
            this.H = h;
        }
    }

	/// <summary>
	/// 円弧の定義(XArcに対応)
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct XArc
	{
		/// <summary>
		/// 左上角のX座標
		/// </summary>
		public short X;
		/// <summary>
		/// 左上角のX座標
		/// </summary>
		public short Y;
		/// <summary>
		/// 幅
		/// </summary>
		public short W;
		/// <summary>
		/// 高さ
		/// </summary>
		public short H;
		/// <summary>
		/// 開始角
		/// </summary>
		public short  StartAngle;
		/// <summary>
		/// 終了角
		/// </summary>
		public short  SweepAngle;

        public XArc(short x, short y, short w, short h, short startAngle, short sweepAngle) {
            this.X = x;
            this.Y = y;
            this.W = w;
            this.H = h;
            this.StartAngle = startAngle;
            this.SweepAngle = sweepAngle;
        }
    }


	/// <summary>
	/// 折れ線の座標定義方法
	/// </summary>
	public enum CoordMode
	{
		/// <summary>
		/// 絶対座標
		/// </summary>
		Origin = TonNurako.X11.Constant.CoordModeOrigin,
		/// <summary>
		/// 相対座標
		/// </summary>
		Previous = TonNurako.X11.Constant.CoordModePrevious,
	}

	/// <summary>
	/// 線の終端形状
	/// </summary>
	public enum CapStyle
	{
		/// <summary>
		/// 何もしない
		/// </summary>
		NotLast = TonNurako.X11.Constant.CapNotLast,
        /// <summary>
        /// 始点と終端で切り落とす
        /// </summary>
        Butt = TonNurako.X11.Constant.CapButt,
		/// <summary>
		/// 始点と終端を半円で閉じる
		/// </summary>
		Round = TonNurako.X11.Constant.CapRound,
		/// <summary>
		/// 始点と終端に線幅の半分だけ突き出す
		/// </summary>
		Projecting = TonNurako.X11.Constant.CapProjecting,
	}

	/// <summary>
	/// 折れ曲がりの形状
	/// </summary>
	public enum JoinStyle
	{
		/// <summary>
		/// 線分の外縁を延長して公差させる
		/// </summary>
		Miter = TonNurako.X11.Constant.JoinMiter,
		/// <summary>
		/// 角の外側を丸める
		/// </summary>
		Round = TonNurako.X11.Constant.JoinRound,
        /// <summary>
        /// 角の外側を切り落とす
        /// </summary>
        Bevel = TonNurako.X11.Constant.JoinBevel

    }

	/// <summary>
	/// 線の形状
	/// </summary>
	public enum LineStyle : int
	{
		/// <summary>
		/// 直線
		/// </summary>
		Solid = TonNurako.X11.Constant.LineSolid,
		/// <summary>
		/// 破線
		/// 奇数番目の要素を前景色で描画
		/// </summary>
		OnOffDash = TonNurako.X11.Constant.LineOnOffDash,
		/// <summary>
		/// 破線
		/// 奇数番目の要素を前景色で、偶数番目の要素を背景色で描画
		/// </summary>
		DoubleDash = TonNurako.X11.Constant.LineDoubleDash
	}

    /// <summary>
    /// FillStyle
    /// </summary>
    public enum FillStyle : int
    {
        FillSolid = TonNurako.X11.Constant.FillSolid,
        FillTiled = TonNurako.X11.Constant.FillTiled,
        FillStippled = TonNurako.X11.Constant.FillStippled,
        FillOpaqueStippled = TonNurako.X11.Constant.FillOpaqueStippled,
    }

    /// <summary>
    /// FillRule
    /// </summary>
    public enum FillRule : int {
        EvenOddRule = TonNurako.X11.Constant.EvenOddRule,
        WindingRule = TonNurako.X11.Constant.WindingRule,
    }

    /// <summary>
    /// ArcMode
    /// </summary>
    public enum ArcMode : int {
        ArcChord = TonNurako.X11.Constant.ArcChord,
        ArcPieSlice = TonNurako.X11.Constant.ArcPieSlice,
    }

    /// <summary>
    /// SubWindowMode
    /// </summary>
    public enum SubWindowMode : int {
        ClipByChildren = TonNurako.X11.Constant.ClipByChildren,
        IncludeInferiors = TonNurako.X11.Constant.IncludeInferiors,
    }

    /// <summary>
    /// ﾄﾞﾛﾜﾎﾞー
    /// </summary>
    public interface IDrawable {
        IntPtr Drawable { get; }
        Display Display { get; }
    }

    /// <summary>
    /// gc破棄ﾊﾝﾄﾞﾗー
    /// </summary>
    /// <param name="gc"></param>
    public delegate void DispseGCDelegate(GC gc);

    public class GC : IX11Interop, IDisposable {
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "XmbDrawString_TNK", CharSet = CharSet.Auto)]
            internal static extern void XmbDrawString(IntPtr display, IntPtr d, IntPtr font_set, IntPtr gc, int x, int y, [In]byte[] str, int num_bytes);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XwcDrawString_TNK", CharSet = CharSet.Auto)]
            internal static extern void XwcDrawString(
                IntPtr display, IntPtr d, IntPtr font_set, IntPtr gc, int x, int y, [In]byte[] st, int num_wchars);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XwcDrawImageString_TNK", CharSet = CharSet.Auto)]
            internal static extern void XwcDrawImageString(
                IntPtr display, IntPtr d, IntPtr font_set, IntPtr gc, int x, int y, [MarshalAs(UnmanagedType.LPWStr)] string str, int num_wchars);
        }

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        Display display = null;
        public Display Display => display;

        IDrawable drawable = null;
        public IDrawable Drawable => drawable;

        bool autoDispose = false;
        public bool AutoDispose => autoDispose;


        public DispseGCDelegate DispseGCDelegate { get; set; } = null;

        public GC() {
        }

        public static GC Create(IDrawable d) =>
            (new GC(Xi.XCreateGC(d.Display, d.Drawable), d.Display, d, true));

        public static GC Create(IDrawable d, GCMask mask, XGCValues values) =>
            (new GC(Xi.XCreateGC(d.Display, d.Drawable, mask, values), d.Display, d, true));

        public GC(IntPtr gc, Display display, IDrawable drawable, bool boo) {
            this.display = display;
            this.drawable = drawable;
            this.handle = gc;
            autoDispose = boo;
        }

        public XGCValues GetGCValues(GCMask mask) {
            var v = new XGCValues();
            if (XStatus.True != Xi.XGetGCValues(display, handle, mask, v)) {
                return null;
            }
            return v;
        }
        public void DrawStringMultiByte(FontSet fontSet, int x, int y, string str) {
            var bs = Encoding.Default.GetBytes(str);
            NativeMethods.XmbDrawString(
                Display.Handle, drawable.Drawable, fontSet.Handle, this.Handle, x, y, bs, bs.Length);
        }

        public void DrawString(FontSet fontSet, int x, int y, string str) {
            NativeMethods.XwcDrawString(
                Display.Handle, drawable.Drawable, fontSet.Handle, this.Handle, x, y,
                Encoding.Convert(Encoding.Default, Encoding.UTF32, Encoding.Default.GetBytes(str)), str.Length);
        }

        public void DrawString(FontSet fontSet, System.Text.Encoding encoding, int x, int y, string str) {
            NativeMethods.XwcDrawString(
                Display.Handle, drawable.Drawable, fontSet.Handle, this.Handle, x, y,
                Encoding.Convert(encoding, Encoding.UTF32, encoding.GetBytes(str)), str.Length);
        }

        public void DrawImageString(FontSet fontSet, int x, int y, string str) {
            NativeMethods.XwcDrawImageString(
                Display.Handle, drawable.Drawable, fontSet.Handle, this.Handle, x, y, str, str.Length);
        }

        #region ｸﾘｱ

        /// <summary>
        /// 表示内容のｸﾘｱ
        /// </summary>
        public void Clear() {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XClearWindow(Display, Drawable.Drawable);
            }
        }

        public void SetForeground(TonNurako.X11.Color color) {
            if (Handle == IntPtr.Zero) {
                return;
            }
            TonNurako.X11.Xi.XSetForeground(Display, Handle, color.Pixel);
        }

        public void SetForeground(TonNurako.GC.Color color) {
            if (Handle == IntPtr.Zero) {
                return;
            }
            TonNurako.X11.Xi.XSetForeground(Display, Handle, color.Pixel);
        }

        public void SetForeground(ulong color) {
            if (Handle == IntPtr.Zero) {
                return;
            }
            TonNurako.X11.Xi.XSetForeground(Display, Handle, color);
        }

        public void CopyArea(IDrawable dest, int x, int y, int w, int h, int dx, int dy) {
            if (Handle == IntPtr.Zero) {
                return;
            }
            TonNurako.X11.Xi.XCopyArea(Display,
                Drawable.Drawable, dest.Drawable,
                this.Handle,
                x, y, (uint)w, (uint)h,
                dx, dy);
        }

        #endregion



        #region 図形描画

        /// <summary>
        /// 点を描画する
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        public void DrawPoint(int x, int y) {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XDrawPoint(Display, drawable.Drawable, Handle, x, y);
            }
        }
        /// <summary>
        /// 複数の点を描画する
        /// </summary>
        /// <param name="points">点の座標定義</param>
        /// <param name="mode">点の座標指定ﾓーﾄﾞ</param>
        public void DrawPoints(TonNurako.X11.XPoint[] points, TonNurako.X11.CoordMode mode) {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XDrawPoints(Display, drawable.Drawable, Handle, points, points.Length, (int)mode);
            }

        }

        /// <summary>
        /// 直線の描画
        /// </summary>
        /// <param name="ax">始点X座標</param>
        /// <param name="ay">始点Y座標</param>
        /// <param name="fx">終点X座標</param>
        /// <param name="fy">終点Y座標</param>
        public void DrawLine(int ax, int ay, int fx, int fy) {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XDrawLine(Display, drawable.Drawable, Handle, ax, ay, fx, fy);
            }
        }

        /// <summary>
        /// 折れ線の描画
        /// </summary>
        /// <param name="points">折れ線の座標定義</param>
        /// <param name="mode">折れ線の座標指定ﾓーﾄﾞ</param>
        public void DrawLines(TonNurako.X11.XPoint[] points, TonNurako.X11.CoordMode mode) {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XDrawLines(Display, drawable.Drawable, Handle, points, points.Length, (int)mode);
            }

        }

        /// <summary>
        /// 矩形の描画
        /// </summary>
        /// <param name="x">左上角X座標</param>
        /// <param name="y">左上角Y座標</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        public void DrawRectangle(int x, int y, int w, int h) {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XDrawRectangle(Display, drawable.Drawable, Handle, x, y, (uint)w, (uint)h);
            }
        }

        /// <summary>
        /// 複数矩形の描画
        /// </summary>
        /// <param name="rects">矩形の定義</param>
        public void DrawRectangle(TonNurako.X11.XRectangle[] rects) {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XDrawRectangles(Display, drawable.Drawable, Handle, rects, rects.Length);
            }

        }

        /// <summary>
        /// 塗りつぶし矩形の描画
        /// </summary>
        /// <param name="x">左上角X座標</param>
        /// <param name="y">左上角Y座標</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        public void FillRectangle(int x, int y, int w, int h) {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XFillRectangle(Display, drawable.Drawable, Handle, x, y, (uint)w, (uint)h);
            }
        }

        /// <summary>
        /// 塗りつぶし矩形の描画(2)
        /// </summary>
        /// <param name="drawable">drawable</param>
        /// <param name="x">左上角X座標</param>
        /// <param name="y">左上角Y座標</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        public void FillRectangle(IDrawable drawable, int x, int y, int w, int h) {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XFillRectangle(drawable.Display, drawable.Drawable, Handle, x, y, (uint)w, (uint)h);
            }
        }

        /// <summary>
        /// 複数の塗りつぶし矩形の描画
        /// </summary>
        /// <param name="rects">矩形の定義</param>
        public void FillRectangles(TonNurako.X11.XRectangle[] rects) {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XFillRectangles(Display, drawable.Drawable, Handle, rects, rects.Length);
            }

        }

        /// <summary>
        /// 円弧の描画
        /// </summary>
        /// <param name="x">左上角X座標</param>
        /// <param name="y">左上角Y座標</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        /// <param name="startAngle">開始角(度数*64)</param>
        /// <param name="sweepAngle">角度(度数*64)</param>
        public void DrawArc(int x, int y, int w, int h, int startAngle, int sweepAngle) {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XDrawArc(Display, drawable.Drawable, Handle,
                    x, y, (uint)w, (uint)h, startAngle, sweepAngle);
            }
        }

        /// <summary>
        /// 複数の円弧の描画
        /// </summary>
        /// <param name="arcs">円弧の定義</param>
        public void DrawArcs(TonNurako.X11.XArc[] arcs) {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XDrawArcs(Display, drawable.Drawable, Handle,
                    arcs, arcs.Length);
            }
        }

        /// <summary>
        /// 塗りつぶし円弧の描画
        /// </summary>
        /// <param name="x">左上角X座標</param>
        /// <param name="y">左上角Y座標</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        /// <param name="startAngle">開始角(度数*64)</param>
        /// <param name="sweepAngle">角度(度数*64)</param>
        public void FillArc(int x, int y, int w, int h, int startAngle, int sweepAngle) {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XFillArc(Display, drawable.Drawable, Handle,
                    x, y, (uint)w, (uint)h, startAngle, sweepAngle);
            }
        }

        /// <summary>
        /// 塗りつぶし円弧の描画(2)
        /// </summary>
        /// <param name="drawable">drawable</param>
        /// <param name="x">左上角X座標</param>
        /// <param name="y">左上角Y座標</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        /// <param name="startAngle">開始角(度数*64)</param>
        /// <param name="sweepAngle">角度(度数*64)</param>
        public void FillArc(IDrawable drawable, int x, int y, int w, int h, int startAngle, int sweepAngle) {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XFillArc(drawable.Display, drawable.Drawable, Handle,
                    x, y, (uint)w, (uint)h, startAngle, sweepAngle);
            }
        }

        /// <summary>
        /// 複数の塗りつぶし円弧の描画
        /// </summary>
        /// <param name="arcs">円弧の定義</param>
        public void FillArcs(TonNurako.X11.XArc[] arcs) {
            if (Handle != IntPtr.Zero) {
                TonNurako.X11.Xi.XFillArcs(Display, drawable.Drawable, Handle,
                    arcs, arcs.Length);
            }
        }

        #endregion

        #region 線の属性
        /// <summary>
        /// 線の属性の設定
        /// </summary>
        /// <param name="w">幅</param>
        /// <param name="line">線の形状</param>
        /// <param name="cap">端の形状</param>
        /// <param name="join">接合方法</param>
        public XStatus SetLineAttributes(uint w, TonNurako.X11.LineStyle line,
                TonNurako.X11.CapStyle cap,
                TonNurako.X11.JoinStyle join) {
            return TonNurako.X11.Xi.XSetLineAttributes(Display, Handle, w, (int)line, (int)cap, (int)join);
        }


        public XStatus SetDashes(int dash_offset, byte[] dash_list) {
            return TonNurako.X11.Xi.XSetDashes(Display, Handle, dash_offset, dash_list);
        }

        #endregion


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (handle != IntPtr.Zero && autoDispose == true) {
                    if (null != DispseGCDelegate) {
                        DispseGCDelegate(this);
                    }
                    else {
                        Xi.XFreeGC(display, handle);
                    }
                    handle = IntPtr.Zero;
                }
                disposedValue = true;
            }
        }

        #if RLE
        ~GC() {
            if (handle != IntPtr.Zero && autoDispose == true) {
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
    }

    /// <summary>
    /// XGCValues
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct XGCValuesRec {
        public int function; // int
        public ulong plane_mask; // unsigned long
        public ulong foreground; // unsigned long
        public ulong background; // unsigned long
        public int line_width; // int
        public LineStyle line_style; // int
        public CapStyle cap_style; // int
        public JoinStyle join_style; // int
        public FillStyle fill_style; // int
        public FillRule fill_rule; // int
        public ArcMode arc_mode; // int
        public System.IntPtr tile; // Pixmap
        public System.IntPtr stipple; // Pixmap
        public int ts_x_origin; // int
        public int ts_y_origin; // int
        public int font; // Font
        public SubWindowMode subwindow_mode; // int
        public bool graphics_exposures; // Bool
        public int clip_x_origin; // int
        public int clip_y_origin; // int
        public System.IntPtr clip_mask; // Pixmap
        public int dash_offset; // int
        public byte dashes; // char
    }

    /// <summary>
    /// XGCValues
    /// </summary>
    public class XGCValues {
        internal XGCValuesRec Record;


        public XGCValues() {
            Record = new XGCValuesRec();
        }

        public int Function {
            get { return Record.function; }
            set { Record.function = value; }
        }

        public ulong PlaneMask {
            get { return Record.plane_mask; }
            set { Record.plane_mask = value; }
        }

        public ulong Foreground {
            get { return Record.foreground; }
            set { Record.foreground = value; }
        }

        public ulong Background {
            get { return Record.background; }
            set { Record.background = value; }
        }

        public int LineWidth {
            get { return Record.line_width; }
            set { Record.line_width = value; }
        }

        public LineStyle line_style {
            get { return Record.line_style; }
            set { Record.line_style = value; }
        }

        public CapStyle cap_style {
            get { return Record.cap_style; }
            set { Record.cap_style = value; }
        }

        public JoinStyle join_style {
            get { return Record.join_style; }
            set { Record.join_style = value; }
        }

        public FillStyle fill_style {
            get { return Record.fill_style; }
            set { Record.fill_style = value; }
        }

        public FillRule fill_rule {
            get { return Record.fill_rule; }
            set { Record.fill_rule = value; }
        }

        public ArcMode arc_mode {
            get { return Record.arc_mode; }
            set { Record.arc_mode = value; }
        }

        //public System.IntPtr tile; // Pixmap
        // public System.IntPtr stipple; // Pixmap

        public int ts_x_origin {
            get { return Record.ts_x_origin; }
            set { Record.ts_x_origin = value; }
        }

        public int ts_y_origin {
            get { return Record.ts_y_origin; }
            set { Record.ts_y_origin = value; }
        }

        // public int font; // Font

        public SubWindowMode subwindow_mode {
            get { return Record.subwindow_mode; }
            set { Record.subwindow_mode = value; }
        }

        public bool graphics_exposures {
            get { return Record.graphics_exposures; }
            set { Record.graphics_exposures = value; }
        }

        public int clip_x_origin {
            get { return Record.clip_x_origin; }
            set { Record.clip_x_origin = value; }
        }

        public int clip_y_origin {
            get { return Record.clip_y_origin; }
            set { Record.clip_y_origin = value; }
        }

        // public System.IntPtr clip_mask; // Pixmap

        public int dash_offset {
            get { return Record.dash_offset; }
            set { Record.dash_offset = value; }
        }

        public byte dashes {
            get { return Record.dashes; }
            set { Record.dashes = value; }
        }

    }
}
