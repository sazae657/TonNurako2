using System;
using TonNurako.Native;

namespace TonNurako.Motif {
    public enum ResourceId {
        [ToolkitOption("accelerator")]
        XmNaccelerator,

        [ToolkitOption("acceleratorText")]
        XmNacceleratorText,

        [ToolkitOption("accelerators")]
        XmNaccelerators,

        [ToolkitOption("activeColorSetId")]
        XmNactiveColorSetId,

        [ToolkitOption("adjustLast")]
        XmNadjustLast,

        [ToolkitOption("adjustMargin")]
        XmNadjustMargin,

        [ToolkitOption("alignment")]
        XmNalignment,

        [ToolkitOption("allowOverlap")]
        XmNallowOverlap,

        [ToolkitOption("allowResize")]
        XmNallowResize,

        [ToolkitOption("allowShellResize")]
        XmNallowShellResize,

        [ToolkitOption("allowUnusedSpace")]
        XmNallowUnusedSpace,

        [ToolkitOption("ancestorSensitive")]
        XmNancestorSensitive,

        [ToolkitOption("animate")]
        XmNanimate,

        [ToolkitOption("animationMask")]
        XmNanimationMask,

        [ToolkitOption("animationPixmap")]
        XmNanimationPixmap,

        [ToolkitOption("animationPixmapDepth")]
        XmNanimationPixmapDepth,

        [ToolkitOption("animationStyle")]
        XmNanimationStyle,

        [ToolkitOption("anyLowerString")]
        XmNanyLowerString,

        [ToolkitOption("anyString")]
        XmNanyString,

        [ToolkitOption("applyLabelString")]
        XmNapplyLabelString,

        [ToolkitOption("area")]
        XmNarea,

        [ToolkitOption("argc")]
        XmNargc,

        [ToolkitOption("argv")]
        XmNargv,

        [ToolkitOption("armColor")]
        XmNarmColor,

        [ToolkitOption("armPixmap")]
        XmNarmPixmap,

        [ToolkitOption("arrowDirection")]
        XmNarrowDirection,

        [ToolkitOption("arrowLayout")]
        XmNarrowLayout,

        [ToolkitOption("arrowOrientation")]
        XmNarrowOrientation,

        [ToolkitOption("arrowSensitivity")]
        XmNarrowSensitivity,

        [ToolkitOption("arrowSize")]
        XmNarrowSize,

        [ToolkitOption("arrowSpacing")]
        XmNarrowSpacing,

        [ToolkitOption("attachment")]
        XmNattachment,

        [ToolkitOption("audibleWarning")]
        XmNaudibleWarning,

        [ToolkitOption("autoClose")]
        XmNautoClose,

        [ToolkitOption("autoDragModel")]
        XmNautoDragModel,

        [ToolkitOption("autoFill")]
        XmNautoFill,

        [ToolkitOption("autoShowCursorPosition")]
        XmNautoShowCursorPosition,

        [ToolkitOption("autoUnmanage")]
        XmNautoUnmanage,

        [ToolkitOption("automaticSelection")]
        XmNautomaticSelection,

        [ToolkitOption("availability")]
        XmNavailability,

        [ToolkitOption("backPageBackground")]
        XmNbackPageBackground,

        [ToolkitOption("backPageForeground")]
        XmNbackPageForeground,

        [ToolkitOption("backPageNumber")]
        XmNbackPageNumber,

        [ToolkitOption("backPagePlacement")]
        XmNbackPagePlacement,

        [ToolkitOption("backPageSize")]
        XmNbackPageSize,

        [ToolkitOption("background")]
        XmNbackground,

        [ToolkitOption("backgroundPixmap")]
        XmNbackgroundPixmap,

        [ToolkitOption("backgroundState")]
        XmNbackgroundState,

        [ToolkitOption("badActionParameters")]
        XmNbadActionParameters,

        [ToolkitOption("badMotionParams")]
        XmNbadMotionParams,

        [ToolkitOption("badRowPixmap")]
        XmNbadRowPixmap,

        [ToolkitOption("badXlfdFont")]
        XmNbadXlfdFont,

        [ToolkitOption("baseHeight")]
        XmNbaseHeight,

        [ToolkitOption("baseWidth")]
        XmNbaseWidth,

        [ToolkitOption("bidirectionalCursor")]
        XmNbidirectionalCursor,

        [ToolkitOption("bindingPixmap")]
        XmNbindingPixmap,

        [ToolkitOption("bindingType")]
        XmNbindingType,

        [ToolkitOption("bindingWidth")]
        XmNbindingWidth,

        [ToolkitOption("bitmap")]
        XmNbitmap,

        [ToolkitOption("bitmapConversionModel")]
        XmNbitmapConversionModel,

        [ToolkitOption("blendModel")]
        XmNblendModel,

        [ToolkitOption("blinkRate")]
        XmNblinkRate,

        [ToolkitOption("blueSliderLabel")]
        XmNblueSliderLabel,

        [ToolkitOption("boldString")]
        XmNboldString,

        [ToolkitOption("borderColor")]
        XmNborder,

        [ToolkitOption("borderColor")]
        XmNborderColor,

        [ToolkitOption("borderPixmap")]
        XmNborderPixmap,

        [ToolkitOption("borderWidth")]
        XmNborderWidth,

        [ToolkitOption("bothString")]
        XmNbothString,

        [ToolkitOption("bottomAttachment")]
        XmNbottomAttachment,

        [ToolkitOption("bottomOffset")]
        XmNbottomOffset,

        [ToolkitOption("bottomPosition")]
        XmNbottomPosition,

        [ToolkitOption("bottomShadowColor")]
        XmNbottomShadowColor,

        [ToolkitOption("bottomShadowPixmap")]
        XmNbottomShadowPixmap,

        [ToolkitOption("bottomWidget")]
        XmNbottomWidget,

        [ToolkitOption("buttonAcceleratorText")]
        XmNbuttonAcceleratorText,

        [ToolkitOption("buttonAccelerators")]
        XmNbuttonAccelerators,

        [ToolkitOption("buttonCount")]
        XmNbuttonCount,

        [ToolkitOption("buttonFontList")]
        XmNbuttonFontList,

        [ToolkitOption("buttonMnemonicCharSets")]
        XmNbuttonMnemonicCharSets,

        [ToolkitOption("buttonMnemonics")]
        XmNbuttonMnemonics,

        [ToolkitOption("buttonRenderTable")]
        XmNbuttonRenderTable,

        [ToolkitOption("buttonSet")]
        XmNbuttonSet,

        [ToolkitOption("buttonType")]
        XmNbuttonType,

        [ToolkitOption("buttons")]
        XmNbuttons,

        [ToolkitOption("callback")]
        XmNcallback,

        [ToolkitOption("cancelButton")]
        XmNcancelButton,

        [ToolkitOption("cancelLabelString")]
        XmNcancelLabelString,

        [ToolkitOption("cascadePixmap")]
        XmNcascadePixmap,

        [ToolkitOption("cellNotEmpty")]
        XmNcellNotEmpty,

        [ToolkitOption("cellX")]
        XmNcellX,

        [ToolkitOption("cellY")]
        XmNcellY,

        [ToolkitOption("childHorizontalAlignment")]
        XmNchildHorizontalAlignment,

        [ToolkitOption("childHorizontalSpacing")]
        XmNchildHorizontalSpacing,

        [ToolkitOption("childPlacement")]
        XmNchildPlacement,

        [ToolkitOption("childPosition")]
        XmNchildPosition,

        [ToolkitOption("childType")]
        XmNchildType,

        [ToolkitOption("childVerticalAlignment")]
        XmNchildVerticalAlignment,

        [ToolkitOption("children")]
        XmNchildren,

        [ToolkitOption("clientData")]
        XmNclientData,

        [ToolkitOption("clipWindow")]
        XmNclipWindow,

        [ToolkitOption("closeFolderPixmap")]
        XmNcloseFolderPixmap,

        [ToolkitOption("collapsedStatePixmap")]
        XmNcollapsedStatePixmap,

        [ToolkitOption("colorAllocationProc")]
        XmNcolorAllocationProc,

        [ToolkitOption("colorCalculationProc")]
        XmNcolorCalculationProc,

        [ToolkitOption("colorListTogLabel")]
        XmNcolorListTogLabel,

        [ToolkitOption("colorMode")]
        XmNcolorMode,

        [ToolkitOption("colorName")]
        XmNcolorName,

        [ToolkitOption("colorNameTooLong")]
        XmNcolorNameTooLong,

        [ToolkitOption("colormap")]
        XmNcolormap,

        [ToolkitOption("columnTitles")]
        XmNcolumnTitles,

        [ToolkitOption("columns")]
        XmNcolumns,

        [ToolkitOption("comboBoxType")]
        XmNcomboBoxType,

        [ToolkitOption("comboTranslations")]
        XmNcomboTranslations,

        [ToolkitOption("command")]
        XmNcommand,

        [ToolkitOption("commandWindow")]
        XmNcommandWindow,

        [ToolkitOption("commandWindowLocation")]
        XmNcommandWindowLocation,

        [ToolkitOption("compressStyle")]
        XmNcompressStyle,

        [ToolkitOption("connectNodes")]
        XmNconnectNodes,

        [ToolkitOption("connectStyle")]
        XmNconnectStyle,

        [ToolkitOption("constrainWidth")]
        XmNconstrainWidth,

        [ToolkitOption("containerID")]
        XmNcontainerID,

        [ToolkitOption("contextSaveFailed")]
        XmNcontextSaveFailed,

        [ToolkitOption("conversionFailure")]
        XmNconversionFailure,

        [ToolkitOption("convertProc")]
        XmNconvertProc,

        [ToolkitOption("couldNotFindFamilyData")]
        XmNcouldNotFindFamilyData,

        [ToolkitOption("createPopupChildProc")]
        XmNcreatePopupChildProc,

        [ToolkitOption("currentFont")]
        XmNcurrentFont,

        [ToolkitOption("currentPageNumber")]
        XmNcurrentPageNumber,

        [ToolkitOption("cursor")]
        XmNcursor,

        [ToolkitOption("cursorBackground")]
        XmNcursorBackground,

        [ToolkitOption("cursorForeground")]
        XmNcursorForeground,

        [ToolkitOption("cursorPosition")]
        XmNcursorPosition,

        [ToolkitOption("cursorPositionVisible")]
        XmNcursorPositionVisible,

        [ToolkitOption("customizedCombinationBox")]
        XmNcustomizedCombinationBox,

        [ToolkitOption("dFieldMaxHeight")]
        XmNdFieldMaxHeight,

        [ToolkitOption("dFieldMaxWidth")]
        XmNdFieldMaxWidth,

        [ToolkitOption("dFieldMinHeight")]
        XmNdFieldMinHeight,

        [ToolkitOption("dFieldMinWidth")]
        XmNdFieldMinWidth,

        [ToolkitOption("dFieldPrefHeight")]
        XmNdFieldPrefHeight,

        [ToolkitOption("dFieldPrefWidth")]
        XmNdFieldPrefWidth,

        [ToolkitOption("darkThreshold")]
        XmNdarkThreshold,

        [ToolkitOption("decimal")]
        XmNdecimal,

        [ToolkitOption("decimalPoints")]
        XmNdecimalPoints,

        [ToolkitOption("defaultArrowSensitivity")]
        XmNdefaultArrowSensitivity,

        [ToolkitOption("defaultButton")]
        XmNdefaultButton,

        [ToolkitOption("defaultButtonEmphasis")]
        XmNdefaultButtonEmphasis,

        [ToolkitOption("defaultButtonShadowThickness")]
        XmNdefaultButtonShadowThickness,

        [ToolkitOption("defaultButtonType")]
        XmNdefaultButtonType,

        [ToolkitOption("defaultCopyCursorIcon")]
        XmNdefaultCopyCursorIcon,

        [ToolkitOption("defaultEncodingString")]
        XmNdefaultEncodingString,

        [ToolkitOption("defaultEntryLabelAlignment")]
        XmNdefaultEntryLabelAlignment,

        [ToolkitOption("defaultEntryLabelFontList")]
        XmNdefaultEntryLabelFontList,

        [ToolkitOption("defaultEntryLabelRenderTable")]
        XmNdefaultEntryLabelRenderTable,

        [ToolkitOption("defaultFillStyle")]
        XmNdefaultFillStyle,

        [ToolkitOption("defaultFontList")]
        XmNdefaultFontList,

        [ToolkitOption("defaultGlyphPixmap")]
        XmNdefaultGlyphPixmap,

        [ToolkitOption("defaultInvalidCursorIcon")]
        XmNdefaultInvalidCursorIcon,

        [ToolkitOption("defaultLinkCursorIcon")]
        XmNdefaultLinkCursorIcon,

        [ToolkitOption("defaultMoveCursorIcon")]
        XmNdefaultMoveCursorIcon,

        [ToolkitOption("defaultNoneCursorIcon")]
        XmNdefaultNoneCursorIcon,

        [ToolkitOption("defaultPixmapResolution")]
        XmNdefaultPixmapResolution,

        [ToolkitOption("defaultPosition")]
        XmNdefaultPosition,

        [ToolkitOption("defaultSourceCursorIcon")]
        XmNdefaultSourceCursorIcon,

        [ToolkitOption("defaultValidCursorIcon")]
        XmNdefaultValidCursorIcon,

        [ToolkitOption("defaultVirtualBindings")]
        XmNdefaultVirtualBindings,

        [ToolkitOption("deleteResponse")]
        XmNdeleteResponse,

        [ToolkitOption("depth")]
        XmNdepth,

        [ToolkitOption("desktopParent")]
        XmNdesktopParent,

        [ToolkitOption("detail")]
        XmNdetail,

        [ToolkitOption("detailColumnHeading")]
        XmNdetailColumnHeading,

        [ToolkitOption("detailColumnHeadingCount")]
        XmNdetailColumnHeadingCount,

        [ToolkitOption("detailCount")]
        XmNdetailCount,

        [ToolkitOption("detailOrder")]
        XmNdetailOrder,

        [ToolkitOption("detailOrderCount")]
        XmNdetailOrderCount,

        [ToolkitOption("detailShadowThickness")]
        XmNdetailShadowThickness,

        [ToolkitOption("detailTabList")]
        XmNdetailTabList,

        [ToolkitOption("dialogStyle")]
        XmNdialogStyle,

        [ToolkitOption("dialogTitle")]
        XmNdialogTitle,

        [ToolkitOption("dialogType")]
        XmNdialogType,

        [ToolkitOption("dirListItemCount")]
        XmNdirListItemCount,

        [ToolkitOption("dirListItems")]
        XmNdirListItems,

        [ToolkitOption("dirListLabelString")]
        XmNdirListLabelString,

        [ToolkitOption("dirMask")]
        XmNdirMask,

        [ToolkitOption("dirSearchProc")]
        XmNdirSearchProc,

        [ToolkitOption("dirSpec")]
        XmNdirSpec,

        [ToolkitOption("dirTextLabelString")]
        XmNdirTextLabelString,

        [ToolkitOption("directory")]
        XmNdirectory,

        [ToolkitOption("directoryValid")]
        XmNdirectoryValid,

        [ToolkitOption("distribution")]
        XmNdistribution,

        [ToolkitOption("doubleClickInterval")]
        XmNdoubleClickInterval,

        [ToolkitOption("dragContextClass")]
        XmNdragContextClass,

        [ToolkitOption("dragIconClass")]
        XmNdragIconClass,

        [ToolkitOption("dragInitiatorProtocolStyle")]
        XmNdragInitiatorProtocolStyle,

        [ToolkitOption("dragOperations")]
        XmNdragOperations,

        [ToolkitOption("dragOverActiveMode")]
        XmNdragOverActiveMode,

        [ToolkitOption("dragOverMode")]
        XmNdragOverMode,

        [ToolkitOption("dragProc")]
        XmNdragProc,

        [ToolkitOption("dragReceiverProtocolStyle")]
        XmNdragReceiverProtocolStyle,

        [ToolkitOption("dropProc")]
        XmNdropProc,

        [ToolkitOption("dropRectangles")]
        XmNdropRectangles,

        [ToolkitOption("dropSiteActivity")]
        XmNdropSiteActivity,

        [ToolkitOption("dropSiteManagerClass")]
        XmNdropSiteManagerClass,

        [ToolkitOption("dropSiteOperations")]
        XmNdropSiteOperations,

        [ToolkitOption("dropSiteType")]
        XmNdropSiteType,

        [ToolkitOption("dropTransferClass")]
        XmNdropTransferClass,

        [ToolkitOption("dropTransfers")]
        XmNdropTransfers,

        [ToolkitOption("editMode")]
        XmNeditMode,

        [ToolkitOption("editType")]
        XmNeditType,

        [ToolkitOption("editable")]
        XmNeditable,

        [ToolkitOption("editingPath")]
        XmNeditingPath,

        [ToolkitOption("enableBtn1Transfer")]
        XmNenableBtn1Transfer,

        [ToolkitOption("enableButtonTab")]
        XmNenableButtonTab,

        [ToolkitOption("enableDragIcon")]
        XmNenableDragIcon,

        [ToolkitOption("enableEtchedInMenu")]
        XmNenableEtchedInMenu,

        [ToolkitOption("enableMultiKeyBindings")]
        XmNenableMultiKeyBindings,

        [ToolkitOption("enableThinThickness")]
        XmNenableThinThickness,

        [ToolkitOption("enableToggleColor")]
        XmNenableToggleColor,

        [ToolkitOption("enableToggleVisual")]
        XmNenableToggleVisual,

        [ToolkitOption("enableUnselectableDrag")]
        XmNenableUnselectableDrag,

        [ToolkitOption("enableWarp")]
        XmNenableWarp,

        [ToolkitOption("encodingList")]
        XmNencodingList,

        [ToolkitOption("encodingString")]
        XmNencodingString,

        [ToolkitOption("entryAlignment")]
        XmNentryAlignment,

        [ToolkitOption("entryBackground")]
        XmNentryBackground,

        [ToolkitOption("entryBorder")]
        XmNentryBorder,

        [ToolkitOption("entryClass")]
        XmNentryClass,

        [ToolkitOption("entryData")]
        XmNentryData,

        [ToolkitOption("entryLabelAlignment")]
        XmNentryLabelAlignment,

        [ToolkitOption("entryLabelFontList")]
        XmNentryLabelFontList,

        [ToolkitOption("entryLabelPixmap")]
        XmNentryLabelPixmap,

        [ToolkitOption("entryLabelRenderTable")]
        XmNentryLabelRenderTable,

        [ToolkitOption("entryLabelString")]
        XmNentryLabelString,

        [ToolkitOption("entryLabelType")]
        XmNentryLabelType,

        [ToolkitOption("entryParent")]
        XmNentryParent,

        [ToolkitOption("entryVerticalAlignment")]
        XmNentryVerticalAlignment,

        [ToolkitOption("entryViewType")]
        XmNentryViewType,

        [ToolkitOption("equalSize")]
        XmNequalSize,

        [ToolkitOption("expandedStatePixmap")]
        XmNexpandedStatePixmap,

        [ToolkitOption("exportTargets")]
        XmNexportTargets,

        [ToolkitOption("extensionType")]
        XmNextensionType,

        [ToolkitOption("familyString")]
        XmNfamilyString,

        [ToolkitOption("file")]
        XmNfile,

        [ToolkitOption("fileFilterStyle")]
        XmNfileFilterStyle,

        [ToolkitOption("fileListItemCount")]
        XmNfileListItemCount,

        [ToolkitOption("fileListItems")]
        XmNfileListItems,

        [ToolkitOption("fileListLabelString")]
        XmNfileListLabelString,

        [ToolkitOption("fileReadError")]
        XmNfileReadError,

        [ToolkitOption("fileSearchProc")]
        XmNfileSearchProc,

        [ToolkitOption("fileTypeMask")]
        XmNfileTypeMask,

        [ToolkitOption("fillOnArm")]
        XmNfillOnArm,

        [ToolkitOption("fillOnSelect")]
        XmNfillOnSelect,

        [ToolkitOption("fillOption")]
        XmNfillOption,

        [ToolkitOption("fillStyle")]
        XmNfillStyle,

        [ToolkitOption("filterLabelString")]
        XmNfilterLabelString,

        [ToolkitOption("findLabel")]
        XmNfindLabel,

        [ToolkitOption("firstColumn")]
        XmNfirstColumn,

        [ToolkitOption("firstColumnPixmaps")]
        XmNfirstColumnPixmaps,

        [ToolkitOption("firstPageNumber")]
        XmNfirstPageNumber,

        [ToolkitOption("firstRow")]
        XmNfirstRow,

        [ToolkitOption("focusPolicyChanged")]
        XmNfocusPolicyChanged,

        [ToolkitOption("font")]
        XmNfont,

        [ToolkitOption("fontEncoding")]
        XmNfontEncoding,

        [ToolkitOption("fontFoundry")]
        XmNfontFoundry,

        [ToolkitOption("fontList")]
        XmNfontList,

        [ToolkitOption("fontName")]
        XmNfontName,

        [ToolkitOption("fontSet")]
        XmNfontSet,

        [ToolkitOption("fontSize")]
        XmNfontSize,

        [ToolkitOption("fontStyle")]
        XmNfontStyle,

        [ToolkitOption("fontType")]
        XmNfontType,

        [ToolkitOption("forceBars")]
        XmNforceBars,

        [ToolkitOption("forceGreaterThanZero")]
        XmNforceGreaterThanZero,

        [ToolkitOption("foreground")]
        XmNforeground,

        [ToolkitOption("foregroundState")]
        XmNforegroundState,

        [ToolkitOption("foregroundThreshold")]
        XmNforegroundThreshold,

        [ToolkitOption("fractionBase")]
        XmNfractionBase,

        [ToolkitOption("frameBackground")]
        XmNframeBackground,

        [ToolkitOption("frameChildType")]
        XmNframeChildType,

        [ToolkitOption("frameShadowThickness")]
        XmNframeShadowThickness,

        [ToolkitOption("freeTabPixmap")]
        XmNfreeTabPixmap,

        [ToolkitOption("function")]
        XmNfunction,

        [ToolkitOption("geometry")]
        XmNgeometry,

        [ToolkitOption("grabStyle")]
        XmNgrabStyle,

        [ToolkitOption("greenSliderLabel")]
        XmNgreenSliderLabel,

        [ToolkitOption("height")]
        XmNheight,

        [ToolkitOption("heightInc")]
        XmNheightInc,

        [ToolkitOption("helpLabelString")]
        XmNhelpLabelString,

        [ToolkitOption("highlight")]
        XmNhighlight,

        [ToolkitOption("highlightColor")]
        XmNhighlightColor,

        [ToolkitOption("highlightOnEnter")]
        XmNhighlightOnEnter,

        [ToolkitOption("highlightPixmap")]
        XmNhighlightPixmap,

        [ToolkitOption("highlightThickness")]
        XmNhighlightThickness,

        [ToolkitOption("historyItemCount")]
        XmNhistoryItemCount,

        [ToolkitOption("historyItems")]
        XmNhistoryItems,

        [ToolkitOption("historyMaxItems")]
        XmNhistoryMaxItems,

        [ToolkitOption("historyVisibleItemCount")]
        XmNhistoryVisibleItemCount,

        [ToolkitOption("horizontalDelta")]
        XmNhorizontalDelta,

        [ToolkitOption("horizontalFontUnit")]
        XmNhorizontalFontUnit,

        [ToolkitOption("horizontalMargin")]
        XmNhorizontalMargin,

        [ToolkitOption("horizontalNodeSpace")]
        XmNhorizontalNodeSpace,

        [ToolkitOption("horizontalScrollBar")]
        XmNhorizontalScrollBar,

        [ToolkitOption("horizontalSpacing")]
        XmNhorizontalSpacing,

        [ToolkitOption("hotX")]
        XmNhotX,

        [ToolkitOption("hotY")]
        XmNhotY,

        [ToolkitOption("iccHandle")]
        XmNiccHandle,

        [ToolkitOption("iconMask")]
        XmNiconMask,

        [ToolkitOption("iconName")]
        XmNiconName,

        [ToolkitOption("iconNameEncoding")]
        XmNiconNameEncoding,

        [ToolkitOption("iconPixmap")]
        XmNiconPixmap,

        [ToolkitOption("iconPlacement")]
        XmNiconPlacement,

        [ToolkitOption("iconTextPadding")]
        XmNiconTextPadding,

        [ToolkitOption("iconWindow")]
        XmNiconWindow,

        [ToolkitOption("iconX")]
        XmNiconX,

        [ToolkitOption("iconY")]
        XmNiconY,

        [ToolkitOption("iconic")]
        XmNiconic,

        [ToolkitOption("illegalResourceValue")]
        XmNillegalResourceValue,

        [ToolkitOption("importTargets")]
        XmNimportTargets,

        [ToolkitOption("inactiveColorSetId")]
        XmNinactiveColorSetId,

        [ToolkitOption("includeStatus")]
        XmNincludeStatus,

        [ToolkitOption("increment")]
        XmNincrement,

        [ToolkitOption("incrementValue")]
        XmNincrementValue,

        [ToolkitOption("incremental")]
        XmNincremental,

        [ToolkitOption("indentSpace")]
        XmNindentSpace,

        [ToolkitOption("indeterminateInsensitivePixmap")]
        XmNindeterminateInsensitivePixmap,

        [ToolkitOption("indeterminatePixmap")]
        XmNindeterminatePixmap,

        [ToolkitOption("index")]
        XmNindex,

        [ToolkitOption("indicatorOn")]
        XmNindicatorOn,

        [ToolkitOption("indicatorSize")]
        XmNindicatorSize,

        [ToolkitOption("indicatorType")]
        XmNindicatorType,

        [ToolkitOption("initialDelay")]
        XmNinitialDelay,

        [ToolkitOption("initialFocus")]
        XmNinitialFocus,

        [ToolkitOption("initialResourcesPersistent")]
        XmNinitialResourcesPersistent,

        [ToolkitOption("initialState")]
        XmNinitialState,

        [ToolkitOption("innerHeight")]
        XmNinnerHeight,

        [ToolkitOption("innerMarginHeight")]
        XmNinnerMarginHeight,

        [ToolkitOption("innerMarginWidth")]
        XmNinnerMarginWidth,

        [ToolkitOption("innerWidth")]
        XmNinnerWidth,

        [ToolkitOption("innerWindow")]
        XmNinnerWindow,

        [ToolkitOption("input")]
        XmNinput,

        [ToolkitOption("inputCreate")]
        XmNinputCreate,

        [ToolkitOption("inputMethod")]
        XmNinputMethod,

        [ToolkitOption("inputPolicy")]
        XmNinputPolicy,

        [ToolkitOption("insensitiveStippleBitmap")]
        XmNinsensitiveStippleBitmap,

        [ToolkitOption("insertBefore")]
        XmNinsertBefore,

        [ToolkitOption("insertBeforeNotSibling")]
        XmNinsertBeforeNotSibling,

        [ToolkitOption("insertPosition")]
        XmNinsertPosition,

        [ToolkitOption("installColormap")]
        XmNinstallColormap,

        [ToolkitOption("internalHeight")]
        XmNinternalHeight,

        [ToolkitOption("internalWidth")]
        XmNinternalWidth,

        [ToolkitOption("invalidCursorForeground")]
        XmNinvalidCursorForeground,

        [ToolkitOption("invokeParseProc")]
        XmNinvokeParseProc,

        [ToolkitOption("isAligned")]
        XmNisAligned,

        [ToolkitOption("isHomogeneous")]
        XmNisHomogeneous,

        [ToolkitOption("italicString")]
        XmNitalicString,

        [ToolkitOption("itemCount")]
        XmNitemCount,

        [ToolkitOption("itemSpacing")]
        XmNitemSpacing,

        [ToolkitOption("items")]
        XmNitems,

        [ToolkitOption("jumpProc")]
        XmNjumpProc,

        [ToolkitOption("justify")]
        XmNjustify,

        [ToolkitOption("keyboardFocusPolicy")]
        XmNkeyboardFocusPolicy,

        [ToolkitOption("label")]
        XmNlabel,

        [ToolkitOption("labelFontList")]
        XmNlabelFontList,

        [ToolkitOption("labelInsensitivePixmap")]
        XmNlabelInsensitivePixmap,

        [ToolkitOption("labelPixmap")]
        XmNlabelPixmap,

        [ToolkitOption("labelRenderTable")]
        XmNlabelRenderTable,

        [ToolkitOption("labelSpacing")]
        XmNlabelSpacing,

        [ToolkitOption("labelString")]
        XmNlabelString,

        [ToolkitOption("labelType")]
        XmNlabelType,

        [ToolkitOption("largeCellHeight")]
        XmNlargeCellHeight,

        [ToolkitOption("largeCellWidth")]
        XmNlargeCellWidth,

        [ToolkitOption("largeIcon")]
        XmNlargeIcon,

        [ToolkitOption("largeIconMask")]
        XmNlargeIconMask,

        [ToolkitOption("largeIconPixmap")]
        XmNlargeIconPixmap,

        [ToolkitOption("largeIconX")]
        XmNlargeIconX,

        [ToolkitOption("largeIconY")]
        XmNlargeIconY,

        [ToolkitOption("lastPageNumber")]
        XmNlastPageNumber,

        [ToolkitOption("layoutDirection")]
        XmNlayoutDirection,

        [ToolkitOption("layoutType")]
        XmNlayoutType,

        [ToolkitOption("leftAttachment")]
        XmNleftAttachment,

        [ToolkitOption("leftOffset")]
        XmNleftOffset,

        [ToolkitOption("leftPosition")]
        XmNleftPosition,

        [ToolkitOption("leftWidget")]
        XmNleftWidget,

        [ToolkitOption("length")]
        XmNlength,

        [ToolkitOption("lightThreshold")]
        XmNlightThreshold,

        [ToolkitOption("lineBackgroundColor")]
        XmNlineBackgroundColor,

        [ToolkitOption("lineColor")]
        XmNlineColor,

        [ToolkitOption("lineSpace")]
        XmNlineSpace,

        [ToolkitOption("lineStyle")]
        XmNlineStyle,

        [ToolkitOption("lineWidth")]
        XmNlineWidth,

        [ToolkitOption("list")]
        XmNlist,

        [ToolkitOption("listItemCount")]
        XmNlistItemCount,

        [ToolkitOption("listItems")]
        XmNlistItems,

        [ToolkitOption("listLabelString")]
        XmNlistLabelString,

        [ToolkitOption("listMarginHeight")]
        XmNlistMarginHeight,

        [ToolkitOption("listMarginWidth")]
        XmNlistMarginWidth,

        [ToolkitOption("listSizePolicy")]
        XmNlistSizePolicy,

        [ToolkitOption("listSpacing")]
        XmNlistSpacing,

        [ToolkitOption("listUpdated")]
        XmNlistUpdated,

        [ToolkitOption("listVisibleItemCount")]
        XmNlistVisibleItemCount,

        [ToolkitOption("loadModel")]
        XmNloadModel,

        [ToolkitOption("logicalParent")]
        XmNlogicalParent,

        [ToolkitOption("lowerRight")]
        XmNlowerRight,

        [ToolkitOption("mainWindowMarginHeight")]
        XmNmainWindowMarginHeight,

        [ToolkitOption("mainWindowMarginWidth")]
        XmNmainWindowMarginWidth,

        [ToolkitOption("majorTabSpacing")]
        XmNmajorTabSpacing,

        [ToolkitOption("mappedWhenManaged")]
        XmNmappedWhenManaged,

        [ToolkitOption("mappingDelay")]
        XmNmappingDelay,

        [ToolkitOption("margin")]
        XmNmargin,

        [ToolkitOption("marginBottom")]
        XmNmarginBottom,

        [ToolkitOption("marginHeight")]
        XmNmarginHeight,

        [ToolkitOption("marginLeft")]
        XmNmarginLeft,

        [ToolkitOption("marginRight")]
        XmNmarginRight,

        [ToolkitOption("marginTop")]
        XmNmarginTop,

        [ToolkitOption("marginWidth")]
        XmNmarginWidth,

        [ToolkitOption("mask")]
        XmNmask,

        [ToolkitOption("matchBehavior")]
        XmNmatchBehavior,

        [ToolkitOption("maxAspectX")]
        XmNmaxAspectX,

        [ToolkitOption("maxAspectY")]
        XmNmaxAspectY,

        [ToolkitOption("maxHeight")]
        XmNmaxHeight,

        [ToolkitOption("maxLength")]
        XmNmaxLength,

        [ToolkitOption("maxWidth")]
        XmNmaxWidth,

        [ToolkitOption("maxX")]
        XmNmaxX,

        [ToolkitOption("maxY")]
        XmNmaxY,

        [ToolkitOption("maximum")]
        XmNmaximum,

        [ToolkitOption("maximumValue")]
        XmNmaximumValue,

        [ToolkitOption("menuAccelerator")]
        XmNmenuAccelerator,

        [ToolkitOption("menuBar")]
        XmNmenuBar,

        [ToolkitOption("menuCursor")]
        XmNmenuCursor,

        [ToolkitOption("menuEntry")]
        XmNmenuEntry,

        [ToolkitOption("menuHelpWidget")]
        XmNmenuHelpWidget,

        [ToolkitOption("menuHistory")]
        XmNmenuHistory,

        [ToolkitOption("menuPost")]
        XmNmenuPost,

        [ToolkitOption("messageAlignment")]
        XmNmessageAlignment,

        [ToolkitOption("messageProc")]
        XmNmessageProc,

        [ToolkitOption("messageString")]
        XmNmessageString,

        [ToolkitOption("messageWindow")]
        XmNmessageWindow,

        [ToolkitOption("minAspectX")]
        XmNminAspectX,

        [ToolkitOption("minAspectY")]
        XmNminAspectY,

        [ToolkitOption("minHeight")]
        XmNminHeight,

        [ToolkitOption("minWidth")]
        XmNminWidth,

        [ToolkitOption("minX")]
        XmNminX,

        [ToolkitOption("minY")]
        XmNminY,

        [ToolkitOption("minimizeButtons")]
        XmNminimizeButtons,

        [ToolkitOption("minimum")]
        XmNminimum,

        [ToolkitOption("minimumCellHeight")]
        XmNminimumCellHeight,

        [ToolkitOption("minimumCellWidth")]
        XmNminimumCellWidth,

        [ToolkitOption("minimumHorizontalCells")]
        XmNminimumHorizontalCells,

        [ToolkitOption("minimumValue")]
        XmNminimumValue,

        [ToolkitOption("minimumVerticalCells")]
        XmNminimumVerticalCells,

        [ToolkitOption("minorTabSpacing")]
        XmNminorTabSpacing,

        [ToolkitOption("mnemonic")]
        XmNmnemonic,

        [ToolkitOption("mnemonicCharSet")]
        XmNmnemonicCharSet,

        [ToolkitOption("modifyVerifyCallbackWcs")]
        XmNmodifyVerifyCallbackWcs,

        [ToolkitOption("monoSpaceString")]
        XmNmonoSpaceString,

        [ToolkitOption("motifVersion")]
        XmNmotifVersion,

        [ToolkitOption("moveOpaque")]
        XmNmoveOpaque,

        [ToolkitOption("multiClick")]
        XmNmultiClick,

        [ToolkitOption("mustMatch")]
        XmNmustMatch,

        [ToolkitOption("mwmDecorations")]
        XmNmwmDecorations,

        [ToolkitOption("mwmFunctions")]
        XmNmwmFunctions,

        [ToolkitOption("mwmInputMode")]
        XmNmwmInputMode,

        [ToolkitOption("mwmMenu")]
        XmNmwmMenu,

        [ToolkitOption("mwmMessages")]
        XmNmwmMessages,

        [ToolkitOption("name")]
        XmNname,

        [ToolkitOption("navigationType")]
        XmNnavigationType,

        [ToolkitOption("needsMotion")]
        XmNneedsMotion,

        [ToolkitOption("newVisualStyle")]
        XmNnewVisualStyle,

        [ToolkitOption("noCellError")]
        XmNnoCellError,

        [ToolkitOption("noComboShell")]
        XmNnoComboShell,

        [ToolkitOption("noEmptyCells")]
        XmNnoEmptyCells,

        [ToolkitOption("noGadgetSupport")]
        XmNnoGadgetSupport,

        [ToolkitOption("noMatchString")]
        XmNnoMatchString,

        [ToolkitOption("noResize")]
        XmNnoResize,

        [ToolkitOption("nodeCloseFolderPixmap")]
        XmNnodeCloseFolderPixmap,

        [ToolkitOption("nodeOpenFolderPixmap")]
        XmNnodeOpenFolderPixmap,

        [ToolkitOption("nodeParentIsSelf")]
        XmNnodeParentIsSelf,

        [ToolkitOption("nodeState")]
        XmNnodeState,

        [ToolkitOption("noneCursorForeground")]
        XmNnoneCursorForeground,

        [ToolkitOption("notebookChildType")]
        XmNnotebookChildType,

        [ToolkitOption("notify")]
        XmNnotify,

        [ToolkitOption("notifyProc")]
        XmNnotifyProc,

        [ToolkitOption("numChildren")]
        XmNnumChildren,

        [ToolkitOption("numColumns")]
        XmNnumColumns,

        [ToolkitOption("numDropRectangles")]
        XmNnumDropRectangles,

        [ToolkitOption("numDropTransfers")]
        XmNnumDropTransfers,

        [ToolkitOption("numExportTargets")]
        XmNnumExportTargets,

        [ToolkitOption("numImportTargets")]
        XmNnumImportTargets,

        [ToolkitOption("numRectangles")]
        XmNnumRectangles,

        [ToolkitOption("numRows")]
        XmNnumRows,

        [ToolkitOption("numStacks")]
        XmNnumStacks,

        [ToolkitOption("numValues")]
        XmNnumValues,

        [ToolkitOption("offsetModel")]
        XmNoffsetModel,

        [ToolkitOption("offsetX")]
        XmNoffsetX,

        [ToolkitOption("offsetY")]
        XmNoffsetY,

        [ToolkitOption("okLabelString")]
        XmNokLabelString,

        [ToolkitOption("openClosePadding")]
        XmNopenClosePadding,

        [ToolkitOption("openFolderPixmap")]
        XmNopenFolderPixmap,

        [ToolkitOption("operationCursorIcon")]
        XmNoperationCursorIcon,

        [ToolkitOption("optionLabel")]
        XmNoptionLabel,

        [ToolkitOption("optionMnemonic")]
        XmNoptionMnemonic,

        [ToolkitOption("optionString")]
        XmNoptionString,

        [ToolkitOption("orientation")]
        XmNorientation,

        [ToolkitOption("otherString")]
        XmNotherString,

        [ToolkitOption("outlineButtonPolicy")]
        XmNoutlineButtonPolicy,

        [ToolkitOption("outlineColumnWidth")]
        XmNoutlineColumnWidth,

        [ToolkitOption("outlineIndentation")]
        XmNoutlineIndentation,

        [ToolkitOption("outlineLineStyle")]
        XmNoutlineLineStyle,

        [ToolkitOption("outlineState")]
        XmNoutlineState,

        [ToolkitOption("outputCreate")]
        XmNoutputCreate,

        [ToolkitOption("overrideRedirect")]
        XmNoverrideRedirect,

        [ToolkitOption("ownerEvents")]
        XmNownerEvents,

        [ToolkitOption("packing")]
        XmNpacking,

        [ToolkitOption("pageIncrement")]
        XmNpageIncrement,

        [ToolkitOption("pageNumber")]
        XmNpageNumber,

        [ToolkitOption("paneMaximum")]
        XmNpaneMaximum,

        [ToolkitOption("paneMinimum")]
        XmNpaneMinimum,

        [ToolkitOption("parameter")]
        XmNparameter,

        [ToolkitOption("parentNode")]
        XmNparentNode,

        [ToolkitOption("pathMode")]
        XmNpathMode,

        [ToolkitOption("pattern")]
        XmNpattern,

        [ToolkitOption("patternType")]
        XmNpatternType,

        [ToolkitOption("pendingDelete")]
        XmNpendingDelete,

        [ToolkitOption("picture")]
        XmNpicture,

        [ToolkitOption("pixEditBadImageCreate")]
        XmNpixEditBadImageCreate,

        [ToolkitOption("pixmap")]
        XmNpixmap,

        [ToolkitOption("pixmapDepth")]
        XmNpixmapDepth,

        [ToolkitOption("pixmapHeight")]
        XmNpixmapHeight,

        [ToolkitOption("pixmapPlacement")]
        XmNpixmapPlacement,

        [ToolkitOption("pixmapTextPadding")]
        XmNpixmapTextPadding,

        [ToolkitOption("pixmapWidth")]
        XmNpixmapWidth,

        [ToolkitOption("popupCursor")]
        XmNpopupCursor,

        [ToolkitOption("popupEnabled")]
        XmNpopupEnabled,

        [ToolkitOption("popupOffset")]
        XmNpopupOffset,

        [ToolkitOption("popupShellWidget")]
        XmNpopupShellWidget,

        [ToolkitOption("position")]
        XmNposition,

        [ToolkitOption("positionIndex")]
        XmNpositionIndex,

        [ToolkitOption("positionMode")]
        XmNpositionMode,

        [ToolkitOption("positionType")]
        XmNpositionType,

        [ToolkitOption("postFromButton")]
        XmNpostFromButton,

        [ToolkitOption("postFromCount")]
        XmNpostFromCount,

        [ToolkitOption("postFromList")]
        XmNpostFromList,

        [ToolkitOption("preeditType")]
        XmNpreeditType,

        [ToolkitOption("preferredPaneSize")]
        XmNpreferredPaneSize,

        [ToolkitOption("primaryColorSetId")]
        XmNprimaryColorSetId,

        [ToolkitOption("primaryOwnership")]
        XmNprimaryOwnership,

        [ToolkitOption("printOrientation")]
        XmNprintOrientation,

        [ToolkitOption("printOrientations")]
        XmNprintOrientations,

        [ToolkitOption("printResolution")]
        XmNprintResolution,

        [ToolkitOption("printResolutions")]
        XmNprintResolutions,

        [ToolkitOption("processingDirection")]
        XmNprocessingDirection,

        [ToolkitOption("promptString")]
        XmNpromptString,

        [ToolkitOption("propSpaceString")]
        XmNpropSpaceString,

        [ToolkitOption("pushButtonEnabled")]
        XmNpushButtonEnabled,

        [ToolkitOption("qualifySearchDataProc")]
        XmNqualifySearchDataProc,

        [ToolkitOption("radioAlwaysOne")]
        XmNradioAlwaysOne,

        [ToolkitOption("radioBehavior")]
        XmNradioBehavior,

        [ToolkitOption("recomputeSize")]
        XmNrecomputeSize,

        [ToolkitOption("rectangles")]
        XmNrectangles,

        [ToolkitOption("redSliderLabel")]
        XmNredSliderLabel,

        [ToolkitOption("refigureMode")]
        XmNrefigureMode,

        [ToolkitOption("renderTable")]
        XmNrenderTable,

        [ToolkitOption("renditionBackground")]
        XmNrenditionBackground,

        [ToolkitOption("renditionForeground")]
        XmNrenditionForeground,

        [ToolkitOption("repeatDelay")]
        XmNrepeatDelay,

        [ToolkitOption("resizable")]
        XmNresizable,

        [ToolkitOption("resize")]
        XmNresize,

        [ToolkitOption("resizeHeight")]
        XmNresizeHeight,

        [ToolkitOption("resizePolicy")]
        XmNresizePolicy,

        [ToolkitOption("resizeToPreferred")]
        XmNresizeToPreferred,

        [ToolkitOption("resizeWidth")]
        XmNresizeWidth,

        [ToolkitOption("reverseVideo")]
        XmNreverseVideo,

        [ToolkitOption("rgbFile")]
        XmNrgbFile,

        [ToolkitOption("rightAttachment")]
        XmNrightAttachment,

        [ToolkitOption("rightOffset")]
        XmNrightOffset,

        [ToolkitOption("rightPosition")]
        XmNrightPosition,

        [ToolkitOption("rightWidget")]
        XmNrightWidget,

        [ToolkitOption("rowColumnType")]
        XmNrowColumnType,

        [ToolkitOption("rows")]
        XmNrows,

        [ToolkitOption("rubberPositioning")]
        XmNrubberPositioning,

        [ToolkitOption("sameAsImageOrPix")]
        XmNsameAsImageOrPix,

        [ToolkitOption("sampleText")]
        XmNsampleText,

        [ToolkitOption("sashHeight")]
        XmNsashHeight,

        [ToolkitOption("sashIndent")]
        XmNsashIndent,

        [ToolkitOption("sashShadowThickness")]
        XmNsashShadowThickness,

        [ToolkitOption("sashTranslations")]
        XmNsashTranslations,

        [ToolkitOption("sashWidth")]
        XmNsashWidth,

        [ToolkitOption("saveUnder")]
        XmNsaveUnder,

        [ToolkitOption("scaleHeight")]
        XmNscaleHeight,

        [ToolkitOption("scaleMultiple")]
        XmNscaleMultiple,

        [ToolkitOption("scaleWidth")]
        XmNscaleWidth,

        [ToolkitOption("scalingString")]
        XmNscalingString,

        [ToolkitOption("screen")]
        XmNscreen,

        [ToolkitOption("scrollBarDisplayPolicy")]
        XmNscrollBarDisplayPolicy,

        [ToolkitOption("scrollBarPlacement")]
        XmNscrollBarPlacement,

        [ToolkitOption("scrollDCursor")]
        XmNscrollDCursor,

        [ToolkitOption("scrollHCursor")]
        XmNscrollHCursor,

        [ToolkitOption("scrollHorizontal")]
        XmNscrollHorizontal,

        [ToolkitOption("scrollLCursor")]
        XmNscrollLCursor,

        [ToolkitOption("scrollLeftSide")]
        XmNscrollLeftSide,

        [ToolkitOption("scrollProc")]
        XmNscrollProc,

        [ToolkitOption("scrollRCursor")]
        XmNscrollRCursor,

        [ToolkitOption("scrollTopSide")]
        XmNscrollTopSide,

        [ToolkitOption("scrollUCursor")]
        XmNscrollUCursor,

        [ToolkitOption("scrollVCursor")]
        XmNscrollVCursor,

        [ToolkitOption("scrollVertical")]
        XmNscrollVertical,

        [ToolkitOption("scrolledWindowChildType")]
        XmNscrolledWindowChildType,

        [ToolkitOption("scrolledWindowMarginHeight")]
        XmNscrolledWindowMarginHeight,

        [ToolkitOption("scrolledWindowMarginWidth")]
        XmNscrolledWindowMarginWidth,

        [ToolkitOption("scrollingPolicy")]
        XmNscrollingPolicy,

        [ToolkitOption("secondaryColorSetId")]
        XmNsecondaryColorSetId,

        [ToolkitOption("selectColor")]
        XmNselectColor,

        [ToolkitOption("selectInsensitivePixmap")]
        XmNselectInsensitivePixmap,

        [ToolkitOption("selectPixmap")]
        XmNselectPixmap,

        [ToolkitOption("selectThreshold")]
        XmNselectThreshold,

        [ToolkitOption("selectedColumn")]
        XmNselectedColumn,

        [ToolkitOption("selectedIndex")]
        XmNselectedIndex,

        [ToolkitOption("selectedItem")]
        XmNselectedItem,

        [ToolkitOption("selectedItemCount")]
        XmNselectedItemCount,

        [ToolkitOption("selectedItems")]
        XmNselectedItems,

        [ToolkitOption("selectedObjectCount")]
        XmNselectedObjectCount,

        [ToolkitOption("selectedObjects")]
        XmNselectedObjects,

        [ToolkitOption("selectedPosition")]
        XmNselectedPosition,

        [ToolkitOption("selectedPositionCount")]
        XmNselectedPositionCount,

        [ToolkitOption("selectedPositions")]
        XmNselectedPositions,

        [ToolkitOption("selection")]
        XmNselection,

        [ToolkitOption("selectionArray")]
        XmNselectionArray,

        [ToolkitOption("selectionArrayCount")]
        XmNselectionArrayCount,

        [ToolkitOption("selectionLabelString")]
        XmNselectionLabelString,

        [ToolkitOption("selectionMode")]
        XmNselectionMode,

        [ToolkitOption("selectionPolicy")]
        XmNselectionPolicy,

        [ToolkitOption("selectionTechnique")]
        XmNselectionTechnique,

        [ToolkitOption("selfOrOutsideOfApplicationDrop")]
        XmNselfOrOutsideOfApplicationDrop,

        [ToolkitOption("sensitive")]
        XmNsensitive,

        [ToolkitOption("separatorOn")]
        XmNseparatorOn,

        [ToolkitOption("separatorType")]
        XmNseparatorType,

        [ToolkitOption("set")]
        XmNset,

        [ToolkitOption("shadow")]
        XmNshadow,

        [ToolkitOption("shadowThickness")]
        XmNshadowThickness,

        [ToolkitOption("shadowType")]
        XmNshadowType,

        [ToolkitOption("shellUnitType")]
        XmNshellUnitType,

        [ToolkitOption("showArrows")]
        XmNshowArrows,

        [ToolkitOption("showAsDefault")]
        XmNshowAsDefault,

        [ToolkitOption("showEntryLabel")]
        XmNshowEntryLabel,

        [ToolkitOption("showFind")]
        XmNshowFind,

        [ToolkitOption("showFontName")]
        XmNshowFontName,

        [ToolkitOption("showLabel")]
        XmNshowLabel,

        [ToolkitOption("showNameString")]
        XmNshowNameString,

        [ToolkitOption("showSash")]
        XmNshowSash,

        [ToolkitOption("showSeparator")]
        XmNshowSeparator,

        [ToolkitOption("showValue")]
        XmNshowValue,

        [ToolkitOption("shown")]
        XmNshown,

        [ToolkitOption("sizePolicy")]
        XmNsizePolicy,

        [ToolkitOption("sizeString")]
        XmNsizeString,

        [ToolkitOption("skipAdjust")]
        XmNskipAdjust,

        [ToolkitOption("sliderMark")]
        XmNsliderMark,

        [ToolkitOption("sliderSize")]
        XmNsliderSize,

        [ToolkitOption("sliderTogLabel")]
        XmNsliderTogLabel,

        [ToolkitOption("sliderVisual")]
        XmNsliderVisual,

        [ToolkitOption("slidingMode")]
        XmNslidingMode,

        [ToolkitOption("smallCellHeight")]
        XmNsmallCellHeight,

        [ToolkitOption("smallCellWidth")]
        XmNsmallCellWidth,

        [ToolkitOption("smallIcon")]
        XmNsmallIcon,

        [ToolkitOption("smallIconMask")]
        XmNsmallIconMask,

        [ToolkitOption("smallIconPixmap")]
        XmNsmallIconPixmap,

        [ToolkitOption("smallIconX")]
        XmNsmallIconX,

        [ToolkitOption("smallIconY")]
        XmNsmallIconY,

        [ToolkitOption("snapBackMultiple")]
        XmNsnapBackMultiple,

        [ToolkitOption("sortFunctions")]
        XmNsortFunctions,

        [ToolkitOption("source")]
        XmNsource,

        [ToolkitOption("sourceCursorIcon")]
        XmNsourceCursorIcon,

        [ToolkitOption("sourceIsExternal")]
        XmNsourceIsExternal,

        [ToolkitOption("sourcePixmapIcon")]
        XmNsourcePixmapIcon,

        [ToolkitOption("sourceWidget")]
        XmNsourceWidget,

        [ToolkitOption("sourceWindow")]
        XmNsourceWindow,

        [ToolkitOption("space")]
        XmNspace,

        [ToolkitOption("spacing")]
        XmNspacing,

        [ToolkitOption("spatialIncludeModel")]
        XmNspatialIncludeModel,

        [ToolkitOption("spatialResizeModel")]
        XmNspatialResizeModel,

        [ToolkitOption("spatialSnapModel")]
        XmNspatialSnapModel,

        [ToolkitOption("spatialStyle")]
        XmNspatialStyle,

        [ToolkitOption("spinBoxChildType")]
        XmNspinBoxChildType,

        [ToolkitOption("spotLocation")]
        XmNspotLocation,

        [ToolkitOption("stackedEffect")]
        XmNstackedEffect,

        [ToolkitOption("startTime")]
        XmNstartTime,

        [ToolkitOption("stateCursorIcon")]
        XmNstateCursorIcon,

        [ToolkitOption("stretchable")]
        XmNstretchable,

        [ToolkitOption("strikethruType")]
        XmNstrikethruType,

        [ToolkitOption("string")]
        XmNstring,

        [ToolkitOption("stringDirection")]
        XmNstringDirection,

        [ToolkitOption("stringGetFailed")]
        XmNstringGetFailed,

        [ToolkitOption("subMenuId")]
        XmNsubMenuId,

        [ToolkitOption("substitute")]
        XmNsubstitute,

        [ToolkitOption("symbolPixmap")]
        XmNsymbolPixmap,

        [ToolkitOption("tabAlignment")]
        XmNtabAlignment,

        [ToolkitOption("tabArrowPlacement")]
        XmNtabArrowPlacement,

        [ToolkitOption("tabAutoSelect")]
        XmNtabAutoSelect,

        [ToolkitOption("tabBackground")]
        XmNtabBackground,

        [ToolkitOption("tabBackgroundPixmap")]
        XmNtabBackgroundPixmap,

        [ToolkitOption("tabBoxWidget")]
        XmNtabBoxWidget,

        [ToolkitOption("tabCornerPercent")]
        XmNtabCornerPercent,

        [ToolkitOption("tabEdge")]
        XmNtabEdge,

        [ToolkitOption("tabForeground")]
        XmNtabForeground,

        [ToolkitOption("tabLabelPixmap")]
        XmNtabLabelPixmap,

        [ToolkitOption("tabLabelSpacing")]
        XmNtabLabelSpacing,

        [ToolkitOption("tabLabelString")]
        XmNtabLabelString,

        [ToolkitOption("tabList")]
        XmNtabList,

        [ToolkitOption("tabMarginHeight")]
        XmNtabMarginHeight,

        [ToolkitOption("tabMarginWidth")]
        XmNtabMarginWidth,

        [ToolkitOption("tabMode")]
        XmNtabMode,

        [ToolkitOption("tabOffset")]
        XmNtabOffset,

        [ToolkitOption("tabOrientation")]
        XmNtabOrientation,

        [ToolkitOption("tabPixmapPlacement")]
        XmNtabPixmapPlacement,

        [ToolkitOption("tabSelectColor")]
        XmNtabSelectColor,

        [ToolkitOption("tabSelectPixmap")]
        XmNtabSelectPixmap,

        [ToolkitOption("tabSide")]
        XmNtabSide,

        [ToolkitOption("tabStringDirection")]
        XmNtabStringDirection,

        [ToolkitOption("tabStyle")]
        XmNtabStyle,

        [ToolkitOption("tabTearOffEnabled")]
        XmNtabTearOffEnabled,

        [ToolkitOption("tabValue")]
        XmNtabValue,

        [ToolkitOption("tag")]
        XmNtag,

        [ToolkitOption("tearOffLabelString")]
        XmNtearOffLabelString,

        [ToolkitOption("tearOffModel")]
        XmNtearOffModel,

        [ToolkitOption("tearOffTitle")]
        XmNtearOffTitle,

        [ToolkitOption("textAccelerators")]
        XmNtextAccelerators,

        [ToolkitOption("textColorSetId")]
        XmNtextColorSetId,

        [ToolkitOption("textColumns")]
        XmNtextColumns,

        [ToolkitOption("textField")]
        XmNtextField,

        [ToolkitOption("textFontList")]
        XmNtextFontList,

        [ToolkitOption("textOptions")]
        XmNtextOptions,

        [ToolkitOption("textPath")]
        XmNtextPath,

        [ToolkitOption("textRenderTable")]
        XmNtextRenderTable,

        [ToolkitOption("textRows")]
        XmNtextRows,

        [ToolkitOption("textSink")]
        XmNtextSink,

        [ToolkitOption("textSource")]
        XmNtextSource,

        [ToolkitOption("textString")]
        XmNtextString,

        [ToolkitOption("textTranslations")]
        XmNtextTranslations,

        [ToolkitOption("textValue")]
        XmNtextValue,

        [ToolkitOption("textVerifyFailed")]
        XmNtextVerifyFailed,

        [ToolkitOption("thickness")]
        XmNthickness,

        [ToolkitOption("thumb")]
        XmNthumb,

        [ToolkitOption("thumbProc")]
        XmNthumbProc,

        [ToolkitOption("title")]
        XmNtitle,

        [ToolkitOption("titleEncoding")]
        XmNtitleEncoding,

        [ToolkitOption("titleString")]
        XmNtitleString,

        [ToolkitOption("toggleMode")]
        XmNtoggleMode,

        [ToolkitOption("toolTipEnable")]
        XmNtoolTipEnable,

        [ToolkitOption("toolTipPostDelay")]
        XmNtoolTipPostDelay,

        [ToolkitOption("toolTipPostDuration")]
        XmNtoolTipPostDuration,

        [ToolkitOption("toolTipString")]
        XmNtoolTipString,

        [ToolkitOption("top")]
        XmNtop,

        [ToolkitOption("topAttachment")]
        XmNtopAttachment,

        [ToolkitOption("topCharacter")]
        XmNtopCharacter,

        [ToolkitOption("topItemPosition")]
        XmNtopItemPosition,

        [ToolkitOption("topOffset")]
        XmNtopOffset,

        [ToolkitOption("topPosition")]
        XmNtopPosition,

        [ToolkitOption("topShadowColor")]
        XmNtopShadowColor,

        [ToolkitOption("topShadowPixmap")]
        XmNtopShadowPixmap,

        [ToolkitOption("topWidget")]
        XmNtopWidget,

        [ToolkitOption("totalLines")]
        XmNtotalLines,

        [ToolkitOption("transferProc")]
        XmNtransferProc,

        [ToolkitOption("transferStatus")]
        XmNtransferStatus,

        [ToolkitOption("transient")]
        XmNtransient,

        [ToolkitOption("transientFor")]
        XmNtransientFor,

        [ToolkitOption("translations")]
        XmNtranslations,

        [ToolkitOption("traversalIndex")]
        XmNtraversalIndex,

        [ToolkitOption("traversalOn")]
        XmNtraversalOn,

        [ToolkitOption("traversalType")]
        XmNtraversalType,

        [ToolkitOption("treeUpdateProc")]
        XmNtreeUpdateProc,

        [ToolkitOption("troughColor")]
        XmNtroughColor,

        [ToolkitOption("underlineType")]
        XmNunderlineType,

        [ToolkitOption("unexpectedEvent")]
        XmNunexpectedEvent,

        [ToolkitOption("uniformTabSize")]
        XmNuniformTabSize,

        [ToolkitOption("unitType")]
        XmNunitType,

        [ToolkitOption("unparsableColor")]
        XmNunparsableColor,

        [ToolkitOption("unpostBehavior")]
        XmNunpostBehavior,

        [ToolkitOption("unselectColor")]
        XmNunselectColor,

        [ToolkitOption("unselectPixmap")]
        XmNunselectPixmap,

        [ToolkitOption("update")]
        XmNupdate,

        [ToolkitOption("updateSliderSize")]
        XmNupdateSliderSize,

        [ToolkitOption("useAsyncGeometry")]
        XmNuseAsyncGeometry,

        [ToolkitOption("useBottom")]
        XmNuseBottom,

        [ToolkitOption("useColorObj")]
        XmNuseColorObj,

        [ToolkitOption("useIconFileCache")]
        XmNuseIconFileCache,

        [ToolkitOption("useImageCache")]
        XmNuseImageCache,

        [ToolkitOption("useMask")]
        XmNuseMask,

        [ToolkitOption("useMultiColorIcons")]
        XmNuseMultiColorIcons,

        [ToolkitOption("useRight")]
        XmNuseRight,

        [ToolkitOption("useScaling")]
        XmNuseScaling,

        [ToolkitOption("useTextColor")]
        XmNuseTextColor,

        [ToolkitOption("useTextColorForList")]
        XmNuseTextColorForList,

        [ToolkitOption("useTextField")]
        XmNuseTextField,

        [ToolkitOption("userData")]
        XmNuserData,

        [ToolkitOption("validCursorForeground")]
        XmNvalidCursorForeground,

        [ToolkitOption("value")]
        XmNvalue,

        [ToolkitOption("valueWcs")]
        XmNvalueWcs,

        [ToolkitOption("values")]
        XmNvalues,

        [ToolkitOption("verify")]
        XmNverify,

        [ToolkitOption("verifyBell")]
        XmNverifyBell,

        [ToolkitOption("verifyPreedit")]
        XmNverifyPreedit,

        [ToolkitOption("verticalDelta")]
        XmNverticalDelta,

        [ToolkitOption("verticalFontUnit")]
        XmNverticalFontUnit,

        [ToolkitOption("verticalMargin")]
        XmNverticalMargin,

        [ToolkitOption("verticalNodeSpace")]
        XmNverticalNodeSpace,

        [ToolkitOption("verticalScrollBar")]
        XmNverticalScrollBar,

        [ToolkitOption("verticalSpacing")]
        XmNverticalSpacing,

        [ToolkitOption("viewType")]
        XmNviewType,

        [ToolkitOption("visibleItemCount")]
        XmNvisibleItemCount,

        [ToolkitOption("visibleWhenOff")]
        XmNvisibleWhenOff,

        [ToolkitOption("visual")]
        XmNvisual,

        [ToolkitOption("visualEmphasis")]
        XmNvisualEmphasis,

        [ToolkitOption("visualPolicy")]
        XmNvisualPolicy,

        [ToolkitOption("waitforwm")]
        XmNwaitForWm,

        [ToolkitOption("whichButton")]
        XmNwhichButton,

        [ToolkitOption("width")]
        XmNwidth,

        [ToolkitOption("widthInc")]
        XmNwidthInc,

        [ToolkitOption("winGravity")]
        XmNwinGravity,

        [ToolkitOption("window")]
        XmNwindow,

        [ToolkitOption("windowGroup")]
        XmNwindowGroup,

        [ToolkitOption("wmTimeout")]
        XmNwmTimeout,

        [ToolkitOption("wordWrap")]
        XmNwordWrap,

        [ToolkitOption("workWindow")]
        XmNworkWindow,

        [ToolkitOption("wrap")]
        XmNwrap,

        [ToolkitOption("x")]
        XmNx,

        [ToolkitOption("xftFont")]
        XmNxftFont,

        [ToolkitOption("xlfdString")]
        XmNxlfdString,

        [ToolkitOption("y")]
        XmNy,

    }
}
