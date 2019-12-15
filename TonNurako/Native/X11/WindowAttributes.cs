using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.X11 {

    public class Geometry :IDisposable {
        internal IntPtr root_return = IntPtr.Zero;
        Display display;
        public Window Root => new Window(root_return, display);

        internal int x_return;
        public int X {
            get { return x_return; }
            set { x_return = value; }
        }

        internal int y_return;
        public int Y {
            get { return y_return; }
            set { y_return = value; }
        }

        internal int width_return;
        public int Width {
            get { return width_return; }
            set { width_return = value; }
        }

        internal int height_return;
        public int Height {
            get { return height_return; }
            set { height_return = value; }
        }

        internal int border_width_return;
        public int BorderWidth {
            get { return border_width_return; }
            set { border_width_return = value; }
        }

        internal int depth_return;
        public int Depth {
            get { return depth_return; }
            set { depth_return = value; }
        }

        public Geometry(Display dpy) {
            display = dpy;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion
    }



    [StructLayout(LayoutKind.Sequential)]
    internal struct XSetWindowAttributesRec {
        public IntPtr background_pixmap; // Pixmap
        public ulong background_pixel; // unsigned long
        public IntPtr border_pixmap; // Pixmap
        public ulong border_pixel; // unsigned long
        public Gravity bit_gravity; // int
        public UnmapGravity win_gravity; // int
        public BackingStoreHint backing_store; // int
        public ulong backing_planes; // unsigned long
        public ulong backing_pixel; // unsigned long
        [MarshalAs(UnmanagedType.U1)] public bool save_under; // Bool
        [MarshalAs(UnmanagedType.U8)] public EventMask event_mask; // long
        [MarshalAs(UnmanagedType.U8)] public EventMask do_not_propagate_mask; // long
        [MarshalAs(UnmanagedType.U1)] public bool override_redirect; // Bool
        public int colormap; // Colormap
        public int cursor; // Cursor
    }

    public class XSetWindowAttributes {

        internal XSetWindowAttributesRec record;

        internal XSetWindowAttributes(IntPtr ptr) {
            record = Marshal.PtrToStructure<XSetWindowAttributesRec>(ptr);
        }

        public XSetWindowAttributes() {
            record = new XSetWindowAttributesRec();
        }

        public ulong BackgroundPixel {
            get { return record.background_pixel; }
            set { record.background_pixel = value; }
        }

        public TonNurako.X11.Pixmap BackgroundPixmap {
            get {
                return TonNurako.X11.Pixmap.FromPixmap(record.background_pixmap, null);
            }
            set {
                record.background_pixmap = value.Drawable;
            }
        }

        public TonNurako.X11.Pixmap BorderPixmap {
            get {
                return TonNurako.X11.Pixmap.FromPixmap(record.border_pixmap, null);
            }
            set {
                record.border_pixmap = value.Drawable;
            }
        }

        public ulong BorderPixel {
            get { return record.border_pixel; }
            set { record.border_pixel = value; }
        }

        public Gravity BitGravity {
            get { return record.bit_gravity; }
            set { record.bit_gravity = value; }
        }

        public UnmapGravity WinGravity {
            get { return record.win_gravity; }
            set { record.win_gravity = value; }
        }


        public BackingStoreHint BackingStore {
            get { return record.backing_store; }
            set { record.backing_store = value; }
        }

        public ulong BackingPlanes {
            get { return record.backing_planes; }
            set { record.backing_planes = value; }
        }


        public ulong BackingPixel {
            get { return record.backing_pixel; }
            set { record.backing_pixel = value; }
        }

        public bool SaveUnder {
            get { return record.save_under; }
            set { record.save_under = value; }
        }

        public EventMask EventMask {
            get { return record.event_mask; }
            set { record.event_mask = value; }
        }

        public bool OverrideRedirect {
            get { return record.override_redirect; }
            set { record.override_redirect = value; }
        }

        public int Colormap { // Colormap
            get { return record.colormap; }
            set { record.colormap = value; }
        }

        //public int cursor; // Cursor
        public int Cursor {
            get { return record.cursor; }
            set { record.cursor = value; }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XWindowAttributesRec {
        public int x; // int
        public int y; // int
        public int width; // int
        public int height; // int
        public int border_width; // int
        public int depth; // int
        internal IntPtr visual; // Visual*
        internal IntPtr root; // Window
        public int klass; // int
        public Gravity bit_gravity; // int
        public UnmapGravity win_gravity; // int
        public BackingStoreHint backing_store; // int
        public ulong backing_planes; // ulong
        public ulong backing_pixel; // ulong
        [MarshalAs(UnmanagedType.U1)] public bool save_under; // Bool
        public int colormap; // Colormap
        [MarshalAs(UnmanagedType.U1)] public  bool map_installed; // Bool
        public MapState map_state; // int
        [MarshalAs(UnmanagedType.U8)] public EventMask all_event_masks; // long
        [MarshalAs(UnmanagedType.U8)] public EventMask your_event_mask; // long
        [MarshalAs(UnmanagedType.U8)] public EventMask do_not_propagate_mask; // long
        [MarshalAs(UnmanagedType.U1)] public bool override_redirect; // Bool
        internal IntPtr screen; // Screen*
    }

    public class XWindowAttributes {
        Display display;
        internal XWindowAttributesRec record;
        internal XWindowAttributesRec Record {
            get { return record; }
            set { record = value; }
        }

        public XWindowAttributes(Display dpy) {
            record = new XWindowAttributesRec();
            display = dpy;
        }

        public int X {
            get { return record.x; }
            set { record.y = value; }
        }

        public int Y {
            get { return record.y; }
            set { record.y = value; }
        }

        public int Width {
            get { return record.width; }
            set { record.width = value; }
        }

        public int Height {
            get { return record.height; }
            set { record.height = value; }
        }

        public int BorderWidth {
            get { return record.border_width; }
            set { record.border_width = value; }
        }

        public int Depth {
            get { return record.depth; }
            set { record.depth = value; }
        }

        public Visual Visual {
            get { return new Visual(record.visual); }
            set { record.visual = value.Handle; }
        }

        public Window Root {
            get { return new Window(record.root, display); }
            set { record.root = value.Handle; }
        }

        public int Glass {
            get { return record.klass; }
            set { record.klass = value; }
        }

        public Gravity BitGravity {
            get { return record.bit_gravity; }
            set { record.bit_gravity = value; }
        }

        public UnmapGravity WinGravity {
            get { return record.win_gravity; }
            set { record.win_gravity = value; }
        }

        public BackingStoreHint BackingStore {
            get { return record.backing_store; }
            set { record.backing_store = value; }
        }

        public ulong BackingPlanes {
            get { return record.backing_planes; }
            set { record.backing_planes = value; }
        }

        public ulong BackingPixel {
            get { return record.backing_pixel; }
            set { record.backing_pixel = value; }
        }

        public bool SaveUnder {
            get { return record.save_under; }
            set { record.save_under = value; }
        }

        public Colormap Colormap {
            get { return new Colormap(record.colormap, display); }
            set { record.colormap = value.Handle; }
        }

        public bool MapInstalled {
            get { return record.map_installed; }
            set { record.map_installed = value; }
        }

        public MapState MapState {
            get { return record.map_state; }
            set { record.map_state = value; }
        }

        public EventMask AllEventMasks {
            get { return record.all_event_masks; }
            set { record.all_event_masks = value; }
        }

        public EventMask YourEventMask {
            get { return record.your_event_mask; }
            set { record.your_event_mask = value; }
        }

        public EventMask DoNotPropagateMask {
            get { return record.do_not_propagate_mask; }
            set { record.do_not_propagate_mask = value; }
        }

        public bool OverrideRedirect {
            get { return record.override_redirect; }
            set { record.override_redirect = value; }
        }


        public Screen Screen {
            get { return new Screen(record.screen, display); }
            set { record.screen = value.Handle; }
        }

    }
}
