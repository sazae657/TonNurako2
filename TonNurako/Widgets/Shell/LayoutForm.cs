using TonNurako.Events;

namespace TonNurako.Widgets {

	/// <summary>
	/// 最下層ｳｲｼﾞｪｯﾄ(ﾚｲｱｳﾄ付き)
	/// </summary>
	public class LayoutWindow<T> : Widgets.Xm.ApplicationShell
         where T:Widgets.IManagerWidget,new()
	{
		#region ｲﾝｽﾀﾝｽ変数
		//内包するFormLayout
		private T form;

		//FormLayout作成済みﾌﾗｸﾞ

		#endregion

		#region ｺﾝｽﾄﾗｸﾀー

		/// <summary>
		/// ｺﾝｽﾄﾗｸﾀー
		/// </summary>
		public LayoutWindow() : base() {
		}

		#endregion

		#region 作成

		/// <summary>
		/// 最下層ｳｲｼﾞｪｯﾄの作成
		/// </summary>
		/// <param name="context">ｺﾝﾃｷｽﾄ</param>
        /// <param name="args">ｺﾏﾝﾄﾞﾗｲﾝ引数</param>
		/// <returns></returns>
		public override int Create(ApplicationContext context,  string[] args )
		{
			//名称が何も指定されていない場合
			if( this.Name == "" ) {
				this.Name = this.GetType().Name;
			}

			//ShellWidget作成
			CreateShell(context,  args );

			form = new T();
            form.Create(this);
			this.Children.Add(form);

			//FormLayout作成済みﾌﾗｸﾞを立てる
			//shellFormAvailable = true;

			return base.Create(context,  args);
		}

		#endregion


        /// <summary>
        /// 自身のWidgetを返す
        /// </summary>
        public override Native.NativeWidget Handle
        {
            get
            {
				return selfWidget;
            }
            set {
                selfWidget = value;
            }
        }

		/// <summary>
		/// ｳｲｼﾞｪｯﾄを可視状態に
		/// </summary>
		public override void Realize()
		{
            if(IsShellAvalible) {
                System.Diagnostics.Debug.WriteLine($"Realize: {this.GetType()}");
                TonNurako.Xt.XtSports.XtRealizeWidget(new ﾄﾝﾇﾗｼﾞｪｯﾄ(selfWidget.Widget, null));
                UIeventTable.CallHandler(TonNuraEventId.Realized, this);
            }
		}

		/// <summary>
		/// ｳｲｼﾞｪｯﾄの破壊
		/// </summary>
		override public void Destroy()
		{
			if (IsShellAvalible) {
                form.Destroy();
                IsShellAvalible = false;
            }
            // 親ｸﾗｽに任せる
            base.Destroy();
		}

		/// <summary>
		/// Manager を返す
		/// </summary>
		public T Layout
		{
			get {
				return form;
			}
		}

	}
}
