using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft {
    [StructLayout(LayoutKind.Sequential)]
    internal struct FcFontSetRec {
        public int nfont;
        public int sfont;
        [MarshalAs(UnmanagedType.LPArray)] public IntPtr[] fonts; //FcPattern**
    }
    public class FcFontSet :IX11Interop, IDisposable {
        internal static class NativeMethods {
            // FcFontSet*: FcFontSetCreate
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcFontSetCreate_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcFontSetCreate();

            // void: FcFontSetDestroy FcFontSet*:s
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcFontSetDestroy_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcFontSetDestroy(IntPtr s);

            // FcBool: FcFontSetAdd FcFontSet*:s  FcPattern*:font
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcFontSetAdd_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcFontSetAdd(IntPtr s, IntPtr font);


            // FcPattern*: FcFontSetMatch FcConfig*:config  FcFontSet**:sets  int:nsets  FcPattern*:p  FcResult*:result
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcFontSetMatch_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcFontSetMatch(IntPtr config, IntPtr sets, int nsets, IntPtr p, out FcResult result);

            // FcPattern*: FcFontMatch FcConfig*:config  FcPattern*:p  FcResult*:result
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcFontMatch_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcFontMatch(IntPtr config, IntPtr p, out FcResult result);

            // FcPattern*: FcFontRenderPrepare FcConfig*:config  FcPattern*:pat  FcPattern*:font
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcFontRenderPrepare_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcFontRenderPrepare(IntPtr config, IntPtr pat, IntPtr font);

            // FcFontSet*: FcFontSetSort FcConfig*:config  FcFontSet**:sets  int:nsets  FcPattern*:p  FcBool:trim  FcCharSet**:csp  FcResult*:result
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcFontSetSort_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcFontSetSort(IntPtr config, IntPtr sets, int nsets, IntPtr p, bool trim, IntPtr[] csp, out FcResult result);

            // FcFontSet*: FcFontSort FcConfig*:config  FcPattern*:p  FcBool:trim  FcCharSet**:csp  FcResult*:result
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcFontSort_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcFontSort(IntPtr config, IntPtr p, bool trim, IntPtr[] csp, out FcResult result);

            // void: FcFontSetSortDestroy FcFontSet*:fs
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcFontSetSortDestroy_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcFontSetSortDestroy(ref FcFontSetRec fs);

        }

        IntPtr handle;
        public IntPtr Handle => handle;

        internal FcFontSet(IntPtr ptr) {
            handle = ptr;
        }

        public static FcFontSet Create() =>
            new FcFontSet(NativeMethods.FcFontSetCreate());


        public void Destroy() =>
            NativeMethods.FcFontSetDestroy(handle);


        public bool Add(FcPattern font) =>
            NativeMethods.FcFontSetAdd(handle, font.Handle);


        /*
        // FcPattern*: FcFontSetMatch FcConfig*:config  FcFontSet**:sets  int:nsets  FcPattern*:p  FcResult*:result
        public IntPtr FcFontSetMatch(IntPtr config, IntPtr sets, int nsets, IntPtr p, out FcResult result) =>
            NativeMethods.FcFontSetMatch(config, sets, nsets, p, result);


        // FcPattern*: FcFontMatch FcConfig*:config  FcPattern*:p  FcResult*:result
        public static IntPtr FcFontMatch(IntPtr config, IntPtr p, out FcResult result) =>
            NativeMethods.FcFontMatch(config, p, result);


        // FcPattern*: FcFontRenderPrepare FcConfig*:config  FcPattern*:pat  FcPattern*:font
        public static IntPtr FcFontRenderPrepare(IntPtr config, IntPtr pat, IntPtr font) =>
            NativeMethods.FcFontRenderPrepare(config, pat, font);


        // FcFontSet*: FcFontSetSort FcConfig*:config  FcFontSet**:sets  int:nsets  FcPattern*:p  FcBool:trim  FcCharSet**:csp  FcResult*:result
        public static IntPtr FcFontSetSort(IntPtr config, IntPtr sets, int nsets, IntPtr p, bool trim, IntPtr[] csp, out FcResult result) =>
            NativeMethods.FcFontSetSort(config, sets, nsets, p, trim, csp, result);


        // FcFontSet*: FcFontSort FcConfig*:config  FcPattern*:p  FcBool:trim  FcCharSet**:csp  FcResult*:result
        public static IntPtr FcFontSort(IntPtr config, IntPtr p, bool trim, IntPtr[] csp, out FcResult result) =>
            NativeMethods.FcFontSort(config, p, trim, csp, result);
        */


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                this.Destroy();
            }
        }

        #if RLE
        ~FcFontSet() {
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
