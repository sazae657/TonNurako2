//
// ﾄﾝﾇﾗｺ
//
// GC
//
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TonNurako.X11;
using TonNurako.Xt;
using TonNurako.XImageFormat;
using TonNurako.Native;

namespace TonNurako.GC
{
#region I原色
    /// <summary>
    /// XPM用の原色実装
    /// </summary>
    public sealed class X11ColorResolver :
        TonNurako.XImageFormat.I原色 {

        public X11ColorResolver(Widgets.IWidget widget) {
            Widget = widget;
            colorMap = new Dictionary<string, XImageFormat.Xi.ぉ>();
        }

        public X11ColorResolver(Widgets.IWidget widget, XImageFormat.Xi.ぉ bg, XImageFormat.Xi.ぉ fg) {
            Widget = widget;
            colorMap = new Dictionary<string, XImageFormat.Xi.ぉ>();
        }

        Dictionary<string, XImageFormat.Xi.ぉ> colorMap;

        Widgets.IWidget Widget;

        XImageFormat.Xi.ぉ 
            XImageFormat.I原色.Black => Lookup(XImageFormat.Xi.ColorFormat.Name, "black");

        XImageFormat.Xi.ぉ 
            XImageFormat.I原色.White => Lookup(XImageFormat.Xi.ColorFormat.Name, "white");

        XImageFormat.Xi.ぉ 
            XImageFormat.I原色.None => Lookup(XImageFormat.Xi.ColorFormat.Name, "none");

        XImageFormat.Xi.ぉ
            XImageFormat.I原色.Foreground => Lookup(XImageFormat.Xi.ColorFormat.Name, "foreground");

        XImageFormat.Xi.ぉ 
            XImageFormat.I原色.Background => Lookup(XImageFormat.Xi.ColorFormat.Name, "background");


        public TonNurako.XImageFormat.Xi.ぉ Lookup(XImageFormat.Xi.ColorFormat fmt, string color) {
            var key = color.ToLower();
            if (colorMap.ContainsKey(key)) {
                return colorMap[key];
            }
            var c = GC.Color.FromName(Widget, color);

            var k = new XImageFormat.Xi.ぉ(c.R, c.G, c.B);
            colorMap.Add(key, k);
            return k;
        }

    }
    #endregion

    public class PixmapFactory {
        PixmapFactory() {
        }


        /// <summary>
        /// ﾌｧｲﾙから生成(Motif)
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="path">ﾌｧｲﾙ</param>
        /// <returns></returns>
        public static Pixmap FromFile(Widgets.Xm.Primitive w, string path) {
            Pixmap pm = new Pixmap();
            pm.display = new TonNurako.X11.Display(() => TonNurako.Xt.XtSports.XtDisplay(w));
            //pm.drawable.Screen = new TonNurako.X11.Screen(()=>TonNurako.Xt.XtSports.XtScreen(w));

            pm.drawable = (IntPtr)TonNurako.Motif.XmSports.XmGetPixmap(w.Handle.Screen.Handle, path,
                w.BackgroundColor.Pixel,
                w.ForegroundColor.Pixel
            );
            pm.DestroyPixmapFunc = () => {
                TonNurako.Motif.XmSports.XmDestroyPixmap(pm.Display.Handle, pm.Drawable);
            };
            return pm;
        }

        /// <summary>
        /// ﾌｧｲﾙから生成(Motif)
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="path">ﾌｧｲﾙ</param>
        /// <returns></returns>
        public static Pixmap FromFile(Widgets.Xm.Manager w, string path) {
            Pixmap pm = new Pixmap();
            pm.display = new Display(() => TonNurako.Xt.XtSports.XtDisplay(w));
            //pm.drawable.Screen = new Screen(() => TonNurako.Xt.XtSports.XtScreen(w));
            var xpm = TonNurako.Motif.XmSports.XmGetPixmap(w.Handle.Screen.Handle, path,
                w.BackgroundColor.Pixel,
                w.ForegroundColor.Pixel
            );
            pm.drawable = (IntPtr)xpm;
            pm.DestroyPixmapFunc = () => {
                TonNurako.Motif.XmSports.XmDestroyPixmap(w.Handle.Screen.Handle, pm.drawable);
            };
            return pm;
        }

        /// <summary>
        /// ﾊﾞｯﾌｧーから生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="buffer">ﾊﾞｯﾌｧー</param>
        /// <returns></returns>
        public static Pixmap FromXpm(Widgets.IWidget w, byte[] buffer) {
            var loader = new XImageFormat.XpmLoader(new X11ColorResolver(w));
            XImageFormat.Xpm 画像 = null;
            using (var ms = new System.IO.MemoryStream(buffer)) {
                画像 = loader.Load(ms);
            }

            var buf = 画像.Toぉ();
            var mp = XImageFormat.Xi.おやさい.原色配列に変換(
                    XImageFormat.Xi.ぉ.画素.B,
                    XImageFormat.Xi.ぉ.画素.G,
                    XImageFormat.Xi.ぉ.画素.R,
                    XImageFormat.Xi.ぉ.画素.A, ref buf);
            TonNurako.X11.Pixmap pixmap = null;
            using (
                var img = TonNurako.GC.XImage.FromBuffer(w, mp, 画像.Width, 画像.Height, 24, 32)) {
                pixmap = PixmapFactory.FromXImageEx(w, img);
            }
            return pixmap;
        }

        /// <summary>
        /// ﾌｧｲﾙから生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="buffer">ﾊﾞｯﾌｧー</param>
        /// <returns></returns>
        public static Pixmap FromXpm(Widgets.IWidget w, string path) {
            var loader = new XImageFormat.XpmLoader(new X11ColorResolver(w));
            XImageFormat.Xpm 画像 = null;
            using (var ms = new System.IO.FileStream(path, System.IO.FileMode.Open)) {
                画像 = loader.Load(ms);
            }

            var buf = 画像.Toぉ();
            var mp = XImageFormat.Xi.おやさい.原色配列に変換(
                    XImageFormat.Xi.ぉ.画素.B,
                    XImageFormat.Xi.ぉ.画素.G,
                    XImageFormat.Xi.ぉ.画素.R,
                    XImageFormat.Xi.ぉ.画素.A, ref buf);
            TonNurako.X11.Pixmap pixmap = null;
            using (
                var img = TonNurako.GC.XImage.FromBuffer(w, mp, 画像.Width, 画像.Height, 24, 32)) {
                pixmap = PixmapFactory.FromXImageEx(w, img);
            }
            return pixmap;
        }

        /// <summary>
        /// XImageから生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="path">ﾌｧｲﾙ</param>
        /// <returns></returns>
        public static Pixmap FromXImage(Widgets.IWidget w, XImage image) {
            var pm = new Pixmap(w, image.Width, image.Height, image.Depth);
            using (GraphicsContext gc = new GraphicsContext(pm)) {
                gc.PutImage(image);
            }
            return pm;
        }

        /// <summary>
        /// XImageから生成 (Root)
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="path">ﾌｧｲﾙ</param>
        /// <returns></returns>
        public static Pixmap FromXImageEx(Widgets.IWidget w, XImage image) {
            var pm = new Pixmap(w.Handle.Display,
                w.Handle.RootWindowOfScreen, image.Width, image.Height, image.Depth);
            using (GraphicsContext gc = new GraphicsContext(pm)) {
                gc.PutImage(image);
            }
            return pm;
        }

        /// <summary>
        /// Bitmapから生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="path">ﾌｧｲﾙ</param>
        /// <returns></returns>
        public static Pixmap FromBitmap(Widgets.IWidget w, System.Drawing.Bitmap bitmap) {
            var pm = new Pixmap(w, bitmap.Width, bitmap.Height, 24);
            using (var image = XImage.FromBitmap(w, bitmap))
            using (var gc = new GraphicsContext(pm)) {
                gc.PutImage(image);
            }
            return pm;
        }


        /// <summary>
        /// Bitmapから生成
        /// </summary>
        /// <param name="w">ｳｲｼﾞｪｯﾄ</param>
        /// <param name="path">ﾌｧｲﾙ</param>
        /// <returns></returns>
        public static Pixmap FromBitmap(IDrawable drawable, System.Drawing.Bitmap bitmap) {
            var pm = new Pixmap(drawable, bitmap.Width, bitmap.Height, 24);
            using (var image = XImage.FromBitmap(drawable, bitmap))
            using (var gc = new GraphicsContext(pm)) {
                gc.PutImage(image);
            }
            return pm;
        }

    }

}
