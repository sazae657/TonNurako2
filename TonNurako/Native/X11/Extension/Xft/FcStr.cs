using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft {

    public class FcStrList : IX11Interop, IDisposable {
        internal static class NativeMethods {
            // FcStrList*: FcStrListCreate FcStrSet*:set
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrListCreate_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcStrListCreate(IntPtr set);

            // void: FcStrListFirst FcStrList*:list
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrListFirst_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcStrListFirst(IntPtr list);

            // FcChar8*: FcStrListNext FcStrList*:list
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrListNext_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcStrListNext(IntPtr list);

            // void: FcStrListDone FcStrList*:list
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrListDone_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcStrListDone(IntPtr list);

        }
        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        internal FcStrList(IntPtr ptr) {
            handle = ptr;
        }

        internal static FcStrList WR(IntPtr ptr) {
            if (IntPtr.Zero == ptr) {
                return null;
            }
            return (new FcStrList(ptr));
        }

        public static FcStrList Create(FcStrSet set) =>
            new FcStrList(NativeMethods.FcStrListCreate(set.Handle));


        public void First() =>
            NativeMethods.FcStrListFirst(Handle);


        public string Next() {
            var k = NativeMethods.FcStrListNext(Handle);
            if (k == IntPtr.Zero) {
                return null;
            }
            return Marshal.PtrToStringAnsi(k);
        }

        public void Done() {
            if (IntPtr.Zero != handle) {
                NativeMethods.FcStrListDone(Handle);
                handle = IntPtr.Zero;
            }
        }


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                this.Done();
            }
        }

        #if RLE
        ~FcStrList() {
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

    public class FcStrSet : IX11Interop, IDisposable {
        internal static class NativeMethods {
            // FcStrSet*: FcStrSetCreate
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrSetCreate_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcStrSetCreate();

            // FcBool: FcStrSetMember FcStrSet*:set  const FcChar8*:s
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrSetMember_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcStrSetMember(IntPtr set, [MarshalAs(UnmanagedType.LPStr)]string s);

            // FcBool: FcStrSetEqual FcStrSet*:sa  FcStrSet*:sb
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrSetEqual_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcStrSetEqual(IntPtr sa, IntPtr sb);

            // FcBool: FcStrSetAdd FcStrSet*:set  const FcChar8*:s
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrSetAdd_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcStrSetAdd(IntPtr set, [MarshalAs(UnmanagedType.LPStr)]string s);

            // FcBool: FcStrSetAddFilename FcStrSet*:set  const FcChar8*:s
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrSetAddFilename_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcStrSetAddFilename(IntPtr set, [MarshalAs(UnmanagedType.LPStr)]string s);

            // FcBool: FcStrSetDel FcStrSet*:set  const FcChar8*:s
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrSetDel_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcStrSetDel(IntPtr set, [MarshalAs(UnmanagedType.LPStr)]string s);

            // void: FcStrSetDestroy FcStrSet*:set
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcStrSetDestroy_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcStrSetDestroy(IntPtr set);

        }

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        public FcStrSet() {
        }

        internal FcStrSet(IntPtr ptr) {
            this.handle = ptr;
        }

        internal static FcStrSet WR(IntPtr ptr) =>
            (IntPtr.Zero != ptr) ? (new FcStrSet(ptr)) : null;

        public static FcStrSet Create() =>
            FcStrSet.WR(NativeMethods.FcStrSetCreate());


        public bool Member(string s) =>
            NativeMethods.FcStrSetMember(Handle, s);


        public bool Equal(FcStrSet sb) =>
            NativeMethods.FcStrSetEqual(Handle, sb.handle);


        public bool Add(string s) =>
            NativeMethods.FcStrSetAdd(Handle, s);


        public bool AddFilename(string s) =>
            NativeMethods.FcStrSetAddFilename(Handle, s);

        public bool Del(string s) =>
            NativeMethods.FcStrSetDel(Handle, s);

        public void Destroy() {
            if (handle != IntPtr.Zero) {
                NativeMethods.FcStrSetDestroy(Handle);
                handle = IntPtr.Zero;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                this.Destroy();
            }
        }

        #if RLE
        ~FcStrSet() {
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