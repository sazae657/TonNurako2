//
// ﾄﾝﾇﾗｺ
//
// ｴｸｽﾄﾘーﾑｽﾎﾟーﾂ
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace TonNurako.Native
{
    /// <summary>
    /// 主にWindowsへの移植の野望達成の為のﾗｲﾌﾞﾗﾘーﾛーﾀﾞー
    /// </summary>
    public class ExtremeSportsLoader : System.IDisposable
    {
        [Serializable]
        public class SymbolNotFoundException : Exception
        {

            public string Symbol { get; internal set; }

            List<string> symbols = new List<string>();
            public IEnumerable<string> Symbols { get; }

            public SymbolNotFoundException(string symbol, string message) : base( message ) {
                Symbol = symbol;
                symbols.Add(symbol);
            }

            public SymbolNotFoundException(IEnumerable<string> symbols, string message) : base(message) {
                this.symbols.AddRange(symbols);
                Symbol = this.symbols[0];
            }
        }

        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport(ExtremeSports.Lib, EntryPoint = "GetProcAddressExtremeSports", BestFitMapping = false, ThrowOnUnmappableChar = true)]
            public static extern System.IntPtr GetProcAddressExtremeSports(System.IntPtr hModule,
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]string lpProcName);

            [System.Runtime.InteropServices.DllImport(ExtremeSports.Lib, EntryPoint = "LoadLibraryExtremeSports", BestFitMapping = false, ThrowOnUnmappableChar = true)]
            public static extern System.IntPtr LoadLibraryExtremeSports(
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]string lpFileName);

            [System.Runtime.InteropServices.DllImport(ExtremeSports.Lib, EntryPoint = "FreeLibraryExtremeSports", BestFitMapping = false, ThrowOnUnmappableChar = true)]
            public static extern System.IntPtr FreeLibraryExtremeSports(System.IntPtr hModule);
        }

        /// <summary>
        /// ﾀｸﾞ
        /// </summary>
        public string Tag {
            get; private set;
        }

        /// <summary>
        /// 使える？
        /// </summary>
        public bool IsAvailable {
            get; set;
        }

        /// <summary>
        /// ﾊﾝﾄﾞﾙ
        /// </summary>
        private IntPtr ModuleHandle {
            get; set;
        }

        public ExtremeSportsLoader()
        {
            Initialize();
        }

        public ExtremeSportsLoader(string tag)
        {
            Initialize();
            this.Load(tag);
        }

        public ExtremeSportsLoader(string path, string tag) {
            Initialize();
            this.Load(path, tag);
        }

        private void Initialize()
        {
            IsAvailable = false;
            ModuleHandle = IntPtr.Zero;
        }

        public bool Load(string tag)
        {
            if (true == IsAvailable) {
                return true;
            }
            ModuleHandle = NativeMethods.LoadLibraryExtremeSports(ExtremeSports.Lib);
            if (ModuleHandle == IntPtr.Zero) {
                throw new System.IO.FileNotFoundException($" LoadLibraryExtremeSports<{ExtremeSports.Lib}> FAILED!!");
            }
            IsAvailable = true;
            return true;
        }


        public bool Load(string path, string tag) {
            if (true == IsAvailable) {
                return true;
            }
            var ex = Path.Combine(path, ExtremeSports.Lib);
            ModuleHandle = NativeMethods.LoadLibraryExtremeSports(ex);
            if (ModuleHandle == IntPtr.Zero) {
                throw new System.IO.FileNotFoundException($" LoadLibraryExtremeSports<{ex}> FAILED!!");
            }
            IsAvailable = true;
            return true;
        }

        public T GetProcAddress<T>(string symbol) where T : class
        {
            if (! this.IsAvailable) {
                throw new System.InvalidOperationException($"{this.Tag}<{ExtremeSports.Lib}> Not Avalible");
            }

            var addr = NativeMethods.GetProcAddressExtremeSports(this.ModuleHandle, symbol);
            if (IntPtr.Zero == addr) {
                throw new SymbolNotFoundException(symbol, $"{symbol} Not Found");
            }

            return Marshal.GetDelegateForFunctionPointer(addr, typeof(T)) as T;
        }

        public IntPtr GetProcAddress(string symbol) {
            if (!this.IsAvailable) {
                throw new System.InvalidOperationException($"{this.Tag}<{ExtremeSports.Lib}> Not Avalible");
            }

            var addr = NativeMethods.GetProcAddressExtremeSports(this.ModuleHandle, symbol);
            if (IntPtr.Zero == addr) {
                throw new SymbolNotFoundException(symbol, $"{symbol} Not Found");
            }
            return addr;
        }

        #region IDisposable
        protected bool disposed;

        public void Dispose()
        {
            Dispose(true);
            // System.GC.SuppressFinalize(this);
        }

        internal virtual void Dispose(bool disposing)
        {
            if (disposed) {
                return;
            }

            if (IntPtr.Zero != ModuleHandle) {
                NativeMethods.FreeLibraryExtremeSports(this.ModuleHandle);
                this.ModuleHandle = IntPtr.Zero;
            }

            disposed = true;
        }
        #endregion


    }
}
