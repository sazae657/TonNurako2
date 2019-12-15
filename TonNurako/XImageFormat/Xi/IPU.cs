using System;
using System.Runtime.InteropServices;

namespace TonNurako.XImageFormat.Xi {

    /// <summary>
    /// ﾋﾟｸｾﾙﾃﾞﾀーの変換関数群
    /// </summary>
    public class おやさい {

        /// <summary>
        /// 原色画像をﾋﾞｯﾄﾏｯﾌﾟに変換する
        /// </summary>
        /// <param name="img">原色画像</param>
        /// <returns>ﾋﾞｯﾄﾏｯﾌﾟ</returns>
        public static System.Drawing.Bitmap ﾍﾞｯﾄﾑｯﾌﾟに変換(原色画像 img) {
            return ﾍﾞｯﾄﾑｯﾌﾟに変換(img.Width, img.Height, img.Toぉ());
        }

        /// <summary>
        /// ぉをﾍﾞｯﾄﾑｯﾋﾟに変換する
        /// </summary>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞﾀー</param>
        /// <returns>ﾍﾞｯﾄﾑｯﾋﾟ</returns>
        public static System.Drawing.Bitmap ﾍﾞｯﾄﾑｯﾌﾟに変換(int width, int height, ぉ[] arr)
        {
            var bitmap = new System.Drawing.Bitmap(width, height);

            var data = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            int k = 0;
            for (int i = 0; i < (width * height); i++, k += 4) {
                var c = arr[i];
                byte r = (byte)(c.R & 0xff);
                byte g = (byte)(c.G & 0xff);
                byte b = (byte)(c.B & 0xff);
                byte a = (byte)(c.A & 0xff);

                Int32 value = (a << 24) | (r << 16) | (g << 8) | b;
                Marshal.WriteInt32(data.Scan0, k, value);
            }
            bitmap.UnlockBits(data);

            return bitmap;
        }

        /// <summary>
        /// 原色配列をRGBAで詰め込んだbyte配列に変換
        /// </summary>
        /// <param name="arr">原色配列</param>
        /// <returns>byte配列</returns>
        public static byte[] 原色配列に変換(ref ぉ[] arr) {
            var ret = new byte[arr.Length * 4];
            int k = 0;
            foreach (var o in arr) {
                ret[k++] = (byte)o.R;
                ret[k++] = (byte)o.G;
                ret[k++] = (byte)o.B;
                ret[k++] = (byte)o.A;
            }
            return ret;
        }

        /// <summary>
        /// 指定画素順でbyte配列に詰め込む
        /// ex. 
        ///  原色配列に変換(ぉ.画素.B,ぉ.画素.G,ぉ.画素.R,ぉ.画素.A, arr) -> [B|G|R|A]
        /// </summary>
        /// <param name="ch0"></param>
        /// <param name="ch1"></param>
        /// <param name="ch2"></param>
        /// <param name="ch3"></param>
        /// <param name="arr">原色配列</param>
        /// <returns>byte配列</returns>
        public static byte[] 原色配列に変換(ぉ.画素 ch0, ぉ.画素 ch1, ぉ.画素 ch2, ぉ.画素 ch3, ref ぉ[] arr) {
            var ret = new byte[arr.Length*4];
            int k = 0;
            foreach(var o in arr) {
                ret[k++] = (byte)o.ほ(ch0);
                ret[k++] = (byte)o.ほ(ch1);
                ret[k++] = (byte)o.ほ(ch2);
                ret[k++] = (byte)o.ほ(ch3);
            }
            return ret;
        }

        /// <summary>
        /// 指定画素順でbyte配列に詰め込む、ただしｱﾙﾌｧーﾁｬﾈﾙは255埋め
        /// ex. 
        ///  原色配列に変換(ぉ.画素.R,ぉ.画素.G,ぉ.画素.B, false, arr) -> [R|G|B]
        ///  原色配列に変換(ぉ.画素.R,ぉ.画素.G,ぉ.画素.B, true, arr) -> [R|G|B|0xff]
        /// </summary>
        /// <param name="ch0"></param>
        /// <param name="ch1"></param>
        /// <param name="ch2"></param>
        /// <param name="alpha">ｱﾙﾌｧーﾁｬﾈﾙ有無</param>
        /// <param name="arr">原色配列</param>
        /// <returns>byte配列</returns>
        public static byte[] 原色配列に変換(ぉ.画素 ch0, ぉ.画素 ch1, ぉ.画素 ch2, bool alpha, ref ぉ[] arr) {
            var ret = new byte[arr.Length * (alpha ? 4 : 3)];
            int k = 0;
            foreach (var o in arr) {
                ret[k++] = (byte)o.ほ(ch0);
                ret[k++] = (byte)o.ほ(ch1);
                ret[k++] = (byte)o.ほ(ch2);
                if (alpha) {
                    ret[k++] = 0xFF;
                }
            }
            return ret;
        }

        /// <summary>
        /// XBM形式の配列に詰め込む
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="ch"></param>
        /// <param name="反転"></param>
        /// <param name="arr"></param>
        /// <returns>byte配列</returns>
        public static byte[] XBM配列に変換(int width, int height, ぉ.画素 ch, bool 反転, ぉ[] arr) {
            return XbmWriter.ToBitmap(width, height, ch, 反転, arr);
        }


        /// <summary>
        /// System.Drawing.Bitmapから変換
        /// </summary>
        /// <param name="bitmap">ﾍﾞｯﾄﾑｯﾌﾟ</param>
        /// <returns>XPM</returns>
        public static ぉ[] ぉに変換(System.Drawing.Bitmap bitmap) {
            var arr = new ぉ[bitmap.Width * bitmap.Height];

            System.Drawing.Imaging.BitmapData data = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int bytes = bitmap.Width * bitmap.Height * 4;
            for (int i = 0, j = 0; i < bytes; i += 4, j++) {
                Int32 value = Marshal.ReadInt32(data.Scan0, i);
                byte b = (byte)(value & 0xff);
                byte g = (byte)((value >> 8) & 0xff);
                byte r = (byte)((value >> 16) & 0xff);
                byte a = (byte)((value >> 24) & 0xff);
                if (a == 0) {
                    r = g = b = 0;
                }
                else {
                    a = 0xff;
                }
                arr[j] = new ぉ(r, g, b, a);
            }
            bitmap.UnlockBits(data);
            return arr;
        }

    }
}
