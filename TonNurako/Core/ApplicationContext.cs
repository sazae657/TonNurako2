//
// ﾄﾝﾇﾗｺ
//
//　ﾄﾝﾇﾗｹーｼｮﾝｺﾝﾃｷｽﾄ
//
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.Widgets;

namespace TonNurako {

    /// <summary>
    /// ｱﾌﾟﾘｹーｼｮﾝｺﾝﾃｷｽﾄ
    /// </summary>
    public class ApplicationContext : IDisposable
    {
        /// <summary>
        /// ﾄｯﾌﾟﾚﾍﾞﾙｳｲｼﾞｪｯﾄ
        /// </summary>
        public IShell Shell {
            get; internal set;
        }

        // 内部ｲﾍﾞﾝﾄﾊﾝﾄﾞﾗー
        private TnkEvents<Events.TonNuraEventId, Events.TnkEventArgs> eventTable;

        // ｼｪﾙのﾘｽﾄ
        private Dictionary<Guid, IShell> shellWidgetList;

        // ｳｲｼﾞｪｯﾄ解決ﾃーﾌﾞﾙ(ｺーﾙﾊﾞｯｸとかね)
        private Dictionary<Native.NativeWidget, IWidget> widgetResolutionTable;

        // ﾄﾝﾇﾗｺﾝﾃｷｽﾄ
        public ExtremeSports.TnkAppContext Handle;

        internal Application.SingleThreadSynchronizationContext SyncContext {
            get; set;
        }

        Dictionary<string, string> fallbackResource;

        /// <summary>
        /// ﾌｫーﾙﾊﾞｯｸﾘｿーｽ
        /// </summary>
        public Dictionary<string, string> FallbackResource {
            get { return fallbackResource; }
        }

		/// <summary>
        /// ｱﾌﾟﾘｹーｼｮﾝ名 (ﾄｯﾌﾟﾚﾍﾞﾙの名前になっちゃう)
        /// </summary>
        public string Name {
            get;
            set;
        }

        private int widgetCounter = 0;
        private bool disposed = false;

        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀー
        /// </summary>
        public ApplicationContext() {
            shellWidgetList = new Dictionary<Guid, IShell>();
            eventTable = new TnkEvents<Events.TonNuraEventId, Events.TnkEventArgs>();
            Name = "";
            fallbackResource = new Dictionary<string, string>();
            widgetResolutionTable = new Dictionary<Native.NativeWidget, IWidget>(new Native.NativeWidgetComparer());
            Handle = new ExtremeSports.TnkAppContext();
        }

        /// <summary>
        /// まだ怪しい
        /// </summary>
        public void Invoke(Delegate delegaty, params object[] args) {
            var c = SynchronizationContext.Current;
            try {
                SynchronizationContext.SetSynchronizationContext(SyncContext);
                lock(Shell) {
                    if(null != Shell && Shell.IsAvailable) {
                        ExtremeSports.TriggerPrivateEvent(Shell.AppContext.Handle, Shell);
                    }
                }
                Task t = new Task(()=>{
                        if(null != Shell && Shell.IsAvailable) {
                            ExtremeSports.TriggerPrivateEvent(Shell.AppContext.Handle, Shell);
                        }
                        delegaty.DynamicInvoke(args);
                        if(null != Shell && Shell.IsAvailable) {
                            ExtremeSports.TriggerPrivateEvent(Shell.AppContext.Handle, Shell);
                        }
                    }
                );
                t.Start(TaskScheduler.FromCurrentSynchronizationContext());

            }finally {
                SynchronizationContext.SetSynchronizationContext(c);
            }
        }


        /// <summary>
        /// まだ怪しい(2)
        /// </summary>
        public void Invoke(Action delegaty) {
            var c = SynchronizationContext.Current;
            try {
                SynchronizationContext.SetSynchronizationContext(SyncContext);
                lock(Shell) {
                    if(null != Shell && Shell.IsAvailable) {
                        ExtremeSports.TriggerPrivateEvent(Shell.AppContext.Handle, Shell);
                    }
                }
                Task t = new Task(()=>{
                        if(null != Shell && Shell.IsAvailable) {
                            ExtremeSports.TriggerPrivateEvent(Shell.AppContext.Handle, Shell);
                        }
                        delegaty();
                        if(null != Shell && Shell.IsAvailable) {
                            ExtremeSports.TriggerPrivateEvent(Shell.AppContext.Handle, Shell);
                        }
                    }
                );
                t.Start(TaskScheduler.FromCurrentSynchronizationContext());

            }finally {
                SynchronizationContext.SetSynchronizationContext(c);
            }
        }

        /// <summary>
        /// 名無しのｳｲｼﾞｪｯﾄ用にそれっぽい名前を払い出す
        /// </summary>
        /// <param name="key">ｷー</param>
        /// <returns>ｷー+連番</returns>
		public string CreateTempName(string key)
		{
            return $"{Name}{key}{widgetCounter++:d4}";
		}

        public void Dispose() {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        internal virtual void Dispose(bool disposing) {
            if(disposed) {
                return;
            }
            fallbackResource.Clear();
            fallbackResource = null;
        }

        /// <summary>
        /// Native - TNK 解決ﾘｽﾄに追加
        /// </summary>
        /// <param name="widget">追加するｳｲｼﾞｪｯﾄ</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void RegisterWidget(IWidget widget) {
            if (null == widget.Handle) {
                return;
            }
            if(! widgetResolutionTable.ContainsKey(widget.Handle)) {
                widgetResolutionTable.Add(widget.Handle, widget);
            }
        }


		/// <summary>
		/// Native - TNK 解決
		/// </summary>
		/// <param name="handle">ﾈｲﾃｨﾌﾞのwidget</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public IWidget FindWidgetByHandle(IntPtr handle) {
            if ((IntPtr.Zero == handle)) {
                throw new NullReferenceException("Null Widget");
            }
            IWidget widget;
            if (widgetResolutionTable.TryGetValue(new Native.NativeWidget(handle), out widget)) {
                return widget;
            }
            throw new Exception($"Widget Not Found <{handle}>");

        }

		/// <summary>
		/// Native - TNK 解決ﾘｽﾄから削除
		/// </summary>
		/// <param name="widget">ｳｲｼﾞｪｯﾄ</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UnregisterWidget(IWidget widget) {
            if ((null == widget.Handle)
                || (! widgetResolutionTable.ContainsKey(widget.Handle)))
            {
                return;
            }
            widgetResolutionTable.Remove(widget.Handle);
        }

		/// <summary>
		/// 最下層ｳｲｼﾞｪｯﾄ管理ﾘｽﾄに追加
		/// </summary>
		/// <param name="w">追加するｳｲｼﾞｪｯﾄ</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
		public void AddShellWidget(IShell w )
		{
			//管理ﾘｽﾄに追加
			shellWidgetList.Add(w.UniqueId, w);
		}

		/// <summary>
		/// 管理ﾘｽﾄからｳｲｼﾞｪｯﾄを削除
		/// </summary>
		/// <param name="w">削除するｳｲｼﾞｪｯﾄ</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
		public void RemoveShellWidget(IShell w )
		{
			shellWidgetList.Remove(w.UniqueId);
			w.Dispose();

			//全てのｳｲｼﾞｪｯﾄが消失した場合
			if (shellWidgetList.Count == 0 )
			{
				//ｱﾌﾟﾘｹーｼｮﾝ終了
                eventTable.CallHandler(Events.TonNuraEventId.DestroyContext, this);
				Application.Exit(this);
			}
		}

        /// <summary>
        /// ｺﾝﾃｷｽﾄがﾃﾞｽﾄﾛｲされたｲﾍﾞﾝﾄ
        /// </summary>
		public event EventHandler<Events.TnkEventArgs> DestroyContextEvent
		{
			add {
				eventTable.AddHandler(Events.TonNuraEventId.DestroyContext, value);
			}
			remove {
				eventTable.RemoveHandler(Events.TonNuraEventId.DestroyContext, value);
			}
		}
    }
}
