using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.Widgets;

namespace TonNurako.Xt.Core {
        
    [StructLayout(LayoutKind.Sequential)]
    internal struct CoreClassPart {
        public IntPtr superclass;     // WidgetClassRec
        [MarshalAs(UnmanagedType.LPStr)] public string class_name;
        public int widget_size;   // Cardinal
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtProc class_initialize;
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtWidgetClassProc class_part_initialize;
        public byte class_inited;     // XtEnum
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtInitProc initialize;
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtArgsProc initialize_hook;
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtRealizeProc realize;
        public IntPtr actions;  // XtActionList
        public int num_actions; //Cardinal
        public IntPtr resources;  // XtResource*
        public int num_resources;
        public int xrm_class;     // XrmClass
        [MarshalAs(UnmanagedType.U1)] public bool compress_motion;
        public byte compress_exposure;  //XtEnum
        [MarshalAs(UnmanagedType.U1)] public bool compress_enterleave;
        [MarshalAs(UnmanagedType.U1)] public bool visible_interest;
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtWidgetProc destroy;
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtWidgetProc resize;
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtExposeProc expose;
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtSetValuesFunc set_values;
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtArgsProc set_values_hook;
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtAlmostProc set_values_almost;
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtArgsProc get_values_hook;
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtAcceptFocusProc accept_focus;
        public ulong version;  //XtVersionType
        public IntPtr callback_private; //XtPointer
        public IntPtr tm_table;
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtGeometryHandler query_geometry;
        [MarshalAs(UnmanagedType.FunctionPtr)] public XtStringProc display_accelerator;
        public IntPtr extension;     // IntPtr
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct WidgetClass {
        public CoreClassPart core_class;
        public ulong dummy;
    }


    [StructLayout(LayoutKind.Sequential)]
    internal struct XtInheritTNK {
        public IntPtr InheritTranslations;
        public XtRealizeProc InheritRealize;
        public XtWidgetProc InheritResize;
        public XtExposeProc InheritExpose;
        public XtAlmostProc InheritSetValuesAlmost;
        public XtAcceptFocusProc InheritAcceptFocus;
        public XtGeometryHandler InheritQueryGeometry;
        public XtStringProc InheritDisplayAccelerator;
    }

    public class CoreWidgetClass : IDisposable {
        internal static class NativeMethods {
            // WidgetClass*: TNK_GetUltraSuperWidgetClass
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetUltraSuperWidgetClass", CharSet = CharSet.Auto)]
            internal static extern IntPtr TNK_GetUltraSuperWidgetClass();

            // void: TNK_GetXtInheritance XtInheritTNK*:p
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetXtInheritance", CharSet = CharSet.Auto)]
            internal static extern void TNK_GetXtInheritance(ref XtInheritTNK p);

            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_InitializeXtWidgetClass", CharSet = CharSet.Auto)]
            internal static extern void TNK_InitializeXtWidgetClass(ref CoreClassPart p);

        }
        public static CoreWidgetClass GetDefaultSuperClass() {
            var inh = new XtInheritTNK();
            NativeMethods.TNK_GetXtInheritance(ref inh);
            var p = NativeMethods.TNK_GetUltraSuperWidgetClass();
            return (new CoreWidgetClass(p));
        }

        public CoreWidgetClass() {
            isPounterAllocated = true;
            pounter = Marshal.AllocCoTaskMem(Marshal.SizeOf<WidgetClass>());
            Record = new WidgetClass();
            NativeMethods.TNK_InitializeXtWidgetClass(ref Record.core_class);
            WidgetSize = Marshal.SizeOf<WidgetClass>();
        }

        internal CoreWidgetClass(IntPtr ptr) {
            isPounterAllocated = false;
            Record = Marshal.PtrToStructure<WidgetClass>(ptr);
            pounter = ptr;
            if (IntPtr.Zero != Record.core_class.superclass) {
                superClass = new CoreWidgetClass(Record.core_class.superclass);
            }
        }

        internal IntPtr SuperClassPtr = IntPtr.Zero;

        bool isPounterAllocated = false;
        IntPtr pounter;
        internal IntPtr Pounter {
            get {
                if (isPounterAllocated) {
                    Marshal.StructureToPtr<WidgetClass>(Record, pounter, false);
                }
                return pounter;
            }
        }

        internal WidgetClass Record;
        CoreWidgetClass superClass = null;
        public CoreWidgetClass SuperClass {
            get => superClass;
            set {
                superClass = value;
                Record.core_class.superclass = value.Pounter;
            }
        }

        public string ClassName {
            get => Record.core_class.class_name;
            set => Record.core_class.class_name = value;
        }
        public int WidgetSize {
            get => Record.core_class.widget_size;
            set => Record.core_class.widget_size = value;
        }

        public XtProc ClassInitialize {
            get => Record.core_class.class_initialize;
            set => Record.core_class.class_initialize = value;
        }


        XtWidgetClassDelegate classPartInitialize = null;
        private void xtClassPartInitializeImp(IntPtr widgetClass) {
            if (null == classPartInitialize) {
                return;
            }
            //Console.WriteLine("Call: " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            classPartInitialize(new CoreWidgetClass(widgetClass));
        }

        public XtWidgetClassDelegate ClassPartInitialize {
            get => classPartInitialize;//Record.core_class.class_part_initialize;
            set {
                classPartInitialize = value;
                if (null != value) {
                    Record.core_class.class_part_initialize = xtClassPartInitializeImp;
                }
                else {
                    Record.core_class.class_part_initialize = null;
                }
            }
        }


        public byte ClassInited {
            get => Record.core_class.class_inited;
            set => Record.core_class.class_inited = value;
        }

        void XtInitProcImp(
          IntPtr request, // Widget
          IntPtr xnew, // Widget
          IntPtr argList, //,
          IntPtr num_args //Cardinal*
        ) {
            if (null == xtInitialize) {
                return;
            }
            //Console.WriteLine("Call: " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            xtInitialize(
                new ﾄﾝﾇﾗｼﾞｪｯﾄ(request, null),
                new ﾄﾝﾇﾗｼﾞｪｯﾄ(xnew, null),
                ConvertArgList(argList, num_args));
        }

        XtInitDelegate xtInitialize;
        public XtInitDelegate Initialize {
            get => xtInitialize;
            set {
                xtInitialize = value;
                if (null != value) {
                    Record.core_class.initialize = XtInitProcImp;
                }
                else {
                    Record.core_class.initialize = null;
                }

            }
        }

        XtArg[] ConvertArgList(IntPtr argList, IntPtr num_args) {
            if (argList == IntPtr.Zero) {
                return null;
            }
            int cnt = Marshal.ReadInt32(num_args);
            var ret = new XtArg[cnt];
            var arr = TonNurako.Inutility.MarshalHelper.ToStructArray<XtArgRec>(argList, cnt);
            for (int i = 0; i < cnt; ++i) {
                ret[i] = new XtArg(arr[i]);
            }
            return ret;
        }

        XtArgsDelegate initializeHook;
        private void xtInitializeHookImp(IntPtr widget, IntPtr argList, IntPtr num_args) {
            if (null == setValuesHook) {
                return;
            }

            //Console.WriteLine("Call: " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            initializeHook(new ﾄﾝﾇﾗｼﾞｪｯﾄ(widget, null), ConvertArgList(argList, num_args));
        }

        public XtArgsDelegate InitializeHook {
            get => initializeHook; // Record.core_class.set_values_hook;
            set {
                initializeHook = value;
                if (null != value) {
                    Record.core_class.initialize_hook = xtInitializeHookImp;
                }
                else {
                    Record.core_class.initialize_hook = null;
                }
            }
        }


        void xtRealizeImp(
              IntPtr widget,
              IntPtr mask, //XtValueMask*
              IntPtr attributes //XSetWindowAttributes
          ) {
            //IWidget widget,
            //X11.ChangeWindowAttributes mask, //XtValueMask*
            //X11.XSetWindowAttributes attributes //XSetWindowAttributes
            if (null == xtRealize) {
                return;
            }
            //Console.WriteLine("Call: " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            xtRealize(new ﾄﾝﾇﾗｼﾞｪｯﾄ(widget, null),
                (X11.ChangeWindowAttributes)Marshal.ReadInt32(mask), new X11.XSetWindowAttributes(attributes));
        }

        XtRealizeDelegate xtRealize;
        public XtRealizeDelegate Realize {
            get => xtRealize;//Record.core_class.realize;
            set {
                if (null != value) {
                    xtRealize = value;
                    Record.core_class.realize = xtRealizeImp;
                }
                else {
                    Record.core_class.realize = null;
                }
            }
        }



        public IntPtr Actions {
            get => Record.core_class.actions;
            set => Record.core_class.actions = value;
        }
        public int NumActions {
            get => Record.core_class.num_actions;
            set => Record.core_class.num_actions = value;
        }
        public IntPtr Resources {
            get => Record.core_class.resources;
            set => Record.core_class.resources = value;
        }
        public int NumResources {
            get => Record.core_class.num_resources;
            set => Record.core_class.num_resources = value;
        }
        public int XrmClass {
            get => Record.core_class.xrm_class;
            set => Record.core_class.xrm_class = value;
        }
        public bool CompressMotion {
            get => Record.core_class.compress_motion;
            set => Record.core_class.compress_motion = value;
        }
        public byte CompressExposure {
            get => Record.core_class.compress_exposure;
            set => Record.core_class.compress_exposure = value;
        }
        public bool CompressEnterleave {
            get => Record.core_class.compress_enterleave;
            set => Record.core_class.compress_enterleave = value;
        }
        public bool VisibleInterest {
            get => Record.core_class.visible_interest;
            set => Record.core_class.visible_interest = value;
        }

        void xtDestroyImp(IntPtr widget){
            if (null == xtDestroy) {
                return;
            }

            //Console.WriteLine("Call: " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            xtDestroy(new ﾄﾝﾇﾗｼﾞｪｯﾄ(widget, null));
        }
        XtWidgetDelegate xtDestroy;
        public XtWidgetDelegate Destroy {
            get => xtDestroy;
            set {
                xtDestroy = value;
                if (null != xtDestroy) {
                    Record.core_class.destroy = xtDestroyImp;
                }
                else {
                    Record.core_class.destroy = null;
                }
            }
        }

        void xtResizeImp(IntPtr widget) {
            if (null == xtResize) {
                return;
            }
            //Console.WriteLine("Call: " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            xtResize(new ﾄﾝﾇﾗｼﾞｪｯﾄ(widget, null));
        }
        XtWidgetDelegate xtResize;
        public XtWidgetDelegate Resize {
            get => xtResize; // Record.core_class.resize;
            set {
                xtResize = value;
                if (null != xtResize) {
                    Record.core_class.resize =  xtResizeImp;
                }
                else {
                    Record.core_class.resize = null;
                }
            }
        }


        void xtExposeImp(
              IntPtr widget,
              IntPtr xevent, //XEvent
              IntPtr region // Region
          ) {
            //Console.WriteLine("Call: " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            xtExpose(new ﾄﾝﾇﾗｼﾞｪｯﾄ(widget, null),
                new X11.Event.XEventArg(xevent),
                new X11.Region(region));
        }

        XtExposeDelegate xtExpose;
        public XtExposeDelegate Expose {
            get => xtExpose;
            set {
                xtExpose = value;
                if (null != xtResize) {
                    Record.core_class.expose = xtExposeImp;
                }
                else {
                    Record.core_class.expose = null;
                }
            }
        }


        bool xtSetValuesImp(
            IntPtr old, // Widget
            IntPtr request,// Widget
            IntPtr xnew,// Widget
            IntPtr args, //ArgList
            IntPtr num_args // Cardinal*
        ) {
            //Console.WriteLine("Call: " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return xtSetValues(new ﾄﾝﾇﾗｼﾞｪｯﾄ(old, null),
                new ﾄﾝﾇﾗｼﾞｪｯﾄ(request, null),
                new ﾄﾝﾇﾗｼﾞｪｯﾄ(xnew, null),
                ConvertArgList(args, num_args));
        }

        XtSetValuesDelegate xtSetValues;
        public XtSetValuesDelegate SetValues {
            get => xtSetValues;//Record.core_class.set_values;
            set  {
                xtSetValues = value;
                if (null != xtSetValues) {
                    Record.core_class.set_values = xtSetValuesImp;
                }
                else {
                    Record.core_class.set_values = null;
                }
            }
        }


        XtArgsDelegate setValuesHook;
        private void xtSetValuesHookImp(IntPtr widget, IntPtr argList, IntPtr num_args) {
            if (null == setValuesHook) {
                return;
            }
            //Console.WriteLine("Call: " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            setValuesHook(new ﾄﾝﾇﾗｼﾞｪｯﾄ(widget, null), ConvertArgList(argList, num_args));
        }

        public XtArgsDelegate SetValuesHook {
            get => setValuesHook; // Record.core_class.set_values_hook;
            set {
                setValuesHook = value;
                if (null != value) {
                    Record.core_class.set_values_hook = xtSetValuesHookImp;
                }
                else {
                    Record.core_class.set_values_hook = null;
                }
            }
        }


        void xtSetValuesAlmostImp(
              IntPtr old, //Widget
              IntPtr xnew, //Widget
              IntPtr request, //XtWidgetGeometry*
              IntPtr reply //XtWidgetGeometry*
          ) {
            //XtWidgetGeometry XtAlmostDelegate(
            //IWidget old, //Widget
            //IWidget xnew, //Widget
            //XtWidgetGeometry request //XtWidgetGeometry*
            //Console.WriteLine("Call: " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            // TODO:replyへのﾏーｼｬﾘﾝｸﾞ
            var k = xtSetValuesAlmost(new ﾄﾝﾇﾗｼﾞｪｯﾄ(old, null), new ﾄﾝﾇﾗｼﾞｪｯﾄ(xnew, null), new XtWidgetGeometry(request));
            throw new NotImplementedException("replyできてない");
        }

        XtAlmostDelegate xtSetValuesAlmost;
        public XtAlmostDelegate SetValuesAlmost {
            get => xtSetValuesAlmost;
            set {
                xtSetValuesAlmost = value;
                if (null != value) {
                    Record.core_class.set_values_almost = xtSetValuesAlmostImp;
                }
                else {
                    Record.core_class.set_values_almost = null;
                }
            }
        }

        XtArgsDelegate getValuesHook;
        private void xtGetValuesHookImp(IntPtr widget, IntPtr argList, IntPtr num_args) {
            if (null == getValuesHook) {
                return;
            }
            //Console.WriteLine("Call: " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            getValuesHook(new ﾄﾝﾇﾗｼﾞｪｯﾄ(widget, null), ConvertArgList(argList, num_args));
        }
        public XtArgsDelegate GetValuesHook {
            get => getValuesHook;
            set {
                getValuesHook = value;
                if (null != value) {
                    Record.core_class.get_values_hook = xtGetValuesHookImp;
                }
                else {
                    Record.core_class.get_values_hook = null;
                }
            }
        }

        bool xtAcceptFocusImp(
           IntPtr widget, //Widget
           IntPtr time // Time*
        ) {
            //Console.WriteLine("Call: " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return xtAcceptFocus(new ﾄﾝﾇﾗｼﾞｪｯﾄ(widget, null), Marshal.ReadInt32(time));
        }

        XtAcceptFocusDelegate xtAcceptFocus;
        public XtAcceptFocusDelegate AcceptFocus {
            get => xtAcceptFocus;
            set {
                xtAcceptFocus = value;
                if (null != value) {
                    Record.core_class.accept_focus = xtAcceptFocusImp;
                }
                else {
                    Record.core_class.accept_focus = null;
                }
            }
        }


        public ulong Version {
            get => Record.core_class.version;
            set => Record.core_class.version = value;
        }

        public IntPtr CallbackPrivate {
            get => Record.core_class.callback_private;
            set => Record.core_class.callback_private = value;
        }

        public IntPtr TmTable {
            get => Record.core_class.tm_table;
            set => Record.core_class.tm_table = value;
        }


        void xtQueryGeometryImp(
              IntPtr widget, //Widget
              IntPtr request, //XtWidgetGeometry*
              IntPtr reply //XtWidgetGeometry*
          ) {
            //IWidget widget, //Widget
            //XtWidgetGeometry request, //XtWidgetGeometry*
            //XtWidgetGeometry reply //XtWidgetGeometry*
            //Console.WriteLine("Call: " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            xtQueryGeometry(new ﾄﾝﾇﾗｼﾞｪｯﾄ(widget, null),
                new XtWidgetGeometry(request));
            throw new NotImplementedException("replyできてない");
        }

        XtGeometryHandlerDelegate xtQueryGeometry;
        public XtGeometryHandlerDelegate QueryGeometry {
            get => xtQueryGeometry;
            set {
                xtQueryGeometry = value;
                if (null != value) {
                    Record.core_class.query_geometry = xtQueryGeometryImp;
                }
                else {
                    Record.core_class.query_geometry = null;
                }
            }
        }


        //
        // String
        //
        void xtDisplayAcceleratorImp(
              IntPtr widget,//Widget
              IntPtr str //String
        ) {
            //Console.WriteLine("Call: " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            xtDisplayAccelerator(new ﾄﾝﾇﾗｼﾞｪｯﾄ(widget, null), Marshal.PtrToStringAnsi(str));
        }

        XtStringProcDelegate xtDisplayAccelerator;

        public XtStringProcDelegate DisplayAccelerator {
            get => xtDisplayAccelerator;
            set {
                xtDisplayAccelerator = value;
                if (null != value) {
                    Record.core_class.display_accelerator = xtDisplayAcceleratorImp;
                }
                else {
                    Record.core_class.display_accelerator = null;
                }
            }
        }


        public IntPtr Extension {
            get => Record.core_class.extension;
            set => Record.core_class.extension = value;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;

                if (null != superClass) {
                    superClass.Dispose();
                    superClass = null;
                }

                if (isPounterAllocated && IntPtr.Zero != Pounter) {
                    Marshal.FreeCoTaskMem(pounter);
                    pounter = IntPtr.Zero;
                }
            }
        }

        // ~Region() {
        //   Dispose(false);
        // }

        public void Dispose() {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

}
