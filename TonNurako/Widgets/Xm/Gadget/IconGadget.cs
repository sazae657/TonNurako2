//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using TonNurako.Data;
using TonNurako.Native;

namespace TonNurako.Widgets.Xm
{

    /// <summary>
    /// IconGadget
    /// </summary>
    public class IconGadget : Gadget
    {
        #region 定数(どっかに追い出したい)
        public enum IconType {
            LargeIcon = TonNurako.Motif.Constant.XmLARGE_ICON,
            SmallIcon = TonNurako.Motif.Constant.XmSMALL_ICON,
        }
        public enum SelectState {
            Selected = TonNurako.Motif.Constant.XmSELECTED,
            NotSelected = TonNurako.Motif.Constant.XmNOT_SELECTED,
        }
        #endregion

		#region 生成

		public IconGadget()  : base()
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
				this.CreateMotifGadget(TonNurako.Motif.CreateSymbol.XmCreateIconGadget, parent, ToolkitResources);
			}

			return base.Create (parent);
		}
		#endregion

        ///  XmNrenderTable XmCRenderTable XmRenderTable dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable RenderTable {
            get {
                return XSports.GetRenderTable(
                    TonNurako.Motif.ResourceId.XmNrenderTable, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetRenderTable(
                    TonNurako.Motif.ResourceId.XmNrenderTable, value, Data.Resource.Access.CSG);
            }
        }

        /// Xmalignment XmCAlignment unsigned char XmALIGNMENT_CENTER CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Alignment Lignment {
            get {
                return XSports.GetValue<Alignment>(
                    TonNurako.Motif.ResourceId.XmNalignment, Alignment.Center, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<Alignment>(
                TonNurako.Motif.ResourceId.XmNalignment, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNdetail XmCDetail XmStringTable NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual CompoundStringTable Detail {
            get {
                return XSports.GetStringTable(
                    TonNurako.Motif.ResourceId.XmNdetail, DetailCount, true, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetStringTable(
                    TonNurako.Motif.ResourceId.XmNdetail, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNdetailCount XmCDetailCount Cardinal 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DetailCount {
            get {
                return XSports.GetInt(
                    TonNurako.Motif.ResourceId.XmNdetailCount, 0, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNdetailCount, value, Data.Resource.Access.CSG);
            }
        }

        // XmNfontList XmCFontList XmFontList NULL CSG
        // -> Core

        /// XmNlabelString XmCXmString XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string LabelString {
            get {
                return XSports.GetString(
                    TonNurako.Motif.ResourceId.XmNlabelString, "", Data.Resource.Access.CSG);
            }
            set {
                XSports.SetString(
                    TonNurako.Motif.ResourceId.XmNlabelString, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNlargeIconMask XmCIconMask Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap LargeIconMask {
            get {
                return XSports.GetPixmap(
                TonNurako.Motif.ResourceId.XmNlargeIconMask, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetPixmap(
                    TonNurako.Motif.ResourceId.XmNlargeIconMask, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNlargeIconPixmap XmCIconPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap LargeIconPixmap {
            get {
                return XSports.GetPixmap(
                    TonNurako.Motif.ResourceId.XmNlargeIconPixmap, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetPixmap(
                    TonNurako.Motif.ResourceId.XmNlargeIconPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginHeight XmCMarginHeight Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(
                    TonNurako.Motif.ResourceId.XmNmarginHeight, 2, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNmarginHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginWidth XmCMarginWidth Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmarginWidth, 2, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNmarginWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNsmallIconMask XmCIconMask Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap SmallIconMask {
            get {
                return XSports.GetPixmap(
                TonNurako.Motif.ResourceId.XmNsmallIconMask, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                TonNurako.Motif.ResourceId.XmNsmallIconMask, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNsmallIconPixmap XmCIconPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap SmallIconPixmap {
            get {
                return XSports.GetPixmap(
                    TonNurako.Motif.ResourceId.XmNsmallIconPixmap, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetPixmap(
                    TonNurako.Motif.ResourceId.XmNsmallIconPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNviewType XmCViewType unsigned char XmLARGE_ICON CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IconType ViewType {
            get {
                return XSports.GetValue<IconType>(
                TonNurako.Motif.ResourceId.XmNviewType, IconType.LargeIcon, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<IconType>(
                TonNurako.Motif.ResourceId.XmNviewType, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNvisualEmphasis XmCVisualEmphasis unsigned char XmNOT_SELECTED CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SelectState VisualEmphasis {
            get {
                return XSports.GetValue<SelectState>(
                TonNurako.Motif.ResourceId.XmNvisualEmphasis, SelectState.NotSelected, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<SelectState>(
                    TonNurako.Motif.ResourceId.XmNvisualEmphasis, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNspacing XmCSpacing Dimension 4 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Spacing {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNspacing, 4, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNspacing, value, Data.Resource.Access.CSG);
            }
        }
    }
}
