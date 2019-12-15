using System;
using System.Runtime.InteropServices;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft {
    public static class FcDefault {
        internal static class NativeMethods {
            // FcStrSet*: FcGetDefaultLangs 
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcGetDefaultLangs_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcGetDefaultLangs();

            // void: FcDefaultSubstitute FcPattern*:pattern  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcDefaultSubstitute_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcDefaultSubstitute(IntPtr pattern);
        }

        public static FcStrSet GetDefaultLangs() =>
            FcStrSet.WR(NativeMethods.FcGetDefaultLangs());


        public static void Substitute(FcPattern pattern) =>
            NativeMethods.FcDefaultSubstitute(pattern.Handle);


    }
}
