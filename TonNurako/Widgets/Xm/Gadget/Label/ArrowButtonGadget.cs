//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// ArrowButtonGadget
    /// </summary>
    public class ArrowButtonGadget : Gadget
    {
		public ArrowButtonGadget()  : base()
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
				this.CreateMotifGadget(TonNurako.Motif.CreateSymbol.XmCreateArrowButtonGadget, parent, ToolkitResources);
			}

			return base.Create (parent);
		}


        /// XmNarrowDirection XmCArrowDirection unsigned char XmARROW_UP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ArrowDirection ArrowDirection {
            get {
                return XSports.GetValue<ArrowDirection>(
                    TonNurako.Motif.ResourceId.XmNarrowDirection, ArrowDirection.Up, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<ArrowDirection>(
                    TonNurako.Motif.ResourceId.XmNarrowDirection, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNdetailShadowThickness XmCDetailShadowThickness Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DetailShadowThickness {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNdetailShadowThickness, 2, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNdetailShadowThickness, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmultiClick XmCMultiClick unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual MultiClick MultiClick {
            get {
                return XSports.GetValue<MultiClick>(
                    TonNurako.Motif.ResourceId.XmNmultiClick, MultiClick.Discard, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<MultiClick>(
                    TonNurako.Motif.ResourceId.XmNmultiClick, value, Data.Resource.Access.CSG);
            }
        }


        /// XmNactivateCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> ActivateEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNactivateCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNactivateCallback ,  value );
            }
        }

        /// XmNarmCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> ArmEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNarmCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNarmCallback ,  value );
            }
        }

        /// XmNdisarmCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> DisarmEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNdisarmCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNdisarmCallback ,  value );
            }
        }
    }
}
