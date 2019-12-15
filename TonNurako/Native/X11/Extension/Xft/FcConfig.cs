using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft {
    public class FcConfig : IX11Interop, IDisposable {
        internal static class NativeMethods {
            // FcChar8*: FcConfigHome
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigHome_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcConfigHome();

            // FcBool: FcConfigEnableHome FcBool:enable
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigEnableHome_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcConfigEnableHome(bool enable);

            // FcChar8*: FcConfigFilename const FcChar8*:url
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigFilename_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr FcConfigFilename([MarshalAs(UnmanagedType.LPStr)]string url);

            // FcConfig*: FcConfigCreate
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigCreate_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcConfigCreate();

            // FcConfig*: FcConfigReference FcConfig*:config
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigReference_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcConfigReference(IntPtr config);

            // void: FcConfigDestroy FcConfig*:config
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigDestroy_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcConfigDestroy(IntPtr config);

            // FcBool: FcConfigSetCurrent FcConfig*:config
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigSetCurrent_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcConfigSetCurrent(IntPtr config);

            // FcConfig*: FcConfigGetCurrent
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigGetCurrent_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcConfigGetCurrent();

            // FcBool: FcConfigUptoDate FcConfig*:config
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigUptoDate_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcConfigUptoDate(IntPtr config);

            // FcBool: FcConfigBuildFonts FcConfig*:config
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigBuildFonts_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcConfigBuildFonts(IntPtr config);

            // FcStrList*: FcConfigGetFontDirs FcConfig*:config
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigGetFontDirs_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcConfigGetFontDirs(IntPtr config);

            // FcStrList*: FcConfigGetConfigDirs FcConfig*:config
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigGetConfigDirs_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcConfigGetConfigDirs(IntPtr config);

            // FcStrList*: FcConfigGetConfigFiles FcConfig*:config
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigGetConfigFiles_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcConfigGetConfigFiles(IntPtr config);

            // FcChar8*: FcConfigGetCache FcConfig*:config
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigGetCache_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcConfigGetCache(IntPtr config);

            // FcBlanks*: FcConfigGetBlanks FcConfig*:config
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigGetBlanks_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcConfigGetBlanks(IntPtr config);

            // FcStrList*: FcConfigGetCacheDirs const FcConfig*:config
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigGetCacheDirs_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcConfigGetCacheDirs(IntPtr config);

            // int: FcConfigGetRescanInterval FcConfig*:config
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigGetRescanInterval_TNK", CharSet = CharSet.Auto)]
            internal static extern int FcConfigGetRescanInterval(IntPtr config);

            // FcBool: FcConfigSetRescanInterval FcConfig*:config  int:rescanInterval
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigSetRescanInterval_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcConfigSetRescanInterval(IntPtr config, int rescanInterval);

            // FcFontSet*: FcConfigGetFonts FcConfig*:config  FcSetName:set
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigGetFonts_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcConfigGetFonts(IntPtr config, FcSetName set);

            // FcBool: FcConfigAppFontAddFile FcConfig*:config  const FcChar8*:file
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigAppFontAddFile_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcConfigAppFontAddFile(IntPtr config, [MarshalAs(UnmanagedType.LPStr)]string file);

            // FcBool: FcConfigAppFontAddDir FcConfig*:config  const FcChar8*:dir
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigAppFontAddDir_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcConfigAppFontAddDir(IntPtr config, [MarshalAs(UnmanagedType.LPStr)]string dir);

            // void: FcConfigAppFontClear FcConfig*:config
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigAppFontClear_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcConfigAppFontClear(IntPtr config);

            // FcBool: FcConfigSubstituteWithPat FcConfig*:config  FcPattern*:p  FcPattern*:p_pat  FcMatchKind:kind
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigSubstituteWithPat_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcConfigSubstituteWithPat(IntPtr config, IntPtr p, IntPtr p_pat, FcMatchKind kind);

            // FcBool: FcConfigSubstitute FcConfig*:config  FcPattern*:p  FcMatchKind:kind
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigSubstitute_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcConfigSubstitute(IntPtr config, IntPtr p, FcMatchKind kind);

            // const FcChar8*: FcConfigGetSysRoot const FcConfig*:config
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigGetSysRoot_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcConfigGetSysRoot(IntPtr config);

            // void: FcConfigSetSysRoot FcConfig*:config  const FcChar8*:sysroot
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigSetSysRoot_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern void FcConfigSetSysRoot(IntPtr config, [MarshalAs(UnmanagedType.LPStr)]string sysroot);

            // FcBool: FcConfigParseAndLoad FcConfig*:config  const FcChar8*:file  FcBool:complain
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcConfigParseAndLoad_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcConfigParseAndLoad(IntPtr config, [MarshalAs(UnmanagedType.LPStr)]string file, bool complain);

        }
        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;
        bool disposable = true;

        public static FcConfig NullConfig { get; } = new FcConfig(IntPtr.Zero, false);

        public FcConfig() {
        }

        internal FcConfig(IntPtr ptr, bool boo) {
            handle = ptr;
            disposable = boo;
        }

        internal static FcConfig WR(IntPtr p, bool boo) {
            if (IntPtr.Zero == p) {
                return null;
            }
            return (new FcConfig(p, boo));
        }

        #region static
        public static string Home() => Marshal.PtrToStringAnsi(NativeMethods.FcConfigHome());

        public static bool EnableHome(bool enable) => NativeMethods.FcConfigEnableHome(enable);

        public static string Filename(string url) => Marshal.PtrToStringAnsi(NativeMethods.FcConfigFilename(url));

        public static FcConfig GetCurrent() =>
            WR(NativeMethods.FcConfigGetCurrent(), false);

        public static FcConfig Create() =>
            WR(NativeMethods.FcConfigCreate(), true);

        #endregion

        public FcConfig Reference() =>
            WR(NativeMethods.FcConfigReference(Handle), true);

        public void Destroy() {
            if (IntPtr.Zero != handle && disposable) {
                NativeMethods.FcConfigDestroy(Handle);
            }
            handle = IntPtr.Zero;
        }

        public bool ParseAndLoad(string file, bool complain) =>
            NativeMethods.FcConfigParseAndLoad(Handle, file, complain);


        public bool SetCurrent() =>
            NativeMethods.FcConfigSetCurrent(Handle);

        public bool UptoDate() =>
            NativeMethods.FcConfigUptoDate(Handle);

        public bool BuildFonts() =>
            NativeMethods.FcConfigBuildFonts(Handle);


        public FcStrList GetFontDirs() =>
            FcStrList.WR(NativeMethods.FcConfigGetFontDirs(Handle));


        public FcStrList GetConfigDirs()
            => FcStrList.WR(NativeMethods.FcConfigGetConfigDirs(Handle));


        public FcStrList GetConfigFiles()
            => FcStrList.WR(NativeMethods.FcConfigGetConfigFiles(Handle));


        public string GetCache()
            => Marshal.PtrToStringAnsi(NativeMethods.FcConfigGetCache(Handle));


        public FcBlanks GetBlanks()
            => (new FcBlanks(NativeMethods.FcConfigGetBlanks(Handle)));


        public FcStrList GetCacheDirs()
            => FcStrList.WR(NativeMethods.FcConfigGetCacheDirs(Handle));


        public int GetRescanInterval()
            => NativeMethods.FcConfigGetRescanInterval(Handle);


        public bool SetRescanInterval(int rescanInterval)
            => NativeMethods.FcConfigSetRescanInterval(Handle, rescanInterval);

        public FcFontSet GetFonts(FcSetName set)
            => new FcFontSet(NativeMethods.FcConfigGetFonts(Handle, set));


        public bool AppFontAddFile(string file)
            => NativeMethods.FcConfigAppFontAddFile(Handle, file);


        public bool AppFontAddDir(string dir)
            => NativeMethods.FcConfigAppFontAddDir(Handle, dir);


        public void AppFontClear()
            => NativeMethods.FcConfigAppFontClear(Handle);


        public bool SubstituteWithPat(FcPattern p, FcPattern p_pat, FcMatchKind kind)
            => NativeMethods.FcConfigSubstituteWithPat(Handle, p.Handle, p_pat.Handle, kind);

        public bool Substitute(FcPattern p, FcMatchKind kind)
            => NativeMethods.FcConfigSubstitute(Handle, p.Handle, kind);

        public static bool Substitute(FcConfig c, FcPattern p, FcMatchKind kind)
            => NativeMethods.FcConfigSubstitute((null!=c) ? c.handle : IntPtr.Zero, p.Handle, kind);

        public string GetSysRoot()
            => Marshal.PtrToStringAnsi(NativeMethods.FcConfigGetSysRoot(Handle));

        public void SetSysRoot(string sysroot)
            => NativeMethods.FcConfigSetSysRoot(Handle, sysroot);

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                this.Destroy();
            }
        }

        #if RLE
        ~FcConfig() {
            if (handle != IntPtr.Zero && disposable) {
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
