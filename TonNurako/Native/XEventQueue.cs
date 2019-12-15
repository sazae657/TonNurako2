//
// ﾄﾝﾇﾗｺ
//
// ｴｸｽﾄﾘーﾑｽﾎﾟーﾂ
//
using System;
using System.Collections.Generic;
using TonNurako.Xt;
using System.Linq;

namespace TonNurako.Native {

	/// <summary>
	/// XtCallbackQueue
	/// </summary>
	public class XEventQueue
	{
		#region private

		/// <summary>
		/// ｲﾍﾞﾝﾄﾊﾝﾄﾞﾗを溜込む
		/// </summary>
		private struct QueueData
		{
            public ulong EventMask;
			public XtEventHandler Proc;
		}
		#endregion

		#region ｲﾝｽﾀﾝｽ変数

		// ｺーﾙﾊﾞｯｸの追加対象になるWidget
		Widgets.IWidget target;

		List<QueueData> callbacks;
        List<QueueData> activeCallbacks;

		#endregion

		/// <summary>
		/// ｺﾝｽﾄﾗｸﾀー
		/// </summary>
		/// <param name="owner">ｺーﾙﾊﾞｯｸを追加すべきｳｲｼﾞｪｯﾄ</param>
		public XEventQueue( Widgets.IWidget owner )
		{
			callbacks = new List<QueueData>();
            activeCallbacks = new List<QueueData>();
			target = owner;
		}

		#region ｺーﾙﾊﾞｯｸの追加

		/// <summary>
		/// ｺーﾙﾊﾞｯｸの追加(Xt)
		/// </summary>
		/// <param name="mask"></param>
		/// <param name="proc"></param>
		public void AddCallback(ulong mask, XtEventHandler proc )
		{
			QueueData q = new QueueData();

			q.EventMask = mask;
			q.Proc = proc;

			// ﾘｽﾄに追加
            callbacks.Add(q);

			//適用
			Apply();
		}

		/// <summary>
		/// ｺーﾙﾊﾞｯｸの削除
		/// </summary>
		/// <param name="mask"></param>
		public void Remove(ulong mask)
		{
            var cbs = from w in activeCallbacks where w.EventMask == mask select w;
			if (0 == cbs.Count()) {
                return;
            }

			foreach (var q in cbs)
			{
				TonNurako.Xt.XtSports.XtRemoveEventHandler(target,
						q.EventMask,false, q.Proc, IntPtr.Zero);
			}
            activeCallbacks.RemoveAll(x => x.EventMask == mask);
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
            foreach (var q in callbacks) {
                TonNurako.Xt.XtSports.XtAddEventHandler(target,
                    q.EventMask,false, q.Proc, IntPtr.Zero);
                //追加済みに追加
                activeCallbacks.Add(q);
            }

            //既出ｷーを削除
            callbacks.Clear();

            return true;
		}

		/// <summary>
        /// 全消し
        /// </summary>
        public void RemoveAll() {
            foreach(var q in activeCallbacks) {
                System.Diagnostics.Debug.WriteLine($"XEventQueueM<{target.GetType()}>: Remove{q.EventMask}");
                TonNurako.Xt.XtSports.XtRemoveEventHandler(target, q.EventMask, false, q.Proc, IntPtr.Zero);
            }
            activeCallbacks.Clear();
        }


		#endregion

	}

}
