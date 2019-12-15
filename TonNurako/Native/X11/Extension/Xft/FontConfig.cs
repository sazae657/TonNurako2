using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft {
    public class FontConfig {
        internal static class NativeMethods {
            // FcBool: FcInit 
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcInit_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcInit();

            // void: FcFini 
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcFini_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcFini();


            // FcConfig*: FcInitLoadConfig 
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcInitLoadConfig_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcInitLoadConfig();

            // FcConfig*: FcInitLoadConfigAndFonts 
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcInitLoadConfigAndFonts_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcInitLoadConfigAndFonts();

            // int: FcGetVersion 
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcGetVersion_TNK", CharSet = CharSet.Auto)]
            internal static extern int FcGetVersion();

            // FcBool: FcInitReinitialize 
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcInitReinitialize_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcInitReinitialize();

            // FcBool: FcInitBringUptoDate 
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcInitBringUptoDate_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcInitBringUptoDate();

            // FcStrSet*: FcGetLangs 
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcGetLangs_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcGetLangs();

        }

        public static FcConfig LoadConfig() =>
            FcConfig.WR(NativeMethods.FcInitLoadConfig(), true);


        public static FcConfig LoadConfigAndFonts() =>
            FcConfig.WR(NativeMethods.FcInitLoadConfigAndFonts(), true);

        public static int GetVersion() 
            => NativeMethods.FcGetVersion();


        public static bool Reinitialize() 
            => NativeMethods.FcInitReinitialize();


        public static bool BringUptoDate()
            => NativeMethods.FcInitBringUptoDate();

        public static FcStrSet GetLangs() =>
            (FcStrSet.WR(NativeMethods.FcGetLangs()));


        public static bool Init() 
            => NativeMethods.FcInit();
        
        public static void Fini() 
            => NativeMethods.FcFini();

    }
}
