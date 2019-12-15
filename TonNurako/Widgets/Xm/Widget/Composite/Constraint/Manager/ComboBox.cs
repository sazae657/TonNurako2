//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Data;
using TonNurako.Native;

namespace TonNurako.Widgets.Xm
{


	/// <summary>
	/// ComboBox
	/// </summary>
	public class ComboBox : Manager, IDefectiveWidget
	{

		#region 生成
		public ComboBox() : base()
		{
            ComboBoxEventTable = new TnkXtEvents<Events.ComboBoxEventArgs>();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		/// <summary>
		/// ComboBox生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent)
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateComboBox, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
		#endregion

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNarrowSize XmCArrowSize Dimension dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ArrowSize {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNarrowSize, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNarrowSize, value);
            }
        }

        /// XmNarrowSpacing XmCArrowSpacing Dimension dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ArrowSpacing {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNarrowSpacing, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNarrowSpacing, value);
            }
        }

        /// XmNcolumns XmCColumn short dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Columns {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNcolumns, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNcolumns, value);
            }
        }

        /// XmNcomboBoxType XmCComboBoxType unsigned char XmCOMBO_BOX CG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ComboBoxType ComboBoxType {
            get {
                return XSports.GetValue<ComboBoxType>(TonNurako.Motif.ResourceId.XmNcomboBoxType, ComboBoxType.ComboBox);
            }
            set {
            XSports.SetValue<ComboBoxType>(TonNurako.Motif.ResourceId.XmNcomboBoxType, value);
            }
        }
        // XmNfontList XmCFontList XmFontList NULL CSG
        // -> Coreで定義

        /// XmNhighlightThickness XmCHighlightThickness Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int HighlightThickness {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNhighlightThickness, 2);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNhighlightThickness, value);
            }
        }

        /// XmNitemCount XmCItemCount int dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int ItemCount {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNitemCount, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNitemCount, value);
            }
        }

        /// XmNitems XmCItems XmStringTable dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public CompoundStringTable Items {
            get {
                return XSports.GetStringTable(TonNurako.Motif.ResourceId.XmNitems, ItemCount, true);
            }
            set {
                XSports.SetStringTable(TonNurako.Motif.ResourceId.XmNitems, value);
            }
        }

        /// XmNlist XmCList Widget dynamic G
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual List List {
            get {
                return XSports.GetWidget<List>(TonNurako.Motif.ResourceId.XmNlist, Data.Resource.Access.G);
            }
        }

        /// XmNmarginHeight XmCMarginHeight Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginHeight, 2);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginHeight, value);
            }
        }

        /// XmNmarginWidth XmCMarginWidth Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginWidth, 2);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginWidth, value);
            }
        }

        /// XmNmatchBehavior XmCMatchBehavior unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual MatchBehavior MatchBehavior {
            get {
                return XSports.GetValue<MatchBehavior>(TonNurako.Motif.ResourceId.XmNmatchBehavior, MatchBehavior.None);
            }
            set {
                XSports.SetValue<MatchBehavior>(TonNurako.Motif.ResourceId.XmNmatchBehavior, value);
            }
        }

        /// XmNpositionMode XmCPositionMode XtEnum XmZERO_BASED CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual PositionMode PositionMode {
            get {
                return XSports.GetValue<PositionMode>(
                    TonNurako.Motif.ResourceId.XmNpositionMode, PositionMode.ZeroBased, Data.Resource.Access.CG);
            }
            set {
                XSports.SetValue<PositionMode>(TonNurako.Motif.ResourceId.XmNpositionMode, value, Data.Resource.Access.CG);
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

        /// XmNselectedItem XmCSelectedItem XmString NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string SelectedItem {
            get {
                return XSports.GetString(TonNurako.Motif.ResourceId.XmNselectedItem, "");
            }
            set {
            XSports.SetString(TonNurako.Motif.ResourceId.XmNselectedItem, value);
            }
        }

        /// XmNselectedPosition XmCSelectedPosition int dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SelectedPosition {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNselectedPosition, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNselectedPosition, value);
            }
        }

        // XmtextField XmCTextField Widget dynamic G
        [Data.Resource.SportyResource(Data.Resource.Access.G)]
        public virtual TextField TextField {
            get {
                return XSports.GetWidget<TextField>(TonNurako.Motif.ResourceId.XmNtextField, Data.Resource.Access.G);
            }
        }

        /// XmNvisibleItemCount XmCVisibleItemCount int 10 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int VisibleItemCount {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNvisibleItemCount, 10);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNvisibleItemCount, value);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ

        TnkXtEvents<Events.ComboBoxEventArgs> ComboBoxEventTable {
            get;
        }

        /// XmNselectionCallback XmCCallback XmCallbackList NULL C
        public virtual event EventHandler<Events.ComboBoxEventArgs> SelectionEvent
        {
            add {
                ComboBoxEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNselectionCallback ,  value );
            }
            remove {
                ComboBoxEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNselectionCallback ,  value );
            }
        }

		#endregion

	}

 	/// <summary>
	/// DropDownComboBox (XmDropDownComboBox.txt)
	/// </summary>
	public class DropDownComboBox : Manager, IDefectiveWidget
	{

		#region ｺﾝｽﾄﾗｸﾀー

		/// <summary>
		/// ｺﾝｽﾄﾗｸﾀー
		/// </summary>
		public DropDownComboBox() : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		#endregion

		#region 生成

		/// <summary>
		/// DropDownComboBox生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent)
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateDropDownComboBox, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
        #endregion
    }

 	/// <summary>
	/// DropDownList (XmDropDownList.txt)
	/// </summary>
	public class DropDownList : Manager, IDefectiveWidget
	{

		#region ｺﾝｽﾄﾗｸﾀー

		/// <summary>
		/// ｺﾝｽﾄﾗｸﾀー
		/// </summary>
		public DropDownList() : base()
		{
		}
        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		#endregion

		#region 生成

		/// <summary>
		/// DropDownComboBox生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent)
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateDropDownList, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
        #endregion
    }
}
