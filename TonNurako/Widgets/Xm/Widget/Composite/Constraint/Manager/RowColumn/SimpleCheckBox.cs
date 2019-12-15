//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// SimpleCheckBox
	/// </summary>
	public class SimpleCheckBox : RowColumn, IDefectiveWidget
	{

		public SimpleCheckBox() : base() {

		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }


		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateSimpleCheckBox, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

	}
}
