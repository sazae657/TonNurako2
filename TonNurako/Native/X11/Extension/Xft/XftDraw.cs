using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.X11;

namespace TonNurako.X11.Extension.Xft {

    public enum FcEndian :int {
        FcEndianBig = TonNurako.X11.Constant.FcEndianBig,
        FcEndianLittle = TonNurako.X11.Constant.FcEndianLittle,
    }

    public class XftDraw : IX11Interop, IDrawable, IDisposable {
        #region ﾈーﾁﾌﾞ
        internal static class NativeMethods {
            // XftDraw*: XftDrawCreate Display*:dpy  Drawable:drawable  Visual*:visual  Colormap:colormap
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawCreate_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XftDrawCreate(IntPtr dpy, IntPtr drawable, IntPtr visual, int colormap);

            // XftDraw*: XftDrawCreateBitmap Display*:dpy  Pixmap:bitmap
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawCreateBitmap_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XftDrawCreateBitmap(IntPtr dpy, IntPtr bitmap);

            // XftDraw*: XftDrawCreateAlpha Display*:dpy  Pixmap:pixmap  int:depth
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawCreateAlpha_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XftDrawCreateAlpha(IntPtr dpy, IntPtr pixmap, int depth);

            // void: XftDrawChange XftDraw*:draw  Drawable:drawable
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawChange_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftDrawChange(IntPtr draw, IntPtr drawable);

            // Display*: XftDrawDisplay XftDraw*:draw
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawDisplay_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XftDrawDisplay(IntPtr draw);

            // Drawable: XftDrawDrawable XftDraw*:draw
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawDrawable_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XftDrawDrawable(IntPtr draw);

            // Colormap: XftDrawColormap XftDraw*:draw
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawColormap_TNK", CharSet = CharSet.Auto)]
            internal static extern int XftDrawColormap(IntPtr draw);

            // Visual*: XftDrawVisual XftDraw*:draw
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawVisual_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XftDrawVisual(IntPtr draw);

            // void: XftDrawDestroy XftDraw*:draw
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawDestroy_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftDrawDestroy(IntPtr draw);

            // Picture: XftDrawPicture XftDraw*:draw
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawPicture_TNK", CharSet = CharSet.Auto)]
            internal static extern int XftDrawPicture(IntPtr draw);

            // Picture: XftDrawSrcPicture XftDraw*:draw  XftColor*:color
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawSrcPicture_TNK", CharSet = CharSet.Auto)]
            internal static extern int XftDrawSrcPicture(IntPtr draw, ref XftColorRec color);



            // void: XftDrawGlyphs XftDraw*:draw  XftColor*:color  XftFont*:pub  int:x  int:y  FT_UInt*:glyphs  int:nglyphs
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawGlyphs_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftDrawGlyphs(IntPtr draw, ref XftColorRec color, IntPtr pub, int x, int y, [In]uint[] glyphs, int nglyphs);

            // void: XftDrawString8 XftDraw*:draw  XftColor*:color  XftFont*:pub  int:x  int:y  FcChar8*:string  int:len
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawString8_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftDrawString8(IntPtr draw, ref XftColorRec color, IntPtr pub, int x, int y, [In]byte[] str, int len);

            // void: XftDrawString16 XftDraw*:draw  XftColor*:color  XftFont*:pub  int:x  int:y  FcChar16*:string  int:len
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawString16_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftDrawString16(IntPtr draw, ref XftColorRec color, IntPtr pub, int x, int y, [MarshalAs(UnmanagedType.LPWStr)]string xstring, int len);

            // void: XftDrawString32 XftDraw*:draw  XftColor*:color  XftFont*:pub  int:x  int:y  FcChar32*:string  int:len
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawString32_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftDrawString32(IntPtr draw, ref XftColorRec color, IntPtr pub, int x, int y, [In] int[] str, int len);

            // void: XftDrawStringUtf8 XftDraw*:draw  XftColor*:color  XftFont*:pub  int:x  int:y  FcChar8*:string  int:len
            //[DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawStringUtf8_TNK", CharSet = CharSet.Auto)]
            //internal static extern void XftDrawStringUtf8(IntPtr draw, ref XftColorRec color, IntPtr pub, int x, int y, [MarshalAs(UnmanagedType.LPStr)]string str, int len);

            // void: XftDrawStringUtf16 XftDraw*:draw  XftColor*:color  XftFont*:pub  int:x  int:y  FcChar8*:string  FcEndian:endian  int:len
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawStringUtf16_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftDrawStringUtf16(IntPtr draw, ref XftColorRec color, IntPtr pub, int x, int y, [MarshalAs(UnmanagedType.LPWStr)]string str, FcEndian endian, int len);

            // void: XftDrawCharSpec XftDraw*:draw  XftColor*:color  XftFont*:pub  XftCharSpec*:chars  int:len
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawCharSpec_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftDrawCharSpec(IntPtr draw, ref XftColorRec color, IntPtr pub, [In]XftCharSpec[] chars, int len);

            // void: XftDrawCharFontSpec XftDraw*:draw  XftColor*:color  XftCharFontSpec*:chars  int:len
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawCharFontSpec_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftDrawCharFontSpec(IntPtr draw, ref XftColorRec color, [In]XftCharFontSpec[] chars, int len);

            // void: XftDrawGlyphSpec XftDraw*:draw  XftColor*:color  XftFont*:pub  XftGlyphSpec*:glyphs  int:len
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawGlyphSpec_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftDrawGlyphSpec(IntPtr draw, ref XftColorRec color, IntPtr pub, [In]XftGlyphSpec[] glyphs, int len);

            // void: XftDrawGlyphFontSpec XftDraw*:draw  XftColor*:color  XftGlyphFontSpec*:glyphs  int:len
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawGlyphFontSpec_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftDrawGlyphFontSpec(IntPtr draw, ref XftColorRec color, [In]XftGlyphSpec[] glyphs, int len);

            // void: XftDrawRect XftDraw*:draw  XftColor*:color  int:x  int:y  unsigned int:width  unsigned int:height
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawRect_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftDrawRect(IntPtr draw, ref XftColorRec color, int x, int y, uint width, uint height);

            // Bool: XftDrawSetClip XftDraw*:draw  Region:r
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawSetClip_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XftDrawSetClip(IntPtr draw, IntPtr r);

            // Bool: XftDrawSetClipRectangles XftDraw*:draw  int:xOrigin  int:yOrigin  XRectangle*:rects  int:n
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawSetClipRectangles_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XftDrawSetClipRectangles(IntPtr draw, int xOrigin, int yOrigin, TonNurako.X11.XRectangle[] rects, int n);

            // void: XftDrawSetSubwindowMode XftDraw*:draw  int:mode
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDrawSetSubwindowMode_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftDrawSetSubwindowMode(IntPtr draw, int mode);


        }
        #endregion

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => Handle;

        Display display;
        Visual visual;
        TonNurako.X11.Extension.Picture picture;
        internal XftDraw(IntPtr ptr) {
            handle = ptr;
            display = new X11.Display(() => NativeMethods.XftDrawDisplay(handle));
            visual = new X11.Visual(() => NativeMethods.XftDrawVisual(handle));
            picture = new X11.Extension.Picture(() => NativeMethods.XftDrawPicture(handle), false);
        }


        public Display Display => display;

        public IntPtr Drawable =>
            NativeMethods.XftDrawDrawable(handle);

        public Visual Visual => visual;

        public int Colormap =>
            NativeMethods.XftDrawColormap(handle);

        public TonNurako.X11.Extension.Picture Picture => picture;

        public void Change(IDrawable drawable) =>
            NativeMethods.XftDrawChange(handle, drawable.Drawable);


        public void Destroy() {
            if (handle != IntPtr.Zero) {
                NativeMethods.XftDrawDestroy(handle);
                handle = IntPtr.Zero;
            }
        }

        public Picture SrcPicture(XftColor color) {
            var p = NativeMethods.XftDrawSrcPicture(handle, ref color.Record);
            if (0 == p) {
                return null;
            }
            return (new Picture(null, p, false));
        }

        public void DrawString(XftColor color, XftFont pub, int x, int y, string str) =>
            NativeMethods.XftDrawString16(handle, ref color.Record, pub.Handle, x, y, str, str.Length);


        public void DrawString16(XftColor color, XftFont pub, int x, int y, string str) =>
            NativeMethods.XftDrawString16(handle, ref color.Record, pub.Handle, x, y, str, str.Length);


        public  void DrawGlyphs(XftColor color, XftFont pub, int x, int y, uint[] glyphs) =>
            NativeMethods.XftDrawGlyphs(handle, ref color.Record, pub.Handle, x, y, glyphs, glyphs.Length);


        public  void DrawString8(XftColor color, XftFont pub, int x, int y, byte[] str) =>
            NativeMethods.XftDrawString8(handle, ref color.Record, pub.Handle, x, y, str, str.Length);


        public  void DrawString32(XftColor color, XftFont pub, int x, int y, int[] str) =>
            NativeMethods.XftDrawString32(handle, ref color.Record, pub.Handle, x, y, str, str.Length);


        //public  void DrawStringUtf8(XftColor color, XftFont pub, int x, int y, string str) =>
        //    NativeMethods.XftDrawStringUtf8(handle, ref color.Record, pub.Handle, x, y, str, str.Length);


        public  void DrawStringUtf16(XftColor color, XftFont pub, int x, int y, string str, FcEndian endian = FcEndian.FcEndianLittle) =>
            NativeMethods.XftDrawStringUtf16(handle, ref color.Record, pub.Handle, x, y, str, endian, str.Length);


        public  void DrawCharSpec(XftColor color, XftFont pub, XftCharSpec[] chars) =>
            NativeMethods.XftDrawCharSpec(handle, ref color.Record, pub.Handle, chars, chars.Length);


        public  void DrawCharFontSpec(XftColor color, XftCharFontSpec[] chars) =>
            NativeMethods.XftDrawCharFontSpec(handle, ref color.Record, chars, chars.Length);


        public  void DrawGlyphSpec(XftColor color, XftFont pub, XftGlyphSpec[] glyphs) =>
            NativeMethods.XftDrawGlyphSpec(handle, ref color.Record, pub.Handle, glyphs, glyphs.Length);


        public  void DrawGlyphFontSpec(XftColor color, XftGlyphSpec[] glyphs) =>
            NativeMethods.XftDrawGlyphFontSpec(handle, ref color.Record, glyphs, glyphs.Length);


        public  void DrawRect(XftColor color, int x, int y, uint width, uint height) =>
            NativeMethods.XftDrawRect(handle, ref color.Record, x, y, width, height);


        public  bool SetClip(TonNurako.X11.Region r) =>
            NativeMethods.XftDrawSetClip(handle, r.Handle);


        public  bool SetClipRectangles(int xOrigin, int yOrigin, TonNurako.X11.XRectangle[] rects) =>
            NativeMethods.XftDrawSetClipRectangles(handle, xOrigin, yOrigin, rects, rects.Length);


        public  void SetSubwindowMode(int mode) =>
            NativeMethods.XftDrawSetSubwindowMode(handle, mode);


        #region staticおじさん
        public static XftDraw Create(Display dpy, IDrawable drawable, Visual visual, int colormap) {
            var p = NativeMethods.XftDrawCreate(dpy.Handle, drawable.Drawable, visual.Handle, colormap);
            if (IntPtr.Zero == p) {
                return null;
            }
            return (new XftDraw(p));
        }

        public static XftDraw CreateBitmap(Display dpy, TonNurako.X11.Pixmap bitmap) {
            var p = NativeMethods.XftDrawCreateBitmap(dpy.Handle, bitmap.Handle);
            if (IntPtr.Zero == p) {
                return null;
            }
            return (new XftDraw(p));
        }

        public static XftDraw CreateAlpha(Display dpy, TonNurako.X11.Pixmap pixmap, int depth) {
            var p = NativeMethods.XftDrawCreateAlpha(dpy.Handle, pixmap.Handle, depth);
            if (IntPtr.Zero == p) {
                return null;
            }
            return (new XftDraw(p));
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                this.Destroy();
            }
        }

        #if RLE
        ~XftDraw() {
            if (handle != IntPtr.Zero) {
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
}
