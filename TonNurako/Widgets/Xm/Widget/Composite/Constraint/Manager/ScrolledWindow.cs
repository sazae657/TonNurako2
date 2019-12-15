//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// ScrolledWindow
	/// </summary>
	public class ScrolledWindow : Manager
	{
        Form clipWindow;

		public ScrolledWindow()  : base()
		{
            clipWindow = null;
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		/// <summary>
		/// ScrolledWindow作成
		/// </summary>
		/// <param name="parent">親ｳｲｼﾞｪｯﾄ</param>
		/// <returns></returns>
		public override int Create( IWidget parent )
		{
			if( !IsAvailable )
			{
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateScrolledWindow, parent, ToolkitResources);
			}
            //IWidget cw = XSports.GetWidget<IWidget>(TonNurako.Motif.ResourceId.XmNclipWindow, Data.Resource.Access.G);
            IntPtr cw = this.ToolkitResources.GetPointerValue(TonNurako.Motif.ResourceId.XmNclipWindow);
            if (IntPtr.Zero != cw) {
                clipWindow = new Form();
                clipWindow.WrapExistingWidget(cw);
                this.Children.Add(clipWindow);
            }

			return base.Create (parent);
		}


        /// XmNautoDragModel XmCAutoDragModel XtEnum XmAUTO_DRAG_ENABLED CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual DragModel AutoDragModel {
            get {
                return XSports.GetValue<DragModel>(TonNurako.Motif.ResourceId.XmNautoDragModel, DragModel.Enabled);
            }
            set {
                XSports.SetValue<DragModel>(TonNurako.Motif.ResourceId.XmNautoDragModel, value);
            }
        }


        /// XmNclipWindow XmCClipWindow Widget dynamic G
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IChild ClipWindow {
            get {
                return XSports.GetWidget<IChild>(TonNurako.Motif.ResourceId.XmNclipWindow, Data.Resource.Access.G);
            }

        }


        /// XmNhorizontalScrollBar XmCHorizontalScrollBar Widget dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IWidget HorizontalScrollBar {
            get {
                return XSports.GetWidget<IWidget>(TonNurako.Motif.ResourceId.XmNhorizontalScrollBar);
            }
            set {
            XSports.SetWidget<IWidget>(TonNurako.Motif.ResourceId.XmNhorizontalScrollBar, value);
            }
        }


        /// XmNscrollBarDisplayPolicy XmCScrollBarDisplayPolicy unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ScrollBarDisplayPolicy ScrollBarDisplayPolicy {
            get {
                return XSports.GetValue<ScrollBarDisplayPolicy>(
                    TonNurako.Motif.ResourceId.XmNscrollBarDisplayPolicy, ScrollBarDisplayPolicy.AsNeeded);
            }
            set {
                XSports.GetValue<ScrollBarDisplayPolicy>(TonNurako.Motif.ResourceId.XmNscrollBarDisplayPolicy, value);
            }
        }


        /// XmNscrollBarPlacement XmCScrollBarPlacement unsigned char XmBOTTOM_RIGHT CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ScrollBarPlacement ScrollBarPlacement {
            get {
                return XSports.GetValue<ScrollBarPlacement>(TonNurako.Motif.ResourceId.XmNscrollBarPlacement, ScrollBarPlacement.BottomRight);
            }
            set {
            XSports.SetValue<ScrollBarPlacement>(TonNurako.Motif.ResourceId.XmNscrollBarPlacement, value);
            }
        }


        /// XmNscrolledWindowMarginHeight XmCScrolledWindowMarginHeight Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ScrolledWindowMarginHeight {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNscrolledWindowMarginHeight, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNscrolledWindowMarginHeight, value);
            }
        }


        /// XmNscrolledWindowMarginWidth XmCScrolledWindowMarginWidth Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ScrolledWindowMarginWidth {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNscrolledWindowMarginWidth, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNscrolledWindowMarginWidth, value);
            }
        }


        /// XmNscrollingPolicy XmCScrollingPolicy unsigned char XmAPPLICATION_DEFINED CG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ScrollingPolicy ScrollingPolicy {
            get {
                return XSports.GetValue<ScrollingPolicy>(
                    TonNurako.Motif.ResourceId.XmNscrollingPolicy, ScrollingPolicy.ApplicationDefined, Data.Resource.Access.CG);
            }
            set {
            XSports.SetValue<ScrollingPolicy>(TonNurako.Motif.ResourceId.XmNscrollingPolicy, value, Data.Resource.Access.CG);
            }
        }


        /// XmNspacing XmCSpacing Dimension 4 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Spacing {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNspacing, 4);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNspacing, value);
            }
        }


        /// XmNverticalScrollBar XmCVerticalScrollBar Widget dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IWidget VerticalScrollBar {
            get {
                return XSports.GetWidget<IWidget>(TonNurako.Motif.ResourceId.XmNverticalScrollBar);
            }
            set {
            XSports.SetWidget<IWidget>(TonNurako.Motif.ResourceId.XmNverticalScrollBar, value);
            }
        }


        /// XmNvisualPolicy XmCVisualPolicy unsigned char dynamic G
        [Data.Resource.SportyResource(Data.Resource.Access.G)]
        public virtual VisualPolicy VisualPolicy {
            get {
                return XSports.GetValue<VisualPolicy>(
                    TonNurako.Motif.ResourceId.XmNvisualPolicy, VisualPolicy.Static, Data.Resource.Access.G);
            }
        }


        /// XmNworkWindow XmCWorkWindow Widget NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IChild WorkWindow {
            get {
                return XSports.GetWidget<IChild>(TonNurako.Motif.ResourceId.XmNworkWindow);
            }
            set {
                XSports.SetWidget<IChild>(TonNurako.Motif.ResourceId.XmNworkWindow, value);
            }
        }


        /// XmNscrolledWindowChildType XmCScrolledWindowChildType unsigned char RESOURCE_DEFAULT CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ScrolledWindowChildType ScrolledWindowChildType {
            get {
                return XSports.GetValue<ScrolledWindowChildType>(
                    TonNurako.Motif.ResourceId.XmNscrolledWindowChildType, ScrolledWindowChildType.GenericChild);
            }
            set {
                XSports.GetValue<ScrolledWindowChildType>(TonNurako.Motif.ResourceId.XmNscrolledWindowChildType, value);
            }
        }


        /// XmNtraverseObscuredCallback XmCCallback XtCallbackList NULL CSG
        public virtual event EventHandler<Events.AnyEventArgs> TraverseObscuredEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNtraverseObscuredCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNtraverseObscuredCallback ,  value );
            }
        }


	}
}
