using System;
using TonNurako.Native;

namespace TonNurako.X11 {
    public enum Constant {

        // locale
        LC_CTYPE	= 0,
        LC_NUMERIC	= 1,
        LC_TIME	= 2,
        LC_COLLATE	= 3,
        LC_MONETARY	= 4,
        LC_MESSAGES	= 5,
        LC_ALL	= 6,

        // Render(PictFormat)
        PictFormatID	= 1,
        PictFormatType	= 2,
        PictFormatDepth	= 4,
        PictFormatRed	= 8,
        PictFormatRedMask	= 16,
        PictFormatGreen	= 32,
        PictFormatGreenMask	= 64,
        PictFormatBlue	= 128,
        PictFormatBlueMask	= 256,
        PictFormatAlpha	= 512,
        PictFormatAlphaMask	= 1024,
        PictFormatColormap	= 2048,

        // Render(PictStandard)
        PictStandardARGB32	= 0,
        PictStandardRGB24	= 1,
        PictStandardA8	= 2,
        PictStandardA4	= 3,
        PictStandardA1	= 4,
        PictStandardNUM	= 5,

        // Render(X_)
        X_RenderQueryVersion	= 0,
        X_RenderQueryPictFormats	= 1,
        X_RenderQueryPictIndexValues	= 2,
        X_RenderQueryDithers	= 3,
        X_RenderCreatePicture	= 4,
        X_RenderChangePicture	= 5,
        X_RenderSetPictureClipRectangles	= 6,
        X_RenderFreePicture	= 7,
        X_RenderComposite	= 8,
        X_RenderScale	= 9,
        X_RenderTrapezoids	= 10,
        X_RenderTriangles	= 11,
        X_RenderTriStrip	= 12,
        X_RenderTriFan	= 13,
        X_RenderColorTrapezoids	= 14,
        X_RenderColorTriangles	= 15,
        X_RenderCreateGlyphSet	= 17,
        X_RenderReferenceGlyphSet	= 18,
        X_RenderFreeGlyphSet	= 19,
        X_RenderAddGlyphs	= 20,
        X_RenderAddGlyphsFromPicture	= 21,
        X_RenderFreeGlyphs	= 22,
        X_RenderCompositeGlyphs8	= 23,
        X_RenderCompositeGlyphs16	= 24,
        X_RenderCompositeGlyphs32	= 25,
        X_RenderFillRectangles	= 26,
        X_RenderCreateCursor	= 27,
        X_RenderSetPictureTransform	= 28,
        X_RenderQueryFilters	= 29,
        X_RenderSetPictureFilter	= 30,
        X_RenderCreateAnimCursor	= 31,
        X_RenderAddTraps	= 32,
        X_RenderCreateSolidFill	= 33,
        X_RenderCreateLinearGradient	= 34,
        X_RenderCreateRadialGradient	= 35,
        X_RenderCreateConicalGradient	= 36,
        RenderNumberRequests	= 37,

        // render(err)
        BadPictFormat	= 0,
        BadPicture	= 1,
        BadPictOp	= 2,
        BadGlyphSet	= 3,
        BadGlyph	= 4,
        RenderNumberErrors	= 5,

        // Render(PictType)
        PictTypeIndexed	= 0,
        PictTypeDirect	= 1,

        // Render(Operators)
        PictOpMinimum	= 0,
        PictOpClear	= 0,
        PictOpSrc	= 1,
        PictOpDst	= 2,
        PictOpOver	= 3,
        PictOpOverReverse	= 4,
        PictOpIn	= 5,
        PictOpInReverse	= 6,
        PictOpOut	= 7,
        PictOpOutReverse	= 8,
        PictOpAtop	= 9,
        PictOpAtopReverse	= 10,
        PictOpXor	= 11,
        PictOpAdd	= 12,
        PictOpSaturate	= 13,
        PictOpMaximum	= 13,
        PictOpDisjointMinimum	= 16,
        PictOpDisjointClear	= 16,
        PictOpDisjointSrc	= 17,
        PictOpDisjointDst	= 18,
        PictOpDisjointOver	= 19,
        PictOpDisjointOverReverse	= 20,
        PictOpDisjointIn	= 21,
        PictOpDisjointInReverse	= 22,
        PictOpDisjointOut	= 23,
        PictOpDisjointOutReverse	= 24,
        PictOpDisjointAtop	= 25,
        PictOpDisjointAtopReverse	= 26,
        PictOpDisjointXor	= 27,
        PictOpDisjointMaximum	= 27,
        PictOpConjointMinimum	= 32,
        PictOpConjointClear	= 32,
        PictOpConjointSrc	= 33,
        PictOpConjointDst	= 34,
        PictOpConjointOver	= 35,
        PictOpConjointOverReverse	= 36,
        PictOpConjointIn	= 37,
        PictOpConjointInReverse	= 38,
        PictOpConjointOut	= 39,
        PictOpConjointOutReverse	= 40,
        PictOpConjointAtop	= 41,
        PictOpConjointAtopReverse	= 42,
        PictOpConjointXor	= 43,
        PictOpConjointMaximum	= 43,
        PictOpBlendMinimum	= 48,
        PictOpMultiply	= 48,
        PictOpScreen	= 49,
        PictOpOverlay	= 50,
        PictOpDarken	= 51,
        PictOpLighten	= 52,
        PictOpColorDodge	= 53,
        PictOpColorBurn	= 54,
        PictOpHardLight	= 55,
        PictOpSoftLight	= 56,
        PictOpDifference	= 57,
        PictOpExclusion	= 58,
        PictOpHSLHue	= 59,
        PictOpHSLSaturation	= 60,
        PictOpHSLColor	= 61,
        PictOpHSLLuminosity	= 62,
        PictOpBlendMaximum	= 62,
        PolyEdgeSharp	= 0,
        PolyEdgeSmooth	= 1,
        PolyModePrecise	= 0,
        PolyModeImprecise	= 1,

        // Render(CPMask)
        CPRepeat	= 1,
        CPAlphaMap	= 2,
        CPAlphaXOrigin	= 4,
        CPAlphaYOrigin	= 8,
        CPClipXOrigin	= 16,
        CPClipYOrigin	= 32,
        CPClipMask	= 64,
        CPGraphicsExposure	= 128,
        CPSubwindowMode	= 256,
        CPPolyEdge	= 512,
        CPPolyMode	= 1024,
        CPDither	= 2048,
        CPComponentAlpha	= 4096,
        CPLastBit	= 12,

        // render
        FilterAliasNone	= -1,

        // render
        SubPixelUnknown	= 0,
        SubPixelHorizontalRGB	= 1,
        SubPixelHorizontalBGR	= 2,
        SubPixelVerticalRGB	= 3,
        SubPixelVerticalBGR	= 4,
        SubPixelNone	= 5,

        // render
        RepeatNone	= 0,
        RepeatNormal	= 1,
        RepeatPad	= 2,
        RepeatReflect	= 3,

        // FcResult
        FcResultMatch	= 0,
        FcResultNoMatch	= 1,
        FcResultTypeMismatch	= 2,
        FcResultNoId	= 3,
        FcResultOutOfMemory	= 4,

        // FcEndian
        FcEndianBig	= 0,
        FcEndianLittle	= 1,

        // FC_CHARSET
        FC_CHARSET_MAP_SIZE	= 8,
        FC_CHARSET_DONE	= -1,

        // FcType
        FcTypeUnknown	= -1,
        FcTypeVoid	= 0,
        FcTypeInteger	= 1,
        FcTypeDouble	= 2,
        FcTypeString	= 3,
        FcTypeBool	= 4,
        FcTypeMatrix	= 5,
        FcTypeCharSet	= 6,
        FcTypeFTFace	= 7,
        FcTypeLangSet	= 8,
        FC_CHAR_WIDTH	= 4223626,

        // FC_WEIGHT
        FC_WEIGHT_THIN	= 0,
        FC_WEIGHT_EXTRALIGHT	= 40,
        FC_WEIGHT_ULTRALIGHT	= 40,
        FC_WEIGHT_LIGHT	= 50,
        FC_WEIGHT_BOOK	= 75,
        FC_WEIGHT_REGULAR	= 80,
        FC_WEIGHT_NORMAL	= 80,
        FC_WEIGHT_MEDIUM	= 100,
        FC_WEIGHT_DEMIBOLD	= 180,
        FC_WEIGHT_SEMIBOLD	= 180,
        FC_WEIGHT_BOLD	= 200,
        FC_WEIGHT_EXTRABOLD	= 205,
        FC_WEIGHT_ULTRABOLD	= 205,
        FC_WEIGHT_BLACK	= 210,
        FC_WEIGHT_HEAVY	= 210,
        FC_WEIGHT_EXTRABLACK	= 215,
        FC_WEIGHT_ULTRABLACK	= 215,

        // FC_SLANT
        FC_SLANT_ROMAN	= 0,
        FC_SLANT_ITALIC	= 100,
        FC_SLANT_OBLIQUE	= 110,

        // FC_WIDTH
        FC_WIDTH_ULTRACONDENSED	= 50,
        FC_WIDTH_EXTRACONDENSED	= 63,
        FC_WIDTH_CONDENSED	= 75,
        FC_WIDTH_SEMICONDENSED	= 87,
        FC_WIDTH_NORMAL	= 100,
        FC_WIDTH_SEMIEXPANDED	= 113,
        FC_WIDTH_EXPANDED	= 125,
        FC_WIDTH_EXTRAEXPANDED	= 150,
        FC_WIDTH_ULTRAEXPANDED	= 200,
        FC_PROPORTIONAL	= 0,
        FC_DUAL	= 90,
        FC_MONO	= 100,
        FC_CHARCELL	= 110,

        // sub-pixel_order
        FC_RGBA_UNKNOWN	= 0,
        FC_RGBA_RGB	= 1,
        FC_RGBA_BGR	= 2,
        FC_RGBA_VRGB	= 3,
        FC_RGBA_VBGR	= 4,
        FC_RGBA_NONE	= 5,

        // hinting_style
        FC_HINT_NONE	= 0,
        FC_HINT_SLIGHT	= 1,
        FC_HINT_MEDIUM	= 2,
        FC_HINT_FULL	= 3,

        // LCD
        FC_LCD_NONE	= 0,
        FC_LCD_DEFAULT	= 1,
        FC_LCD_LIGHT	= 2,
        FC_LCD_LEGACY	= 3,

        // FcMatchKind
        FcMatchPattern	= 0,
        FcMatchFont	= 1,
        FcMatchScan	= 2,

        // FcLangResult
        FcLangEqual	= 0,
        FcLangDifferentCountry	= 1,
        FcLangDifferentTerritory	= 1,
        FcLangDifferentLang	= 2,

        // FcSetName
        FcSetSystem	= 0,
        FcSetApplication	= 1,

        // CursorShape
        ShapeSet	= 0,
        ShapeUnion	= 1,
        ShapeIntersect	= 2,
        ShapeSubtract	= 3,
        ShapeInvert	= 4,
        ShapeBounding	= 0,
        ShapeClip	= 1,
        ShapeInput	= 2,
        ShapeNotifyMask	= 1,
        ShapeNotify	= 0,
        ShapeNumberEvents	= 1,

        // region
        RectangleOut	= 0,
        RectangleIn	= 1,
        RectanglePart	= 2,

        // Visual
        VisualNoMask	= 0,
        VisualIDMask	= 1,
        VisualScreenMask	= 2,
        VisualDepthMask	= 4,
        VisualClassMask	= 8,
        VisualRedMaskMask	= 16,
        VisualGreenMaskMask	= 32,
        VisualBlueMaskMask	= 64,
        VisualColormapSizeMask	= 128,
        VisualBitsPerRGBMask	= 256,
        VisualAllMask	= 511,

        // XICCEncodingStyle
        XNoMemory	= -1,
        XLocaleNotSupported	= -2,
        XConverterNotFound	= -3,
        XStringStyle	= 0,
        XCompoundTextStyle	= 1,
        XTextStyle	= 2,
        XStdICCTextStyle	= 3,
        XUTF8StringStyle	= 4,

        // ｸﾞﾛｰﾊﾞﾙ
        PointerWindow	= 0,
        InputFocus	= 1,
        PointerRoot	= 1,
        AnyPropertyType	= 0,
        AnyKey	= 0,
        AnyButton	= 0,
        AllTemporary	= 0,
        CurrentTime	= 0,
        NoSymbol	= 0,
        AllPlanes	= -1,

        // Xlib
        QueuedAlready	= 0,
        QueuedAfterReading	= 1,
        QueuedAfterFlush	= 2,

        // いべんとますく
        NoEventMask	= 0,
        KeyPressMask	= 1,
        KeyReleaseMask	= 2,
        ButtonPressMask	= 4,
        ButtonReleaseMask	= 8,
        EnterWindowMask	= 16,
        LeaveWindowMask	= 32,
        PointerMotionMask	= 64,
        PointerMotionHintMask	= 128,
        Button1MotionMask	= 256,
        Button2MotionMask	= 512,
        Button3MotionMask	= 1024,
        Button4MotionMask	= 2048,
        Button5MotionMask	= 4096,
        ButtonMotionMask	= 8192,
        KeymapStateMask	= 16384,
        ExposureMask	= 32768,
        VisibilityChangeMask	= 65536,
        StructureNotifyMask	= 131072,
        ResizeRedirectMask	= 262144,
        SubstructureNotifyMask	= 524288,
        SubstructureRedirectMask	= 1048576,
        FocusChangeMask	= 2097152,
        PropertyChangeMask	= 4194304,
        ColormapChangeMask	= 8388608,
        OwnerGrabButtonMask	= 16777216,

        // いべんと
        KeyPress	= 2,
        KeyRelease	= 3,
        ButtonPress	= 4,
        ButtonRelease	= 5,
        MotionNotify	= 6,
        EnterNotify	= 7,
        LeaveNotify	= 8,
        FocusIn	= 9,
        FocusOut	= 10,
        KeymapNotify	= 11,
        Expose	= 12,
        GraphicsExpose	= 13,
        NoExpose	= 14,
        VisibilityNotify	= 15,
        CreateNotify	= 16,
        DestroyNotify	= 17,
        UnmapNotify	= 18,
        MapNotify	= 19,
        MapRequest	= 20,
        ReparentNotify	= 21,
        ConfigureNotify	= 22,
        ConfigureRequest	= 23,
        GravityNotify	= 24,
        ResizeRequest	= 25,
        CirculateNotify	= 26,
        CirculateRequest	= 27,
        PropertyNotify	= 28,
        SelectionClear	= 29,
        SelectionRequest	= 30,
        SelectionNotify	= 31,
        ColormapNotify	= 32,
        ClientMessage	= 33,
        MappingNotify	= 34,
        GenericEvent	= 35,
        LASTEvent	= 36,

        // 装飾キー
        ShiftMask	= 1,
        LockMask	= 2,
        ControlMask	= 4,
        Mod1Mask	= 8,
        Mod2Mask	= 16,
        Mod3Mask	= 32,
        Mod4Mask	= 64,
        Mod5Mask	= 128,

        // mod
        ShiftMapIndex	= 0,
        LockMapIndex	= 1,
        ControlMapIndex	= 2,
        Mod1MapIndex	= 3,
        Mod2MapIndex	= 4,
        Mod3MapIndex	= 5,
        Mod4MapIndex	= 6,
        Mod5MapIndex	= 7,

        // ボタムマスク
        Button1Mask	= 256,
        Button2Mask	= 512,
        Button3Mask	= 1024,
        Button4Mask	= 2048,
        Button5Mask	= 4096,
        AnyModifier	= 32768,

        // 
        Button1	= 1,
        Button2	= 2,
        Button3	= 3,
        Button4	= 4,
        Button5	= 5,

        // ボタム通知
        NotifyNormal	= 0,
        NotifyGrab	= 1,
        NotifyUngrab	= 2,
        NotifyWhileGrabbed	= 3,

        // VB
        VisibilityUnobscured	= 0,
        VisibilityPartiallyObscured	= 1,
        VisibilityFullyObscured	= 2,

        // 切り替え
        PlaceOnTop	= 0,
        PlaceOnBottom	= 1,

        // FAX
        FamilyInternet	= 0,
        FamilyDECnet	= 1,
        FamilyChaos	= 2,
        FamilyInternet6	= 6,
        FamilyServerInterpreted	= 5,

        // プロパチー
        PropertyNewValue	= 0,
        PropertyDelete	= 1,

        // CMイベント
        ColormapUninstalled	= 0,
        ColormapInstalled	= 1,

        // ごゆるりワールド
        GrabModeSync	= 0,
        GrabModeAsync	= 1,

        // ごゆるりワールド(状態)
        GrabSuccess	= 0,
        AlreadyGrabbed	= 1,
        GrabInvalidTime	= 2,
        GrabNotViewable	= 3,
        GrabFrozen	= 4,

        // ごゆるりワールド(イベント)
        AsyncPointer	= 0,
        SyncPointer	= 1,
        ReplayPointer	= 2,
        AsyncKeyboard	= 3,
        SyncKeyboard	= 4,
        ReplayKeyboard	= 5,
        AsyncBoth	= 6,
        SyncBoth	= 7,

        // フォーカス
        RevertToNone	= 0,
        RevertToPointerRoot	= 1,
        RevertToParent	= 2,

        // エラーコード
        Success	= 0,
        BadRequest	= 1,
        BadValue	= 2,
        BadWindow	= 3,
        BadPixmap	= 4,
        BadAtom	= 5,
        BadCursor	= 6,
        BadFont	= 7,
        BadMatch	= 8,
        BadDrawable	= 9,
        BadAccess	= 10,
        BadAlloc	= 11,
        BadColor	= 12,
        BadGC	= 13,
        BadIDChoice	= 14,
        BadName	= 15,
        BadLength	= 16,
        BadImplementation	= 17,
        FirstExtensionError	= 128,
        LastExtensionError	= 255,

        // CW
        InputOutput	= 1,
        InputOnly	= 2,
        CopyFromParent	= 0,

        // ChangeWindowAttributes
        CWBackPixmap	= 1,
        CWBackPixel	= 2,
        CWBorderPixmap	= 4,
        CWBorderPixel	= 8,
        CWBitGravity	= 16,
        CWWinGravity	= 32,
        CWBackingStore	= 64,
        CWBackingPlanes	= 128,
        CWBackingPixel	= 256,
        CWOverrideRedirect	= 512,
        CWSaveUnder	= 1024,
        CWEventMask	= 2048,
        CWDontPropagate	= 4096,
        CWColormap	= 8192,
        CWCursor	= 16384,

        // ConfigureWindow
        CWX	= 1,
        CWY	= 2,
        CWWidth	= 4,
        CWHeight	= 8,
        CWBorderWidth	= 16,
        CWSibling	= 32,
        CWStackMode	= 64,
        XtCWQueryOnly	= 128,

        // Gravity
        ForgetGravity	= 0,
        NorthWestGravity	= 1,
        NorthGravity	= 2,
        NorthEastGravity	= 3,
        WestGravity	= 4,
        CenterGravity	= 5,
        EastGravity	= 6,
        SouthWestGravity	= 7,
        SouthGravity	= 8,
        SouthEastGravity	= 9,
        StaticGravity	= 10,

        // UnmapGravity
        UnmapGravity	= 0,

        // CWﾊﾞｯｷﾝｸﾞｽﾄｱー
        NotUseful	= 0,
        WhenMapped	= 1,
        Always	= 2,

        // GetWindowAttributes
        IsUnmapped	= 0,
        IsUnviewable	= 1,
        IsViewable	= 2,

        // ChangeSaveSet
        SetModeInsert	= 0,
        SetModeDelete	= 1,

        // ChangeCloseDownMode
        DestroyAll	= 0,
        RetainPermanent	= 1,
        RetainTemporary	= 2,

        // ｽﾀｯｸ
        Above	= 0,
        Below	= 1,
        TopIf	= 2,
        BottomIf	= 3,
        Opposite	= 4,
        XtSMDontChange	= 5,

        // 循環方向
        RaiseLowest	= 0,
        LowerHighest	= 1,

        // プロパチー
        PropModeReplace	= 0,
        PropModePrepend	= 1,
        PropModeAppend	= 2,

        // GC定数
        GXclear	= 0,
        GXand	= 1,
        GXandReverse	= 2,
        GXcopy	= 3,
        GXandInverted	= 4,
        GXnoop	= 5,
        GXxor	= 6,
        GXor	= 7,
        GXnor	= 8,
        GXequiv	= 9,
        GXinvert	= 10,
        GXorReverse	= 11,
        GXcopyInverted	= 12,
        GXorInverted	= 13,
        GXnand	= 14,
        GXset	= 15,

        // LineStyle
        LineSolid	= 0,
        LineOnOffDash	= 1,
        LineDoubleDash	= 2,

        // capStyle
        CapNotLast	= 0,
        CapButt	= 1,
        CapRound	= 2,
        CapProjecting	= 3,

        // joinStyle
        JoinMiter	= 0,
        JoinRound	= 1,
        JoinBevel	= 2,

        // fillStyle
        FillSolid	= 0,
        FillTiled	= 1,
        FillStippled	= 2,
        FillOpaqueStippled	= 3,

        // fillRule
        EvenOddRule	= 0,
        WindingRule	= 1,

        // subwindow
        ClipByChildren	= 0,
        IncludeInferiors	= 1,

        // SetClipRectanglesのOrder
        Unsorted	= 0,
        YSorted	= 1,
        YXSorted	= 2,
        YXBanded	= 3,

        // CoordinateMode
        CoordModeOrigin	= 0,
        CoordModePrevious	= 1,

        // Polygon
        Complex	= 0,
        Nonconvex	= 1,
        Convex	= 2,

        // PolyFillArc
        ArcChord	= 0,
        ArcPieSlice	= 1,

        // CreateGC
        GCFunction	= 1,
        GCPlaneMask	= 2,
        GCForeground	= 4,
        GCBackground	= 8,
        GCLineWidth	= 16,
        GCLineStyle	= 32,
        GCCapStyle	= 64,
        GCJoinStyle	= 128,
        GCFillStyle	= 256,
        GCFillRule	= 512,
        GCTile	= 1024,
        GCStipple	= 2048,
        GCTileStipXOrigin	= 4096,
        GCTileStipYOrigin	= 8192,
        GCFont	= 16384,
        GCSubwindowMode	= 32768,
        GCGraphicsExposures	= 65536,
        GCClipXOrigin	= 131072,
        GCClipYOrigin	= 262144,
        GCClipMask	= 524288,
        GCDashOffset	= 1048576,
        GCDashList	= 2097152,
        GCArcMode	= 4194304,
        GCLastBit	= 22,

        // QueryFont
        FontLeftToRight	= 0,
        FontRightToLeft	= 1,
        FontChange	= 255,

        // ImageFormat
        XYBitmap	= 0,
        XYPixmap	= 1,
        ZPixmap	= 2,

        // CreateColormap
        AllocNone	= 0,
        AllocAll	= 1,

        // StoreColors
        DoRed	= 1,
        DoGreen	= 2,
        DoBlue	= 4,

        // QueryBestSize
        CursorShape	= 0,
        TileShape	= 1,
        StippleShape	= 2,

        // XKB
        AutoRepeatModeOff	= 0,
        AutoRepeatModeOn	= 1,
        AutoRepeatModeDefault	= 2,
        LedModeOff	= 0,
        LedModeOn	= 1,

        // ChangeKeyboardControlますく
        KBKeyClickPercent	= 1,
        KBBellPercent	= 2,
        KBBellPitch	= 4,
        KBBellDuration	= 8,
        KBLed	= 16,
        KBLedMode	= 32,
        KBKey	= 64,
        KBAutoRepeatMode	= 128,

        // ChangeKeyboardControl
        MappingSuccess	= 0,
        MappingBusy	= 1,
        MappingFailed	= 2,
        MappingModifier	= 0,
        MappingKeyboard	= 1,
        MappingPointer	= 2,

        // スクリーンケイバー
        DontPreferBlanking	= 0,
        PreferBlanking	= 1,
        DefaultBlanking	= 2,
        DisableScreenSaver	= 0,
        DisableScreenInterval	= 0,
        DontAllowExposures	= 0,
        AllowExposures	= 1,
        DefaultExposures	= 2,

        // ForceScreenSaver
        ScreenSaverReset	= 0,
        ScreenSaverActive	= 1,

        // ChangeHosts
        HostInsert	= 0,
        HostDelete	= 1,

        // ChangeAccessControl
        EnableAccess	= 1,
        DisableAccess	= 0,

        // Display
        StaticGray	= 0,
        GrayScale	= 1,
        StaticColor	= 2,
        PseudoColor	= 3,
        TrueColor	= 4,
        DirectColor	= 5,

        // imageByteOrder
        LSBFirst	= 0,
        MSBFirst	= 1,

        // XIM
        XIMPreeditArea	= 1,
        XIMPreeditCallbacks	= 2,
        XIMPreeditPosition	= 4,
        XIMPreeditNothing	= 8,
        XIMPreeditNone	= 16,
        XIMStatusArea	= 256,
        XIMStatusCallbacks	= 512,
        XIMStatusNothing	= 1024,
        XIMStatusNone	= 2048,
        XBufferOverflow	= -1,
        XLookupNone	= 1,
        XLookupChars	= 2,
        XLookupKeySym	= 3,
        XLookupBoth	= 4,
        XIMReverse	= 1,
        XIMUnderline	= 2,
        XIMHighlight	= 4,
        XIMPrimary	= 32,
        XIMSecondary	= 64,
        XIMTertiary	= 128,
        XIMVisibleToForward	= 256,
        XIMVisibleToBackword	= 512,
        XIMVisibleToCenter	= 1024,
        XIMPreeditUnKnown	= 0,
        XIMPreeditEnable	= 1,
        XIMPreeditDisable	= 2,
        XIMInitialState	= 1,
        XIMPreserveState	= 2,
        XIMStringConversionLeftEdge	= 1,
        XIMStringConversionRightEdge	= 2,
        XIMStringConversionTopEdge	= 4,
        XIMStringConversionBottomEdge	= 8,
        XIMStringConversionConcealed	= 16,
        XIMStringConversionWrapped	= 32,
        XIMStringConversionBuffer	= 1,
        XIMStringConversionLine	= 2,
        XIMStringConversionWord	= 3,
        XIMStringConversionChar	= 4,
        XIMStringConversionSubstitution	= 1,
        XIMStringConversionRetrieval	= 2,

        // Cursor Font
        XC_num_glyphs	= 154,
        XC_X_cursor	= 0,
        XC_arrow	= 2,
        XC_based_arrow_down	= 4,
        XC_based_arrow_up	= 6,
        XC_boat	= 8,
        XC_bogosity	= 10,
        XC_bottom_left_corner	= 12,
        XC_bottom_right_corner	= 14,
        XC_bottom_side	= 16,
        XC_bottom_tee	= 18,
        XC_box_spiral	= 20,
        XC_center_ptr	= 22,
        XC_circle	= 24,
        XC_clock	= 26,
        XC_coffee_mug	= 28,
        XC_cross	= 30,
        XC_cross_reverse	= 32,
        XC_crosshair	= 34,
        XC_diamond_cross	= 36,
        XC_dot	= 38,
        XC_dotbox	= 40,
        XC_double_arrow	= 42,
        XC_draft_large	= 44,
        XC_draft_small	= 46,
        XC_draped_box	= 48,
        XC_exchange	= 50,
        XC_fleur	= 52,
        XC_gobbler	= 54,
        XC_gumby	= 56,
        XC_hand1	= 58,
        XC_hand2	= 60,
        XC_heart	= 62,
        XC_icon	= 64,
        XC_iron_cross	= 66,
        XC_left_ptr	= 68,
        XC_left_side	= 70,
        XC_left_tee	= 72,
        XC_leftbutton	= 74,
        XC_ll_angle	= 76,
        XC_lr_angle	= 78,
        XC_man	= 80,
        XC_middlebutton	= 82,
        XC_mouse	= 84,
        XC_pencil	= 86,
        XC_pirate	= 88,
        XC_plus	= 90,
        XC_question_arrow	= 92,
        XC_right_ptr	= 94,
        XC_right_side	= 96,
        XC_right_tee	= 98,
        XC_rightbutton	= 100,
        XC_rtl_logo	= 102,
        XC_sailboat	= 104,
        XC_sb_down_arrow	= 106,
        XC_sb_h_double_arrow	= 108,
        XC_sb_left_arrow	= 110,
        XC_sb_right_arrow	= 112,
        XC_sb_up_arrow	= 114,
        XC_sb_v_double_arrow	= 116,
        XC_shuttle	= 118,
        XC_sizing	= 120,
        XC_spider	= 122,
        XC_spraycan	= 124,
        XC_star	= 126,
        XC_target	= 128,
        XC_tcross	= 130,
        XC_top_left_arrow	= 132,
        XC_top_left_corner	= 134,
        XC_top_right_corner	= 136,
        XC_top_side	= 138,
        XC_top_tee	= 140,
        XC_trek	= 142,
        XC_ul_angle	= 144,
        XC_umbrella	= 146,
        XC_ur_angle	= 148,
        XC_watch	= 150,
        XC_xterm	= 152,
    }
}
