//
// ﾄﾝﾇﾗｺ
// 
// Widget
//
using System.Runtime.InteropServices;

namespace TonNurako.Events
{
    public class SimpleEventArgs : TnkEventArgs {

        public int SelectedIndex {
            get; internal set;
        }

        public SimpleEventArgs() : base() {
        }

        internal override void ParseXEvent(System.IntPtr call, System.IntPtr client)  {
            var callData = (TonNurako.Motif.XmStruct.XmPopupHandlerCallbackStruct)
                Marshal.PtrToStructure(call, typeof(TonNurako.Motif.XmStruct.XmPopupHandlerCallbackStruct ) );

            System.Diagnostics.Debug.WriteLine(DumpStruct(callData));
            Reason = ConvertReason(callData.reason);
            SelectedIndex = (int)client;
        }
    }
}
