using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11 {
    public class Screen : IX11Interop {

        internal static class NativeMethods {
            // Display*: DisplayOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DisplayOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr DisplayOfScreen(IntPtr s);

            // Window: RootWindowOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "RootWindowOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr RootWindowOfScreen(IntPtr s);

            // ulong: BlackPixelOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "BlackPixelOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern ulong BlackPixelOfScreen(IntPtr s);

            // ulong: WhitePixelOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "WhitePixelOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern ulong WhitePixelOfScreen(IntPtr s);

            // Colormap: DefaultColormapOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DefaultColormapOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern int DefaultColormapOfScreen(IntPtr s);

            // int: DefaultDepthOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DefaultDepthOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern int DefaultDepthOfScreen(IntPtr s);

            // GC: DefaultGCOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DefaultGCOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr DefaultGCOfScreen(IntPtr s);

            // Visual*: DefaultVisualOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DefaultVisualOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr DefaultVisualOfScreen(IntPtr s);

            // int: WidthOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "WidthOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern int WidthOfScreen(IntPtr s);

            // int: HeightOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "HeightOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern int HeightOfScreen(IntPtr s);

            // int: WidthMMOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "WidthMMOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern int WidthMMOfScreen(IntPtr s);

            // int: HeightMMOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "HeightMMOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern int HeightMMOfScreen(IntPtr s);

            // int: PlanesOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "PlanesOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern int PlanesOfScreen(IntPtr s);

            // int: CellsOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "CellsOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern int CellsOfScreen(IntPtr s);

            // int: MinCmapsOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "MinCmapsOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern int MinCmapsOfScreen(IntPtr s);

            // int: MaxCmapsOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "MaxCmapsOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern int MaxCmapsOfScreen(IntPtr s);

            // Bool: DoesSaveUnders [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DoesSaveUnders_TNK", CharSet = CharSet.Auto)]
            internal static extern bool DoesSaveUnders(IntPtr s);

            // int: DoesBackingStore [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "DoesBackingStore_TNK", CharSet = CharSet.Auto)]
            internal static extern int DoesBackingStore(IntPtr s);

            // long: EventMaskOfScreen [{'type': 'Screen*', 'name': 's'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "EventMaskOfScreen_TNK", CharSet = CharSet.Auto)]
            internal static extern long EventMaskOfScreen(IntPtr s);
        }


        ReturnPointerDelegaty delegaty;
        IntPtr screen;
        Display display;

        public Screen(ReturnPointerDelegaty delegaty) {
            this.delegaty = delegaty;
        }

        public Screen(IntPtr screen, Display dpy) {
            this.screen = screen;
            this.display = dpy;
        }

        public IntPtr Handle =>
            (delegaty != null) ? delegaty() : screen;

        public Display DisplayOfScreen => new Display(NativeMethods.DisplayOfScreen(Handle), true);
        public Window RootWindowOfScreen => new Window(NativeMethods.RootWindowOfScreen(Handle), DisplayOfScreen);
        public ulong BlackPixelOfScreen => NativeMethods.BlackPixelOfScreen(Handle);
        public ulong WhitePixelOfScreen => NativeMethods.WhitePixelOfScreen(Handle);
        public Colormap DefaultColormapOfScreen => new Colormap(NativeMethods.DefaultColormapOfScreen(Handle), DisplayOfScreen);
        public int DefaultDepthOfScreen => NativeMethods.DefaultDepthOfScreen(Handle);
        // DefaultGCOfScreen
        public Visual DefaultVisualOfScreen => (new Visual(NativeMethods.DefaultVisualOfScreen(Handle)));

        public int WidthOfScreen => NativeMethods.WidthOfScreen(Handle);
        public int HeightOfScreen => NativeMethods.HeightOfScreen(Handle);
        public int WidthMMOfScreen => NativeMethods.WidthMMOfScreen(Handle);
        public int HeightMMOfScreen => NativeMethods.HeightMMOfScreen(Handle);

        public int PlanesOfScreen => NativeMethods.PlanesOfScreen(Handle);
        public int CellsOfScreen => NativeMethods.CellsOfScreen(Handle);
        public int MinCmapsOfScreen => NativeMethods.MinCmapsOfScreen(Handle);
        public int MaxCmapsOfScreen => NativeMethods.MaxCmapsOfScreen(Handle);
        public bool DoesSaveUnders => NativeMethods.DoesSaveUnders(Handle);
        public BackingStoreHint DoesBackingStore => (BackingStoreHint)NativeMethods.DoesBackingStore(Handle);
        public EventMask EventMaskOfScreen => (EventMask)NativeMethods.EventMaskOfScreen(Handle);
    }
}
