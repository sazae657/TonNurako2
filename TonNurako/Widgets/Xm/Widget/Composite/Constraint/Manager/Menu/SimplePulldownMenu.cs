//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// SimplePulldownMenu
	/// </summary>
	public class SimplePulldownMenu : SimpleMenuBase
	{

		#region 生成

		public SimplePulldownMenu()  : base()
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
			if( !IsAvailable )
			{
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateSimplePulldownMenu, parent, ToolkitResources);
			}

			return base.Create (parent);
		}

		#endregion

	}
}
