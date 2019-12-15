//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// SimpleRadioBox
	/// </summary>
	public class SimpleRadioBox : RowColumn, IDefectiveWidget
	{

		public SimpleRadioBox() : base() {

		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }


		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateSimpleRadioBox, parent, ToolkitResources);
			}
			return base.Create (parent);
		}


	}
}
