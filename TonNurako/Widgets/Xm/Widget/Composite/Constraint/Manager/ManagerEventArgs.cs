//
// ﾄﾝﾇﾗｺ
// 
// Widget
//
using System.Runtime.InteropServices;

namespace TonNurako.Events
{
    public class PopupHandlerEventArgs : TnkEventArgs {


        public PopupHandlerEventArgs() : base() {
        }

        internal override void ParseXEvent(System.IntPtr call, System.IntPtr client)  {
            var callData = (TonNurako.Motif.XmStruct.XmPopupHandlerCallbackStruct)
                Marshal.PtrToStructure(call, typeof(TonNurako.Motif.XmStruct.XmPopupHandlerCallbackStruct ) );

            System.Diagnostics.Debug.WriteLine(DumpStruct(callData));
            Reason = ConvertReason(callData.reason);
        }

    }


    public class ComboBoxEventArgs : TnkEventArgs {
        public string Item {
            get; internal set;
        }

        public int Position {
            get; internal set;
        }

        public ComboBoxEventArgs() : base() {
        }

        internal override void ParseXEvent(System.IntPtr call, System.IntPtr client) {
            var callData = (TonNurako.Motif.XmStruct.XmComboBoxCallbackStruct)
                Marshal.PtrToStructure(call, typeof(TonNurako.Motif.XmStruct.XmComboBoxCallbackStruct ) );

            this.Reason = ConvertReason(callData.reason);
            this.Item = Data.CompoundString.AsString(callData.item_or_text);
            this.Position = callData.item_position;
        }
    }

    public class ScaleEventArgs : TnkEventArgs {
        public string Item {
            get; internal set;
        }

        public int Position {
            get; internal set;
        }

        public ScaleEventArgs() : base() {
        }

        internal override void ParseXEvent(System.IntPtr call, System.IntPtr client) {
            var callData = (TonNurako.Motif.XmStruct.XmComboBoxCallbackStruct)
                Marshal.PtrToStructure(call, typeof(TonNurako.Motif.XmStruct.XmComboBoxCallbackStruct ) );

            this.Reason = ConvertReason(callData.reason);
            this.Item = Data.CompoundString.AsString(callData.item_or_text);
            this.Position = callData.item_position;
        }
    }
}
