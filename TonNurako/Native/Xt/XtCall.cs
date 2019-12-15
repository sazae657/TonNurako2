//
// ﾄﾝﾇﾗｺ
//
// XToolkit
//
using System;
using System.Runtime.InteropServices;
using TonNurako.Native;
using TonNurako.X11;

namespace TonNurako.Xt {
    /// <summary>
    /// Xtﾛーﾀﾞー
    /// </summary>
    public class XtSports : Native.ExtremeSportsLoader {
        private static XtSports Instance {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="libXtName"></param>
        public static void Register(string libXtName) {
            if (null != Instance) {
                return;
            }
            Instance = new XtSports(libXtName);
        }

        public static void Unregister() {
            if (null == Instance) {
                return;
            }
            System.Diagnostics.Debug.WriteLine("Xt: unregister");
            Instance.Dispose();
            Instance = null;
        }

        private XtSports(string lib) : base(lib) {
        }


        internal static class NativeMethods
        {
            [DllImport(ExtremeSports.Lib, EntryPoint="XtFree_TNK", CharSet=CharSet.Auto) ]
            public static extern void XtFree( IntPtr str );

            [DllImport(ExtremeSports.Lib, EntryPoint="XtNameToWidget_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern IntPtr XtNameToWidget(IntPtr parent, [MarshalAs(UnmanagedType.LPStr)]string name);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtDestroyWidget_TNK", CharSet=CharSet.Auto) ]
            public static extern void  XtDestroyWidget(IntPtr wgt);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtUnmanageChild_TNK", CharSet=CharSet.Auto) ]
            public static extern void  XtUnmanageChild(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtManageChild_TNK", CharSet=CharSet.Auto) ]
            public static extern void  XtManageChild(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtUnmapWidget_TNK", CharSet=CharSet.Auto) ]
            public static extern void  XtUnmapWidget(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtRealizeWidget_TNK", CharSet=CharSet.Auto) ]
            public static extern void  XtRealizeWidget(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtMapWidget_TNK", CharSet=CharSet.Auto) ]
            public static extern void  XtMapWidget(IntPtr wgt);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtIsManaged_TNK", CharSet=CharSet.Auto) ]
            public static extern IntPtr XtIsManaged(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtDisplay_TNK", CharSet=CharSet.Auto) ]
            public static extern IntPtr XtDisplay(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtScreen_TNK", CharSet=CharSet.Auto) ]
            public static extern IntPtr XtScreen(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtWindow_TNK", CharSet=CharSet.Auto) ]
            public static extern IntPtr XtWindow(IntPtr wgt);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtName_TNK", CharSet=CharSet.Auto)]
            public static extern IntPtr XtName(IntPtr wgt);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtRemoveCallback_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern void XtRemoveCallback(IntPtr w,
                [MarshalAs(UnmanagedType.LPStr)]string type, XtCallbackProc call ,IntPtr client);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtAddCallback_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true) ]
            public static extern void XtAddCallback(IntPtr w,
                [MarshalAs(UnmanagedType.LPStr)]string type, XtCallbackProc call ,IntPtr client);


            [DllImport(ExtremeSports.Lib, EntryPoint="XtLastTimestampProcessed_TNK", CharSet=CharSet.Auto)]
            public static extern uint XtLastTimestampProcessed(IntPtr display);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtParseTranslationTable_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern IntPtr XtParseTranslationTable([MarshalAs(UnmanagedType.LPStr)] string table);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtAugmentTranslations_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtAugmentTranslations(IntPtr w, IntPtr translations);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtOverrideTranslations_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtOverrideTranslations(IntPtr w, IntPtr translations);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtUninstallTranslations_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtUninstallTranslations(IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtParseAcceleratorTable_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern IntPtr XtParseAcceleratorTable([MarshalAs(UnmanagedType.LPStr)] string source);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtInstallAccelerators_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtInstallAccelerators(IntPtr destination, IntPtr source);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtInstallAllAccelerators_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtInstallAllAccelerators(IntPtr destination, IntPtr source);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtAddEventHandler_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtAddEventHandler(IntPtr w, ulong event_mask,
                    [MarshalAs(UnmanagedType.U1)] bool nonmaskable, TonNurako.Xt.XtEventHandler proc, IntPtr client_data);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtRemoveEventHandler_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtRemoveEventHandler(IntPtr w, ulong event_mask,
                    [MarshalAs(UnmanagedType.U1)] bool nonmaskable, TonNurako.Xt.XtEventHandler proc, IntPtr client_data);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtInitializeWidgetClass_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtInitializeWidgetClass(IntPtr glass);

            [DllImport(ExtremeSports.Lib, EntryPoint="TNK_GetWidgetClass", CharSet=CharSet.Auto)]
            internal static extern IntPtr TNK_GetWidgetClass(Motif.MotifWidgetClass glass);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XtGetGC_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XtGetGC(IntPtr w, X11.GCMask value_mask, [In, Out]ref X11.XGCValuesRec values);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtGetGC_TNK", CharSet=CharSet.Auto)]
            internal static extern IntPtr XtGetGC(IntPtr w, X11.GCMask value_mask, IntPtr values);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtReleaseGC_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtReleaseGC(IntPtr w, [In]IntPtr gc);

            // void: XtCreateWindow Widget:widget int:window_class Visual*:visual XtValueMask:value_mask XSetWindowAttributes*:attributes
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtCreateWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtCreateWindow(IntPtr widget, WindowClass window_class, IntPtr visual, ChangeWindowAttributes value_mask, ref XSetWindowAttributesRec attributes);


            // Boolean: XtIsRealized Widget:w  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtIsRealized_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XtIsRealized(IntPtr w);

            // void: XtUnrealizeWidget Widget:w  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtUnrealizeWidget_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtUnrealizeWidget(IntPtr w);

            // Widget: XtParent Widget:w  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtParent_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XtParent(IntPtr w);
        }

        public static void XtFree(IntPtr str) {
            NativeMethods.XtFree(str);
        }

        public static Widgets.IWidget XtNameToWidget(Widgets.IWidget parent, string name)
        {
            var handle = NativeMethods.XtNameToWidget(parent.Handle.Widget.Handle, name);
            if (IntPtr.Zero == handle) {
                return null;
            }
            var widget = parent.AppContext.FindWidgetByHandle(handle);
            if (null != widget) {
                return widget;
            }
            return (new Widgets.ﾄﾝﾇﾗｼﾞｪｯﾄ(handle, parent));
        }

        public static void  XtDestroyWidget(Widgets.IWidget wgt) {
            NativeMethods.XtDestroyWidget(wgt.Handle.Widget.Handle);
        }
        public static  void  XtUnmanageChild(Widgets.IWidget wgt) {
            NativeMethods.XtUnmanageChild(wgt.Handle.Widget.Handle);
        }
        public static  void  XtManageChild(Widgets.IWidget wgt) {
            NativeMethods.XtManageChild(wgt.Handle.Widget.Handle);
        }

        public static  void  XtUnmapWidget(Widgets.IWidget wgt) {
            NativeMethods.XtUnmapWidget(wgt.Handle.Widget.Handle);
        }

        public static  void  XtRealizeWidget(Widgets.IWidget wgt) {
            NativeMethods.XtRealizeWidget(wgt.Handle.Widget.Handle);
        }

        public static bool XtIsRealized(Widgets.IWidget w) {
            return NativeMethods.XtIsRealized(w.Handle.Widget.Handle);
        }

        public static void XtUnrealizeWidget(Widgets.IWidget w) {
            NativeMethods.XtUnrealizeWidget(w.Handle.Widget.Handle);
        }

        public static  bool  XtIsManaged(Widgets.IWidget wgt) {
            return (NativeMethods.XtIsManaged(wgt.Handle.Widget.Handle).ToInt32() == 0) ? false : true;
        }

        public static  void  XtMapWidget(Widgets.IWidget wgt) {
            NativeMethods.XtMapWidget(wgt.Handle.Widget.Handle);
        }

        public static  IntPtr  XtScreen(Widgets.IWidget wgt) {
            return NativeMethods.XtScreen(wgt.Handle.Widget.Handle);
        }
        public static  IntPtr  XtScreen(IntPtr wgt) {
            return NativeMethods.XtScreen(wgt);
        }

        public static  IntPtr  XtDisplay(Widgets.IWidget wgt) {
            return NativeMethods.XtDisplay(wgt.Handle.Widget.Handle);
        }

        public static  IntPtr  XtDisplay(IntPtr wgt) {
            return NativeMethods.XtDisplay(wgt);
        }

        public static  IntPtr  XtWindow(Widgets.IWidget wgt) {
            return NativeMethods.XtWindow(wgt.Handle.Widget.Handle);
        }
        public static  IntPtr  XtWindow(IntPtr wgt) {
            return NativeMethods.XtWindow(wgt);
        }

        public static string XtName(IntPtr wgt) {
            IntPtr ip = NativeMethods.XtName(wgt);
            if (IntPtr.Zero != ip) {
                return Marshal.PtrToStringAnsi(ip);
            }
            return null;
        }

        public static  void  XtRemoveCallback(Widgets.IWidget wgt, string type, XtCallbackProc call) {
            NativeMethods.XtRemoveCallback(wgt.Handle.Widget.Handle, type, call, IntPtr.Zero);
        }

        public static  void  XtAddCallback(Widgets.IWidget wgt, string type, XtCallbackProc call ) {
            NativeMethods.XtAddCallback(wgt.Handle.Widget.Handle, type, call, IntPtr.Zero);
        }
        public static uint XtLastTimestampProcessed(IntPtr display) {
            return NativeMethods.XtLastTimestampProcessed(display);
        }


        public static IntPtr XtParseTranslationTable(string table) {
            return NativeMethods.XtParseTranslationTable(table);
        }


        public static void XtAugmentTranslations(Widgets.IWidget wgt, IntPtr translations) {
            NativeMethods.XtAugmentTranslations(wgt.Handle.Widget.Handle,translations);
        }


        public static void XtOverrideTranslations(Widgets.IWidget wgt, IntPtr translations) {
            NativeMethods.XtOverrideTranslations(wgt.Handle.Widget.Handle,translations);
        }


        public static void XtUninstallTranslations(Widgets.IWidget wgt) {
            NativeMethods.XtUninstallTranslations(wgt.Handle.Widget.Handle);
        }


        public static IntPtr XtParseAcceleratorTable(string source) {
            return NativeMethods.XtParseAcceleratorTable(source);
        }


        public static void XtInstallAccelerators(Widgets.IWidget destination, Widgets.IWidget source) {
            NativeMethods.XtInstallAccelerators(destination.Handle.Widget.Handle, source.Handle.Widget.Handle);
        }


        public static void XtInstallAllAccelerators(Widgets.IWidget destination, Widgets.IWidget source) {
            NativeMethods.XtInstallAllAccelerators(destination.Handle.Widget.Handle, source.Handle.Widget.Handle);
        }

        public static void XtAddEventHandler(Widgets.IWidget w, ulong event_mask, bool nonmaskable,
                     TonNurako.Xt.XtEventHandler proc, IntPtr client_data) {
            NativeMethods.XtAddEventHandler(w.Handle.Widget.Handle, event_mask,nonmaskable,proc,client_data);
        }


        public static void XtRemoveEventHandler(Widgets.IWidget w, ulong event_mask, bool nonmaskable,
            TonNurako.Xt.XtEventHandler proc, IntPtr client_data) {
            NativeMethods.XtRemoveEventHandler(w.Handle.Widget.Handle,event_mask,nonmaskable,proc,client_data);
        }

        public static TonNurako.X11.GC XtGetGC(Widgets.IWidget w, X11.GCMask value_mask, X11.XGCValues values) {
            //var v = new X11.XGCValuesRec();
            var r = NativeMethods.XtGetGC(w.Handle.Widget.Handle, value_mask, ref values.Record);
            var rgc = new TonNurako.X11.GC(r, w.Handle.Display, w.Handle, true);
            rgc.DispseGCDelegate = (c) => NativeMethods.XtReleaseGC(w.Handle.Widget.Handle, c.Handle);
            return rgc;
        }


        public static IntPtr XtGetGC(Widgets.IWidget w) {
            return NativeMethods.XtGetGC(w.Handle.Widget.Handle, 0, IntPtr.Zero);
        }

        internal static void XtReleaseGC(Widgets.IWidget w, IntPtr gc) {
            NativeMethods.XtReleaseGC(w.Handle.Widget.Handle, gc);
        }

        public static void XtCreateWindow(Widgets.IWidget widget, WindowClass window_class, Visual visual, ChangeWindowAttributes value_mask, XSetWindowAttributes attributes) {
            NativeMethods.XtCreateWindow(widget.Handle.Widget.Handle, window_class, visual.Handle, value_mask, ref attributes.record);
        }

        public static Widgets.IWidget XtParent(Widgets.IWidget w) {
            var r = NativeMethods.XtParent(w.Handle.Widget.Handle);
            if (IntPtr.Zero == r) {
                return null;
            }
            return new TonNurako.Widgets.ﾄﾝﾇﾗｼﾞｪｯﾄ(r, null);
        }


        // 一時的
        public static void XtInitializeWidgetClass(TonNurako.Motif.MotifWidgetClass glass) {
            var ptr = NativeMethods.TNK_GetWidgetClass(glass);
            if (IntPtr.Zero == ptr) {
                throw new Exception($"NullWidget {glass.ToString()}");
            }
            NativeMethods.XtInitializeWidgetClass(ptr);

        }
    }
}
