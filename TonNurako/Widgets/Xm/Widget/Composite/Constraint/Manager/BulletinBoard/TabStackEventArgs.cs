//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System.Runtime.InteropServices;

namespace TonNurako.Events {
    /// <summary>
    /// TabStackEventArgs
    /// </summary>
    public class TabStackEventArgs : TnkEventArgs {

        public TabStackEventArgs() {
        }

        public Widgets.IWidget Widget{
            get; internal set;
        }

        internal override void ParseXEvent(System.IntPtr call, System.IntPtr client) {
            var callData = (TonNurako.Motif.XmStruct.XmTabStackCallbackStruct)
            Marshal.PtrToStructure(call, typeof(TonNurako.Motif.XmStruct.XmTabStackCallbackStruct ) );

            Reason = ConvertReason(callData.reason);
            Widget = Sender.AppContext.FindWidgetByHandle(callData.selected_child);
        }

    }
}
