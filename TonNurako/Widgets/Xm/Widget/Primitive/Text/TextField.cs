//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Runtime.InteropServices;
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// TextField
	/// </summary>
	public class TextField : Primitive
	{
        private string remainText;

		public TextField()  : base()
		{
            remainText = null;
            TextVerifyEventTable = new TnkXtEvents<Events.TextVerifyEventArgs>();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


		/// <summary>
		/// TextFieldの作成
		/// </summary>
		/// <param name="parent">親ｳｲｼﾞｪｯﾄ</param>
		/// <returns></returns>
		public override int Create(IWidget parent)
		{
			if( !IsAvailable )
			{
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateTextField, parent, ToolkitResources);
			}
            if(null != remainText) {
                NativeMethods.XmTextFieldSetString(this.Handle.Widget.Handle, remainText);
                remainText = null;
            }

			return base.Create(parent);
		}


        #region TextField ﾌﾟﾛﾊﾟﾃｨ

        internal static class NativeMethods {

            [DllImport(Native.ExtremeSports.Lib, EntryPoint = "XmTextFieldGetString_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XmTextFieldGetString(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint = "XmTextFieldSetString_TNK", CharSet = CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern void XmTextFieldSetString(IntPtr widget, [MarshalAs(UnmanagedType.LPStr)] string str);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldClearSelection_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextFieldClearSelection(IntPtr widget, uint time);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldCopy_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmTextFieldCopy(IntPtr widget, uint time);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldCopyLink_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmTextFieldCopyLink(IntPtr widget, uint time);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldCut_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmTextFieldCut(IntPtr widget, uint time);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldGetBaseline_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmTextFieldGetBaseline(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldGetEditable_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmTextFieldGetEditable(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldGetInsertionPosition_TNK", CharSet=CharSet.Auto)]
            internal static extern long XmTextFieldGetInsertionPosition(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldGetLastPosition_TNK", CharSet=CharSet.Auto)]
            internal static extern long XmTextFieldGetLastPosition(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldGetMaxLength_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmTextFieldGetMaxLength(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldGetSelection_TNK", CharSet=CharSet.Auto)]
            internal static extern IntPtr XmTextFieldGetSelection(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldGetSelectionPosition_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmTextFieldGetSelectionPosition(IntPtr widget, out long left, out long right);


            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldGetSubstring_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern int XmTextFieldGetSubstring(IntPtr widget, long start, int num_chars, int buffer_size, [MarshalAs(UnmanagedType.LPStr)] string buffer);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldInsert_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern void XmTextFieldInsert(IntPtr widget, long position, [MarshalAs(UnmanagedType.LPStr)] string value);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldPaste_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmTextFieldPaste(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldPasteLink_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmTextFieldPasteLink(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldPosToXY_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmTextFieldPosToXY(IntPtr widget, long position, IntPtr x, IntPtr y);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldRemove_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmTextFieldRemove(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldReplace_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern void XmTextFieldReplace(IntPtr widget, long from_pos, long to_pos, [MarshalAs(UnmanagedType.LPStr)] string value);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldSetAddMode_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextFieldSetAddMode(IntPtr widget, [MarshalAs(UnmanagedType.U1)] bool state);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldSetEditable_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextFieldSetEditable(IntPtr widget, [MarshalAs(UnmanagedType.U1)] bool editable);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldSetHighlight_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextFieldSetHighlight(IntPtr widget, long left, long right, Text.HighlightMode mode);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldSetInsertionPosition_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextFieldSetInsertionPosition(IntPtr widget, long position);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldSetMaxLength_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextFieldSetMaxLength(IntPtr widget, int max_length);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldSetSelection_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextFieldSetSelection(IntPtr widget, long first, long last, uint time);


            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldShowPosition_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextFieldShowPosition(IntPtr widget, long position);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFieldXYToPos_TNK", CharSet=CharSet.Auto)]
            internal static extern long XmTextFieldXYToPos(IntPtr widget, Int16 x, Int16 y);

        }

        public void SetString(string src) {
            this.Value = src;
        }
        public string GetString() {
            return this.Value;
        }

        public void ClearSelection() {
            NativeMethods.XmTextFieldClearSelection(this.Handle.Widget.Handle,
                            TonNurako.Xt.XtSports.XtLastTimestampProcessed(this.Handle.Display.Handle));
        }
        public void SetSelection(Text.Range range) {
            NativeMethods.XmTextFieldSetSelection(this.Handle.Widget.Handle,
                range.Begin, range.End, TonNurako.Xt.XtSports.XtLastTimestampProcessed(this.Handle.Display.Handle));
        }

        public void Copy() {
            NativeMethods.XmTextFieldCopy(this.Handle.Widget.Handle,
                            TonNurako.Xt.XtSports.XtLastTimestampProcessed(this.Handle.Display.Handle));
        }

        public void CopyLink() {
            NativeMethods.XmTextFieldCopyLink(this.Handle.Widget.Handle,
                            TonNurako.Xt.XtSports.XtLastTimestampProcessed(this.Handle.Display.Handle));
        }

        public void Cut() {
            NativeMethods.XmTextFieldCut(this.Handle.Widget.Handle,
                            TonNurako.Xt.XtSports.XtLastTimestampProcessed(this.Handle.Display.Handle));
        }

        public int GetBaseline() {
            return NativeMethods.XmTextFieldGetBaseline(this.Handle.Widget.Handle);
        }


        public bool GetEditable() {
            return NativeMethods.XmTextFieldGetEditable(this.Handle.Widget.Handle);
        }

        public void SetEditable(bool editable) {
            NativeMethods.XmTextFieldSetEditable(this.Handle.Widget.Handle, editable);
        }

        public int GetInsertionPosition() {
            return (int)NativeMethods.XmTextFieldGetInsertionPosition(this.Handle.Widget.Handle);
        }
        public int GetLastPosition() {
            return (int)NativeMethods.XmTextFieldGetLastPosition(this.Handle.Widget.Handle);
        }

        public int GetMaxLength() {
            return (int)NativeMethods.XmTextFieldGetMaxLength(this.Handle.Widget.Handle);
        }

        public string GetSelection() {
            IntPtr p = NativeMethods.XmTextFieldGetSelection(this.Handle.Widget.Handle);
            if (IntPtr.Zero == p) {
                return null;
            }
            string r = Marshal.PtrToStringAnsi(p);
            TonNurako.Xt.XtSports.XtFree(p);
            return r;
        }

        public Text.Range GetSelectionPosition() {
            long begin,  end;
            bool r = NativeMethods.XmTextFieldGetSelectionPosition(this.Handle.Widget.Handle, out begin, out end);
            if (true != r) {
                return null;
            }
            return new Text.Range((int)begin, (int)end);
        }



        public void Insert(string text, int offset) {
            NativeMethods.XmTextFieldInsert(this.Handle.Widget.Handle, (long)offset, text);
        }

        public bool Paste() {
            return NativeMethods.XmTextFieldPaste(this.Handle.Widget.Handle);
        }
        public bool PasteLink() {
            return NativeMethods.XmTextFieldPasteLink(this.Handle.Widget.Handle);
        }

        public bool Remove() {
            return NativeMethods.XmTextFieldRemove(this.Handle.Widget.Handle);
        }

        public void Replace(Text.Range range, string replace) {
            NativeMethods.XmTextFieldReplace(this.Handle.Widget.Handle, range.Begin, range.End, replace);
        }

        public void SetAddMode(bool mode) {
            NativeMethods.XmTextFieldSetAddMode(this.Handle.Widget.Handle, mode);
        }

        public void SetHighlight(Text.Range range, Text.HighlightMode mode) {
            NativeMethods.XmTextFieldSetHighlight(this.Handle.Widget.Handle, range.Begin, range.End, mode);
        }

        public void SetInsertionPosition(TextPosition pos) {
            NativeMethods.XmTextFieldSetInsertionPosition(this.Handle.Widget.Handle, pos.Position);
        }

        public void SetMaxLength(int max) {
            NativeMethods.XmTextFieldSetMaxLength(this.Handle.Widget.Handle, max);
        }

        public void ShowPosition(int pos) {
            NativeMethods.XmTextFieldShowPosition(this.Handle.Widget.Handle, pos);
        }

		/// <summary>
		/// 入力された文字を取得
		/// </summary>
		public virtual string Value
		{
			get
			{
				if( ! IsAvailable ) {
                    return "";
                }
                IntPtr pStr = NativeMethods.XmTextFieldGetString(this.Handle.Widget.Handle);
                string r = Marshal.PtrToStringAnsi(pStr);
                TonNurako.Xt.XtSports.XtFree(pStr);
				return r;
			}
			set
			{
				if (! IsAvailable ) {
                    remainText = value; // 控えに送る
                    System.Diagnostics.Debug.WriteLine("Text NotSet: " + value);
                    return;
                }
                System.Diagnostics.Debug.WriteLine("Text Set: " + value);
                NativeMethods.XmTextFieldSetString( this.Handle.Widget.Handle, value );
			}

		}

		#endregion

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNblinkRate XmCBlinkRate int 500 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int BlinkRate {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNblinkRate, 500);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNblinkRate, value);
            }
        }

        /// XmNcolumns XmCColumns short dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Columns {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNcolumns, 1);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNcolumns, value);
            }
        }

        /// XmNcursorPosition XmCCursorPosition XmTextPosition 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int CursorPosition {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNcolumns, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNcolumns, value);
            }
        }

        /// XmNcursorPositionVisible XmCCursorPositionVisible Boolean dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool CursorPositionVisible {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNcursorPositionVisible, true);
            }
            set {
            XSports.SetBool(TonNurako.Motif.ResourceId.XmNcursorPositionVisible, value);
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

        //  XmNfontList XmCFontList XmFontList dynamic CSG
        // -> Coreで定義

        /// XmNmarginHeight XmCMarginHeight Dimension 5 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginHeight {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginHeight, 5);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginHeight, value);
            }
        }

        /// XmNmarginWidth XmCMarginWidth Dimension 5 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MarginWidth {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmarginWidth, 5);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNmarginWidth, value);
            }
        }

        /// XmNmaxLength XmCMaxLength int largest integer CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int MaxLength {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmaxLength, Int32.MaxValue-1);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNmaxLength, value);
            }
        }

        /// XmNpendingDelete XmCPendingDelete Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool PendingDelete {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNpendingDelete, true);
            }
            set {
            XSports.SetBool(TonNurako.Motif.ResourceId.XmNpendingDelete, value);
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

        /// XmNresizeWidth XmCResizeWidth Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool ResizeWidth {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNresizeWidth, false);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNresizeWidth, value);
            }
        }
        // ### UNKOWN TYPE
        // ### XmNselectionArray XmCSelectionArray XtPointer default array CSG

        /// XmNselectionArrayCount XmCSelectionArrayCount int 3 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SelectionArrayCount {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNselectionArrayCount, 3);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNselectionArrayCount, value);
            }
        }

        /// XmNselectThreshold XmCSelectThreshold int 5 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int SelectThreshold {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNselectThreshold, 5);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNselectThreshold, value);
            }
        }


        /// XmNverifyBell XmCVerifyBell Boolean dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool VerifyBell {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNverifyBell, false);
            }
            set {
            XSports.SetBool(TonNurako.Motif.ResourceId.XmNverifyBell, value);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ
        internal TnkXtEvents<Events.TextVerifyEventArgs> TextVerifyEventTable {
            get;
        }

        /// XmNactivateCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> ActivateEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNactivateCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNactivateCallback ,  value );
            }
        }

        /// XmNdestinationCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> DestinationEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNdestinationCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNdestinationCallback ,  value );
            }
        }

        /// XmNfocusCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.TextVerifyEventArgs> FocusEvent
        {
            add {
                TextVerifyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNfocusCallback ,  value );
            }
            remove {
                TextVerifyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNfocusCallback ,  value );
            }
        }

        /// XmNgainPrimaryCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.TextVerifyEventArgs> GainPrimaryEvent
        {
            add {
                TextVerifyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNgainPrimaryCallback ,  value );
            }
            remove {
                TextVerifyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNgainPrimaryCallback ,  value );
            }
        }

        /// XmNlosePrimaryCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.TextVerifyEventArgs> LosePrimaryEvent
        {
            add {
                TextVerifyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNlosePrimaryCallback ,  value );
            }
            remove {
                TextVerifyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNlosePrimaryCallback ,  value );
            }
        }

        /// XmNlosingFocusCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.TextVerifyEventArgs> LosingFocusEvent
        {
            add {
                TextVerifyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNlosingFocusCallback ,  value );
            }
            remove {
                TextVerifyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNlosingFocusCallback ,  value );
            }
        }

        /// XmNmodifyVerifyCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.TextVerifyEventArgs> ModifyVerifyEvent
        {
            add {
                TextVerifyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNmodifyVerifyCallback ,  value );
            }
            remove {
                TextVerifyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNmodifyVerifyCallback ,  value );
            }
        }

        /// XmNmotionVerifyCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.TextVerifyEventArgs> MotionVerifyEvent
        {
            add {
                TextVerifyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNmotionVerifyCallback ,  value );
            }
            remove {
                TextVerifyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNmotionVerifyCallback ,  value );
            }
        }

        /// XmNvalueChangedCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> ValueChangedEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
        }

		#endregion


	}
}
