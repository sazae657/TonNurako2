using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11 {
    public class Colormap : IX11Interop<int>
    {
        internal static class NativeMethods {

            // Colormap: XCreateColormap [{'type': 'Display*', 'name': 'display'}, {'type': 'Window', 'name': 'w'}, {'type': 'Visual*', 'name': 'visual'}, {'type': 'int', 'name': 'alloc'}]
            [DllImport(ExtremeSports.Lib, EntryPoint="XCreateColormap_TNK", CharSet=CharSet.Auto)]
            internal static extern int XCreateColormap(IntPtr display, IntPtr w, out IntPtr visual, int alloc);

            // Colormap: XCopyColormapAndFree [{'type': 'Display*', 'name': 'display'}, {'type': 'Colormap', 'name': 'colormap'}]
            [DllImport(ExtremeSports.Lib, EntryPoint="XCopyColormapAndFree_TNK", CharSet=CharSet.Auto)]
            internal static extern int XCopyColormapAndFree(IntPtr display, int colormap);

            // int: XFreeColormap [{'type': 'Display*', 'name': 'display'}, {'type': 'Colormap', 'name': 'colormap'}]
            [DllImport(ExtremeSports.Lib, EntryPoint="XFreeColormap_TNK", CharSet=CharSet.Auto)]
            internal static extern int XFreeColormap(IntPtr display, IntPtr colormap);
        }

        int handle;
        public int Handle => (null != cmapDelegaty) ? cmapDelegaty() : handle;

        Display display;
        ReturnPointerDelegaty<int> cmapDelegaty = null;

        public Colormap() {
        }

        public Colormap(ReturnPointerDelegaty<int> delegaty, Display dpy) {
            cmapDelegaty = delegaty;
            display = dpy;
        }

        public Colormap(int cm, Display dpy) {
            display = dpy;
            handle = cm;
        }

    }
}
