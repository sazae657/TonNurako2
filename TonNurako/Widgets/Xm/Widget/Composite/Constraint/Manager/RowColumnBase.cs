//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// RowColumnBase
	/// </summary>
	public abstract class RowColumnBase : Manager
	{
		public RowColumnBase()  : base()
		{

		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


		public override int Create( IWidget parent )
		{
			return base.Create (parent);
		}



		#region RowColumnﾌﾟﾛﾊﾟﾃｨ

        /*
        *** XmRowColumn Resource Set
        Name	Class	Type	Default	Access
        */

        /// XmNadjustLast XmCAdjustLast Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool AdjustLast {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNadjustLast, true);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNadjustLast, value);
            }
        }


        /// XmNadjustMargin XmCAdjustMargin Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool AdjustMargin {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNadjustMargin, true);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNadjustMargin, value);
            }
        }


        /// XmNentryAlignment XmCAlignment unsigned char XmALIGNMENT_BEGINNING CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Alignment EntryAlignment {
            get {
                return XSports.GetValue<Alignment>(TonNurako.Motif.ResourceId.XmNentryAlignment, Alignment.Beginning);
            }
            set {
                XSports.SetValue<Alignment>(TonNurako.Motif.ResourceId.XmNentryAlignment, value);
            }
        }


        /// XmNentryBorder XmCEntryBorder Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int EntryBorder {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNentryBorder, 0);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNentryBorder, value);
            }
        }

        // ### UNKOWN TYPE
        // ### XmNentryClass XmCEntryClass WidgetClass dynamic CSG

        /// XmNentryVerticalAlignment XmCVerticalAlignment unsigned char XmALIGNMENT_CENTER CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ContentsAlignment EntryVerticalAlignment {
            get {
                return XSports.GetValue<ContentsAlignment>(TonNurako.Motif.ResourceId.XmNentryVerticalAlignment, ContentsAlignment.Center);
            }
            set {
                XSports.SetValue<ContentsAlignment>(TonNurako.Motif.ResourceId.XmNentryVerticalAlignment, value);
            }
        }


        /// XmNisAligned XmCIsAligned Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool IsAligned {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNisAligned, true);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNisAligned, value);
            }
        }


        /// XmNisHomogeneous XmCIsHomogeneous Boolean dynamic CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual bool IsHomogeneous {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNisHomogeneous, false, Data.Resource.Access.CG);
            }
            internal set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNisHomogeneous, value, Data.Resource.Access.CG);
            }
        }


        /// XmNlabelString XmCXmString XmString NULL C
        [Data.Resource.SportyResource(Data.Resource.Access.C)]
        public virtual string LabelString {
            get {
                return XSports.GetString(TonNurako.Motif.ResourceId.XmNlabelString, "", Data.Resource.Access.C);
            }
            set {
                XSports.SetString(TonNurako.Motif.ResourceId.XmNlabelString, value, Data.Resource.Access.C);
            }
        }


        /// XmNmarginHeight XmCMarginHeight Dimension dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginHeight, 0);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginHeight, value);
            }
        }


        /// XmNmarginWidth XmCMarginWidth Dimension dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginWidth, 0);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginWidth, value);
            }
        }

        /// XmNmenuAccelerator XmCAccelerators String dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Accelerators MenuAccelerator {
            get {
                return XSports.GetAccelerators(TonNurako.Motif.ResourceId.XmNmenuAccelerator);
            }
            set {
                XSports.SetAccelerators(TonNurako.Motif.ResourceId.XmNmenuAccelerator, value);
            }
        }


        // get;set; Widget XmNmenuHelpWidget XmCMenuWidget Widget NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IMenuWidget MenuHelpWidget {
            get {
                 return XSports.GetWidget<IMenuWidget>(TonNurako.Motif.ResourceId.XmNmenuHelpWidget);
            }
            set {
                XSports.SetChildWidget<IMenuWidget>(TonNurako.Motif.ResourceId.XmNmenuHelpWidget, value);
            }
        }

        // get;set; Widget XmNmenuHistory XmCMenuWidget Widget NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IMenuWidget MenuHistory {
            get {
                 return XSports.GetWidget<IMenuWidget>(TonNurako.Motif.ResourceId.XmNmenuHistory);
            }
            set {
                XSports.SetChildWidget<IMenuWidget>(TonNurako.Motif.ResourceId.XmNmenuHistory, value);
            }
        }

        //  XmNmenuPost XmCMenuPost String NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IMenuWidget MenuPost {
            get {
                 return XSports.GetWidget<IMenuWidget>(TonNurako.Motif.ResourceId.XmNmenuPost);
            }
            set {
                XSports.SetChildWidget<IMenuWidget>(TonNurako.Motif.ResourceId.XmNmenuPost, value);
            }
        }


        //  XmNmnemonic XmCMnemonic KeySym NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.KeySym Mnemonic {
            get {
                return XSports.GetKeySym(TonNurako.Motif.ResourceId.XmNmnemonic);
            }
            set {
                XSports.SetKeySym(TonNurako.Motif.ResourceId.XmNmnemonic, value);
            }
        }

        // ### UNKOWN TYPE
        // ### XmNmnemonicCharSet XmCMnemonicCharSet String XmFONTLIST_DEFAULT_TAG CSG


        /// XmNnumColumns XmCNumColumns short 1 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int NumColumns {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNnumColumns, (short)0);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNnumColumns, (short)value);
            }
        }

        /// XmNorientation XmCOrientation unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Orientation Orientation {
            get {
                return XSports.GetValue<Orientation>(TonNurako.Motif.ResourceId.XmNorientation, Orientation.Horizontal);
            }
            set {
                XSports.SetValue<Orientation>(TonNurako.Motif.ResourceId.XmNorientation, value);
            }
        }


        /// XmNpacking XmCPacking unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Packing Packing {
            get {
                return XSports.GetValue<Packing>(TonNurako.Motif.ResourceId.XmNpacking, Packing.Column);
            }
            set {
                XSports.SetValue<Packing>(TonNurako.Motif.ResourceId.XmNpacking, value);
            }
        }


        /// XmNpopupEnabled XmCPopupEnabled int XmPOPUP_KEYBOARD CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual PopupType PopupEnabled {
            get {
                return XSports.GetValue<PopupType>(TonNurako.Motif.ResourceId.XmNpopupEnabled, PopupType.Keyboard);
            }
            set {
                XSports.SetValue<PopupType>(TonNurako.Motif.ResourceId.XmNpopupEnabled, value);
            }
        }


        /// XmNradioAlwaysOne XmCRadioAlwaysOne Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool RadioAlwaysOne {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNradioAlwaysOne, true);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNradioAlwaysOne, value);
            }
        }


        /// XmNradioBehavior XmCRadioBehavior Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool RadioBehavior {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNradioBehavior, false);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNradioBehavior, value);
            }
        }


        /// XmNresizeHeight XmCResizeHeight Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool ResizeHeight {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNresizeHeight, true);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNresizeHeight, value);
            }
        }


        /// XmNresizeWidth XmCResizeWidth Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool ResizeWidth {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNresizeWidth, true);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNresizeWidth, value);
            }
        }


        /// XmNrowColumnType XmCRowColumnType unsigned char XmWORK_AREA CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual RowColumnType RowColumnType {
            get {
                return XSports.GetValue<RowColumnType>(
                    TonNurako.Motif.ResourceId.XmNrowColumnType, RowColumnType.WorkArea, Data.Resource.Access.CG);
            }
            internal set {
                XSports.SetValue<RowColumnType>(TonNurako.Motif.ResourceId.XmNrowColumnType, value, Data.Resource.Access.CG);
            }
        }


        /// XmNspacing XmCSpacing Dimension dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Spacing {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNspacing, 3);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNspacing, value);
            }
        }

        // get;set; Widget XmNsubMenuId XmCMenuWidget Widget NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IMenuWidget SubMenuId {
            get {
                 return XSports.GetWidget<IMenuWidget>(TonNurako.Motif.ResourceId.XmNsubMenuId);
            }
            set {
                XSports.SetChildWidget<IMenuWidget>(TonNurako.Motif.ResourceId.XmNsubMenuId, value);
            }
        }

        /// XmNtearOffModel XmCTearOffModel unsigned char XmTEAR_OFF_DISABLED CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual TearOffModel TearOffModel {
            get {
                return XSports.GetValue<TearOffModel>(TonNurako.Motif.ResourceId.XmNtearOffModel, TearOffModel.Disabled);
            }
            set {
                XSports.SetValue<TearOffModel>(TonNurako.Motif.ResourceId.XmNtearOffModel, value);
            }
        }


        /// XmNtearOffTitle XmCTearOffTitle XmString NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string TearOffTitle {
            get {
                return XSports.GetString(TonNurako.Motif.ResourceId.XmNtearOffTitle, "");
            }
            set {
                XSports.SetString(TonNurako.Motif.ResourceId.XmNtearOffTitle, value);
            }
        }

        //  廃止
        //  XmNwhichButton XmCWhichButton unsigned int dynamic CSG
        #endregion

        #region callback


        /// XmNentryCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> EntryEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNentryCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNentryCallback ,  value );
            }
        }


        /// XmNmapCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> MapEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNmapCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNmapCallback ,  value );
            }
        }


        /// XmNtearOffMenuActivateCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> TearOffMenuActivateEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNtearOffMenuActivateCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNtearOffMenuActivateCallback ,  value );
            }
        }


        /// XmNtearOffMenuDeactivateCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> TearOffMenuDeactivateEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNtearOffMenuDeactivateCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNtearOffMenuDeactivateCallback ,  value );
            }
        }


        /// XmNunmapCallback XmCCallback XtCallbackList NULL C
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
	}
}
