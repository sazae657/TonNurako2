//
// ﾄﾝﾇﾗｺ
//
// ｳｲｼﾞｪｯﾄ定数
//
using System;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// 編集ﾓーﾄﾞ
    /// </summary>
    public enum  EditMode: byte {
        Single = TonNurako.Motif.Constant.XmSINGLE_LINE_EDIT,
        Multi = TonNurako.Motif.Constant.XmMULTI_LINE_EDIT
    }

    /// <summary>
    /// ﾗﾍﾞﾙの中身
    /// </summary>
    public enum LabelType : byte {
        String = TonNurako.Motif.Constant.XmSTRING,
        Pixmap = TonNurako.Motif.Constant.XmPIXMAP,
        PixmapAndString = TonNurako.Motif.Constant.XmPIXMAP_AND_STRING
    }

    /// <summary>
    /// 方向
    /// </summary>
    public enum StringDirection : byte {
        LtoR = TonNurako.Motif.Constant.XmSTRING_DIRECTION_L_TO_R,
        RtoL = TonNurako.Motif.Constant.XmSTRING_DIRECTION_R_TO_L,
        Default = TonNurako.Motif.Constant.XmSTRING_DIRECTION_DEFAULT
    }

    /// <summary>
    /// 複数ｸﾘｯｸ許容する？
    /// </summary>
    public enum MultiClick : byte{
        Keep = TonNurako.Motif.Constant.XmMULTICLICK_KEEP,
        Discard = TonNurako.Motif.Constant.XmMULTICLICK_DISCARD
    }

    /// <summary>
    /// ﾀﾞｲｱﾛｸﾞの表示ｽﾀｲﾙ(SYSTEM_MODAL危険)
    /// </summary>
    public enum DialogStyle : byte{
        SystemModal = TonNurako.Motif.Constant.XmDIALOG_SYSTEM_MODAL,
        PrimaryApplicationModal = TonNurako.Motif.Constant.XmDIALOG_PRIMARY_APPLICATION_MODAL,
        ApplicationModal = TonNurako.Motif.Constant.XmDIALOG_APPLICATION_MODAL,
        FullApplicationModal =  TonNurako.Motif.Constant.XmDIALOG_FULL_APPLICATION_MODAL,
        Modeless = TonNurako.Motif.Constant.XmDIALOG_MODELESS,
        WorkArea = TonNurako.Motif.Constant.XmDIALOG_WORK_AREA
    }

    /// <summary>
    /// ﾘｻｲｽﾞﾎﾟﾘｼー
    /// </summary>
    public enum ResizePolicy : byte{
        None = TonNurako.Motif.Constant.XmRESIZE_NONE,
        Any = TonNurako.Motif.Constant.XmRESIZE_ANY,
        Grow = TonNurako.Motif.Constant.XmRESIZE_GROW,
    }

	/// <summary>
	/// ArrowButtonの向き
	/// </summary>
    public enum ArrowDirection : byte{
        Up      = TonNurako.Motif.Constant.XmARROW_UP,
        Down    = TonNurako.Motif.Constant.XmARROW_DOWN,
        Left    = TonNurako.Motif.Constant.XmARROW_LEFT,
        Right   = TonNurako.Motif.Constant.XmARROW_RIGHT,
    }

    /// <summary>
    /// 影の形
    /// </summary>
    public enum ShadowType : byte{
        In = TonNurako.Motif.Constant.XmSHADOW_IN,
        Out = TonNurako.Motif.Constant.XmSHADOW_OUT,
        EtchedIn = TonNurako.Motif.Constant.XmSHADOW_ETCHED_IN,
        EtchedOut = TonNurako.Motif.Constant.XmSHADOW_ETCHED_OUT
    }

    /// <summary>
    /// ﾀﾞｲｱﾛｸﾞのﾃﾞﾌｫﾙﾄﾎﾞﾀﾝ
    /// </summary>
    public enum DefaultButtonType : byte
    {
        Cancel= TonNurako.Motif.Constant.XmDIALOG_CANCEL_BUTTON,
        Ok  = TonNurako.Motif.Constant.XmDIALOG_OK_BUTTON,
        Help = TonNurako.Motif.Constant.XmDIALOG_HELP_BUTTON,
        None = TonNurako.Motif.Constant.XmDIALOG_NONE
    }

    /// <summary>
    /// ﾒｯｾーｼﾞﾀﾞｲｱﾛｸﾞのｲﾝｼﾞｹーﾀー
    /// </summary>
    public enum MessageDialogType : byte {
        Error = TonNurako.Motif.Constant.XmDIALOG_ERROR,
        Information = TonNurako.Motif.Constant.XmDIALOG_INFORMATION,
        Message = TonNurako.Motif.Constant.XmDIALOG_MESSAGE,
        Question = TonNurako.Motif.Constant.XmDIALOG_QUESTION,
        Template = TonNurako.Motif.Constant.XmDIALOG_TEMPLATE,
        Warning = TonNurako.Motif.Constant.XmDIALOG_WARNING,
    }

    /// <summary>
    /// ﾀﾞｲｱﾛｸﾞの種類
    /// </summary>
    public enum DialogType : byte{
        Working = TonNurako.Motif.Constant.XmDIALOG_WORKING,
        Prompt = TonNurako.Motif.Constant.XmDIALOG_PROMPT,
        Command = TonNurako.Motif.Constant.XmDIALOG_COMMAND,
        Selection = TonNurako.Motif.Constant.XmDIALOG_SELECTION,
        FileSelection = TonNurako.Motif.Constant.XmDIALOG_FILE_SELECTION,
        WorkArea = TonNurako.Motif.Constant.XmDIALOG_WORK_AREA,
    }

    /// <summary>
    /// ﾜーｸｴﾘｱの配置
    /// </summary>
    public enum Placement : byte{
        AboveSelection = TonNurako.Motif.Constant.XmPLACE_ABOVE_SELECTION,
        BelowSelection = TonNurako.Motif.Constant.XmPLACE_BELOW_SELECTION,
        Top = TonNurako.Motif.Constant.XmPLACE_TOP
    }

    /// <summary>
    /// 中身の位置
    /// </summary>
    public enum ContentsAlignment : byte{
        BaselineBottom = TonNurako.Motif.Constant.XmALIGNMENT_BASELINE_BOTTOM,
        BaselineTop = TonNurako.Motif.Constant.XmALIGNMENT_BASELINE_TOP,
        ContentsBottom = TonNurako.Motif.Constant.XmALIGNMENT_CONTENTS_BOTTOM,
        Center = TonNurako.Motif.Constant.XmALIGNMENT_CENTER,
        ContentsTop  = TonNurako.Motif.Constant.XmALIGNMENT_CONTENTS_TOP,
    }

    /// <summary>
    /// RowColumnのﾊﾟｯｷﾝｸﾞ
    /// </summary>
    public enum Packing : byte{
        None	= TonNurako.Motif.Constant.XmPACK_NONE,
        Column	= TonNurako.Motif.Constant.XmPACK_COLUMN,
        Tight	= TonNurako.Motif.Constant.XmPACK_TIGHT
    }

    /// <summary>
    /// ﾎﾟｯﾌﾟｱｯﾌﾟの挙動
    /// </summary>
    public enum PopupType : byte { // TODO 名前がわかりにくい
        Keyboard = TonNurako.Motif.Constant.XmPOPUP_KEYBOARD,
        Disabled = TonNurako.Motif.Constant.XmPOPUP_DISABLED,
        Automatic = TonNurako.Motif.Constant.XmPOPUP_AUTOMATIC,
        AutomaticRecursive = TonNurako.Motif.Constant.XmPOPUP_AUTOMATIC_RECURSIVE,
    }

    /// <summary>
    /// RwColumnの種類
    /// </summary>
    public enum RowColumnType : byte{
        WorkArea = TonNurako.Motif.Constant.XmWORK_AREA,
        MenuBar = TonNurako.Motif.Constant.XmMENU_BAR,
        MenuPulldown = TonNurako.Motif.Constant.XmMENU_PULLDOWN,
        MenuPopup = TonNurako.Motif.Constant.XmMENU_POPUP
    }

    /// <summary>
    /// ﾒﾆｭーの切り離し設定
    /// </summary>
    public enum TearOffModel : byte{
        Enabled = TonNurako.Motif.Constant.XmTEAR_OFF_ENABLED,
        Disabled = TonNurako.Motif.Constant.XmTEAR_OFF_DISABLED,
    }

    /// <summary>
    /// 区切り線のｽﾀｲﾙ
    /// </summary>
    public enum SeparatorType : byte{
        SingleLine = TonNurako.Motif.Constant.XmSINGLE_LINE,
        DoubleLine = TonNurako.Motif.Constant.XmDOUBLE_LINE,
        SingleDashedLine = TonNurako.Motif.Constant.XmSINGLE_DASHED_LINE,
        DoubleDashedLine = TonNurako.Motif.Constant.XmDOUBLE_DASHED_LINE,
        NoLine = TonNurako.Motif.Constant.XmNO_LINE,
        ShadowEtchedIn = TonNurako.Motif.Constant.XmSHADOW_ETCHED_IN,
        ShadowEtchedOut = TonNurako.Motif.Constant.XmSHADOW_ETCHED_OUT,
        ShadowEtchedInDash = TonNurako.Motif.Constant.XmSHADOW_ETCHED_IN_DASH,
        ShadowEtchedOutDash = TonNurako.Motif.Constant.XmSHADOW_ETCHED_OUT_DASH,
    }

    //
    // LIST
    //

    /// <summary>
    /// 自動選択ﾓーﾄﾞ
    /// </summary>
    public enum AutomaticSelection : byte{
        Auto  = TonNurako.Motif.Constant.XmAUTO_SELECT,
        No = TonNurako.Motif.Constant.XmNO_AUTO_SELECT,
        Single = TonNurako.Motif.Constant.XmSINGLE_SELECT,
        Multiple = TonNurako.Motif.Constant.XmMULTIPLE_SELECT,
        Extended = TonNurako.Motif.Constant.XmEXTENDED_SELECT,
        Browse = TonNurako.Motif.Constant.XmBROWSE_SELECT,
    }

    /// <summary>
    /// 項目の選択方式
    /// </summary>
    public enum SelectionPolicy : byte{
        Single  = TonNurako.Motif.Constant.XmSINGLE_SELECT,
        Multiple = TonNurako.Motif.Constant.XmMULTIPLE_SELECT,
        Extended = TonNurako.Motif.Constant.XmEXTENDED_SELECT,
        Browse = TonNurako.Motif.Constant.XmBROWSE_SELECT,
    }

    /// <summary>
    /// ｷーﾎﾞーﾄﾞﾅﾋﾞｹﾞーｼｮﾝ
    /// </summary>
    public enum MatchBehavior : byte{
        None = TonNurako.Motif.Constant.XmNONE,
        QuickNavigate = TonNurako.Motif.Constant.XmQUICK_NAVIGATE,
    }

    /// <summary>
    /// 選択項目の所有権
    /// </summary>
    public enum PrimaryOwnership : byte{
        Never = TonNurako.Motif.Constant.XmOWN_NEVER,
        Always = TonNurako.Motif.Constant.XmOWN_ALWAYS,
        Multiple = TonNurako.Motif.Constant.XmOWN_MULTIPLE,
        PossibleMultiple = TonNurako.Motif.Constant.XmOWN_POSSIBLE_MULTIPLE,
    };

    /// <summary>
    /// ﾘｽﾄのｻｲｽﾞ変更ﾎﾟﾘｼー
    /// </summary>
    public enum ListSizePolicy : byte{
        Variable = TonNurako.Motif.Constant.XmVARIABLE,
        Constant = TonNurako.Motif.Constant.XmCONSTANT,
        ResizeIfPossible = TonNurako.Motif.Constant.XmRESIZE_IF_POSSIBLE,
    }

    /// <summary>
    /// 選択ﾓーﾄﾞ
    /// </summary>
    public enum SelectionMode : byte{
        Normal = TonNurako.Motif.Constant.XmNORMAL_MODE,
        Add = TonNurako.Motif.Constant.XmADD_MODE,
    }

    /// <summary>
    /// 選択項目の色
    /// </summary>
    public enum SelectColor {
        DefaultSelectColor = TonNurako.Motif.Constant.XmDEFAULT_SELECT_COLOR,
        ReversedGroundColors = TonNurako.Motif.Constant.XmREVERSED_GROUND_COLORS,
        HighlightColor = TonNurako.Motif.Constant.XmHIGHLIGHT_COLOR,
    }

    /// <summary>
    /// ｲﾝｼﾞｹーﾀーのｽﾀｲﾙ
    /// </summary>
    public enum Indicator {
        None  = TonNurako.Motif.Constant.XmINDICATOR_NONE,
        Fill  = TonNurako.Motif.Constant.XmINDICATOR_FILL,
        Box   = TonNurako.Motif.Constant.XmINDICATOR_BOX,
        Check     = TonNurako.Motif.Constant.XmINDICATOR_CHECK,
        CheckBox = TonNurako.Motif.Constant.XmINDICATOR_CHECK_BOX,
        Cross     = TonNurako.Motif.Constant.XmINDICATOR_CROSS,
        CrossBox = TonNurako.Motif.Constant.XmINDICATOR_CROSS_BOX,
    }

    /// <summary>
    /// ｲﾝｼﾞｹーﾀーの形
    /// </summary>
    public enum IndicatorType : byte{
        Many = TonNurako.Motif.Constant.XmN_OF_MANY,
        OneOfMany = TonNurako.Motif.Constant.XmONE_OF_MANY,
        Round = TonNurako.Motif.Constant.XmONE_OF_MANY_ROUND,
        Diamond = TonNurako.Motif.Constant.XmONE_OF_MANY_DIAMOND,
    }

    /// <summary>
    /// ﾄｸﾞﾙﾎﾞﾀﾝのｽﾃーﾄ
    /// </summary>
    public enum ToggleButtonState : byte{
        Unset  = TonNurako.Motif.Constant.XmUNSET,
        Set  = TonNurako.Motif.Constant.XmSET,
        Indeterminate  = TonNurako.Motif.Constant.XmINDETERMINATE,
    }

    /// <summary>
    /// ﾄｸﾞﾙﾎﾞﾀﾝのﾓーﾄﾞ
    /// </summary>
    public enum ToggleMode : byte{
        Boolean = TonNurako.Motif.Constant.XmTOGGLE_BOOLEAN,
        Indeterminate = TonNurako.Motif.Constant.XmTOGGLE_INDETERMINATE,
    }


    /// <summary>
    /// 方向ﾌﾗｸﾞ
    /// </summary>
    [Flags]
    public enum Direction : byte{
        Ignored     = TonNurako.Motif.Constant.XmDIRECTION_IGNORED,
        RightToLeftMask    = TonNurako.Motif.Constant.XmRIGHT_TO_LEFT_MASK,
        LeftToRightMask    = TonNurako.Motif.Constant.XmLEFT_TO_RIGHT_MASK,
        HorizontalMask       = TonNurako.Motif.Constant.XmHORIZONTAL_MASK,
        TopToBottomMask    = TonNurako.Motif.Constant.XmTOP_TO_BOTTOM_MASK,
        BottomToTopMask    = TonNurako.Motif.Constant.XmBOTTOM_TO_TOP_MASK,
        VerticalMask         = TonNurako.Motif.Constant.XmVERTICAL_MASK,
        PrecedenceHorizMask = TonNurako.Motif.Constant.XmPRECEDENCE_HORIZ_MASK,
        PrecedenceVertMask  = TonNurako.Motif.Constant.XmPRECEDENCE_VERT_MASK,
        PrecedenceMask       = TonNurako.Motif.Constant.XmPRECEDENCE_MASK,
        RightToLeftTopToBottom =
            RightToLeftMask | TopToBottomMask | PrecedenceHorizMask,
        LeftToRightTopToBottom =
            LeftToRightMask | TopToBottomMask | PrecedenceHorizMask,
        RightToLeftBottomToTop =
            RightToLeftMask | BottomToTopMask | PrecedenceHorizMask,
        LeftToRightBottomToTop =
            LeftToRightMask | BottomToTopMask | PrecedenceHorizMask,
        TopToBottomRightToLeft =
            RightToLeftMask | TopToBottomMask | PrecedenceVertMask,
        TopToBottomLeftToRight =
            LeftToRightMask | TopToBottomMask | PrecedenceVertMask,
        BottomToTopRightToLeft =
            RightToLeftMask | BottomToTopMask | PrecedenceVertMask,
        BottomToTopLeftToRight =
            LeftToRightMask | BottomToTopMask | PrecedenceVertMask,
        TopToBottom =
            TopToBottomMask | HorizontalMask | PrecedenceMask,
        BottomToTop =
            BottomToTopMask | HorizontalMask | PrecedenceMask,
        RightToLeft =
            RightToLeftMask | VerticalMask | PrecedenceMask,
        LeftToRight =
            LeftToRightMask | VerticalMask | PrecedenceMask,
        DefaultDirection = 0xff

    }

    /// <summary>
    /// 単位
    /// </summary>
    public enum UnitType : byte{
        Pixels            = TonNurako.Motif.Constant.XmPIXELS,
        Millimeters       = TonNurako.Motif.Constant.XmMILLIMETERS,
        X100thMillimeters = TonNurako.Motif.Constant.Xm100TH_MILLIMETERS,
        Centimeters       = TonNurako.Motif.Constant.XmCENTIMETERS,
        Inches            = TonNurako.Motif.Constant.XmINCHES,
        X1000thInches     = TonNurako.Motif.Constant.Xm1000TH_INCHES,
        Points            = TonNurako.Motif.Constant.XmPOINTS,
        X100thPoints      = TonNurako.Motif.Constant.Xm100TH_POINTS,
        FontUnits        = TonNurako.Motif.Constant.XmFONT_UNITS,
        X100thFontUnits  = TonNurako.Motif.Constant.Xm100TH_FONT_UNITS,
    }

    /// <summary>
    /// ﾄﾞﾗｯｸﾞ許容
    /// </summary>
    public enum DragModel : byte{
        Enabled = TonNurako.Motif.Constant.XmAUTO_DRAG_ENABLED,
        Disabled = TonNurako.Motif.Constant.XmAUTO_DRAG_DISABLED,
    }

    /// <summary>
    /// ｽｸﾛーﾙﾊﾞーの表示条件
    /// </summary>
    public enum ScrollBarDisplayPolicy : byte{
        AsNeeded =  TonNurako.Motif.Constant.XmAS_NEEDED,
        Static = TonNurako.Motif.Constant.XmSTATIC,
    }

    /// <summary>
    /// ｽｸﾛーﾙ方法
    /// </summary>
    public enum ScrollingPolicy : byte{
        Automatic = TonNurako.Motif.Constant.XmAUTOMATIC,
        Constant  = TonNurako.Motif.Constant.XmCONSTANT,
        ApplicationDefined = TonNurako.Motif.Constant.XmAPPLICATION_DEFINED,
    }

    /// <summary>
    /// ｽｸﾛーﾙｳｲﾝﾄﾞｳの中身
    /// </summary>
    public enum VisualPolicy : byte{
        Variable = TonNurako.Motif.Constant.XmVARIABLE,
        Static    = TonNurako.Motif.Constant.XmSTATIC,
        Constant = TonNurako.Motif.Constant.XmCONSTANT,

    }

    /// <summary>
    /// ｽｸﾛーﾙﾊﾞーの位置
    /// </summary>
    public enum ScrollBarPlacement : byte{
        TopLeft  = TonNurako.Motif.Constant.XmTOP_LEFT,
        BottomLeft = TonNurako.Motif.Constant.XmBOTTOM_LEFT,
        TopRight = TonNurako.Motif.Constant.XmTOP_RIGHT,
        BottomRight = TonNurako.Motif.Constant.XmBOTTOM_RIGHT,
    }

    /// <summary>
    /// ｽｸﾛーﾙｳｲﾝﾄﾞｳの子供達
    /// </summary>
    public enum ScrolledWindowChildType : byte{
        WorkArea = TonNurako.Motif.Constant.XmWORK_AREA,
        HorScrollbar = TonNurako.Motif.Constant.XmHOR_SCROLLBAR,
        VertScrollbar = TonNurako.Motif.Constant.XmVERT_SCROLLBAR,
        CommandWindow = TonNurako.Motif.Constant.XmCOMMAND_WINDOW,
        MessageWindow = TonNurako.Motif.Constant.XmMESSAGE_WINDOW,
        ScrollHor = TonNurako.Motif.Constant.XmSCROLL_HOR,
        ScrollVert = TonNurako.Motif.Constant.XmSCROLL_VERT,
        NoScroll = TonNurako.Motif.Constant.XmNO_SCROLL,
        ClipWindow = TonNurako.Motif.Constant.XmCLIP_WINDOW,
        GenericChild =  TonNurako.Motif.Constant.XmGENERIC_CHILD,
    }

    /// <summary>
    /// ｺﾏﾝﾄﾞｳｲﾝﾄﾞｳの配置
    /// </summary>
    public enum CommandWindowLocation {
        AboveWorkspace =  TonNurako.Motif.Constant.XmCOMMAND_ABOVE_WORKSPACE,
        BelowWorkspace =  TonNurako.Motif.Constant.XmCOMMAND_BELOW_WORKSPACE,
    }

    /// <summary>
    /// Frameに束縛される際の処遇
    /// </summary>
    public enum FrameChildType : byte {
        TitleChild     =  TonNurako.Motif.Constant.XmFRAME_TITLE_CHILD,
        WorkareaChild  =  TonNurako.Motif.Constant.XmFRAME_WORKAREA_CHILD,
        GenericChild   =  TonNurako.Motif.Constant.XmFRAME_GENERIC_CHILD,
    }

	/// <summary>
	/// ﾚｲｱｳﾄ条件
	/// </summary>
	public enum AttachmentType : byte
	{
        None = TonNurako.Motif.Constant.XmATTACH_NONE,
        Form = TonNurako.Motif.Constant.XmATTACH_FORM,

        OppositeForm = TonNurako.Motif.Constant.XmATTACH_OPPOSITE_FORM,
		Widget = TonNurako.Motif.Constant.XmATTACH_WIDGET,

        OppositeWidget = TonNurako.Motif.Constant.XmATTACH_OPPOSITE_WIDGET,
        Position = TonNurako.Motif.Constant.XmATTACH_POSITION,
		Self = TonNurako.Motif.Constant.XmATTACH_SELF
	}


	/// <summary>
	/// 表示方向
	/// </summary>
	public enum Orientation : byte
	{
        Horizontal = TonNurako.Motif.Constant.XmHORIZONTAL,
		Vertical = TonNurako.Motif.Constant.XmVERTICAL
	}


	/// <summary>
	/// ﾀﾌﾞｸﾞﾙーﾌﾟでの動作を指定する
	/// </summary>
	public enum NavigationType : byte
	{
		None = TonNurako.Motif.Constant.XmNONE,
		TabGroup = TonNurako.Motif.Constant.XmTAB_GROUP,
		StickyTabGroup = TonNurako.Motif.Constant.XmSTICKY_TAB_GROUP,
		ExclusiveTabGroup = TonNurako.Motif.Constant.XmEXCLUSIVE_TAB_GROUP,
	}


	/// <summary>
	/// 配置
	/// </summary>
	public enum Alignment : byte
	{
        Beginning = TonNurako.Motif.Constant.XmALIGNMENT_BEGINNING,
		Center = TonNurako.Motif.Constant.XmALIGNMENT_CENTER,
		End = TonNurako.Motif.Constant.XmALIGNMENT_END,
	}

    /// <summary>
    /// 子ｳｲｼﾞｪｯﾄの配置
    /// </summary>
    public enum ChildAlignment : byte {
        BaselineBottom = TonNurako.Motif.Constant.XmALIGNMENT_BASELINE_BOTTOM,
        BaselineTop    = TonNurako.Motif.Constant.XmALIGNMENT_BASELINE_TOP,
        ChildTop       = TonNurako.Motif.Constant.XmALIGNMENT_CHILD_TOP,
        Center          = TonNurako.Motif.Constant.XmALIGNMENT_CENTER,
        ChildBottom    = TonNurako.Motif.Constant.XmALIGNMENT_CHILD_BOTTOM,
    }


	/// <summary>
	/// SpinBox の矢印ﾎﾞﾀﾝ配置
	/// </summary>
	public enum ArrowLayout : byte
	{
        Beginning = TonNurako.Motif.Constant.XmARROWS_BEGINNING,
        End = TonNurako.Motif.Constant.XmARROWS_END,
		FlatBeginning = TonNurako.Motif.Constant.XmARROWS_FLAT_BEGINNING,
		FlatEnd = TonNurako.Motif.Constant.XmARROWS_FLAT_END,
		Split = TonNurako.Motif.Constant.XmARROWS_SPLIT,
	}

    /// <summary>
    /// SpinBoxの矢印ﾎﾞﾀﾝの挙動
    /// </summary>
    public enum ArrowSensitivity : byte{
        Sensitive = TonNurako.Motif.Constant.XmARROWS_SENSITIVE,
        DecrementSensitive = TonNurako.Motif.Constant.XmARROWS_DECREMENT_SENSITIVE,
        IncrementSensitive = TonNurako.Motif.Constant.XmARROWS_INCREMENT_SENSITIVE,
        Insensitive = TonNurako.Motif.Constant.XmARROWS_INSENSITIVE,
        Default = TonNurako.Motif.Constant.XmARROWS_DEFAULT_SENSITIVITY
    }

    /// <summary>
    /// SpinBoxの表示項目の種類
    /// </summary>
    public enum SpinBoxChildType : byte{
        String = TonNurako.Motif.Constant.XmSTRING,
        Numeric = TonNurako.Motif.Constant.XmNUMERIC,
    }

    /// <summary>
    /// SpinBoxの値の
    /// </summary>
    public enum SpinBoxPositionType : byte{
        Index = TonNurako.Motif.Constant.XmPOSITION_INDEX,
        Value = TonNurako.Motif.Constant.XmPOSITION_VALUE,
    }



	/// <summary>
	/// 矢印ﾎﾞﾀﾝの方向
	/// </summary>
	public enum ArrowOrientation : byte
	{
		Vertical = TonNurako.Motif.Constant.XmARROWS_VERTICAL,
		Horizontal = TonNurako.Motif.Constant.XmARROWS_HORIZONTAL,
	}

    /// <summary>
    ///　FileSelectionBoxのﾊﾟｽﾓーﾄﾞ
    /// </summary>
    public enum PathMode {
       Full = TonNurako.Motif.Constant.XmPATH_MODE_FULL,
       Relative  = TonNurako.Motif.Constant.XmPATH_MODE_RELATIVE
    }

    /// <summary>
    /// FileSelectionBoxのﾌｧｲﾙﾀｲﾌﾟ
    /// </summary>
    [Flags]
    public enum FileTypeMask :byte{
        Directory = TonNurako.Motif.Constant.XmFILE_DIRECTORY,
        Regular = TonNurako.Motif.Constant.XmFILE_REGULAR,
        Any = TonNurako.Motif.Constant.XmFILE_ANY_TYPE,
    }

    /// <summary>
    /// SelectionBoxのﾌｨﾙﾀーのｽﾀｲﾙ
    /// </summary>
    public enum FileFilterStyle {
        HiddenFiles	= TonNurako.Motif.Constant.XmFILTER_HIDDEN_FILES,
        None	= TonNurako.Motif.Constant.XmFILTER_NONE,
    }

	/// <summary>
	/// TabStackのﾓーﾄﾞ
	/// </summary>
    public enum TabMode {
        Basic = TonNurako.Motif.Constant.XmTABS_BASIC,
        Stacked =  TonNurako.Motif.Constant.XmTABS_STACKED,
        StackedStatic = TonNurako.Motif.Constant.XmTABS_STACKED_STATIC,
    }

	/// <summary>
	/// TabStackの方向
	/// </summary>
    public enum TabOrientation {
        Dynamic = TonNurako.Motif.Constant.XmTAB_ORIENTATION_DYNAMIC,
        LeftToRight = TonNurako.Motif.Constant.XmTABS_LEFT_TO_RIGHT,
        RightToLeft = TonNurako.Motif.Constant.XmTABS_RIGHT_TO_LEFT,
        TopToBottom = TonNurako.Motif.Constant.XmTABS_TOP_TO_BOTTOM,
        BottomToTop = TonNurako.Motif.Constant.XmTABS_BOTTOM_TO_TOP,
    }

	/// <summary>
	/// TabStackのﾀﾌﾞ位置
	/// </summary>
    public enum TabSide {
        Top = TonNurako.Motif.Constant.XmTABS_ON_TOP,
        Bottom = TonNurako.Motif.Constant.XmTABS_ON_BOTTOM,
        Right = TonNurako.Motif.Constant.XmTABS_ON_RIGHT,
        Left = TonNurako.Motif.Constant.XmTABS_ON_LEFT,

    }

    /// <summary>
	/// TabStackのｽﾀｲﾙ
	/// </summary>
    public enum TabStyle {
        Beveled = TonNurako.Motif.Constant.XmTABS_BEVELED,
        Rounded = TonNurako.Motif.Constant.XmTABS_ROUNDED,
        Squared = TonNurako.Motif.Constant.XmTABS_SQUARED,
    }

	/// <summary>
	/// ﾒﾆｭーのﾎﾞﾀﾝの種類
	/// </summary>
    public enum MenuButtonType : byte {
        Pushbutton = TonNurako.Motif.Constant.XmPUSHBUTTON,
        Togglebutton = TonNurako.Motif.Constant.XmTOGGLEBUTTON,
        Radiobutton = TonNurako.Motif.Constant.XmRADIOBUTTON,
        Cascadebutton = TonNurako.Motif.Constant.XmCASCADEBUTTON,
        Separator = TonNurako.Motif.Constant.XmSEPARATOR,
        DoubleSeparator = TonNurako.Motif.Constant.XmDOUBLE_SEPARATOR,
        Title = TonNurako.Motif.Constant.XmTITLE,
        Checkbutton = TonNurako.Motif.Constant.XmCHECKBUTTON,
    }

	/// <summary>
	/// FillOption
	/// </summary>
    public enum FillOption : byte{
        None = TonNurako.Motif.Constant.XmFillNone,
        Major = TonNurako.Motif.Constant.XmFillMajor,
        Minor = TonNurako.Motif.Constant.XmFillMinor,
        All = TonNurako.Motif.Constant.XmFillAll,
    }

    /// <summary>
	/// ComboBoxの種類
	/// </summary>
    public enum ComboBoxType {
        ComboBox = TonNurako.Motif.Constant.XmCOMBO_BOX,
        DropDownComboBox = TonNurako.Motif.Constant.XmDROP_DOWN_COMBO_BOX,
        DropDownList = TonNurako.Motif.Constant.XmDROP_DOWN_LIST,
    }

    /// <summary>
	/// ComboBoxの基準
	/// </summary>
    public enum PositionMode {
        ZeroBased = TonNurako.Motif.Constant.XmZERO_BASED,
        OneBased = TonNurako.Motif.Constant.XmONE_BASED,
    }

    /// <summary>
    /// Scaleのﾗﾍﾞﾙ位置
    /// </summary>
    public enum ShowValuePosition {
        None          = TonNurako.Motif.Constant.XmNONE,
        NearSlider   = TonNurako.Motif.Constant.XmNEAR_SLIDER,
        NearBorder   = TonNurako.Motif.Constant.XmNEAR_BORDER,
    }

    /// <summary>
	/// ｳｲﾝﾄﾞーの状態
	/// </summary>
    public enum WindowState {
        Normal = 1,
        Iconic = 3
    }
}
