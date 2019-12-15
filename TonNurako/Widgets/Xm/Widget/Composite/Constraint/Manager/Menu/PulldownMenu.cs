//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// PulldownMenu
	/// </summary>
	public class PulldownMenu : RowColumn, IMenuWidget
	{

		#region 生成

		public PulldownMenu()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }

        public override bool AllowAutoManage {
            get {return false;}
        }

		public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreatePulldownMenu, parent, ToolkitResources);
			}

			return base.Create (parent);
		}

		#endregion

        /// <summary>
        /// IMenuWidget用
        /// </summary>
        public IChild ExtremeMenuSports {
            get {
                return this;
            }
        }
	}
}
