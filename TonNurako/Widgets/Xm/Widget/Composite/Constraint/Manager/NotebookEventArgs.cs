//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Runtime.InteropServices;

namespace TonNurako.Events
{
    public class NotebookEventArgs : TnkEventArgs {

        [StructLayout(LayoutKind.Sequential)]
        internal struct XmNotebookCallbackStruct {
            public int reason;
            public IntPtr xevent; // XEvent*
            public int page_number;
            public IntPtr page_widget;
            public int prev_page_number;
            public IntPtr prev_page_widget;
        }

        public int PageNumber {
            get; internal set;
        }

        public TonNurako.Widgets.IWidget PageWidget {
            get; internal set;
        }

        public int PrevPageNumber {
            get; internal set;
        }

        public TonNurako.Widgets.IWidget PrevPageWidget {
            get; internal set;
        }

        public NotebookEventArgs() : base() {
        }

        internal override void ParseXEvent(System.IntPtr call, System.IntPtr client)  {
            var cs = (XmNotebookCallbackStruct)Marshal.PtrToStructure(call, typeof(XmNotebookCallbackStruct));
            Reason = ConvertReason(cs.reason);

            PageNumber = cs.page_number;
            PageWidget = (IntPtr.Zero != cs.page_widget) ? Sender.AppContext.FindWidgetByHandle(cs.page_widget) : null;

            PrevPageNumber = cs.prev_page_number;
            PrevPageWidget = (IntPtr.Zero != cs.prev_page_widget) ? Sender.AppContext.FindWidgetByHandle(cs.prev_page_widget) : null;
        }
    }
}

