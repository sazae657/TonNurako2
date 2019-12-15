//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// RadioBox
	/// </summary>
	public class RadioBox : RowColumn, IDefectiveWidget
	{

		public RadioBox() : base() {

		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateRadioBox, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

	}
}
