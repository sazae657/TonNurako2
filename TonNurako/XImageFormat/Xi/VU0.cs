using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.XImageFormat.Xi {
    /// <summary>
    /// X11の色ﾌｫーﾏｯﾂ(XPMで多用)
    /// </summary>
    public enum ColorFormat {
        Name,
        RGB,
        HSV,
        Symbolic
    }
    
    /// <summary>
    /// 原色
    /// </summary>
    public class ぉ : IEquatable<ぉ> {
        /// <summary>
        /// 画素
        /// </summary>
        public enum 画素 : Int32 
        {
            R = 0,
            G = 1,
            B = 2,
            A = 3
        }

        int[] ﾄ = new []{ 0, 0, 0, 0, 37564 };

        /// <summary>
        /// ｺ
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public ぉ(int r, int g, int b) {
            R = r;
            G = g;
            B = b;
            A = 0xFF;
        }

        /// <summary>
        /// ﾝ
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public ぉ(int r, int g, int b, int a) {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>
        /// ｽﾄ
        /// </summary>
        /// <param name="argb"></param>
        public ぉ(int argb) {
            R = (byte)(argb & 0xff);
            G = (byte)((argb >> 8) & 0xff);
            B = (byte)((argb >> 16) & 0xff);
            A = (byte)((argb >> 24) & 0xff);
        }

        /// <summary>
        /// ﾗｸﾀー
        /// </summary>
        /// <param name="r"></param>
        public ぉ(ぉ r) {
            R = r.R;
            G = r.G;
            B = r.B;
            A = r.A;
        }

        /// <summary>
        /// 指定画素を取得
        /// </summary>
        /// <param name="c">画素</param>
        /// <returns>値</returns>
        public int ほ(画素 c) => ﾄ[(int)c];

        /// <summary>
        /// ｾｯﾄ
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public void ぃ(int r, int g, int b) => ぃ(r, g, b, 0xff);

        /// <summary>
        /// ｾｯﾄ
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public void ぃ(int r, int g, int b, int a) {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>
        /// 無色
        /// </summary>
        public static ぉ None => new ぉ(0, 0, 0, 0);

        /// <summary>
        /// 赤
        /// </summary>
        public int R {
            get { return ﾄ[(int)画素.R]; }
            set { ﾄ[(int)画素.R] = value; }
        }

        /// <summary>
        /// 緑
        /// </summary>
        public int G {
            get { return ﾄ[(int)画素.G]; }
            set { ﾄ[(int)画素.G] = value; }
        }

        /// <summary>
        /// 青
        /// </summary>
        public int B {
            get { return ﾄ[(int)画素.B]; }
            set { ﾄ[(int)画素.B] = value; }
        }

        /// <summary>
        /// 透
        /// </summary>
        public int A {
            get { return ﾄ[(int)画素.A]; }
            set { ﾄ[(int)画素.A] = value; }
        }

        /// <summary>
        /// IEquatable用
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() =>
            R.GetHashCode() ^ G.GetHashCode() ^ B.GetHashCode() ^ A.GetHashCode();

        /// <summary>
        /// IEquatable用
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool IEquatable<ぉ>.Equals(ぉ other) =>
                (R == other.R &&
                G == other.G &&
                B == other.B &&
                A == other.A);

        /// <summary>
        /// #RRGGBB形式の文字列にする
        /// </summary>
        /// <returns></returns>
        public string ToXRGB8() => $"#{R:X2}{G:X2}{B:X2}";

        /// <summary>
        /// #RRRRGGGGBBBBの文字列にする
        /// </summary>
        /// <returns></returns>
        public string ToXRGB16() => $"#{R:X2}{R:X2}{G:X2}{G:X2}{B:X2}{B:X2}";

        /// <summary>
        /// RGBAにﾊﾟｯｷﾝｸﾞして返す
        /// </summary>
        /// <returns></returns>
        public int ToARGBi386() => ((A & 0xff) << 24) | ((R & 0xff) << 16) | ((G & 0xff) << 8) | (B & 0xff);

        /// <summary>
        /// [ch0|ch1|ch2|ch3]でi386形式にﾊﾟｯｷﾝｸﾞして返す
        /// </summary>
        /// <param name="ch0"></param>
        /// <param name="ch1"></param>
        /// <param name="ch2"></param>
        /// <param name="ch3"></param>
        /// <returns></returns>
        public int PackI386(ぉ.画素 ch0, ぉ.画素 ch1, ぉ.画素 ch2, ぉ.画素 ch3) => 
            ((ほ(ch0) & 0xff) << 24) | ((ほ(ch1) & 0xff) << 16) | ((ほ(ch2) & 0xff) << 8) | (ほ(ch3) & 0xff);
    }
}
