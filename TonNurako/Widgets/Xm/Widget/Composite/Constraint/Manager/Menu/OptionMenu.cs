//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// OptionMenu
	/// </summary>
	public class OptionMenu : RowColumnBase, IDefectiveWidget
	{
		#region 生成
		public OptionMenu() : base()
		{

		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		/// <summary>
		/// OptionMenu生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent)
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateOptionMenu, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
		#endregion

        /*
        これ実装してない
        Widget XmOptionLabelGadget(Widget option_menu);
        Widget XmOptionButtonGadget(Widget option_menu);
        */

		#region ﾌﾟﾛﾊﾟﾁー

		#endregion

		#region ｲﾍﾞﾝﾄ

		#endregion

	}
}
