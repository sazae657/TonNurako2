using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.X11.Event;

namespace TonNurako.X11 {

    public class Display : IX11Interop {

        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "XOpenDisplay_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr XOpenDisplay([MarshalAs(UnmanagedType.LPStr)] string display_name);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XOpenDisplay_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XOpenDisplayP(IntPtr display_name);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XCloseDisplay_TNK", CharSet = CharSet.Auto)]
            internal static extern int XCloseDisplay(IntPtr display);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFlush_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XFlush(IntPtr display);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSync_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XSync(IntPtr display, [MarshalAs(UnmanagedType.U1)] bool discard);

            // [DllImport(ExtremeSports.Lib, EntryPoint = "XEventsQueued_TNK", CharSet = CharSet.Auto)]
            // internal static extern int XEventsQueued(IntPtr display, int mode);

            // int: XPending [{'type': 'Display*', 'name': 'display'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XPending_TNK", CharSet = CharSet.Auto)]
            internal static extern int XPending(IntPtr display);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDisplayName_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr XDisplayName([MarshalAs(UnmanagedType.LPStr)] string sxtring);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDisplayName_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XDisplayNameP(IntPtr ptr);

            [DllImport(ExtremeSports.Lib, EntryPoint = "ServerVendor_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr ServerVendor(IntPtr dpy);

            [DllImport(ExtremeSports.Lib, EntryPoint = "DisplayWidth_TNK", CharSet = CharSet.Auto)]
            internal static extern int DisplayWidth(IntPtr display, int screen_number);

            [DllImport(ExtremeSports.Lib, EntryPoint = "DisplayHeight_TNK", CharSet = CharSet.Auto)]
            internal static extern int DisplayHeight(IntPtr display, int screen_number);

            [DllImport(ExtremeSports.Lib, EntryPoint = "DisplayWidthMM_TNK", CharSet = CharSet.Auto)]
            internal static extern int DisplayWidthMM(IntPtr display, int screen_number);

            [DllImport(ExtremeSports.Lib, EntryPoint = "DisplayHeightMM_TNK", CharSet = CharSet.Auto)]
            internal static extern int DisplayHeightMM(IntPtr display, int screen_number);

            [DllImport(ExtremeSports.Lib, EntryPoint = "DefaultScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern int DefaultScreen(IntPtr display);

            [DllImport(ExtremeSports.Lib, EntryPoint = "ProtocolVersion_TNK", CharSet = CharSet.Auto)]
            internal static extern int ProtocolVersion(IntPtr display);

            [DllImport(ExtremeSports.Lib, EntryPoint = "ProtocolRevision_TNK", CharSet = CharSet.Auto)]
            internal static extern int ProtocolRevision(IntPtr display);


            [DllImport(ExtremeSports.Lib, EntryPoint = "XNextEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern int XNextEvent(IntPtr display, [In, Out] IntPtr event_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XPeekEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern int XPeekEvent(IntPtr display, [In, Out] IntPtr event_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XAllowEvents_TNK", CharSet = CharSet.Auto)]
            internal static extern int XAllowEvents(IntPtr display, Event.EventMode event_mode, uint time);

            // int: XMaskEvent Display*:display  long:event_mask  XEvent*:event_return  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XMaskEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern int XMaskEvent(IntPtr display, EventMask event_mask, [In, Out] IntPtr event_return);

            // Bool: XCheckMaskEvent Display*:display  long:event_mask  XEvent*:event_return  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCheckMaskEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XCheckMaskEvent(IntPtr display, EventMask event_mask, [In, Out] IntPtr event_return);

            // Bool: XCheckTypedEvent Display*:display  int:event_type  XEvent*:event_return  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCheckTypedEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XCheckTypedEvent(IntPtr display, Event.XEventType event_type, [In, Out] IntPtr event_return);

            // Status: XSendEvent Display*:display  Window:w  Bool:propagate  long:event_mask  XEvent*:event_send  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSendEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSendEvent(IntPtr display, IntPtr w, [MarshalAs(UnmanagedType.U1)] bool propagate, EventMask event_mask, [In]IntPtr event_send);

            // u_long: XDisplayMotionBufferSize Display*:display  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XDisplayMotionBufferSize_TNK", CharSet = CharSet.Auto)]
            internal static extern ulong XDisplayMotionBufferSize(IntPtr display);


            [DllImport(ExtremeSports.Lib, EntryPoint = "XCreateSimpleWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XCreateSimpleWindow(IntPtr display, IntPtr parent, int x, int y, uint width, uint height, uint border_width, ulong border, ulong background);

            // Window: XCreateWindow Display*:display Window:parent int:x int:y unsigned int:width unsigned int:height unsigned int:border_width int:depth unsigned int:class Visual*:visual unsigned long:valuemask XSetWindowAttributes*:attributes
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCreateWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XCreateWindow(IntPtr display,
                IntPtr parent, int x, int y, uint width, uint height, uint border_width, int depth, WindowClass qlass, [In]IntPtr visual, ChangeWindowAttributes valuemask, ref XSetWindowAttributesRec attributes);

            [DllImport(ExtremeSports.Lib, EntryPoint = "DefaultColormap_TNK", CharSet = CharSet.Auto)]
            internal static extern int DefaultColormap(IntPtr display, int screen_num);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetCloseDownMode_TNK", CharSet = CharSet.Auto)]
            internal static extern int XSetCloseDownMode(IntPtr display, CloseDownMode close_mode);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XKillClient_TNK", CharSet = CharSet.Auto)]
            internal static extern int XKillClient(IntPtr display, int resource);

            // int: ConnectionNumber [{'type': 'Display*', 'name': 'dpy'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "ConnectionNumber_TNK", CharSet = CharSet.Auto)]
            internal static extern int ConnectionNumber(IntPtr dpy);

            // int: QLength [{'type': 'Display*', 'name': 'dpy'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "QLength_TNK", CharSet = CharSet.Auto)]
            internal static extern int QLength(IntPtr dpy);

            // int: ScreenCount [{'type': 'Display*', 'name': 'dpy'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "ScreenCount_TNK", CharSet = CharSet.Auto)]
            internal static extern int ScreenCount(IntPtr dpy);

            // int: VendorRelease [{'type': 'Display*', 'name': 'dpy'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "VendorRelease_TNK", CharSet = CharSet.Auto)]
            internal static extern int VendorRelease(IntPtr dpy);

            // char*: DisplayString [{'type': 'Display*', 'name': 'dpy'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DisplayString_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr DisplayString(IntPtr dpy);

            // int: BitmapUnit [{'type': 'Display*', 'name': 'dpy'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "BitmapUnit_TNK", CharSet = CharSet.Auto)]
            internal static extern int BitmapUnit(IntPtr dpy);

            // int: BitmapBitOrder [{'type': 'Display*', 'name': 'dpy'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "BitmapBitOrder_TNK", CharSet = CharSet.Auto)]
            internal static extern int BitmapBitOrder(IntPtr dpy);

            // int: BitmapPad [{'type': 'Display*', 'name': 'dpy'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "BitmapPad_TNK", CharSet = CharSet.Auto)]
            internal static extern int BitmapPad(IntPtr dpy);

            // int: ImageByteOrder [{'type': 'Display*', 'name': 'dpy'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "ImageByteOrder_TNK", CharSet = CharSet.Auto)]
            internal static extern int ImageByteOrder(IntPtr dpy);

            // int: NextRequest [{'type': 'Display*', 'name': 'dpy'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "NextRequest_TNK", CharSet = CharSet.Auto)]
            internal static extern int NextRequest(IntPtr dpy);

            // ulong: LastKnownRequestProcessed [{'type': 'Display*', 'name': 'dpy'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "LastKnownRequestProcessed_TNK", CharSet = CharSet.Auto)]
            internal static extern ulong LastKnownRequestProcessed(IntPtr dpy);

            // Window: RootWindow [{'type': 'Display*', 'name': 'dpy'}, {'type': 'Screen*', 'name': 'scr'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "RootWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr RootWindow(IntPtr dpy, int scr);

            // Window: DefaultRootWindow [{'type': 'Display*', 'name': 'dpy'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DefaultRootWindow_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr DefaultRootWindow(IntPtr dpy);

            // Visual*: DefaultVisual [{'type': 'Display*', 'name': 'dpy'}, {'type': 'int', 'name': 'scr'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DefaultVisual_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr DefaultVisual(IntPtr dpy, int scr);

            // GC: DefaultGC [{'type': 'Display*', 'name': 'dpy'}, {'type': 'int', 'name': 'scr'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DefaultGC_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr DefaultGC(IntPtr dpy, int scr);

            // ulong: BlackPixel [{'type': 'Display*', 'name': 'dpy'}, {'type': 'int', 'name': 'scr'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "BlackPixel_TNK", CharSet = CharSet.Auto)]
            internal static extern ulong BlackPixel(IntPtr dpy, int scr);

            // ulong: WhitePixel [{'type': 'Display*', 'name': 'dpy'}, {'type': 'int', 'name': 'scr'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "WhitePixel_TNK", CharSet = CharSet.Auto)]
            internal static extern ulong WhitePixel(IntPtr dpy, int scr);

            // int: DisplayPlanes [{'type': 'Display*', 'name': 'dpy'}, {'type': 'int', 'name': 'scr'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DisplayPlanes_TNK", CharSet = CharSet.Auto)]
            internal static extern int DisplayPlanes(IntPtr dpy, int scr);

            // int: DisplayCells [{'type': 'Display*', 'name': 'dpy'}, {'type': 'int', 'name': 'scr'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DisplayCells_TNK", CharSet = CharSet.Auto)]
            internal static extern int DisplayCells(IntPtr dpy, int scr);

            // int: DefaultDepth [{'type': 'Display*', 'name': 'dpy'}, {'type': 'int', 'name': 'scr'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DefaultDepth_TNK", CharSet = CharSet.Auto)]
            internal static extern int DefaultDepth(IntPtr dpy, int scr);

            // Screen*: ScreenOfDisplay [{'type': 'Display*', 'name': 'dpy'}, {'type': 'int', 'name': 'scr'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "ScreenOfDisplay_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr ScreenOfDisplay(IntPtr dpy, int scr);

            // Screen*: DefaultScreenOfDisplay [{'type': 'Display*', 'name': 'dpy'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DefaultScreenOfDisplay_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr DefaultScreenOfDisplay(IntPtr dpy);

            // KeySym: XKeycodeToKeysym [{'type': 'Display*', 'name': 'display'}, {'type': 'KeyCode', 'name': 'keycode'}, {'type': 'int', 'name': 'index'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XkbKeycodeToKeysym_TNK", CharSet = CharSet.Auto)]
            internal static extern KeySym XkbKeycodeToKeysym(IntPtr dpy, uint kc, uint group, uint level);

            // KeyCode: XKeysymToKeycode [{'type': 'Display*', 'name': 'display'}, {'type': 'KeySym', 'name': 'keysym'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XKeysymToKeycode_TNK", CharSet = CharSet.Auto)]
            internal static extern uint XKeysymToKeycode(IntPtr display, KeySym keysym);


            // KeySym: XStringToKeysym [{'type': 'char*', 'name': 'string'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XStringToKeysym_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern KeySym XStringToKeysym([MarshalAs(UnmanagedType.LPStr)] string sk);

            // char*: XKeysymToString [{'type': 'KeySym', 'name': 'keysym'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XKeysymToString_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XKeysymToString(KeySym keysym);

            // void: XConvertCase KeySym:keysym  KeySym*:lower_return  KeySym*:upper_return  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XConvertCase_TNK", CharSet = CharSet.Auto)]
            internal static extern void XConvertCase(KeySym keysym, out KeySym lower_return, out KeySym upper_return);

            // int: XDisplayKeycodes Display*:display  int*:min_keycodes_return  int*:max_keycodes_return  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XDisplayKeycodes_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XDisplayKeycodes(IntPtr display, out int min_keycodes_return, out int max_keycodes_return);

            // int: XSetModifierMapping Display*:display  XModifierKeymap*:modmap  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetModifierMapping_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XSetModifierMapping(IntPtr display, IntPtr modmap);

            // XModifierKeymap*: XGetModifierMapping Display*:display  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetModifierMapping_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XGetModifierMapping(IntPtr display);


            // int: XGrabServer [{'type': 'Display*', 'name': 'display'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XGrabServer_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XGrabServer(IntPtr display);

            // int: XUngrabServer [{'type': 'Display*', 'name': 'display'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XUngrabServer_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XUngrabServer(IntPtr display);


            [DllImport(ExtremeSports.Lib, EntryPoint = "XGrabKey_TNK", CharSet = CharSet.Auto)]
            internal static extern int XGrabKey(
                IntPtr display, int keycode, uint modifiers, IntPtr grab_window, [MarshalAs(UnmanagedType.U1)] bool owner_events, GrabMode pointer_mode, GrabMode keyboard_mode);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XUngrabKey_TNK", CharSet = CharSet.Auto)]
            internal static extern int XUngrabKey(IntPtr display, int keycode, uint modifiers, IntPtr grab_window);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGrabButton_TNK", CharSet = CharSet.Auto)]
            internal static extern int XGrabButton(IntPtr display, uint button, uint modifiers, IntPtr grab_window, [MarshalAs(UnmanagedType.U1)] bool owner_events, EventMask event_mask, GrabMode pointer_mode, GrabMode keyboard_mode, IntPtr confine_to, int cursor);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XUngrabButton_TNK", CharSet = CharSet.Auto)]
            internal static extern int XUngrabButton(IntPtr display, uint button, uint modifiers, IntPtr grab_window);

            // int: XSetInputFocus Display*:display  Window:focus  int:revert_to  Time:time  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetInputFocus_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XSetInputFocus(IntPtr display, IntPtr focus, RevertTo revert_to, uint time);

            // int: XGetInputFocus Display*:display  Window*:focus_return  int*:revert_to_return  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetInputFocus_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XGetInputFocus(IntPtr display, out IntPtr focus_return, out RevertTo revert_to_return);

            // int: XWarpPointer Display*:display  Window:src_w  Window:dest_w  int:src_x  int:src_y  unsigned int:src_width  unsigned int:src_height  int:dest_x  int:dest_y  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XWarpPointer_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XWarpPointer(IntPtr display, IntPtr src_w, IntPtr dest_w, int src_x, int src_y, uint src_width, uint src_height, int dest_x, int dest_y);



            // int: XGetErrorText [{'type': 'Display*', 'name': 'display'}, {'type': 'int', 'name': 'code'}, {'type': 'char*', 'name': 'buffer_return'}, {'type': 'int', 'name': 'length'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetErrorText_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern int XGetErrorText(IntPtr display, int code, [MarshalAs(UnmanagedType.LPStr)] string buffer_return, int length);

            // int: XGetErrorDatabaseText [{'type': 'Display*', 'name': 'display'}, {'type': 'char*', 'name': 'name'}, {'type': 'char*', 'name': 'message'}, {'type': 'char*', 'name': 'default_string'}, {'type': 'char*', 'name': 'buffer_return'}, {'type': 'int', 'name': 'length'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetErrorDatabaseText_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern int XGetErrorDatabaseText(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string message, [MarshalAs(UnmanagedType.LPStr)] string default_string, [MarshalAs(UnmanagedType.LPStr)] string buffer_return, int length);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetAfterFunction_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XSetAfterFunction(IntPtr display, [MarshalAs(UnmanagedType.FunctionPtr)] XSetAfterFunctionDelegatyInt proc);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSynchronize_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XSynchronize(IntPtr display, bool onoff);

            // Bool: XTranslateCoordinates Display*:display  Window:src_w  Window:dest_w  int:src_x  int:src_y  int*:dest_x_return  int*:dest_y_return  Window*:child_return  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XTranslateCoordinates_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XTranslateCoordinates(IntPtr display, IntPtr src_w, IntPtr dest_w, int src_x, int src_y, out int dest_x_return, out int dest_y_return, out IntPtr child_return);

        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int XSetAfterFunctionDelegatyInt();

        public delegate int XSetAfterFunctionDelegaty();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int XSynchronizeDelegaty(IntPtr ptr);

        public static Display Open(string display) {
            var dp = (null != display) ? NativeMethods.XOpenDisplay(display) : NativeMethods.XOpenDisplayP(IntPtr.Zero);
            if (IntPtr.Zero == dp) {
                return null;
            }
            return new Display(dp, true);
        }

        public int SetCloseDownMode(CloseDownMode mode) =>
                NativeMethods.XSetCloseDownMode(Handle, mode);

        public int KillClient(int resource) =>
            NativeMethods.XKillClient(Handle, resource);


        public Display() {
        }

        ReturnPointerDelegaty delegaty;
        IntPtr display = IntPtr.Zero;
        bool cloasble = false;

        public Display(ReturnPointerDelegaty delegaty) {
            this.delegaty = delegaty;
        }

        public Display(IntPtr dpy, bool closable) {
            display = dpy;
            cloasble = closable;
        }

        public void Assign(IntPtr dpy, bool closable) {
            this.display = dpy;
            this.cloasble = closable;
        }

        public void Assign(ReturnPointerDelegaty delegaty, bool closable) {
            this.delegaty = delegaty;
            this.cloasble = closable;
        }


        public IntPtr Handle =>
            (delegaty != null) ? delegaty() : display;

        public int Close() {
            if (!cloasble || IntPtr.Zero == display) {
                return 0;
            }
            return NativeMethods.XCloseDisplay(display);
        }


        public XStatus Flush() {
            return NativeMethods.XFlush(display);
        }

        public XStatus Sync(bool discard) {
            return NativeMethods.XSync(display, discard);
        }

        // TODO: 元に戻す処理(スタック詰む？)
        public void SetAfterFunction(XSetAfterFunctionDelegaty proc) {
            NativeMethods.XSetAfterFunction(Handle, ()=> proc());
        }

        // TODO: 元に戻す処理
        public void Synchronize(bool onoff) {
            NativeMethods.XSynchronize(Handle, onoff);
        }

        public int Pending() {
            return NativeMethods.XPending(display);
        }

        public XStatus GrabServer() =>
            NativeMethods.XGrabServer(display);


        public XStatus UngrabServer() =>
            NativeMethods.XUngrabServer(display);


        public string GetDisplayName() {
            return GetDisplayName(null);
        }

        public string GetDisplayName(string name) {
            return Marshal.PtrToStringAnsi(
                null != name ? NativeMethods.XDisplayName(name) : NativeMethods.XDisplayNameP(IntPtr.Zero)
                );
        }

        public Colormap DefaultColormap =>
            new Colormap(NativeMethods.DefaultColormap(Handle, DefaultScreen), this);

        public Colormap GetDefaultColormap(int screen) =>
            new Colormap(NativeMethods.DefaultColormap(Handle, screen), this);

        public Window GetRootWindow(int screen) => (new Window(NativeMethods.RootWindow(Handle, screen), this));
        public Window DefaultRootWindow => (new Window(NativeMethods.DefaultRootWindow(Handle), this));

        public int DisplayPlanes => NativeMethods.DisplayPlanes(Handle, DefaultScreen);
        public int GetDisplayPlanes(int screen) => NativeMethods.DisplayPlanes(Handle, screen);

        public int DisplayCells => NativeMethods.DisplayCells(Handle, DefaultScreen);
        public int GetDisplayCells(int screen) => NativeMethods.DisplayCells(Handle, screen);

        public int DefaultDepth => NativeMethods.DefaultDepth(Handle, DefaultScreen);
        public int GetDefaultDepth(int screen) => NativeMethods.DefaultDepth(Handle, screen);
        public Screen GetScreenOfDisplay(int screen) => (new Screen(NativeMethods.ScreenOfDisplay(Handle, screen), this));
        public Screen DefaultScreenOfDisplay => (new Screen(NativeMethods.DefaultScreenOfDisplay(Handle), this));

        public Visual DefaultVisual => (new Visual(NativeMethods.DefaultVisual(Handle, DefaultScreen)));
        public Visual GetDefaultVisual(int screen) => (new Visual(NativeMethods.DefaultVisual(Handle, screen)));

        // DefaultGC

        public ulong BlackPixel => NativeMethods.BlackPixel(Handle, DefaultScreen);
        public ulong GetBlackPixel(int screen) => NativeMethods.BlackPixel(Handle, screen);
        public ulong WhitePixel => NativeMethods.WhitePixel(Handle, DefaultScreen);
        public ulong GetWhitePixel(int screen) => NativeMethods.WhitePixel(Handle, screen);

        public string ServerVendor => Marshal.PtrToStringAnsi(NativeMethods.ServerVendor(Handle));

        public int DefaultScreen => NativeMethods.DefaultScreen(Handle);
        public int ProtocolVersion => NativeMethods.ProtocolVersion(Handle);
        public int ProtocolRevision => NativeMethods.ProtocolRevision(Handle);

        public int ConnectionNumber => NativeMethods.ConnectionNumber(Handle);

        public int QLength => NativeMethods.QLength(Handle);
        public int ScreenCount => NativeMethods.ScreenCount(Handle);
        public int VendorRelease => NativeMethods.VendorRelease(Handle);
        public string DisplayString => Marshal.PtrToStringAnsi(NativeMethods.DisplayString(Handle));
        public int BitmapUnit => NativeMethods.BitmapUnit(Handle);
        public ByteOrder BitmapBitOrder => (ByteOrder)NativeMethods.BitmapBitOrder(Handle);
        public int BitmapPad => NativeMethods.BitmapPad(Handle);
        public int ImageByteOrder => NativeMethods.ImageByteOrder(Handle);
        public int NextRequest => NativeMethods.NextRequest(Handle);
        public ulong LastKnownRequestProcessed => NativeMethods.LastKnownRequestProcessed(Handle);

        public int GetDisplayWidth(int num) => NativeMethods.DisplayWidth(Handle, num);
        public int GetDisplayHeight(int num) => NativeMethods.DisplayHeight(Handle, num);

        public int GetDisplayWidthMM(int num) => NativeMethods.DisplayWidthMM(Handle, num);
        public int GetDisplayHeightMM(int num) => NativeMethods.DisplayHeightMM(Handle, num);

        public KeySym KeycodeToKeysym(uint keycode, uint group, uint level)
            => NativeMethods.XkbKeycodeToKeysym(Handle, keycode, group, level);

        public uint KeysymToKeycode(KeySym keysym)
            => NativeMethods.XKeysymToKeycode(Handle, keysym);

        public KeySym StringToKeysym(string sk)
            => NativeMethods.XStringToKeysym(sk);

        public string KeysymToString(KeySym keysym)
            => Marshal.PtrToStringAnsi(NativeMethods.XKeysymToString(keysym));

        public void ConvertCase(KeySym keysym, out KeySym lower_return, out KeySym upper_return) =>
            NativeMethods.XConvertCase(keysym, out lower_return, out upper_return);

        public XStatus DisplayKeycodes(out int min_keycodes_return, out int max_keycodes_return) =>
            NativeMethods.XDisplayKeycodes(this.Handle, out min_keycodes_return, out max_keycodes_return);


        // int: XSetModifierMapping Display*:display  XModifierKeymap*:modmap  
        public XStatus SetModifierMapping(XModifierKeymap modmap) =>
            NativeMethods.XSetModifierMapping(display, modmap.Handle);


        // XModifierKeymap*: XGetModifierMapping Display*:display  
        public XModifierKeymap GetModifierMapping() =>
            XModifierKeymap.WR(NativeMethods.XGetModifierMapping(Handle));


        public int GrabKey(int keycode, uint modifiers, bool owner_events, GrabMode pointer_mode, GrabMode keyboard_mode) =>
            NativeMethods.XGrabKey(
                this.Handle, keycode, modifiers, this.Handle, owner_events, pointer_mode, keyboard_mode);

        public int UngrabKey(int keycode, uint modifiers) =>
            NativeMethods.XUngrabKey(this.Handle, keycode, modifiers, this.Handle);


        public int GrabButton(uint button, uint modifiers, bool owner_events, EventMask event_mask, GrabMode pointer_mode, GrabMode keyboard_mode, Window confine_to, int cursor) =>
            NativeMethods.XGrabButton(this.Handle, button, modifiers, this.Handle,
                owner_events, event_mask, pointer_mode, keyboard_mode, (null != confine_to) ? confine_to.Handle : IntPtr.Zero, cursor);

        public int UngrabButton(uint button, uint modifiers) =>
            NativeMethods.XUngrabButton(this.Handle, button, modifiers, this.Handle);

        public XStatus SetInputFocus(Window focus, RevertTo revert_to, uint time) =>
            NativeMethods.XSetInputFocus(this.Handle, focus.Handle, revert_to, time);

        public XStatus WarpPointer(Window src_w, Window dest_w, int src_x, int src_y, uint src_width, uint src_height, int dest_x, int dest_y) =>
            NativeMethods.XWarpPointer(this.Handle, 
                (null != src_w) ? src_w.Handle : IntPtr.Zero , dest_w.Handle, src_x, src_y, src_width, src_height, dest_x, dest_y);


        public XFocusInfo GetInputFocus() {
            IntPtr focus_return;
            RevertTo revert_to_return;
            if (XStatus.True != NativeMethods.XGetInputFocus(this.Handle, out focus_return, out revert_to_return)) {
                return null;
            }
            return (new XFocusInfo(this, focus_return, revert_to_return));
        }




        public int NextEvent(TonNurako.X11.Event.XEventArg ev) {
            IntPtr p = IntPtr.Zero;
            var r = NativeMethods.XNextEvent(Handle, ev.handle);
            ev.Assign();
            return r;
        }
        public int PeekEvent(TonNurako.X11.Event.XEventArg ev) {
            int r = NativeMethods.XPeekEvent(Handle, ev.Handle);
            ev.Assign();
            return r;
        }

        public int MaskEvent(EventMask event_mask, TonNurako.X11.Event.XEventArg ev) {
            var r = NativeMethods.XMaskEvent(Handle, event_mask, ev.Handle);
            ev.Assign();
            return r;
        }

        public bool CheckMaskEvent(EventMask event_mask, XEventArg ev) {
            var r = NativeMethods.XCheckMaskEvent(Handle, event_mask, ev.Handle);
            ev.Assign();
            return r;
        }
        
        public bool CheckTypedEvent(Event.XEventType event_type, XEventArg ev) {
            var r = NativeMethods.XCheckTypedEvent(Handle, event_type, ev.Handle);
            ev.Assign();
            return r;
        }

        //TODO： どうすっか考え中
        public int SendEvent(Window w, bool propagate, EventMask event_mask, XSendEventArg event_send) {
            return NativeMethods.XSendEvent(Handle, w.Handle, propagate, event_mask, event_send.Parallelize(event_send.Type));
        }

        public int SendEvent<T>(Window w, bool propagate, EventMask event_mask, T event_send) where T:struct {
            if (Marshal.SizeOf(typeof(T))  < Marshal.SizeOf(typeof(XAnyEvent))) {
                throw new ArgumentOutOfRangeException($"小さい杉: {event_send}({Marshal.SizeOf(typeof(T))}) < {Marshal.SizeOf(typeof(XAnyEvent))}");
            }
            if (Marshal.SizeOf(typeof(T)) > Marshal.SizeOf(typeof(XEvent))) {
                throw new ArgumentOutOfRangeException($"大きい杉: {event_send}({Marshal.SizeOf(typeof(T))}) > {Marshal.SizeOf(typeof(XEvent))}");
            }
            var p = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(XEvent)));
            Marshal.StructureToPtr(event_send, p, true);
            var r = NativeMethods.XSendEvent(Handle, w.Handle, propagate, event_mask, p);
            Marshal.FreeCoTaskMem(p);
            return r;
        }



        public ulong DisplayMotionBufferSize() =>
            NativeMethods.XDisplayMotionBufferSize(Handle);



        public int AllowEvents(Event.EventMode mode, uint time) => NativeMethods.XAllowEvents(Handle, mode, time);

        public bool TranslateCoordinates(Window src_w, Window dest_w, int src_x, int src_y, XCoordinates coord) {
            var r = NativeMethods.XTranslateCoordinates(
                this.Handle, src_w.Handle, dest_w.Handle, src_x, src_y, out coord.destX, out coord.destY, out coord.child);
            if (r) {
                coord.Assign(this);
            }
            return r;
        }


        public Window CreateSimpleWindow(
            Window parent, int x, int y, int width, int height, int border, TonNurako.X11.Color borderColor, TonNurako.X11.Color backgroundColor) {
            var w = NativeMethods.XCreateSimpleWindow(
                Handle,
                (null != parent) ? parent.Handle : IntPtr.Zero,
                x,
                y,
                (uint)width,
                (uint)height,
                (uint)border,
                borderColor.Pixel,
                backgroundColor.Pixel);
            return (new Window(w, this));
        }

        public Window CreateWindow(
            Window parent, int x, int y, int width, int height, int border_width, int depth, WindowClass windowClass, Visual visual, ChangeWindowAttributes valuemask, XSetWindowAttributes attributes) {
            var w = NativeMethods.XCreateWindow(
                Handle,
                (null != parent) ? parent.Handle : IntPtr.Zero, 
                x, 
                y, 
                (uint)width, 
                (uint)height, 
                (uint)border_width, 
                depth,
                windowClass, 
                visual.Handle, 
                valuemask, 
                ref attributes.record);
            return (new Window(w, this));
        }
    }

    public class XFocusInfo {
        Window window;
        public Window Window => window;

        RevertTo revert;
        RevertTo RevertTo => revert;

        public XFocusInfo(Display dpy, IntPtr window, RevertTo revert) {
            this.window = new Window(window, dpy);
            this.revert = revert;
        }
    }

    public class XCoordinates : IDisposable {
        internal IntPtr child = IntPtr.Zero;

        Window window = null;
        public Window Child =>
            (child != IntPtr.Zero) ? window : null;

        internal int destX = 0;
        public int DestX => destX;

        internal int destY = 0;
        public int DestY => destY;

        public XCoordinates() {
        }

        internal void Assign(Display display) {
            if (IntPtr.Zero == child) {
                return;
            }
            if (null == window) {
                window = new Window();
            }
            window.Assign(child, display);
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
}
