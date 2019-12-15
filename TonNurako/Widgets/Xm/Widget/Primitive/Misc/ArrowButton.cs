//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// ArrowButton
	/// </summary>
	public class ArrowButton : Primitive
	{
		public ArrowButton() : base()
		{
            PushButtonEventTable = new TnkXtEvents<Events.PushButtonEventArgs>();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


		public override int Create(IWidget parent)
		{
			if( !IsAvailable )
			{
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateArrowButton, parent, ToolkitResources);
			}
			return base.Create (parent);
		}


		#region ﾌﾟﾛﾊﾟﾃｨ
        /// XmNarrowDirection XmCArrowDirection unsigned char XmARROW_UP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ArrowDirection ArrowDirection {
            get {
                return XSports.GetValue<ArrowDirection>(TonNurako.Motif.ResourceId.XmNarrowDirection, ArrowDirection.Up);
            }
            set {
                XSports.SetValue<ArrowDirection>(TonNurako.Motif.ResourceId.XmNarrowDirection, value);
            }
        }


        /// XmNdetailShadowThickness XmCDetailShadowThickness Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DetailShadowThickness {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNdetailShadowThickness, 2);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNdetailShadowThickness, value);
            }
        }


        /// XmNmultiClick XmCMultiClick unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual MultiClick MultiClick {
            get {
                return XSports.GetValue<MultiClick>(TonNurako.Motif.ResourceId.XmNmultiClick, MultiClick.Discard);
            }
            set {
                XSports.SetValue<MultiClick>(TonNurako.Motif.ResourceId.XmNmultiClick, value);
            }
        }


        internal TnkXtEvents<Events.PushButtonEventArgs> PushButtonEventTable {
            get;
        }


        /// XmNactivateCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.PushButtonEventArgs> ActivateEvent
        {
            add {
                PushButtonEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNactivateCallback ,  value );
            }
            remove {
                PushButtonEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNactivateCallback ,  value );
            }
        }


        /// XmNarmCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.PushButtonEventArgs> ArmEvent
        {
            add {
                PushButtonEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNarmCallback ,  value );
            }
            remove {
                PushButtonEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNarmCallback ,  value );
            }
        }


        /// XmNdisarmCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.PushButtonEventArgs> DisarmEvent
        {
            add {
                PushButtonEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNdisarmCallback ,  value );
            }
            remove {
                PushButtonEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNdisarmCallback ,  value );
            }
        }


		#endregion

	}
}
