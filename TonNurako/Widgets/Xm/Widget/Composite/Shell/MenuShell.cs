//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// MenuShell
	/// </summary>
	public class MenuShell : Shell, IDefectiveWidget
	{
		public MenuShell() : base() {
            throw new System.NotImplementedException();
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateMenuShell, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNbuttonFontList XmCButtonFontList XmFontList dynamic CSG
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

        /// XmNbuttonRenderTable	XmCButtonRenderTable	XmRenderTable	dynamic	CSG
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

        /// XmNlabelRenderTable XmCLabelRenderTable XmRenderTable NULL CSG
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

        /// XmNanimate XmCAnimate Boolean False CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual bool Animate {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNanimate, false, Data.Resource.Access.CG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNanimate, value, Data.Resource.Access.CG);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ

		#endregion

	}
}
