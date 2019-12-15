using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft {
    public class FcBlanks :IX11Interop, IDisposable {
        internal static class NativeMethods {
            // FcBlanks*: FcBlanksCreate
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcBlanksCreate_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcBlanksCreate();

            // void: FcBlanksDestroy FcBlanks*:b
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcBlanksDestroy_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcBlanksDestroy(IntPtr b);

            // FcBool: FcBlanksAdd FcBlanks*:b  FcChar32:ucs4
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcBlanksAdd_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcBlanksAdd(IntPtr b, uint ucs4);

            // FcBool: FcBlanksIsMember FcBlanks*:b  FcChar32:ucs4
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcBlanksIsMember_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcBlanksIsMember(IntPtr b, uint ucs4);
        }

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;
        public FcBlanks() {
        }

        internal FcBlanks(IntPtr p) {
            handle = p;
        }

        public static FcBlanks Create() =>
            new FcBlanks(NativeMethods.FcBlanksCreate());


        public void Destroy() {
            if (handle != IntPtr.Zero) {
                NativeMethods.FcBlanksDestroy(Handle);
                handle = IntPtr.Zero;
            }
        }

        public bool Add(uint ucs4) =>
            NativeMethods.FcBlanksAdd(Handle, ucs4);


        public bool IsMember(uint ucs4) =>
            NativeMethods.FcBlanksIsMember(Handle, ucs4);


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                this.Destroy();
            }
        }

        #if RLE
        ~FcBlanks() {
            if (handle != IntPtr.Zero) {
                throw new ResourceLeakException(this);
            }
            Dispose(false);
        }
        #endif

        public void Dispose() {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        #endregion
    }
}
