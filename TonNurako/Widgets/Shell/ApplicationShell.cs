
namespace TonNurako.Widgets.Xm {

	/// <summary>
	/// 最下層ｳｲｼﾞｪｯﾄの基底ｸﾗｽ
	/// </summary>
	public partial class ApplicationShell : ShellBase
	{

		#region ｺﾝｽﾄﾗｸﾀー

		/// <summary>
		/// ｺﾝｽﾄﾗｸﾀー
		/// </summary>
		public ApplicationShell() : base()
		{
            InitializeBase();
		}

		#endregion

		#region 作成/破棄
        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        internal override void InitialzieShell(ApplicationContext _Ctx) {
            base.InitialzieShell(_Ctx);
        }


        /// <summary>
        /// ｳｲｼﾞｪｯﾄの破壊
        /// </summary>
		public override  void Destroy()
		{
			//親ｸﾗｽに任せる
			base.Destroy();

			//Applicationの管理ﾘｽﾄから削除
			AppContext.RemoveShellWidget( this );
		}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

		#endregion

	}
}
