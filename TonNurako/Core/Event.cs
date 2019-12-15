//
// ﾄﾝﾇﾗｺ
//
//　ｲﾍﾞﾝﾄ
//

using System;
using System.Collections.Generic;
namespace TonNurako {
    /// <summary>
	/// ｲﾍﾞﾝﾄ
	/// </summary>
	public class TnkEvents<T_Key, E_Type>
        where E_Type : Events.TnkEventArgs,new()
    {
		private Dictionary<T_Key, EventHandler<E_Type>> eventTable = null;

		/// <summary>
		/// ｺﾝｽﾄﾗｸﾀー
		/// </summary>
		public TnkEvents()
		{
			eventTable = new Dictionary<T_Key, EventHandler<E_Type>>();
		}

		/// <summary>
		/// ｲﾍﾞﾝﾄﾊﾝﾄﾞﾗの追加
		/// </summary>
		/// <param name="n">ｲﾍﾞﾝﾄの識別子</param>
		/// <param name="e">通知先</param>
		public void AddHandler(T_Key n, EventHandler<E_Type> e )
		{
            if (! eventTable.ContainsKey(n)) {
                eventTable.Add(n, e);
                return;
            }
            eventTable[n] = eventTable[n] + e;
		}

		/// <summary>
		/// ｲﾍﾞﾝﾄﾊﾝﾄﾞﾗの削除
		/// </summary>
		/// <param name="n">ｲﾍﾞﾝﾄの識別子</param>
		/// <param name="e">通知先</param>
		public void RemoveHandler(T_Key n, EventHandler<E_Type> e )
		{
            if (! eventTable.ContainsKey(n)) {
                return;
            }
			eventTable[n] = eventTable[n] - e;
            if (null == eventTable[n]) {
                eventTable.Remove(n);
            }
		}

        public bool CallHandler(T_Key n, Object sender) {
            return CallHandler(n, sender, null);
        }

        public bool CallHandler(T_Key n, Object sender, E_Type e) {
            if (! eventTable.ContainsKey(n)) {
                return false;
            }
            eventTable[n](sender, e);
            return true;
        }

        public bool HasHandler(T_Key n) {
            return eventTable.ContainsKey(n);
        }

	}

    /// <summary>
	/// XToolkitのｲﾍﾞﾝﾄ
	/// </summary>
    public class TnkXtEvents<E_Type> : TnkEvents<Enum,E_Type>
        where E_Type : Events.TnkEventArgs,new()
	{
		public TnkXtEvents() : base()
		{
		}


        /// <summary>
        /// XtCallbackListの登録
        /// </summary>
        /// <param name="widget">ういじぇっと</param>
        /// <param name="n">ｲﾍﾞﾝﾄ</param>
        /// <param name="e">ﾊﾝﾄﾞﾗー</param>
		public void AddHandler(Widgets.WidgetBase widget, Enum n, EventHandler<E_Type> e)
		{
            if(! HasHandler(n)) {
                TonNurako.Xt.XtCallbackProc cb =
                 (w, client, call) => {
                            this.CallHandler(n, widget,
                                ((Func<E_Type>)(() => {
                                    var t = new E_Type();
                                    t.Sender = widget;
                                    t.ParseXEvent(call, client);
                                    return t;
                                }))());
                        };
                widget.CallbackQueue.AddXtCallback(n, cb);
            }
            AddHandler(n, e);
		}

        /// <summary>
        /// ﾘｿーｽに登録しなければならない系の登録
        /// </summary>
        /// <param name="widget">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="n">ｲﾍﾞﾝﾄ</param>
        /// <param name="e">ﾊﾝﾄﾞﾗー</param>
		public void AddHandlerToRes(Widgets.WidgetBase widget, Enum n, EventHandler<E_Type> e)
		{
            if(! HasHandler(n)) {
                TonNurako.Xt.XtCallbackProc cb =
                 (w, client, call) => {
                            this.CallHandler(n, widget,
                                ((Func<E_Type>)(() => {
                                    var t = new E_Type();
                                    t.Sender = widget;
                                    t.ParseXEvent(call, client);
                                    return t;
                                }))());
                        };
                widget.ToolkitResources.Add(n, cb);
            }
            AddHandler(n, e);
		}
    }

    /// <summary>
	/// Xｻーﾊﾞーのｲﾍﾞﾝﾄ
	/// </summary>
    public class XMaskEventQueue<E_Type> : TnkEvents<ulong,E_Type>
        where E_Type : Events.TnkEventArgs,new()
	{
		public XMaskEventQueue() : base()
		{
		}

        /// <summary>
        /// Xのｲﾍﾞﾝﾄﾏｽｸ登録
        /// </summary>
        /// <param name="widget">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="mask">ｲﾍﾞﾝﾄﾏｽｸ</param>
        /// <param name="e">ﾊﾝﾄﾞﾗー</param>
        public void AddHandler(Widgets.WidgetBase widget, ulong mask, EventHandler<E_Type> e ){
            if(! HasHandler(mask)) {
                widget.XEventQueue.AddCallback(mask,
                        (w,  closure,  xevent,  continue_to_dispatch) => {
                        this.CallHandler(
                            mask, widget,
                            ((Func<E_Type>)(() => {
                                var t = new E_Type();
                                t.Sender = widget;
                                t.ParseXEvent(xevent, IntPtr.Zero);
                                return t;
                            }))());
                } );
            }
            AddHandler(mask, e);
        }
    }
 }
