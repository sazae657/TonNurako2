using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.X11;


namespace TonNurako.X11.Extension.Xft {
    public class Xft {
        internal static class NativeMethods {
            // FcBool: XftInit _Xconst char*:config  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftInit_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool XftInit([MarshalAs(UnmanagedType.LPStr)] string config);

            // int: XftGetVersion 
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftGetVersion_TNK", CharSet = CharSet.Auto)]
            internal static extern int XftGetVersion();

            // Bool: XftDefaultHasRender Display*:dpy  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDefaultHasRender_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XftDefaultHasRender(IntPtr dpy);

            // Bool: XftDefaultSet Display*:dpy  FcPattern*:defaults  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDefaultSet_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XftDefaultSet(IntPtr dpy, IntPtr defaults);

            // void: XftDefaultSubstitute Display*:dpy  int:screen  FcPattern*:pattern  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftDefaultSubstitute_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftDefaultSubstitute(IntPtr dpy, int screen, IntPtr pattern);

        }

        public static bool Init(string config) => NativeMethods.XftInit(config);

        public static int GetVersion() => NativeMethods.XftGetVersion();

        public static bool HasRender(Display dpy) =>
            NativeMethods.XftDefaultHasRender(dpy.Handle);


        public static bool Set(Display dpy, FcPattern defaults) =>
            NativeMethods.XftDefaultSet(dpy.Handle, defaults.Handle);


        public static void Substitute(Display dpy, int screen, FcPattern pattern) =>
            NativeMethods.XftDefaultSubstitute(dpy.Handle, screen, pattern.Handle);


    }
}
