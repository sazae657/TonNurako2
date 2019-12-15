//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// BulletinBoard
	/// </summary>
	public class BulletinBoard : Manager
    {
		public BulletinBoard() : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		/// <summary>
		/// 子ｳｲｼﾞｪｯﾄの作成
		/// </summary>
		/// <param name="parent">親ｳｲｼﾞｪｯﾄ</param>
		/// <returns></returns>
		public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateBulletinBoard, parent, ToolkitResources);
            }

			return base.Create( parent );
		}

		#region ﾌﾟﾛﾊﾟﾃｨ

        /*
        XmBulletinBoard Resource Set
        Name	Class	Type	Default	Access
        */

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool AllowOverlap {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNallowOverlap, true);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNallowOverlap, value);
            }
        }

        /// XmNautoUnmanage XmCAutoUnmanage Boolean True CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual bool AutoUnmanage {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNautoUnmanage, true, Data.Resource.Access.CG);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNautoUnmanage, value, Data.Resource.Access.CG);
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

        /// XmNdefaultPosition XmCDefaultPosition Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool DefaultPosition {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNdefaultPosition, true);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNdefaultPosition, value);
            }
        }


        /// XmNdialogStyle XmCDialogStyle unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual DialogStyle DialogStyle {
            get {
                return XSports.GetValue<DialogStyle>(TonNurako.Motif.ResourceId.XmNdialogStyle, DialogStyle.ApplicationModal);
            }
            set {
                XSports.SetValue<DialogStyle>(TonNurako.Motif.ResourceId.XmNdialogStyle, value);
            }
        }


        /// XmNdialogTitle XmCDialogTitle XmString NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string DialogTitle {
            get {
                return XSports.GetString(TonNurako.Motif.ResourceId.XmNdialogTitle, "");
            }
            set {
                XSports.SetString(TonNurako.Motif.ResourceId.XmNdialogTitle, value);
            }
        }

        /// XmNlabelRenderTable XmCLabelRenderTable XmRenderTable dynamic CSG
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

        /// XmNmarginHeight XmCMarginHeight Dimension 10 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginHeight, 10);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginHeight, value);
            }
        }


        /// XmNmarginWidth XmCMarginWidth Dimension 10 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginWidth, 10);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginWidth, value);
            }
        }


        /// XmNnoResize XmCNoResize Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool NoResize {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNnoResize, false);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNnoResize, value);
            }
        }


        /// XmNresizePolicy XmCResizePolicy unsigned char XmRESIZE_ANY CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ResizePolicy ResizePolicy {
            get {
                return XSports.GetValue<ResizePolicy>(TonNurako.Motif.ResourceId.XmNresizePolicy, ResizePolicy.Any);
            }
            set {
                XSports.SetValue<ResizePolicy>(TonNurako.Motif.ResourceId.XmNresizePolicy, value);
            }
        }


        /// XmNshadowType XmCShadowType unsigned char XmSHADOW_OUT CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ShadowType ShadowType {
            get {
                return XSports.GetValue<ShadowType>(TonNurako.Motif.ResourceId.XmNshadowType, ShadowType.Out);
            }
            set {
                XSports.SetValue<ShadowType>(TonNurako.Motif.ResourceId.XmNshadowType, value);
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

        /// XmNcancelButton XmCWidget Widget Cancel button SG
        [Data.Resource.SportyResource(Data.Resource.Access.SG)]
        public virtual IWidget CancelButton {
            get {
                return XSports.GetWidget<IWidget>(
                    TonNurako.Motif.ResourceId.XmNcancelButton, Data.Resource.Access.SG);
            }
            set {
            XSports.SetWidget<IWidget>(
                TonNurako.Motif.ResourceId.XmNcancelButton, value, Data.Resource.Access.SG);
            }
        }

        /// XmNdefaultButton XmCWidget Widget dynamic SG
        [Data.Resource.SportyResource(Data.Resource.Access.SG)]
        public virtual IWidget DefaultButton {
            get {
                return XSports.GetWidget<IWidget>(
                    TonNurako.Motif.ResourceId.XmNdefaultButton, Data.Resource.Access.SG);
            }
            set {
            XSports.SetWidget<IWidget>(
                TonNurako.Motif.ResourceId.XmNdefaultButton, value, Data.Resource.Access.SG);
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

        /// XmNtextTranslations XmCTranslations XtTranslations NULL C
        [Data.Resource.SportyResource(Data.Resource.Access.C)]
        public virtual Xt.Translations TextTranslations {
            set {
                XSports.SetTranslations(
                    TonNurako.Motif.ResourceId.XmNtextTranslations, value, Data.Resource.Access.C);
            }
        }

        #endregion

        #region ｺーﾙﾊﾞｯｸ


        /// XmNmapCallback	XmCCallback	XtCallbackList	NULL	C
		public virtual event EventHandler<Events.AnyEventArgs> MapEvent
		{
			add {
				MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNmapCallback ,  value );
			}
			remove {
				MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNmapCallback ,  value );
			}
		}

        /// XmNfocusCallback	XmCCallback	XtCallbackList	NULL	C
		public virtual event EventHandler<Events.AnyEventArgs> FocusEvent
		{
			add {
				MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNfocusCallback ,  value );
			}
			remove {
				MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNfocusCallback ,  value );
			}
		}

        /// XmNunmapCallback	XmCCallback	XtCallbackList	NULL	C
		public virtual event EventHandler<Events.AnyEventArgs> UnmapEvent
		{
			add {
				MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNunmapCallback ,  value );
			}
			remove {
				MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNunmapCallback ,  value );
			}
		}

        #endregion




// #STAB


    }
}
