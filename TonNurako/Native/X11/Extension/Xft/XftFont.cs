using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.X11;


namespace TonNurako.X11.Extension.Xft {


    public class XftFont : IX11Interop, IDisposable {
        internal static class NativeMethods {
            // XftFont*: XftFontOpenName Display*:dpy  int:screen  unsigned char*:name
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftFontOpenName_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr XftFontOpenName(IntPtr dpy, int screen, [In,MarshalAs(UnmanagedType.LPStr)] string name);

            // XftFont*: XftFontOpenPattern Display*:dpy  FcPattern*:fontpattern
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftFontOpenPattern_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XftFontOpenPattern(IntPtr dpy, IntPtr fontpattern);

            // XftFont*: XftFontOpenXlfd Display*:dpy  int:screen  String:xlfd
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftFontOpenXlfd_TNK", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr XftFontOpenXlfd(IntPtr dpy, int screen, [MarshalAs(UnmanagedType.LPStr)] string xlfd);

            // XftFont*: XftFontOpenInfo Display*:dpy  FcPattern*:pattern  XftFontInfo*:fi
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftFontOpenInfo_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XftFontOpenInfo(IntPtr dpy, IntPtr pattern, IntPtr fi);

            // void: XftFontClose Display*:dpy  XftFont*:font
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftFontClose_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftFontClose(IntPtr dpy, IntPtr font);

            // FcBool: XftCharExists Display*:dpy  XftFont*:pub  FcChar32:ucs4
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftCharExists_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XftCharExists(IntPtr dpy, IntPtr pub, uint ucs4);

            // FT_UInt: XftCharIndex Display*:dpy  XftFont*:pub  FcChar32:ucs4
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftCharIndex_TNK", CharSet = CharSet.Auto)]
            internal static extern uint XftCharIndex(IntPtr dpy, IntPtr pub, uint ucs4);



            #region XftFont
            // int
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetXftFontAscent", CharSet = CharSet.Auto)]
            internal static extern int TNK_GetXftFontAscent(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetXftFontAscent", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetXftFontAscent(IntPtr ptr, int omg);

            // int
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetXftFontDescent", CharSet = CharSet.Auto)]
            internal static extern int TNK_GetXftFontDescent(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetXftFontDescent", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetXftFontDescent(IntPtr ptr, int omg);

            // int
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetXftFontHeight", CharSet = CharSet.Auto)]
            internal static extern int TNK_GetXftFontHeight(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetXftFontHeight", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetXftFontHeight(IntPtr ptr, int omg);

            // int
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetXftFontMaxAdvanceWidth", CharSet = CharSet.Auto)]
            internal static extern int TNK_GetXftFontMaxAdvanceWidth(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetXftFontMaxAdvanceWidth", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetXftFontMaxAdvanceWidth(IntPtr ptr, int omg);

            // FcCharSet*
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetXftFontCharset", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetXftFontCharset(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetXftFontCharset", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetXftFontCharset(IntPtr ptr, IntPtr omg);

            // FcPattern*
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetXftFontPattern", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetXftFontPattern(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetXftFontPattern", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetXftFontPattern(IntPtr ptr, IntPtr omg);
            #endregion
        }

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        Display display;
        FcPattern fcPattern;

        public XftFont() {
        }

        internal XftFont(IntPtr ptr, FcPattern pattern, Display dpy) {
            display = dpy;
            handle = ptr;
            fcPattern = pattern;
        }

        public bool CharExists(uint ucs4) =>
            NativeMethods.XftCharExists(display.Handle, handle, ucs4);

        public bool CharExists(string str) =>
            NativeMethods.XftCharExists(display.Handle, handle, (uint)Char.ConvertToUtf32(str, 0));


        public uint CharIndex(uint ucs4) =>
            NativeMethods.XftCharIndex(display.Handle, handle, ucs4);


        public uint CharIndex(string str) =>
            NativeMethods.XftCharIndex(display.Handle, handle, (uint)Char.ConvertToUtf32(str, 0));


        public static XftFont OpenName(Display dpy, int screen, string name) {
            var p =  NativeMethods.XftFontOpenName(dpy.Handle, screen, name);
            if (IntPtr.Zero == p) {
                throw new ArgumentException($"XftFontOpenName({name}) == NULL");
            }

            /*var pattern = FcPattern.Parse(name);
            if (null == pattern) {
                NativeMethods.XftFontClose(dpy.Handle, p);
                throw new ArgumentException($"FcNameParse({name}) == NULL");
            }*/

            return (new XftFont(p, null, dpy));
        }

        public static XftFont OpenPattern(Display dpy, FcPattern fontpattern) {
            var p =  NativeMethods.XftFontOpenPattern(dpy.Handle, fontpattern.Handle);
            if (IntPtr.Zero == p) {
                throw new ArgumentException($"XftFontOpenPattern() == NULL");
            }
            return (new XftFont(p, fontpattern, dpy));
        }

        public static XftFont OpenXlfd(Display dpy, int screen, string xlfd) {
            var p = NativeMethods.XftFontOpenXlfd(dpy.Handle, screen, xlfd);
            if (IntPtr.Zero == p) {
                throw new ArgumentException($"XftFontOpenPattern() == NULL");
            }
            return (new XftFont(p, null, dpy));
        }
        public static XftFont OpenInfo(Display dpy, FcPattern pattern, XftFontInfo fi) {
            var p = NativeMethods.XftFontOpenInfo(dpy.Handle, pattern.Handle, fi.Handle);
            if (IntPtr.Zero == p) {
                throw new ArgumentException($"XftFontOpenInfo() == NULL");
            }
            return (new XftFont(p, pattern, dpy));

        }



        public void Close() {
            if (handle != IntPtr.Zero) {
                NativeMethods.XftFontClose(display.Handle, handle);
                handle = IntPtr.Zero;
            }
            if (null != fcPattern) {
                fcPattern.Dispose();
                fcPattern = null;
            }
        }

        #region XftFontｱｸｾｯｻー
        public int Ascent {
            get => NativeMethods.TNK_GetXftFontAscent(this.Handle);
            set => NativeMethods.TNK_SetXftFontAscent(this.Handle, value);
        }

        public int Descent {
            get => NativeMethods.TNK_GetXftFontDescent(this.Handle);
            set => NativeMethods.TNK_SetXftFontDescent(this.Handle, value);
        }

        public int Height {
            get => NativeMethods.TNK_GetXftFontHeight(this.Handle);
            set => NativeMethods.TNK_SetXftFontHeight(this.Handle, value);
        }

        public int MaxAdvanceWidth {
            get => NativeMethods.TNK_GetXftFontMaxAdvanceWidth(this.Handle);
            set => NativeMethods.TNK_SetXftFontMaxAdvanceWidth(this.Handle, value);
        }

        internal IntPtr Charset {
            get => NativeMethods.TNK_GetXftFontCharset(this.Handle);
            set => NativeMethods.TNK_SetXftFontCharset(this.Handle, value);
        }

        internal IntPtr Pattern {
            get => NativeMethods.TNK_GetXftFontPattern(this.Handle);
            set => NativeMethods.TNK_SetXftFontPattern(this.Handle, value);
        }
        #endregion


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                this.Close();
            }
        }

        #if RLE
        ~XftFont() {
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

    public class XftFontRecord {
        internal static class NativeMethods {

        }



    }
}
