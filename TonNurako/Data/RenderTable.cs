using System;
using System.Runtime.InteropServices;

namespace TonNurako.Data
{
    public class RenderTable : IDisposable {
        public enum MergeMode {
            SKIP = TonNurako.Motif.Constant.XmSKIP,
            REPLACE = TonNurako.Motif.Constant.XmMERGE_REPLACE,
            OLD = TonNurako.Motif.Constant.XmMERGE_OLD,
            NEW = TonNurako.Motif.Constant.XmMERGE_NEW,
            DUPLICATE = TonNurako.Motif.Constant.XmDUPLICATE,
        }

        internal static class NativeMethods {

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmRenderTableAddRenditions_TNK", CharSet=CharSet.Auto)]
            internal static extern IntPtr XmRenderTableAddRenditions(
                IntPtr oldtable, IntPtr [] renditions, int rendition_count, MergeMode merge_mode);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmRenderTableCopy_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern IntPtr XmRenderTableCopy(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string tags, int tag_count);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmRenderTableCvtFromProp_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern IntPtr XmRenderTableCvtFromProp(IntPtr widget, [MarshalAs(UnmanagedType.LPStr)] string property, uint length);

            // [DllImport(Native.LibHelper.LibName, EntryPoint="XmRenderTableCvtToProp_TNK", CharSet=CharSet.Auto)]
            // internal static extern uint XmRenderTableCvtToProp(IntPtr widget, IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string prop_return);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmRenderTableFree_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmRenderTableFree(IntPtr table);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmRenderTableGetRendition_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern IntPtr XmRenderTableGetRendition(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string tag);

            //[DllImport(Native.LibHelper.LibName, EntryPoint="XmRenderTableGetRenditions_TNK", CharSet=CharSet.Auto)]
            //internal static extern IntPtr XmRenderTableGetRenditions(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string tags, int tag_count);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmRenderTableGetTags_TNK", CharSet=CharSet.Auto)]
            internal static extern int XmRenderTableGetTags(IntPtr table, out IntPtr tag_list);

            // [DllImport(Native.LibHelper.LibName, EntryPoint="XmRenderTableRemoveRenditions_TNK", CharSet=CharSet.Auto)]
            //internal static extern IntPtr XmRenderTableRemoveRenditions(IntPtr oldtable, [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStr)] string [] tags, int tag_count);
        }

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle {
            get {return handle;}
        }

        private bool isReference = false;

        public RenderTable(Widgets.IWidget widget, string property) {
            handle = NativeMethods.XmRenderTableCvtFromProp(widget.Handle.Widget.Handle, property, (uint)property.Length);
        }

        public RenderTable(Rendition[] renditions) {
            var rs = new IntPtr[renditions.Length];
            for (int i = 0; i < renditions.Length; ++i) {
                rs[i] = renditions[i].Handle;
            }
            handle = NativeMethods.XmRenderTableAddRenditions(IntPtr.Zero, rs, renditions.Length, MergeMode.REPLACE);
        }

        internal RenderTable(IntPtr tableRef) {
            handle = tableRef;
            isReference = true;
        }

        public string[] GetTags() {
            IntPtr tags;
            int count = NativeMethods.XmRenderTableGetTags(handle, out tags);
            if (0 == count) {
                return (new string[]{});
            }
            var arr = new IntPtr[count];
            Marshal.Copy(tags, arr, 0, count);
            var ret = new string[count];
            for (int i =0;i < count; ++i) {
                ret[i] = Marshal.PtrToStringAnsi(arr[i]);
            }
            return ret;
        }

        public Rendition GetRendition(string tag) {
            var r = NativeMethods.XmRenderTableGetRendition(handle, tag);
            if (IntPtr.Zero == r) {
                return null;
            }
            return (new Rendition(r));
        }


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)  {
            if (!disposedValue)
            {
                if (IntPtr.Zero != handle) {
                    if(!isReference) {
                        NativeMethods.XmRenderTableFree(handle);
                    }
                    handle = IntPtr.Zero;
                }
                disposedValue = true;
            }
        }

        ~RenderTable() {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        #endregion
    }
}
