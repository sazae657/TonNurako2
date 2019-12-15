//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// SimplePopupMenu
	/// </summary>
	public class SimplePopupMenu : SimpleMenuBase
	{

		#region 生成
		public SimplePopupMenu()  : base()
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
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateSimplePopupMenu, parent, ToolkitResources);
			}

			return base.Create (parent);
		}

		#endregion

        #region 固有
        public void  SetPopupPosition(TonNurako.X11.Event.XButtonEvent ev) {
            TonNurako.Motif.XmSports.XmMenuPosition(this, ev);
        }

        public void  Popup(int x, int y) {
            TonNurako.X11.Event.XButtonEvent ev =new TonNurako.X11.Event.XButtonEvent();
            ev.XRoot = x;
            ev.YRoot = y;
            Popup(ev);
        }

        public void  Popup(TonNurako.X11.Event.XButtonEvent ev) {
            SetPopupPosition(ev);
            Popup();
        }

        public void  Popup() {
            this.Visible = true;
        }

        #endregion
	}
}
