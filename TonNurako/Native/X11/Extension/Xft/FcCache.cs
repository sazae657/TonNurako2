using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft {
    public class FcCache : IX11Interop {
        internal static class NativeMethods {
            // const FcChar8*: FcCacheDir const FcCache*:c  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCacheDir_TNK", CharSet = CharSet.Auto)]
            internal static extern string FcCacheDir(IntPtr c);

            // FcFontSet*: FcCacheCopySet const FcCache*:c  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCacheCopySet_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcCacheCopySet(IntPtr c);

            // const FcChar8*: FcCacheSubdir const FcCache*:c  int:i  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCacheSubdir_TNK", CharSet = CharSet.Auto)]
            internal static extern string FcCacheSubdir(IntPtr c, int i);

            // int: FcCacheNumSubdir const FcCache*:c  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCacheNumSubdir_TNK", CharSet = CharSet.Auto)]
            internal static extern int FcCacheNumSubdir(IntPtr c);

            // int: FcCacheNumFont const FcCache*:c  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCacheNumFont_TNK", CharSet = CharSet.Auto)]
            internal static extern int FcCacheNumFont(IntPtr c);

            // void: FcCacheCreateTagFile const FcConfig*:config  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcCacheCreateTagFile_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcCacheCreateTagFile(IntPtr config);
        }

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        public FcCache() {
        }

        internal FcCache(IntPtr ptr) {
            handle = ptr;
        }

        public string Dir() {
            return NativeMethods.FcCacheDir(Handle);
        }

        public FcFontSet CopySet() =>
            new FcFontSet(NativeMethods.FcCacheCopySet(Handle));

        public string Subdir(int i) {
            return NativeMethods.FcCacheSubdir(Handle, i);
        }

        public int NumSubdir() {
            return NativeMethods.FcCacheNumSubdir(Handle);
        }

        public int NumFont() {
            return NativeMethods.FcCacheNumFont(Handle);
        }

        public static void CreateTagFile(FcConfig config) {
            NativeMethods.FcCacheCreateTagFile(config.Handle);
        }
    }

    public class FcDirCache  {
        internal static class NativeMethods {
            // FcBool: FcDirCacheUnlink const FcChar8*:dir  FcConfig*:config  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcDirCacheUnlink_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcDirCacheUnlink([MarshalAs(UnmanagedType.LPStr)]string dir, IntPtr config);

            // FcBool: FcDirCacheValid const FcChar8*:cache_file  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcDirCacheValid_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcDirCacheValid([MarshalAs(UnmanagedType.LPStr)]string cache_file);

            // FcBool: FcDirCacheClean const FcChar8*:cache_dir  FcBool:verbose  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcDirCacheClean_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool FcDirCacheClean([MarshalAs(UnmanagedType.LPStr)]string cache_dir, bool verbose);
        }

        public static bool Unlink(string dir, FcConfig config)
            => NativeMethods.FcDirCacheUnlink(dir, config.Handle);
        
        public static bool Valid(string cache_file)
            => NativeMethods.FcDirCacheValid(cache_file);

        public static bool Clean(string cache_dir, bool verbose)
            => NativeMethods.FcDirCacheClean(cache_dir, verbose);
    }
}
