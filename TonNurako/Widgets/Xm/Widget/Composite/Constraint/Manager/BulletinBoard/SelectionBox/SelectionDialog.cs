//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// SelectionDialog
	/// </summary>
	public class SelectionDialog : SelectionBox
	{
		public SelectionDialog()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


		/// <summary>
		/// 作成
		/// </summary>
		/// <param name="parent">親ｳｲｼﾞｪｯﾄ</param>
		/// <returns></returns>
		public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateSelectionDialog, parent, ToolkitResources);
			}

			return base.Create (parent);
		}
	}

	/// <summary>
	/// PromptDialog
	/// </summary>
	public class PromptDialog : SelectionBox
	{
		public PromptDialog()  : base()
		{

		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
            //標準の名前をｾｯﾄ
        }

        /// <summary>
        /// 作成
        /// </summary>
        /// <param name="parent">親ｳｲｼﾞｪｯﾄ</param>
        /// <returns></returns>
        public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreatePromptDialog, parent, ToolkitResources);
			}

			return base.Create (parent);
		}
	}
}
