using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11 {

    public enum XICCEncodingStyle  {
        XStringStyle = TonNurako.X11.Constant.XStringStyle,
        XCompoundTextStyle = TonNurako.X11.Constant.XCompoundTextStyle,
        XTextStyle = TonNurako.X11.Constant.XTextStyle,
        XStdICCTextStyle = TonNurako.X11.Constant.XStdICCTextStyle,
        XUTF8StringStyle = TonNurako.X11.Constant.XUTF8StringStyle,
    }


    [StructLayout(LayoutKind.Sequential)]
    internal struct XTextPropertyRec {
        public IntPtr value;
        public ulong encoding; // ATOM
        public int format;
        public ulong nitems;
    }

    public class XTextProperty : IX11Interop, IDisposable {
        enum TextPropEncode {
            Mb,
            Wchar
        }
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "XwcTextListToTextProperty_TNK", CharSet = CharSet.Auto)]
            internal static extern int XwcTextListToTextProperty(
                IntPtr display, IntPtr list, int count, XICCEncodingStyle style, ref XTextPropertyRec text_prop_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XmbTextPropertyToTextList_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XmbTextPropertyToTextList(IntPtr display, ref XTextPropertyRec text_prop, out IntPtr list_return, out int count_return);

            // TODO: UTF-32の上手いﾏーｼｬﾘﾝｸﾞ方法思いついたら替える
            //[DllImport(ExtremeSports.Lib, EntryPoint = "XwcTextPropertyToTextList_TNK", CharSet = CharSet.Auto)]
            //internal static extern int XwcTextPropertyToTextList(IntPtr display, ref XTextPropertyRec text_prop, out IntPtr list_return, out int count_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XwcFreeStringList_TNK", CharSet = CharSet.Auto)]
            internal static extern void XwcFreeStringList([In] IntPtr list);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFreeStringList_TNK", CharSet = CharSet.Auto)]
            internal static extern void XFreeStringList([In] IntPtr list);

           [DllImport(Native.ExtremeSports.Lib, EntryPoint="TNK_CreateCompoundTextProperty", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern int TNK_CreateCompoundTextProperty(
                        [In,Out]ref XTextPropertyRec tprop,
                        IntPtr display,
                        [MarshalAs(UnmanagedType.LPStr)]string text
                        );

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="TNK_FreeCompoundTextProperty", CharSet=CharSet.Auto)]
            internal static extern void TNK_FreeCompoundTextProperty([In,Out]ref XTextPropertyRec tprop);

        }

        //TextPropEncode encode = TextPropEncode.Mb;

        internal XTextPropertyRec record;

        public XTextProperty() {
            record = new XTextPropertyRec();
        }

        public string[] TextPropertyToTextList(Display display) {
            int count = 0;
            IntPtr list;

            NativeMethods.XmbTextPropertyToTextList(display.Handle, ref record, out list , out count);
            if (count == 0) {
                return null;
            }

            var arr = new IntPtr[count];
            var ret = new string[count];
            Marshal.Copy(list, arr, 0, count);
            for (int i = 0; i < count; ++i) {
                ret[i] = Marshal.PtrToStringAnsi(arr[i]);
            }
            NativeMethods.XFreeStringList(list);
            return ret;
        }

        public IntPtr Handle {
            get {return record.value;}
        }

        public ulong Encoding {
            get {return record.encoding;}
        }
        public int Format {
            get {return record.format;}
        }

        public ulong Items {
            get {return record.nitems;}
        }


        /*public int Create(Display dpy, string text) {
            var result = NativeMethods.TNK_CreateCompoundTextProperty(ref textProperty, dpy.Handle, text);
            return result;
        }*/

        public static XTextProperty Create(Display dpy, string text) {
            var k = new XTextProperty();
            NativeMethods.TNK_CreateCompoundTextProperty(ref k.record, dpy.Handle, text);
            return k;
        }

        public static XTextProperty Create(TonNurako.Widgets.IWidget widget, string text) {
            return Create(widget.Handle.Display, text);
        }

        public static XTextProperty TextListToTextProperty(Display dpy, string [] list, XICCEncodingStyle style) {
            var r = new XTextProperty();
            //r.Encode = TextPropEncode.Wchar;

            var arr = new IntPtr[list.Length+1];
            for (int i = 0; i < list.Length; ++i) {
                byte[] b =
                    System.Text.Encoding.Convert(
                        System.Text.Encoding.Default, System.Text.Encoding.UTF32, System.Text.Encoding.Default.GetBytes(list[i]));

                arr[i] = Marshal.AllocCoTaskMem(b.Length+1);
                Marshal.Copy(b, 0, arr[i], b.Length);
            }
            arr[list.Length] = IntPtr.Zero;
            var addrOfArray = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(IntPtr)) * arr.Length);
            Marshal.Copy(arr, 0, addrOfArray, arr.Length);

            int k = NativeMethods.XwcTextListToTextProperty(dpy.Handle, addrOfArray, 1, style, ref r.record);

            for (int i = 0; i < arr.Length; ++i) {
                if (arr[i] != IntPtr.Zero) {
                    Marshal.FreeCoTaskMem(arr[i]);
                }
            }
            Marshal.FreeCoTaskMem(addrOfArray);

            return r;
        }

       #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue) {
                return;
            }
            if(IntPtr.Zero != record.value) {
                NativeMethods.TNK_FreeCompoundTextProperty(ref record);
                record.value = IntPtr.Zero;
            }

            System.Diagnostics.Debug.WriteLine("Dispose:" + this.ToString());

            disposedValue = true;
        }


        public void Dispose()
        {
            Dispose(true);
            #if RLE
            System.GC.SuppressFinalize(this);
            #endif
        }

        #if RLE
        ~XTextProperty() {
            if (IntPtr.Zero != record.value) {
                throw new ResourceLeakException(this);
            }
            Dispose(false);
        }
        #endif
        #endregion

    }
}
