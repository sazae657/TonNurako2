using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11 {

    public enum VisualClass : int {
        StaticGray = TonNurako.X11.Constant.StaticGray,
        GrayScale = TonNurako.X11.Constant.GrayScale,
        StaticColor = TonNurako.X11.Constant.StaticColor,
        PseudoColor = TonNurako.X11.Constant.PseudoColor,
        TrueColor = TonNurako.X11.Constant.TrueColor,
        DirectColor = TonNurako.X11.Constant.DirectColor,
    }

    public enum VisualMask : ulong {
        VisualNoMask = TonNurako.X11.Constant.VisualNoMask,
        VisualIDMask = TonNurako.X11.Constant.VisualIDMask,
        VisualScreenMask = TonNurako.X11.Constant.VisualScreenMask,
        VisualDepthMask = TonNurako.X11.Constant.VisualDepthMask,
        VisualClassMask = TonNurako.X11.Constant.VisualClassMask,
        VisualRedMaskMask = TonNurako.X11.Constant.VisualRedMaskMask,
        VisualGreenMaskMask = TonNurako.X11.Constant.VisualGreenMaskMask,
        VisualBlueMaskMask = TonNurako.X11.Constant.VisualBlueMaskMask,
        VisualColormapSizeMask = TonNurako.X11.Constant.VisualColormapSizeMask,
        VisualBitsPerRGBMask = TonNurako.X11.Constant.VisualBitsPerRGBMask,
        VisualAllMask = TonNurako.X11.Constant.VisualAllMask,
    }

    public class Visual : IX11Interop {
        internal static class NativeMethods {
            // VisualID: XVisualIDFromVisual Visual*:visual
            [DllImport(ExtremeSports.Lib, EntryPoint = "XVisualIDFromVisual_TNK", CharSet = CharSet.Auto)]
            internal static extern ulong XVisualIDFromVisual(ref VisualC visual);
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class VisualC {
            public IntPtr ext_data; // XExtData*
            public ulong visualid; // VisualID
            public VisualClass klass; // int
            public ulong red_mask; // unsigned long
            public ulong green_mask; // unsigned long
            public ulong blue_mask; // unsigned long
            public int bits_per_rgb; // int
            public int map_entries; // int
        }

        // TODO: どうすっか考え中
        [StructLayout(LayoutKind.Sequential)]
        internal class XExtData {
            public int number;
            public IntPtr next; // XExtData*
            public IntPtr free_private;    //int(* free_private)(struct _XExtData *extension);
            public IntPtr private_data;  /* data private to this extension. */
        }

        VisualC visual = new VisualC();
        XExtData extdata = null;

        public ulong VisualId => visual.visualid;
        public VisualClass Class => visual.klass;
        public ulong RedMask => visual.visualid;
        public ulong GreenMask => visual.visualid;
        public ulong BlueMask => visual.visualid;
        public int BitsPerRgb => visual.bits_per_rgb;
        public int MapEntries => visual.map_entries;

        ReturnPointerDelegaty delegaty;

        IntPtr handle;
        public IntPtr Handle => (delegaty == null) ? handle : delegaty();


        public Visual(IntPtr v) {
            handle = v;
            if (IntPtr.Zero == v) {
                return;
            }
            visual = (VisualC)Marshal.PtrToStructure(v, typeof(VisualC));
            if (IntPtr.Zero != visual.ext_data) {
                extdata = (XExtData)Marshal.PtrToStructure(visual.ext_data, typeof(XExtData));
            }
        }

        internal Visual(ReturnPointerDelegaty delegaty) {
            this.delegaty = delegaty;
            //TODO: Marshallするか考え中
        }

        /// <summary>
        /// CopyFromParent定数対応
        /// </summary>
        public static Visual CopyFromParent {
            get {
                return (new Visual(IntPtr.Zero));
            }
        }



        public ulong VisualIDFromVisual
            => NativeMethods.XVisualIDFromVisual(ref visual);

        public int Free() {
            return TonNurako.Native.ExtremeSports.CallPtrArg1ReturnInt(extdata.free_private, visual.ext_data);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XVisualInfoRec {
        public IntPtr visual; // Visual*
        public ulong visualid; // VisualID
        public int screen; // int
        public int depth; // int
        public VisualClass qlass; // int
        public ulong red_mask; // unsigned long
        public ulong green_mask; // unsigned long
        public ulong blue_mask; // unsigned long
        public int colormap_size; // int
        public int bits_per_rgb; // int
    }

    public class XVisualInfo {
        internal static class NativeMethods {
            // XVisualInfo*: XGetVisualInfo Display*:display long:vinfo_mask XVisualInfo*:vinfo_template int*:nitems_return
            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetVisualInfo_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XGetVisualInfo(IntPtr display, VisualMask vinfo_mask, ref XVisualInfoRec vinfo_template, out int nitems_return);

            // Status: XMatchVisualInfo Display*:display int:screen int:depth int:class XVisualInfo*:vinfo_return
            [DllImport(ExtremeSports.Lib, EntryPoint = "XMatchVisualInfo_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XMatchVisualInfo(IntPtr display, int screen, int depth, VisualClass klass, ref XVisualInfoRec vinfo_return);
        }

        internal XVisualInfoRec Record;
        public XVisualInfo() {
            Record = new XVisualInfoRec();
        }

        internal Visual visual;
        internal XVisualInfo(IntPtr ptr) {
            Record = Marshal.PtrToStructure<XVisualInfoRec>(ptr);
            if (IntPtr.Zero != Record.visual) {
                visual = new Visual(Record.visual);
            }
        }
        internal XVisualInfo(IntPtr ptr, int seq) {
            sequence = seq;
            Record = Marshal.PtrToStructure<XVisualInfoRec>(ptr);
            if (IntPtr.Zero != Record.visual) {
                visual = new Visual(Record.visual);
            }
        }

        internal XVisualInfo(XVisualInfoRec ptr, bool parse) {
            Record = ptr;
            if (parse && IntPtr.Zero != Record.visual) {
                visual = new Visual(Record.visual);
            }
        }
        int sequence = 0;
        public int Sequence => sequence;


        //public IntPtr visual; // Visual*
        public Visual Visual {
            get => visual;
        }

        public ulong VisualId {
            get => Record.visualid;
            set => Record.visualid = value;
        }
        public int Screen {
            get => Record.screen;
            set => Record.screen = value;
        }
        public int Depth {
            get => Record.depth;
            set => Record.depth = value;
        }
        public VisualClass Class {
            get => Record.qlass;
            set => Record.qlass = value;
        }
        public ulong RedMask {
            get => Record.red_mask;
            set => Record.red_mask = value;
        }
        public ulong GreenMask {
            get => Record.green_mask;
            set => Record.green_mask = value;
        }
        public ulong BlueMask {
            get => Record.blue_mask;
            set => Record.blue_mask = value;
        }
        public int ColormapSize {
            get => Record.colormap_size;
            set => Record.colormap_size = value;
        }
        public int BitsPerRgb {
            get => Record.bits_per_rgb;
            set => Record.bits_per_rgb = value;
        }

        public static XVisualInfo[] GetVisualInfo(Display display, VisualMask vinfo_mask, XVisualInfo vinfo_template) {
            int nitems_return = 0;
            var k = NativeMethods.XGetVisualInfo(display.Handle, vinfo_mask, ref vinfo_template.Record, out nitems_return);

            var arr = new IntPtr[nitems_return];
            var tr = new XVisualInfo[nitems_return];
            int size = Marshal.SizeOf(typeof(XVisualInfoRec));
            Marshal.Copy(k, arr, 0, nitems_return);
            for (int i = 0; i < nitems_return; ++i) {
                IntPtr current = new IntPtr(k.ToInt64() + (size * i));
                tr[i] = new XVisualInfo(current, i);
            }

            return tr;
        }

        public static XVisualInfo MatchVisualInfo(Display display, int screen, int depth, VisualClass klass)
        {
            XVisualInfoRec vinfo_return = new XVisualInfoRec();
            if(XStatus.True != NativeMethods.XMatchVisualInfo(display.Handle, screen, depth, klass, ref vinfo_return)) {
                return null;
            }
            return new XVisualInfo(vinfo_return, true);
        }
    }
}
