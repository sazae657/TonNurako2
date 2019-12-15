//
// ﾄﾝﾇﾗｺ
//
// GC
//
using System;
using System.Runtime.InteropServices;
using TonNurako.X11;
using TonNurako.Xt;


namespace TonNurako.GC
{
    /// <summary>
    /// XImage
    /// </summary>
    public class XImage : IDisposable {
        internal static class NativeMethods {
            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XCreateImage_TNK", CharSet=CharSet.Auto)]
            internal static extern IntPtr XCreateImage(IntPtr display,
                    int visual, uint depth, XImage.Format format, int offset, IntPtr data, uint width, uint height, int bitmap_pad, int bytes_per_line);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XGetPixel_TNK", CharSet=CharSet.Auto)]
            internal static extern ulong XGetPixel(IntPtr ximage, int x, int y);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XPutPixel_TNK", CharSet=CharSet.Auto)]
            internal static extern int XPutPixel(IntPtr ximage, int x, int y, ulong pixel);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XSubImage_TNK", CharSet=CharSet.Auto)]
            internal static extern IntPtr XSubImage(IntPtr ximage, int x, int y, uint subimage_width, uint subimage_height);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XAddPixel_TNK", CharSet=CharSet.Auto)]
            internal static extern int XAddPixel(IntPtr ximage, long value);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XDestroyImage_TNK", CharSet=CharSet.Auto)]
            internal static extern int XDestroyImage(IntPtr ximage);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XPutImage_TNK", CharSet=CharSet.Auto)]
            internal static extern int XPutImage(IntPtr display, IntPtr d, IntPtr gc, IntPtr image, int src_x, int src_y, int dest_x, int dest_y, uint width, uint height);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XGetImage_TNK", CharSet=CharSet.Auto)]
            internal static extern IntPtr XGetImage(IntPtr display, IntPtr d, int x, int y, uint width, uint height, ulong plane_mask, int format);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XGetSubImage_TNK", CharSet=CharSet.Auto)]
            internal static extern IntPtr XGetSubImage(IntPtr display, IntPtr d, int x, int y, uint width, uint height, ulong plane_mask, int format, IntPtr dest_image, int dest_x, int dest_y);
        }

        /// <summary>
        /// XImageﾌｫーﾏｯﾄ
        /// </summary>
        public enum Format : int{
            XYBitmap = TonNurako.X11.Constant.XYBitmap,
            XYPixmap = TonNurako.X11.Constant.XYPixmap,
            ZPixmap = TonNurako.X11.Constant.ZPixmap,
        }

        /// <summary>
        /// XImageの参照
        /// </summary>
        private IntPtr image = IntPtr.Zero;

        /// <summary>
        /// 中身への参照
        /// </summary>
        public IntPtr Handle { get {return image; } }

        /// <summary>
        /// 変換ﾊﾞｯﾌｧー
        /// </summary>
        private IntPtr convertBuffer = IntPtr.Zero;

        /// <summary>
        /// 幅
        /// </summary>
        public int Width {get; internal set;}

        /// <summary>
        /// 高さ
        /// </summary>
        public int Height {get; internal set;}

        /// <summary>
        /// 深度
        /// </summary>
        public int Depth {get; internal set;}

        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀー
        /// </summary>
        public XImage() {
        }

        /// <summary>
        /// System.Drawing.Bitmapから生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="bitmap">bitmap</param>
        /// <returns>XImageのｲﾝｽﾀﾝｽ</returns>
        public static XImage FromBitmap(Widgets.IWidget w, System.Drawing.Bitmap bitmap) {
            var im = new XImage();

            var data = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int bytes = bitmap.Width * bitmap.Height * 4;
            byte[] buf = new byte[bytes];
            Marshal.Copy(data.Scan0, buf, 0, buf.Length);
            bitmap.UnlockBits(data);

            im.convertBuffer = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(byte)) * (buf.Length+1));
            Marshal.Copy(buf, 0, im.convertBuffer, buf.Length);

            im.image = NativeMethods.XCreateImage(w.Handle.Display.Handle,
                0, 24, Format.ZPixmap, 0, im.convertBuffer, (uint)bitmap.Width, (uint)bitmap.Height, 32, 0);

            im.Width = bitmap.Width;
            im.Height = bitmap.Height;
            im.Depth = 24;
            return im;
        }

        /// <summary>
        /// System.Drawing.Bitmapから生成(2)
        /// </summary>
        /// <param name="w">IDrawable</param>
        /// <param name="bitmap">bitmap</param>
        /// <returns>XImageのｲﾝｽﾀﾝｽ</returns>
        public static XImage FromBitmap(IDrawable w, System.Drawing.Bitmap bitmap) {
            var im = new XImage();

            var data = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int bytes = bitmap.Width * bitmap.Height * 4;
            byte[] buf = new byte[bytes];
            Marshal.Copy(data.Scan0, buf, 0, buf.Length);
            bitmap.UnlockBits(data);

            im.convertBuffer = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(byte)) * (buf.Length + 1));
            Marshal.Copy(buf, 0, im.convertBuffer, buf.Length);

            im.image = NativeMethods.XCreateImage(w.Display.Handle,
                0, 24, Format.ZPixmap, 0, im.convertBuffer, (uint)bitmap.Width, (uint)bitmap.Height, 32, 0);

            im.Width = bitmap.Width;
            im.Height = bitmap.Height;
            im.Depth = 24;
            return im;
        }

        /// <summary>
        /// ﾊﾞｯﾌｧーから生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="buffer">ﾊﾞｯﾌｧー</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="depth">色深度</param>
        /// <param name="bpp">BPP</param>
        /// <returns>XImageのｲﾝｽﾀﾝｽ</returns>
        public static XImage FromBuffer(Widgets.IWidget w, byte[] buffer,int width, int height,int depth, int bpp) {
            var im = new XImage();
            im.convertBuffer = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(byte)) * (buffer.Length+1));
            Marshal.Copy(buffer, 0, im.convertBuffer, buffer.Length);

            im.image = NativeMethods.XCreateImage(w.Handle.Display.Handle,
                0, (uint)depth, Format.ZPixmap, 0, im.convertBuffer, (uint)width, (uint)height, bpp, 0);
            im.Width = width;
            im.Height = height;
            im.Depth = depth;
            return im;
        }

        internal void PutImage(Display dpy, IntPtr d, IntPtr gc, int sx, int sy, int dx, int dy, int w, int h) {
            NativeMethods.XPutImage(dpy.Handle, d, gc, image, sx, sy, dx, dy, (uint)w, (uint)h);
        }

#region IDisposable ﾒﾝﾊﾞー
        private bool disposed = false;


        /// <summary>
        /// 後始末
        /// </summary>
		public void Dispose()
		{
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        ~XImage() {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposed) {
                return;
            }

            if (IntPtr.Zero != image) {
                NativeMethods.XDestroyImage(image);
                image = IntPtr.Zero;
            }
            if (IntPtr.Zero != convertBuffer) {
                Marshal.FreeCoTaskMem(convertBuffer);
                convertBuffer = IntPtr.Zero;
            }
            disposed = true;
        }

#endregion
    }
}
