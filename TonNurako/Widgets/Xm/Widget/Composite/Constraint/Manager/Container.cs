using System;
using System.Runtime.InteropServices;

namespace TonNurako.Widgets.Xm
{
    public enum EntryViewType : byte
    {
        Any = TonNurako.Motif.Constant.XmANY_ICON,
        Large = TonNurako.Motif.Constant.XmLARGE_ICON,
        Small = TonNurako.Motif.Constant.XmSMALL_ICON,
    }

    public enum LayoutType : byte
    {
        Detail = TonNurako.Motif.Constant.XmDETAIL,
        Outline = TonNurako.Motif.Constant.XmOUTLINE,
        Spatial = TonNurako.Motif.Constant.XmSPATIAL,
    }

    public enum OutlineButtonPolicy : byte
    {
        Absent = TonNurako.Motif.Constant.XmOUTLINE_BUTTON_ABSENT,
        Present = TonNurako.Motif.Constant.XmOUTLINE_BUTTON_PRESENT
    }

    public enum LineStyle : byte
    {
        NoLine = TonNurako.Motif.Constant.XmNO_LINE,
        Single = TonNurako.Motif.Constant.XmSINGLE
    }

    public enum SelectionTechnique : byte
    {
        Marquee = TonNurako.Motif.Constant.XmMARQUEE,
        MarqueeExtendStart = TonNurako.Motif.Constant.XmMARQUEE_EXTEND_START,
        MarqueeExtendBoth = TonNurako.Motif.Constant.XmMARQUEE_EXTEND_BOTH,
        TouchOnly = TonNurako.Motif.Constant.XmTOUCH_ONLY,
        TouchOver = TonNurako.Motif.Constant.XmTOUCH_OVER

    }

    public enum SpatialIncludeModel : byte
    {
        Append = TonNurako.Motif.Constant.XmAPPEND,
        Closest = TonNurako.Motif.Constant.XmCLOSEST,
        FirstFit = TonNurako.Motif.Constant.XmFIRST_FIT
    }

    public enum SpatialResizeModel : byte
    {
        GrowBalanced = TonNurako.Motif.Constant.XmGROW_BALANCED,
        GrowMajor = TonNurako.Motif.Constant.XmGROW_MAJOR,
        GrowMinor = TonNurako.Motif.Constant.XmGROW_MINOR
    }
    public enum SpatialSnapModel : byte
    {
        Center = TonNurako.Motif.Constant.XmCENTER,
        SnapToGrid = TonNurako.Motif.Constant.XmSNAP_TO_GRID,
        None = TonNurako.Motif.Constant.XmNONE
    }

    public enum SpatialStyle : byte
    {
        Cells = TonNurako.Motif.Constant.XmCELLS,
        Grid = TonNurako.Motif.Constant.XmGRID,
        None = TonNurako.Motif.Constant.XmNONE
    }

    public enum OutlineState : byte {
        Collapsed = TonNurako.Motif.Constant.XmCOLLAPSED,
        Expanded = TonNurako.Motif.Constant.XmEXPANDED,
    }

    /// <summary>
    /// Container (XmContainer.txt)
    /// </summary>
    public class Container : Manager, IDefectiveWidget
    {

        #region 生成

        public Container() : base()
        {
        }

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }



        /// <summary>
        /// Container生成
        /// </summary>
        /// <param name="parent">親</param>
        /// <returns></returns>
        public override int Create(IWidget parent)
        {
            if (!IsAvailable)
            {
                this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateContainer, parent, ToolkitResources);
            }
            return base.Create(parent);
        }
        #endregion


        #region ﾌﾟﾛﾊﾟﾁー

        /// <summary>
        /// XmNautomaticSelection XmCAutomaticSelection unsigned char XmAUTO_SELECT CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual AutomaticSelection AutomaticSelection
        {
            get
            {
                return XSports.GetValue<AutomaticSelection>(
                   TonNurako.Motif.ResourceId.XmNautomaticSelection, AutomaticSelection.Auto, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<AutomaticSelection>(
                    TonNurako.Motif.ResourceId.XmNautomaticSelection, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNcollapsedStatePixmap XmCCollapsedStatePixmap Pixmap dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap CollapsedStatePixmap
        {
            get
            {
                return XSports.GetPixmap(
                   TonNurako.Motif.ResourceId.XmNcollapsedStatePixmap, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetPixmap(
                    TonNurako.Motif.ResourceId.XmNcollapsedStatePixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNdetailColumnHeading XmCDetailColumnHeading XmStringTable NULL CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.CompoundStringTable DetailColumnHeading
        {
            get
            {
                return XSports.GetStringTable(
                   TonNurako.Motif.ResourceId.XmNdetailColumnHeading, DetailColumnHeadingCount, true, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetStringTable(
                    TonNurako.Motif.ResourceId.XmNdetailColumnHeading, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNdetailColumnHeadingCount XmCDetailColumnHeadingCount Cardinal 0 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DetailColumnHeadingCount
        {
            get
            {
                return XSports.GetInt(
                   TonNurako.Motif.ResourceId.XmNdetailColumnHeadingCount, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNdetailColumnHeadingCount, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        // XmNdetailOrder XmCDetailOrder Cardinal * NULL CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int [] DetailOrder {
            get {
                int count = 0;
                if (0 == (count = DetailOrderCount)) {
                    return new int[]{};
                }
                IntPtr listRef = XSports.GetPtr(TonNurako.Motif.ResourceId.XmNdetailOrder);
                int [] ret = new int[count];
                Marshal.Copy(listRef, ret, 0, count);
                // listRefはfreeしちゃﾀﾞﾒ
                return ret;
            }
            set {
                IntPtr ptr = IntPtr.Zero;
                int count = value.Length;
                ToolkitResources.Begin();
                try {
                    DetailOrderCount = count;
                    if (0 != count) {
                        ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(int)) * value.Length);
                        Marshal.Copy(value, 0, ptr, value.Length);
                        XSports.SetPtr(TonNurako.Motif.ResourceId.XmNdetailOrder, ptr, Data.Resource.Access.CSG);
                    }
                }finally {
                    ToolkitResources.Commit(true);
                    if(IntPtr.Zero != ptr) {
                        Marshal.FreeCoTaskMem(ptr);
                    }
                }
            }
        }

        /// <summary>
        /// XmNdetailOrderCount XmCDetailOrderCount Cardinal dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DetailOrderCount
        {
            get
            {
                return XSports.GetInt(
                   TonNurako.Motif.ResourceId.XmNdetailOrderCount, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNdetailOrderCount, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNdetailTabList XmCDetailTabList XmTabList NULL CSG
        /// </summary>
        public virtual Data.TabList DetailTabList
        {
            get
            {
                Data.TabList tab = new Data.TabList(
                    XSports.GetPtr(TonNurako.Motif.ResourceId.XmNdetailTabList,  Data.Resource.Access.CSG));
                return tab;
            }
            set
            {
                XSports.SetPtr(
                    TonNurako.Motif.ResourceId.XmNdetailTabList, value.Handle, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNentryViewType XmCEntryViewType unsigned char XmANY_ICON CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual EntryViewType EntryViewType
        {
            get
            {
                return XSports.GetValue<EntryViewType>(
                   TonNurako.Motif.ResourceId.XmNentryViewType, EntryViewType.Any, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<EntryViewType>(
                    TonNurako.Motif.ResourceId.XmNentryViewType, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNexpandedStatePixmap XmCExpandedStatePixmap Pixmap dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap ExpandedStatePixmap
        {
            get
            {
                return XSports.GetPixmap(
                   TonNurako.Motif.ResourceId.XmNexpandedStatePixmap, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetPixmap(
                    TonNurako.Motif.ResourceId.XmNexpandedStatePixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNlargeCellHeight XmCCellHeight Dimension dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int LargeCellHeight
        {
            get
            {
                return XSports.GetInt(
                   TonNurako.Motif.ResourceId.XmNlargeCellHeight, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNlargeCellHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNlargeCellWidth XmCCellWidth Dimension dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int LargeCellWidth
        {
            get
            {
                return XSports.GetInt(
                   TonNurako.Motif.ResourceId.XmNlargeCellWidth, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNlargeCellWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNlayoutType XmCLayoutType unsigned char XmSPATIAL CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual LayoutType LayoutType
        {
            get
            {
                return XSports.GetValue<LayoutType>(
                   TonNurako.Motif.ResourceId.XmNlayoutType, LayoutType.Spatial, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<LayoutType>(
                    TonNurako.Motif.ResourceId.XmNlayoutType, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNmarginHeight XmCMarginHeight Dimension 0 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight
        {
            get
            {
                return XSports.GetInt(
                   TonNurako.Motif.ResourceId.XmNmarginHeight, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNmarginHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNmarginWidth XmCMarginWidth Dimension 0 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth
        {
            get
            {
                return XSports.GetInt(
                   TonNurako.Motif.ResourceId.XmNmarginWidth, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNmarginWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNoutlineButtonPolicy XmCOutlineButtonPolicy unsigned char XmOUTLINE_BUTTON_PRESENT CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual OutlineButtonPolicy OutlineButtonPolicy
        {
            get
            {
                return XSports.GetValue<OutlineButtonPolicy>(
                   TonNurako.Motif.ResourceId.XmNoutlineButtonPolicy, OutlineButtonPolicy.Present, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<OutlineButtonPolicy>(
                    TonNurako.Motif.ResourceId.XmNoutlineButtonPolicy, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNoutlineColumnWidth XmCOutlineColumnWidth Dimension dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int OutlineColumnWidth
        {
            get
            {
                return XSports.GetInt(
                   TonNurako.Motif.ResourceId.XmNoutlineColumnWidth, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNoutlineColumnWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNoutlineIndentation XmCOutlineIndentation Dimension 40 CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int OutlineIndentation
        {
            get
            {
                return XSports.GetInt(
                   TonNurako.Motif.ResourceId.XmNoutlineIndentation, 40, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNoutlineIndentation, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNoutlineLineStyle XmCLineStyle unsigned char XmSINGLE CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual LineStyle OutlineLineStyle
        {
            get
            {
                return XSports.GetValue<LineStyle>(
                   TonNurako.Motif.ResourceId.XmNoutlineLineStyle, LineStyle.Single, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<LineStyle>(
                    TonNurako.Motif.ResourceId.XmNoutlineLineStyle, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNprimaryOwnership XmCprimaryOwnership unsigned char XmOWN_POSSIBLE_MULTIPLE CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual PrimaryOwnership PrimaryOwnership
        {
            get
            {
                return XSports.GetValue<PrimaryOwnership>(
                   TonNurako.Motif.ResourceId.XmNprimaryOwnership, PrimaryOwnership.Multiple, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<PrimaryOwnership>(
                    TonNurako.Motif.ResourceId.XmNprimaryOwnership, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNrenderTable XmCRenderTable XmRenderTable dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable RenderTable
        {
            get
            {
                return XSports.GetRenderTable(
                   TonNurako.Motif.ResourceId.XmNrenderTable, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetRenderTable(
                    TonNurako.Motif.ResourceId.XmNrenderTable, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNselectColor XmCSelectColor Pixel dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color SelectColor
        {
            get
            {
                return XSports.GetColor(
                   TonNurako.Motif.ResourceId.XmNselectColor, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetColor(
                    TonNurako.Motif.ResourceId.XmNselectColor, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// ### XmNselectedObjects XmCSelectedObjects WidgetList NULL SG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.SG)]
        public virtual Data.WidgetList SelectedObjects {
            get{
                IntPtr p = XSports.GetPtr(
                   TonNurako.Motif.ResourceId.XmNselectedObjects, Data.Resource.Access.SG);

                int count = SelectedObjectCount;
                var w = new Data.WidgetList(this.AppContext, p, count);
                return w;
            }
            set {
                int count = value.Count;
                ToolkitResources.Begin();
                try {
                    SelectedObjectCount = count;
                    if (0 != count) {
                        XSports.SetPtr(TonNurako.Motif.ResourceId.XmNselectedObjects, value.ToPointer(), Data.Resource.Access.CSG);
                    }
                }finally {
                    ToolkitResources.Commit(true);
                }
            }

        }

        /// <summary>
        /// XmNselectedObjectCount XmCSelectedObjectCount unsigned int 0 SG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.SG)]
        public virtual int SelectedObjectCount
        {
            get
            {
                return XSports.GetInt(
                   TonNurako.Motif.ResourceId.XmNselectedObjectCount, 0, Data.Resource.Access.SG);
            }
            set
            {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNselectedObjectCount, value, Data.Resource.Access.SG);
            }
        }

        /// <summary>
        /// XmNselectionPolicy XmCSelectionPolicy unsigned char XmEXTENDED_SELECT CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SelectionPolicy SelectionPolicy
        {
            get
            {
                return XSports.GetValue<SelectionPolicy>(
                   TonNurako.Motif.ResourceId.XmNselectionPolicy, SelectionPolicy.Extended, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<SelectionPolicy>(
                    TonNurako.Motif.ResourceId.XmNselectionPolicy, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNselectionTechnique XmCSelectionTechnique unsigned char XmTOUCH_OVER CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SelectionTechnique SelectionTechnique
        {
            get
            {
                return XSports.GetValue<SelectionTechnique>(
                   TonNurako.Motif.ResourceId.XmNselectionTechnique, SelectionTechnique.TouchOver, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<SelectionTechnique>(
                    TonNurako.Motif.ResourceId.XmNselectionTechnique, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNsmallCellHeight XmCCellHeight Dimension dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SmallCellHeight
        {
            get
            {
                return XSports.GetInt(
                   TonNurako.Motif.ResourceId.XmNsmallCellHeight, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNsmallCellHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNsmallCellWidth XmCCellWidth Dimension dynamic CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SmallCellWidth
        {
            get
            {
                return XSports.GetInt(
                   TonNurako.Motif.ResourceId.XmNsmallCellWidth, 0, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNsmallCellWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNspatialIncludeModel XmCSpatialIncludeModel unsigned char XmAPPEND CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SpatialIncludeModel SpatialIncludeModel
        {
            get
            {
                return XSports.GetValue<SpatialIncludeModel>(
                   TonNurako.Motif.ResourceId.XmNspatialIncludeModel, SpatialIncludeModel.Append, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<SpatialIncludeModel>(
                    TonNurako.Motif.ResourceId.XmNspatialIncludeModel, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNspatialResizeModel XmCSpatialResizeModel unsigned char XmGROW_MINOR CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SpatialResizeModel SpatialResizeModel
        {
            get
            {
                return XSports.GetValue<SpatialResizeModel>(
                   TonNurako.Motif.ResourceId.XmNspatialResizeModel, SpatialResizeModel.GrowMinor, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<SpatialResizeModel>(
                    TonNurako.Motif.ResourceId.XmNspatialResizeModel, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNspatialSnapModel XmCSpatialSnapModel unsigned char XmNONE CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SpatialSnapModel SpatialSnapModel
        {
            get
            {
                return XSports.GetValue<SpatialSnapModel>(
                   TonNurako.Motif.ResourceId.XmNspatialSnapModel, SpatialSnapModel.None, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<SpatialSnapModel>(
                    TonNurako.Motif.ResourceId.XmNspatialSnapModel, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNspatialStyle XmCSpatialStyle unsigned char XmGRID CSG
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SpatialStyle SpatialStyle
        {
            get
            {
                return XSports.GetValue<SpatialStyle>(
                   TonNurako.Motif.ResourceId.XmNspatialStyle, SpatialStyle.Grid, Data.Resource.Access.CSG);
            }
            set
            {
                XSports.SetValue<SpatialStyle>(
                    TonNurako.Motif.ResourceId.XmNspatialStyle, value, Data.Resource.Access.CSG);
            }
        }

        #endregion

        #region ｲﾍﾞﾝﾄ

        /// <summary>
        /// XmNconvertCallback XmCCallback XtCallbackList NULL C
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> ConvertEvent
        {
            add
            {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNconvertCallback, value);
            }
            remove
            {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNconvertCallback, value);
            }
        }

        /// <summary>
        /// XmNdefaultActionCallback XmCCallback XtCallbackList NULL C
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> DefaultActionEvent
        {
            add
            {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNdefaultActionCallback, value);
            }
            remove
            {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNdefaultActionCallback, value);
            }
        }

        /// <summary>
        /// XmNdestinationCallback XmCCallback XtCallbackList NULL C
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> DestinationEvent
        {
            add
            {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNdestinationCallback, value);
            }
            remove
            {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNdestinationCallback, value);
            }
        }

        /// <summary>
        /// XmNoutlineChangedCallback XmCCallback XtCallbackList NULL C
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> OutlineChangedEvent
        {
            add
            {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNoutlineChangedCallback, value);
            }
            remove
            {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNoutlineChangedCallback, value);
            }
        }

        /// <summary>
        /// XmNselectionCallback XmCCallback XtCallbackList NULL C
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> SelectionEvent
        {
            add
            {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNselectionCallback, value);
            }
            remove
            {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNselectionCallback, value);
            }
        }

        #endregion

    }
}
