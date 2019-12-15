using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TonNurako.Widgets;
using TonNurako.Widgets.Xm;

namespace TonNurako.Data
{
    public class WidgetList : IDisposable {

        List<IWidget> widgetList;

        public IntPtr Handle {
            get {return addrOfArray;}
        }

        public IEnumerable<IWidget> Widgets {
            get {return widgetList;}
        }

        public int Count {
            get {return widgetList.Count;}
        }

        /// <summary>
        /// Widgetの配列から
        /// </summary>
        /// <param name="tabs">Tab配列</param>
        public WidgetList(IWidget[] tabs) {
            widgetList = new List<IWidget>();
            for (int i=0; i < tabs.Length; i++) {
                widgetList.Add(tabs[i]);
            }
        }

        /// <summary>
        /// ﾈｲﾃｨﾌﾞから
        /// </summary>
        /// <param name="app">ApplicationContext</param>
        /// <param name="tabs">WidgetList</param>
        internal WidgetList(ApplicationContext app, IntPtr widgets, int count) {
            IntPtr [] ps = new IntPtr[count+1];
            widgetList = new List<IWidget>();
            Marshal.Copy(widgets, ps, 0, count);
            for (int i = 0;i < count;i++) {
                IWidget w = app.FindWidgetByHandle(ps[i]);
                if (null == w) {
                    throw new NullReferenceException("w == NULL");
                }
                widgetList.Add(w);
            }
        }

        public IntPtr [] ToNativeArray() {
            IntPtr [] ps = new IntPtr[widgetList.Count];
            for (int i = 0;i < widgetList.Count;i++) {
                ps[i] = widgetList[i].Handle.Widget.Handle;
            }
            return ps;
        }

        IntPtr addrOfArray = IntPtr.Zero;

        public IntPtr ToPointer() {
            if (IntPtr.Zero != addrOfArray) {
                Marshal.FreeCoTaskMem(addrOfArray);
            }
            IntPtr[] arr =  ToNativeArray();
            addrOfArray = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(IntPtr)) * arr.Length);
            Marshal.Copy(arr, 0, addrOfArray, arr.Length);
            return addrOfArray;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (IntPtr.Zero != addrOfArray) {
                    Marshal.FreeCoTaskMem(addrOfArray);
                    addrOfArray = IntPtr.Zero;
                }
                disposedValue = true;
            }
        }

        ~WidgetList() {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        #endregion
    }
}
