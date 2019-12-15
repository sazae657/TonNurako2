//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// PopupMenu
	/// </summary>
	public class PopupMenu : RowColumn, IDefectiveWidget
	{

		#region 生成


		public PopupMenu() : base() {

		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

        public override bool AllowAutoManage {
            get {return false;}
        }


		/// <summary>
		/// PopupMenu生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreatePopupMenu, parent, ToolkitResources);
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

		#region ﾌﾟﾛﾊﾟﾁー

		#endregion

		#region ｲﾍﾞﾝﾄ

		#endregion

	}
}
