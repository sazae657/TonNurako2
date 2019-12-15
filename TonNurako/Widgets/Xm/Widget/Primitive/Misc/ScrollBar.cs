//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    ///
    /// </summary>
    public enum ProcessingDirection{
        Top = TonNurako.Motif.Constant.XmMAX_ON_TOP,
        Bottom = TonNurako.Motif.Constant.XmMAX_ON_BOTTOM,
        Left = TonNurako.Motif.Constant.XmMAX_ON_LEFT,
        Right = TonNurako.Motif.Constant.XmMAX_ON_RIGHT,
    }

    /// <summary>
    ///
    /// </summary>
    public enum ShowArrows {
        None = TonNurako.Motif.Constant.XmNONE,
        EachSide = TonNurako.Motif.Constant.XmEACH_SIDE,
        MaxSide = TonNurako.Motif.Constant.XmMAX_SIDE,
        MinSide = TonNurako.Motif.Constant.XmMIN_SIDE,
    }

    /// <summary>
    ///
    /// </summary>
    public enum SliderMark {
        EtchedLine    = TonNurako.Motif.Constant.XmETCHED_LINE,
        None          = TonNurako.Motif.Constant.XmNONE,
        RoundMark    = TonNurako.Motif.Constant.XmROUND_MARK,
        ThumbMark    = TonNurako.Motif.Constant.XmTHUMB_MARK,

    }

    /// <summary>
    ///
    /// </summary>
    public enum SliderVisual {
        BackgroundColor = TonNurako.Motif.Constant.XmBACKGROUND_COLOR,
        ForegroundColor = TonNurako.Motif.Constant.XmFOREGROUND_COLOR,
        ShadowedBackground = TonNurako.Motif.Constant.XmSHADOWED_BACKGROUND,
        TroughColor = TonNurako.Motif.Constant.XmTROUGH_COLOR,
    }

    /// <summary>
    ///
    /// </summary>
    public enum SlidingMode {
        Slider = TonNurako.Motif.Constant.XmSLIDER,
        Thermometer = TonNurako.Motif.Constant.XmTHERMOMETER,
    }

	/// <summary>
	/// ScrollBar
	/// </summary>
	public class ScrollBar : Primitive, IDefectiveWidget
	{
		public ScrollBar() : base()
		{
            ScrollBarEventTable = new TnkXtEvents<Events.ScrollBarEventArgs>();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


		/// <summary>
		/// ScrollBar生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent)
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateScrollBar, parent, ToolkitResources);
			}
			return base.Create (parent);
		}

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNeditable XmCEditable Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool Editable {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNeditable, true);
            }
            set {
            XSports.SetBool(TonNurako.Motif.ResourceId.XmNeditable, value);
            }
        }

        /// XmNincrement XmCIncrement int 1 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Increment {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNincrement, 1);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNincrement, value);
            }
        }

        /// XmNinitialDelay XmCInitialDelay int 250 ms CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int InitialDelay {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNinitialDelay, 250);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNinitialDelay, value);
            }
        }

        /// XmNmaximum XmCMaximum int 100 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Maximum {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmaximum, 100);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNmaximum, value);
            }
        }

        /// XmNminimum XmCMinimum int 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Minimum {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNminimum, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNminimum, value);
            }
        }

        /// XmNorientation XmCOrientation unsigned char XmVERTICAL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Orientation Orientation {
            get {
                return XSports.GetValue<Orientation>(TonNurako.Motif.ResourceId.XmNorientation, Orientation.Vertical);
            }
            set {
                XSports.SetValue<Orientation>(TonNurako.Motif.ResourceId.XmNorientation, value);
            }
        }

        /// XmNpageIncrement XmCPageIncrement int 10 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int PageIncrement {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNpageIncrement, 10);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNpageIncrement, value);
            }
        }

        /// XmNprocessingDirection XmCProcessingDirection unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ProcessingDirection ProcessingDirection {
            get {
                return XSports.GetValue<ProcessingDirection>(
                        TonNurako.Motif.ResourceId.XmNprocessingDirection, ProcessingDirection.Bottom);
            }
            set {
                XSports.SetValue<ProcessingDirection>(TonNurako.Motif.ResourceId.XmNprocessingDirection, value);
            }
        }

        /// XmNrepeatDelay XmCRepeatDelay int 50 ms CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int RepeatDelay {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNrepeatDelay, 50);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNrepeatDelay, value);
            }
        }

        /// XmNshowArrows XmCShowArrows XtEnum XmEACH_SIDE CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ShowArrows ShowArrows {
            get {
                return XSports.GetValue<ShowArrows>(TonNurako.Motif.ResourceId.XmNshowArrows, ShowArrows.EachSide);
            }
            set {
                XSports.SetValue<ShowArrows>(TonNurako.Motif.ResourceId.XmNshowArrows, value);
            }
        }

        /// XmNsliderSize XmCSliderSize int dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SliderSize {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNsliderSize, 1);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNsliderSize, value);
            }
        }

        /// XmNsliderMark XmCSliderMark XtEnum dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SliderMark SliderMark {
            get {
                return XSports.GetValue<SliderMark>(TonNurako.Motif.ResourceId.XmNsliderMark, SliderMark.EtchedLine);
            }
            set {
            XSports.SetValue<SliderMark>(TonNurako.Motif.ResourceId.XmNsliderMark, value);
            }
        }

        /// XmNsliderVisual XmCSliderVisual XtEnum XmSHADOWED CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SliderVisual SliderVisual {
            get {
                return XSports.GetValue<SliderVisual>(TonNurako.Motif.ResourceId.XmNsliderVisual, SliderVisual.ShadowedBackground);
            }
            set {
            XSports.SetValue<SliderVisual>(TonNurako.Motif.ResourceId.XmNsliderVisual, value);
            }
        }

        /// XmNslidingMode XmCSlidingMode XtEnum XmSLIDER CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SlidingMode SlidingMode {
            get {
                return XSports.GetValue<SlidingMode>(TonNurako.Motif.ResourceId.XmNslidingMode, SlidingMode.Slider);
            }
            set {
            XSports.SetValue<SlidingMode>(TonNurako.Motif.ResourceId.XmNslidingMode, value);
            }
        }
        /// XmNsnapBackMultiple XmCSnapBackMultiple unsigned short MaxValue CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SnapBackMultiple {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNsnapBackMultiple, 0);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNsnapBackMultiple, value);
            }
        }

        /// XmNtroughColor XmCTroughColor Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color TroughColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNtroughColor);
            }
            set {
            XSports.SetColor(TonNurako.Motif.ResourceId.XmNtroughColor, value);
            }
        }

        /// XmNvalue XmCValue int dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Value {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNvalue, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNvalue, value);
            }
        }

        #endregion

        #region ｲﾍﾞﾝﾄ

        TnkXtEvents<Events.ScrollBarEventArgs> ScrollBarEventTable {
            get;
        }

        /// XmNdecrementCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> DecrementEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNdecrementCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNdecrementCallback ,  value );
            }
        }

        /// XmNdragCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> DragEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNdragCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNdragCallback ,  value );
            }
        }

        /// XmNincrementCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> IncrementEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNincrementCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNincrementCallback ,  value );
            }
        }

        /// XmNpageDecrementCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> PageDecrementEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNpageDecrementCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNpageDecrementCallback ,  value );
            }
        }

        /// XmNpageIncrementCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> PageIncrementEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNpageIncrementCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNpageIncrementCallback ,  value );
            }
        }

        /// XmNtoBottomCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> ToBottomEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNtoBottomCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNtoBottomCallback ,  value );
            }
        }

        /// XmNtoTopCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> ToTopEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNtoTopCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNtoTopCallback ,  value );
            }
        }

        /// XmNvalueChangedCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ScrollBarEventArgs> ValueChangedEvent
        {
            add {
                ScrollBarEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
            remove {
                ScrollBarEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
        }

		#endregion

	}
}
