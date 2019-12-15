//
// ﾄﾝﾇﾗｺ
// 
// Widget
//
using System.Runtime.InteropServices;

namespace TonNurako.Events {
    /// <summary>
    /// 
    /// </summary>
    public class FileSelectionBoxEventArgs : TnkEventArgs {

        public FileSelectionBoxEventArgs() {
        }
        
        internal override void ParseXEvent(System.IntPtr call, System.IntPtr client) {
            var callData = (TonNurako.Motif.XmStruct.XmFileSelectionBoxCallbackStruct)
            Marshal.PtrToStructure(call, typeof(TonNurako.Motif.XmStruct.XmFileSelectionBoxCallbackStruct) );

            Reason = ConvertReason(callData.reason);
        }

    }
}
