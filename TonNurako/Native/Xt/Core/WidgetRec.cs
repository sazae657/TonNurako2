using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.Widgets;

namespace TonNurako.Xt.Core {
/*
    [StructLayout(LayoutKind.Sequential)]
    internal struct CorePart {
        public IntPtr self;    // Widget
        public IntPtr widget_class;    // WidgetClass
        public IntPtr parent;    // Widget
        public int xrm_name;    // XrmName
        [MarshalAs(UnmanagedType.U1)] public bool being_destroyed;    // Boolean
        public IntPtr destroy_callbacks;    // XtCallbackList
        public IntPtr constraints;    // XtPointer
        public Int16 x;    // Position
        public Int16 y;    // Position
        public int width;    // Dimension
        public int height;    // Dimension
        public int border_width;    // Dimension
        [MarshalAs(UnmanagedType.U1)] public bool managed;    // Boolean
        [MarshalAs(UnmanagedType.U1)] public bool sensitive;    // Boolean
        [MarshalAs(UnmanagedType.U1)] public bool ancestor_sensitive;    // Boolean
        public IntPtr event_table;    // XtEventTable
        public XtTMRec tm;    // XtTMRec
        public IntPtr accelerators;    // XtTranslations
        public ulong border_pixel;    // Pixel
        public IntPtr border_pixmap;    // Pixmap
        public IntPtr popup_list;    // WidgetList
        public int num_popups;    // Cardinal
        public IntPtr name;    // String
        public IntPtr screen;    // Screen*
        public ulong colormap;    // Colormap
        public ulong window;    // Window
        public int depth;    // Cardinal
        public ulong background_pixel;    // Pixel
        public IntPtr background_pixmap;    // Pixmap
        [MarshalAs(UnmanagedType.U1)] public bool visible;    // Boolean
        [MarshalAs(UnmanagedType.U1)] public bool mapped_when_managed;    // Boolean
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct _WidgetRec {
        public CorePart core;
    }
    */

    public class WidgetRecAccessor {
        internal IntPtr Pounter;
        internal WidgetRecAccessor(IntPtr ptr) {
            Pounter = ptr;
        }

        #region NativeMethods;
        internal static class NativeMethods {
            // Widget
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecSelf", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetWidgetRecSelf(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecSelf", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecSelf(IntPtr ptr, IntPtr omg);

            // WidgetClass
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecWidgetClass", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetWidgetRecWidgetClass(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecWidgetClass", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecWidgetClass(IntPtr ptr, IntPtr omg);

            // Widget
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecParent", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetWidgetRecParent(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecParent", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecParent(IntPtr ptr, IntPtr omg);

            // XrmName
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecXrmName", CharSet = CharSet.Auto)]
            internal static extern int TNK_GetWidgetRecXrmName(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecXrmName", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecXrmName(IntPtr ptr, int omg);

            // Boolean
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecBeingDestroyed", CharSet = CharSet.Auto)]
            internal static extern bool TNK_GetWidgetRecBeingDestroyed(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecBeingDestroyed", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecBeingDestroyed(IntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool omg);

            // XtCallbackList
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecDestroyCallbacks", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetWidgetRecDestroyCallbacks(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecDestroyCallbacks", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecDestroyCallbacks(IntPtr ptr, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] omg);

            // XtPointer
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecConstraints", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetWidgetRecConstraints(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecConstraints", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecConstraints(IntPtr ptr, IntPtr omg);

            // Position
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecX", CharSet = CharSet.Auto)]
            internal static extern Int16 TNK_GetWidgetRecX(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecX", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecX(IntPtr ptr, Int16 omg);

            // Position
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecY", CharSet = CharSet.Auto)]
            internal static extern Int16 TNK_GetWidgetRecY(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecY", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecY(IntPtr ptr, Int16 omg);

            // Dimension
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecWidth", CharSet = CharSet.Auto)]
            internal static extern int TNK_GetWidgetRecWidth(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecWidth", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecWidth(IntPtr ptr, int omg);

            // Dimension
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecHeight", CharSet = CharSet.Auto)]
            internal static extern int TNK_GetWidgetRecHeight(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecHeight", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecHeight(IntPtr ptr, int omg);

            // Dimension
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecBorderWidth", CharSet = CharSet.Auto)]
            internal static extern int TNK_GetWidgetRecBorderWidth(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecBorderWidth", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecBorderWidth(IntPtr ptr, int omg);

            // Boolean
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecManaged", CharSet = CharSet.Auto)]
            internal static extern bool TNK_GetWidgetRecManaged(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecManaged", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecManaged(IntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool omg);

            // Boolean
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecSensitive", CharSet = CharSet.Auto)]
            internal static extern bool TNK_GetWidgetRecSensitive(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecSensitive", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecSensitive(IntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool omg);

            // Boolean
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecAncestorSensitive", CharSet = CharSet.Auto)]
            internal static extern bool TNK_GetWidgetRecAncestorSensitive(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecAncestorSensitive", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecAncestorSensitive(IntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool omg);

            // XtEventTable
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecEventTable", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetWidgetRecEventTable(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecEventTable", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecEventTable(IntPtr ptr, ref XtEventRec omg);

            // XtTMRec
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecTm", CharSet = CharSet.Auto)]
            internal static extern XtTMRec TNK_GetWidgetRecTm(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecTm", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecTm(IntPtr ptr, ref XtTMRec omg);

            // XtTranslations
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecAccelerators", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetWidgetRecAccelerators(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecAccelerators", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecAccelerators(IntPtr ptr, IntPtr omg);

            // Pixel
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecBorderPixel", CharSet = CharSet.Auto)]
            internal static extern ulong TNK_GetWidgetRecBorderPixel(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecBorderPixel", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecBorderPixel(IntPtr ptr, ulong omg);

            // Pixmap
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecBorderPixmap", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetWidgetRecBorderPixmap(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecBorderPixmap", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecBorderPixmap(IntPtr ptr, IntPtr omg);

            // WidgetList
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecPopupList", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetWidgetRecPopupList(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecPopupList", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecPopupList(IntPtr ptr, IntPtr omg);

            // Cardinal
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecNumPopups", CharSet = CharSet.Auto)]
            internal static extern int TNK_GetWidgetRecNumPopups(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecNumPopups", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecNumPopups(IntPtr ptr, int omg);

            // String
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecName", CharSet = CharSet.Auto)]
            internal static extern string TNK_GetWidgetRecName(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecName", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern void TNK_SetWidgetRecName(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] string omg);

            // Screen*
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecScreen", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetWidgetRecScreen(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecScreen", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecScreen(IntPtr ptr, IntPtr omg);

            // Colormap
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecColormap", CharSet = CharSet.Auto)]
            internal static extern int TNK_GetWidgetRecColormap(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecColormap", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecColormap(IntPtr ptr, int omg);

            // Window
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecWindow", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetWidgetRecWindow(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecWindow", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecWindow(IntPtr ptr, IntPtr omg);

            // Cardinal
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecDepth", CharSet = CharSet.Auto)]
            internal static extern int TNK_GetWidgetRecDepth(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecDepth", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecDepth(IntPtr ptr, int omg);

            // Pixel
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecBackgroundPixel", CharSet = CharSet.Auto)]
            internal static extern ulong TNK_GetWidgetRecBackgroundPixel(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecBackgroundPixel", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecBackgroundPixel(IntPtr ptr, ulong omg);

            // Pixmap
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecBackgroundPixmap", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetWidgetRecBackgroundPixmap(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecBackgroundPixmap", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecBackgroundPixmap(IntPtr ptr, IntPtr omg);

            // Boolean
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecVisible", CharSet = CharSet.Auto)]
            internal static extern bool TNK_GetWidgetRecVisible(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecVisible", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecVisible(IntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool omg);

            // Boolean
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetWidgetRecMappedWhenManaged", CharSet = CharSet.Auto)]
            internal static extern bool TNK_GetWidgetRecMappedWhenManaged(IntPtr ptr);
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetWidgetRecMappedWhenManaged", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetWidgetRecMappedWhenManaged(IntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool omg);

        }
        #endregion

        ﾄﾝﾇﾗｼﾞｪｯﾄ self = null;
        public IWidget Self {
            get {
                if (null == self) {
                    self = new ﾄﾝﾇﾗｼﾞｪｯﾄ(NativeMethods.TNK_GetWidgetRecSelf(this.Pounter), null);
                }
                return self;
            }
            //set => NativeMethods.TNK_SetWidgetRecSelf(this.Pounter, value);
        }

        internal IntPtr WidgetClass {
            get => NativeMethods.TNK_GetWidgetRecWidgetClass(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecWidgetClass(this.Pounter, value);
        }

        ﾄﾝﾇﾗｼﾞｪｯﾄ parent = null;
        public IWidget Parent {
            get {
                if (null == parent) {
                    parent = new ﾄﾝﾇﾗｼﾞｪｯﾄ(NativeMethods.TNK_GetWidgetRecParent(this.Pounter), null);
                }
                return parent;
            }
            //set => NativeMethods.TNK_SetWidgetRecParent(this.Pounter, value);
        }

        public int XrmName {
            get => NativeMethods.TNK_GetWidgetRecXrmName(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecXrmName(this.Pounter, value);
        }

        public bool BeingDestroyed {
            get => NativeMethods.TNK_GetWidgetRecBeingDestroyed(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecBeingDestroyed(this.Pounter, value);
        }

        internal IntPtr DestroyCallbacks {
            get => NativeMethods.TNK_GetWidgetRecDestroyCallbacks(this.Pounter);
            //set => NativeMethods.TNK_SetWidgetRecDestroyCallbacks(this.Pounter, value);
        }

        internal IntPtr Constraints {
            get => NativeMethods.TNK_GetWidgetRecConstraints(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecConstraints(this.Pounter, value);
        }

        public short X {
            get => NativeMethods.TNK_GetWidgetRecX(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecX(this.Pounter, value);
        }

        public short Y {
            get => NativeMethods.TNK_GetWidgetRecY(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecY(this.Pounter, value);
        }

        public int Width {
            get => NativeMethods.TNK_GetWidgetRecWidth(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecWidth(this.Pounter, value);
        }

        public int Height {
            get => NativeMethods.TNK_GetWidgetRecHeight(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecHeight(this.Pounter, value);
        }

        public int BorderWidth {
            get => NativeMethods.TNK_GetWidgetRecBorderWidth(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecBorderWidth(this.Pounter, value);
        }

        public bool Managed {
            get => NativeMethods.TNK_GetWidgetRecManaged(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecManaged(this.Pounter, value);
        }

        public bool Sensitive {
            get => NativeMethods.TNK_GetWidgetRecSensitive(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecSensitive(this.Pounter, value);
        }

        public bool AncestorSensitive {
            get => NativeMethods.TNK_GetWidgetRecAncestorSensitive(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecAncestorSensitive(this.Pounter, value);
        }

        internal IntPtr EventTable {
            get => NativeMethods.TNK_GetWidgetRecEventTable(this.Pounter);
            //set => NativeMethods.TNK_SetWidgetRecEventTable(this.Pounter, value);
        }

        internal XtTMRec Tm {
            get => NativeMethods.TNK_GetWidgetRecTm(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecTm(this.Pounter, ref value);
        }

        internal IntPtr Accelerators {
            get => NativeMethods.TNK_GetWidgetRecAccelerators(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecAccelerators(this.Pounter, value);
        }



        TonNurako.X11.Color borderPixel = null;
        public TonNurako.X11.Color BorderPixel {
            get {
                if (null == borderPixel) {
                    borderPixel = new X11.Color(() => NativeMethods.TNK_GetWidgetRecBorderPixel(this.Pounter));
                }
                return borderPixel;
            }
            set => NativeMethods.TNK_SetWidgetRecBorderPixel(this.Pounter, value.Pixel);
        }


        TonNurako.X11.Pixmap borderPixmap = null;
        public TonNurako.X11.Pixmap BorderPixmap {
            get {
                if (null == borderPixmap) {
                    borderPixmap = new X11.Pixmap(IntPtr.Zero, () => { });
                }
                borderPixmap.AssignPixmap(NativeMethods.TNK_GetWidgetRecBorderPixmap(this.Pounter));
                return borderPixmap;
            }
            set => NativeMethods.TNK_SetWidgetRecBorderPixmap(this.Pounter, value.Handle);
        }

        internal IntPtr PopupList {
            get => NativeMethods.TNK_GetWidgetRecPopupList(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecPopupList(this.Pounter, value);
        }

        public int NumPopups {
            get => NativeMethods.TNK_GetWidgetRecNumPopups(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecNumPopups(this.Pounter, value);
        }

        public string Name {
            get => NativeMethods.TNK_GetWidgetRecName(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecName(this.Pounter, value);
        }

        TonNurako.X11.Screen screen = null;
        public TonNurako.X11.Screen Screen {
            get {
                if (null == screen) {
                    screen = new X11.Screen(() => NativeMethods.TNK_GetWidgetRecScreen(this.Pounter));
                }
                return screen;
            }
            //set => NativeMethods.TNK_SetWidgetRecScreen(this.Pounter, value);
        }

        TonNurako.X11.Colormap colormap = null;
        public TonNurako.X11.Colormap Colormap {
            get {
                if (null == colormap) {
                    colormap = new X11.Colormap(() => NativeMethods.TNK_GetWidgetRecColormap(this.Pounter), null);
                }
                return colormap;
            }
            set => NativeMethods.TNK_SetWidgetRecColormap(this.Pounter, value.Handle);
        }

        TonNurako.X11.Window window;
        public TonNurako.X11.Window Window {
            get {
                if (null == window) {
                    window = new X11.Window(() =>
                        NativeMethods.TNK_GetWidgetRecWindow(this.Pounter), Self.Handle.Display);
                }
                return window;
            }
            //set => NativeMethods.TNK_SetWidgetRecWindow(this.Pounter, value);
        }

        public int Depth {
            get => NativeMethods.TNK_GetWidgetRecDepth(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecDepth(this.Pounter, value);
        }

        TonNurako.X11.Color backgroundPixel = null;
        public TonNurako.X11.Color BackgroundPixel {
            get {
                if (null == backgroundPixel) {
                    backgroundPixel = new X11.Color(() => NativeMethods.TNK_GetWidgetRecBackgroundPixel(this.Pounter));
                }
                return backgroundPixel;
            }
            set => NativeMethods.TNK_SetWidgetRecBackgroundPixel(this.Pounter, value.Pixel);
        }

        TonNurako.X11.Pixmap backgroundPixmap = null;
        public TonNurako.X11.Pixmap BackgroundPixmap {
            get {
                if (null == backgroundPixmap) {
                    backgroundPixmap = new X11.Pixmap(IntPtr.Zero, () => { });
                }
                backgroundPixmap.AssignPixmap(
                    NativeMethods.TNK_GetWidgetRecBackgroundPixmap(this.Pounter));
                return backgroundPixmap;
            }
            set => NativeMethods.TNK_SetWidgetRecBackgroundPixmap(this.Pounter, value.Handle);
        }

        public bool Visible {
            get => NativeMethods.TNK_GetWidgetRecVisible(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecVisible(this.Pounter, value);
        }

        public bool MappedWhenManaged {
            get => NativeMethods.TNK_GetWidgetRecMappedWhenManaged(this.Pounter);
            set => NativeMethods.TNK_SetWidgetRecMappedWhenManaged(this.Pounter, value);
        }
    }
}
