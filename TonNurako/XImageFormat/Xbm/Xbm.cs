using System;
using TonNurako.XImageFormat.Xi;

namespace TonNurako.XImageFormat {

    /// <summary>
    /// XBM
    /// </summary>
    public class Xbm : 原色画像 {

        /// <summary>
        /// ｺﾝｽ
        /// </summary>
        public Xbm() {
            ColorResolver = new Fallback原色();
        }

        /// <summary>
        /// ﾄﾗｸﾀー
        /// </summary>
        /// <param name="cr">原色</param>
        public Xbm(I原色 cr) {
            ColorResolver = cr;
        }

        /// <summary>
        ///　名前
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// 幅
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 高さ
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 原色
        /// </summary>
        public I原色 ColorResolver { get; }

        /// <summary>
        /// ﾊﾟﾃﾞｨﾝｸﾞ
        /// </summary>
        internal int Padding {
            get; set;
        }

        /// <summary>
        /// ﾋﾟｸｾﾙﾃﾞﾀー
        /// </summary>
        public byte[] RawPixels => raw;

        /// <summary>
        /// XBMの生ﾃﾞﾀー
        /// </summary>
        private byte[] raw = null;

        /// <summary>
        /// 内部ﾊﾞｯﾌｧーの確保
        /// </summary>
        public void AllocPixels() {
            Padding = ((Width % 8) == 0) ? 0 : 1;
            raw = new byte[((Width / 8) + Padding) * Height];
        }

        /// <summary>
        /// 決着用ﾏｽｸ
        /// </summary>
        readonly byte[] masken = new byte[] {
            0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80
        };

        /// <summary>
        /// ﾏｽｸを掛けて白黒決着する
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="b"></param>
        /// <returns>白黒</returns>
        private ぉ ぁゃιぃ(byte mask, byte b) =>
            ((b & mask) == 0) ? ColorResolver.White : ColorResolver.Black;

        /// <summary>
        /// ぉに変換する
        /// </summary>
        /// <returns>（ぉ</returns>
        public ぉ[] Toぉ() {
            int bo = 0;
            int po = 0;
            var xpad = Width % 8;
            var o = new ぉ[Width * Height];
            for (int y = 0; y < Height; ++y) {
                for (int x = 0; x < Width; x += 8) {
                    var b = raw[bo];
                    int bits = 8;
                    if ((Width - x < 8) && Padding == 1) {
                        bits = xpad;
                    }
                    for (int i = 0; i < bits; ++i) {
                        o[po++] = ぁゃιぃ(masken[i], b);
                    }
                    bo++;
                }
            }
            return o;
        }
    }
}
