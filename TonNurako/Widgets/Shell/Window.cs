namespace TonNurako.Widgets {

	/// <summary>
	/// 最下層ｳｲｼﾞｪｯﾄ
	/// </summary>
	public class Window : Widgets.Xm.ApplicationShell
	{
		#region ｲﾝｽﾀﾝｽ変数


		#endregion

		#region ｺﾝｽﾄﾗｸﾀー

		/// <summary>
		/// ｺﾝｽﾄﾗｸﾀー
		/// </summary>
		public Window() : base()
		{

		}

		#endregion

		#region 作成

		/// <summary>
		/// 最下層ｳｲｼﾞｪｯﾄの作成
		/// </summary>
		/// <param name="context">ｺﾏﾝﾄﾞﾗｲﾝ引数</param>
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

			return base.Create(context,  args);
		}

		#endregion

	}
}
