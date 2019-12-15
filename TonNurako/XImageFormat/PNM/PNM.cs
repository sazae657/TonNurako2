using System;
using System.Reflection;
using TonNurako.XImageFormat.Xi;

namespace TonNurako.XImageFormat {


    /// <summary>
    /// PNMの属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class ﾇﾌﾟーﾘAttribute : Attribute {
        public String TUPLTYPE;
        public int DEPTH;
        public ﾇﾌﾟーﾘAttribute(String tt, int depth) {
            this.TUPLTYPE = tt;
            this.DEPTH = depth;
        }
    }

    /// <summary>
    /// 属性へるぱー
    /// </summary>
    public static class ﾇﾌﾟーﾘEnumExtensions {
        public static string ﾀﾌﾟﾀﾌﾟ(this PNM.ﾇﾌﾟーﾘ target) {
            var attribute = target.GetType().GetMember(target.ToString())[0].GetCustomAttribute(typeof(ﾇﾌﾟーﾘAttribute));

            return attribute == null ? null : ((ﾇﾌﾟーﾘAttribute)attribute).TUPLTYPE;
        }
        public static int ﾃﾞﾌﾞｽ(this PNM.ﾇﾌﾟーﾘ target) {
            var attribute = target.GetType().GetMember(target.ToString())[0].GetCustomAttribute(typeof(ﾇﾌﾟーﾘAttribute));
            return ((ﾇﾌﾟーﾘAttribute)attribute).DEPTH;
        }
    }

    /// <summary>
    /// PNM
    /// </summary>
    public class PNM : 原色画像 {

        /// <summary>
        /// PNMの形式
        /// </summary>
        public enum 形式 {
            P1, // PBM(A)
            P2, // PGM(A)
            P3, // PPM(A)
            P4, // PBM(R)
            P5, // PGM(R)
            P6, // PPM(R)
            P7, // PAM
            PF  // PFM
        }

        /// <summary>
        /// ﾋﾟｸｾﾙの形式
        /// </summary>
        public enum ﾇﾌﾟーﾘ {
            [ﾇﾌﾟーﾘ("BLACKANDWHITE", 1)]
            BLACKANDWHITE,

            [ﾇﾌﾟーﾘ("GRAYSCALE", 1)]
            GRAYSCALE,

            [ﾇﾌﾟーﾘ("RGB", 3)]
            RGB,

            [ﾇﾌﾟーﾘ("BLACKANDWHITE_ALPHA", 2)]
            BLACKANDWHITE_ALPHA,

            [ﾇﾌﾟーﾘ("GRAYSCALE_ALPHA", 2)]
            GRAYSCALE_ALPHA,

            [ﾇﾌﾟーﾘ("RGB_ALPHA", 4)]
            RGB_ALPHA
        }

        /// <summary>
        /// 名前(使わない)
        /// </summary>
        public string Name { get ; set; }

        /// <summary>
        /// 幅
        /// </summary>
        public int Width { get ; set ; }

        /// <summary>
        /// 高さ
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// P1~P3で使用
        /// </summary>
        public int Maxval { get; set; }

        /// <summary>
        /// 深度
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// このPNMの形式
        /// </summary>
        public 形式 Format { get; set; }

        /// <summary>
        /// ﾋﾟｸｾﾙの形式
        /// </summary>
        public ﾇﾌﾟーﾘ TupleType { get; set; }

        /// <summary>
        /// ﾋﾟｸｾﾙﾃﾞーﾀ
        /// </summary>
        public ぉ[] Pixls { get; set; }

        /// <summary>
        /// ぉで返す
        /// </summary>
        /// <returns>ぉ</returns>
        public ぉ[] Toぉ() => Pixls;

        /// <summary>
        /// 内部用
        /// </summary>
        internal int 現在位置 { get; set; }
        
    }
}
