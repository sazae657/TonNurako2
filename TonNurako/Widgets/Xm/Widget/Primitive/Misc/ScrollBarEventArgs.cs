//
// ﾄﾝﾇﾗｺ
// 
// Widget
//
using System;
using System.Runtime.InteropServices;

namespace TonNurako.Events
{
    public class ScrollBarEventArgs : TnkEventArgs {

        public int Value {
            get;
            private set;
        }
        public int Pixel {
            get;
            private set;
        }

        public ScrollBarEventArgs() : base() {
        }

        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            var callData = (TonNurako.Motif.XmStruct.XmScrollBarCallbackStruct)
            Marshal.PtrToStructure(call, typeof(TonNurako.Motif.XmStruct.XmScrollBarCallbackStruct ) );

            this.Reason = ConvertReason(callData.reason);
            this.Value = callData.value;
            this.Pixel = callData.pixel;
        }

    }
}
