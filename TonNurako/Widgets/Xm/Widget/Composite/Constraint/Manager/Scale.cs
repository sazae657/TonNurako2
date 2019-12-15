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
	/// Scale
	/// </summary>
	public class Scale : Manager, IDefectiveWidget
	{

		#region 生成

		public Scale() : base() {
            ScaleEventTable =  new TnkXtEvents<Events.ScaleEventArgs>();
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		/// <summary>
		/// Scale生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateScale, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
		#endregion

		#region ﾌﾟﾛﾊﾟﾁー

        /// <summary>
        /// XmNdecimalPoints XmCDecimalPoints short 0 CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DecimalPoints {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNdecimalPoints, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNdecimalPoints, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNeditable XmCEditable Boolean True CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool Editable {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNeditable, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNeditable, value, Data.Resource.Access.CSG);
            }
        }

        // XmNfontList XmCFontList XmFontList dynamic CSG
        // -> Core

        /// <summary>
        ///  XmNhighlightOnEnter XmCHighlightOnEnter Boolean False CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool HighlightOnEnter {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNhighlightOnEnter, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNhighlightOnEnter, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNhighlightThickness XmCHighlightThickness Dimension 2 CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int HighlightThickness {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNhighlightThickness, 2, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNhighlightThickness, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNmaximum XmCMaximum int 100 CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Maximum {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNmaximum, 100, Data.Resource.Access.CSG);
            }
            set {
             XSports.SetInt(
                  TonNurako.Motif.ResourceId.XmNmaximum, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNminimum XmCMinimum int 0 CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Minimum {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNminimum, 0, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                  TonNurako.Motif.ResourceId.XmNminimum, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNorientation XmCOrientation unsigned char XmVERTICAL CSG
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// XmNprocessingDirection XmCProcessingDirection unsigned char dynamic CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ProcessingDirection ProcessingDirection {
            get {
                return XSports.GetValue<ProcessingDirection>(
                    TonNurako.Motif.ResourceId.XmNprocessingDirection, ProcessingDirection.Left, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<ProcessingDirection>(
                    TonNurako.Motif.ResourceId.XmNprocessingDirection, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNscaleHeight XmCScaleHeight Dimension 0 CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ScaleHeight {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNscaleHeight, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNscaleHeight, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNscaleMultiple XmCScaleMultiple int dynamic CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ScaleMultiple {
            get {
                return XSports.GetInt(
                    TonNurako.Motif.ResourceId.XmNscaleMultiple, 0, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNscaleMultiple, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNscaleWidth XmCScaleWidth Dimension 0 CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ScaleWidth {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNscaleWidth, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNscaleWidth, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNrenderTable XmCRenderTable XmRenderTable dynamic CSG
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// XmNshowArrows XmCShowArrows XtEnum XmNONE CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ShowArrows ShowArrows {
            get {
                return XSports.GetValue<ShowArrows>(
                TonNurako.Motif.ResourceId.XmNshowArrows, ShowArrows.None, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<ShowArrows>(
                TonNurako.Motif.ResourceId.XmNshowArrows, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNshowValue XmCShowValue XtEnum XmNONE CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ShowValuePosition ShowValue {
            get {
                return XSports.GetValue<ShowValuePosition>(
                    TonNurako.Motif.ResourceId.XmNshowValue, ShowValuePosition.None, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<ShowValuePosition>(
                    TonNurako.Motif.ResourceId.XmNshowValue, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNsliderMark XmCSliderMark XtEnum dynamic CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SliderMark SliderMark {
            get {
                return XSports.GetValue<SliderMark>(
                    TonNurako.Motif.ResourceId.XmNsliderMark, SliderMark.EtchedLine, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<SliderMark>(
                    TonNurako.Motif.ResourceId.XmNsliderMark, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNsliderVisual XmCSliderVisual XtEnum dynamic CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SliderVisual SliderVisual {
            get {
                return XSports.GetValue<SliderVisual>(
                TonNurako.Motif.ResourceId.XmNsliderVisual, SliderVisual.BackgroundColor, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<SliderVisual>(
                    TonNurako.Motif.ResourceId.XmNsliderVisual, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNslidingMode XmCSlidingMode XtEnum XmSLIDER CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SlidingMode SlidingMode {
            get {
                return XSports.GetValue<SlidingMode>(
                TonNurako.Motif.ResourceId.XmNslidingMode, SlidingMode.Slider, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<SlidingMode>(
                TonNurako.Motif.ResourceId.XmNslidingMode, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNtitleString XmCTitleString XmString NULL CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string TitleString {
            get {
                return XSports.GetString(
                TonNurako.Motif.ResourceId.XmNtitleString, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetString(
                TonNurako.Motif.ResourceId.XmNtitleString, value, Data.Resource.Access.CSG);
            }
        }

        /// <summary>
        /// XmNvalue XmCValue int dynamic CSG
        /// </summary>
        /// <returns></returns>
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Value {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNvalue, 0, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNvalue, value, Data.Resource.Access.CSG);
            }
        }

        #endregion

        #region ｲﾍﾞﾝﾄ
        TnkXtEvents<Events.ScaleEventArgs> ScaleEventTable {
            get;
        }

        /// <summary>
        /// XmNconvertCallback
        /// </summary>
        public virtual event EventHandler<Events.ScaleEventArgs> ConvertEvent
        {
            add {
                ScaleEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNconvertCallback ,  value );
            }
            remove {
                ScaleEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNconvertCallback ,  value );
            }
        }

        /// <summary>
        /// XmNdragCallback
        /// </summary>
        public virtual event EventHandler<Events.ScaleEventArgs> DragEvent
        {
            add {
                ScaleEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNdragCallback ,  value );
            }
            remove {
                ScaleEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNdragCallback ,  value );
            }
        }

        /// <summary>
        /// XmNvalueChangedCallback
        /// </summary>
        public virtual event EventHandler<Events.ScaleEventArgs> ValueChangedEvent
        {
            add {
                ScaleEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
            remove {
                ScaleEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
        }

		#endregion

	}
}
