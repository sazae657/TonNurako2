using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.X11;


namespace TonNurako.X11.Extension.Xft {
    public class XftFontInfo : IX11Interop, IDisposable {
        internal static class NativeMethods {
            // XftFontInfo*: XftFontInfoCreate Display*:dpy  _Xconst FcPattern*:pattern
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftFontInfoCreate_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XftFontInfoCreate(IntPtr dpy, IntPtr pattern);

            // void: XftFontInfoDestroy Display*:dpy  XftFontInfo*:fi
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftFontInfoDestroy_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftFontInfoDestroy(IntPtr dpy, IntPtr fi);

            // FcChar32: XftFontInfoHash XftFontInfo*:fi
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftFontInfoHash_TNK", CharSet = CharSet.Auto)]
            internal static extern uint XftFontInfoHash(IntPtr fi);

            // FcBool: XftFontInfoEqual XftFontInfo*:a  _Xconst XftFontInfo*:b
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftFontInfoEqual_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XftFontInfoEqual(IntPtr a, IntPtr b);
        }

        Display display;
        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;


        internal XftFontInfo(IntPtr ptr, Display display) {
            handle = ptr;
            this.display = display;
        }

        internal static XftFontInfo WR(IntPtr ptr, Display display) {
            if (IntPtr.Zero == ptr) {
                return null;
            }
            return (new XftFontInfo(ptr, display));
        }

        public static XftFontInfo Create(Display dpy, FcPattern pattern) =>
            WR(NativeMethods.XftFontInfoCreate(dpy.Handle, pattern.Handle), dpy);

        public void Destroy() =>
            NativeMethods.XftFontInfoDestroy(display.Handle, handle);


        public uint Hash() =>
            NativeMethods.XftFontInfoHash(handle);


        public bool Equal(XftFontInfo b) =>
            NativeMethods.XftFontInfoEqual(handle, b.handle);

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                this.Destroy();
            }
        }

        #if RLE
        ~XftFontInfo() {
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
