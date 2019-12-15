//
// ﾄﾝﾇﾗｺ
// 
// Widget
//
using System;
using System.Runtime.InteropServices;
using TonNurako.Xt;

//
// 全然実装してないよ
//

namespace TonNurako.Events.Server
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TnkServerEventArgs<T> : TnkEventArgs {
        public T XEvent {
            get;
            internal set;
        }
        public TnkServerEventArgs() : base() {
        }
        public TnkServerEventArgs(Widgets.IWidget _Sender) {
            Sender = _Sender;
        }


        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            base.ParseXEvent(call, client);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class AnyEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XAnyEvent> {
        public AnyEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent = (TonNurako.X11.Event.XAnyEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XAnyEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ButtonEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XButtonEvent> {
        public ButtonEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent = (TonNurako.X11.Event.XButtonEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XButtonEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MotionEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XMotionEvent> {
        public MotionEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent = (TonNurako.X11.Event.XMotionEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XMotionEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CrossingEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XCrossingEvent> {
        public CrossingEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XCrossingEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XCrossingEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FocusChangeEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XFocusChangeEvent> {
        public FocusChangeEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XFocusChangeEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XFocusChangeEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ExposeEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XExposeEvent> {
        public ExposeEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XExposeEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XExposeEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GraphicsExposeEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XGraphicsExposeEvent> {
        public GraphicsExposeEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XGraphicsExposeEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XGraphicsExposeEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class NoExposeEventEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XNoExposeEvent> {
        public NoExposeEventEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XNoExposeEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XNoExposeEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class VisibilityEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XVisibilityEvent> {
        public VisibilityEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XVisibilityEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XVisibilityEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateWindowEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XCreateWindowEvent> {
        public CreateWindowEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XCreateWindowEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XCreateWindowEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DestroyWindowEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XDestroyWindowEvent> {
        public DestroyWindowEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XDestroyWindowEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XDestroyWindowEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MapEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XMapEvent> {
        public MapEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XMapEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XMapEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MapRequestEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XMapRequestEvent> {
        public MapRequestEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XMapRequestEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XMapRequestEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UnmapEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XUnmapEvent> {
        public UnmapEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XUnmapEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XUnmapEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ReparentEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XReparentEvent> {
        public ReparentEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XReparentEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XReparentEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ConfigureEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XConfigureEvent> {
        public ConfigureEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XConfigureEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XConfigureEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GravityEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XGravityEvent> {
        public GravityEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XGravityEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XGravityEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ResizeRequestEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XResizeRequestEvent> {
        public ResizeRequestEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XResizeRequestEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XResizeRequestEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ConfigureRequestEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XConfigureRequestEvent> {
        public ConfigureRequestEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XConfigureRequestEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XConfigureRequestEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CirculateEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XCirculateEvent> {
        public CirculateEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XCirculateEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XCirculateEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CirculateRequestEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XCirculateRequestEvent> {
        public CirculateRequestEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XCirculateRequestEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XCirculateRequestEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PropertyEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XPropertyEvent> {
        public PropertyEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XPropertyEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XPropertyEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SelectionClearEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XSelectionClearEvent> {
        public SelectionClearEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XSelectionClearEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XSelectionClearEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SelectionRequestEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XSelectionRequestEvent> {
        public SelectionRequestEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XSelectionRequestEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XSelectionRequestEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SelectionEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XSelectionEvent> {
        public SelectionEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XSelectionEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XSelectionEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ColormapEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XColormapEvent> {
        public ColormapEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XColormapEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XColormapEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClientMessageEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XClientMessageEvent> {
        public ClientMessageEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            // 中に XClientMessageEventDataが入ってる
            XEvent =
                (TonNurako.X11.Event.XClientMessageEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XClientMessageEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MappingEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XMappingEvent> {
        public MappingEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XMappingEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XMappingEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ErrorEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XErrorEvent> {
        public ErrorEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XErrorEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XErrorEvent));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class KeymapEventArgs :TnkServerEventArgs<TonNurako.X11.Event.XKeymapEvent> {
        public KeymapEventArgs() : base() {
        }
        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            XEvent =
                (TonNurako.X11.Event.XKeymapEvent)Marshal.PtrToStructure(call, typeof(TonNurako.X11.Event.XKeymapEvent));
        }
    }
}
