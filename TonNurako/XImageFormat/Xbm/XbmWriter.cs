using System.Collections.Generic;
using System.Text;
using TonNurako.XImageFormat.Xi;

namespace TonNurako.XImageFormat {

    /// <summary>
    /// XBM書き込むﾀﾞー
    /// </summary>
    public class XbmWriter {
        /// <summary>
        /// ﾏｽｸ
        /// </summary>
        static readonly byte[] masken = new byte[] {
            0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80
        };

        /// <summary>
        /// 書き込む
        /// </summary>
        /// <param name="stream">ｽﾄﾚーﾑ</param>
        /// <param name="prefix">構造体の接頭子</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="channel">書き込むﾁｬﾈﾙ</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞﾀー</param>
        public void Write(
            System.IO.Stream stream, string prefix, int width, int height, ぉ.画素 channel, IEnumerable<ぉ> arr) 
        {
            var war = new byte[width * height];
            int sr = 0;
            foreach (var x in arr) {
                war[sr++] = (byte)x.ほ(channel);
            }
            Write(stream, prefix, width, height, war);
        }

        /// <summary>
        /// 書き込む
        /// </summary>
        /// <param name="stream">ｽﾄﾚーﾑ</param>
        /// <param name="prefix">構造体の接頭子</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞﾀー(01形式)</param>
        public void Write(
            System.IO.Stream stream, string prefix, int width, int height, byte[] arr) {
            StringBuilder sb = new StringBuilder();
            sb.Append($"#define {prefix}_width {width}\n")
              .Append($"#define {prefix}_height {height}\n");


            int bo = 0;
            int po = 0;
            var xpad = width % 8;
            var bufw = ((width / 8) + (xpad != 0 ? 1 : 0)) * height;
            var buf = new byte[bufw];
            for (int y = 0; y < height; ++y) {
                for (int x = 0; x < width; x += 8) {
                    byte b = 0;
                    int bits = 8;
                    if ((width - x < 8)) {
                        bits = xpad;
                    }
                    for (int i = 0; i < bits; ++i) {
                        var a = arr[po++];
                        if (a != 0) {
                            continue;
                        }
                        b |= masken[i];
                    }
                    buf[bo++] = b;
                }
            }

            sb.Append($"static unsigned char {prefix}_bits[] = {{\n");
            bool boo = false;
            for (int i = 0; i < buf.Length; i += 16) {
                for (int j = 0; j < 16; j++) {
                    int f = i + j;
                    sb.Append($" 0x{buf[f]:X2}");
                    if (f >= (buf.Length - 1)) {
                        boo = true;
                        break;
                    }
                    sb.Append(",");
                }
                if (!boo) {
                    sb.Append("\n");
                }
            }
            sb.Append("};\n");
            var mp3 = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            stream.Write(mp3, 0, mp3.Length);
        }


        /// <summary>
        /// ぉをﾍﾞｯﾄﾑｯﾌﾟに変換する
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="channel"></param>
        /// <param name="反転"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static byte[] ToBitmap(int width, int height, ぉ.画素 channel, bool 反転, ぉ[] arr) {
            int bo = 0;
            int po = 0;
            var xpad = width % 8;
            var bufw = ((width / 8) + (xpad != 0 ? 1 : 0)) * height;
            var buf = new byte[bufw];
            for (int y = 0; y < height; ++y) {
                for (int x = 0; x < width; x += 8) {
                    byte b = 0;
                    int bits = 8;
                    if ((width - x < 8)) {
                        bits = xpad;
                    }
                    for (int i = 0; i < bits; ++i) {
                        var a = arr[po++].ほ(channel);
                        bool k = (a == 0);
                        if (反転) {
                            k = !k;
                        }
                        if (k) {
                            continue;
                        }
                        b |= masken[i];
                    }
                    buf[bo++] = b;
                }
            }
            return buf;
        }
    }
}
