using System;
using System.Text;
using TonNurako.XImageFormat.Xi;

namespace TonNurako.XImageFormat {
    /// <summary>
    /// XPMの色種別
    /// </summary>
    public enum 色種別 {
        Mono,
        Symbolic,
        Gray4,
        Gray,
        Color
    }

    /// <summary>
    /// の拡張
    /// </summary>
    public static class 色種別の拡張 {
        public static string Key(this 色種別 value) {
            string[] values = { "m", "s", "g4", "g", "c" };
            return values[(int)value];
        }
    }

    /// <summary>
    /// 総天然色
    /// </summary>
    public class 総天然色 
    {
        /// <summary>
        /// XPMの色ﾚｺーﾄﾞに対応
        /// </summary>
        public class ColorRef {
            /// <summary>
            /// ｺﾝｽ
            /// </summary>
            public ColorRef() {
                Converted = false;
            }

            /// <summary>
            /// 色種別
            /// </summary>
            public 色種別 Context { get; set; }

            /// <summary>
            /// 形式
            /// </summary>
            public ColorFormat Format { get; set; }

            /// <summary>
            /// 色記述
            /// </summary>
            public string Color { get; set; }

            /// <summary>
            /// 原色に変換した色
            /// </summary>
            public ぉ ConvertedColor { get; set; }

            /// <summary>
            /// 変換済み？
            /// </summary>
            public bool Converted { get; set; }


        }

        /// <summary>
        /// 文字
        /// </summary>
        public string Char { get; set; }

        /// <summary>
        /// 色
        /// </summary>
        public ColorRef[] Color => colors;

        private ColorRef[] colors;

        /// <summary>
        /// 変換済み色のｲﾝﾃﾞｯｸｽ
        /// </summary>
        public int ConvertedIndex { get; internal set; }

        /// <summary>
        /// 色解決
        /// </summary>
        public I原色 ColorResolver { get; }

        /// <summary>
        /// ｺﾝ
        /// </summary>
        /// <param name="cres">原色</param>
        public 総天然色(I原色 cres) {
            colors = null;
            ColorResolver = cres;
        }
        
        /// <summary>
        /// 内部用(LUTのｲﾝﾃﾞｯｸｽ)
        /// </summary>
        internal int LutIndex { get; set; }

        /// <summary>
        /// 警察
        /// </summary>
        /// <param name="zise">ｻｲｽﾞ</param>
        public void Alloc(int zise) => colors = new ColorRef[zise];

        /// <summary>
        /// ぉに変換
        /// </summary>
        /// <param name="index">色</param>
        /// <returns>ぉ</returns>
        public ぉ Toぉ(int index = -1) {
            if (index != -1) {
                var c = ColorResolver.Lookup(colors[index].Format, colors[index].Color);
                if (null == c) {
                    throw new およよ($"色解決失敗: {colors[0].Color}");
                }
                return c;
            }
            index = ConvertedIndex;
            if (colors[index].Converted) {
                return colors[index].ConvertedColor;
            }

            for (int i = 0; i < colors.Length; ++i) {
                if (colors[i].Converted) {
                    return colors[i].ConvertedColor;
                }
                var k = ColorResolver.Lookup(colors[i].Format, colors[i].Color);
                if (null != k) {
                    colors[i].ConvertedColor = k;
                    colors[i].Converted = true;
                    return colors[i].ConvertedColor;
                }
            }
            throw new およよ($"色解決失敗: {colors[0].Color}");
        }

        /// <summary>
        /// System.Drawing.Colorに変換
        /// </summary>
        /// <param name="index">色</param>
        /// <returns>色</returns>
        public System.Drawing.Color ToColor(int index = -1) {
            try {
                var c = Toぉ(index);
                return System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);
            }
            catch (およよ e) {
                throw new およよ($"色解決失敗: {e.Message}", e);
            }
        }
        
        /// <summary>
        /// XPMの色定義に変換
        /// </summary>
        /// <returns>色</returns>
        public string ToColorString() {
            StringBuilder sb = new StringBuilder(Char);
            foreach (var c in colors) {
                sb.Append(" ")
                    .Append(c.Context.Key())
                    .Append(" ")
                    .Append(c.Color);
            }
            return sb.ToString();
        }

        /// <summary>
        /// ColorRefを解決して原色にする
        /// </summary>
        /// <param name="cr">原色</param>
        /// <param name="color">ColorRef</param>
        /// <returns>ぉ</returns>
        internal static ぉ ParseColor(I原色 cr, ColorRef color) {
            var rgb = cr.Lookup(color.Format, color.Color);
            if (null == rgb) {
                throw new およよ($"ﾌﾟﾘｾｯﾄに見当たらねえ: {color.Color}");
            }
            return rgb;
        }

        /// <summary>
        /// XPMの色定義をColorRefにする
        /// </summary>
        /// <param name="cr">原色</param>
        /// <param name="c">種別</param>
        /// <param name="color">色</param>
        /// <returns>ColorRef</returns>
        public static ColorRef ParseColorRef(I原色 cr, string c, string color) {
            var r = new ColorRef();
            switch (c) {
                case "m":
                    r.Context = 色種別.Mono;
                    break;
                case "c":
                    r.Context = 色種別.Color;
                    break;
                case "s":
                    r.Context = 色種別.Symbolic;
                    break;
                case "g4":
                    r.Context = 色種別.Gray4;
                    break;
                case "g":
                    r.Context = 色種別.Gray;
                    break;
                default:
                    throw new およよ($"しらねえﾌｫーﾏｯﾂ {c}");
            }
            r.Color = color;
            switch (r.Color[0]) {
                case '#':
                    r.Format = ColorFormat.RGB;
                    break;
                case '%':
                    r.Format = ColorFormat.HSV;
                    break;
                default:
                    r.Format = ColorFormat.Name;
                    break;
            }

            try {
                r.ConvertedColor = ParseColor(cr, r);
                r.Converted = true;
            }
            catch (およよ) {
                r.Converted = false;
            }
            return r;
        }

        /// <summary>
        /// XPMの色定義から総天然色のｲﾝｽﾀﾝｽを作る
        /// </summary>
        /// <param name="xpm">XPM</param>
        /// <param name="src">色定義</param>
        /// <returns>総天然色</returns>
        public static 総天然色 Parse(Xpm xpm, string src) {
            var r = new 総天然色(xpm.ColorResolver);
            // CPP分
            r.Char = src.Substring(0, xpm.CharsPerPixel);
            var vs = src.Substring(xpm.CharsPerPixel + 1).Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            r.colors = new ColorRef[vs.Length / 2];
            for (int i = 0, j = 0; i < vs.Length; i += 2, j++) {
                r.colors[j] = ParseColorRef(xpm.ColorResolver, vs[i], vs[i + 1]);
                if (r.colors[j].Converted) {
                    r.ConvertedIndex = j;
                }
            }

            return r;
        }

    }
}

