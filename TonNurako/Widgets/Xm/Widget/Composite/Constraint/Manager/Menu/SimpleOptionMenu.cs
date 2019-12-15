//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Data;
using TonNurako.Events;
using TonNurako.Native;

namespace TonNurako.Widgets.Xm
{


	/// <summary>
	/// SimpleOptionMenu
	/// </summary>
	public class SimpleOptionMenu : SimpleMenuBase
	{

		#region 生成

		public SimpleOptionMenu()  : base()
		{
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }

		public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
                AddInternalEventHandler();
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateSimpleOptionMenu, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

		#endregion

	}
}
