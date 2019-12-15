//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// SimpleMenuBar
	/// </summary>
	public class SimpleMenuBar : RowColumn
	{

		#region 生成
		public SimpleMenuBar()  : base()
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
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateSimpleMenuBar, parent, ToolkitResources);
			}

			return base.Create (parent);
		}

		#endregion
	}
}
