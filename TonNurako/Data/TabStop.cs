using System;
using System.Runtime.InteropServices;
using TonNurako.Widgets.Xm;

namespace TonNurako.Data
{
    public enum OffsetModel {
        ABSOLUTE = TonNurako.Motif.Constant.XmABSOLUTE,
        RELATIVE = TonNurako.Motif.Constant.XmRELATIVE,
    }
    public class Tab : IDisposable {
        internal static class NativeMethods {
            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTabCreate_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern IntPtr XmTabCreate(float value,
                byte units, byte offset_model, byte alignment, [MarshalAs(UnmanagedType.LPStr)] string xdecimal);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTabFree_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTabFree(IntPtr tab);
        }

        internal IntPtr handle = IntPtr.Zero;
        public IntPtr Handle {
            get {return handle;}
        }

        public Tab(float value, UnitType units, OffsetModel offset_model) {
            handle = NativeMethods.XmTabCreate(value,
                (byte)units, (byte)offset_model, (byte)TonNurako.Motif.Constant.XmALIGNMENT_BEGINNING, ".");
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (IntPtr.Zero != Handle) {
                    NativeMethods.XmTabFree(Handle);
                    handle = IntPtr.Zero;
                }
                disposedValue = true;
            }
        }

        ~Tab() {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class TabList : IDisposable {

        internal static class NativeMethods {
            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTabListInsertTabs_TNK", CharSet=CharSet.Auto)]
            internal static extern IntPtr XmTabListInsertTabs(IntPtr oldlist, IntPtr[] tabs, int tab_count, int position);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmTabListFree_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmTabListFree(IntPtr tablist);
        }

        internal IntPtr handle = IntPtr.Zero;
        public IntPtr Handle {
            get {return handle;}
        }

        /// <summary>
        /// tabの配列から
        /// </summary>
        /// <param name="tabs">Tab配列</param>
        public TabList(Tab[] tabs) {
            var arr = new IntPtr[tabs.Length];
            for (int i=0; i < tabs.Length; i++) {
                arr[i] = tabs[i].Handle;
            }
            handle = NativeMethods.XmTabListInsertTabs (IntPtr.Zero, arr, tabs.Length, 0);
        }

        /// <summary>
        /// ﾈｲﾃｨﾌﾞから
        /// </summary>
        /// <param name="tabs">XmTabList</param>
        internal TabList(IntPtr tabs) {
            handle = tabs;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (IntPtr.Zero != Handle) {
                    NativeMethods.XmTabListFree(Handle);
                    handle = IntPtr.Zero;
                }
                disposedValue = true;
            }
        }

        ~TabList() {
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
