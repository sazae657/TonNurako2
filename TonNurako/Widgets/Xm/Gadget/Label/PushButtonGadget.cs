//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// PushButtonGadget
    /// </summary>
    public class PushButtonGadget : LabelGadget
    {
		#region ｳｲｼﾞｪｯﾄ作成
		public PushButtonGadget()  : base()
		{
            PushButtonEventTable = new TnkXtEvents<Events.PushButtonEventArgs>();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


        TnkXtEvents<Events.PushButtonEventArgs> PushButtonEventTable {
            get;
        }

		public override int Create(IWidget parent)
		{
			if( !IsAvailable )
			{
				this.CreateMotifGadget(TonNurako.Motif.CreateSymbol.XmCreatePushButtonGadget, parent, ToolkitResources);
			}

			return base.Create (parent);
		}
		#endregion


        /// XmNarmColor XmCArmColor Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color ArmColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNarmColor);
            }
            set {
            XSports.SetColor(TonNurako.Motif.ResourceId.XmNarmColor, value);
            }
        }


        /// XmNarmPixmap XmCArmPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap ArmPixmap {
            get {
                return XSports.GetPixmap(TonNurako.Motif.ResourceId.XmNarmPixmap);
            }
            set {
            XSports.SetPixmap(TonNurako.Motif.ResourceId.XmNarmPixmap, value);
            }
        }


        /// XmNdefaultButtonShadowThickness XmCdefaultButtonShadowThickness Dimension dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DefaultButtonShadowThickness {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNdefaultButtonShadowThickness, 2);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNdefaultButtonShadowThickness, value);
            }
        }


        /// XmNfillOnArm XmCFillOnArm Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool FillOnArm {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNfillOnArm, true);
            }
            set {
            XSports.SetBool(TonNurako.Motif.ResourceId.XmNfillOnArm, value);
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


        /// XmNshowAsDefault XmCShowAsDefault Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ShowAsDefault {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNshowAsDefault, 0);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNshowAsDefault, value);
            }
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

    }
}
