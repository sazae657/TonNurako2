//
// ﾄﾝﾇﾗｺ
// 
// Motif
//
using TonNurako.Native;

namespace TonNurako.Motif
{
    /// <summary>
    /// ｳｲｼﾞｪｯﾄｸﾗｽ
    /// </summary>
    public enum MotifWidgetClass {
        [ToolkitOption("ﾌﾌﾌﾌﾌﾌﾌﾌﾌﾌﾌﾌﾌﾌﾌﾌﾌﾌﾌ")] INVALID = 0,
        [ToolkitOption("XmArrowButtonGadget")] xmArrowButtonGadgetClass = 1,
        [ToolkitOption("XmArrowButton")] xmArrowButtonWidgetClass = 2,
        [ToolkitOption("XmBulletinBoard")] xmBulletinBoardWidgetClass = 3,
        [ToolkitOption("XmButtonBox")] xmButtonBoxWidgetClass = 4,
        [ToolkitOption("XmCascadeButtonGadget")] xmCascadeButtonGadgetClass = 5,
        [ToolkitOption("XmCascadeButton")] xmCascadeButtonWidgetClass = 6,
        [ToolkitOption("XmColorSelector")] xmColorSelectorWidgetClass = 7,
        [ToolkitOption("XmColumn")] xmColumnWidgetClass = 8,
        [ToolkitOption("XmComboBox")] xmComboBoxWidgetClass = 9,
        [ToolkitOption("XmCommand")] xmCommandWidgetClass = 10,
        [ToolkitOption("XmContainer")] xmContainerWidgetClass = 11,
        [ToolkitOption("XmDataField")] xmDataFieldWidgetClass = 12,
        [ToolkitOption("XmDialogShell")] xmDialogShellWidgetClass = 13,
        [ToolkitOption("XmDisplay")] xmDisplayClass = 14,
        [ToolkitOption("XmDragContext")] xmDragContextClass = 15,
        [ToolkitOption("XmDragIconObject")] xmDragIconObjectClass = 16,
        [ToolkitOption("XmDragOverShell")] xmDragOverShellWidgetClass = 17,
        [ToolkitOption("XmDrawingArea")] xmDrawingAreaWidgetClass = 18,
        [ToolkitOption("XmDrawnButton")] xmDrawnButtonWidgetClass = 19,
        [ToolkitOption("XmDropDown")] xmDropDownWidgetClass = 20,
        [ToolkitOption("XmDropSiteManagerObject")] xmDropSiteManagerObjectClass = 21,
        [ToolkitOption("XmDropTransferObject")] xmDropTransferObjectClass = 22,
        [ToolkitOption("XmFileSelectionBox")] xmFileSelectionBoxWidgetClass = 23,
        [ToolkitOption("XmFontSelector")] xmFontSelectorWidgetClass = 24,
        [ToolkitOption("XmForm")] xmFormWidgetClass = 25,
        [ToolkitOption("XmFrame")] xmFrameWidgetClass = 26,
        [ToolkitOption("XmGadget")] xmGadgetClass = 27,
        [ToolkitOption("XmGrabShell")] xmGrabShellWidgetClass = 28,
        [ToolkitOption("XmHierarchy")] xmHierarchyWidgetClass = 29,
        [ToolkitOption("XmIconBox")] xmIconBoxWidgetClass = 30,
        [ToolkitOption("XmIconButton")] xmIconButtonWidgetClass = 31,
        [ToolkitOption("XmIconGadget")] xmIconGadgetClass = 32,
        [ToolkitOption("XmIconHeader")] xmIconHeaderClass = 33,
        [ToolkitOption("XmLabelGadget")] xmLabelGadgetClass = 34,
        [ToolkitOption("XmLabel")] xmLabelWidgetClass = 35,
        [ToolkitOption("XmList")] xmListWidgetClass = 36,
        [ToolkitOption("XmMainWindow")] xmMainWindowWidgetClass = 37,
        [ToolkitOption("XmManager")] xmManagerWidgetClass = 38,
        [ToolkitOption("XmMenuShell")] xmMenuShellWidgetClass = 39,
        [ToolkitOption("XmMessageBox")] xmMessageBoxWidgetClass = 40,
        [ToolkitOption("XmMultiList")] xmMultiListWidgetClass = 41,
        [ToolkitOption("XmNotebook")] xmNotebookWidgetClass = 42,
        [ToolkitOption("XmOutline")] xmOutlineWidgetClass = 43,
        [ToolkitOption("XmPaned")] xmPanedWidgetClass = 44,
        [ToolkitOption("XmPanedWindow")] xmPanedWindowWidgetClass = 45,
        [ToolkitOption("XmPrimitive")] xmPrimitiveWidgetClass = 46,
        [ToolkitOption("XmPrintShell")] xmPrintShellWidgetClass = 47,
        [ToolkitOption("XmPushButtonGadget")] xmPushButtonGadgetClass = 48,
        [ToolkitOption("XmPushButton")] xmPushButtonWidgetClass = 49,
        [ToolkitOption("XmRowColumn")] xmRowColumnWidgetClass = 50,
        [ToolkitOption("XmScale")] xmScaleWidgetClass = 51,
        [ToolkitOption("XmScreen")] xmScreenClass = 52,
        [ToolkitOption("XmScrollBar")] xmScrollBarWidgetClass = 53,
        [ToolkitOption("XmScrolledWindow")] xmScrolledWindowWidgetClass = 54,
        [ToolkitOption("XmSelectionBox")] xmSelectionBoxWidgetClass = 55,
        [ToolkitOption("XmSeparatorGadget")] xmSeparatorGadgetClass = 56,
        [ToolkitOption("XmSeparator")] xmSeparatorWidgetClass = 57,
        [ToolkitOption("XmSimpleSpinBox")] xmSimpleSpinBoxWidgetClass = 58,
        [ToolkitOption("XmSpinBox")] xmSpinBoxWidgetClass = 59,
        [ToolkitOption("XmTabBox")] xmTabBoxWidgetClass = 60,
        [ToolkitOption("XmTabStack")] xmTabStackWidgetClass = 61,
        [ToolkitOption("XmTextField")] xmTextFieldWidgetClass = 62,
        [ToolkitOption("XmText")] xmTextWidgetClass = 63,
        [ToolkitOption("XmToggleButtonGadget")] xmToggleButtonGadgetClass = 64,
        [ToolkitOption("XmToggleButton")] xmToggleButtonWidgetClass = 65,
        [ToolkitOption("XmTree")] xmTreeWidgetClass = 66,
        [ToolkitOption("ﾄﾄﾄﾄﾄﾄﾄﾄﾄﾄﾄ")] MAX = 67
    }
}
