//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{

	/// <summary>
	/// ButtonBox
	/// </summary>
	public class ButtonBox : Manager, IDefectiveWidget
	{
		public ButtonBox() : base() {

		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		/// <summary>
		/// ButtonBox生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateButtonBox, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNequalSize XmCEqualSize Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool EqualSize {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNequalSize, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNequalSize, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNfillOption XmCFillOption unsigned char XmFillNone CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual FillOption FillOption {
            get {
                return XSports.GetValue<FillOption>(
                TonNurako.Motif.ResourceId.XmNfillOption, FillOption.None, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<FillOption>(
                TonNurako.Motif.ResourceId.XmNfillOption, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginHeight XmCMargin VerticalDimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmarginHeight, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmarginHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginWidth XmCMargin HorizontalDimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmarginWidth, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmarginWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNorientation XmCOrientation unsigned char XmHORIZONTAL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Orientation Orientation {
            get {
                return XSports.GetValue<Orientation>(
                    TonNurako.Motif.ResourceId.XmNorientation, Orientation.Horizontal, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<Orientation>(
                    TonNurako.Motif.ResourceId.XmNorientation, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNdefaultButton XmCWidget Widget NULL SG
        [Data.Resource.SportyResource(Data.Resource.Access.SG)]
        public virtual IWidget DefaultButton {
            get {
                return XSports.GetWidget<IWidget>(
                    TonNurako.Motif.ResourceId.XmNdefaultButton, Data.Resource.Access.SG);
            }
            set {
                XSports.SetWidget<IWidget>(
                    TonNurako.Motif.ResourceId.XmNdefaultButton, value, Data.Resource.Access.SG);
            }
        }

		#endregion


	}
}
