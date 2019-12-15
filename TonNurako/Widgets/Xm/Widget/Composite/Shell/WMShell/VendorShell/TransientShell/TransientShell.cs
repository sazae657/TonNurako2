//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// TransientShell
	/// </summary>
	public abstract class TransientShell : VendorShell, IDefectiveWidget
	{

		public TransientShell() : base() {
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }


		public override int Create(IWidget parent) {
			return base.Create (parent);
		}


		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNtransientFor XmCTransientFor Widget NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IWidget TransientFor {
            get {
                return XSports.GetWidget<IWidget>(
                    TonNurako.Motif.ResourceId.XmNtransientFor, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetWidget<IWidget>(
                    TonNurako.Motif.ResourceId.XmNtransientFor, value, Data.Resource.Access.CSG);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ

		#endregion

	}
}
