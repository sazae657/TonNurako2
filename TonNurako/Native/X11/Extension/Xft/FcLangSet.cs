using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft {
    public class FcLangSet : IX11Interop, IDisposable {
        internal static class NativeMethods {


            // FcChar8*: FcLangNormalize const FcChar8*:lang
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangNormalize_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern string FcLangNormalize([MarshalAs(UnmanagedType.LPStr)]string lang);

            // const FcCharSet*: FcLangGetCharSet const FcChar8*:lang
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangGetCharSet_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr FcLangGetCharSet([MarshalAs(UnmanagedType.LPStr)]string lang);

            // FcLangSet*: FcLangSetCreate
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangSetCreate_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcLangSetCreate();

            // void: FcLangSetDestroy FcLangSet*:ls
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangSetDestroy_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcLangSetDestroy(IntPtr ls);

            // FcLangSet*: FcLangSetCopy const FcLangSet*:ls
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangSetCopy_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcLangSetCopy(IntPtr ls);

            // FcBool: FcLangSetAdd FcLangSet*:ls  const FcChar8*:lang
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangSetAdd_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcLangSetAdd(IntPtr ls, [MarshalAs(UnmanagedType.LPStr)]string lang);

            // FcBool: FcLangSetDel FcLangSet*:ls  const FcChar8*:lang
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangSetDel_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcLangSetDel(IntPtr ls, [MarshalAs(UnmanagedType.LPStr)]string lang);

            // FcLangResult: FcLangSetHasLang const FcLangSet*:ls  const FcChar8*:lang
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangSetHasLang_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern FcLangResult FcLangSetHasLang(IntPtr ls, [MarshalAs(UnmanagedType.LPStr)]string lang);

            // FcLangResult: FcLangSetCompare const FcLangSet*:lsa  const FcLangSet*:lsb
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangSetCompare_TNK", CharSet = CharSet.Auto)]
            internal static extern FcLangResult FcLangSetCompare(IntPtr lsa, IntPtr lsb);

            // FcBool: FcLangSetContains const FcLangSet*:lsa  const FcLangSet*:lsb
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangSetContains_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcLangSetContains(IntPtr lsa, IntPtr lsb);

            // FcBool: FcLangSetEqual const FcLangSet*:lsa  const FcLangSet*:lsb
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangSetEqual_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcLangSetEqual(IntPtr lsa, IntPtr lsb);

            // FcChar32: FcLangSetHash const FcLangSet*:ls
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangSetHash_TNK", CharSet = CharSet.Auto)]
            internal static extern uint FcLangSetHash(IntPtr ls);

            // FcStrSet*: FcLangSetGetLangs const FcLangSet*:ls
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangSetGetLangs_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcLangSetGetLangs(IntPtr ls);

            // FcLangSet*: FcLangSetUnion const FcLangSet*:a  const FcLangSet*:b
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangSetUnion_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcLangSetUnion(IntPtr a, IntPtr b);

            // FcLangSet*: FcLangSetSubtract const FcLangSet*:a  const FcLangSet*:b
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcLangSetSubtract_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcLangSetSubtract(IntPtr a, IntPtr b);
        }

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        public FcLangSet() {
        }

        internal FcLangSet(IntPtr ptr) {
            handle = ptr;
        }


        public static string Normalize(string lang) =>
            NativeMethods.FcLangNormalize(lang);


        public static FcCharSet FcLangGetCharSet(string lang) =>
            (FcCharSet.WR(NativeMethods.FcLangGetCharSet(lang), false));


        static FcLangSet WR(IntPtr p) =>
            (IntPtr.Zero != p) ? (new FcLangSet(p)) : null;

        public static FcLangSet Create() =>
            WR(NativeMethods.FcLangSetCreate());

        public void Destroy() {
            if (IntPtr.Zero != handle) {
                NativeMethods.FcLangSetDestroy(Handle);
                handle = IntPtr.Zero;
            }
        }

        public FcLangSet Copy() =>
            WR(NativeMethods.FcLangSetCopy(Handle));


        public bool Add(string lang) =>
            NativeMethods.FcLangSetAdd(Handle, lang);

        public bool Del(string lang) =>
            NativeMethods.FcLangSetDel(Handle, lang);


        public FcLangResult HasLang(string lang) =>
            NativeMethods.FcLangSetHasLang(Handle, lang);


        public FcLangResult Compare(FcLangSet lsb) =>
            NativeMethods.FcLangSetCompare(Handle, lsb.Handle);


        public bool SetContains(FcLangSet lsb) =>
            NativeMethods.FcLangSetContains(Handle, lsb.handle);


        public bool Equal(FcLangSet lsb) =>
            NativeMethods.FcLangSetEqual(Handle, lsb.Handle);


        public uint SetHash() =>
            NativeMethods.FcLangSetHash(Handle);


        public FcStrSet GetLangs() =>
            FcStrSet.WR(NativeMethods.FcLangSetGetLangs(Handle));


        public FcLangSet Union(FcLangSet b) =>
            WR(NativeMethods.FcLangSetUnion(Handle, b.Handle));


        public FcLangSet Subtract(FcLangSet b) =>
            WR(NativeMethods.FcLangSetSubtract(Handle, b.Handle));



        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                this.Destroy();
            }
        }
        #if RLE
        ~FcLangSet() {
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
