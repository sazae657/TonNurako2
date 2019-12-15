using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11 {
    /// <summary>
    /// Pixmap
    /// </summary>
    public class Pixmap : IDrawable, IX11Interop, IDisposable {
        #region NativeMethods
        internal static class NativeMethods {
            // int: XReadBitmapFile [{'type': 'Display*', 'name': 'display'}, {'type': 'Drawable', 'name': 'd'}, {'type': 'char*', 'name': 'filename'}, {'type': 'unsigned int*', 'name': 'width_return'}, {'type': 'unsigned int*', 'name': 'height_return'}, {'type': 'Pixmap*', 'name': 'bitmap_return'}, {'type': 'int*', 'name': 'x_hot_return'}, {'type': 'int*', 'name': 'y_hot_return'}]
            //[DllImport(ExtremeSports.Lib, EntryPoint = "XReadBitmapFile_TNK", CharSet = CharSet.Auto)]
            //internal static extern int XReadBitmapFile(IntPtr display, IntPtr d, [MarshalAs(UnmanagedType.LPStr)] string filename, out IntPtr width_return, out IntPtr height_return, IntPtr bitmap_return, out IntPtr x_hot_return, out IntPtr y_hot_return);

            // int: XReadBitmapFileData [{'type': 'char*', 'name': 'filename'}, {'type': 'unsigned int*', 'name': 'width_return'}, {'type': 'unsigned int*', 'name': 'height_return'}, {'type': 'unsigned char*', 'name': 'data_return'}, {'type': 'int*', 'name': 'x_hot_return'}, {'type': 'int*', 'name': 'y_hot_return'}]
            //[DllImport(ExtremeSports.Lib, EntryPoint = "XReadBitmapFileData_TNK", CharSet = CharSet.Auto)]
            //internal static extern int XReadBitmapFileData([MarshalAs(UnmanagedType.LPStr)] string filename, out IntPtr width_return, out IntPtr height_return, [MarshalAs(UnmanagedType.LPStr)] string data_return, out IntPtr x_hot_return, out IntPtr y_hot_return);

            // int: XWriteBitmapFile [{'type': 'Display*', 'name': 'display'}, {'type': 'char*', 'name': 'filename'}, {'type': 'Pixmap', 'name': 'bitmap'}, {'type': 'unsigned int', 'name': 'width'}, {'type': 'unsigned int', 'name': 'height'}, {'type': 'int', 'name': 'x_hot'}, {'type': 'int', 'name': 'y_hot'}]
            //[DllImport(ExtremeSports.Lib, EntryPoint = "XWriteBitmapFile_TNK", CharSet = CharSet.Auto)]
            //internal static extern int XWriteBitmapFile(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr bitmap, uint width, uint height, int x_hot, int y_hot);

            // Pixmap: XCreatePixmapFromBitmapData [{'type': 'Display*', 'name': 'display'}, {'type': 'Drawable', 'name': 'd'}, {'type': 'char*', 'name': 'data'}, {'type': 'unsigned int', 'name': 'width'}, {'type': 'unsigned int', 'name': 'height'}, {'type': 'unsigned long', 'name': 'fg'}, {'type': 'unsigned long', 'name': 'bg'}, {'type': 'unsigned int', 'name': 'depth'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCreatePixmapFromBitmapData_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XCreatePixmapFromBitmapData(IntPtr display, IntPtr d, [In, MarshalAs(UnmanagedType.LPArray)] byte[] data, uint width, uint height, ulong fg, ulong bg, uint depth);

            // Pixmap: XCreateBitmapFromData [{'type': 'Display*', 'name': 'display'}, {'type': 'Drawable', 'name': 'd'}, {'type': 'char*', 'name': 'data'}, {'type': 'unsigned int', 'name': 'width'}, {'type': 'unsigned int', 'name': 'height'}]
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCreateBitmapFromData_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XCreateBitmapFromData(IntPtr display, IntPtr d, [In, MarshalAs(UnmanagedType.LPArray)] byte[] data, uint width, uint height);
        }
        #endregion

        #region ﾄﾞﾛﾜﾎﾞー
        internal IntPtr drawable;
        public IntPtr Drawable => drawable;

        internal Display display;
        public Display Display => display;

        public IntPtr Handle => drawable;
        #endregion

        public delegate void DestroyPixmapDelegaty();
        internal DestroyPixmapDelegaty DestroyPixmapFunc = null;


        public Pixmap() {
            display = null;
            drawable = IntPtr.Zero;
        }


        /// <summary>
        /// 新規生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="depth">色深度</param>
        public Pixmap(Widgets.IWidget w, int width, int height, int depth) {
            display = w.Handle.Display;
            //Window取得
            IntPtr window = w.Handle.Window.Handle;
            System.Diagnostics.Debug.WriteLine($"Pixmap window={window}<0x{w.Handle.Widget.Handle:x}> width={width} height={height} depth={depth}");
            drawable =
                Xi.XCreatePixmap(display, window, (uint)width, (uint)height, (uint)depth);
            System.Diagnostics.Debug.WriteLine($"Pixmap {drawable}");
            DestroyPixmapFunc = () => {
                Xi.XFreePixmap(display, drawable);
            };
        }

        /// <summary>
        /// 新規生成2
        /// </summary>
        /// <param name="display">ﾃﾞｽﾌﾟﾚー</param>
        /// <param name="window">ｳｲﾝﾄﾞー</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="depth">色深度</param>
        public Pixmap(Display display, Window window, int width, int height, int depth) {
            this.display = display;
            System.Diagnostics.Debug.WriteLine($"Pixmap(N) window=<0x{window.Handle:x}> display=<0x{display.Handle:x}> width={width} height={height} depth={depth}");

            drawable =
                Xi.XCreatePixmap(Display, window.Handle, (uint)width, (uint)height, (uint)depth);
            System.Diagnostics.Debug.WriteLine($"Pixmap(N) <{drawable}>");

            DestroyPixmapFunc = () => {
                System.Diagnostics.Debug.WriteLine($"Pixmap(N) Dispose <{drawable}>");
                Xi.XFreePixmap(Display, drawable);
            };
        }

        /// <summary>
        /// 新規生成3
        /// </summary>
        /// <param name="drm">IDrawable</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="depth">色深度</param>
        public Pixmap(IDrawable drm, int width, int height, int depth) {
            this.display = drm.Display;

            drawable =
                Xi.XCreatePixmap(drm.Display, drm.Drawable, (uint)width, (uint)height, (uint)depth);
            if (drawable == IntPtr.Zero) {
                throw new Exception($"XCreatePixmap == NULL");
            }
            System.Diagnostics.Debug.WriteLine($"Pixmap(N) <{drawable}>");

            DestroyPixmapFunc = () => {
                System.Diagnostics.Debug.WriteLine($"Pixmap(N) Dispose <{drawable}>");
                Xi.XFreePixmap(Display, drawable);
            };
        }

        public Pixmap(IntPtr ptr, DestroyPixmapDelegaty delegaty) {
            this.drawable = ptr;
            this.display = null;
            this.DestroyPixmapFunc = delegaty;
        }

        public void AssignPixmap(IntPtr ptr) {
            this.drawable = ptr;
        }

        /// <summary>
        /// ﾑｯﾌﾟ
        /// </summary>
        /// <param name="pixmap"></param>
        /// <param name="delegaty"></param>
        /// <returns></returns>
        public static Pixmap FromPixmap(IntPtr pixmap, Pixmap.DestroyPixmapDelegaty delegaty) {
            return (new Pixmap(pixmap, delegaty));
        }

        public static Pixmap FromBitmapData(IDrawable drawable, int width, int height, byte[] pixel, TonNurako.X11.Color bg, TonNurako.X11.Color fg, int depth) {
            var pm = new Pixmap();
            pm.drawable = NativeMethods.XCreatePixmapFromBitmapData(drawable.Display.Handle, drawable.Drawable, pixel, (uint)width, (uint)height, fg.Pixel, bg.Pixel, (uint)depth);
            pm.display = drawable.Display;
            pm.DestroyPixmapFunc = () => {
                Xi.XFreePixmap(drawable.Display, pm.drawable);
            };
            return pm;
        }

        public static Pixmap FromBitmapData(IDrawable drawable, int width, int height, byte[] pixel) {
            var pm = new Pixmap();
            pm.drawable = NativeMethods.XCreateBitmapFromData(drawable.Display.Handle, drawable.Drawable, pixel, (uint)width, (uint)height);
            pm.display = drawable.Display;
            pm.DestroyPixmapFunc = () => {
                Xi.XFreePixmap(drawable.Display, pm.drawable);
            };
            return pm;
        }


        #region IDisposable

        public void Dispose() {
            Dispose(true);
            #if RLE
            System.GC.SuppressFinalize(this);
            #endif
        }

        #if RLE
        ~Pixmap() {
            if (drawable != IntPtr.Zero) {
                throw new ResourceLeakException(this);
            }
            Dispose(false);
        }
        #endif

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (disposedValue) {
                return;
            }

            disposedValue = true;
            if (IntPtr.Zero != drawable) {
                DestroyPixmapFunc?.Invoke();
                display = null;
                drawable = IntPtr.Zero;
            }

        }
        #endregion

    }
}
