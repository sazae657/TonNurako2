//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// Manager
	/// </summary>
	public abstract class Manager : Constraint, Widgets.IManagerWidget
	{

		internal Manager() : base()
		{
            PopupHandlerEventTable = new TnkXtEvents<Events.PopupHandlerEventArgs>();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        internal TnkXtEvents<Events.PopupHandlerEventArgs> PopupHandlerEventTable {
            get;
        }

		public override int Create( IWidget parent )
		{
			return base.Create( parent );
		}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Managerﾌﾟﾛﾊﾟﾃｨ

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
		public virtual int ShadowThickness
		{
			get {
				return XSports.GetInt(TonNurako.Motif.ResourceId.XmNshadowThickness, 0);
			}
			set{
				XSports.SetInt( TonNurako.Motif.ResourceId.XmNshadowThickness, value );
			}
		}

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color BottomShadowColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNbottomShadowColor);
            }
            set {
                XSports.SetColor(TonNurako.Motif.ResourceId.XmNbottomShadowColor, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color ForegroundColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNforeground);
            }
            set {
                XSports.SetColor(TonNurako.Motif.ResourceId.XmNforeground, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color HighlightColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNhighlightColor);
            }
            set {
                XSports.SetColor(TonNurako.Motif.ResourceId.XmNhighlightColor, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color TopShadowColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNtopShadowColor);
            }
            set {
                XSports.SetColor(TonNurako.Motif.ResourceId.XmNtopShadowColor, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
		public NavigationType NavigationType
		{
			get {
                return XSports.GetValue<NavigationType>(TonNurako.Motif.ResourceId.XmNnavigationType, NavigationType.TabGroup);
			}
			set {
                XSports.SetValue<NavigationType>(TonNurako.Motif.ResourceId.XmNnavigationType, value );
			}
		}

        /// XmNbottomShadowPixmap XmCBottomShadowPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap BottomShadowPixmap {
            get {
                return XSports.GetPixmap(TonNurako.Motif.ResourceId.XmNbottomShadowPixmap);
            }
            set {
            XSports.SetPixmap(TonNurako.Motif.ResourceId.XmNbottomShadowPixmap, value);
            }
        }


        /// XmNhighlightPixmap XmCHighlightPixmap Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap HighlightPixmap {
            get {
                return XSports.GetPixmap(TonNurako.Motif.ResourceId.XmNhighlightPixmap);
            }
            set {
            XSports.SetPixmap(TonNurako.Motif.ResourceId.XmNhighlightPixmap, value);
            }
        }


        /// XmNinitialFocus XmCInitialFocus Widget NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IWidget InitialFocus {
            get {
                return XSports.GetWidget<IWidget>(TonNurako.Motif.ResourceId.XmNinitialFocus);
            }
            set {
                XSports.SetWidget<IWidget>(TonNurako.Motif.ResourceId.XmNinitialFocus, value);
            }
        }


        /// XmNlayoutDirection XmCLayoutDirection XmDirection dynamic CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual Direction LayoutDirection {
            get {
                return XSports.GetValue<Direction>(
                    TonNurako.Motif.ResourceId.XmNlayoutDirection, Direction.DefaultDirection, Data.Resource.Access.CG);
            }
            set {
            XSports.SetValue<Direction>(TonNurako.Motif.ResourceId.XmNlayoutDirection, value, Data.Resource.Access.CG);
            }
        }


        /// XmNstringDirection XmCStringDirection XmStringDirection dynamic CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual StringDirection StringDirection {
            get {
                return XSports.GetValue<StringDirection>(
                    TonNurako.Motif.ResourceId.XmNstringDirection, StringDirection.LtoR, Data.Resource.Access.CG);
            }
            set {
            XSports.SetValue<StringDirection>(TonNurako.Motif.ResourceId.XmNstringDirection, value, Data.Resource.Access.CG);
            }
        }


        /// XmNtopShadowPixmap XmCTopShadowPixmap Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap TopShadowPixmap {
            get {
                return XSports.GetPixmap(TonNurako.Motif.ResourceId.XmNtopShadowPixmap);
            }
            set {
            XSports.SetPixmap(TonNurako.Motif.ResourceId.XmNtopShadowPixmap, value);
            }
        }


        /// XmNtraversalOn XmCTraversalOn Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool TraversalOn {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNtraversalOn, true);
            }
            set {
            XSports.SetBool(TonNurako.Motif.ResourceId.XmNtraversalOn, value);
            }
        }


        /// XmNunitType XmCUnitType unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual UnitType UnitType {
            get {
                return XSports.GetValue<UnitType>(TonNurako.Motif.ResourceId.XmNunitType, UnitType.Pixels);
            }
            set {
                XSports.SetValue<UnitType>(TonNurako.Motif.ResourceId.XmNunitType, value);
            }
        }

        // ### UNKOWN TYPE
        // ### XmNuserData XmCUserData XtPointer NULL CSG

        /// XmNhelpCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> HelpEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNhelpCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNhelpCallback ,  value );
            }
        }


        /// XmNpopupHandlerCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.PopupHandlerEventArgs> PopupHandlerEvent
        {
            add {
                PopupHandlerEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNpopupHandlerCallback ,  value );
            }
            remove {
                PopupHandlerEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNpopupHandlerCallback ,  value );
            }
        }


		#endregion

	}
}

