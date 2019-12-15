using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.X11.Extension.Xft {
    public enum FcType :int{
        FcTypeUnknown = TonNurako.X11.Constant.FcTypeUnknown,
        FcTypeVoid = TonNurako.X11.Constant.FcTypeVoid,
        FcTypeInteger = TonNurako.X11.Constant.FcTypeInteger,
        FcTypeDouble = TonNurako.X11.Constant.FcTypeDouble,
        FcTypeString = TonNurako.X11.Constant.FcTypeString,
        FcTypeBool = TonNurako.X11.Constant.FcTypeBool,
        FcTypeMatrix = TonNurako.X11.Constant.FcTypeMatrix,
        FcTypeCharSet = TonNurako.X11.Constant.FcTypeCharSet,
        FcTypeFTFace = TonNurako.X11.Constant.FcTypeFTFace,
        FcTypeLangSet = TonNurako.X11.Constant.FcTypeLangSet,
        //FcTypeRange = TonNurako.X11.Constant.FcTypeRange,
    }

    public enum FcMatchKind : int {
        FcMatchPattern = TonNurako.X11.Constant.FcMatchPattern,
        FcMatchFont = TonNurako.X11.Constant.FcMatchFont,
        FcMatchScan = TonNurako.X11.Constant.FcMatchScan
    }

    public enum FcLangResult : int {
        FcLangEqual = TonNurako.X11.Constant.FcLangEqual,
        FcLangDifferentCountry = TonNurako.X11.Constant.FcLangDifferentCountry,
        FcLangDifferentTerritory = TonNurako.X11.Constant.FcLangDifferentTerritory,
        FcLangDifferentLang = TonNurako.X11.Constant.FcLangDifferentLang
    }

    public enum FcSetName : int {
        FcSetSystem = TonNurako.X11.Constant.FcSetSystem,
        FcSetApplication = TonNurako.X11.Constant.FcSetApplication
    }
}
