using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Event {

    /// <summary>
    /// ｲﾍﾞﾝﾄ定数
    /// </summary>
    public enum XEventType : int {
        KeyPress = TonNurako.X11.Constant.KeyPress,
        KeyRelease = TonNurako.X11.Constant.KeyRelease,
        ButtonPress = TonNurako.X11.Constant.ButtonPress,
        ButtonRelease = TonNurako.X11.Constant.ButtonRelease,
        MotionNotify = TonNurako.X11.Constant.MotionNotify,
        EnterNotify = TonNurako.X11.Constant.EnterNotify,
        LeaveNotify = TonNurako.X11.Constant.LeaveNotify,
        FocusIn = TonNurako.X11.Constant.FocusIn,
        FocusOut = TonNurako.X11.Constant.FocusOut,
        KeymapNotify = TonNurako.X11.Constant.KeymapNotify,
        Expose = TonNurako.X11.Constant.Expose,
        GraphicsExpose = TonNurako.X11.Constant.GraphicsExpose,
        NoExpose = TonNurako.X11.Constant.NoExpose,
        VisibilityNotify = TonNurako.X11.Constant.VisibilityNotify,
        CreateNotify = TonNurako.X11.Constant.CreateNotify,
        DestroyNotify = TonNurako.X11.Constant.DestroyNotify,
        UnmapNotify = TonNurako.X11.Constant.UnmapNotify,
        MapNotify = TonNurako.X11.Constant.MapNotify,
        MapRequest = TonNurako.X11.Constant.MapRequest,
        ReparentNotify = TonNurako.X11.Constant.ReparentNotify,
        ConfigureNotify = TonNurako.X11.Constant.ConfigureNotify,
        ConfigureRequest = TonNurako.X11.Constant.ConfigureRequest,
        GravityNotify = TonNurako.X11.Constant.GravityNotify,
        ResizeRequest = TonNurako.X11.Constant.ResizeRequest,
        CirculateNotify = TonNurako.X11.Constant.CirculateNotify,
        CirculateRequest = TonNurako.X11.Constant.CirculateRequest,
        PropertyNotify = TonNurako.X11.Constant.PropertyNotify,
        SelectionClear = TonNurako.X11.Constant.SelectionClear,
        SelectionRequest = TonNurako.X11.Constant.SelectionRequest,
        SelectionNotify = TonNurako.X11.Constant.SelectionNotify,
        ColormapNotify = TonNurako.X11.Constant.ColormapNotify,
        ClientMessage = TonNurako.X11.Constant.ClientMessage,
        MappingNotify = TonNurako.X11.Constant.MappingNotify,
        GenericEvent = TonNurako.X11.Constant.GenericEvent,
        LASTEvent = TonNurako.X11.Constant.LASTEvent,
    }

    /// <summary>
    /// ﾓーﾄﾞ
    /// </summary>
    public enum EventMode : uint {
        AsyncPointer = TonNurako.X11.Constant.AsyncPointer,
        SyncPointer = TonNurako.X11.Constant.SyncPointer,
        ReplayPointer = TonNurako.X11.Constant.ReplayPointer,
        AsyncKeyboard = TonNurako.X11.Constant.AsyncKeyboard,
        SyncKeyboard = TonNurako.X11.Constant.SyncKeyboard,
        ReplayKeyboard = TonNurako.X11.Constant.ReplayKeyboard,
        AsyncBoth = TonNurako.X11.Constant.AsyncBoth,
        SyncBoth = TonNurako.X11.Constant.SyncBoth,
    }

    public interface IXEvent {

    }

    /// <summary>
    /// XAnyEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XAnyEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;      //ulong?
        public int SendEvent;
        public ulong Display;
        public ulong Window;      //ulong?
    }

    /// <summary>
    /// XKeyEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XKeyEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Window;
        public ulong Root;
        public ulong Subwindow;
        public ulong Time;
        public int X;
        public int Y;
        public int XRoot;
        public int YRoot;
        public uint State;
        public uint KeyCode;
        public int SameScreen;

    }
    /// <summary>
    /// XButtonEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XButtonEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Window;
        public ulong Root;
        public ulong Subwindow;
        public ulong Time;
        public int X;
        public int Y;
        public int XRoot;
        public int YRoot;
        public uint State;
        public uint Button;
        public int SameScreen;
    }

    /// <summary>
    /// XMotionEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XMotionEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Window;
        public ulong Root;
        public ulong Subwindow;
        public ulong Time;
        public int X;
        public int Y;
        public int XRoot;
        public int YRoot;
        public ulong State;
        public char IsHint;
        public int SameScreen;
    }

    /// <summary>
    /// XCrossingEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XCrossingEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Window;
        public ulong Root;
        public ulong Subwindow;
        public ulong Time;
        public int X;
        public int Y;
        public int XRoot;
        public int YRoot;
        public int Mode;
        public int Detail;
        public int SameScreen;
        public int Focus;
        public uint State;
    }

    /// <summary>
    /// XFocusChangeEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XFocusChangeEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Window;
        public int Mode;
        public int Detail;
    }

    /// <summary>
    /// XExposeEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XExposeEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Window;
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public int Count;
    }
    /// <summary>
    /// XGraphicsExposeEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XGraphicsExposeEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Drawable;
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public int Count;
        public int MajorCode;
        public int MinorCode;
    }

    /// <summary>
    /// XNoExposeEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XNoExposeEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Drawable;
        public int MajorCode;
        public int MinorCode;
    }

    /// <summary>
    /// XVisibilityEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XVisibilityEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Window;
        public int State;
    }

    /// <summary>
    /// XCreateWindowEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XCreateWindowEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Parent;
        public ulong Window;
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public int BorderWidth;
        public int OverrideRedirect;
    }

    /// <summary>
    /// XDestroyWindowEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XDestroyWindowEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Xevent;
        public ulong Window;
    }

    /// <summary>
    /// XUnmapEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XUnmapEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Xevent;
        public ulong Window;
        public int FromConfigure;
    }

    /// <summary>
    /// XMapEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XMapEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Xevent;
        public ulong Window;
        public int OverrideRedirect;
    }

    /// <summary>
    /// XMapRequestEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XMapRequestEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Parent;
        public ulong Window;
    }

    /// <summary>
    /// XReparentEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XReparentEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Xevent;
        public ulong Window;
        public ulong Parent;
        public int X;
        public int Y;
        public int OverrideRedirect;
    }

    /// <summary>
    /// XConfigureEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XConfigureEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Xevent;
        public ulong Window;
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public int BorderWidth;
        public ulong Above;
        public int OverrideRedirect;
    }

    /// <summary>
    /// XGravityEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XGravityEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Xevent;
        public ulong Window;
        public int X;
        public int Y;
    }

    /// <summary>
    /// XResizeRequestEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XResizeRequestEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Window;
        public int Width;
        public int Height;
    }

    /// <summary>
    /// XConfigureRequestEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XConfigureRequestEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Parent;
        public ulong Window;
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public int BorderWidth;
        public ulong Above;
        public int Detail;
        public ulong ValueMask;
    }

    /// <summary>
    /// XCirculateEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XCirculateEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Xevent;
        public ulong Window;
        public int Place;
    }

    /// <summary>
    /// XCirculateRequestEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XCirculateRequestEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Parent;
        public ulong Window;
        public int Place;
    }

    /// <summary>
    /// XPropertyEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XPropertyEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Window;
        public ulong Atom;
        public ulong Time;
        public int State;
    }

    /// <summary>
    /// XSelectionClearEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XSelectionClearEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Window;
        public ulong Selection;
        public ulong Time;
    }

    /// <summary>
    ///  XSelectionRequestEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XSelectionRequestEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Owner;
        public ulong Requestor;
        public ulong Selection;
        public ulong Target;
        public ulong Property;
        public ulong Time;
    }

    /// <summary>
    ///  XSelectionEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XSelectionEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Requestor;
        public ulong Selection;
        public ulong Target;
        public ulong Property;
        public ulong Time;
    }

    /// <summary>
    /// XColormapEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XColormapEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Window;
        public ulong Colormap;
        public int Xnew;
        public int State;
    }
    #region むり
    /// <summary>
    /// XClientMessageEventData( XClientMessageEvent内のdata共用体)
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 40, Pack = 1)]
    public struct _XClientMessageEventData {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        [FieldOffset(0)]
        public byte[] b;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        [FieldOffset(0)]
        public short[] s;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        [FieldOffset(0)]
        public int[] l;
    }

    /// <summary>
    /// XClientMessageEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct _XClientMessageEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType type;
        public ulong serial;
        public int send_event;
        public ulong display;
        public ulong window;
        public ulong message_type;
        public int format;
        //public _XClientMessageEventData data;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public fixed long l[5];
    }
    #endregion

    /// <summary>
    /// XClientMessageEventData( XClientMessageEvent内のdata共用体)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XClientMessageEventData {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] B;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public short[] S;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public long[] L;
    }

    /// <summary>
    /// XClientMessageEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XClientMessageEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Window;
        public ulong MessageType;
        public int Format;
        public XClientMessageEventData Data;
    }


    /// <summary>
    /// XMappingEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XMappingEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Window;
        public int Request;
        public int FirstKeyCode;
        public int Count;
    }

    /// <summary>
    ///  XErrorEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XErrorEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Display;
        public int ResourceId;
        public ulong Serial;

        [MarshalAs(UnmanagedType.U1)]
        public ErrorCode ErrorCode;

        [MarshalAs(UnmanagedType.U1)]
        public RequestCode RequestCode;
        public byte MinorCode;
    }

    /// <summary>
    /// XKeymapEvent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XKeymapEvent : IXEvent {
        [MarshalAs(UnmanagedType.I4)]
        public XEventType Type;
        public ulong Serial;
        public int SendEvent;
        public ulong Display;
        public ulong Window;

        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public fixed byte KeyVector[32];
    }

    /// <summary>
    /// XEvent
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct XEvent {
        [FieldOffset(0)] [MarshalAs(UnmanagedType.I4)] public XEventType Type;
        [FieldOffset(0)] public XAnyEvent Any;
        [FieldOffset(0)] public XKeyEvent Key;
        [FieldOffset(0)] public XButtonEvent Button;
        [FieldOffset(0)] public XMotionEvent Motion;
        [FieldOffset(0)] public XCrossingEvent Crossing;
        [FieldOffset(0)] public XFocusChangeEvent Focus;
        [FieldOffset(0)] public XExposeEvent Expose;
        [FieldOffset(0)] public XGraphicsExposeEvent GraphicsExpose;
        [FieldOffset(0)] public XNoExposeEvent NoExpose;
        [FieldOffset(0)] public XVisibilityEvent Visibility;
        [FieldOffset(0)] public XCreateWindowEvent CreateWindow;
        [FieldOffset(0)] public XDestroyWindowEvent DestroyWindow;
        [FieldOffset(0)] public XUnmapEvent Unmap;
        [FieldOffset(0)] public XMapEvent Map;
        [FieldOffset(0)] public XMapRequestEvent MapRequest;
        [FieldOffset(0)] public XReparentEvent Reparent;
        [FieldOffset(0)] public XConfigureEvent Configure;
        [FieldOffset(0)] public XGravityEvent Gravity;
        [FieldOffset(0)] public XResizeRequestEvent ResizeRequest;
        [FieldOffset(0)] public XConfigureRequestEvent ConfigureRequest;
        [FieldOffset(0)] public XCirculateEvent Circulate;
        [FieldOffset(0)] public XCirculateRequestEvent CirculateRequest;
        [FieldOffset(0)] public XPropertyEvent Property;
        [FieldOffset(0)] public XSelectionClearEvent SelectionClear;
        [FieldOffset(0)] public XSelectionRequestEvent SelectionRequest;
        [FieldOffset(0)] public XSelectionEvent Selection;
        [FieldOffset(0)] public XColormapEvent Colormap;
        [FieldOffset(0)] public _XClientMessageEvent Client;
        [FieldOffset(0)] public XMappingEvent Mapping;
        [FieldOffset(0)] public XErrorEvent Error;
        [FieldOffset(0)] public XKeymapEvent Keymap;

        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        [FieldOffset(0)]
        public fixed long pad[24];

    }

    public class XEventArg : IX11Interop, IDisposable {

        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_IMP_SplitXClientMessageEventData", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr TNK_IMP_SplitXClientMessageEventData(IntPtr src, ref XClientMessageEvent ev, [In,Out]IntPtr datum);
        }

        internal IntPtr handle;
        public IntPtr Handle => handle;

        bool handleAllocated = false;

        XAnyEvent xevent;
        public XAnyEvent XEvent => xevent;

        public XEventType Type => xevent.Type;

        Display display;
        public Display Display => display;

        Window window;
        public Window Window => window;

        Dictionary<Type, object> even;

        bool cmSplitted;
        XClientMessageEvent clientMessageEvent;

        public XEventArg() {
            display = new Display();
            window = new Window();
            even = new Dictionary<Type, object>();
            handle = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(XEvent)));
            handleAllocated = true;
            cmSplitted = false;
        }

        internal XEventArg(IntPtr href) {
            handle = href;
            handleAllocated = false;
            cmSplitted = false;
        }

        public void Assign() {
            this.xevent = (XAnyEvent)Marshal.PtrToStructure(Handle, typeof(XAnyEvent));
            display.Assign((IntPtr)XEvent.Display, false);
            window.Assign((IntPtr)XEvent.Window, display);
            cmSplitted = false;
            even.Clear();
        }

        T CastReturn<T>() {
            Type t = typeof(T);
            if (!even.ContainsKey(t)) {
                even[t] = Marshal.PtrToStructure(Handle, typeof(T));
            }
            return (T)even[t];
        }

        public XAnyEvent Any => CastReturn<XAnyEvent>();
        public XKeyEvent Key => CastReturn<XKeyEvent>();
        public XButtonEvent Button => CastReturn<XButtonEvent>();
        public XMotionEvent Motion => CastReturn<XMotionEvent>();
        public XCrossingEvent Crossing => CastReturn<XCrossingEvent>();
        public XFocusChangeEvent FocusChange => CastReturn<XFocusChangeEvent>();
        public XExposeEvent Expose => CastReturn<XExposeEvent>();
        public XGraphicsExposeEvent GraphicsExpose => CastReturn<XGraphicsExposeEvent>();
        public XNoExposeEvent NoExpose => CastReturn<XNoExposeEvent>();
        public XVisibilityEvent Visibility => CastReturn<XVisibilityEvent>();
        public XCreateWindowEvent CreateWindow => CastReturn<XCreateWindowEvent>();
        public XDestroyWindowEvent DestroyWindow => CastReturn<XDestroyWindowEvent>();
        public XUnmapEvent Unmap => CastReturn<XUnmapEvent>();
        public XMapEvent Map => CastReturn<XMapEvent>();
        public XMapRequestEvent MapRequest => CastReturn<XMapRequestEvent>();
        public XReparentEvent Reparent => CastReturn<XReparentEvent>();
        public XConfigureEvent Configure => CastReturn<XConfigureEvent>();
        public XGravityEvent Gravity => CastReturn<XGravityEvent>();
        public XResizeRequestEvent ResizeRequest => CastReturn<XResizeRequestEvent>();
        public XConfigureRequestEvent ConfigureRequest => CastReturn<XConfigureRequestEvent>();
        public XCirculateEvent Circulate => CastReturn<XCirculateEvent>();
        public XCirculateRequestEvent CirculateRequest => CastReturn<XCirculateRequestEvent>();
        public XPropertyEvent Property => CastReturn<XPropertyEvent>();
        public XSelectionClearEvent SelectionClear => CastReturn<XSelectionClearEvent>();
        public XSelectionRequestEvent SelectionRequest => CastReturn<XSelectionRequestEvent>();
        public XSelectionEvent Selection => CastReturn<XSelectionEvent>();
        public XColormapEvent Colormap => CastReturn<XColormapEvent>();
        public XMappingEvent Mapping => CastReturn<XMappingEvent>();
        public XErrorEvent Error => CastReturn<XErrorEvent>();
        public XKeymapEvent Keymap => CastReturn<XKeymapEvent>();

        public XClientMessageEvent ClientMessage {
            get {
                if (!cmSplitted) {
                    clientMessageEvent = new XClientMessageEvent();
                    NativeMethods.TNK_IMP_SplitXClientMessageEventData(Handle, ref clientMessageEvent, IntPtr.Zero);
                    cmSplitted = true;
                    //var k = Marshal.PtrToStructure<_XClientMessageEvent>(Handle);
                    //clientMessageEvent.data.b = new byte[20];
                    //clientMessageEvent.data.s = new short[10];
                    //clientMessageEvent.data.l = new long[5];
                    //clientMessageEvent.type = k.type;
                }
                return clientMessageEvent;
            }
        }


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (handle != IntPtr.Zero) {
                    if (handleAllocated) {
                        Marshal.FreeHGlobal(handle);
                    }
                    handle = IntPtr.Zero;
                }
                disposedValue = true;
            }
        }

        ~XEventArg() {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class XSendEventArg : IX11Interop, IDisposable {

        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_AssembleEventArg", CharSet = CharSet.Auto)]
            internal static extern void TNK_AssembleEventArg([In,Out] IntPtr e, XEventType type, IntPtr display, IntPtr window);
        }


        internal IntPtr handle;
        public IntPtr Handle => handle;
        bool handleAllocated = false;

        public XSendEventArg() {
            handle = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(XEvent)));
            handleAllocated = true;
        }

        public Display Display { get; set; }
        public Window Window { get; set; }
        public XEventType Type { get; set; }

        IntPtr CastReturn<T>(T t) {
            Marshal.StructureToPtr<T>(t, handle, true);
            NativeMethods.TNK_AssembleEventArg(handle, Type, Display.Handle, Window.Handle);
            return handle;
        }

        internal IntPtr Parallelize(XEventType type) {
            switch (type) {
                case XEventType.KeyPress:
                    return CastReturn(Key);
                case XEventType.KeyRelease:
                    return CastReturn(Key);

                case XEventType.ButtonPress:
                    return CastReturn(Button);
                case XEventType.ButtonRelease:
                    return CastReturn(Button);

                case XEventType.MotionNotify:
                    return CastReturn(Motion);

                case XEventType.EnterNotify:
                    return CastReturn(Crossing);
                case XEventType.LeaveNotify:
                    return CastReturn(Crossing);

                case XEventType.FocusIn:
                    return CastReturn(FocusChange);
                case XEventType.FocusOut:
                    return CastReturn(FocusChange);

                case XEventType.KeymapNotify:
                    return CastReturn(Keymap);

                case XEventType.Expose:
                    return CastReturn(Expose);

                case XEventType.GraphicsExpose:
                    return CastReturn(GraphicsExpose);

                case XEventType.NoExpose:
                    return CastReturn(NoExpose);

                case XEventType.VisibilityNotify:
                    return CastReturn(Visibility);

                case XEventType.CreateNotify:
                    return CastReturn(CreateWindow);

                case XEventType.DestroyNotify:
                    return CastReturn(DestroyWindow);

                case XEventType.UnmapNotify:
                    return CastReturn(Unmap);

                case XEventType.MapNotify:
                    return CastReturn(Map);

                case XEventType.MapRequest:
                    throw new NotImplementedException("MapRequest");

                case XEventType.ReparentNotify:
                    return CastReturn(Reparent);

                case XEventType.ConfigureNotify:
                    return CastReturn(Configure);

                case XEventType.ConfigureRequest:
                    return CastReturn(ConfigureRequest);

                case XEventType.GravityNotify:
                    return CastReturn(Gravity);

                case XEventType.ResizeRequest:
                    return CastReturn(ResizeRequest);

                case XEventType.CirculateNotify:
                    return CastReturn(Circulate);

                case XEventType.CirculateRequest:
                    return CastReturn(CirculateRequest);

                case XEventType.PropertyNotify:
                    return CastReturn(Property);

                case XEventType.SelectionClear:
                    return CastReturn(SelectionClear);

                case XEventType.SelectionRequest:
                    return CastReturn(SelectionRequest);

                case XEventType.SelectionNotify:
                    return CastReturn(Selection);

                case XEventType.ColormapNotify:
                    return CastReturn(Colormap);

                case XEventType.ClientMessage:  
                    unsafe {
                        var x = new _XClientMessageEvent();
                        x.type = ClientMessage.Type;
                        x.serial = ClientMessage.Serial;
                        x.send_event = ClientMessage.SendEvent;
                        x.display = ClientMessage.Display;
                        x.window = ClientMessage.Window;
                        x.message_type = ClientMessage.MessageType;
                        x.format = ClientMessage.Format;
                        //Marshal.Copy(ClientMessage.Data.L, 0, x.l, 5); // TODO:いやまじ無理
                        return CastReturn(x);
                    }
                case XEventType.MappingNotify:
                    return CastReturn(Mapping);

                case XEventType.GenericEvent:
                    return CastReturn(Any);
                default:
                    throw new ArgumentException($"UNKNOWN Event: {type}");
            }
        }


        //TODO: XClientMessageEvent保留
        public XAnyEvent Any;
        public XKeyEvent Key;
        public XButtonEvent Button;
        public XMotionEvent Motion;
        public XCrossingEvent Crossing;
        public XFocusChangeEvent FocusChange;
        public XExposeEvent Expose;
        public XGraphicsExposeEvent GraphicsExpose;
        public XNoExposeEvent NoExpose;
        public XVisibilityEvent Visibility;
        public XCreateWindowEvent CreateWindow;
        public XDestroyWindowEvent DestroyWindow;
        public XUnmapEvent Unmap;
        public XMapEvent Map;
        public XMapRequestEvent MapRequest;
        public XReparentEvent Reparent;
        public XConfigureEvent Configure;
        public XGravityEvent Gravity;
        public XResizeRequestEvent ResizeRequest;
        public XConfigureRequestEvent ConfigureRequest;
        public XCirculateEvent Circulate;
        public XCirculateRequestEvent CirculateRequest;
        public XPropertyEvent Property;
        public XSelectionClearEvent SelectionClear;
        public XSelectionRequestEvent SelectionRequest;
        public XSelectionEvent Selection;
        public XColormapEvent Colormap;
        public XMappingEvent Mapping;
        public XErrorEvent Error;
        public XKeymapEvent Keymap;
        public XClientMessageEvent ClientMessage;

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (handle != IntPtr.Zero) {
                    if (handleAllocated) {
                        Marshal.FreeHGlobal(handle);
                    }
                    handle = IntPtr.Zero;
                }
                disposedValue = true;
            }
        }

        ~XSendEventArg() {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        #endregion
    }
}
