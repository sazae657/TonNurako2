//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// MenuBar
	/// </summary>
	public class MenuBar : RowColumn
	{

		#region 生成

		public MenuBar()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		public override int Create( IWidget parent )
		{
			if( !IsAvailable )
			{
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateMenuBar, parent, ToolkitResources);
			}

			return base.Create (parent);
		}

		#endregion
	}
}
