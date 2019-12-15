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
    /// Gadget
    /// </summary>
    public abstract class Gadget : Widget
    {
		public Gadget()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


		public override int Create(IWidget parent)
		{
			return base.Create (parent);
		}


        protected void CreateMotifGadget(
            TonNurako.Motif.CreateSymbol sym, IWidget parent, XResource res)
        {
            if (0 == this.Name.Length) {
                // 名無しは作れないので強制命名
                this.Name = AppContext.CreateTempName(this.GetType().Name);
            }

            IntPtr w = TonNurako.Motif.XmSports.CallCreate2P(sym,
                                    parent,
                                    this.Name,
                                    (null != res) ? res.ToXtArg() : null);

            if (IntPtr.Zero == w) {
                throw new Exception($"{sym.ToString()} failed");
            }
            Handle = new Native.NativeWidget(w);
            if (null != res) {
                res.Clear();
            }
        }


        #region resource
        /// XmNbackground XmCBackground Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color Background {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNbackground);
            }
            set {
            XSports.SetColor(TonNurako.Motif.ResourceId.XmNbackground, value);
            }
        }


        /// XmNbackgroundPixmap XmCPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap BackgroundPixmap {
            get {
                return XSports.GetPixmap(TonNurako.Motif.ResourceId.XmNbackgroundPixmap);
            }
            set {
            XSports.SetPixmap(TonNurako.Motif.ResourceId.XmNbackgroundPixmap, value);
            }
        }


        /// XmNbottomShadowColor XmCBottomShadowColor Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color BottomShadowColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNbottomShadowColor);
            }
            set {
            XSports.SetColor(TonNurako.Motif.ResourceId.XmNbottomShadowColor, value);
            }
        }


        /// XmNbottomShadowPixmap XmCBottomShadowPixmap Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap BottomShadowPixmap {
            get {
                return XSports.GetPixmap(TonNurako.Motif.ResourceId.XmNbottomShadowPixmap);
            }
            set {
            XSports.SetPixmap(TonNurako.Motif.ResourceId.XmNbottomShadowPixmap, value);
            }
        }


        /// XmNforeground XmCForeground Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color Foreground {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNforeground);
            }
            set {
            XSports.SetColor(TonNurako.Motif.ResourceId.XmNforeground, value);
            }
        }


        /// XmNhighlightColor XmCHighlightColor Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color HighlightColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNhighlightColor);
            }
            set {
            XSports.SetColor(TonNurako.Motif.ResourceId.XmNhighlightColor, value);
            }
        }


        /// XmNhighlightOnEnter XmCHighlightOnEnter Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool HighlightOnEnter {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNhighlightOnEnter, false);
            }
            set {
            XSports.SetBool(TonNurako.Motif.ResourceId.XmNhighlightOnEnter, value);
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


        /// XmNhighlightThickness XmCHighlightThickness Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int HighlightThickness {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNhighlightThickness, 2);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNhighlightThickness, value);
            }
        }


        /// XmNlayoutDirection XmNCLayoutDirection XmDirection dynamic CG
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


        /// XmNnavigationType XmCNavigationType XmNavigationType XmNONE CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual NavigationType NavigationType {
            get {
                return XSports.GetValue<NavigationType>(TonNurako.Motif.ResourceId.XmNnavigationType, NavigationType.None);
            }
            set {
            XSports.SetValue<NavigationType>(TonNurako.Motif.ResourceId.XmNnavigationType, value);
            }
        }


        /// XmNshadowThickness XmCShadowThickness Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ShadowThickness {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNshadowThickness, 2);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNshadowThickness, value);
            }
        }


        /// XmNtopShadowColor XmCTopShadowColor Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color TopShadowColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNtopShadowColor);
            }
            set {
            XSports.SetColor(TonNurako.Motif.ResourceId.XmNtopShadowColor, value);
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

        /// XmNtoolTipString XmCToolTipString XmString NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string ToolTipString {
            get {
                return XSports.GetString(TonNurako.Motif.ResourceId.XmNtoolTipString, "");
            }
            set {
            XSports.SetString(TonNurako.Motif.ResourceId.XmNtoolTipString, value);
            }
        }


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


        #endregion
    }

}
