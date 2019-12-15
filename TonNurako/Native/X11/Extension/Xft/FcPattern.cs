using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.X11;

namespace TonNurako.X11.Extension.Xft {
    public enum FcResult :int {
        Match = TonNurako.X11.Constant.FcResultMatch,
        NoMatch = TonNurako.X11.Constant.FcResultNoMatch,
        TypeMismatch = TonNurako.X11.Constant.FcResultTypeMismatch,
        NoId = TonNurako.X11.Constant.FcResultNoId,
        OutOfMemory = TonNurako.X11.Constant.FcResultOutOfMemory,
    }


    public class FcPattern :IX11Interop,IDisposable {
        internal static class NativeMethods {
            // void: FcPatternDestroy FcPattern*:p
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternDestroy_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcPatternDestroy(IntPtr p);

            // FcPattern*: XftXlfdParse char*:xlfd_orig  Bool:ignore_scalable  Bool:complete
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftXlfdParse_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr XftXlfdParse(
                [MarshalAs(UnmanagedType.LPStr)] string xlfd_orig, [MarshalAs(UnmanagedType.U1)] bool ignore_scalable, [MarshalAs(UnmanagedType.U1)] bool complete);

            // FcPattern*: FcNameParse FcChar8*:name
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcNameParse_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr FcNameParse([MarshalAs(UnmanagedType.LPStr)]string name);


            // FcPattern*: FcPatternCreate
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternCreate_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcPatternCreate();

            // FcPattern*: FcPatternDuplicate const FcPattern*:p
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternDuplicate_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcPatternDuplicate(IntPtr p);

            // void: FcPatternReference FcPattern*:p
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternReference_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcPatternReference(IntPtr p);

            // FcPattern*: FcPatternFilter FcPattern*:p  const FcObjectSet*:os
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternFilter_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcPatternFilter(IntPtr p, ref FcObjectSet os);

            // FcBool: FcPatternEqual const FcPattern*:pa  const FcPattern*:pb
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternEqual_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcPatternEqual(IntPtr pa, IntPtr pb);

            // FcBool: FcPatternEqualSubset const FcPattern*:pa  const FcPattern*:pb  const FcObjectSet*:os
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternEqualSubset_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcPatternEqualSubset(IntPtr pa, IntPtr pb, ref FcObjectSet os);

            // FcChar32: FcPatternHash const FcPattern*:p
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternHash_TNK", CharSet = CharSet.Auto)]
            internal static extern uint FcPatternHash(IntPtr p);


            // FcBool: FcPatternDel FcPattern*:p  const char*:pbject
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternDel_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcPatternDel(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject);

            // FcBool: FcPatternRemove FcPattern*:p  const char*:pbject  int:id
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternRemove_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcPatternRemove(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, int id);

            // FcBool: FcPatternAddInteger FcPattern*:p  const char*:pbject  int:i
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternAddInteger_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcPatternAddInteger(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, int i);

            // FcBool: FcPatternAddDouble FcPattern*:p  const char*:pbject  double:d
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternAddDouble_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcPatternAddDouble(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, double d);

            // FcBool: FcPatternAddString FcPattern*:p  const char*:pbject  const FcChar8*:s
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternAddString_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcPatternAddString(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, [MarshalAs(UnmanagedType.LPStr)]string s);

            // FcBool: FcPatternAddMatrix FcPattern*:p  const char*:pbject  const FcMatrix*:s
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternAddMatrix_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcPatternAddMatrix(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, ref FcMatrixRec s);

            // FcBool: FcPatternAddCharSet FcPattern*:p  const char*:pbject  const FcCharSet*:c
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternAddCharSet_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcPatternAddCharSet(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, IntPtr c);

            // FcBool: FcPatternAddBool FcPattern*:p  const char*:pbject  FcBool:b
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternAddBool_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcPatternAddBool(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, bool b);

            // FcBool: FcPatternAddLangSet FcPattern*:p  const char*:pbject  const FcLangSet*:ls
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternAddLangSet_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcPatternAddLangSet(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, IntPtr ls);

            // FcResult: FcPatternGetInteger const FcPattern*:p  const char*:pbject  int:n  int*:i
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternGetInteger_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern FcResult FcPatternGetInteger(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, int n, out int i);

            // FcResult: FcPatternGetDouble const FcPattern*:p  const char*:pbject  int:n  double*:d
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternGetDouble_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern FcResult FcPatternGetDouble(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, int n, out double d);

            // FcResult: FcPatternGetString const FcPattern*:p  const char*:pbject  int:n  FcChar8**:s
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternGetString_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern FcResult FcPatternGetString(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, int n, out IntPtr s);

            // FcResult: FcPatternGetMatrix const FcPattern*:p  const char*:pbject  int:n  FcMatrix**:s
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternGetMatrix_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern FcResult FcPatternGetMatrix(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, int n, out IntPtr s);

            // FcResult: FcPatternGetCharSet const FcPattern*:p  const char*:pbject  int:n  FcCharSet**:c
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternGetCharSet_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern FcResult FcPatternGetCharSet(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, int n, out IntPtr c);

            // FcResult: FcPatternGetBool const FcPattern*:p  const char*:pbject  int:n  FcBool*:b
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternGetBool_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern FcResult FcPatternGetBool(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, int n, out bool b);

            // FcResult: FcPatternGetLangSet const FcPattern*:p  const char*:pbject  int:n  FcLangSet**:ls
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternGetLangSet_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern FcResult FcPatternGetLangSet(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, int n, out IntPtr ls);

            // FcChar8*: FcPatternFormat FcPattern*:pat  const FcChar8*:format
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternFormat_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern string FcPatternFormat(IntPtr pat, [MarshalAs(UnmanagedType.LPStr)]string format);

#if USE_FC22
            // FcBool: FcPatternAddRange FcPattern*:p  const char*:pbject  const FcRange*:r
            //[DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternAddRange_TNK", CharSet = CharSet.Auto)]
            //internal static extern bool FcPatternAddRange(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, IntPtr r);

            // FcResult: FcPatternGetRange const FcPattern*:p  const char*:pbject  int:id  FcRange**:r
            //[DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternGetRange_TNK", CharSet = CharSet.Auto)]
            //internal static extern FcResult FcPatternGetRange(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, int id, IntPtr[] r);
#endif
            /* ↓考え中
            // FcBool: FcValueEqual FcValue:va  FcValue:vb
            //[DllImport(ExtremeSports.Lib, EntryPoint = "FcValueEqual_TNK", CharSet = CharSet.Auto)]
            //internal static extern bool FcValueEqual([In]FcValue va, [In]FcValue vb);

            // FcValue: FcValueSave FcValue:v
            //[DllImport(ExtremeSports.Lib, EntryPoint = "FcValueSave_TNK", CharSet = CharSet.Auto)]
            //internal static extern IntPtr FcValueSave([In]FcValue v);

            // FcBool: FcPatternAdd FcPattern*:p  const char*:object  FcValue:value  FcBool:append
            //[DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternAdd_TNK", CharSet = CharSet.Auto)]
            //internal static extern bool FcPatternAdd(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, [In]FcValue value, bool append);

            // FcBool: FcPatternAddWeak FcPattern*:p  const char*:pbject  FcValue:value  FcBool:append
            //[DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternAddWeak_TNK", CharSet = CharSet.Auto)]
            //internal static extern bool FcPatternAddWeak(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, [In]FcValue value, bool append);

            // FcResult: FcPatternGet const FcPattern*:p  const char*:pbject  int:id  FcValue*:v
            //[DllImport(ExtremeSports.Lib, EntryPoint = "FcPatternGet_TNK", CharSet = CharSet.Auto)]
            //internal static extern FcResult FcPatternGet(IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string pbject, int id, ref FcValue v);
             */
        }

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        public FcPattern() {
        }

        internal FcPattern(IntPtr ptr) {
            handle = ptr;
        }

        public void Destroy() {
            if (handle != IntPtr.Zero) {
                NativeMethods.FcPatternDestroy(handle);
            }
            handle = IntPtr.Zero;
        }

        internal static FcPattern WR(IntPtr ptr) =>
            (IntPtr.Zero != ptr) ? (new FcPattern(ptr)) : null;

        public static FcPattern Create() =>
             WR(NativeMethods.FcPatternCreate());


        public FcPattern Duplicate() =>
            WR(NativeMethods.FcPatternDuplicate(Handle));


        public void Reference() =>
            NativeMethods.FcPatternReference(Handle);


        public FcPattern Filter(FcObjectSet os) =>
            WR(NativeMethods.FcPatternFilter(Handle, ref os));



        public bool Equal(FcPattern pb) =>
            NativeMethods.FcPatternEqual(Handle, pb.Handle);


        public bool EqualSubset(FcPattern pb, FcObjectSet os) =>
            NativeMethods.FcPatternEqualSubset(Handle, pb.Handle, ref os);

        /*
        public static bool FcValueEqual([In]FcValue va, [In]FcValue vb) {
            return NativeMethods.FcValueEqual(va, vb);
        }

        public static IntPtr FcValueSave([In]FcValue v) {
            return NativeMethods.FcValueSave(v);
        }*/


        public uint Hash() =>
            NativeMethods.FcPatternHash(Handle);

        public bool Del(FcObjectId obzekt) =>
            NativeMethods.FcPatternDel(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt));


        public bool Remove(FcObjectId obzekt, int id) =>
            NativeMethods.FcPatternRemove(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), id);

        public string Format(string format) =>
            NativeMethods.FcPatternFormat(Handle, format);

        /* FC22用
        public static bool FcPatternAdd(IntPtr p, string obzekt, [In]FcValue value, bool append) {
            return NativeMethods.FcPatternAdd(p, obzekt, value, append);
        }

        public static bool FcPatternAddWeak(IntPtr p, string obzekt, [In]FcValue value, bool append) {
            return NativeMethods.FcPatternAddWeak(p, obzekt, value, append);
        }*/


        public bool AddInteger(FcObjectId obzekt, int i) =>
                NativeMethods.FcPatternAddInteger(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), i);


        public bool AddDouble(FcObjectId obzekt, double d) =>
             NativeMethods.FcPatternAddDouble(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), d);


        public bool AddString(FcObjectId obzekt, string s) =>
             NativeMethods.FcPatternAddString(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), s);


        public bool AddMatrix(FcObjectId obzekt, FcMatrix s) =>
             NativeMethods.FcPatternAddMatrix(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), ref s.Record);


        public bool AddCharSet(FcObjectId obzekt, FcCharSet c) =>
             NativeMethods.FcPatternAddCharSet(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), c.Handle);


        public bool AddBool(FcObjectId obzekt, bool b) =>
             NativeMethods.FcPatternAddBool(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), b);


        public bool AddLangSet(FcObjectId obzekt, FcLangSet ls) =>
             NativeMethods.FcPatternAddLangSet(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), ls.Handle);


        /*　FC22用
         * public bool AddRange(FcObjectId obzekt, IntPtr r) =>
             NativeMethods.FcPatternAddRange(Handle, obzekt, r);
        */

        public FcResult GetInteger(FcObjectId obzekt, int n, out int i) =>
             NativeMethods.FcPatternGetInteger(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), n, out i);


        public  FcResult GetDouble(FcObjectId obzekt, int n, out double d) =>
             NativeMethods.FcPatternGetDouble(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), n, out d);


        public FcResult GetString(FcObjectId obzekt, int n, out string s) {
            IntPtr p;
            var r = NativeMethods.FcPatternGetString(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), n, out p);
            if (r == FcResult.TypeMismatch || p == IntPtr.Zero) {
                s = null;
                return r;
            }
            s = Marshal.PtrToStringAnsi(p);
            return r;
        }

        public FcResult GetBool(FcObjectId obzekt, int n, out bool b) =>
                NativeMethods.FcPatternGetBool(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), n, out b);



        public FcResult GetMatrix(FcObjectId obzekt, int n, out FcMatrix s) {
            s = null;
            IntPtr p = IntPtr.Zero;
            var r = NativeMethods.FcPatternGetMatrix(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), n, out p);
            if (r == FcResult.TypeMismatch || p == IntPtr.Zero) {
                return r;
            }
            s = new FcMatrix(p, true);
            return r;
        }


        public FcResult GetCharSet(FcObjectId obzekt, int n, out FcCharSet c) {
            c = null;
            IntPtr p = IntPtr.Zero;
            var r = NativeMethods.FcPatternGetCharSet(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), n, out p);
            if (r == FcResult.TypeMismatch || p == IntPtr.Zero) {
                return r;
            }
            c = new FcCharSet(p, true);
            return r;
        }


        public FcResult GetLangSet(FcObjectId obzekt, int n, FcLangSet ls) {
            ls = null;
            IntPtr p = IntPtr.Zero;
            var r = NativeMethods.FcPatternGetLangSet(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), n, out p);
            if (r == FcResult.TypeMismatch || p == IntPtr.Zero) {
                return r;
            }
            ls = new FcLangSet(p);
            return r;
        }


        /*   FC22用
         *   public  FcResult GetRange(FcObjectId obzekt, int id, IntPtr[] r) =>
                   NativeMethods.FcPatternGetRange(Handle, ToolkitOptionAttribute.GetToolkitName(obzekt), id, r);
        */





        #region staticおじさん
        public static FcPattern ParseXlfd(string xlfd_orig, bool ignore_scalable, bool complete) =>
                    FcPattern.WR(NativeMethods.XftXlfdParse(xlfd_orig, ignore_scalable, complete));


        public static FcPattern Parse(string name) =>
            FcPattern.WR(NativeMethods.FcNameParse(name));


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
        ~FcPattern() {
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
