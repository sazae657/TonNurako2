using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.X11;
using TonNurako.X11.Event;

namespace TonNurako.Xt {

    [StructLayout(LayoutKind.Sequential)]
    internal struct XtActionsRec
    {
        [MarshalAs(UnmanagedType.LPStr)] string str;
        [MarshalAs(UnmanagedType.FunctionPtr)] XtActionProc proc;
        public XtActionsRec(string str, XtActionProc d) {
            this.str = str;
            this.proc = d;
        }
    }


    public struct XtAction {
        public string Str;
        public XtActionDelegate Delegaty;

        public XtAction(string str, XtActionDelegate d) {
            Str = str;
            Delegaty = d;
        }
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void XtTimerCallbackProc(
        XtTimerCallbackDelegate closure, //XtPointer
        IntPtr id //XtIntervalId*
    );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void XtTimerCallbackDelegate(ulong id);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void XtBlockHookProc(IntPtr client_data);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void  XtSignalCallbackProc(
        IntPtr closure,//XtPointer
        IntPtr id //XtSignalId*
      );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void XtErrorHandler(
        IntPtr msg //string
    );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void XtErrorMsgHandler(
          IntPtr name,//String
          IntPtr type,//String
          IntPtr glass,//String
          IntPtr befault, //String
          IntPtr qarams , // String*
          IntPtr num_params //Cardinal* 
      );


    public class XtAppContext : IX11Interop {
        #region NativeMethods
        internal static class NativeMethods {

            // XtActionHookId: XtAppAddActionHook XtAppContext:app_context XtActionHookProc:proc XtPointer:client_data
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppAddActionHook_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XtAppAddActionHook(IntPtr app_context, [MarshalAs(UnmanagedType.FunctionPtr)]XtActionHookProc proc, IntPtr client_data);

            // void: XtRemoveActionHook XtActionHookId:id
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtRemoveActionHook_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtRemoveActionHook(IntPtr id);

            // XtTranslations: XtParseTranslationTable String:table
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtParseTranslationTable_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr XtParseTranslationTable([MarshalAs(UnmanagedType.LPStr)] string table);


            // void: XtAppAddActions XtAppContext:app_context XtActionList:actions Cardinal:num_actions
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppAddActions_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAppAddActions(IntPtr app_context, [MarshalAs(UnmanagedType.LPArray)]XtActionsRec[] actions, int num_actions);


            // XtIntervalId: XtAppAddTimeOut XtAppContext:app_context  long:interval  XtTimerCallbackProc:proc  XtPointer:client_data
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppAddTimeOut_TNK", CharSet = CharSet.Auto)]
            internal static extern ulong XtAppAddTimeOut(
                IntPtr app_context, long interval, [MarshalAs(UnmanagedType.FunctionPtr)]XtTimerCallbackProc proc, [MarshalAs(UnmanagedType.FunctionPtr)]XtTimerCallbackDelegate client_data);

            // void: XtRemoveTimeOut XtIntervalId:timer
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtRemoveTimeOut_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtRemoveTimeOut(ulong timer);

            // XtInputId: XtAppAddInput XtAppContext:app_context  int:source  XtPointer:condition  XtInputCallbackProc:proc  XtPointer:client_data  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppAddInput_TNK", CharSet = CharSet.Auto)]
            internal static extern ulong XtAppAddInput(IntPtr app_context, int source, IntPtr condition, [MarshalAs(UnmanagedType.FunctionPtr)] XtInputCallbackProc proc, IntPtr client_data);

            // void: XtRemoveInput XtInputId:id  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtRemoveInput_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtRemoveInput(ulong id);

            // XtWorkProcId: XtAppAddWorkProc XtAppContext:app_context  XtWorkProc:proc  XtPointer:client_data  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppAddWorkProc_TNK", CharSet = CharSet.Auto)]
            internal static extern ulong XtAppAddWorkProc(IntPtr app_context, [MarshalAs(UnmanagedType.FunctionPtr)] XtWorkProc proc, IntPtr client_data);

            // void: XtRemoveWorkProc XtWorkProcId:id  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtRemoveWorkProc_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtRemoveWorkProc(ulong id);


            // XtBlockHookId: XtAppAddBlockHook XtAppContext:app_context  XtBlockHookProc:proc  XtPointer:client_data  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppAddBlockHook_TNK", CharSet = CharSet.Auto)]
            internal static extern ulong XtAppAddBlockHook(IntPtr app_context, [MarshalAs(UnmanagedType.FunctionPtr)] XtBlockHookProc proc, IntPtr client_data);

            // void: XtRemoveBlockHook XtBlockHookId:id  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtRemoveBlockHook_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtRemoveBlockHook(ulong id);


            // XtSignalId: XtAppAddSignal XtAppContext:app_context  XtSignalCallbackProc:proc  XtPointer:client_data  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppAddSignal_TNK", CharSet = CharSet.Auto)]
            internal static extern ulong XtAppAddSignal(IntPtr app_context, [MarshalAs(UnmanagedType.FunctionPtr)] XtSignalCallbackProc proc, IntPtr client_data);

            // void: XtRemoveSignal XtSignalId:id  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtRemoveSignal_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtRemoveSignal(ulong id);

            // void: XtNoticeSignal XtSignalId:id  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtNoticeSignal_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtNoticeSignal(ulong id);

            // void: XtAppError XtAppContext:app_context  String:message  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppError_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern void XtAppError(IntPtr app_context, [MarshalAs(UnmanagedType.LPStr)] string message);

            // void: XtAppSetErrorHandler XtAppContext:app_context  XtErrorHandler:handler  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppSetErrorHandler_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAppSetErrorHandler(IntPtr app_context, [MarshalAs(UnmanagedType.FunctionPtr)] XtErrorHandler handler);

            // void: XtAppSetWarningHandler XtAppContext:app_context  XtErrorHandler:handler  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppSetWarningHandler_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAppSetWarningHandler(IntPtr app_context, [MarshalAs(UnmanagedType.FunctionPtr)] XtErrorHandler handler);

            // void: XtAppWarning XtAppContext:app_context  String:message  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppWarning_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern void XtAppWarning(IntPtr app_context, [MarshalAs(UnmanagedType.LPStr)] string message);

            // void: XtAppErrorMsg XtAppContext:app_context  String:name  String:type  String:class  String:default  String*:params  Cardinal*:num_params  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppErrorMsg_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern void XtAppErrorMsg(IntPtr app_context, 
                [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string type, 
                [MarshalAs(UnmanagedType.LPStr)] string glass, [MarshalAs(UnmanagedType.LPStr)] string befault, out IntPtr qarams, out IntPtr num_params);

            // void: XtAppSetErrorMsgHandler XtAppContext:app_context  XtErrorMsgHandler:msg_handler  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppSetErrorMsgHandler_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAppSetErrorMsgHandler(IntPtr app_context, [MarshalAs(UnmanagedType.FunctionPtr)] XtErrorMsgHandler msg_handler);

            // void: XtAppSetWarningMsgHandler XtAppContext:app_context  XtErrorMsgHandler:msg_handler  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppSetWarningMsgHandler_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAppSetWarningMsgHandler(IntPtr app_context, [MarshalAs(UnmanagedType.FunctionPtr)] XtErrorMsgHandler msg_handler);

            // void: XtAppWarningMsg XtAppContext:app_context  String:name  String:type  String:class  String:default  String*:params  Cardinal*:num_params  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppWarningMsg_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern void XtAppWarningMsg(IntPtr app_context,
                [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string type, 
                [MarshalAs(UnmanagedType.LPStr)] string qlass, [MarshalAs(UnmanagedType.LPStr)] string befault, out IntPtr qarams, out IntPtr num_params);

            // Widget: XtAppCreateShell String:application_name  String:application_class  WidgetClass:widget_class  Display*:display  ArgList:args  Cardinal:num_args  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppCreateShell_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr XtAppCreateShell([MarshalAs(UnmanagedType.LPStr)] string application_name, 
                [MarshalAs(UnmanagedType.LPStr)] string application_class, IntPtr widget_class, IntPtr display, IntPtr[] args, int num_args);

            // XrmDatabase*: XtAppGetErrorDatabase XtAppContext:app_context  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppGetErrorDatabase_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XtAppGetErrorDatabase(IntPtr app_context);

            // void: XtAppGetErrorDatabaseText XtAppContext:app_context  char*:name  char*:type  char*:class  char*:default  char*:buffer_return  int:nbytes  XrmDatabase:database  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppGetErrorDatabaseText_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern void XtAppGetErrorDatabaseText(IntPtr app_context, 
                [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string type, 
                [MarshalAs(UnmanagedType.LPStr)] string glass, 
                [MarshalAs(UnmanagedType.LPStr)] string befault, 
                [MarshalAs(UnmanagedType.LPArray)] out byte[] buffer_return, int nbytes, IntPtr database);

            // void: XtAppSetExitFlag XtAppContext:app_context  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppSetExitFlag_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAppSetExitFlag(IntPtr app_context);

            // Boolean: XtAppGetExitFlag XtAppContext:app_context  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppGetExitFlag_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XtAppGetExitFlag(IntPtr app_context);

            // unsigned long: XtAppGetSelectionTimeout XtAppContext:app_context  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppGetSelectionTimeout_TNK", CharSet = CharSet.Auto)]
            internal static extern ulong XtAppGetSelectionTimeout(IntPtr app_context);

            // void: XtAppSetSelectionTimeout XtAppContext:app_context  unsigned long:timeout  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppSetSelectionTimeout_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAppSetSelectionTimeout(IntPtr app_context, ulong timeout);

            // void: XtAppLock XtAppContext:app_context  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppLock_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAppLock(IntPtr app_context);

            // void: XtAppUnlock XtAppContext:app_context  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppUnlock_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAppUnlock(IntPtr app_context);

            // void: XtAppNextEvent XtAppContext:app_context  XEvent*:event_return  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppNextEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAppNextEvent(IntPtr app_context, [In, Out] IntPtr event_return);

            // Boolean: XtAppPeekEvent XtAppContext:app_context  XEvent*:event_return  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppPeekEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XtAppPeekEvent(IntPtr app_context, [In,Out] IntPtr event_return);

            // XtInputMask: XtAppPending XtAppContext:app_context  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppPending_TNK", CharSet = CharSet.Auto)]
            internal static extern XtInputMask XtAppPending(IntPtr app_context);

            // void: XtAppProcessEvent XtAppContext:app_context  XtInputMask:mask  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppProcessEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAppProcessEvent(IntPtr app_context, XtInputMask mask);

            // void: XtAppMainLoop XtAppContext:app_context  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAppMainLoop_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAppMainLoop(IntPtr app_context);

            /*
            // Boolean: XtDispatchEvent XEvent*:event  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtDispatchEvent_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XtDispatchEvent([In]IntPtr fvent);

            // void: XtAugmentTranslations Widget:w XtTranslations:translations
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtAugmentTranslations_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtAugmentTranslations(IntPtr w, IntPtr translations);

            // void: XtOverrideTranslations Widget:w XtTranslations:translations
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtOverrideTranslations_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtOverrideTranslations(IntPtr w, IntPtr translations);

            // void: XtUninstallTranslations Widget:w
            [DllImport(ExtremeSports.Lib, EntryPoint = "XtUninstallTranslations_TNK", CharSet = CharSet.Auto)]
            internal static extern void XtUninstallTranslations(IntPtr w);
            */

        }
        #endregion

        #region staticおじさん
        public static IntPtr XtAppCreateShell(string application_name, string application_class, IntPtr widget_class, IntPtr display, IntPtr[] args) {
            return NativeMethods.XtAppCreateShell(application_name, application_class, widget_class, display, args, args.Length);
        }
        #endregion


        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        internal XtAppContext(IntPtr ptr) {
            handle = ptr;
        }


        void xtTimerCallbackProc(
            XtTimerCallbackDelegate closure, //XtPointer
            IntPtr id //XtIntervalId*
        ) {
            closure((ulong)Marshal.ReadInt64(id));
        }

        public ulong AddTimeOut(long interval, XtTimerCallbackDelegate proc) {
            return NativeMethods.XtAppAddTimeOut(this.handle, interval, xtTimerCallbackProc, proc);
        }

        public void RemoveTimeOut(ulong timer) {
            NativeMethods.XtRemoveTimeOut(timer);
        }

        public ulong AddInput(int source, IntPtr condition, XtInputCallbackProc proc, IntPtr client_data) {
            return NativeMethods.XtAppAddInput(this.handle, source, condition, proc, client_data);
        }

        public ulong AddInput(IntPtr app_context, int source, XtInputMask condition, XtInputCallbackProc proc, IntPtr client_data) {
            return NativeMethods.XtAppAddInput(this.handle, source, (IntPtr)condition, proc, client_data);
        }

        public void RemoveInput(ulong id) {
            NativeMethods.XtRemoveInput(id);
        }

        public ulong AddWorkProc(XtWorkProc proc, IntPtr client_data) {
            return NativeMethods.XtAppAddWorkProc(this.handle, proc, client_data);
        }

        public void RemoveWorkProc(ulong id) {
            NativeMethods.XtRemoveWorkProc(id);
        }

        public ulong AddBlockHook(XtBlockHookProc proc, IntPtr client_data) {
            return NativeMethods.XtAppAddBlockHook(this.handle, proc, client_data);
        }

        public void RemoveBlockHook(ulong id) {
            NativeMethods.XtRemoveBlockHook(id);
        }

        public ulong AddSignal(XtSignalCallbackProc proc, IntPtr client_data) {
            return NativeMethods.XtAppAddSignal(this.handle, proc, client_data);
        }

        public void RemoveSignal(ulong id) {
            NativeMethods.XtRemoveSignal(id);
        }

        public void NoticeSignal(ulong id) {
            NativeMethods.XtNoticeSignal(id);
        }

        public void Error(string message) {
            NativeMethods.XtAppError(this.handle, message);
        }

        public void SetErrorHandler(XtErrorHandler handler) {
            NativeMethods.XtAppSetErrorHandler(this.handle, handler);
        }

        public void SetWarningHandler(XtErrorHandler handler) {
            NativeMethods.XtAppSetWarningHandler(this.handle, handler);
        }

        public void Warning(string message) {
            NativeMethods.XtAppWarning(this.handle, message);
        }
        public void XtAppErrorMsg(string name, string type, string glass,string befault) {
            IntPtr qarams = IntPtr.Zero;
            IntPtr num_qarams = IntPtr.Zero;
            NativeMethods.XtAppErrorMsg(this.handle, name, type, glass, befault, out qarams, out num_qarams);

            throw new NotImplementedException();
        }

        public void SetErrorMsgHandler(XtErrorMsgHandler msg_handler) {
            NativeMethods.XtAppSetErrorMsgHandler(this.handle, msg_handler);
        }

        public void SetWarningMsgHandler(XtErrorMsgHandler msg_handler) {
            NativeMethods.XtAppSetWarningMsgHandler(this.handle, msg_handler);
        }

        public void WarningMsg(string name, string type, string glass, string befault) {
            IntPtr qarams = IntPtr.Zero;
            IntPtr num_qarams = IntPtr.Zero;
            NativeMethods.XtAppWarningMsg(this.handle, name, type, glass, befault, out qarams, out num_qarams);

            throw new NotImplementedException();
        }

        public void SetExitFlag() {
            NativeMethods.XtAppSetExitFlag(this.handle);
        }

        public bool GetExitFlag() {
            return NativeMethods.XtAppGetExitFlag(this.handle);
        }

        public ulong GetSelectionTimeout() {
            return NativeMethods.XtAppGetSelectionTimeout(this.handle);
        }

        public void SetSelectionTimeout(ulong timeout) {
            NativeMethods.XtAppSetSelectionTimeout(this.handle, timeout);
        }

        public void Lock() {
            NativeMethods.XtAppLock(this.Handle);
        }

        public void Unlock() {
            NativeMethods.XtAppUnlock(this.Handle);
        }
        

        public void NextEvent(TonNurako.X11.Event.XEventArg event_return) {
            NativeMethods.XtAppNextEvent(this.Handle, event_return.handle);
            event_return.Assign();
        }

        public bool PeekEvent(TonNurako.X11.Event.XEventArg event_return) {
            var r = NativeMethods.XtAppPeekEvent(this.Handle, event_return.handle);
            event_return.Assign();
            return r;
        }

        public XtInputMask Pending() {
            return NativeMethods.XtAppPending(this.Handle);
        }

        public void ProcessEvent(XtInputMask mask) {
            NativeMethods.XtAppProcessEvent(this.Handle, mask);
        }

        //public static bool XtDispatchEvent(TonNurako.X11.Event.XEvent event) {
        //    return NativeMethods.XtDispatchEvent(event);
        //}

        public void AppMainLoop() {
            NativeMethods.XtAppMainLoop(this.Handle);
        }


        public Xrm.XrmDatabase XtAppGetErrorDatabase() {
            return (new Xrm.XrmDatabase(NativeMethods.XtAppGetErrorDatabase(this.handle), false));
        }

        public string XtAppGetErrorDatabaseText(string name, string type, string glass, string befault, Xrm.XrmDatabase database) {
            byte[] buffer_return = new byte[1024]; // TODO
            int nbytes = buffer_return.Length - 1;
            NativeMethods.XtAppGetErrorDatabaseText(this.handle, name, type, glass, befault, out buffer_return, nbytes, database.Handle);
            return System.Text.Encoding.ASCII.GetString(buffer_return);
        }


    }
}
