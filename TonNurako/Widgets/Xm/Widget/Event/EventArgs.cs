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
    /// 
    /// </summary>
    public class TnkEventArgs : System.EventArgs {
        public CallReason Reason {
            get;
            internal set;
        }
        public Widgets.IWidget Sender {
            get;
            internal set;
        }

        internal CallReason ConvertReason(int reason) {
            return (CallReason)System.Enum.ToObject(typeof(CallReason), reason);
        }

        public TnkEventArgs() : base() {
        }

        internal virtual void ParseXEvent(IntPtr call, IntPtr client) {
        }
        internal System.IntPtr ModifiedCallData {
            get; set;
        }

        public string DumpStruct() {
            return DumpStruct(this, 0);
        }

        public string DumpStruct(object obj) {
            return DumpStruct(obj, 0);
        }
        public string DumpStruct(object klass, int level)
        {
            string ret = "";
            try
            {
                System.Reflection.FieldInfo[] fields = klass.GetType().GetFields();
                foreach (System.Reflection.FieldInfo f in fields)
                {
                    for (int i = 0; i < level; i++) {
                        ret += "  ";
                    }
                    ret += f.Name  + ": ";
                    ret += f.GetValue(klass).ToString() + "\n";
                    if (f.FieldType.ToString().StartsWith("TonNurako")) {
                        ret += DumpStruct(f.GetValue(klass), level+=1);
                    }
                }
            }
            catch (System.Exception e) {
                ret = e.ToString();
            }
            return ret;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TnkWidgetEventArgs : System.EventArgs {
        public Widgets.IWidget Sender {
            get;
            internal set;
        }
        public TnkWidgetEventArgs(Widgets.IWidget _Sender) : base() {
            Sender = _Sender;
        }

        internal virtual void ParseXEvent(IntPtr call, IntPtr client) {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AnyEventArgs : TnkEventArgs {

        public AnyEventArgs() : base() {
        }


        internal AnyEventArgs(TonNurako.Motif.XmStruct.XmAnyCallbackStruct call) : base() {
            Reason = ConvertReason(call.reason);
        }

        internal override void ParseXEvent(IntPtr call, IntPtr client) {
            TonNurako.Motif.XmStruct.XmAnyCallbackStruct callData = (TonNurako.Motif.XmStruct.XmAnyCallbackStruct)
            Marshal.PtrToStructure(call, typeof(TonNurako.Motif.XmStruct.XmAnyCallbackStruct ) );

            Reason = ConvertReason(callData.reason);
        }
    }



}

