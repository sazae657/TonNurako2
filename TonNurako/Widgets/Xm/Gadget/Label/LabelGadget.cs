//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// LabelGadget
    /// </summary>
    public class LabelGadget : Gadget
    {
        public LabelGadget()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		public override int Create(IWidget parent)
		{
			if( !IsAvailable )
			{
				this.CreateMotifGadget(TonNurako.Motif.CreateSymbol.XmCreateLabelGadget, parent, ToolkitResources);
			}

			return base.Create (parent);
		}


        /// XmNaccelerator XmCAccelerator String NULL CSG
        public virtual string Accelerator {
            get {
                return XSports.GetAnsiString(TonNurako.Motif.ResourceId.XmNaccelerator, "");
            }
            set {
            XSports.SetAnsiString(TonNurako.Motif.ResourceId.XmNaccelerator, value);
            }
        }


        /// XmNacceleratorText XmCAcceleratorText XmString NULL CSG
        public virtual string AcceleratorText {
            get {
                return XSports.GetString(TonNurako.Motif.ResourceId.XmNacceleratorText, "");
            }
            set {
            XSports.SetString(TonNurako.Motif.ResourceId.XmNacceleratorText, value);
            }
        }


        /// XmNalignment XmCAlignment unsigned char dynamic CSG
        public virtual Alignment Alignment {
            get {
                return XSports.GetValue<Alignment>(TonNurako.Motif.ResourceId.XmNalignment, Alignment.Beginning);
            }
            set {
                XSports.SetValue<Alignment>(TonNurako.Motif.ResourceId.XmNalignment, value);
            }
        }


        // XmNfontList XmCFontList XmFontList dynamic CSG
        // -> Coreで定義


        /// XmNlabelInsensitivePixmap XmCLabelInsensitivePixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        public virtual X11.Pixmap LabelInsensitivePixmap {
            get {
                return XSports.GetPixmap(TonNurako.Motif.ResourceId.XmNlabelInsensitivePixmap);
            }
            set {
            XSports.SetPixmap(TonNurako.Motif.ResourceId.XmNlabelInsensitivePixmap, value);
            }
        }


        /// XmNlabelPixmap XmCLabelPixmap Pixmap dynamic CSG
        public virtual X11.Pixmap LabelPixmap {
            get {
                return XSports.GetPixmap(TonNurako.Motif.ResourceId.XmNlabelPixmap);
            }
            set {
            XSports.SetPixmap(TonNurako.Motif.ResourceId.XmNlabelPixmap, value);
            }
        }


        /// XmNlabelString XmCXmString XmString dynamic CSG
        public virtual string LabelString {
            get {
                return XSports.GetString(TonNurako.Motif.ResourceId.XmNlabelString, "");
            }
            set {
            XSports.SetString(TonNurako.Motif.ResourceId.XmNlabelString, value);
            }
        }


        /// XmNlabelType XmCLabelType unsigned char XmSTRING CSG
        public virtual LabelType LabelType {
            get {
                return XSports.GetValue<LabelType>(TonNurako.Motif.ResourceId.XmNlabelType, LabelType.String);
            }
            set {
            XSports.SetValue<LabelType>(TonNurako.Motif.ResourceId.XmNlabelType, value);
            }
        }


        /// XmNmarginBottom XmCMarginBottom Dimension dynamic CSG
        public virtual int MarginBottom {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginBottom, 2);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginBottom, value);
            }
        }


        /// XmNmarginHeight XmCMarginHeight Dimension 2 CSG
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginHeight, 2);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginHeight, value);
            }
        }


        /// XmNmarginLeft XmCMarginLeft Dimension dynamic CSG
        public virtual int MarginLeft {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginLeft, 2);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginLeft, value);
            }
        }


        /// XmNmarginRight XmCMarginRight Dimension dynamic CSG
        public virtual int MarginRight {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginRight, 2);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginRight, value);
            }
        }


        /// XmNmarginTop XmCMarginTop Dimension dynamic CSG
        public virtual int MarginTop {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginTop, 2);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginTop, value);
            }
        }


        /// XmNmarginWidth XmCMarginWidth Dimension 2 CSG
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginWidth, 2);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginWidth, value);
            }
        }


        /// XmNmnemonic XmCMnemonic KeySym NULL CSG
        public virtual Data.KeySym Mnemonic {
            get {
                return XSports.GetKeySym(TonNurako.Motif.ResourceId.XmNmnemonic);
            }
            set {
            XSports.SetKeySym(TonNurako.Motif.ResourceId.XmNmnemonic, value);
            }
        }


        // ### XmNpixmapPlacement XmCPixmapPlacement unsigned int XmPIXMAP_LEFT CSG
        /*public virtual uint PixmapPlacement {
            get {
                return XSports.GetUInt(TonNurako.Motif.ResourceId.XmNpixmapPlacement, XmPIXMAP_LEFT);
            }
            set {
            XSports.SetUInt(TonNurako.Motif.ResourceId.XmNpixmapPlacement, value);
            }
        }*/


        /// XmNpixmapTextPadding XmCSpace Dimension 2 CSG
        public virtual int PixmapTextPadding {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNpixmapTextPadding, 2);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNpixmapTextPadding, value);
            }
        }


        /// XmNmnemonicCharSet XmCMnemonicCharSet String dynamic CSG
        public virtual string MnemonicCharSet {
            get {
                return XSports.GetAnsiString(TonNurako.Motif.ResourceId.XmNmnemonicCharSet, "");
            }
            set {
            XSports.SetAnsiString(TonNurako.Motif.ResourceId.XmNmnemonicCharSet, value);
            }
        }


        /// XmNrecomputeSize XmCRecomputeSize Boolean True CSG
        public virtual bool RecomputeSize {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNrecomputeSize, true);
            }
            set {
            XSports.SetBool(TonNurako.Motif.ResourceId.XmNrecomputeSize, value);
            }
        }

        /// XmNrenderTable XmCRenderTable XmRenderTable dynamic CSG
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
        public virtual StringDirection StringDirection {
            get {
                return XSports.GetValue<StringDirection>(TonNurako.Motif.ResourceId.XmNstringDirection, StringDirection.LtoR);
            }
            set {
                XSports.SetValue<StringDirection>(TonNurako.Motif.ResourceId.XmNstringDirection, value);
            }
        }


    }

}
