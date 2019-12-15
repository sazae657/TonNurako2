using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.Xt.Core {
    [StructLayout(LayoutKind.Sequential)]
    internal struct XtEventRec {
        IntPtr next; //XtEventTable = XtEventRec*
        [MarshalAs(UnmanagedType.U8)] TonNurako.X11.EventMask mask;
        [MarshalAs(UnmanagedType.FunctionPtr)] XtEventHandler proc;
        IntPtr closure;
        uint bitfield; //TODO: ↓ おう、勘弁してくれよ
                       //uint select:1;
                       // uint has_type_specifier:1;
                       // uint async:1; 
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XtTMRec {
        IntPtr translations;    // XtTranslations
        //TODO: delegateの配列どうすんだ
        IntPtr proc_table;      // XtActionProc[] 
        IntPtr current_state;   // _XtStateRec
        ulong lastEventTime;
    }


    [StructLayout(LayoutKind.Sequential)]
    internal struct XtResource {
        [MarshalAs(UnmanagedType.LPStr)] public string resource_name;
        [MarshalAs(UnmanagedType.LPStr)] public string resource_class;
        [MarshalAs(UnmanagedType.LPStr)] public string resource_type;
        public int resource_size;
        public int resource_offset;
        [MarshalAs(UnmanagedType.LPStr)] public string default_type;
        public IntPtr default_addr; //XtPointer
    }
}
