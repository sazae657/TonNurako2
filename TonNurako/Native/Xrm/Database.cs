using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.X11;

namespace TonNurako.Xrm {
    public class XrmDatabase :IX11Interop, IDisposable {

        #region ｲﾝﾎﾟ
        internal static class NativeMethods {
            // XrmDatabase: XrmGetFileDatabase char*:filename  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XrmGetFileDatabase_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr XrmGetFileDatabase([MarshalAs(UnmanagedType.LPStr)] string filename);

            // void: XrmPutFileDatabase XrmDatabase:database  char*:stored_db  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XrmPutFileDatabase_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern void XrmPutFileDatabase(IntPtr database, [MarshalAs(UnmanagedType.LPStr)] string stored_db);

            // XrmDatabase: XrmGetStringDatabase char*:data  char*:XrmLocaleOfDatabase  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XrmGetStringDatabase_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr XrmGetStringDatabase([MarshalAs(UnmanagedType.LPStr)] string data);

            // XrmDatabase: XrmGetDatabase Display*:display  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XrmGetDatabase_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XrmGetDatabase(IntPtr display);

            // void: XrmSetDatabase Display*:display  XrmDatabase:database  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XrmSetDatabase_TNK", CharSet = CharSet.Auto)]
            internal static extern void XrmSetDatabase(IntPtr display, IntPtr database);

            // void: XrmDestroyDatabase XrmDatabase:database  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XrmDestroyDatabase_TNK", CharSet = CharSet.Auto)]
            internal static extern void XrmDestroyDatabase(IntPtr database);

            // void: XrmMergeDatabases XrmDatabase:source_db  XrmDatabase*:target_db  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XrmMergeDatabases_TNK", CharSet = CharSet.Auto)]
            internal static extern void XrmMergeDatabases(IntPtr source_db, ref IntPtr target_db);

            // void: XrmCombineDatabase XrmDatabase:source_db  XrmDatabase*:target_db  Bool:override  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XrmCombineDatabase_TNK", CharSet = CharSet.Auto)]
            internal static extern void XrmCombineDatabase(IntPtr source_db, ref IntPtr target_db, [MarshalAs(UnmanagedType.U1)] bool pverride);

            // Status: XrmCombineFileDatabase char*:filename  XrmDatabase*:target_db  Bool:override  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XrmCombineFileDatabase_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern int XrmCombineFileDatabase([MarshalAs(UnmanagedType.LPStr)] string filename, ref IntPtr target_db, [MarshalAs(UnmanagedType.U1)] bool pverride);

        }
        #endregion

        internal IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        bool callDestroy = true;

        public XrmDatabase() {
        }

        internal XrmDatabase(IntPtr db, bool destroy) {
            handle = db;
            callDestroy = destroy;
        }

        static XrmDatabase ぉ(IntPtr db,bool destroy) {
            if (IntPtr.Zero == db) {
                throw new NullReferenceException("db == NULL");
            }
            return new XrmDatabase(db, destroy);
        }

        #region staticおじさん
        public static XrmDatabase GetFileDatabase(string filename) {
            return ぉ(NativeMethods.XrmGetFileDatabase(filename), true);
        }

        public static XrmDatabase GetStringDatabase(string data) {
            return ぉ(NativeMethods.XrmGetStringDatabase(data), true);
        }

        public static XrmDatabase GetDatabase(IntPtr display) {
            return ぉ(NativeMethods.XrmGetDatabase(display), true);
        }


        public static void MergeDatabases(XrmDatabase source_db, XrmDatabase target_db) {
            NativeMethods.XrmMergeDatabases(source_db.handle, ref target_db.handle);
        }

        public static void CombineDatabase(XrmDatabase source_db, XrmDatabase target_db, bool _override) {
            NativeMethods.XrmCombineDatabase(source_db.handle, ref target_db.handle, _override);
        }

        public static　int CombineFileDatabase(string filename, XrmDatabase target_db, bool _override) {
            return NativeMethods.XrmCombineFileDatabase(filename, ref target_db.handle, _override);
        }
        #endregion


        public void PutFileDatabase(string stored_db) {
            NativeMethods.XrmPutFileDatabase(handle, stored_db);
        }


        public void SetDatabase(Display display) {
            NativeMethods.XrmSetDatabase(display.Handle, handle);
        }

        public void DestroyDatabase() {
            NativeMethods.XrmDestroyDatabase(handle);
            handle = IntPtr.Zero;
        }



    #region IDisposable Support
    private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (true == callDestroy && IntPtr.Zero != handle) {
                    DestroyDatabase();
                }
                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(true);
        }
        #endregion
    }
}
