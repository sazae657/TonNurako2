//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// Paned
	/// </summary>
	public class Paned : Manager, IDefectiveWidget
	{

		public Paned() : base() {

		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		/// <summary>
		/// Paned生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreatePaned, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

		#region ﾌﾟﾛﾊﾟﾁー

		// TODO
        // ### XmNcursor XmCursor tCursor None CSG


        /// XmNmarginHeight XmCMarginHeight Dimension 3 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmarginHeight, 3, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmarginHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNmarginWidth XmCMarginWidth Dimension 3 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmarginWidth, 3, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNmarginWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNorientation XmCOrientation unsigned char XmVERTICAL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Orientation Orientation {
            get {
                return XSports.GetValue<Orientation>(
                TonNurako.Motif.ResourceId.XmNorientation, Orientation.Vertical, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<Orientation>(
                    TonNurako.Motif.ResourceId.XmNorientation, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNrefigureMode XmCBoolean Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool RefigureMode {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNrefigureMode, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNrefigureMode, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNsashHeight XmCSashHeight Dimension 8 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SashHeight {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNsashHeight, 8, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNsashHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNsashIndent XmCSashIndent Position -10 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SashIndent {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNsashIndent, -10, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNsashIndent, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNsashShadowThickness XmCShadowThickness Dimension dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SashShadowThickness {
            get {
                return XSports.GetInt(
                    TonNurako.Motif.ResourceId.XmNsashShadowThickness, 2, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNsashShadowThickness, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNsashTranslations Translations XtTranslations see below CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Xt.Translations SashTranslations {
            get {
                return XSports.GetTranslations(
                    TonNurako.Motif.ResourceId.XmNsashTranslations, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetTranslations(
                    TonNurako.Motif.ResourceId.XmNsashTranslations, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNsashWidth XmCSashWidth Dimension 10 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SashWidth {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNsashWidth, 10, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNsashWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNseparatorOn XmCSeparatorOn Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool SeparatorOn {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNseparatorOn, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNseparatorOn, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNspacing XmCSpacing Dimension 8 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Spacing {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNspacing, 8, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNspacing, value, Data.Resource.Access.CSG);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ

		#endregion

	}
}
