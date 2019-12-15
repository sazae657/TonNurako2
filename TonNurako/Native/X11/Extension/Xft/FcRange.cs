using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft {
#if USE_FC22
    public class FcRange : IX11Interop, IDisposable {
        internal static class NativeMethods {
            // FcRange*: FcRangeCreateDouble double:begin  double:end
            //[DllImport(ExtremeSports.Lib, EntryPoint = "FcRangeCreateDouble_TNK", CharSet = CharSet.Auto)]
            //internal static extern IntPtr FcRangeCreateDouble(double begin, double end);

            // FcRange*: FcRangeCreateInteger FcChar32:begin  FcChar32:end
            //[DllImport(ExtremeSports.Lib, EntryPoint = "FcRangeCreateInteger_TNK", CharSet = CharSet.Auto)]
            //internal static extern IntPtr FcRangeCreateInteger(uint begin, uint end);

            // void: FcRangeDestroy FcRange*:range
            //[DllImport(ExtremeSports.Lib, EntryPoint = "FcRangeDestroy_TNK", CharSet = CharSet.Auto)]
            //internal static extern void FcRangeDestroy(IntPtr range);

            // FcRange*: FcRangeCopy const FcRange*:r
            //[DllImport(ExtremeSports.Lib, EntryPoint = "FcRangeCopy_TNK", CharSet = CharSet.Auto)]
            //internal static extern IntPtr FcRangeCopy(IntPtr r);

            // FcBool: FcRangeGetDouble const FcRange*:range  double*:begin  double*:end
            //[DllImport(ExtremeSports.Lib, EntryPoint = "FcRangeGetDouble_TNK", CharSet = CharSet.Auto)]
            //internal static extern bool FcRangeGetDouble(IntPtr range, out double begin, out double end);
        }

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;
        public FcRange() {
        }

        internal FcRange(IntPtr p) {
            handle = p;
        }
        internal static FcRange WR(IntPtr ptr) => (IntPtr.Zero != ptr) ? (new FcRange(ptr)) : null;

        public static FcRange CreateDouble(double begin, double end)
            => WR(NativeMethods.FcRangeCreateDouble(begin, end));


        public static FcRange FcRangeCreateInteger(uint begin, uint end)
            => WR(NativeMethods.FcRangeCreateInteger(begin, end));

        public void Destroy() {
            if (IntPtr.Zero != handle) {
                NativeMethods.FcRangeDestroy(handle);
                handle = IntPtr.Zero;
            }
        }

        public FcRange Copy() =>
            WR(NativeMethods.FcRangeCopy(handle));


        public bool GetDouble(out double begin, out double end) =>
            NativeMethods.FcRangeGetDouble(handle, out begin, out end);

#region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                this.Destroy();
            }
        }

        // ~FcRange() {
        //   Dispose(false);
        // }

        public void Dispose() {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
#endregion

    }
#endif
}
