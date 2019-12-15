using System;

namespace TonNurako.Widgets.Xm
{

    public enum NotebookChildType : byte{
        Page = TonNurako.Motif.Constant.XmPAGE,
        MajorTab = TonNurako.Motif.Constant.XmMAJOR_TAB,
        MinorTab = TonNurako.Motif.Constant.XmMINOR_TAB,
        StatusArea = TonNurako.Motif.Constant.XmSTATUS_AREA,
        PageScroller = TonNurako.Motif.Constant.XmPAGE_SCROLLER
    }

    public enum BackPagePlacement : byte{
        TopLeft  = TonNurako.Motif.Constant.XmTOP_LEFT,
        BottomLeft = TonNurako.Motif.Constant.XmBOTTOM_LEFT,
        TopRight = TonNurako.Motif.Constant.XmTOP_RIGHT,
        BottomRight = TonNurako.Motif.Constant.XmBOTTOM_RIGHT,
    }

    public enum NotebookBindingType : byte {
        None = TonNurako.Motif.Constant.XmNONE,
        Solid = TonNurako.Motif.Constant.XmSOLID,
        Spiral= TonNurako.Motif.Constant.XmSPIRAL,
        Pixmap = TonNurako.Motif.Constant.XmPIXMAP,
        PixmapOverlapOnly = TonNurako.Motif.Constant.XmPIXMAP_OVERLAP_ONLY
    }

	/// <summary>
	/// Notebook (XmNotebook.txt)
	/// </summary>
	public class Notebook : Manager, IDefectiveWidget
	{

		#region 生成

		public Notebook() : base() {
            NotebookEventTable = new TnkXtEvents<Events.NotebookEventArgs> ();
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		/// <summary>
		/// Notebook生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateNotebook, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
		#endregion

		#region ﾌﾟﾛﾊﾟﾁー

        /// <summary>
        /// XmNbackPageBackground XmCBackPageBackground Pixel dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color BackPageBackground {
            get {
                return XSports.GetColor(
                TonNurako.Motif.ResourceId.XmNbackPageBackground, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetColor(
                TonNurako.Motif.ResourceId.XmNbackPageBackground, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbackPageForeground XmCBackPageForeground Pixel dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color BackPageForeground {
            get {
                return XSports.GetColor(
                TonNurako.Motif.ResourceId.XmNbackPageForeground, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetColor(
                TonNurako.Motif.ResourceId.XmNbackPageForeground, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbackPageNumber XmCBackPageNumber Cardinal 2 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int BackPageNumber {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNbackPageNumber, 2, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNbackPageNumber, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbackPagePlacement XmCBackPagePlacement unsigned char dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual BackPagePlacement BackPagePlacement {
            get {
                return XSports.GetValue<BackPagePlacement>(
                TonNurako.Motif.ResourceId.XmNbackPagePlacement, BackPagePlacement.TopLeft, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<BackPagePlacement>(
                TonNurako.Motif.ResourceId.XmNbackPagePlacement, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbackPageSize XmCBackPageSize Dimension 8 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int BackPageSize {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNbackPageSize, 8, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNbackPageSize, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbindingPixmap XmCBindingPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap BindingPixmap {
            get {
                return XSports.GetPixmap(
                TonNurako.Motif.ResourceId.XmNbindingPixmap, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                TonNurako.Motif.ResourceId.XmNbindingPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbindingType XmCBindingType unsigned char XmSPIRAL CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual NotebookBindingType BindingType {
            get {
                return XSports.GetValue<NotebookBindingType>(
                TonNurako.Motif.ResourceId.XmNbindingType, NotebookBindingType.Spiral, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<NotebookBindingType>(
                TonNurako.Motif.ResourceId.XmNbindingType, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbindingWidth XmCBindingWidth Dimension 25 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int BindingWidth {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNbindingWidth, 25, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNbindingWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNcurrentPageNumber XmCCurrentPageNumber int dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int CurrentPageNumber {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNcurrentPageNumber, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNcurrentPageNumber, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNfirstPageNumber XmCFirstPageNumber int 1 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int FirstPageNumber {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNfirstPageNumber, 1, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNfirstPageNumber, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNframeBackground XmCFrameBackground Pixel dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color FrameBackground {
            get {
                return XSports.GetColor(
                TonNurako.Motif.ResourceId.XmNframeBackground, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetColor(
                TonNurako.Motif.ResourceId.XmNframeBackground, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNframeShadowThickness XmCShadowThickness Dimension 0 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int FrameShadowThickness {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNframeShadowThickness, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNframeShadowThickness, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNinnerMarginHeight XmCInnerMarginHeight Dimension 0 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int InnerMarginHeight {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNinnerMarginHeight, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNinnerMarginHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNinnerMarginWidth XmCInnerMarginWidth Dimension 0 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int InnerMarginWidth {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNinnerMarginWidth, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNinnerMarginWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNlastPageNumber XmCLastPageNumber int dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int LastPageNumber {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNlastPageNumber, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNlastPageNumber, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNminorTabSpacing XmCMinorTabSpacing Dimension 3 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MinorTabSpacing {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNminorTabSpacing, 3, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNminorTabSpacing, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNmajorTabSpacing XmCMajorTabSpacing Dimension 3 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MajorTabSpacing {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmajorTabSpacing, 3, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmajorTabSpacing, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNorientation XmCOrientation unsigned char XmHORIZONTAL CSG
        /// </summary>
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

		#endregion

		#region ｲﾍﾞﾝﾄ
        internal TnkXtEvents<Events.NotebookEventArgs> NotebookEventTable {
            get;
        }

        /// <summary>
        /// XmNpageChangedCallback XmCCallback XtCallbackList NULL C
        /// </summary>
        public virtual event EventHandler<Events.NotebookEventArgs> PageChangedEvent
        {
            add {
                NotebookEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNpageChangedCallback ,  value );
            }
            remove {
                NotebookEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNpageChangedCallback ,  value );
            }
        }

		#endregion

	}
}
