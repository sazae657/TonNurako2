//
// ﾄﾝﾇﾗｺ
//
// XToolkit
//
using System;
using System.Runtime.InteropServices;

//
// Xt周り
//
namespace TonNurako.Xt {
    /// <summary>
    /// CallBack
    /// </summary>
    public sealed class G {
        /// <summary>
        /// 汎用ｺーﾙﾊﾞｯｸ
        /// </summary>
        //public delegate void XtCallBack(IntPtr w, IntPtr client, IntPtr call);

        /// <summary>
        /// List widgetの選択項目列挙用
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ListEnumCallback(int count, IntPtr list);

        /// <summary>
	    /// EventHandler
	    /// </summary>
        //public delegate void XtEventHandler(IntPtr widget, IntPtr closure, IntPtr xevent, IntPtr continue_to_dispatch);
    }

    /// <summary>
    /// Extremesports - TonNurakoのﾃﾞーﾀﾀｲﾌﾟ
    /// </summary>
    public enum XtArgType {
        Undefined = 0,
        Int = 1,
        UInt = 2,
        Long = 3,
        ULong = 4,
        Object = 5,

        String = 6,
        CompoundString = 7,
        Color = 8,
        Callback = 9

    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XtWidgetGeometryRec {
        public XtGeometryMask request_mode; // XtGeometryMask
        public Int16 x; // Position
        public Int16 y; // Position
        public int width; // Dimension
        public int height; // Dimension
        public int border_width; // Dimension
        internal IntPtr sibling; // Widget
        public XtStackMode stack_mode; // int
    }

    public class XtWidgetGeometry {
        internal XtWidgetGeometryRec Record;

        internal XtWidgetGeometry(IntPtr ptr) {
            Record = Marshal.PtrToStructure<XtWidgetGeometryRec>(ptr);
        }
        internal XtWidgetGeometry(XtWidgetGeometryRec rec) {
            Record = rec;
        }

        public XtGeometryMask RequestMode {
            get => Record.request_mode;
            set => Record.request_mode = value;
        }
        public Int16 X {
            get => Record.x;
            set => Record.x = value;
        }
        public Int16 Y {
            get => Record.y;
            set => Record.y = value;
        }
        public int Width {
            get => Record.width;
            set => Record.width = value;
        }
        public int Height {
            get => Record.height;
            set => Record.height = value;
        }
        public int BorderWidth {
            get => Record.border_width;
            set => Record.border_width = value;
        }
        //public IntPtr Sibling {
        //    get => Record.sibling;
        //    set => Record.sibling = value;
        //}
        public XtStackMode StackMode {
            get => Record.stack_mode;
            set => Record.stack_mode = value;
        }
    }



    /// <summary>
    /// Arg 相当
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct XtArgRec {
        internal IntPtr Name ;
        internal IntPtr Value;
    }
    public class XtArg {
        internal XtArgRec Record;
        internal XtArg(XtArgRec rec) {
            Record = rec;
        }
    }


    /// <summary>
    /// ExtremeSportsにﾘｿーｽの処理を強要する用
    /// 共用体にしたかったけど無理だった
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Arg
    {
        [MarshalAs(UnmanagedType.LPStr)] public string name ;

        XtArgType type ;

        internal int intVal;
        internal uint uintVal;
        internal long longVal;
        internal ulong ulongVal;
        internal IntPtr ptrVal;

        [MarshalAs(UnmanagedType.LPStr)] public string strVal;
        internal IntPtr compoundStr;

        public ulong color;

        public XtCallbackProc callback;

        public Arg(string _Name, int _Val) {
            name = _Name;
            intVal  = _Val;
            type = XtArgType.Int;

            longVal = 0;
            uintVal = 0;
            ulongVal = 0;
            ptrVal = IntPtr.Zero;
            strVal = "";

            compoundStr = IntPtr.Zero;

            color = 0;
            callback = null;

        }
        public Arg(string _Name, uint _Val) {
            name = _Name;
            uintVal  = _Val;
            type = XtArgType.UInt;

            longVal = 0;
            intVal = 0;
            ulongVal = 0;
            ptrVal = IntPtr.Zero;
            strVal = "";
            compoundStr = IntPtr.Zero;
            color = 0;
            callback = null;
        }

        public Arg(string _Name, long _Val) {
            name = _Name;
            longVal  = _Val;
            type = XtArgType.Long;

            uintVal = 0;
            intVal = 0;
            ulongVal = 0;
            ptrVal = IntPtr.Zero;
            strVal = "";
            compoundStr = IntPtr.Zero;
            color = 0;
            callback = null;
        }

        public Arg(string _Name, ulong _Val) {
            name = _Name;
            ulongVal  = _Val;
            type = XtArgType.ULong;

            uintVal = 0;
            intVal = 0;
            longVal = 0;
            ptrVal = IntPtr.Zero;
            strVal = "";
            compoundStr = IntPtr.Zero;
            color = 0;
            callback = null;
        }

        public Arg(string _Name, IntPtr _Val) {
            name = _Name;
            ptrVal = _Val;
            type = XtArgType.Object;

            longVal = 0;
            uintVal = 0;
            ulongVal = 0;
            intVal = 0;
            strVal = "";
            compoundStr = IntPtr.Zero;

            color = 0;
            callback = null;
        }

        public Arg(string _Name, string _Val) {
            name = _Name;
            strVal = _Val;
            type = XtArgType.String;

            longVal = 0;
            uintVal = 0;
            ulongVal = 0;
            intVal = 0;
            ptrVal = IntPtr.Zero;
            compoundStr = IntPtr.Zero;

            color = 0;
            callback = null;
        }
        public Arg(string _Name, Data.CompoundString _Val) {
            name = _Name;
            compoundStr = _Val.Handle;
            type = XtArgType.CompoundString;

            longVal = 0;
            uintVal = 0;
            ulongVal = 0;
            intVal = 0;
            ptrVal = IntPtr.Zero;
            strVal = "";
            color = 0;
            callback = null;
        }

        public Arg(string _Name, TonNurako.X11.XColor _Val) {
            name = _Name;
            color = _Val.Pixel;

            type = XtArgType.Color;

            compoundStr = IntPtr.Zero;
            longVal = 0;
            uintVal = 0;
            ulongVal = 0;
            intVal = 0;
            strVal = "";
            ptrVal = IntPtr.Zero;
            callback = null;
        }

        public Arg(string _Name, XtCallbackProc _Val) {
            name = _Name;
            callback = _Val;
            type = XtArgType.Callback;

            compoundStr = IntPtr.Zero;
            longVal = 0;
            uintVal = 0;
            ulongVal = 0;
            intVal = 0;
            strVal = "";
            ptrVal = IntPtr.Zero;
            color = 0;
        }

        /// <summary>
        /// ﾘｿーｽ文字列にする(ﾎﾟｲﾝﾀーとかは無視)
        /// </summary>
        /// <returns></returns>
        public string ToXrmString() {
            string ret = name + ": ";
            switch(type) {
                case XtArgType.Int:
                    ret += intVal.ToString();
                    break;

                case XtArgType.UInt:
                    ret += uintVal.ToString();
                    break;

                case XtArgType.Long:
                    ret += longVal.ToString();
                    break;

                case XtArgType.ULong:
                    ret += ulongVal.ToString();
                    break;

                case XtArgType.Object:
                    return null;

                case XtArgType.String:
                    ret += strVal;
                    break;

                case XtArgType.CompoundString:
                    ret += Data.CompoundString.AsString(this.compoundStr);
                    break;
                case XtArgType.Undefined:
                case XtArgType.Callback:
                default:
                    return null;
            }
            return ret.Replace("\n", @"\n");
        }
    }



}
