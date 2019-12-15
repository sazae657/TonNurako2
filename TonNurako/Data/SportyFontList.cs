using System;
using System.Runtime.InteropServices;
using TonNurako.Native;
using TonNurako.Xt;

namespace TonNurako.Data
{
    /// <summary>
	/// ﾌｫﾝﾄﾘｽﾄ
	/// </summary>
    public class SportyFontList :IDisposable {
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint="XLoadFont_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern int XLoadFont(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string name);

            [DllImport(ExtremeSports.Lib, EntryPoint="XQueryFont_TNK", CharSet=CharSet.Auto)]
            internal static extern IntPtr XQueryFont(IntPtr display, int font_ID);

            [DllImport(ExtremeSports.Lib, EntryPoint="XLoadQueryFont_TNK", CharSet=CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr XLoadQueryFont(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string name);

            [DllImport(ExtremeSports.Lib, EntryPoint="XFreeFont_TNK", CharSet=CharSet.Auto)]
            internal static extern int XFreeFont(IntPtr display, IntPtr font_struct);

            [DllImport(ExtremeSports.Lib, EntryPoint="XGetFontProperty_TNK", CharSet=CharSet.Auto)]
            internal static extern int XGetFontProperty(IntPtr font_struct, ulong atom, out IntPtr value_return);

            [DllImport(ExtremeSports.Lib, EntryPoint="XUnloadFont_TNK", CharSet=CharSet.Auto)]
            internal static extern int XUnloadFont(IntPtr display, int font);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmFontListCreate_TNK", CharSet=CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr XmFontListCreate(IntPtr font, [MarshalAs(UnmanagedType.LPStr)] string charset);
        }

        private IntPtr fontList = IntPtr.Zero;
        public IntPtr FontList {
            get {return fontList;}
        }

        private IntPtr font = IntPtr.Zero;
        public IntPtr Font {
            get {return font;}
        }

        private IntPtr display = IntPtr.Zero;
        public IntPtr Display {
            get {return display;}
        }
        internal SportyFontList() {
        }

        public SportyFontList(Widgets.IWidget widget, string fontName) {
            display = XtSports.XtDisplay(widget);
            font = NativeMethods.XLoadQueryFont(XtSports.XtDisplay(widget), fontName);
            if (IntPtr.Zero == font) {
                throw new Exception($"{font}: XLoadQueryFont failed!!");
            }
            fontList = NativeMethods.XmFontListCreate(font, "");
            if (IntPtr.Zero == fontList) {
                throw new Exception($"{font}: XmFontListCreate failed!!");
            }
        }

        internal static SportyFontList FromFont(IntPtr fontRef) {
            var sf = new SportyFontList();
            sf.font = fontRef;
            sf.fontList = NativeMethods.XmFontListCreate(sf.font, "");
            if (IntPtr.Zero == sf.fontList) {
                throw new Exception($"{sf.font}: XmFontListCreate failed!!");
            }
            return sf;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (IntPtr.Zero != fontList) {
                    fontList = IntPtr.Zero;
                    display = IntPtr.Zero;
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        ~SportyFontList() {
            Dispose(false);
        }
        #endregion
    }
}
