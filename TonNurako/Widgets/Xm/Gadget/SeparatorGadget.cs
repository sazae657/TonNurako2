//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// SeparatorGadget
    /// </summary>
    public class SeparatorGadget : Gadget
    {
		#region ｳｲｼﾞｪｯﾄ作成

		public SeparatorGadget()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		public override int Create(IWidget parent)
		{
			if( !IsAvailable )
			{
				this.CreateMotifGadget(TonNurako.Motif.CreateSymbol.XmCreateSeparatorGadget, parent, ToolkitResources);
			}

			return base.Create (parent);
		}
		#endregion

        /// XmNmargin XmCMargin Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Margin {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmargin, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmargin, value, Data.Resource.Access.CSG);
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

        /// XmNseparatorType XmCSeparatorType unsigned char XmSHADOW_ETCHED_IN CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SeparatorType SeparatorType {
            get {
                return XSports.GetValue<SeparatorType>(
                TonNurako.Motif.ResourceId.XmNseparatorType, SeparatorType.ShadowEtchedIn, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<SeparatorType>(
                    TonNurako.Motif.ResourceId.XmNseparatorType, value, Data.Resource.Access.CSG);
            }
        }
    }
}
