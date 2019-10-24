using System;
using TonNurako.Native;

namespace TonNurako.Xt {
    public enum ResourceId {
        [ToolkitOption("Accelerators")]
        XtCAccelerators,

        [ToolkitOption("Background")]
        XtCBackground,

        [ToolkitOption("Bitmap")]
        XtCBitmap,

        [ToolkitOption("Boolean")]
        XtCBoolean,

        [ToolkitOption("BorderColor")]
        XtCBorderColor,

        [ToolkitOption("BorderWidth")]
        XtCBorderWidth,

        [ToolkitOption("Callback")]
        XtCCallback,

        [ToolkitOption("Color")]
        XtCColor,

        [ToolkitOption("Colormap")]
        XtCColormap,

        [ToolkitOption("Cursor")]
        XtCCursor,

        [ToolkitOption("Depth")]
        XtCDepth,

        [ToolkitOption("EditType")]
        XtCEditType,

        [ToolkitOption("EventBindings")]
        XtCEventBindings,

        [ToolkitOption("File")]
        XtCFile,

        [ToolkitOption("Font")]
        XtCFont,

        [ToolkitOption("FontSet")]
        XtCFontSet,

        [ToolkitOption("Foreground")]
        XtCForeground,

        [ToolkitOption("Fraction")]
        XtCFraction,

        [ToolkitOption("Function")]
        XtCFunction,

        [ToolkitOption("HSpace")]
        XtCHSpace,

        [ToolkitOption("Height")]
        XtCHeight,

        [ToolkitOption("Index")]
        XtCIndex,

        [ToolkitOption("InitialResourcesPersistent")]
        XtCInitialResourcesPersistent,

        [ToolkitOption("InsertPosition")]
        XtCInsertPosition,

        [ToolkitOption("Interval")]
        XtCInterval,

        [ToolkitOption("Justify")]
        XtCJustify,

        [ToolkitOption("KnobIndent")]
        XtCKnobIndent,

        [ToolkitOption("KnobPixel")]
        XtCKnobPixel,

        [ToolkitOption("Label")]
        XtCLabel,

        [ToolkitOption("Length")]
        XtCLength,

        [ToolkitOption("MappedWhenManaged")]
        XtCMappedWhenManaged,

        [ToolkitOption("Margin")]
        XtCMargin,

        [ToolkitOption("MenuEntry")]
        XtCMenuEntry,

        [ToolkitOption("Notify")]
        XtCNotify,

        [ToolkitOption("Orientation")]
        XtCOrientation,

        [ToolkitOption("Parameter")]
        XtCParameter,

        [ToolkitOption("Pixmap")]
        XtCPixmap,

        [ToolkitOption("Position")]
        XtCPosition,

        [ToolkitOption("ReadOnly")]
        XtCReadOnly,

        [ToolkitOption("Resize")]
        XtCResize,

        [ToolkitOption("ReverseVideo")]
        XtCReverseVideo,

        [ToolkitOption("Screen")]
        XtCScreen,

        [ToolkitOption("ScrollDCursor")]
        XtCScrollDCursor,

        [ToolkitOption("ScrollHCursor")]
        XtCScrollHCursor,

        [ToolkitOption("ScrollLCursor")]
        XtCScrollLCursor,

        [ToolkitOption("ScrollProc")]
        XtCScrollProc,

        [ToolkitOption("ScrollRCursor")]
        XtCScrollRCursor,

        [ToolkitOption("ScrollUCursor")]
        XtCScrollUCursor,

        [ToolkitOption("ScrollVCursor")]
        XtCScrollVCursor,

        [ToolkitOption("Selection")]
        XtCSelection,

        [ToolkitOption("SelectionArray")]
        XtCSelectionArray,

        [ToolkitOption("Sensitive")]
        XtCSensitive,

        [ToolkitOption("Space")]
        XtCSpace,

        [ToolkitOption("String")]
        XtCString,

        [ToolkitOption("TextOptions")]
        XtCTextOptions,

        [ToolkitOption("TextPosition")]
        XtCTextPosition,

        [ToolkitOption("TextSink")]
        XtCTextSink,

        [ToolkitOption("TextSource")]
        XtCTextSource,

        [ToolkitOption("Thickness")]
        XtCThickness,

        [ToolkitOption("Thumb")]
        XtCThumb,

        [ToolkitOption("Translations")]
        XtCTranslations,

        [ToolkitOption("VSpace")]
        XtCVSpace,

        [ToolkitOption("Value")]
        XtCValue,

        [ToolkitOption("Width")]
        XtCWidth,

        [ToolkitOption("Window")]
        XtCWindow,

        [ToolkitOption("X")]
        XtCX,

        [ToolkitOption("Y")]
        XtCY,

        [ToolkitOption("false")]
        XtEfalse,

        [ToolkitOption("horizontal")]
        XtEhorizontal,

        [ToolkitOption("no")]
        XtEno,

        [ToolkitOption("off")]
        XtEoff,

        [ToolkitOption("on")]
        XtEon,

        [ToolkitOption("append")]
        XtEtextAppend,

        [ToolkitOption("edit")]
        XtEtextEdit,

        [ToolkitOption("read")]
        XtEtextRead,

        [ToolkitOption("true")]
        XtEtrue,

        [ToolkitOption("vertical")]
        XtEvertical,

        [ToolkitOption("xtdefaultbackground")]
        XtExtdefaultbackground,

        [ToolkitOption("xtdefaultfont")]
        XtExtdefaultfont,

        [ToolkitOption("xtdefaultforeground")]
        XtExtdefaultforeground,

        [ToolkitOption("yes")]
        XtEyes,

        [ToolkitOption("XtaddCallback")]
        XtHaddCallback,

        [ToolkitOption("XtaddCallbacks")]
        XtHaddCallbacks,

        [ToolkitOption("XtaugmentTranslations")]
        XtHaugmentTranslations,

        [ToolkitOption("Xtconfigure")]
        XtHconfigure,

        [ToolkitOption("Xtcreate")]
        XtHcreate,

        [ToolkitOption("Xtdestroy")]
        XtHdestroy,

        [ToolkitOption("XtmanageChildren")]
        XtHmanageChildren,

        [ToolkitOption("XtmanageSet")]
        XtHmanageSet,

        [ToolkitOption("XtmapWidget")]
        XtHmapWidget,

        [ToolkitOption("XtoverrideTranslations")]
        XtHoverrideTranslations,

        [ToolkitOption("Xtpopdown")]
        XtHpopdown,

        [ToolkitOption("Xtpopup")]
        XtHpopup,

        [ToolkitOption("XtpopupSpringLoaded")]
        XtHpopupSpringLoaded,

        [ToolkitOption("XtpostGeometry")]
        XtHpostGeometry,

        [ToolkitOption("XtpreGeometry")]
        XtHpreGeometry,

        [ToolkitOption("XtrealizeWidget")]
        XtHrealizeWidget,

        [ToolkitOption("XtremoveAllCallbacks")]
        XtHremoveAllCallbacks,

        [ToolkitOption("XtremoveCallback")]
        XtHremoveCallback,

        [ToolkitOption("XtremoveCallbacks")]
        XtHremoveCallbacks,

        [ToolkitOption("XtsetKeyboardFocus")]
        XtHsetKeyboardFocus,

        [ToolkitOption("XtsetMappedWhenManaged")]
        XtHsetMappedWhenManaged,

        [ToolkitOption("XtsetValues")]
        XtHsetValues,

        [ToolkitOption("XtsetWMColormapWindows")]
        XtHsetWMColormapWindows,

        [ToolkitOption("XtuninstallTranslations")]
        XtHuninstallTranslations,

        [ToolkitOption("XtunmanageChildren")]
        XtHunmanageChildren,

        [ToolkitOption("XtunmanageSet")]
        XtHunmanageSet,

        [ToolkitOption("XtunmapWidget")]
        XtHunmapWidget,

        [ToolkitOption("XtunrealizeWidget")]
        XtHunrealizeWidget,

        [ToolkitOption("accelerators")]
        XtNaccelerators,

        [ToolkitOption("allowHoriz")]
        XtNallowHoriz,

        [ToolkitOption("allowVert")]
        XtNallowVert,

        [ToolkitOption("ancestorSensitive")]
        XtNancestorSensitive,

        [ToolkitOption("background")]
        XtNbackground,

        [ToolkitOption("backgroundPixmap")]
        XtNbackgroundPixmap,

        [ToolkitOption("bitmap")]
        XtNbitmap,

        [ToolkitOption("borderColor")]
        XtNborder,

        [ToolkitOption("borderColor")]
        XtNborderColor,

        [ToolkitOption("borderPixmap")]
        XtNborderPixmap,

        [ToolkitOption("borderWidth")]
        XtNborderWidth,

        [ToolkitOption("callback")]
        XtNcallback,

        [ToolkitOption("changeHook")]
        XtNchangeHook,

        [ToolkitOption("children")]
        XtNchildren,

        [ToolkitOption("colormap")]
        XtNcolormap,

        [ToolkitOption("configureHook")]
        XtNconfigureHook,

        [ToolkitOption("createHook")]
        XtNcreateHook,

        [ToolkitOption("depth")]
        XtNdepth,

        [ToolkitOption("destroyCallback")]
        XtNdestroyCallback,

        [ToolkitOption("destroyHook")]
        XtNdestroyHook,

        [ToolkitOption("editType")]
        XtNeditType,

        [ToolkitOption("file")]
        XtNfile,

        [ToolkitOption("font")]
        XtNfont,

        [ToolkitOption("fontSet")]
        XtNfontSet,

        [ToolkitOption("forceBars")]
        XtNforceBars,

        [ToolkitOption("foreground")]
        XtNforeground,

        [ToolkitOption("function")]
        XtNfunction,

        [ToolkitOption("geometryHook")]
        XtNgeometryHook,

        [ToolkitOption("hSpace")]
        XtNhSpace,

        [ToolkitOption("height")]
        XtNheight,

        [ToolkitOption("highlight")]
        XtNhighlight,

        [ToolkitOption("index")]
        XtNindex,

        [ToolkitOption("initialResourcesPersistent")]
        XtNinitialResourcesPersistent,

        [ToolkitOption("innerHeight")]
        XtNinnerHeight,

        [ToolkitOption("innerWidth")]
        XtNinnerWidth,

        [ToolkitOption("innerWindow")]
        XtNinnerWindow,

        [ToolkitOption("insertPosition")]
        XtNinsertPosition,

        [ToolkitOption("internalHeight")]
        XtNinternalHeight,

        [ToolkitOption("internalWidth")]
        XtNinternalWidth,

        [ToolkitOption("jumpProc")]
        XtNjumpProc,

        [ToolkitOption("justify")]
        XtNjustify,

        [ToolkitOption("knobHeight")]
        XtNknobHeight,

        [ToolkitOption("knobIndent")]
        XtNknobIndent,

        [ToolkitOption("knobPixel")]
        XtNknobPixel,

        [ToolkitOption("knobWidth")]
        XtNknobWidth,

        [ToolkitOption("label")]
        XtNlabel,

        [ToolkitOption("length")]
        XtNlength,

        [ToolkitOption("lowerRight")]
        XtNlowerRight,

        [ToolkitOption("mappedWhenManaged")]
        XtNmappedWhenManaged,

        [ToolkitOption("menuEntry")]
        XtNmenuEntry,

        [ToolkitOption("name")]
        XtNname,

        [ToolkitOption("notify")]
        XtNnotify,

        [ToolkitOption("numChildren")]
        XtNnumChildren,

        [ToolkitOption("numShells")]
        XtNnumShells,

        [ToolkitOption("orientation")]
        XtNorientation,

        [ToolkitOption("parameter")]
        XtNparameter,

        [ToolkitOption("pixmap")]
        XtNpixmap,

        [ToolkitOption("popdownCallback")]
        XtNpopdownCallback,

        [ToolkitOption("popupCallback")]
        XtNpopupCallback,

        [ToolkitOption("resize")]
        XtNresize,

        [ToolkitOption("reverseVideo")]
        XtNreverseVideo,

        [ToolkitOption("screen")]
        XtNscreen,

        [ToolkitOption("scrollDCursor")]
        XtNscrollDCursor,

        [ToolkitOption("scrollHCursor")]
        XtNscrollHCursor,

        [ToolkitOption("scrollLCursor")]
        XtNscrollLCursor,

        [ToolkitOption("scrollProc")]
        XtNscrollProc,

        [ToolkitOption("scrollRCursor")]
        XtNscrollRCursor,

        [ToolkitOption("scrollUCursor")]
        XtNscrollUCursor,

        [ToolkitOption("scrollVCursor")]
        XtNscrollVCursor,

        [ToolkitOption("selection")]
        XtNselection,

        [ToolkitOption("selectionArray")]
        XtNselectionArray,

        [ToolkitOption("sensitive")]
        XtNsensitive,

        [ToolkitOption("shells")]
        XtNshells,

        [ToolkitOption("shown")]
        XtNshown,

        [ToolkitOption("space")]
        XtNspace,

        [ToolkitOption("string")]
        XtNstring,

        [ToolkitOption("textOptions")]
        XtNtextOptions,

        [ToolkitOption("textSink")]
        XtNtextSink,

        [ToolkitOption("textSource")]
        XtNtextSource,

        [ToolkitOption("thickness")]
        XtNthickness,

        [ToolkitOption("thumb")]
        XtNthumb,

        [ToolkitOption("thumbProc")]
        XtNthumbProc,

        [ToolkitOption("top")]
        XtNtop,

        [ToolkitOption("translations")]
        XtNtranslations,

        [ToolkitOption("unrealizeCallback")]
        XtNunrealizeCallback,

        [ToolkitOption("update")]
        XtNupdate,

        [ToolkitOption("useBottom")]
        XtNuseBottom,

        [ToolkitOption("useRight")]
        XtNuseRight,

        [ToolkitOption("vSpace")]
        XtNvSpace,

        [ToolkitOption("value")]
        XtNvalue,

        [ToolkitOption("width")]
        XtNwidth,

        [ToolkitOption("window")]
        XtNwindow,

        [ToolkitOption("x")]
        XtNx,

        [ToolkitOption("y")]
        XtNy,

        [ToolkitOption("AcceleratorTable")]
        XtRAcceleratorTable,

        [ToolkitOption("Atom")]
        XtRAtom,

        [ToolkitOption("Bitmap")]
        XtRBitmap,

        [ToolkitOption("Bool")]
        XtRBool,

        [ToolkitOption("Boolean")]
        XtRBoolean,

        [ToolkitOption("CallProc")]
        XtRCallProc,

        [ToolkitOption("Callback")]
        XtRCallback,

        [ToolkitOption("Cardinal")]
        XtRCardinal,

        [ToolkitOption("Color")]
        XtRColor,

        [ToolkitOption("Colormap")]
        XtRColormap,

        [ToolkitOption("CommandArgArray")]
        XtRCommandArgArray,

        [ToolkitOption("Cursor")]
        XtRCursor,

        [ToolkitOption("Dimension")]
        XtRDimension,

        [ToolkitOption("DirectoryString")]
        XtRDirectoryString,

        [ToolkitOption("Display")]
        XtRDisplay,

        [ToolkitOption("EditMode")]
        XtREditMode,

        [ToolkitOption("Enum")]
        XtREnum,

        [ToolkitOption("EnvironmentArray")]
        XtREnvironmentArray,

        [ToolkitOption("File")]
        XtRFile,

        [ToolkitOption("Float")]
        XtRFloat,

        [ToolkitOption("Font")]
        XtRFont,

        [ToolkitOption("FontSet")]
        XtRFontSet,

        [ToolkitOption("FontStruct")]
        XtRFontStruct,

        [ToolkitOption("Function")]
        XtRFunction,

        [ToolkitOption("Geometry")]
        XtRGeometry,

        [ToolkitOption("Gravity")]
        XtRGravity,

        [ToolkitOption("Immediate")]
        XtRImmediate,

        [ToolkitOption("InitialState")]
        XtRInitialState,

        [ToolkitOption("Int")]
        XtRInt,

        [ToolkitOption("Justify")]
        XtRJustify,

        [ToolkitOption("Bool")]
        XtRLongBoolean,

        [ToolkitOption("Object")]
        XtRObject,

        [ToolkitOption("Orientation")]
        XtROrientation,

        [ToolkitOption("Pixel")]
        XtRPixel,

        [ToolkitOption("Pixmap")]
        XtRPixmap,

        [ToolkitOption("Pointer")]
        XtRPointer,

        [ToolkitOption("Position")]
        XtRPosition,

        [ToolkitOption("RestartStyle")]
        XtRRestartStyle,

        [ToolkitOption("Screen")]
        XtRScreen,

        [ToolkitOption("Short")]
        XtRShort,

        [ToolkitOption("SmcConn")]
        XtRSmcConn,

        [ToolkitOption("String")]
        XtRString,

        [ToolkitOption("StringArray")]
        XtRStringArray,

        [ToolkitOption("StringTable")]
        XtRStringTable,

        [ToolkitOption("TranslationTable")]
        XtRTranslationTable,

        [ToolkitOption("UnsignedChar")]
        XtRUnsignedChar,

        [ToolkitOption("Visual")]
        XtRVisual,

        [ToolkitOption("Widget")]
        XtRWidget,

        [ToolkitOption("WidgetClass")]
        XtRWidgetClass,

        [ToolkitOption("WidgetList")]
        XtRWidgetList,

        [ToolkitOption("Window")]
        XtRWindow,

    }
}
