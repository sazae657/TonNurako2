//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
    public enum AudibleWarning {
        Bell = TonNurako.Motif.Constant.XmBELL,
        None = TonNurako.Motif.Constant.XmNONE
    }
    public enum DeleteResponse {
        Destroy = TonNurako.Motif.Constant.XmDESTROY,
        Unmap = TonNurako.Motif.Constant.XmUNMAP,
        DoNothing = TonNurako.Motif.Constant.XmDO_NOTHING,

    }

    public enum InputPolicy {
        PerShell = TonNurako.Motif.Constant.XmPER_SHELL,
        PerWidget = TonNurako.Motif.Constant.XmPER_WIDGET,
    }

    public enum KeyboardFocusPolicy {
        Explicit = TonNurako.Motif.Constant.XmEXPLICIT,
        Pointer = TonNurako.Motif.Constant.XmPOINTER,
    }

    [Flags]
    public enum MwmDecorations {
        All       = (1 << 0),
        Border    = (1 << 1),
        Resizeh   = (1 << 2),
        Title     = (1 << 3),
        Menu      = (1 << 4),
        Minimize  = (1 << 5),
        Maximize  = (1 << 6),
    }

    public enum MwmFunctions  {
        All      =  (1 << 0),
        Resize   = (1 << 1),
        Move     = (1 << 2),
        Minimize  = (1 << 3),
        Maximize  = (1 << 4),
        Close     = (1 << 5),
    }

	/// <summary>
	/// VendorShell
	/// </summary>
	public abstract class VendorShell : WMShell, IDefectiveWidget
	{

		public VendorShell() : base() {

		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		public override int Create(IWidget parent) {
			return base.Create (parent);
		}

		#region ﾌﾟﾛﾊﾟﾁー
        /// XmNaudibleWarning XmCAudibleWarning unsigned char XmBELL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual AudibleWarning AudibleWarning {
            get {
                return XSports.GetValue<AudibleWarning>(
                    TonNurako.Motif.ResourceId.XmNaudibleWarning, AudibleWarning.Bell, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<AudibleWarning>(
                    TonNurako.Motif.ResourceId.XmNaudibleWarning, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNbuttonFontList XmCButtonFontList XmFontList dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SportyFontList ButtonFontList {
            get {
                return XSports.GetFontList(
                    TonNurako.Motif.ResourceId.XmNbuttonFontList,  Data.Resource.Access.CSG);
            }
            set {
                XSports.SetFontList(
                    TonNurako.Motif.ResourceId.XmNbuttonFontList, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNbuttonRenderTable XmCButtonRenderTable XmRenderTable dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable ButtonRenderTable  {
            get {
                return XSports.GetRenderTable(
                    TonNurako.Motif.ResourceId.XmNbuttonRenderTable, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetRenderTable(
                    TonNurako.Motif.ResourceId.XmNbuttonRenderTable, value, Data.Resource.Access.CSG);
            }
        }


        /// XmNdefaultFontList XmCDefaultFontList XmFontList dynamic CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual SportyFontList DefaultFontList {
            get {
                return XSports.GetFontList(
                    TonNurako.Motif.ResourceId.XmNdefaultFontList, Data.Resource.Access.CG);
            }
            set {
                XSports.SetFontList(
                    TonNurako.Motif.ResourceId.XmNdefaultFontList, value, Data.Resource.Access.CG);
            }
        }

        /// XmNdeleteResponse XmCDeleteResponse unsigned char XmDESTROY CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual DeleteResponse DeleteResponse {
            get {
                return XSports.GetValue<DeleteResponse>(
                    TonNurako.Motif.ResourceId.XmNdeleteResponse, DeleteResponse.Destroy, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<DeleteResponse>(
                    TonNurako.Motif.ResourceId.XmNdeleteResponse, value, Data.Resource.Access.CSG);
            }
        }

        // ### UNKOWN TYPE
        // ### XmNinputMethod XmCInputMethod string NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string InputMethod {
            get {
                return XSports.GetAnsiString(
                    TonNurako.Motif.ResourceId.XmNinputMethod, "", Data.Resource.Access.CSG);
            }
            set {
                XSports.SetAnsiString(
                    TonNurako.Motif.ResourceId.XmNinputMethod, value, Data.Resource.Access.CSG);
            }
        }

        // ### XmNinputPolicy XmCInputPolicy XmInputPolicy XmPER_SHELL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual InputPolicy InputPolicy {
            get {
                return XSports.GetValue<InputPolicy>(
                    TonNurako.Motif.ResourceId.XmNinputPolicy, InputPolicy.PerShell, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<InputPolicy>(
                    TonNurako.Motif.ResourceId.XmNinputPolicy, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNkeyboardFocusPolicy XmCKeyboardFocusPolicy unsigned char XmEXPLICIT CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual KeyboardFocusPolicy KeyboardFocusPolicy {
            get {
                return XSports.GetValue<KeyboardFocusPolicy>(
                TonNurako.Motif.ResourceId.XmNkeyboardFocusPolicy, KeyboardFocusPolicy.Explicit, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<KeyboardFocusPolicy>(
                    TonNurako.Motif.ResourceId.XmNkeyboardFocusPolicy, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNlabelFontList XmCLabelFontList XmFontList dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SportyFontList LabelFontList {
            get {
                return XSports.GetFontList(
                    TonNurako.Motif.ResourceId.XmNlabelFontList, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetFontList(
                    TonNurako.Motif.ResourceId.XmNlabelFontList, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNlabelRenderTable XmCLabelRenderTabel XmRenderTable dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable LabelRenderTable  {
            get {
                return XSports.GetRenderTable(
                    TonNurako.Motif.ResourceId.XmNlabelRenderTable, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetRenderTable(
                    TonNurako.Motif.ResourceId.XmNlabelRenderTable, value, Data.Resource.Access.CSG);
            }
        }


        /// XmNlayoutDirection XmCLayoutDirection XmDirection XmLEFT_TO_RIGHT CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual Direction LayoutDirection {
            get {
                return XSports.GetValue<Direction>(
                TonNurako.Motif.ResourceId.XmNlayoutDirection, Direction.LeftToRight, Data.Resource.Access.CG);
            }
            set {
                XSports.SetValue<Direction>(
                    TonNurako.Motif.ResourceId.XmNlayoutDirection, value, Data.Resource.Access.CG);
            }
        }

        /// XmNmwmDecorations XmCMwmDecorations int -1 CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual MwmDecorations MwmDecorations {
            get {
                return XSports.GetValue<MwmDecorations>(
                    TonNurako.Motif.ResourceId.XmNmwmDecorations, MwmDecorations.All, Data.Resource.Access.CG);
            }
            set {
                XSports.SetValue<MwmDecorations>(
                    TonNurako.Motif.ResourceId.XmNmwmDecorations, value, Data.Resource.Access.CG);
            }
        }

        /// XmNmwmFunctions XmCMwmFunctions int -1 CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual MwmFunctions MwmFunctions {
            get {
                return XSports.GetValue(
                TonNurako.Motif.ResourceId.XmNmwmFunctions, MwmFunctions.All, Data.Resource.Access.CG);
            }
            set {
                XSports.SetValue(
                    TonNurako.Motif.ResourceId.XmNmwmFunctions, value, Data.Resource.Access.CG);
            }
        }

        /// XmNmwmInputMode XmCMwmInputMode int -1 CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual int MwmInputMode {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmwmInputMode, -1, Data.Resource.Access.CG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmwmInputMode, value, Data.Resource.Access.CG);
            }
        }

        /// XmNmwmMenu XmCMwmMenu String NULL CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual string MwmMenu {
            get {
                return XSports.GetAnsiString(
                TonNurako.Motif.ResourceId.XmNmwmMenu, "", Data.Resource.Access.CG);
            }
            set {
            XSports.SetAnsiString(
                TonNurako.Motif.ResourceId.XmNmwmMenu, value, Data.Resource.Access.CG);
            }
        }

        /// XmNpreeditType XmCPreeditType String dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string PreeditType {
            get {
                return XSports.GetAnsiString(
                TonNurako.Motif.ResourceId.XmNpreeditType, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetAnsiString(
                TonNurako.Motif.ResourceId.XmNpreeditType, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNverifyPreedit XmCVerifyPreedit Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool VerifyPreedit {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNverifyPreedit, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNverifyPreedit, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNshellUnitType XmCShellUnitType unsigned char XmPIXELS CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual UnitType ShellUnitType {
            get {
                return XSports.GetValue<UnitType>(
                TonNurako.Motif.ResourceId.XmNshellUnitType, UnitType.Pixels , Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<UnitType>(
                    TonNurako.Motif.ResourceId.XmNshellUnitType, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNtextFontList XmCTextFontList XmFontList dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SportyFontList TextFontList {
            get {
                return XSports.GetFontList(
                TonNurako.Motif.ResourceId.XmNtextFontList, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetFontList(
                TonNurako.Motif.ResourceId.XmNtextFontList, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNtextRenderTable XmCTextRenderTable XmRenderTable dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable TextRenderTable  {
            get {
                return XSports.GetRenderTable(
                    TonNurako.Motif.ResourceId.XmNtextRenderTable, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetRenderTable(
                    TonNurako.Motif.ResourceId.XmNtextRenderTable, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNtoolTipPostDelay XmCToolTipPostDelay int 5000 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ToolTipPostDelay {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNtoolTipPostDelay, 5000, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNtoolTipPostDelay, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNtoolTipPostDuration XmCToolTipPostDuration int 5000 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ToolTipPostDuration {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNtoolTipPostDuration, 5000, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNtoolTipPostDuration, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNtoolTipEnable XmCToolTipEnable Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool ToolTipEnable {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNtoolTipEnable, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNtoolTipEnable, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNunitType XmCUnitType unsigned char XmPIXELS CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual UnitType UnitType {
            get {
                return XSports.GetValue<UnitType>(
                TonNurako.Motif.ResourceId.XmNunitType, UnitType.Pixels, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<UnitType>(
                    TonNurako.Motif.ResourceId.XmNunitType, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNuseAsyncGeometry XmCUseAsyncGeometry Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool UseAsyncGeometry {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNuseAsyncGeometry, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNuseAsyncGeometry, value, Data.Resource.Access.CSG);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ

		#endregion

	}
}
