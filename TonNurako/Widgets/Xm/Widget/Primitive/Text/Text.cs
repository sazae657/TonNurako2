//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Runtime.InteropServices;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// TextPosition
    /// </summary>
    public class TextPosition {
        public int X {get; set;}
        public int Y {get; set;}

        public int Position {get;set;}
        public TextPosition() {
        }
    }


    /// <summary>
    /// Text
    /// </summary>
    public class Text : TextBase {
        public enum FindDirection {
            // The search proceeds toward the end of the text buffer.
            Forward = TonNurako.Motif.Constant.XmTEXT_FORWARD,

            // The search proceeds toward the beginning of the text buffer.
            Backward = TonNurako.Motif.Constant.XmTEXT_BACKWARD,
        }

        public enum HighlightMode {
            Normal	= TonNurako.Motif.Constant.XmHIGHLIGHT_NORMAL,
            SecondarySelected = TonNurako.Motif.Constant.XmHIGHLIGHT_SECONDARY_SELECTED,
            Selected = TonNurako.Motif.Constant.XmHIGHLIGHT_SELECTED,
        }


        public class Range {
            public int Begin {get; set;}
            public int End {get; set;}

            public Range() {
            }

            public Range(int begin, int end) {
                Begin = begin;
                End = end;
            }
        }

        #region 初期化

        private string remainText;

        public Text() : base()
        {
            remainText = null;
        }

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        /// <summary>
        /// ScrollBarの作成
        /// </summary>
        /// <param name="parent">親ｳｲｼﾞｪｯﾄ</param>
        /// <returns></returns>
        public override int Create(IWidget parent)
        {
            if (!IsAvailable) {
                this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateText, parent, ToolkitResources);
            }
            if (null != remainText) {
                NativeMethods.XmTextSetString(this.Handle.Widget.Handle, remainText);
                remainText = null;
            }
            return base.Create(parent);
        }
        #endregion

        internal static class NativeMethods {

            [DllImport(Native.ExtremeSports.Lib, EntryPoint = "XmTextGetString_TNK", CharSet = CharSet.Auto)]
            public static extern IntPtr XmTextGetString(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint = "XmTextSetString_TNK", CharSet = CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            public static extern void XmTextSetString(IntPtr widget, [MarshalAs(UnmanagedType.LPStr)] string str);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextClearSelection_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextClearSelection(IntPtr widget, uint time);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextCopy_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmTextCopy(IntPtr widget, uint time);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextCopyLink_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmTextCopyLink(IntPtr widget, uint time);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextCut_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmTextCut(IntPtr widget, uint time);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextDisableRedisplay_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextDisableRedisplay(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextEnableRedisplay_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextEnableRedisplay(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextFindString_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern bool XmTextFindString(IntPtr widget, long start,
                    [MarshalAs(UnmanagedType.LPStr)] string xstring, FindDirection direction,[Out] out long position);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextPosToXY_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmTextPosToXY(IntPtr widget, long position,[Out] out Int16 x, [Out] out Int16 y);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextXYToPos_TNK", CharSet=CharSet.Auto)]
            internal static extern long XmTextXYToPos(IntPtr widget, Int16 x, Int16 y);


            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextGetBaseline_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmTextGetBaseline(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextGetCenterline_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmTextGetCenterline(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextGetEditable_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmTextGetEditable(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextGetInsertionPosition_TNK", CharSet=CharSet.Auto)]
            internal static extern long XmTextGetInsertionPosition(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextGetLastPosition_TNK", CharSet=CharSet.Auto)]
            internal static extern long XmTextGetLastPosition(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextGetMaxLength_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmTextGetMaxLength(IntPtr widget);


            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextGetSelection_TNK", CharSet=CharSet.Auto)]
            internal static extern IntPtr XmTextGetSelection(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextGetSelectionPosition_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmTextGetSelectionPosition(IntPtr widget, [Out] out long left, [Out] out long right);

            //
            // TODO: unsafeﾌﾞﾛｯｸじゃないと触れん
            //
            // [DllImport(LibHelper.LibName, EntryPoint="XmTextSetSource_TNK", CharSet=CharSet.Auto)]
            // internal static extern void XmTextSetSource(IntPtr widget, IntPtr source, long top_character, long cursor_position);
            // [DllImport(LibHelper.LibName, EntryPoint="XmTextGetSource_TNK", CharSet=CharSet.Auto)]
            // internal static extern IntPtr XmTextGetSource(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextGetTopCharacter_TNK", CharSet=CharSet.Auto)]
            internal static extern long XmTextGetTopCharacter(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextInsert_TNK", CharSet=CharSet.Auto,BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern void XmTextInsert(IntPtr widget, long position, [MarshalAs(UnmanagedType.LPStr)] string value);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextPaste_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmTextPaste(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextPasteLink_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmTextPasteLink(IntPtr widget);


            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextRemove_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmTextRemove(IntPtr widget);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextReplace_TNK", CharSet=CharSet.Auto,BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern void XmTextReplace(IntPtr widget, long from_pos, long to_pos, [MarshalAs(UnmanagedType.LPStr)] string value);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextScroll_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextScroll(IntPtr widget, int lines);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextSetAddMode_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextSetAddMode(IntPtr widget, [MarshalAs(UnmanagedType.U1)] bool state);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextSetEditable_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextSetEditable(IntPtr widget, [MarshalAs(UnmanagedType.U1)] bool editable);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextSetHighlight_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextSetHighlight(IntPtr widget, long left, long right, HighlightMode mode);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextSetInsertionPosition_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextSetInsertionPosition(IntPtr widget, long position);


            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextSetMaxLength_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextSetMaxLength(IntPtr widget, int max_length);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextSetSelection_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextSetSelection(IntPtr widget, long first, long last, uint time);


            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextSetTopCharacter_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextSetTopCharacter(IntPtr widget, long top_character);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTextShowPosition_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTextShowPosition(IntPtr widget, long position);

        }

        public void SetString(string src) {
            this.Value = src;
        }
        public string GetString() {
            return this.Value;
        }

        public void ClearSelection() {
            NativeMethods.XmTextClearSelection(this.Handle.Widget.Handle,
                            TonNurako.Xt.XtSports.XtLastTimestampProcessed(this.Handle.Display.Handle));
        }
        public void SetSelection(Range range) {
            NativeMethods.XmTextSetSelection(this.Handle.Widget.Handle,
                range.Begin, range.End, TonNurako.Xt.XtSports.XtLastTimestampProcessed(this.Handle.Display.Handle));
        }

        public void Copy() {
            NativeMethods.XmTextCopy(this.Handle.Widget.Handle,
                            TonNurako.Xt.XtSports.XtLastTimestampProcessed(this.Handle.Display.Handle));
        }

        public void CopyLink() {
            NativeMethods.XmTextCopyLink(this.Handle.Widget.Handle,
                            TonNurako.Xt.XtSports.XtLastTimestampProcessed(this.Handle.Display.Handle));
        }

        public void Cut() {
            NativeMethods.XmTextCut(this.Handle.Widget.Handle,
                            TonNurako.Xt.XtSports.XtLastTimestampProcessed(this.Handle.Display.Handle));
        }

        public void DisableRedisplay() {
            NativeMethods.XmTextDisableRedisplay(this.Handle.Widget.Handle);
        }

        public void EnableRedisplay() {
            NativeMethods.XmTextEnableRedisplay(this.Handle.Widget.Handle);
        }

        public bool Find(string find, int offset, FindDirection direction, TextPosition pos) {
            long ret = -1;
            bool r = NativeMethods.XmTextFindString(this.Handle.Widget.Handle, (long)offset, find, direction, out ret);
            if (true != r) {
                return false;
            }
            short x, y;
            NativeMethods.XmTextPosToXY(this.Handle.Widget.Handle, ret, out x, out y);
            pos.X = x;
            pos.Y = y;
            pos.Position = (int)ret;
            return r;
        }

        public int Find(string find, int offset, FindDirection direction) {
            long ret = -1;
            bool r = NativeMethods.XmTextFindString(this.Handle.Widget.Handle, (long)offset, find, direction, out ret);
            if (true != r) {
                return -1;
            }
            return (int)ret;
        }
        public int GetBaseline() {
            return NativeMethods.XmTextGetBaseline(this.Handle.Widget.Handle);
        }

        public int GetCenterline() {
            return NativeMethods.XmTextGetCenterline(this.Handle.Widget.Handle);
        }

        public bool GetEditable() {
            return NativeMethods.XmTextGetEditable(this.Handle.Widget.Handle);
        }

        public void SetEditable(bool editable) {
            NativeMethods.XmTextSetEditable(this.Handle.Widget.Handle, editable);
        }

        public int GetInsertionPosition() {
            return (int)NativeMethods.XmTextGetInsertionPosition(this.Handle.Widget.Handle);
        }
        public int GetLastPosition() {
            return (int)NativeMethods.XmTextGetLastPosition(this.Handle.Widget.Handle);
        }

        public int GetMaxLength() {
            return (int)NativeMethods.XmTextGetMaxLength(this.Handle.Widget.Handle);
        }

        public string GetSelection() {
            IntPtr p = NativeMethods.XmTextGetSelection(this.Handle.Widget.Handle);
            if (IntPtr.Zero == p) {
                return null;
            }
            string r = Marshal.PtrToStringAnsi(p);
            TonNurako.Xt.XtSports.XtFree(p);
            return r;
        }

        public Range GetSelectionPosition() {
            long begin,  end;
            bool r = NativeMethods.XmTextGetSelectionPosition(this.Handle.Widget.Handle, out begin, out end);
            if (true != r) {
                return null;
            }
            return new Range((int)begin, (int)end);
        }

        public int GetTopCharacter() {
            return (int)NativeMethods.XmTextGetTopCharacter(this.Handle.Widget.Handle);
        }

        public void SetTopCharacter(int ch) {
            NativeMethods.XmTextSetTopCharacter(this.Handle.Widget.Handle, ch);
        }

        public void Insert(string text, int offset) {
            NativeMethods.XmTextInsert(this.Handle.Widget.Handle, (long)offset, text);
        }

        public bool Paste() {
            return NativeMethods.XmTextPaste(this.Handle.Widget.Handle);
        }
        public bool PasteLink() {
            return NativeMethods.XmTextPasteLink(this.Handle.Widget.Handle);
        }

        public bool Remove() {
            return NativeMethods.XmTextRemove(this.Handle.Widget.Handle);
        }

        public void Replace(Range range, string replace) {
            NativeMethods.XmTextReplace(this.Handle.Widget.Handle, range.Begin, range.End, replace);
        }

        public void Scroll(int line) {
            NativeMethods.XmTextScroll(this.Handle.Widget.Handle, line);
        }

        public void SetAddMode(bool mode) {
            NativeMethods.XmTextSetAddMode(this.Handle.Widget.Handle, mode);
        }

        public void SetHighlight(Range range, HighlightMode mode) {
            NativeMethods.XmTextSetHighlight(this.Handle.Widget.Handle, range.Begin, range.End, mode);
        }

        public void SetInsertionPosition(TextPosition pos) {
            NativeMethods.XmTextSetInsertionPosition(this.Handle.Widget.Handle, pos.Position);
        }

        public void SetMaxLength(int max) {
            NativeMethods.XmTextSetMaxLength(this.Handle.Widget.Handle, max);
        }

        public void ShowPosition(int pos) {
            NativeMethods.XmTextShowPosition(this.Handle.Widget.Handle, pos);
        }

		#region ﾌﾟﾛﾊﾟﾃｨ
		/// <summary>
		/// 入力された文字を取得
		/// </summary>
		public override string Value
		{
			get
			{
				if( ! IsAvailable ) {
                    return "";
                }
                IntPtr pStr = NativeMethods.XmTextGetString(this.Handle.Widget.Handle);
                string r = Marshal.PtrToStringAnsi(pStr);
                TonNurako.Xt.XtSports.XtFree(pStr);
				return r;
			}
			set
			{
				if (! IsAvailable ) {
                    remainText = value; // 控えに送る
                    return;
                }
                NativeMethods.XmTextSetString(this.Handle.Widget.Handle, value );
			}
		}
        #endregion



	}
}
