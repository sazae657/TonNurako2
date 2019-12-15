using System;
using TonNurako.Data;
using TonNurako.Events;
using TonNurako.Native;

namespace TonNurako.Widgets.Xm {

	/// <summary>
	/// 最下層ｳｲｼﾞｪｯﾄの基底ｸﾗｽ(ﾌﾟﾛﾊﾟﾁー)
	/// </summary>
	public partial class ApplicationShell : ShellBase
	{
        #region 見たら卒倒するよ
        private static readonly int XtUnspecifiedShellInt = 0;
        // ### どうするか考え中

        // ### XmNinputMethod XmCInputMethod string NULL CSG
        // ### XmNwindowGroup XmCWindowGroup Window dynamic CSG

        // ### XmNiconWindow XmCIconWindow Window NULL CSG
        // XmNscreen XmCScreen Screen * dynamic CG
        // XmNvisual XmCVisual Visual * CopyFromParent CSG
        // XmNchildren XmCReadOnly WidgetList NULL G
        // XmNinsertPosition XmCInsertPosition XtOrderProc NULL CSG
        // XmNcreatePopupChildProc XmCCreatePopupChildProc XtCreatePopupChildProc NULL CSG
        // ### XmNtitleEncoding XmCTitleEncoding Atom dynamic CSG ←たぶんやらない(Titleで吸収)
        // ## XmNiconNameEncoding XmCIconNameEncoding	Atom	dynamic	CSG ←たぶんやらない(IconNameで吸収)

        internal void SetCompoundStr(
            TonNurako.Motif.ResourceId idStr, TonNurako.Motif.ResourceId idEnc, string text) {

            var ct = X11.XTextProperty.Create(this, text);
            ToolkitResources.RetainCustomObject(ct);
            ToolkitResources.Begin();
            ToolkitResources.Add(idEnc, ct.Encoding);
            ToolkitResources.Add(idStr, ct.Handle);
            ToolkitResources.Commit(true);
        }

        #region VendorShell

        /// <summary>
        /// XmNaudibleWarning
        /// </summary>
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

        /// <summary>
        /// XmNbuttonFontList
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SportyFontList ButtonFontList {
            get {
                return XSports.GetFontList(
                TonNurako.Motif.ResourceId.XmNbuttonFontList, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetFontList(
                TonNurako.Motif.ResourceId.XmNbuttonFontList, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbuttonRenderTable
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable ButtonRenderTable {
            get {
                return XSports.GetRenderTable(
                TonNurako.Motif.ResourceId.XmNbuttonRenderTable, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetRenderTable(
                TonNurako.Motif.ResourceId.XmNbuttonRenderTable, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNdefaultFontList
        /// </summary>
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

        /// <summary>
        /// XmNdeleteResponse
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Xm.DeleteResponse DeleteResponse {
            get {
                return XSports.GetValue<Xm.DeleteResponse>(
                TonNurako.Motif.ResourceId.XmNdeleteResponse, Xm.DeleteResponse.Destroy, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<Xm.DeleteResponse>(
                TonNurako.Motif.ResourceId.XmNdeleteResponse, value, Data.Resource.Access.CSG);
            }
        }



        /// <summary>
        /// XmNinputPolicy
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Xm.InputPolicy InputPolicy {
            get {
                return XSports.GetValue<Xm.InputPolicy>(
                TonNurako.Motif.ResourceId.XmNinputPolicy, Xm.InputPolicy.PerShell, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<Xm.InputPolicy>(
                TonNurako.Motif.ResourceId.XmNinputPolicy, value, Data.Resource.Access.CSG);
            }
        }


        /// <summary>
        /// XmNkeyboardFocusPolicy
        /// </summary>
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

        /// <summary>
        /// XmNlabelFontList
        /// </summary>
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

        /// <summary>
        /// XmNlabelRenderTable
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable LabelRenderTable {
            get {
                return XSports.GetRenderTable(
                TonNurako.Motif.ResourceId.XmNlabelRenderTable, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetRenderTable(
                TonNurako.Motif.ResourceId.XmNlabelRenderTable, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNlayoutDirection
        /// </summary>
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

        /// <summary>
        /// XmNmwmDecorations
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual int MwmDecorations {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmwmDecorations, -1, Data.Resource.Access.CG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmwmDecorations, value, Data.Resource.Access.CG);
            }
        }

        /// <summary>
        /// XmNmwmFunctions
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual int MwmFunctions {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmwmFunctions, -1, Data.Resource.Access.CG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmwmFunctions, value, Data.Resource.Access.CG);
            }
        }

        /// <summary>
        /// XmNmwmInputMode
        /// </summary>
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

        /// <summary>
        /// XmNmwmMenu
        /// </summary>
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

        /// <summary>
        /// XmNpreeditType
        /// </summary>
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

        /// <summary>
        /// XmNverifyPreedit
        /// </summary>
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

        /// <summary>
        /// XmNshellUnitType
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual UnitType ShellUnitType {
            get {
                return XSports.GetValue<UnitType>(
                TonNurako.Motif.ResourceId.XmNshellUnitType, UnitType.Pixels, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<UnitType>(
                TonNurako.Motif.ResourceId.XmNshellUnitType, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNtextFontList
        /// </summary>
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

        /// <summary>
        /// XmNtextRenderTable
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable TextRenderTable {
            get {
                return XSports.GetRenderTable(
                TonNurako.Motif.ResourceId.XmNtextRenderTable, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetRenderTable(
                TonNurako.Motif.ResourceId.XmNtextRenderTable, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNtoolTipPostDelay
        /// </summary>
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

        /// <summary>
        /// XmNtoolTipPostDuration
        /// </summary>
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

        /// <summary>
        /// XmNtoolTipEnable
        /// </summary>
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

        /// <summary>
        /// XmNunitType
        /// </summary>
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

        /// <summary>
        /// XmNuseAsyncGeometry
        /// </summary>
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

        #region shell

        /// <summary>
        /// XmNbaseHeight
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int BaseHeight {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNbaseHeight, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNbaseHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbaseWidth
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int BaseWidth {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNbaseWidth, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNbaseWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNheightInc
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int HeightInc {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNheightInc, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNheightInc, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNiconMask
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap IconMask {
            get {
                return XSports.GetPixmap(
                TonNurako.Motif.ResourceId.XmNiconMask, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                TonNurako.Motif.ResourceId.XmNiconMask, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNiconPixmap
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap IconPixmap {
            get {
                return XSports.GetPixmap(
                TonNurako.Motif.ResourceId.XmNiconPixmap, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                TonNurako.Motif.ResourceId.XmNiconPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNiconX
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int IconX {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNiconX, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNiconX, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNiconY
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int IconY {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNiconY, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNiconY, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNiconic
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool Iconic {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNiconic, false, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetBool(
                    TonNurako.Motif.ResourceId.XmNiconic, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNiconName
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string IconName {
            set {
                this.SetCompoundStr(
                    TonNurako.Motif.ResourceId.XmNiconName, TonNurako.Motif.ResourceId.XmNiconNameEncoding, value);
            }
            get {
                return XSports.GetAnsiString(
                	TonNurako.Motif.ResourceId.XmNiconName, "", Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNinitialState
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual WindowState InitialState {
            get {
                return XSports.GetValue<WindowState>(
                TonNurako.Motif.ResourceId.XmNinitialState, WindowState.Normal, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<WindowState>(
                TonNurako.Motif.ResourceId.XmNinitialState, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNinput
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool Input {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNinput, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNinput, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNmaxAspectX
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MaxAspectX {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmaxAspectX, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmaxAspectX, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNmaxAspectY
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MaxAspectY {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmaxAspectY, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmaxAspectY, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNmaxHeight
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MaxHeight {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmaxHeight, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmaxHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNmaxWidth
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MaxWidth {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmaxWidth, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmaxWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNminAspectX
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MinAspectX {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNminAspectX, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNminAspectX, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNminAspectY
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MinAspectY {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNminAspectY, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNminAspectY, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNminHeight
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MinHeight {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNminHeight, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNminHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNminWidth
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MinWidth {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNminWidth, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNminWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNtitle
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string Title {
            set {
                this.SetCompoundStr(
                    TonNurako.Motif.ResourceId.XmNtitle, TonNurako.Motif.ResourceId.XmNtitleEncoding, value);
            }
            get {
                return XSports.GetAnsiString(
                	TonNurako.Motif.ResourceId.XmNtitle, "", Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNtransient
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool Transient {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNtransient, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNtransient, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNwaitForWm
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool WaitForWm {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNwaitForWm, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNwaitForWm, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNwidthInc
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int WidthInc {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNwidthInc, XtUnspecifiedShellInt, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNwidthInc, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNwinGravity
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int InGravity {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNwinGravity, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNwinGravity, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNwmTimeout
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int WmTimeout {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNwmTimeout, 5000, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNwmTimeout, value, Data.Resource.Access.CSG);
            }
        }


        #endregion

        #region tab

        /// <summary>
        /// XmNallowShellResize
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual bool AllowShellResize {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNallowShellResize, false, Data.Resource.Access.CG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNallowShellResize, value, Data.Resource.Access.CG);
            }
        }

        /// <summary>
        /// XmNgeometry
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string Geometry {
            get {
                return XSports.GetAnsiString(
                TonNurako.Motif.ResourceId.XmNgeometry, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetAnsiString(
                TonNurako.Motif.ResourceId.XmNgeometry, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNoverrideRedirect
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool OverrideRedirect {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNoverrideRedirect, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNoverrideRedirect, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNsaveUnder
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool SaveUnder {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNsaveUnder, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNsaveUnder, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNnumChildren
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.G)]
        public virtual int NumChildren {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNnumChildren, 0, Data.Resource.Access.G);
            }
        }


        #endregion

        #region Core
        /// <summary>
        /// XmNaccelerators
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Accelerators Accelerators {
            get {
                return XSports.GetAccelerators(
                TonNurako.Motif.ResourceId.XmNaccelerators,  Data.Resource.Access.CSG);
            }
            set {
            XSports.SetAccelerators(
                TonNurako.Motif.ResourceId.XmNaccelerators, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNancestorSensitive
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.G)]
        public virtual bool AncestorSensitive {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNancestorSensitive, false, Data.Resource.Access.G);
            }
        }

        /// <summary>
        /// XmNbackground
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color Background {
            get {
                return XSports.GetColor(
                TonNurako.Motif.ResourceId.XmNbackground, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetColor(
                TonNurako.Motif.ResourceId.XmNbackground, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNbackgroundPixmap
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap BackgroundPixmap {
            get {
                return XSports.GetPixmap(
                TonNurako.Motif.ResourceId.XmNbackgroundPixmap, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                TonNurako.Motif.ResourceId.XmNbackgroundPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNborderColor
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color BorderColor {
            get {
                return XSports.GetColor(
                TonNurako.Motif.ResourceId.XmNborderColor, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetColor(
                TonNurako.Motif.ResourceId.XmNborderColor, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNborderPixmap
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap BorderPixmap {
            get {
                return XSports.GetPixmap(
                TonNurako.Motif.ResourceId.XmNborderPixmap, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                TonNurako.Motif.ResourceId.XmNborderPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNborderWidth
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int BorderWidth {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNborderWidth, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNborderWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNcolormap
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual int Colormap {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNcolormap, 0, Data.Resource.Access.CG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNcolormap, value, Data.Resource.Access.CG);
            }
        }

        /// <summary>
        /// XmNdepth
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual int Depth {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNdepth, 0, Data.Resource.Access.CG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNdepth, value, Data.Resource.Access.CG);
            }
        }

        /// <summary>
        /// XmNheight
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Height {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNheight, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNheight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNinitialResourcesPersistent
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.C)]
        public virtual bool InitialResourcesPersistent {

            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNinitialResourcesPersistent, value, Data.Resource.Access.C);
            }
        }

        /// <summary>
        /// XmNmappedWhenManaged
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool MappedWhenManaged {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNmappedWhenManaged, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNmappedWhenManaged, value, Data.Resource.Access.CSG);
            }
        }


        /// <summary>
        /// XmNsensitive
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool Sensitive {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNsensitive, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNsensitive, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNtranslations
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Xt.Translations Translations {
            get {
                return XSports.GetTranslations(
                TonNurako.Motif.ResourceId.XmNtranslations, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetTranslations(
                TonNurako.Motif.ResourceId.XmNtranslations, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNwidth
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Width {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNwidth, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNwidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNx
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int X {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNx, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNx, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNy
        /// </summary>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Y {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNy, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNy, value, Data.Resource.Access.CSG);
            }
        }

        #endregion

        #region ｴﾍﾞﾝﾄ

        /// <summary>
        /// XmNpopdownCallback
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> PopdownEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNpopdownCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNpopdownCallback ,  value );
            }
        }

        /// <summary>
        /// XmNpopupCallback
        /// </summary>
        public virtual event EventHandler<Events.AnyEventArgs> PopupEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNpopupCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNpopupCallback ,  value );
            }
        }


        /// <summary>
        /// XmNdestroyCallback
        /// </summary>
        public override event EventHandler<Events.TnkEventArgs> DestroyEvent
        {
			add {
				if (! UIeventTable.HasHandler(TonNuraEventId.Destroyed)) {
					CallbackQueue.AddXtCallback( TonNurako.Motif.EventId.XmNdestroyCallback,
                    (w, client, call ) => {
				        //Destroyedｲﾍﾞﾝﾄが通知可能な場合は通知
			             UIeventTable.CallHandler(TonNuraEventId.Destroyed, this);
                    });
				}
				base.DestroyEvent += value;
			}
			remove {
				base.DestroyEvent -= value;
			}
        }
        #endregion

        #endregion
    }
}
