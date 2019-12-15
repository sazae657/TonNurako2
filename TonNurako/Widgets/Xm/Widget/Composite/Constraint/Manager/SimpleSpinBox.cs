//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Runtime.InteropServices;
using TonNurako.Native;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// SimpleSpinBox
	/// </summary>
	public class SimpleSpinBox : Manager, IDefectiveWidget
	{
		public SimpleSpinBox() : base() {
            widgets = new Widgets();
            SimpleSpinBoxEventTable = new TnkXtEvents<Events.SimpleSpinBoxEventArgs>();
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

        protected override void Dispose(bool disposing) {
            widgets.TextField = null;
            widgets = null;
            base.Dispose(disposing);
        }


		/// <summary>
		/// SimpleSpinBox生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateSimpleSpinBox, parent, ToolkitResources);
			}
            widgets.TextField.WrapExistingWidget(ToolkitResources.GetPointerValue(TonNurako.Motif.ResourceId.XmNtextField));
            this.Children.Add(widgets.TextField);
			return base.Create (parent);
		}


        #region 固有ﾒｿｯﾄﾞー

        // ﾈｲﾃｨﾌﾞ参照
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint="XmSimpleSpinBoxAddItem_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmSimpleSpinBoxAddItem(IntPtr w, IntPtr item, int pos);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmSimpleSpinBoxDeletePos_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmSimpleSpinBoxDeletePos(IntPtr w, int pos);

            [DllImport(ExtremeSports.Lib, EntryPoint="XmSimpleSpinBoxSetItem_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmSimpleSpinBoxSetItem(IntPtr w, IntPtr item);
        }

        internal class Widgets {
            public Widgets() {
                TextField = new TextField();
            }
            public TextField TextField {
                get; internal set;
            }
        }
        internal Widgets widgets;

        public void AddItem(string item, int pos) {
            using (var s = new Data.CompoundString(item)) {
                NativeMethods.XmSimpleSpinBoxAddItem(this.Handle.Widget.Handle , s.Handle, pos);
            }
        }


        public void DeletePos(int pos) {
            NativeMethods.XmSimpleSpinBoxDeletePos(this.Handle.Widget.Handle, pos);
        }


        public void SetItem(string item) {
            using (var s = new Data.CompoundString(item)) {
                NativeMethods.XmSimpleSpinBoxSetItem(this.Handle.Widget.Handle, s.Handle);
            }
        }


        #endregion

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNarrowLayout XmCArrowLayout unsigned char XmARROWS_END CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ArrowLayout ArrowLayout {
            get {
                return XSports.GetValue<ArrowLayout>(TonNurako.Motif.ResourceId.XmNarrowLayout, ArrowLayout.End);
            }
            set {
                XSports.SetValue<ArrowLayout>(TonNurako.Motif.ResourceId.XmNarrowLayout, value);
            }
        }

        /// XmNarrowSensitivity XmCArrowSensitivity unsigned char XmARROWS-_SENSITIVE CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ArrowSensitivity ArrowSensitivity {
            get {
                return XSports.GetValue<ArrowSensitivity>(TonNurako.Motif.ResourceId.XmNarrowSensitivity, ArrowSensitivity.Sensitive);
            }
            set {
                XSports.SetValue<ArrowSensitivity>(TonNurako.Motif.ResourceId.XmNarrowSensitivity, value);
            }
        }

        /// XmNcolumns XmCColumn short 20 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Columns {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNcolumns, 20);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNcolumns, value);
            }
        }

        /// XmNdecimalPoints XmCDecimalPoints short 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DecimalPoints {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNdecimalPoints, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNdecimalPoints, value);
            }
        }

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

        /// XmNincrementValue XmCIncrementValue int 1 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int IncrementValue {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNincrementValue, 1);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNincrementValue, value);
            }
        }

        /// XmNinitialDelay XmCInitialDelay unsigned int 250 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual uint InitialDelay {
            get {
                return XSports.GetUInt(TonNurako.Motif.ResourceId.XmNinitialDelay, 250);
            }
            set {
                XSports.SetUInt(TonNurako.Motif.ResourceId.XmNinitialDelay, value);
            }
        }

        /// XmNmaximumValue XmCMaximumValue int 10 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MaximumValue {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmaximumValue, 10);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNmaximumValue, value);
            }
        }

        /// XmNminimumValue XmCMinimumValue int 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MinimumValue {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNminimumValue, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNminimumValue, value);
            }
        }

        /// XmNnumValues XmCNumValues int 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int NumValues {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNnumValues, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNnumValues, value);
            }
        }

        //  XmNvalues XmCValues XmStringTable NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public Data.CompoundStringTable Values {
            get {
                return XSports.GetStringTable(TonNurako.Motif.ResourceId.XmNvalues, NumValues, true);
            }
            set {
                NumValues = value.Count;
                XSports.SetStringTable(TonNurako.Motif.ResourceId.XmNvalues, value);
            }
        }

        /// XmNposition XmCPosition int 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Position {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNposition, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNposition, value);
            }
        }

        /// XmNrepeatDelay XmCRepeatDelay unsigned int 200 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual uint RepeatDelay {
            get {
                return XSports.GetUInt(TonNurako.Motif.ResourceId.XmNrepeatDelay, 200);
            }
            set {
            XSports.SetUInt(TonNurako.Motif.ResourceId.XmNrepeatDelay, value);
            }
        }

        /// XmNspinBoxChildType XmCSpinBoxChildType unsigned char XmSTRING CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual SpinBoxChildType SpinBoxChildType {
            get {
                return XSports.GetValue<SpinBoxChildType>(
                    TonNurako.Motif.ResourceId.XmNspinBoxChildType, SpinBoxChildType.String, Data.Resource.Access.CG);
            }
            set {
                XSports.SetValue<SpinBoxChildType>(
                    TonNurako.Motif.ResourceId.XmNspinBoxChildType, value, Data.Resource.Access.CG);
            }
        }

        /// XmNtextField XmCTextField Widget dynamic G
        [Data.Resource.SportyResource(Data.Resource.Access.G)]
        public virtual TextField TextField {
            get {
                return widgets.TextField;
                //return XSports.GetWidget<TextField>(TonNurako.Motif.ResourceId.XmNtextField, Data.Resource.Access.G);
            }
        }


        #endregion

        #region ｲﾍﾞﾝﾄ
        TnkXtEvents<Events.SimpleSpinBoxEventArgs> SimpleSpinBoxEventTable {
            get;
        }

        /// XmNmodifyVerifyCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.SimpleSpinBoxEventArgs> ModifyVerifyEvent
        {
            add {
                SimpleSpinBoxEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNmodifyVerifyCallback ,  value );
            }
            remove {
                SimpleSpinBoxEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNmodifyVerifyCallback ,  value );
            }
        }

        /// XmNvalueChangedCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.SimpleSpinBoxEventArgs> ValueChangedEvent
        {
            add {
                SimpleSpinBoxEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
            remove {
                SimpleSpinBoxEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
        }

		#endregion

	}
}
