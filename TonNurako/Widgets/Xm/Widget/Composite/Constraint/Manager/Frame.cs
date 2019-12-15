//
// ﾄﾝﾇﾗｺ
//
// Widget
//

using System;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// Frame
	/// </summary>
	public class Frame : RowColumn, IMenuWidget
	{

		public Frame()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }

        public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateFrame, parent, ToolkitResources);
			}

			return base.Create (parent);
		}

        /// <summary>
        /// IMenuWidget用
        /// </summary>
        public IChild ExtremeMenuSports {
            get {
                return this;
            }
        }


        /*
        XmFrame Resource Set
        */

        /// XmNmarginWidth XmCMarginWidth Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public override int MarginWidth {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginWidth, 0);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginWidth, value);
            }
        }


        /// XmNmarginHeight XmCMarginHeight Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public override int MarginHeight {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginHeight, 0);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginHeight, value);
            }
        }


        /// XmNshadowType XmCShadowType unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ShadowType ShadowType {
            get {
                return XSports.GetValue<ShadowType>(TonNurako.Motif.ResourceId.XmNshadowType, ShadowType.EtchedIn);
            }
            set {
                XSports.SetValue<ShadowType>(TonNurako.Motif.ResourceId.XmNshadowType, value);
            }
        }

    }
}
