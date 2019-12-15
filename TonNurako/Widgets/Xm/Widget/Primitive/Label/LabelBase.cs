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
	/// LabelBase
	/// </summary>
	public abstract class LabelBase : Primitive
	{

		public LabelBase()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


		public override int Create(IWidget parent)
		{
			return base.Create (parent);
		}


		#region Labelﾌﾟﾛﾊﾟﾃｨ

        /// XmNaccelerator XmCAccelerator String NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string Accelerator {
            get {
                return XSports.GetAnsiString(
                TonNurako.Motif.ResourceId.XmNaccelerator, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetAnsiString(
                TonNurako.Motif.ResourceId.XmNaccelerator, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNacceleratorText XmCAcceleratorText XmString NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string AcceleratorText {
            get {
                return XSports.GetString(
                TonNurako.Motif.ResourceId.XmNacceleratorText, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetString(
                TonNurako.Motif.ResourceId.XmNacceleratorText, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNalignment XmCAlignment unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Alignment Alignment {
            get {
                return XSports.GetValue<Alignment>(
                TonNurako.Motif.ResourceId.XmNalignment, Alignment.Beginning, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<Alignment>(
                    TonNurako.Motif.ResourceId.XmNalignment, value, Data.Resource.Access.CSG);
            }
        }

        // XmNfontList XmCFontList XmFontList dynamic CSG
        // -> Coreで定義

        /// XmNlabelInsensitivePixmap XmCLabelInsensitivePixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap LabelInsensitivePixmap {
            get {
                return XSports.GetPixmap(
                    TonNurako.Motif.ResourceId.XmNlabelInsensitivePixmap, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetPixmap(
                    TonNurako.Motif.ResourceId.XmNlabelInsensitivePixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNlabelPixmap XmCLabelPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap LabelPixmap {
            get {
                return XSports.GetPixmap(
                    TonNurako.Motif.ResourceId.XmNlabelPixmap, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetPixmap(
                    TonNurako.Motif.ResourceId.XmNlabelPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNlabelString XmCXmString XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string LabelString {
            get {
                return XSports.GetString(
                TonNurako.Motif.ResourceId.XmNlabelString, "", Data.Resource.Access.CSG);
            }
            set {
                XSports.SetString(
                    TonNurako.Motif.ResourceId.XmNlabelString, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNlabelType XmCLabelType unsigned char XmSTRING CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual LabelType LabelType {
            get {
                return XSports.GetValue<LabelType>(
                TonNurako.Motif.ResourceId.XmNlabelType, LabelType.String, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<LabelType>(
                    TonNurako.Motif.ResourceId.XmNlabelType, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginBottom XmCMarginBottom Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginBottom {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmarginBottom, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmarginBottom, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginHeight XmCMarginHeight Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmarginHeight, 2, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmarginHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginLeft XmCMarginLeft Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginLeft {
            get {
                return XSports.GetInt(
                    TonNurako.Motif.ResourceId.XmNmarginLeft, 0, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNmarginLeft, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginRight XmCMarginRight Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginRight {
            get {
                return XSports.GetInt(
                    TonNurako.Motif.ResourceId.XmNmarginRight, 0, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNmarginRight, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginTop XmCMarginTop Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginTop {
            get {
                return XSports.GetInt(
                    TonNurako.Motif.ResourceId.XmNmarginTop, 0, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNmarginTop, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginWidth XmCMarginWidth Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(
                    TonNurako.Motif.ResourceId.XmNmarginWidth, 2, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNmarginWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmnemonic XmCMnemonic KeySym NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.KeySym Mnemonic {
            get {
                return XSports.GetKeySym(
                    TonNurako.Motif.ResourceId.XmNmnemonic, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetKeySym(
                    TonNurako.Motif.ResourceId.XmNmnemonic, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmnemonicCharSet XmCMnemonicCharSet String XmFONTLIST_DEFAULT_TAG CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string MnemonicCharSet {
            get {
                return XSports.GetAnsiString(
                    TonNurako.Motif.ResourceId.XmNmnemonicCharSet, "", Data.Resource.Access.CSG);
            }
            set {
                XSports.SetAnsiString(
                    TonNurako.Motif.ResourceId.XmNmnemonicCharSet, value, Data.Resource.Access.CSG);
            }
        }
        /*
        /// XmNpixmapPlacement XmCPixmapPlacement unsigned int XmPIXMAP_LEFT CSG
        public virtual uint PixmapPlacement {
            get {
                return XSports.GetUInt(
                TonNurako.Motif.ResourceId.XmNpixmapPlacement, XmPIXMAP_LEFT, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetUInt(
                TonNurako.Motif.ResourceId.XmNpixmapPlacement, value, Data.Resource.Access.CSG);
            }
        }*/

        /// XmNpixmapTextPadding XmCSpace Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int PixmapTextPadding {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNpixmapTextPadding, 2, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNpixmapTextPadding, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNrecomputeSize XmCRecomputeSize Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool RecomputeSize {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNrecomputeSize, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNrecomputeSize, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNrenderTable XmCRenderTable XmRenderTable dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.RenderTable RenderTable {
            get {
                return XSports.GetRenderTable(
                    TonNurako.Motif.ResourceId.XmNrenderTable, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetRenderTable(
                    TonNurako.Motif.ResourceId.XmNrenderTable, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNstringDirection XmCStringDirection XmStringDirection dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual StringDirection StringDirection {
            get {
                return XSports.GetValue<StringDirection>(
                    TonNurako.Motif.ResourceId.XmNstringDirection, StringDirection.Default, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<StringDirection>(
                    TonNurako.Motif.ResourceId.XmNstringDirection, value, Data.Resource.Access.CSG);
            }
        }

		#endregion

	}
}
