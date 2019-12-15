using System;

using TonNurako.Events;
using TonNurako.Native;
using TonNurako.Xt;
namespace TonNurako.Widgets {

	/// <summary>
	/// 最下層ｳｲｼﾞｪｯﾄの基底ｸﾗｽ
	/// </summary>
	public　abstract class ShellBase : WidgetBase, IShell
	{
        private ApplicationContext m_appContext;
        public override ApplicationContext AppContext {
            get {
                return m_appContext;
            }
        }

        public bool IsShellAvalible {
            get; set;
        }

		#region ｺﾝｽﾄﾗｸﾀー

		/// <summary>
		/// ｺﾝｽﾄﾗｸﾀー
		/// </summary>
		public ShellBase() : base()
		{
            IsShellAvalible =  false;
            InitializeBase();
		}

		#endregion

		#region 作成/破棄

        internal virtual void InitialzieShell(ApplicationContext _Ctx) {
            m_appContext = _Ctx;
        }


		/// <summary>
		/// ShellWidgetの作成
		/// </summary>
        /// <param name="context"></param>
        /// <param name="args">ｺﾏﾝﾄﾞﾗｲﾝ引数</param>
		/// <returns></returns>
		internal int CreateShell(ApplicationContext context, string[] args )
		{
            InitialzieShell(context);

			//Applicationの管理ﾘｽﾄに追加
			AppContext.AddShellWidget(this);

			//ShellWidgetの作成
			selfWidget = new Native.NativeWidget(
                ExtremeSports.XtAppCreateShell(m_appContext.Handle, this.Name, ref args, this.ToolkitResources.ToXtArg()));
            this.ToolkitResources.Clear();

            System.Diagnostics.Debug.WriteLine("CTX: display={0} context={1}",
                new object[]{context.Handle.Display, context.Handle.Context});

			//Closeｺーﾙﾊﾞｯｸの追加
			this.CallbackQueue.AaddWMCallback( "WM_DELETE_WINDOW", new XtCallbackProc( this.WMCloseCallBack ));

			//閉じられないように設定
			ToolkitResources.Add( TonNurako.Motif.ResourceId.XmNdeleteResponse, TonNurako.Motif.Constant.XmDO_NOTHING );
			ToolkitResources.SetWidget(true );
            return 0;
		}

        /// <summary>
        /// 最下層ｳｲｼﾞｪｯﾄの作成(1)
        /// </summary>
        /// <param name="context">ｺﾝﾃｷｽﾄ</param>
        /// <param name="args">ｺﾏﾝﾄﾞﾗｲﾝ引数</param>
        /// <returns></returns>
		virtual public int Create(ApplicationContext context, String[] args )
		{
            InitialzieShell(context);

            IsShellAvalible = true;

			//Loadｲﾍﾞﾝﾄを通知
            ShellCreated();
			UIeventTable.CallHandler(TonNuraEventId.WidgetCreated, this);

			foreach(IChild c in this.Children.GetCreationList()) {
                System.Diagnostics.Debug.WriteLine($"CreatChild:{c.GetType()}");
				c.Create( this );
			}

			//全ての子ｳｲｼﾞｪｯﾄをﾏﾈーｼﾞする
			this.ManageChildren();

            return 0;
		}

		/// <summary>
		/// 最下層ｳｲｼﾞｪｯﾄの作成(2)
		/// </summary>
		/// <returns></returns>
		virtual public int Create(ApplicationContext _Ctx)
		{
            InitialzieShell(_Ctx);

			string [] cmdline = new string[1];

			return Create(_Ctx, cmdline );
		}



		/// <summary>
		/// ｳｲｼﾞｪｯﾄの破壊
		/// </summary>
		override public void Destroy()
		{
			//親ｸﾗｽに任せる
			base.Destroy();

			//Applicationの管理ﾘｽﾄから削除
			AppContext.RemoveShellWidget( this );
		}

		/// <summary>
		/// ｳｲｼﾞｪｯﾄを可視状態に
		/// </summary>
		virtual public void Realize()
		{
			TonNurako.Xt.XtSports.XtRealizeWidget(this);
            UIeventTable.CallHandler(TonNuraEventId.Realized, this);
		}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

		#endregion

		#region ｲﾍﾞﾝﾄ

        public virtual void ShellCreated() {}


		/// <summary>
		/// ｳｲｼﾞｪｯﾄを破壊しようとした時
		/// </summary>
		public event EventHandler<TnkEventArgs> ClosingEvent
		{
			add {
				UIeventTable.AddHandler( TonNuraEventId.Closing, value );
			}
			remove {
				UIeventTable.RemoveHandler( TonNuraEventId.Closing, value );
			}
		}

		/// <summary>
		/// ｳｲｼﾞｪｯﾄを破壊しようとした時
		/// </summary>
		public event EventHandler<TnkEventArgs> RealizedEvent
		{
			add {
				UIeventTable.AddHandler( TonNuraEventId.Realized, value );
			}
			remove {
				UIeventTable.RemoveHandler( TonNuraEventId.Realized, value );
			}
		}
		#endregion

		#region ｺーﾙﾊﾞｯｸ

		/// <summary>
		/// ｳｲﾝﾄﾞｳを閉じた時に呼ばれる
		/// </summary>
		private void WMCloseCallBack( IntPtr w, IntPtr client, IntPtr call )
		{
			//Closeｲﾍﾞﾝﾄが通知可能な場合は通知
			if (UIeventTable.CallHandler(TonNuraEventId.Closing, this)) {
                return;
			}
			//Closeｲﾍﾞﾝﾄが通知出来ない場合は容赦無く閉じる
			Destroy();
		}

		#endregion

        #region ﾌﾟﾛﾊﾟﾁー
		/// <summary>
		/// 色深度の取得
		/// </summary>
		public int ColorDepth
		{
			get {
				int depth = XSports.GetInt(TonNurako.Motif.ResourceId.XmNdepth, 0);
				return depth;
			}

		}
        #endregion
    }
}
