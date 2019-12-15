using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TonNurako.XImageFormat.Xi;

namespace TonNurako.XImageFormat {
    /// <summary>
    /// XPM
    /// </summary>
    public class Xpm : 原色画像 {
        /// <summary>
        /// 火山
        /// </summary>
        public enum VulkanIndex : int {
            Columns,
            Rows,
            Colors,
            CharsPerPixel,
            XHotSpot,
            YHotSpot,
            __MAX__
        }

        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ－
        /// </summary>
        public Xpm() {
            Values = new int[(int)VulkanIndex.__MAX__];
            ColorTable = new Dictionary<string, 総天然色>();
            ColorLookupTable = new List<総天然色>();
            XHotSpot =
            YHotSpot = -1;
        }

        /// <summary>
        /// 桁数(幅)
        /// </summary>
        public int Columns {
            get { return Values[(int)VulkanIndex.Columns]; }
            set { Values[(int)VulkanIndex.Columns] = value; }
        }

        /// <summary>
        /// 行数(高さ)
        /// </summary>
        public int Rows {
            get { return Values[(int)VulkanIndex.Rows]; }
            set { Values[(int)VulkanIndex.Rows] = value; }
        }

        /// <summary>
        /// 色数
        /// </summary>
        public int NumColors {
            get { return Values[(int)VulkanIndex.Colors]; }
            set { Values[(int)VulkanIndex.Colors] = value; }
        }

        /// <summary>
        /// 1ﾋﾟｸｾﾙ辺りの文字数
        /// </summary>
        public int CharsPerPixel {
            get { return Values[(int)VulkanIndex.CharsPerPixel]; }
            set { Values[(int)VulkanIndex.CharsPerPixel] = value; }
        }

        /// <summary>
        /// 当たり判定(X)
        /// </summary>
        public int XHotSpot {
            get { return Values[(int)VulkanIndex.XHotSpot]; }
            set { Values[(int)VulkanIndex.XHotSpot] = value; }
        }

        /// <summary>
        /// 当たり判定(Y)
        /// </summary>
        public int YHotSpot {
            get { return Values[(int)VulkanIndex.XHotSpot]; }
            set { Values[(int)VulkanIndex.XHotSpot] = value; }
        }

        /// <summary>
        /// 色解決
        /// </summary>
        public I原色 ColorResolver { get; set; }

        /// <summary>
        /// XPMのﾋﾟｸｾﾙﾃﾞーﾀ
        /// </summary>
        public int[][] Pixels { get; set; } = null;

        /// <summary>
        /// 色解決ﾃーﾌﾞﾙ
        /// </summary>
        public Dictionary<string, 総天然色> ColorTable {
            get;
        }

        /// <summary>
        /// LUT
        /// </summary>
        public List<総天然色> ColorLookupTable {
            get;
        }

        public void AddColor(総天然色 c) {
            if (ColorTable.ContainsKey(c.Char)) {
                return;
            }
            c.LutIndex = ColorLookupTable.Count;
            ColorTable.Add(c.Char, c);
            ColorLookupTable.Add(c);
        }

        public void SetPixel(int x, int y, string pixel) {
            Pixels[y][x] = ColorTable[pixel].LutIndex;
        }

        public void AllocPixels() {
            AllocPixels(Rows, Columns);
        }
        public void AllocPixels(int rows, int cols) {
            Pixels = new int[rows][];
            for (int i = 0; i < rows; ++i) {
                Pixels[i] = new int[cols];
            }
        }

        public int [] Values { get; set; } = null;


        #region I原色画像
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 幅
        /// </summary>
        public int Width {
            get { return Columns; }
            set { Columns = value; }
        }

        /// <summary>
        /// 高さ
        /// </summary>
        public int Height {
            get { return Rows; }
            set { Rows = value; }
        }

        ぉ[] ぉぃぉぃ;
        /// <summary>
        /// ぉ
        /// </summary>
        /// <returns>ぉ</returns>
        public ぉ[] Toぉ() {
            ぉぃぉぃ = new ぉ[Columns * Rows];
            int s = 0;
            for (int y = 0; y < Rows; ++y) {
                for (int x = 0; x < Columns; ++x) {
                    var p = ColorLookupTable[Pixels[y][x]];
                    ぉぃぉぃ[s] = p.Toぉ();
                    if (null == ぉぃぉぃ[s]) {
                        throw new およよ($"色解決失敗: {p.ToColorString()}");
                    }
                    s++;
                }
            }
            return ぉぃぉぃ;
        }
        #endregion


        /// <summary>
        /// XPM
        /// </summary>
        const string XPMCHARS = " .+@#$%&*=-;>,')!~{]^/(_:<[}|1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ`";

        /// <summary>
        /// ｶﾗーﾏｯﾌﾟ生成
        /// </summary>
        /// <param name="pix">ぉ</param>
        /// <param name="rpp">1ﾋﾟｸｾﾙ辺りの文字数(Tupleが公式ｻﾎﾟーﾄされたらTupleで返そう)</param>
        /// <returns>色</returns>
        public static Dictionary<string, 総天然色> GenerateColorMap(ぉ[] pix, out int rpp) {
            var cmap = new Dictionary<ぉ, int>();
            cmap.Add(new ぉ(0, 0, 0, 0), 0);
            int pi = 1;
            foreach (var c in pix) {
                if (!cmap.ContainsKey(c)) {
                    cmap.Add(c, pi++);
                }
            }
            var dik = XPMCHARS.Length - 1;
            // 桁数
            int cn = cmap.Count < dik ? 1 : (cmap.Count / (XPMCHARS.Length * XPMCHARS.Length)) + 2;
            rpp = cn;

            var keys = new string[cmap.Count];
            int[] ack = new int[cn];
            int vc = 0;
            for (int j = 0; j < cn; j++) {
                ack[j] = j;
            }
            int cni = 0;

            for (int i = 0; i < cmap.Count; i++) {
                keys[i] = XPMCHARS[vc].ToString();
                for (int j = 1; j < cn; j++) {
                    keys[i] += XPMCHARS[ack[j - 1]];
                }
                vc++;
                if (vc > dik) {
                    vc = 0;
                    if (++ack[cni] >= dik) {
                        cni++;
                    }
                }
            }
            var 原色 = new Fallback原色();

            var ret = new Dictionary<string, 総天然色>();
            foreach (var c in cmap.Keys) {
                var k = keys[cmap[c]];
                var g = new 総天然色(原色);
                g.Alloc(1);
                if (cmap[c] == 0) {
                    g.Char = k;
                    g.Color[0] = new 総天然色.ColorRef();
                    g.Color[0].Context = 色種別.Color;
                    g.Color[0].Format = ColorFormat.Name;
                    g.Color[0].Color = "None";
                }
                else {
                    g.Char = k;
                    g.Color[0] = new 総天然色.ColorRef();
                    g.Color[0].Context = 色種別.Color;
                    g.Color[0].Format = ColorFormat.RGB;
                    g.Color[0].Color = c.ToXRGB16();
                }
                ret.Add(k, g);
            }
            return ret;
        }

        /// <summary>
        /// System.Drawing.Bitmapに変換
        /// </summary>
        /// <returns>System.Drawing.Bitmap</returns>
        public System.Drawing.Bitmap ToBitmap() {
            var bitmap = new System.Drawing.Bitmap(Columns, Rows);

            var data = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var svc = this.Toぉ();
            int k = 0;
            for (int i = 0; i < (Columns * Rows); i++, k += 4) {
                var c = svc[i];
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
        /// System.Drawing.Bitmapから変換
        /// </summary>
        /// <param name="bitmap">ﾍﾞｯﾄﾑｯﾌﾟ</param>
        /// <returns>XPM</returns>
        public static Xpm FromBitmap(System.Drawing.Bitmap bitmap) {
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
            return Fromぉ(bitmap.Width, bitmap.Height, arr);
        }

        /// <summary>
        /// ぉからXPMを生成
        /// </summary>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="pixels">ﾋﾟｸｾﾙﾃﾞﾀー</param>
        /// <returns>XPM</returns>
        public static Xpm Fromぉ(int width, int height, ぉ [] pixels) {
            var xpm = new Xpm();
            xpm.Rows = height;
            xpm.Columns = width;
            xpm.AllocPixels();

            int cpp = 0;
            foreach (var c in GenerateColorMap(pixels, out cpp).Values) {
                xpm.AddColor(c);
            }
            xpm.NumColors = xpm.ColorTable.Count;
            xpm.CharsPerPixel = cpp;
            // 逆引きﾃーﾌﾞﾙを作っとく
            var rt = new Dictionary<ぉ, string>();
            foreach (var c in xpm.ColorTable.Keys) {
                var s = xpm.ColorTable[c];
                var o = s.Toぉ();
                if (null == o) {
                    throw new およよ($"色解決失敗: {s.ToColorString()}");
                }
                if (!rt.ContainsKey(o)) {
                    rt.Add(o, c);
                }
            }

            int pos = 0;
            for (int y = 0; y < xpm.Rows; ++y) {
                for (int x = 0; x < xpm.Columns; ++x) {
                    xpm.SetPixel(x, y, rt[pixels[pos]]);
                    pos++;
                }
            }

            return xpm;
        }

    }
}
