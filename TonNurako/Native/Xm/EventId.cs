//
// ﾄﾝﾇﾗｺ
// 
// Motif
//
using TonNurako.Native;

namespace TonNurako.Motif {

    /// <summary>
    /// MotifｲﾍﾞﾝﾄID
    /// </summary>
    public enum EventId {
        [ToolkitOption("activateCallback")]
        XmNactivateCallback,

        [ToolkitOption("applyCallback")]
        XmNapplyCallback,

        [ToolkitOption("armCallback")]
        XmNarmCallback,

        [ToolkitOption("browseSelectionCallback")]
        XmNbrowseSelectionCallback,

        [ToolkitOption("cancelCallback")]
        XmNcancelCallback,

        [ToolkitOption("cascadingCallback")]
        XmNcascadingCallback,

        [ToolkitOption("commandChangedCallback")]
        XmNcommandChangedCallback,

        [ToolkitOption("commandEnteredCallback")]
        XmNcommandEnteredCallback,

        [ToolkitOption("convertCallback")]
        XmNconvertCallback,

        [ToolkitOption("decrementCallback")]
        XmNdecrementCallback,

        [ToolkitOption("defaultActionCallback")]
        XmNdefaultActionCallback,

        [ToolkitOption("destinationCallback")]
        XmNdestinationCallback,

        [ToolkitOption("destroyCallback")]
        XmNdestroyCallback,

        [ToolkitOption("disarmCallback")]
        XmNdisarmCallback,

        [ToolkitOption("doubleClickCallback")]
        XmNdoubleClickCallback,

        [ToolkitOption("dragCallback")]
        XmNdragCallback,

        [ToolkitOption("dragDropFinishCallback")]
        XmNdragDropFinishCallback,

        [ToolkitOption("dragMotionCallback")]
        XmNdragMotionCallback,

        [ToolkitOption("dragStartCallback")]
        XmNdragStartCallback,

        [ToolkitOption("dropFinishCallback")]
        XmNdropFinishCallback,

        [ToolkitOption("dropSiteEnterCallback")]
        XmNdropSiteEnterCallback,

        [ToolkitOption("dropSiteLeaveCallback")]
        XmNdropSiteLeaveCallback,

        [ToolkitOption("dropStartCallback")]
        XmNdropStartCallback,

        [ToolkitOption("endJobCallback")]
        XmNendJobCallback,

        [ToolkitOption("entryCallback")]
        XmNentryCallback,

        [ToolkitOption("exposeCallback")]
        XmNexposeCallback,

        [ToolkitOption("extendedSelectionCallback")]
        XmNextendedSelectionCallback,

        [ToolkitOption("focusCallback")]
        XmNfocusCallback,

        [ToolkitOption("focusMovedCallback")]
        XmNfocusMovedCallback,

        [ToolkitOption("gainPrimaryCallback")]
        XmNgainPrimaryCallback,

        [ToolkitOption("helpCallback")]
        XmNhelpCallback,

        [ToolkitOption("incrementCallback")]
        XmNincrementCallback,

        [ToolkitOption("inputCallback")]
        XmNinputCallback,

        [ToolkitOption("itemFoundCallback")]
        XmNitemFoundCallback,

        [ToolkitOption("itemNotFoundCallback")]
        XmNitemNotFoundCallback,

        [ToolkitOption("losePrimaryCallback")]
        XmNlosePrimaryCallback,

        [ToolkitOption("losingFocusCallback")]
        XmNlosingFocusCallback,

        [ToolkitOption("mapCallback")]
        XmNmapCallback,

        [ToolkitOption("modifyVerifyCallback")]
        XmNmodifyVerifyCallback,

        [ToolkitOption("motionVerifyCallback")]
        XmNmotionVerifyCallback,

        [ToolkitOption("multipleSelectionCallback")]
        XmNmultipleSelectionCallback,

        [ToolkitOption("noFontCallback")]
        XmNnoFontCallback,

        [ToolkitOption("noMatchCallback")]
        XmNnoMatchCallback,

        [ToolkitOption("noRenditionCallback")]
        XmNnoRenditionCallback,

        [ToolkitOption("nodeStateBegEndCallback")]
        XmNnodeStateBegEndCallback,

        [ToolkitOption("nodeStateBeginEndCallback")]
        XmNnodeStateBeginEndCallback,

        [ToolkitOption("nodeStateCallback")]
        XmNnodeStateCallback,

        [ToolkitOption("nodeStateChangedCallback")]
        XmNnodeStateChangedCallback,

        [ToolkitOption("okCallback")]
        XmNokCallback,

        [ToolkitOption("operationChangedCallback")]
        XmNoperationChangedCallback,

        [ToolkitOption("outlineChangedCallback")]
        XmNoutlineChangedCallback,

        [ToolkitOption("pageChangedCallback")]
        XmNpageChangedCallback,

        [ToolkitOption("pageDecrementCallback")]
        XmNpageDecrementCallback,

        [ToolkitOption("pageIncrementCallback")]
        XmNpageIncrementCallback,

        [ToolkitOption("pageSetupCallback")]
        XmNpageSetupCallback,

        [ToolkitOption("pdmNotificationCallback")]
        XmNpdmNotificationCallback,

        [ToolkitOption("pictureErrorCallback")]
        XmNpictureErrorCallback,

        [ToolkitOption("popdownCallback")]
        XmNpopdownCallback,

        [ToolkitOption("popupCallback")]
        XmNpopupCallback,

        [ToolkitOption("popupHandlerCallback")]
        XmNpopupHandlerCallback,

        [ToolkitOption("preeditCaretCallback")]
        XmNpreeditCaretCallback,

        [ToolkitOption("preeditDoneCallback")]
        XmNpreeditDoneCallback,

        [ToolkitOption("preeditDrawCallback")]
        XmNpreeditDrawCallback,

        [ToolkitOption("preeditStartCallback")]
        XmNpreeditStartCallback,

        [ToolkitOption("protocolCallback")]
        XmNprotocolCallback,

        [ToolkitOption("realizeCallback")]
        XmNrealizeCallback,

        [ToolkitOption("resizeCallback")]
        XmNresizeCallback,

        [ToolkitOption("selectCallback")]
        XmNselectCallback,

        [ToolkitOption("selectionCallback")]
        XmNselectionCallback,

        [ToolkitOption("simpleCallback")]
        XmNsimpleCallback,

        [ToolkitOption("singleSelectionCallback")]
        XmNsingleSelectionCallback,

        [ToolkitOption("startJobCallback")]
        XmNstartJobCallback,

        [ToolkitOption("tabSelectedCallback")]
        XmNtabSelectedCallback,

        [ToolkitOption("tearOffMenuActivateCallback")]
        XmNtearOffMenuActivateCallback,

        [ToolkitOption("tearOffMenuDeactivateCallback")]
        XmNtearOffMenuDeactivateCallback,

        [ToolkitOption("toBottomCallback")]
        XmNtoBottomCallback,

        [ToolkitOption("toPositionCallback")]
        XmNtoPositionCallback,

        [ToolkitOption("toTopCallback")]
        XmNtoTopCallback,

        [ToolkitOption("topLevelEnterCallback")]
        XmNtopLevelEnterCallback,

        [ToolkitOption("topLevelLeaveCallback")]
        XmNtopLevelLeaveCallback,

        [ToolkitOption("traversalCallback")]
        XmNtraversalCallback,

        [ToolkitOption("traverseObscuredCallback")]
        XmNtraverseObscuredCallback,

        [ToolkitOption("unmapCallback")]
        XmNunmapCallback,

        [ToolkitOption("unselectCallback")]
        XmNunselectCallback,

        [ToolkitOption("updateShellCallback")]
        XmNupdateShellCallback,

        [ToolkitOption("updateTextCallback")]
        XmNupdateTextCallback,

        [ToolkitOption("validateCallback")]
        XmNvalidateCallback,

        [ToolkitOption("valueChangedCallback")]
        XmNvalueChangedCallback,

        [ToolkitOption("verifyTextCallback")]
        XmNverifyTextCallback,

        [ToolkitOption("verifyTextFailedCallback")]
        XmNverifyTextFailedCallback


    }
}
