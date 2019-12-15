using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.X11;
using TonNurako.X11.Extension;

namespace TonNurako.X11.Extension.Xft {

    [StructLayout(LayoutKind.Sequential)]
    struct XftColorRec {
       public ulong   Pixel;
        public XRenderColor Color;
    }

    public class XftColor : IDisposable {
        internal static class NativeMethods {
            // Bool: XftColorAllocName Display*:dpy  Visual*:visual  Colormap:cmap  char*:name  XftColor*:result  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftColorAllocName_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern bool XftColorAllocName(IntPtr dpy, IntPtr visual, int cmap, [MarshalAs(UnmanagedType.LPStr)] string name, ref XftColorRec result);

            // Bool: XftColorAllocValue Display*:dpy  Visual*:visual  Colormap:cmap  XRenderColor*:color  XftColor*:result  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftColorAllocValue_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XftColorAllocValue(IntPtr dpy, IntPtr visual, int cmap, ref XRenderColor color, ref XftColorRec result);

            // void: XftColorFree Display*:dpy  Visual*:visual  Colormap:cmap  XftColor*:color  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XftColorFree_TNK", CharSet = CharSet.Auto)]
            internal static extern void XftColorFree(IntPtr dpy, IntPtr visual, int cmap, ref XftColorRec color);

        }

        internal XftColorRec Record;
        Display display;
        Colormap colormap;
        Visual visual;
        bool allocated = false;
        
        public XftColor() {
            Record = new XftColorRec();
        }

        internal XftColor(Display dpy, Visual vis, Colormap cm) {
            display = dpy;
            visual = vis;
            colormap = cm;
        }

        public void Free() {
            if (!allocated) {
                return;
            }
            NativeMethods.XftColorFree(display.Handle, visual.Handle, colormap.Handle, ref Record);
        }

        public ulong Pixel {
            get => Record.Pixel;
            set => Record.Pixel = value;
        }

        public XRenderColor Color {
            get => Record.Color;
            set => Record.Color = value;
        }


        #region static おじさん

        public static XftColor AllocName(Display dpy, Visual visual, Colormap cmap, string name) {
            var p = new XftColor(dpy, visual, cmap);
            if (!NativeMethods.XftColorAllocName(dpy.Handle, visual.Handle, cmap.Handle, name, ref p.Record)) {
                return null;
            }
            p.allocated = true;
            return p;
        }

        public static XftColor AllocValue(Display dpy, Visual visual, Colormap cmap, XRenderColor color) {
            var p = new XftColor(dpy, visual, cmap);
            if (!NativeMethods.XftColorAllocValue(dpy.Handle, visual.Handle, cmap.Handle, ref color, ref p.Record)) {
                return p;
            }
            p.allocated = true;
            return p;
        }

        #endregion

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                this.Free();
            }
        }

        // ~XftColor() {
        //   Dispose(false);
        // }

        public void Dispose() {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
