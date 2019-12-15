//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Runtime.InteropServices;

namespace TonNurako.Events
{
    public class HierarchyEventArgs : TnkEventArgs {

        [StructLayout(LayoutKind.Sequential)]
        internal struct XmHierarchyNodeStateData {
            public IntPtr widget;
            public TonNurako.Widgets.Xm.Hierarchy.NodeState state;
        }

        public TonNurako.Widgets.Xm.Hierarchy.NodeState State {
            get; internal set;
        }

        public TonNurako.Widgets.IWidget Widget {
            get; internal set;
        }

        public HierarchyEventArgs() : base() {
        }

        internal override void ParseXEvent(System.IntPtr call, System.IntPtr client)  {
            var cs = (XmHierarchyNodeStateData)Marshal.PtrToStructure(call, typeof(XmHierarchyNodeStateData));
            State = cs.state;

            Widget = Sender.AppContext.FindWidgetByHandle(cs.widget);

        }
    }
}

