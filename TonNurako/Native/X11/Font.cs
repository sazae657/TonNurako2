using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11 {
    [StructLayout(LayoutKind.Sequential)]
    public struct XCharStruct {
        public Int16 lbearing; // short
        public Int16 rbearing; // short
        public Int16 width; // short
        public Int16 ascent; // short
        public Int16 descent; // short
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XFontProp {
        public ulong name; // Atom
        public ulong card32; // unsigned long
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XChar2b {
        public byte byte1; // unsigned char
        public byte byte2; // unsigned char
    }


    [StructLayout(LayoutKind.Sequential)]
    internal struct XFontStructRec {
        public IntPtr ext_data; // XExtData*
        public int fid; // Font
        public uint direction; // unsigned
        public uint min_char_or_byte2; // unsigned
        public uint max_char_or_byte2; // unsigned
        public uint min_byte1; // unsigned
        public uint max_byte1; // unsigned
        [MarshalAs(UnmanagedType.U1)] public bool all_chars_exist; // Bool
        public uint default_char; // unsigned
        public int n_properties; // int
        public IntPtr properties; // XFontProp*
        public TonNurako.X11.XCharStruct min_bounds; // XCharStruct
        public TonNurako.X11.XCharStruct max_bounds; // XCharStruct
        public IntPtr per_char; // XCharStruct*
        public int ascent; // int
        public int descent; // int
    }

    public class XFontStruct {
        IntPtr Src;
        XFontStructRec rec;
        XFontProp[] fontProp;
        XCharStruct[] charStruct = null;
        public XFontStruct(IntPtr src) {
            Src = src;
            rec = Marshal.PtrToStructure<XFontStructRec>(src);
            // rec.ext_data
            if (rec.n_properties != 0) {
                var arr = new IntPtr[rec.n_properties];
                Marshal.Copy(rec.properties, arr, 0, rec.n_properties);
                fontProp = new XFontProp[rec.n_properties];
                for (int i = 0; i < rec.n_properties; ++i) {
                    fontProp[i] = Marshal.PtrToStructure<XFontProp>(arr[i]);
                }

            }
        }

        // public IntPtr ext_data; // XExtData*

        public int FID => rec.fid;

        public uint Direction => rec.direction;
        public uint MinCharOrByte2 => rec.min_char_or_byte2;
        public uint MaxCharOrByte2 => rec.max_char_or_byte2;
        public uint MinByte1 => rec.min_byte1;
        public uint MaxByte1 => rec.max_byte1;
        public bool AllCharsExist => rec.all_chars_exist;
        public uint DefaultChar => rec.default_char;
        //public int  n_properties => rec.n_properties;
        public XFontProp[] Properties => fontProp;
        public TonNurako.X11.XCharStruct MinBounds => rec.min_bounds;
        public TonNurako.X11.XCharStruct MaxBounds => rec.max_bounds;
        public XCharStruct[] PerChar => charStruct;
        public int Ascent => rec.ascent;
        public int Descent => rec.descent;

    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XFontSetExtentsRec {
        public XRectangle max_ink_extent;      /* over all drawable characters */
        public XRectangle max_logical_extent;  /* over all drawable characters */
    }

    public class XFontSetExtents : IDisposable {
        IntPtr handle;
        XFontSetExtentsRec record;

        public XFontSetExtents(IntPtr hDC) {
            if (IntPtr.Zero == hDC) {
                throw new NullReferenceException("hDC == NULL");
            }
            handle = hDC;
            record = Marshal.PtrToStructure<XFontSetExtentsRec>(hDC);
        }

        public XRectangle MaxInkExtent => record.max_ink_extent;
        public XRectangle MaxLogicalExtent => record.max_logical_extent;

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
            }
        }


        // ~XFontSetExtents() {
        //   Dispose(false);
        // }


        public void Dispose() {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion
    }



    public class TextExtents {
        internal XRectangle overall_ink;
        public XRectangle OverallLnk => overall_ink;

        internal XRectangle overall_logical;

        public XRectangle OverallLogical => overall_logical;

        public TextExtents() {
            overall_ink = new XRectangle();
            overall_logical = new XRectangle();
        }
    }

    public class FontSet : IX11Interop, IDisposable {

        internal static class NativeMethods {

            [DllImport(ExtremeSports.Lib, EntryPoint = "XCreateFontSet_TNK", CharSet = CharSet.Auto, BestFitMapping =false,ThrowOnUnmappableChar =true)]
            internal static extern IntPtr XCreateFontSet(
                IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string base_font_name_list, out IntPtr missing_charset_list_return, out int missing_charset_count_return, out IntPtr def_string_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFreeFontSet_TNK", CharSet = CharSet.Auto)]
            internal static extern void XFreeFontSet(IntPtr display, [In] IntPtr font_set);

            /*
             * XDrawStringやらんので保留
            [DllImport(ExtremeSports.Lib, EntryPoint = "XLoadFont_TNK", CharSet = CharSet.Auto)]
            internal static extern int XLoadFont(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string name);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XUnloadFont_TNK", CharSet = CharSet.Auto)]
            internal static extern int XUnloadFont(IntPtr display, int font);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XListFontsWithInfo_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XListFontsWithInfo(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string pattern, int maxnames, out int count_return, out IntPtr info_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFreeFontInfo_TNK", CharSet = CharSet.Auto)]
            internal static extern int XFreeFontInfo([In]IntPtr names, [In]IntPtr free_info, int actual_count);
             */

            // XFontStruct*: XQueryFont [{'type': 'Display*', 'name': 'display'}, {'type': 'XID', 'name': 'font_ID'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XQueryFont_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XQueryFont(IntPtr display, int font_ID);

            // XFontStruct*: XLoadQueryFont [{'type': 'Display*', 'name': 'display'}, {'type': 'char*', 'name': 'name'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XLoadQueryFont_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr XLoadQueryFont(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string name);

            // int: XFreeFont [{'type': 'Display*', 'name': 'display'}, {'type': 'XFontStruct*', 'name': 'font_struct'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XFreeFont_TNK", CharSet = CharSet.Auto)]
            internal static extern int XFreeFont(IntPtr display, IntPtr font_struct);

            // Bool: XGetFontProperty [{'type': 'XFontStruct*', 'name': 'font_struct'}, {'type': 'Atom', 'name': 'atom'}, {'type': 'unsigned long*', 'name': 'value_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetFontProperty_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XGetFontProperty(IntPtr font_struct, ulong atom, out IntPtr value_return);


            [DllImport(ExtremeSports.Lib, EntryPoint = "XListFonts_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr XListFonts(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string pattern, int maxnames, out int actual_count_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFreeFontNames_TNK", CharSet = CharSet.Auto)]
            internal static extern int XFreeFontNames([In]IntPtr list);

            // int: XmbTextExtents [{'type': 'XFontSet', 'name': 'font_set'}, {'type': 'char*', 'name': 'string'}, {'type': 'int', 'name': 'num_bytes'}, {'type': 'XRectangle*', 'name': 'overall_ink_return'}, {'type': 'XRectangle*', 'name': 'overall_logical_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XmbTextExtents_TNK", CharSet = CharSet.Auto)]
            internal static extern ErrorCode XmbTextExtents(IntPtr font_set, [In] byte[] str, int num_bytes, ref TonNurako.X11.XRectangle overall_ink_return, ref TonNurako.X11.XRectangle overall_logical_return);

            // int: XwcTextExtents [{'type': 'XFontSet', 'name': 'font_set'}, {'type': 'wchar_t*', 'name': 'string'}, {'type': 'int', 'name': 'num_wchars'}, {'type': 'XRectangle*', 'name': 'overall_ink_return'}, {'type': 'XRectangle*', 'name': 'overall_logical_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XwcTextExtents_TNK", CharSet = CharSet.Auto)]
            internal static extern ErrorCode XwcTextExtents(IntPtr font_set, [In] byte[] str, int num_wchars, ref TonNurako.X11.XRectangle overall_ink_return, ref TonNurako.X11.XRectangle overall_logical_return);

            // XFontSetExtents*: XExtentsOfFontSet [{'type': 'XFontSet', 'name': 'font_set'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XExtentsOfFontSet_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XExtentsOfFontSet(IntPtr font_set);

        }

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        Display display;
        public Display Display => display;

        delegate void Delegaty();

        Delegaty DestructFunction = null;

        public string[] MissingCharsetList { get; internal set; }

        public FontSet() {
            handle = IntPtr.Zero;
        }

        public static string[] ListFonts(Display display, string pattern, int max) {
            int count;
            IntPtr names = NativeMethods.XListFonts(display.Handle, pattern, max, out count);
            if (IntPtr.Zero == names) {
                throw new Exception("XListFonts failed");
            }

            var arr = new IntPtr[count];
            Marshal.Copy(names, arr, 0, count);
            var ret = new string[count];

            for (int i = 0; i < count; ++i) {
                ret[i] = Marshal.PtrToStringAnsi(arr[i]);
            }

            NativeMethods.XFreeFontNames(names);
            return ret;
        }

        public ErrorCode TextExtentsMultiByte(string str, TextExtents extents) {
            var bs = Encoding.Default.GetBytes(str);
            var r = NativeMethods.XmbTextExtents(this.Handle, bs, bs.Length, ref extents.overall_ink, ref extents.overall_logical);
            return r;
        }


        public ErrorCode TextExtents(string str, TextExtents extents) {
            var gs = Encoding.Convert(Encoding.Default, Encoding.UTF32, Encoding.Default.GetBytes(str));
            var r = NativeMethods.XwcTextExtents(this.Handle, gs, str.Length, ref extents.overall_ink, ref extents.overall_logical);
            return r;
        }

        public XFontSetExtents XExtentsOfFontSet() {
            var f = NativeMethods.XExtentsOfFontSet(this.Handle);
            if (IntPtr.Zero == f) {
                return null;
            }
            return new XFontSetExtents(f);
        }

        public static FontSet CreateFontSet(Display display, string font_name_list) {
            var fs = new FontSet();
            fs.display = display;
            IntPtr mc;
            int mco;
            IntPtr def;

            fs.handle = NativeMethods.XCreateFontSet(
                display.Handle, font_name_list, out mc, out mco, out def);
            if (fs.handle == IntPtr.Zero) {
                throw new Exception("XCreateFontSet failed");
            }

            if (IntPtr.Zero != mc) {
                var arr = new IntPtr[mco];
                Marshal.Copy(mc, arr, 0, mco);
                fs.MissingCharsetList = new string[mco];
                for (int i = 0; i < mco; ++i) {
                    fs.MissingCharsetList[i] = Marshal.PtrToStringAnsi(arr[i]);
                }
                TonNurako.X11.Xi.FreeStringList(mc);
            }

            fs.DestructFunction = () => {
                if (IntPtr.Zero != fs.Handle) {
                    NativeMethods.XFreeFontSet(display.Handle, fs.Handle);
                    fs.handle = IntPtr.Zero;
                }
            };
            return fs;
        }


        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                DestructFunction?.Invoke();
                handle = IntPtr.Zero;
                disposedValue = true;
            }
        }

        #if RLE
        ~FontSet() {
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
