using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11 {

    [Flags]
    public enum XColorFlags : byte {
        DoRed = TonNurako.X11.Constant.DoRed,
        DoGreen = TonNurako.X11.Constant.DoGreen,
        DoBlue = TonNurako.X11.Constant.DoBlue,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XColor {
        public ulong    Pixel;
        public ushort   Red;
        public ushort   Green;
        public ushort   Blue;
        [MarshalAs(UnmanagedType.U1)] public XColorFlags Flags;
        public byte     Pad;
    };

    public class XLookupColorResult {
        internal Color exact;
        internal Color screen;

        public Color Exact => exact;
        public Color Screen => screen;

        public XLookupColorResult() {
            exact = new Color();
            screen = new Color();
        }
        internal XLookupColorResult(Display dpy, Colormap cmap) {
            exact = new Color(dpy, cmap);
            screen = new Color(dpy, cmap);
        }
    }

    #region ColorCell
    // TODO: PseudoColorな環境が要る
    public class ColorCell : IDisposable {
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "XAllocColorCells_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XAllocColorCells(
                IntPtr display, int colormap, [MarshalAs(UnmanagedType.U1)] bool contig, 
                [In, Out] ulong[] plane_masks_return, uint nplanes, [In, Out] ulong[] pixels_return, uint npixels);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFreeColors_TNK", CharSet = CharSet.Auto)]
            internal static extern int XFreeColors(IntPtr display, int colormap, [In] ulong[] pixels, int npixels, ulong planes);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XAllocColorPlanes_TNK", CharSet = CharSet.Auto)]
            internal static extern int XAllocColorPlanes(IntPtr display, int colormap, 
                [MarshalAs(UnmanagedType.U1)] bool contig, out IntPtr pixels_return, int ncolors, int nreds, int ngreens, int nblues, out IntPtr rmask_return, out IntPtr gmask_return, out IntPtr bmask_return);

        }

        Colormap colormap;
        Display display;

        public ColorCell(Display display, Colormap colormap, int masks, int pixels) {
            this.colormap = colormap;
            this.display = display;
            this.masks = new ulong[masks];
            this.pixels = new ulong[pixels];
        }

        ulong[] masks;
        public ulong[] Masks => masks;

        ulong[] pixels;
        public ulong[] Pixels => pixels;

        public static ColorCell AllocColorCells(
            Display display, Colormap colormap, int masks, int pixels) {

            if (display.DefaultVisual.Class != VisualClass.PseudoColor) {
                throw new System.ArgumentException($"この環境ではｶﾗーｾﾙは使えないよ: {display.DefaultVisual.Class}");
            }

            var r = new ColorCell(display, colormap, masks, pixels);
            var res = NativeMethods.XAllocColorCells(display.Handle, colormap.Handle, true,
                r.masks, (uint)masks,
                r.pixels, (uint)pixels);
            if (XStatus.True != res) {
                throw new System.ArgumentException($"XAllocColorCells FAILED R/C={res}");
            }
            return r;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                NativeMethods.XFreeColors(
                    display.Handle, colormap.Handle, pixels, pixels.Length, (ulong)masks.Length);
                disposedValue = true;
            }
        }


        // ~ColorCell() {
        //   Dispose(false);
        // }

        public void Dispose() {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
    #endregion

    public class Color : IX11Interop<ulong> {

        internal static class NativeMethods {

            [DllImport(ExtremeSports.Lib, EntryPoint = "XAllocColor_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XAllocColor(IntPtr display, int colormap, [In, Out] ref XColor screen_in_out);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XAllocNamedColor_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern XStatus XAllocNamedColor(IntPtr display, int colormap, [MarshalAs(UnmanagedType.LPStr)] string color_name, out XColor screen_def_return, out XColor exact_def_return);

            // int: XQueryColor Display*:display  Colormap:colormap  XColor*:def_in_out  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XQueryColor_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XQueryColor(IntPtr display, int colormap, ref XColor def_in_out);

            // int: XQueryColors Display*:display  Colormap:colormap  XColor:defs_in_out[]  int:ncolors  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XQueryColors_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XQueryColors(IntPtr display, int colormap, [In,Out] XColor [] defs_in_out, int ncolors);

            // Status: XLookupColor Display*:display  Colormap:colormap  char*:color_name  XColor*:exact_def_return  XColor*:screen_def_return  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XLookupColor_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern XStatus XLookupColor(IntPtr display, int colormap, [MarshalAs(UnmanagedType.LPStr)] string color_name, out XColor exact_def_return, out XColor screen_def_return);

            // Status: XParseColor Display*:display  Colormap:colormap  char*:spec  XColor*:exact_def_return  
            [DllImport(ExtremeSports.Lib, EntryPoint = "XParseColor_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern XStatus XParseColor(IntPtr display, int colormap, [MarshalAs(UnmanagedType.LPStr)] string spec, out XColor exact_def_return);
        }

        public ulong Handle => Record.Pixel;

        internal XColor Record;
        public XColor XColor => Record;

        Colormap colormap;
        Display display;

        public ReturnPointerDelegaty<ulong> PixelDelegaty = null;

        public Color() {
            colormap = null;
            display = null;
            Record = new XColor();
        }

        public Color(Display dpy, Colormap cmap) {
            colormap = cmap;
            display = dpy;
            Record = new XColor();
        }

        public Color(Display dpy, Colormap cmap, XColor color) {
            colormap = cmap;
            display = dpy;
            this.Record = color;
        }


        public Color(ulong pixel) {
            colormap = null;
            display = null;
            Record = new XColor();
            Record.Pixel = pixel;
        }

        public Color(ReturnPointerDelegaty<ulong> delegaty) {
            colormap = null;
            display = null;
            PixelDelegaty = delegaty;
            Record = new XColor();
        }

        public ulong Pixel {
            get => (null != PixelDelegaty) ? PixelDelegaty() : Record.Pixel;
            set => Record.Pixel = value;
        }
        public ushort Red {
            get => Record.Red;
            set => Record.Red = value;
        }
        public ushort Green {
            get => Record.Green;
            set => Record.Green = value;
        }
        public ushort Blue {
            get => Record.Blue;
            set => Record.Blue = value;
        }
        public XColorFlags Flags {
            get => Record.Flags;
            set => Record.Flags = value;
        }
        public byte Pad {
            get => Record.Pad;
            set => Record.Pad = value;
        }

        public bool PixelEquals(Color b) {
            return (this.Pixel == b.Pixel);
        }

        internal void Assign(Display dpy, Colormap cmap, XColor color) {
            this.colormap = cmap;
            this.display = dpy;
            this.Record = color;
        }



        #region ﾌｧｸﾄﾘーっぽいやつ
        public static Color AllocNamedColor(Display dpy, Colormap cmap, string name) {
            var near = new XColor();
            var far  = new XColor();
            if (XStatus.True != NativeMethods.XAllocNamedColor(dpy.Handle, cmap.Handle, name, out near, out far)) {
                throw new System.ArgumentException($"XAllocNamedColor({name} == False");
            }
            var k = new Color(dpy, cmap);
            k.Record = near;
            return k;
        }

        public static Color AllocColor(Display dpy, Colormap cmap, int r, int g, int b) {
            var k = new Color(dpy, cmap);
            k.Record.Red = (ushort)(256*r);
            k.Record.Green = (ushort)(256 * g);
            k.Record.Blue = (ushort)(256 * b);
            if (XStatus.True != NativeMethods.XAllocColor(dpy.Handle, cmap.Handle, ref k.Record)) {
                throw new System.ArgumentException($"r#{r} g#{g} #b{b}");
            }
            return k;
        }

        public static Color QueryColor(Display display, Colormap colormap, XColor color) {
            var r = new Color(display, colormap);
            r.Record.Pixel= color.Pixel;
            if (XStatus.True != NativeMethods.XQueryColor(display.Handle, colormap.Handle, ref r.Record)) {
                return null;
            }
            return r;
        }

        public static Color [] QueryColors(Display display, Colormap colormap, XColor[] colors) {
            if (XStatus.True != NativeMethods.XQueryColors(display.Handle, colormap.Handle, colors, colors.Length)) {
                return null;
            }
            var r = new Color[colors.Length];
            for (int i = 0; i < colors.Length; ++i) {
                r[i] = new Color(display, colormap, colors[i]);
            }
            return r;
        }

        public static XLookupColorResult LookupColor(Display display, Colormap colormap, string color_name) {
            var r = new XLookupColorResult(display, colormap);
            if (XStatus.True != NativeMethods.XLookupColor(display.Handle, colormap.Handle, color_name, out r.exact.Record, out r.screen.Record)) {
                return null;
            }
            return r;
        }

        public static Color ParseColor(Display display, Colormap colormap, string spec) {
            var r = new Color(display, colormap);
            if (XStatus.True != NativeMethods.XParseColor(display.Handle, colormap.Handle, spec, out r.Record)) {
                return null;
            }
            return r;
        }
        #endregion

    }
}
