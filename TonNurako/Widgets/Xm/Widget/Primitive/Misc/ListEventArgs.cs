//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Runtime.InteropServices;

namespace TonNurako.Events
{
    /// <summary>
    /// ListEventArgs
    /// </summary>
    public class ListEventArgs : TnkEventArgs {

        public int Value {
            get;
            private set;
        }
        public int Pixel {
            get;
            private set;
        }

        public ListEventArgs() : base() {
        }

        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            var callData = (TonNurako.Motif.XmStruct.XmListCallbackStruct)
            Marshal.PtrToStructure(call, typeof(TonNurako.Motif.XmStruct.XmListCallbackStruct) );

            this.Reason = ConvertReason(callData.reason);
            switch (Reason) {
                case CallReason.DEFAULT_ACTION:
                    break;
                case CallReason.SINGLE_SELECT:
                    break;
                case CallReason.BROWSE_SELECT:
                    break;
                case CallReason.MULTIPLE_SELECT:
                    break;
                case CallReason.EXTENDED_SELECT:
                    break;
            }

        }

    }
}
