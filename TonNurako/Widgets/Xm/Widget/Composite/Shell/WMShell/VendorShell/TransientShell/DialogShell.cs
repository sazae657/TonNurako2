//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// DialogShell
	/// </summary>
	public class DialogShell : TransientShell, IDefectiveWidget
	{

		public DialogShell() : base() {

		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		/// <summary>
		/// DialogShell生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateDialogShell, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

	}
}
