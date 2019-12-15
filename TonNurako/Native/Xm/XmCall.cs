//
// ﾄﾝﾇﾗｺ
//
// Motif
//
using System;
using System.Runtime.InteropServices;
using TonNurako.Native;

namespace TonNurako.Motif
{
    /// <summary>
    /// Motifﾛーﾀﾞー
    /// </summary>
    public class XmSports : Native.ExtremeSportsLoader {
        private static XmSports Instance;
        private Functions.XmCreateFunc[] xmCreateFuncs;

        public static void Register(string libXmName) {
            if (null != Instance) {
                return;
            }
            Instance = new XmSports(libXmName);
            Instance.FetchCreateFunction();
        }

        public static void Unregister() {
            if (null == Instance) {
                return;
            }
            System.Diagnostics.Debug.WriteLine("Xm: unregister");
            Instance.Dispose();
            Instance = null;
        }

        internal class Functions
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate System.IntPtr XmCreateFunc(IntPtr parent,string name, TonNurako.Xt.XtArgRec[] arg, int argc );
        }

        internal static class NativeMethods
        {

            [ DllImport(ExtremeSports.Lib, EntryPoint="XmGetPixmap_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern IntPtr XmGetPixmap(IntPtr screen,
                    [MarshalAs(UnmanagedType.LPStr)]string image_name,
                    ulong foreground, ulong background);

            [ DllImport(ExtremeSports.Lib, EntryPoint="XmDestroyPixmap_TNK", CharSet=CharSet.Auto) ]
            public static extern void XmDestroyPixmap(IntPtr screen, IntPtr pixmap);

            [ DllImport(ExtremeSports.Lib, EntryPoint="XmStringFree_TNK", CharSet=CharSet.Auto) ]
            public static extern void XmStringFree( IntPtr str );

            [ DllImport(ExtremeSports.Lib ,EntryPoint="XmStringCreateLocalized_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern IntPtr XmStringCreateLocalized( [MarshalAs(UnmanagedType.LPStr)] string str );

            [ DllImport(ExtremeSports.Lib, EntryPoint="XmStringUnparse_TNK" ,CharSet=CharSet.Auto) ]
            public static extern IntPtr XmStringUnparse(
                IntPtr str,
                int _RESERVED_ZERO,
                int tag_type,
                int output_type,
                IntPtr _RESERVED_NULL,
                int _RESERVED_ZERO2,
                int parse_model
                );

            [DllImport(ExtremeSports.Lib, EntryPoint="XmMenuPosition_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmMenuPosition(IntPtr menu, [In]TonNurako.X11.Event.XButtonEvent xevent);
            
            
            [ DllImport(ExtremeSports.Lib, EntryPoint="XmRedisplayWidget_TNK", CharSet=CharSet.Auto) ]
            public static extern void XmRedisplayWidget(IntPtr widget);            
        }

        public static IntPtr XmGetPixmap(IntPtr screen,
                string image_name,
                ulong foreground, ulong background)
        {
            return NativeMethods.XmGetPixmap(screen, image_name, foreground, background);
        }


        public static void XmDestroyPixmap(IntPtr screen, IntPtr pixmap) {
            NativeMethods.XmDestroyPixmap(screen, pixmap);
        }

        public static void XmStringFree( IntPtr str ) {
            NativeMethods.XmStringFree(str);
        }

        public static IntPtr XmStringCreateLocalized(string str) {
            return NativeMethods.XmStringCreateLocalized(str);
        }

        public static IntPtr XmStringUnparse(
            IntPtr str,
            int tag_type,
            int output_type,
            int parse_model
            ) {
                return NativeMethods.XmStringUnparse(str, 0, tag_type, output_type, IntPtr.Zero, 0, parse_model);
            }

        public static void XmMenuPosition(Widgets.IWidget menu, TonNurako.X11.Event.XButtonEvent xevent) {
            NativeMethods.XmMenuPosition(menu.Handle.Widget.Handle, xevent);
        }
        
        public static void XmRedisplayWidget(Widgets.IWidget widget) {
            NativeMethods.XmRedisplayWidget(widget.Handle.Widget.Handle);
        }        


        private XmSports(string lib) : base(lib) {
            xmCreateFuncs = new Functions.XmCreateFunc[Enum.GetValues(typeof(Motif.CreateSymbol)).Length];
        }

        /// <summary>
        /// XmCreateXXの呼び出し
        /// </summary>
        public static IntPtr CallCreate2P(TonNurako.Motif.CreateSymbol sym, Widgets.IWidget parent,string name, TonNurako.Xt.Arg[] args) {
            if (null ==args || 0 == args.Length) {
                return Instance.xmCreateFuncs[(int)sym](parent.Handle.Widget.Handle, name, null, 0);
            }

            TonNurako.Xt.XtArgRec[] au = new TonNurako.Xt.XtArgRec[args.Length];
            int argc = ExtremeSports.TnkConvertResourceEx(args, au, true);
            foreach(TonNurako.Xt.XtArgRec k in au) {
                System.Diagnostics.Debug.WriteLine($"NA<A>: {k.Name} : {k.Value}");
            }
            System.Diagnostics.Debug.WriteLine($"XM_CVT {au.Length} -> {argc}");
            IntPtr wgt = Instance.xmCreateFuncs[(int)sym](parent.Handle.Widget.Handle, name, au, argc);
            ExtremeSports.TnkFreeDeepCopyArg(au);

            return wgt;
        }


        /// <summary>
        /// ﾊﾝﾄﾞﾙ
        /// </summary>
        private void FetchCreateFunction() {
            foreach(var s in Enum.GetValues(typeof(Motif.CreateSymbol))) {
                try {
                    xmCreateFuncs[(int)s] = GetProcAddress<Functions.XmCreateFunc>($"{s.ToString()}_TNK");
                }
                catch(ExtremeSportsLoader.SymbolNotFoundException) {
                    // Widgetを使用不可にする
                    xmCreateFuncs[(int)s] = null;
                }
            }
        }



    }
}
