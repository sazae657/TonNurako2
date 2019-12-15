using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.Widgets;

namespace TonNurako.Xt {
    [StructLayout(LayoutKind.Sequential)]
    internal struct XtCallbackRec {
        [MarshalAs(UnmanagedType.FunctionPtr)] XtCallbackProc callback;
        IntPtr closure;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void XtCallbackProc(
          IntPtr widget,
          IntPtr closure,
          IntPtr call_data
      );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void XtEventHandler(
        IntPtr widget,
        IntPtr closure,
        IntPtr xevent,//XEvent*
         IntPtr continue_to_dispatch //Boolean*
        );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void XtActionProc(
          IntPtr widget,
          IntPtr xevent, //XEvent*
          IntPtr xparams, //String*
          IntPtr num_params //Cardinal*
    );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void XtActionHookProc(
          IntPtr w, // Widget 
          IntPtr client_data, //XtPointer
          string action_name, //String
          IntPtr xevent, // XEvent
          IntPtr xparams, //String*
          IntPtr num_params //Cardinal*
    );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void XtActionDelegate(
        Widgets.IWidget widget,
        X11.Event.XEventArg xevent, // TODO: 別ｸﾗｽに分ける(?)
        string[] xparams
    );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void XtInputCallbackProc (
          IntPtr  closure, //XtPointer
          IntPtr source , //int*
          IntPtr id     //XtInputId*
      );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool XtWorkProc(
       IntPtr closure //XtPointer
    );


    //TODO: 散らばってるEventHandler系をこれに集める
    public class M860 {
        internal static class NativeMethods {
            // void: XtAddRawEventHandler Widget:w  EventMask:event_mask  Boolean:nonmaskable  XtEventHandler:proc  XtPointer:client_data  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAddRawEventHandler_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAddRawEventHandler(
                IntPtr w, TonNurako.X11.EventMask event_mask, [MarshalAs(UnmanagedType.U1)] bool nonmaskable,
                [MarshalAs(UnmanagedType.FunctionPtr)]TonNurako.Xt.XtEventHandler proc, IntPtr client_data);

            // void: XtRemoveRawEventHandler Widget:w  EventMask:event_mask  Boolean:nonmaskable  XtEventHandler:proc  XtPointer:client_data  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtRemoveRawEventHandler_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtRemoveRawEventHandler(
                IntPtr w, TonNurako.X11.EventMask event_mask, [MarshalAs(UnmanagedType.U1)] bool nonmaskable, 
                [MarshalAs(UnmanagedType.FunctionPtr)]TonNurako.Xt.XtEventHandler proc, IntPtr client_data);

            // void: XtInsertEventHandler Widget:w  EventMask:event_mask  Boolean:nonmaskable  XtEventHandler:proc  XtPointer:client_data  XtListPosition:position  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtInsertEventHandler_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtInsertEventHandler(
                IntPtr w, TonNurako.X11.EventMask event_mask, [MarshalAs(UnmanagedType.U1)] bool nonmaskable,
                [MarshalAs(UnmanagedType.FunctionPtr)]TonNurako.Xt.XtEventHandler proc, IntPtr client_data, XtListPosition position);

            // void: XtInsertRawEventHandler Widget:w  EventMask:event_mask  Boolean:nonmaskable  XtEventHandler:proc  XtPointer:client_data  XtListPosition:position  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtInsertRawEventHandler_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtInsertRawEventHandler(
                IntPtr w, TonNurako.X11.EventMask event_mask, [MarshalAs(UnmanagedType.U1)] bool nonmaskable,
                [MarshalAs(UnmanagedType.FunctionPtr)]TonNurako.Xt.XtEventHandler proc, IntPtr client_data, XtListPosition position);


        }

        public static void XtAddRawEventHandler(IWidget w, TonNurako.X11.EventMask event_mask,  bool nonmaskable, TonNurako.Xt.XtEventHandler proc, IntPtr client_data) {
            NativeMethods.XtAddRawEventHandler(w.Handle.Widget.Handle, event_mask, nonmaskable, proc, client_data);
        }

        public static void XtRemoveRawEventHandler(IWidget w, TonNurako.X11.EventMask event_mask, bool nonmaskable, TonNurako.Xt.XtEventHandler proc, IntPtr client_data) {
            NativeMethods.XtRemoveRawEventHandler(w.Handle.Widget.Handle, event_mask, nonmaskable, proc, client_data);
        }

        public static void XtInsertEventHandler(IWidget w, TonNurako.X11.EventMask event_mask,  bool nonmaskable, TonNurako.Xt.XtEventHandler proc, IntPtr client_data, XtListPosition position) {
            NativeMethods.XtInsertEventHandler(w.Handle.Widget.Handle, event_mask, nonmaskable, proc, client_data, position);
        }

        public static void XtInsertRawEventHandler(IWidget w, TonNurako.X11.EventMask event_mask, bool nonmaskable, TonNurako.Xt.XtEventHandler proc, IntPtr client_data, XtListPosition position) {
            NativeMethods.XtInsertRawEventHandler(w.Handle.Widget.Handle, event_mask, nonmaskable, proc, client_data, position);
        }



    }

}
