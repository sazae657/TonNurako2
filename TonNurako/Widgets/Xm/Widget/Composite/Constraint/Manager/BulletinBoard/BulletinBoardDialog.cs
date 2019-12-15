//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// BulletinBoardDialog
	/// </summary>
	public class BulletinBoardDialog : BulletinBoard
	{

		#region 作成

		public BulletinBoardDialog()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateBulletinBoardDialog, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

		#endregion
	}
}
