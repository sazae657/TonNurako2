//
// ﾄﾝﾇﾗｺ
//
// ｴｸｽﾄﾘーﾑｽﾎﾟーﾂ
//
using System;
using System.Linq;
using System.Collections.Generic;
using TonNurako.Xt;

namespace TonNurako.Native {

	/// <summary>
	/// XtCallbackQueue
	/// </summary>
	public class CallbackQueue
	{
		#region private

		/// <summary>
		/// ｺーﾙﾊﾞｯｸの種類
		/// </summary>
		private enum CallbackType
		{
			Xt,
			WM,
		}

		/// <summary>
		/// ｲﾍﾞﾝﾄﾊﾝﾄﾞﾗーを溜込む
		/// </summary>
		private struct QueueData
		{
			public CallbackType type;
            public string eventName;
			public XtCallbackProc proc;

            public QueueData(CallbackType t, string n, XtCallbackProc p) {
                type = t;
                eventName = n;
                proc = p;
            }
		}
		#endregion


		// ｺーﾙﾊﾞｯｸの追加対象になるWidget
		Widgets.IWidget target;

		List<QueueData> callbacks;
        List<QueueData> activeCallbacks;


		/// <summary>
		/// ｺﾝｽﾄﾗｸﾀー
		/// </summary>
		/// <param name="owner">ｺーﾙﾊﾞｯｸを追加すべきｳｲｼﾞｪｯﾄ</param>
		public CallbackQueue( Widgets.WidgetBase owner )
		{
			callbacks = new List<QueueData>();
            activeCallbacks = new List<QueueData>();
			target = owner;
		}

		#region ｺーﾙﾊﾞｯｸの追加

		/// <summary>
		/// ｺーﾙﾊﾞｯｸの追加(Xt)
		/// </summary>
		/// <param name="eventName"></param>
		/// <param name="proc"></param>
		public void AddXtCallback( string eventName, XtCallbackProc proc )
		{
			callbacks.Add(new QueueData(CallbackType.Xt, eventName, proc));
			//適用
			Apply();
		}
		/// <summary>
		/// ｺーﾙﾊﾞｯｸの追加(Xt)
		/// </summary>
		/// <param name="eventId"></param>
		/// <param name="proc"></param>
		public void AddXtCallback(Enum eventId, XtCallbackProc proc )
        {
            AddXtCallback(ToolkitOptionAttribute.GetToolkitName(eventId), proc);
        }

		/// <summary>
		/// ｺーﾙﾊﾞｯｸの追加(WM)
		/// </summary>
		/// <param name="eventName"></param>
		/// <param name="proc"></param>
		public void AaddWMCallback( string eventName, XtCallbackProc proc )
        {
            callbacks.Add(new QueueData(CallbackType.WM, eventName, proc));
            //適用
			Apply();
		}

		/// <summary>
		/// ｺーﾙﾊﾞｯｸの追加(WM)
		/// </summary>
		/// <param name="eventId"></param>
		/// <param name="proc"></param>
		public void AddWMCallback(Enum eventId, XtCallbackProc proc )
        {
            AaddWMCallback(ToolkitOptionAttribute.GetToolkitName(eventId), proc);
        }

		/// <summary>
		/// ｺーﾙﾊﾞｯｸの削除
		/// </summary>
		public void Remove(string eventName, bool fkd = true)
		{
            var cbs = from w in activeCallbacks where w.eventName == eventName select w;
			if (0 == cbs.Count()) {
                return;
            }

			foreach(var q in cbs) {
                switch( q.type )
                {
                    case CallbackType.Xt:
                        TonNurako.Xt.XtSports.XtRemoveCallback( target,
                            q.eventName, q.proc );
                        break;
                    case CallbackType.WM:
                        ExtremeSports.XmRemoveWMProtocolCallback( target.Handle,
                            q.eventName, q.proc );
                        break;
                }
			}
            if (fkd) {
                activeCallbacks.RemoveAll(x=> x.eventName == eventName);
            }
		}

		public void Remove(Enum eventId)
        {
            Remove(ToolkitOptionAttribute.GetToolkitName(eventId));
        }

		public void RemoveAlll()
        {
            if (null == activeCallbacks) {
                return;
            }
            foreach(var w in activeCallbacks) {
                switch(w.type) {
                    case CallbackType.Xt:
                        TonNurako.Xt.XtSports.XtRemoveCallback( target,
                            w.eventName, w.proc );
                        break;
                    case CallbackType.WM:
                        ExtremeSports.XmRemoveWMProtocolCallback( target.Handle,
                            w.eventName, w.proc );
                        break;
                }
            }
            activeCallbacks.Clear();
            callbacks =  null;
        }

		#endregion

		#region 溜め込んだｺーﾙﾊﾞｯｸの追加

		/// <summary>
		/// 全ｺーﾙﾊﾞｯｸを追加する
		/// </summary>
		/// <returns>true:成功 false:失敗</returns>
		public bool Apply()
		{
			// ｳｲｼﾞｪｯﾄが存在する場合は一気に追加
			if (! target.IsAvailable ) {
                return false;
            }
			//既出ｷー
            foreach(var q in callbacks) {
                switch( q.type )
                {
                    case CallbackType.Xt:
                        TonNurako.Xt.XtSports.XtAddCallback( target,
                            q.eventName, q.proc );
                        break;
                    case CallbackType.WM:
                        ExtremeSports.XmAddWMProtocolCallback( target.Handle,
                            q.eventName, q.proc );
                        break;
                }
                //追加済みに追加
                activeCallbacks.Add(q);
            }
            callbacks.Clear();
            return true;
		}
		#endregion
	}
}
