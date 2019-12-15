//
// ﾄﾝﾇﾗｺ
// 
// Widget
//
using System;

namespace TonNurako.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class ServerEvent {
        internal Widgets.WidgetBase Widget {
            get;
        }

        internal ServerEvent(Widgets.WidgetBase widget) {
            ButtonEventTable = new XMaskEventQueue<Events.Server.ButtonEventArgs>();
            MotionEventTable = new XMaskEventQueue<Events.Server.MotionEventArgs>();
            ExposeEventTable = new XMaskEventQueue<Server.ExposeEventArgs>();
            Widget = widget;
        }

        internal XMaskEventQueue<Events.Server.ButtonEventArgs> ButtonEventTable {
            get;
        }
        internal XMaskEventQueue<Events.Server.MotionEventArgs> MotionEventTable {
            get;
        }

        internal XMaskEventQueue<Events.Server.KeymapEventArgs> KeyMapEventTable {
            get;
        }

        internal XMaskEventQueue<Events.Server.ExposeEventArgs> ExposeEventTable {
            get;
        }


        public void AddButtonEvent(TonNurako.X11.EventMask _Mask, EventHandler<Events.Server.ButtonEventArgs> listener) {
            ulong mask = (ulong)_Mask;
            ButtonEventTable.AddHandler(Widget, mask , listener);
        }

        public void AddMotionEvent(TonNurako.X11.EventMask _Mask, EventHandler<Events.Server.MotionEventArgs> listener) {
            ulong mask = (ulong)_Mask;
            MotionEventTable.AddHandler(Widget, mask , listener);
        }

        public virtual event EventHandler<Events.Server.ButtonEventArgs> ButtonPressEvent
        {
            add {
                ButtonEventTable.AddHandler(Widget, (ulong)TonNurako.X11.EventMask.ButtonPressMask ,  value );
            }
            remove {
                ButtonEventTable.RemoveHandler((ulong)TonNurako.X11.EventMask.ButtonPressMask ,  value );
            }
        }


        public virtual event EventHandler<Events.Server.ButtonEventArgs> ButtonReleaseEvent
        {
            add {
                ButtonEventTable.AddHandler(Widget, (ulong)TonNurako.X11.EventMask.ButtonReleaseMask ,  value );
            }
            remove {
                ButtonEventTable.RemoveHandler((ulong)TonNurako.X11.EventMask.ButtonReleaseMask ,  value );
            }
        }

        public virtual event EventHandler<Events.Server.MotionEventArgs> PointerMotionEvent
        {
            add {
                MotionEventTable.AddHandler(Widget, (ulong)TonNurako.X11.EventMask.PointerMotionMask ,  value );
            }
            remove {
                MotionEventTable.RemoveHandler((ulong)TonNurako.X11.EventMask.PointerMotionMask ,  value );
            }
        }

        public virtual event EventHandler<Events.Server.ExposeEventArgs> ExposeEvent {
            add => ExposeEventTable.AddHandler(Widget, (ulong)TonNurako.X11.EventMask.ExposureMask, value);
            remove => ExposeEventTable.RemoveHandler((ulong)TonNurako.X11.EventMask.ExposureMask, value);           
        }
        
    }
}
