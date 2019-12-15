using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.X11.Event;

namespace TonNurako.X11 {

    internal struct XQueryPointerRec  {
        public IntPtr Root;
        public IntPtr Child;
        public int RootX;
        public int RootY;
        public int WinX;
        public int WinY;
        public ModifierMask Mask;
    }

    public class XPointerInfo {
        internal XQueryPointerRec Record;

        public XPointerInfo() {
            Record = new XQueryPointerRec();
        }

        internal Display Display { get; set; }

        public Window Root {
            get => new Window(Record.Root, Display);
            set => Record.Root = value.Handle;
        }
        public Window Child {
            get => new Window(Record.Child, Display);
            set => Record.Child = value.Handle;
        }
        public int RootX {
            get => Record.RootX;
            set => Record.RootX = value;
        }
        public int RootY {
            get => Record.RootY;
            set => Record.RootY = value;
        }
        public int WinX {
            get => Record.WinX;
            set => Record.WinX = value;
        }
        public int WinY {
            get => Record.WinY;
            set => Record.WinY = value;
        }
        public ModifierMask Mask {
            get => Record.Mask;
            set => Record.Mask = value;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion
    }




    public class Window : IX11Interop, IDrawable {
        ReturnPointerDelegaty delegaty;
        IntPtr window;
        Display display;

        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "DefaultRootWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr DefaultRootWindow(IntPtr dpy);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSelectInput_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XSelectInput(IntPtr display, IntPtr w, ulong event_mask);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XMapWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XMapWindow(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XMapRaised_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XMapRaised(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XMapSubwindows_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XMapSubwindows(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XUnmapWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XUnmapWindow(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XUnmapSubwindows_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XUnmapSubwindows(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XRaiseWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XRaiseWindow(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XLowerWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern int XLowerWindow(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWMProtocols_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XSetWMProtocols(IntPtr display, IntPtr w, IntPtr protocols, int count);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetWMProtocols_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XGetWMProtocols(IntPtr display, IntPtr w, out IntPtr protocols_return, out int count_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDestroyWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern int XDestroyWindow(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDestroySubwindows_TNK", CharSet = CharSet.Auto)]
            internal static extern int XDestroySubwindows(IntPtr display, IntPtr w);


            [DllImport(ExtremeSports.Lib, EntryPoint = "XChangeWindowAttributes_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XChangeWindowAttributes(IntPtr display, IntPtr w, ulong valuemask, ref XSetWindowAttributesRec attributes);


            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWindowBackground_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XSetWindowBackground(IntPtr display, IntPtr w, ulong background_pixel);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWindowBorder_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XSetWindowBorder(IntPtr display, IntPtr w, ulong border_pixel);

            // int: XSetWindowBackgroundPixmap [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Pixmap', 'name': 'background_pixmap'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWindowBackgroundPixmap_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XSetWindowBackgroundPixmap(IntPtr display, IntPtr w, IntPtr background_pixmap);


            // int: XSetWindowBorderPixmap [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Pixmap', 'name': 'border_pixmap'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWindowBorderPixmap_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XSetWindowBorderPixmap(IntPtr display, IntPtr w, IntPtr border_pixmap);

            // int: XSetWindowColormap [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Colormap', 'name': 'colormap'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWindowColormap_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XSetWindowColormap(IntPtr display, IntPtr w, IntPtr colormap);


            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetWindowAttributes_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XGetWindowAttributes(IntPtr display, IntPtr w, out XWindowAttributesRec window_attributes_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetGeometry_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XGetGeometry(IntPtr display, IntPtr d,
                out IntPtr root_return, out int x_return, out int y_return, out int width_return, out int height_return, out int border_width_return, out int depth_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetClassHint_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XSetClassHint(IntPtr display, IntPtr w, ref XClassHint class_hints);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetClassHint_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XGetClassHint(IntPtr display, IntPtr w, out XClassHintRec class_hints_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XMoveWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XMoveWindow(IntPtr display, IntPtr w, int x, int y);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XResizeWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XResizeWindow(IntPtr display, IntPtr w, uint width, uint height);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XMoveResizeWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XMoveResizeWindow(IntPtr display, IntPtr w, int x, int y, uint width, uint height);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWindowBorderWidth_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XSetWindowBorderWidth(IntPtr display, IntPtr w, uint width);

            // int: XCirculateSubwindows [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'int', 'name': 'direction'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCirculateSubwindows_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XCirculateSubwindows(IntPtr display, IntPtr w, int direction);

            // int: XCirculateSubwindowsUp [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCirculateSubwindowsUp_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XCirculateSubwindowsUp(IntPtr display, IntPtr w);

            // int: XCirculateSubwindowsDown [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCirculateSubwindowsDown_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XCirculateSubwindowsDown(IntPtr display, IntPtr w);

            // int: XRestackWindows [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'windows[]'}, {'type': 'int', 'name': 'nwindows'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRestackWindows_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XRestackWindows(IntPtr display, IntPtr[] windows, int nwindows);

            // int: XWindowEvent Display*:display  Window:w  long:event_mask  XEvent*:event_return
            [DllImport(ExtremeSports.Lib, EntryPoint = "XWindowEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XWindowEvent(IntPtr display, IntPtr w, EventMask event_mask, [In,Out] IntPtr event_return);

            // Bool: XCheckWindowEvent Display*:display  Window:w  long:event_mask  XEvent*:event_return
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCheckWindowEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XCheckWindowEvent(IntPtr display, IntPtr w, EventMask event_mask, [In,Out] IntPtr event_return);

            // Bool: XCheckTypedWindowEvent Display*:display  Window:w  int:event_type  XEvent*:event_return
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCheckTypedWindowEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XCheckTypedWindowEvent(IntPtr display, IntPtr w, Event.XEventType event_type, [In, Out] IntPtr event_return);


            // XTimeCoord*: XGetMotionEvents Display*:display  Window:w  Time:start  Time:stop  int*:nevents_return
            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetMotionEvents_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XGetMotionEvents(IntPtr display, IntPtr w, uint start, uint stop, out int nevents_return);

            // int: XConfigureWindow [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'unsigned', 'name': 'value_mask'}, {'type': 'XWindowChanges*', 'name': 'changes'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XConfigureWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XConfigureWindow(IntPtr display, IntPtr w, uint value_mask, IntPtr changes);

            // Status: XQueryTree [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Window*', 'name': 'root_return'}, {'type': 'Window*', 'name': 'parent_return'}, {'type': 'Window*', 'name': '*children_return'}, {'type': 'unsigned int*', 'name': 'nchildren_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XQueryTree_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XQueryTree(IntPtr display, IntPtr w, out IntPtr root_return, out IntPtr parent_return, out IntPtr children_return, out IntPtr nchildren_return);

            // int: XSetTransientForHint [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Window', 'name': 'prop_window'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetTransientForHint_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XSetTransientForHint(IntPtr display, IntPtr w, IntPtr prop_window);

            // Status: XGetTransientForHint [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Window*', 'name': 'prop_window_return'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetTransientForHint_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XGetTransientForHint(IntPtr display, IntPtr w, out IntPtr prop_window_return);

            // Bool: XQueryPointer Display*:display Window:w Window*:root_return Window*:child_return int*:root_x_return int*:root_y_return int*:win_x_return int*:win_y_return unsigned int*:mask_return
            [DllImport(ExtremeSports.Lib, EntryPoint = "XQueryPointer_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XQueryPointer(
                IntPtr display, IntPtr w, out IntPtr root_return, out IntPtr child_return, out int root_x_return, out int root_y_return, out int win_x_return, out int win_y_return, out ModifierMask mask_return);


            // Status: XDefineCursor Display*:display  Window:w  Cursor:cursor
            [DllImport(ExtremeSports.Lib, EntryPoint = "XDefineCursor_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XDefineCursor(IntPtr display, IntPtr w, int cursor);

            // Status: XUndefineCursor Display*:display  Window:w
            [DllImport(ExtremeSports.Lib, EntryPoint = "XUndefineCursor_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XUndefineCursor(IntPtr display, IntPtr w);


            // int: XGetWindowProperty [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Atom', 'name': 'property'}, {'type': 'long', 'name': 'long_offset'}, {'type': 'long', 'name': 'long_length'}, {'type': 'Bool', 'name': 'delete'}, {'type': 'Atom', 'name': 'req_type'}, {'type': 'Atom*', 'name': 'actual_type_return'}, {'type': 'int*', 'name': 'actual_format_return'}, {'type': 'unsigned long*', 'name': 'nitems_return'}, {'type': 'unsigned long*', 'name': 'bytes_after_return'}, {'type': 'unsigned char*', 'name': '*prop_return'}]
            // [DllImport(ExtremeSports.Lib, EntryPoint = "XGetWindowProperty_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            // internal static extern int XGetWindowProperty(IntPtr display, IntPtr w, ulong property, long long_offset, long long_length, [MarshalAs(UnmanagedType.U1)] bool delete, ulong req_type, IntPtr actual_type_return, out IntPtr actual_format_return, out IntPtr nitems_return, out IntPtr bytes_after_return, [MarshalAs(UnmanagedType.LPStr)] string prop_return);

            // Atom*: XListProperties [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'int*', 'name': 'num_prop_return'}]
            // [DllImport(ExtremeSports.Lib, EntryPoint = "XListProperties_TNK", CharSet = CharSet.Auto)]
            // internal static extern IntPtr XListProperties(IntPtr display, IntPtr w, out IntPtr num_prop_return);

            //[DllImport(ExtremeSports.Lib, EntryPoint = "XChangeProperty_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            //internal static extern int XChangeProperty(IntPtr display, IntPtr w, ulong property, ulong type, int format, int mode, [MarshalAs(UnmanagedType.LPStr)] string data, int nelements);

            //[DllImport(ExtremeSports.Lib, EntryPoint = "XRotateWindowProperties_TNK", CharSet = CharSet.Auto)]
            //internal static extern int XRotateWindowProperties(IntPtr display, IntPtr w, ulong [] properties, int num_prop, int npositions);

            //[DllImport(ExtremeSports.Lib, EntryPoint = "XDeleteProperty_TNK", CharSet = CharSet.Auto)]
            //internal static extern int XDeleteProperty(IntPtr display, IntPtr w, ulong property);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetTextProperty_TNK", CharSet = CharSet.Auto)]
            internal static extern void XSetTextProperty(IntPtr display, IntPtr w, IntPtr text_prop, ulong property);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetTextProperty_TNK", CharSet = CharSet.Auto)]
            internal static extern int XGetTextProperty(IntPtr display, IntPtr w, IntPtr text_prop_return, ulong property);

            /* [DllImport(ExtremeSports.Lib, EntryPoint = "XmbSetWMProperties_TNK", CharSet = CharSet.Auto)]
             internal static extern void XmbSetWMProperties(
                 IntPtr display, IntPtr w, [MarshalAs(UnmanagedType.LPStr)] string window_name, [MarshalAs(UnmanagedType.LPStr)] string icon_name, [MarshalAs(UnmanagedType.LPStr)] string[] argv, int argc, ref XSizeHints normal_hints, ref XWMHintsRec wm_hints, ref XClassHintRec class_hints);

             [DllImport(ExtremeSports.Lib, EntryPoint = "XmbSetWMProperties_TNK", CharSet = CharSet.Auto)]
             internal static extern void XmbSetWMProperties(
                 IntPtr display, IntPtr w,
                 [In] byte[] window_name, [In] byte[] icon_name, [MarshalAs(UnmanagedType.LPStr)] string[] argv, int argc,
                 IntPtr normal_hints, IntPtr wm_hints, IntPtr class_hints);
                 */


            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWMName_TNK", CharSet = CharSet.Auto)]
            internal static extern void XSetWMName(IntPtr display, IntPtr w, ref XTextPropertyRec text_prop);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetWMName_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XGetWMName(IntPtr display, IntPtr w, ref XTextPropertyRec text_prop_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XStoreName_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern XStatus XStoreName(IntPtr display, IntPtr w, [MarshalAs(UnmanagedType.LPStr)] string window_name);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFetchName_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XFetchName(IntPtr display, IntPtr w, out IntPtr window_name_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWMIconName_TNK", CharSet = CharSet.Auto)]
            internal static extern void XSetWMIconName(IntPtr display, IntPtr w, ref XTextPropertyRec text_prop);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetWMIconName_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XGetWMIconName(IntPtr display, IntPtr w, ref XTextPropertyRec text_prop_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetIconName_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern XStatus XSetIconName(IntPtr display, IntPtr w, [MarshalAs(UnmanagedType.LPStr)] string icon_name);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetIconName_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XGetIconName(IntPtr display, IntPtr w, out IntPtr icon_name_return);

            // XSizeHints*: XAllocSizeHints
            //[DllImport(ExtremeSports.Lib, EntryPoint = "XAllocSizeHints_TNK", CharSet = CharSet.Auto)]
            //internal static extern IntPtr XAllocSizeHints();

            // void: XSetWMNormalHints Display*:display  Window:w  XSizeHints*:hints
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWMNormalHints_TNK", CharSet = CharSet.Auto)]
            internal static extern void XSetWMNormalHints(IntPtr display, IntPtr w, ref XSizeHints hints);

            // Status: XGetWMNormalHints Display*:display  Window:w  XSizeHints*:hints_return  long*:supplied_return
            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetWMNormalHints_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XGetWMNormalHints(IntPtr display, IntPtr w, ref XSizeHints hints_return, out long supplied_return);

            // void: XSetWMSizeHints Display*:display  Window:w  XSizeHints*:hints  Atom:property
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetWMSizeHints_TNK", CharSet = CharSet.Auto)]
            internal static extern void XSetWMSizeHints(IntPtr display, IntPtr w, ref XSizeHints hints, ulong property);

            // Status: XGetWMSizeHints Display*:display  Window:w  XSizeHints*:hints_return  long*:supplied_return  Atom:property
            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetWMSizeHints_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XGetWMSizeHints(IntPtr display, IntPtr w, ref XSizeHints hints_return, out long supplied_return, ulong property);


        }

        public static Window GetDefaultRootWindow(Display dpy) {
            return (new Window(NativeMethods.DefaultRootWindow(dpy.Handle), dpy));
        }

        public Window(ReturnPointerDelegaty delegaty, Display display) {
            this.delegaty = delegaty;
            this.display = display;
        }

        public Window(IntPtr window, Display display) {
            this.window = window;
            this.display = display;
        }

        public Window() {
        }

        public void Assign(IntPtr window, Display display) {
            this.window = window;
            this.display = display;
        }

        public void Assign(ReturnPointerDelegaty delegaty, Display display) {
            this.delegaty = delegaty;
            this.display = display;
        }

        public IntPtr Handle =>
            (delegaty != null) ? delegaty() : window;

        public Display Display => display;

        #region IDrawable
        public IntPtr Drawable => Handle;
        #endregion

        public XStatus SelectInput(EventMask mask) {
            return NativeMethods.XSelectInput(display.Handle, Handle, (ulong)mask);
        }


        public XStatus SetWMProtocols(IEnumerable<Atom> atoms) {
            var arr = new List<IntPtr>();
            foreach (var a in atoms) {
                arr.Add(a.Handle);
            }
            var addrOfArray = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(IntPtr)) * arr.Count);
            Marshal.Copy(arr.ToArray(), 0, addrOfArray, arr.Count);
            var rv = NativeMethods.XSetWMProtocols(display.Handle, Handle, addrOfArray, arr.Count);
            Marshal.FreeCoTaskMem(addrOfArray);
            return rv;
        }

        public IEnumerable<Atom> GetWMProtocols() {
            IntPtr arr;
            int count;
            var ret = new List<Atom>();
            NativeMethods.XGetWMProtocols(display.Handle, Handle, out arr, out count);
            if (0 == count) {
                return ret;
            }

            IntPtr[] ps = new IntPtr[count];
            Marshal.Copy(arr, ps, 0, count);
            foreach (var i in ps) {
                ret.Add(new Atom(i, display));
            }
            return ret;
        }

        public void SetWMName(XTextProperty property) {
            NativeMethods.XSetWMName(display.Handle, Handle, ref property.record);
        }

        public void SetWMIconName(XTextProperty property) {
            NativeMethods.XSetWMIconName(display.Handle, Handle, ref property.record);
        }

        public XTextProperty GetWMName() {
            var r = new XTextProperty();
            if(XStatus.False == NativeMethods.XGetWMName(display.Handle, Handle, ref r.record)) {
                return null;
            }
            return r;
        }

        public XTextProperty GetWMIconName() {
            var r = new XTextProperty();
            if (XStatus.False ==  NativeMethods.XGetWMIconName(display.Handle, Handle, ref r.record)) {
                return null;
            }
            return r;
        }



        string sfr(IntPtr str) {
            if (str == IntPtr.Zero) {
                return null;
            }
            var r = Marshal.PtrToStringAnsi(str);
            Xi.Free(str);
            return r;
        }

        public int ClearWindow() {
            return TonNurako.X11.Xi.XClearWindow(Display, Handle);
        }

        public XStatus StoreName(string window_name) =>
            NativeMethods.XStoreName(display.Handle, Handle, window_name);

        public string FetchName() {
            IntPtr rw = IntPtr.Zero;
            NativeMethods.XFetchName(display.Handle, Handle, out rw);
            return sfr(rw);
        }

        public XStatus SetIconName(string window_name) =>
            NativeMethods.XSetIconName(display.Handle, Handle, window_name);

        public string GetIconName() {
            IntPtr rw = IntPtr.Zero;
            NativeMethods.XGetIconName(display.Handle, Handle, out rw);
            return sfr(rw);
        }


        public XStatus MapWindow() => NativeMethods.XMapWindow(display.Handle, Handle);
        public XStatus MapRaised() => NativeMethods.XMapRaised(display.Handle, Handle);

        public XStatus MapSubwindows() => NativeMethods.XMapSubwindows(display.Handle, Handle);

        public XStatus UnmapWindow() => NativeMethods.XUnmapWindow(display.Handle, Handle);
        public XStatus UnmapSubwindows() => NativeMethods.XUnmapSubwindows(display.Handle, Handle);

        public XStatus RaiseWindow() => NativeMethods.XRaiseWindow(display.Handle, Handle);
        public int LowerWindow() => NativeMethods.XLowerWindow(display.Handle, Handle);

        public int DestroyWindow() => NativeMethods.XDestroyWindow(display.Handle, Handle);
        public int DestroySubwindows() => NativeMethods.XDestroySubwindows(display.Handle, Handle);

        public XStatus SetWindowBackground(Color color) => NativeMethods.XSetWindowBackground(display.Handle, Handle, color.Pixel);
        public XStatus SetWindowBorder(Color color) => NativeMethods.XSetWindowBorder(display.Handle, Handle, color.Pixel);


        public XStatus SetWindowBackgroundPixmap(TonNurako.X11.Pixmap pixmap) =>
            NativeMethods.XSetWindowBackgroundPixmap(display.Handle, Handle, pixmap.Drawable);

        public XStatus SetWindowBorderPixmap(TonNurako.X11.Pixmap pixmap) =>
            NativeMethods.XSetWindowBorderPixmap(display.Handle, Handle, pixmap.Drawable);

        public XStatus MoveWindow(int x, int y)
            => NativeMethods.XMoveWindow(display.Handle, Handle, x, y);

        public XStatus ResizeWindow(int width, int height)
            => NativeMethods.XResizeWindow(display.Handle, Handle, (uint)width, (uint)height);

        public XStatus MoveResizeWindow(int x, int y, int width, int height)
            => NativeMethods.XMoveResizeWindow(display.Handle, Handle, x, y, (uint)width, (uint)height);

        public XStatus SetWindowBorderWidth(int width)
            => NativeMethods.XSetWindowBorderWidth(display.Handle, Handle, (uint)width);

        //public static IntPtr XAllocSizeHints() =>
        //    NativeMethods.XAllocSizeHints();


        // void: XSetWMNormalHints Display*:display  Window:w  XSizeHints*:hints
        public void SetWMNormalHints(ref XSizeHints hints) =>
            NativeMethods.XSetWMNormalHints(display.Handle, Handle, ref hints);


        // Status: XGetWMNormalHints Display*:display  Window:w  XSizeHints*:hints_return  long*:supplied_return
        public XStatus GetWMNormalHints(ref XSizeHints hints_return, out long supplied_return) =>
            NativeMethods.XGetWMNormalHints(display.Handle, Handle, ref hints_return, out supplied_return);


        // void: XSetWMSizeHints Display*:display  Window:w  XSizeHints*:hints  Atom:property
        public void SetWMSizeHints(ref XSizeHints hints, ulong property) =>
            NativeMethods.XSetWMSizeHints(display.Handle, Handle, ref hints, property);


        // Status: XGetWMSizeHints Display*:display  Window:w  XSizeHints*:hints_return  long*:supplied_return  Atom:property
        public XStatus GetWMSizeHints(ref XSizeHints hints_return, out long supplied_return, Atom property) =>
            NativeMethods.XGetWMSizeHints(display.Handle, Handle, ref hints_return, out supplied_return, (ulong)property.Handle);



        public XStatus WindowEvent(EventMask event_mask, XEventArg event_return) {
            var r = NativeMethods.XWindowEvent(display.Handle, Handle, event_mask, event_return.handle);
            event_return.Assign();
            return r;
        }

        public bool CheckWindowEvent(EventMask event_mask, XEventArg event_return) {
            var r = NativeMethods.XCheckWindowEvent(display.Handle, Handle, event_mask, event_return.handle);
            event_return.Assign();
            return r;
        }

        public bool CheckTypedWindowEvent(Event.XEventType event_type, XEventArg ev) {
            var r = NativeMethods.XCheckTypedWindowEvent(display.Handle, Handle, event_type, ev.Handle);
            ev.Assign();
            return r;
        }

        public XTimeCoord[] GetMotionEvents(uint start, uint stop) {
            int n = 0;
            var r = NativeMethods.XGetMotionEvents(display.Handle, Handle, start, stop, out n);
            if (IntPtr.Zero == r || n <= 0) {
                return null;
            }
            //TODO: Free����K�v�͖����炵��������ǂ��̂Œ�����
            return Inutility.MarshalHelper.ToStructArray<XTimeCoord>(r, n);
        }


        public XWindowAttributes GetWindowAttributes() {
            var rw = new XWindowAttributes(Display);
            var k = NativeMethods.XGetWindowAttributes(this.Display.Handle, Handle, out rw.record);
            if(XStatus.False == k) {
                return null;
            }
            return rw;
        }

        public XStatus ChangeWindowAttributes(ChangeWindowAttributes cw, XSetWindowAttributes attr) {
            return NativeMethods.XChangeWindowAttributes(this.Display.Handle, Handle, (ulong)cw, ref attr.record);
        }

        public XStatus SetClassHint(XClassHint klass) {
            return NativeMethods.XSetClassHint(this.Display.Handle, Handle, ref klass);
        }

        public XClassHint GetClassHint() {
            XClassHintRec p;
            if (XStatus.False == NativeMethods.XGetClassHint(this.Display.Handle, Handle, out p)) {
                return null;
            }
            return (new XClassHint(p));
        }

        public bool QueryPointer(XPointerInfo info) {
            info.Display = this.Display;
            var r = NativeMethods.XQueryPointer(
                this.Display.Handle, this.Handle,
                out info.Record.Root, out info.Record.Child,
                out info.Record.RootX, out info.Record.RootY,
                out info.Record.WinX, out info.Record.WinY,
                out info.Record.Mask);
            return r;
        }

        public XStatus DefineCursor(Cursor cursor) =>
            NativeMethods.XDefineCursor(this.Display.Handle, this.Handle, cursor.Handle);


        public XStatus UndefineCursor() =>
            NativeMethods.XUndefineCursor(this.Display.Handle, this.Handle);

        public Geometry GetGeometry() {
            var g = new Geometry(Display);
            var r = NativeMethods.XGetGeometry(
                this.Display.Handle, Handle,
                out g.root_return,
                out g.x_return,
                out g.y_return,
                out g.width_return,
                out g.height_return,
                out g.border_width_return,
                out g.depth_return);
            if(XStatus.True != r) {
                return null;
            }
            return g;
        }

        /*public void SetWMProperties(string window_name, string icon_name, string[] argv, XSizeHints normal_hints, XWMHints wm_hints, ref XClassHint class_hints) {
            NativeMethods.XmbSetWMProperties(
                this.Display.Handle, Handle,
                window_name,
                icon_name,
                argv,
                argv.Length,
                ref normal_hints,
                ref wm_hints.record, ref class_hints.classHint);
        }

        public void SetWMProperties(string window_name, string icon_name, string[] argv) {
            NativeMethods.XmbSetWMProperties(
                this.Display.Handle, Handle,
                Encoding.Default.GetBytes(window_name),
                Encoding.Default.GetBytes(icon_name),
                argv,
                argv.Length,
                IntPtr.Zero,
                IntPtr.Zero, IntPtr.Zero);
        }*/
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XSizeHintsAspect {
        int x;   /* numerator */
        int y;   /* denominator */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XSizeHints {
        long flags;     /* marks which fields in this structure are defined */
        int x, y;       /* Obsolete */
        int width, height;      /* Obsolete */
        int min_width, min_height;
        int max_width, max_height;
        int width_inc, height_inc;
        XSizeHintsAspect min_aspect;
        XSizeHintsAspect max_aspect;
        int base_width, base_height;
        int win_gravity;
        /* this structure may be extended in the future */
    }


    [StructLayout(LayoutKind.Sequential)]
    internal struct XWMHintsRec {
        public long flags; // long
        [MarshalAs(UnmanagedType.U1)] public bool input; // Bool
        public int initial_state; // int
        public IntPtr icon_pixmap; // Pixmap
        public IntPtr icon_window; // Window
        public int icon_x; // int
        public int icon_y; // int
        public IntPtr icon_mask; // Pixmap
        public int window_group; // XID
    }

    public class XWMHints : IX11Interop, IDisposable {
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "XAllocWMHints_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XAllocWMHints();
        }
        IntPtr handle;
        public IntPtr Handle => handle;

        internal XWMHintsRec record;

        public static XWMHints Alloc() {
            var r = new XWMHints();
            r.handle = NativeMethods.XAllocWMHints();
            return r;
        }
        public XWMHints() {
            record = new XWMHintsRec();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (handle != IntPtr.Zero) {
                    Xi.Free(handle);
                    handle = IntPtr.Zero;
                }
                disposedValue = true;
            }
        }

        #if RLE
        ~XWMHints() {
            if (IntPtr.Zero != handle) {
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


    [StructLayout(LayoutKind.Sequential)]
    internal struct XClassHintRec {
        public IntPtr res_name;
        public IntPtr res_class;
    }

    public class XClassHint : IX11Interop, IDisposable {
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "XAllocClassHint_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XAllocClassHint();
        }


        public XClassHint() {
        }

        internal XClassHint(XClassHintRec handle) {
            classHint = handle;
        }

        public static XClassHint Alloc() {
            var r = new XClassHint();
            r.allocRoot = NativeMethods.XAllocClassHint();
            r.raw = r.allocRoot;
            return r;
        }

        IntPtr allocRoot = IntPtr.Zero;
        IntPtr raw = IntPtr.Zero;
        internal XClassHintRec classHint;
        public string ResName => Marshal.PtrToStringAnsi(classHint.res_name);
        public string ResClass => Marshal.PtrToStringAnsi(classHint.res_class);

        public IntPtr Handle => raw;

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (allocRoot != IntPtr.Zero) {
                    Xi.Free(allocRoot);
                    allocRoot = IntPtr.Zero;
                }
                else {
                    if (classHint.res_class != IntPtr.Zero) {
                        Xi.Free(classHint.res_class);
                        classHint.res_class = IntPtr.Zero;
                    }
                    if (classHint.res_name != IntPtr.Zero) {
                        Xi.Free(classHint.res_name);
                        classHint.res_name = IntPtr.Zero;
                    }
                }
                disposedValue = true;
            }
        }

        ~XClassHint() {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        #endregion
    }
}

