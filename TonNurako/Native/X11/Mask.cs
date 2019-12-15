//
// ﾄﾝﾇﾗｺ
// 
// Xlibﾗｯﾊﾟー
//
using System;
namespace TonNurako.X11
{

    /// <summary>
    /// ﾊﾞｯｷﾝｸﾞｽﾄｱー
    /// </summary>
    public enum BackingStoreHint : int {
        NotUseful   = TonNurako.X11.Constant.NotUseful,
        WhenMapped  = TonNurako.X11.Constant.WhenMapped,
        Always      = TonNurako.X11.Constant.Always,
    }

    /// <summary>
    /// ordering
    /// </summary>
    public enum Ordering : int{
        Unsorted = TonNurako.X11.Constant.Unsorted,
        YSorted = TonNurako.X11.Constant.YSorted,
        YXSorted = TonNurako.X11.Constant.YXSorted,
        YXBanded = TonNurako.X11.Constant.YXBanded,
    }

    /// <summary>
    /// ChangeCloseDownModeの定数
    /// </summary>
    public enum CloseDownMode : int {
        DestroyAll = TonNurako.X11.Constant.DestroyAll,
        RetainPermanent = TonNurako.X11.Constant.RetainPermanent,
        RetainTemporary = TonNurako.X11.Constant.RetainTemporary
    }

    /// <summary>
    /// ﾌｫーｶｽ
    /// </summary>
    public enum RevertTo : int {
        None = TonNurako.X11.Constant.RevertToNone,
        PointerRoot = TonNurako.X11.Constant.RevertToPointerRoot,
        Parent = TonNurako.X11.Constant.RevertToParent
    }


    /// <summary>
    /// MapState
    /// </summary>
    public enum MapState : int {
        IsUnmapped = TonNurako.X11.Constant.IsUnmapped,
        IsUnviewable = TonNurako.X11.Constant.IsUnviewable,
        IsViewable = TonNurako.X11.Constant.IsViewable,
    }

    /// <summary>
    /// Grab
    /// </summary>
    public enum GrabMode : int {
        GrabModeSync = TonNurako.X11.Constant.GrabModeSync,
        GrabModeAsync = TonNurako.X11.Constant.GrabModeAsync,
    }

    public enum WindowClass : int {
        InputOutput = TonNurako.X11.Constant.InputOutput,
        InputOnly = TonNurako.X11.Constant.InputOnly,
        CopyFromParent = TonNurako.X11.Constant.CopyFromParent
    }


    /// <summary>
    /// ChangeWindowAttributes
    /// </summary>
    [Flags]
    public enum ChangeWindowAttributes : int {
        CWBackPixmap = TonNurako.X11.Constant.CWBackPixmap,
        CWBackPixel = TonNurako.X11.Constant.CWBackPixel,
        CWBorderPixmap = TonNurako.X11.Constant.CWBorderPixmap,
        CWBorderPixel = TonNurako.X11.Constant.CWBorderPixel,
        CWBitGravity = TonNurako.X11.Constant.CWBitGravity,
        CWWinGravity = TonNurako.X11.Constant.CWWinGravity,
        CWBackingStore = TonNurako.X11.Constant.CWBackingStore,
        CWBackingPlanes = TonNurako.X11.Constant.CWBackingPlanes,
        CWBackingPixel = TonNurako.X11.Constant.CWBackingPixel,
        CWOverrideRedirect = TonNurako.X11.Constant.CWOverrideRedirect,
        CWSaveUnder = TonNurako.X11.Constant.CWSaveUnder,
        CWEventMask = TonNurako.X11.Constant.CWEventMask,
        CWDontPropagate = TonNurako.X11.Constant.CWDontPropagate,
        CWColormap = TonNurako.X11.Constant.CWColormap,
        CWCursor = TonNurako.X11.Constant.CWCursor
    }

    /// <summary>
    /// Gravity
    /// </summary>
    [Flags]
    public enum Gravity : int {
        ForgetGravity = TonNurako.X11.Constant.ForgetGravity,
        NorthWestGravity = TonNurako.X11.Constant.NorthWestGravity,
        NorthGravity = TonNurako.X11.Constant.NorthGravity,
        NorthEastGravity = TonNurako.X11.Constant.NorthEastGravity,
        WestGravity = TonNurako.X11.Constant.WestGravity,
        CenterGravity = TonNurako.X11.Constant.CenterGravity,
        EastGravity = TonNurako.X11.Constant.EastGravity,
        SouthWestGravity = TonNurako.X11.Constant.SouthWestGravity,
        SouthGravity = TonNurako.X11.Constant.SouthGravity,
        SouthEastGravity = TonNurako.X11.Constant.SouthEastGravity,
        StaticGravity = TonNurako.X11.Constant.StaticGravity,
    }


    public enum UnmapGravity : int {
        UnmapGravity = TonNurako.X11.Constant.UnmapGravity,
        NorthWestGravity = TonNurako.X11.Constant.NorthWestGravity,
        NorthGravity = TonNurako.X11.Constant.NorthGravity,
        NorthEastGravity = TonNurako.X11.Constant.NorthEastGravity,
        WestGravity = TonNurako.X11.Constant.WestGravity,
        CenterGravity = TonNurako.X11.Constant.CenterGravity,
        EastGravity = TonNurako.X11.Constant.EastGravity,
        SouthWestGravity = TonNurako.X11.Constant.SouthWestGravity,
        SouthGravity = TonNurako.X11.Constant.SouthGravity,
        SouthEastGravity = TonNurako.X11.Constant.SouthEastGravity,
        StaticGravity = TonNurako.X11.Constant.StaticGravity,
    }

    /// <summary>
    /// ｲﾍﾞﾝﾄﾏｽｸ
    /// </summary>
    [Flags]
    public enum EventMask : long {
        NoEventMask             = TonNurako.X11.Constant.NoEventMask,
        KeyPressMask            = TonNurako.X11.Constant.KeyPressMask,
        KeyReleaseMask          = TonNurako.X11.Constant.KeyReleaseMask,
        ButtonPressMask         = TonNurako.X11.Constant.ButtonPressMask,
        ButtonReleaseMask       = TonNurako.X11.Constant.ButtonReleaseMask,
        EnterWindowMask         = TonNurako.X11.Constant.EnterWindowMask,
        LeaveWindowMask         = TonNurako.X11.Constant.LeaveWindowMask,
        PointerMotionMask       = TonNurako.X11.Constant.PointerMotionMask,
        PointerMotionHintMask   = TonNurako.X11.Constant.PointerMotionHintMask,
        Button1MotionMask       = TonNurako.X11.Constant.Button1MotionMask,
        Button2MotionMask       = TonNurako.X11.Constant.Button2MotionMask,
        Button3MotionMask       = TonNurako.X11.Constant.Button3MotionMask,
        Button4MotionMask       = TonNurako.X11.Constant.Button4MotionMask,
        Button5MotionMask       = TonNurako.X11.Constant.Button5MotionMask,
        ButtonMotionMask        = TonNurako.X11.Constant.ButtonMotionMask,
        KeymapStateMask         = TonNurako.X11.Constant.KeymapStateMask,
        ExposureMask            = TonNurako.X11.Constant.ExposureMask,
        VisibilityChangeMask    = TonNurako.X11.Constant.VisibilityChangeMask,
        StructureNotifyMask     = TonNurako.X11.Constant.StructureNotifyMask,
        ResizeRedirectMask      = TonNurako.X11.Constant.ResizeRedirectMask,
        SubstructureNotifyMask  = TonNurako.X11.Constant.SubstructureNotifyMask,
        SubstructureRedirectMask = TonNurako.X11.Constant.SubstructureRedirectMask,
        FocusChangeMask         = TonNurako.X11.Constant.FocusChangeMask,
        PropertyChangeMask      = TonNurako.X11.Constant.PropertyChangeMask,
        ColormapChangeMask      = TonNurako.X11.Constant.ColormapChangeMask,
        OwnerGrabButtonMask     = TonNurako.X11.Constant.OwnerGrabButtonMask,
    }

    /// <summary>
    /// 装飾キーﾏｽｸ
    /// </summary>
    [Flags]
    public enum ModifierMask : uint {
        // 装飾キー
        ShiftMask = TonNurako.X11.Constant.ShiftMask,
        LockMask = TonNurako.X11.Constant.LockMask,
        ControlMask = TonNurako.X11.Constant.ControlMask,
        Mod1Mask = TonNurako.X11.Constant.Mod1Mask,
        Mod2Mask = TonNurako.X11.Constant.Mod2Mask,
        Mod3Mask = TonNurako.X11.Constant.Mod3Mask,
        Mod4Mask = TonNurako.X11.Constant.Mod4Mask,
        Mod5Mask = TonNurako.X11.Constant.Mod5Mask,
        // ボタムマスク
        Button1Mask = TonNurako.X11.Constant.Button1Mask,
        Button2Mask = TonNurako.X11.Constant.Button2Mask,
        Button3Mask = TonNurako.X11.Constant.Button3Mask,
        Button4Mask = TonNurako.X11.Constant.Button4Mask,
        Button5Mask = TonNurako.X11.Constant.Button5Mask,
        AnyModifier = TonNurako.X11.Constant.AnyModifier,
    }
}
