using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.Xt {
    public enum XtStackMode :int {
        Above = TonNurako.X11.Constant.Above,
        Below = TonNurako.X11.Constant.Below,
        TopIf = TonNurako.X11.Constant.TopIf,
        BottomIf = TonNurako.X11.Constant.BottomIf,
        Opposite = TonNurako.X11.Constant.Opposite,
        SMDontChange = TonNurako.X11.Constant.XtSMDontChange,
    }

    [Flags]
    public enum XtGeometryMask :int {
        CWX = TonNurako.X11.Constant.CWX,
        CWY = TonNurako.X11.Constant.CWY,
        CWWidth = TonNurako.X11.Constant.CWWidth,
        CWHeight = TonNurako.X11.Constant.CWHeight,
        CWBorderWidth = TonNurako.X11.Constant.CWBorderWidth,
        CWSibling = TonNurako.X11.Constant.CWSibling,
        CWStackMode = TonNurako.X11.Constant.CWStackMode,
        CWQueryOnly = TonNurako.X11.Constant.XtCWQueryOnly,
    }

    [Flags]
    public enum XtInputMask :ulong{
        XtInputNoneMask = TonNurako.Xt.Constant.XtInputNoneMask,
        XtInputReadMask = TonNurako.Xt.Constant.XtInputReadMask,
        XtInputWriteMask = TonNurako.Xt.Constant.XtInputWriteMask,
        XtInputExceptMask = TonNurako.Xt.Constant.XtInputExceptMask
    }
}
