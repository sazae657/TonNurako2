using System;
using System.Collections.Generic;
using System.Text;
using TonNurako.XImageFormat.Xi;

namespace TonNurako.XImageFormat {

    /// <summary>
    /// PNM書き込むだ－
    /// </summary>
    public class PNMWriter {

        /// <summary>
        /// 形式(P7はﾊﾞｲﾅﾘーのみ)
        /// </summary>
        public enum ｴﾝｺーﾃﾞｨﾝｸﾞ {
            平文,
            ﾊﾞｲﾅﾘー
        }

        /// <summary>
        /// ﾌｫーﾏｯﾂ
        /// </summary>
        public enum ﾌｫーﾏｯﾂ {
            PBM,
            PGM,
            PPM,
            PAM
        }

        /// <summary>
        /// ｺﾝｽﾄ
        /// </summary>
        public PNMWriter() {
        }

        #region 一括

        /// <summary>
        /// 形式指定で書き出す
        /// </summary>
        /// <param name="stream">ｽﾄﾘーﾑー</param>
        /// <param name="format">形式</param>
        /// <param name="enc">ｴﾝｺーﾃﾞｨﾝｸﾞ(PAMでは無視)</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="channel">ﾁｬﾈﾙ</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞﾀー</param>
        public void Write(
            System.IO.Stream stream, ﾌｫーﾏｯﾂ format, ｴﾝｺーﾃﾞｨﾝｸﾞ enc, int width, int height, ぉ.画素 channel, IEnumerable<ぉ> arr) {
            switch (format) {
                case ﾌｫーﾏｯﾂ.PBM:
                    WritePBM(stream, enc, width, height, channel, arr);
                    break;

                case ﾌｫーﾏｯﾂ.PGM:
                    WritePGM(stream, enc, width, height, channel, arr);
                    break;

                case ﾌｫーﾏｯﾂ.PPM:
                    WritePPM(stream, enc, width, height, arr);
                    break;
                case ﾌｫーﾏｯﾂ.PAM:
                    WritePAM(stream, PNM.ﾇﾌﾟーﾘ.RGB_ALPHA, width, height, channel, arr);
                    break;
                default:
                    throw new Xi.それ対応してない(format.ToString());
            }
        }

        /// <summary>
        /// 形式指定で書き出す
        /// </summary>
        /// <param name="stream">ｽﾄﾘーﾑ</param>
        /// <param name="形式">形式</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="channel">書き出すﾁｬﾈﾙ(ﾓﾉｸﾛ形式のみ)</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞﾀー</param>
        public void Write(
            System.IO.Stream stream, PNM.形式 形式, int width, int height, ぉ.画素 channel, IEnumerable<ぉ> arr) 
        {
            switch (形式) {
                case PNM.形式.P1:
                    WritePBM(stream, ｴﾝｺーﾃﾞｨﾝｸﾞ.平文, width, height, channel, arr);
                    break;
                case PNM.形式.P4:
                    WritePBM(stream, ｴﾝｺーﾃﾞｨﾝｸﾞ.ﾊﾞｲﾅﾘー, width, height, channel, arr);
                    break;

                case PNM.形式.P2:
                    WritePGM(stream, ｴﾝｺーﾃﾞｨﾝｸﾞ.平文, width, height, channel, arr);
                    break;
                case PNM.形式.P5:
                    WritePGM(stream, ｴﾝｺーﾃﾞｨﾝｸﾞ.ﾊﾞｲﾅﾘー, width, height, channel, arr);
                    break;

                case PNM.形式.P3:
                    WritePPM(stream, ｴﾝｺーﾃﾞｨﾝｸﾞ.平文, width, height, arr);
                    break;
                case PNM.形式.P6:
                    WritePPM(stream, ｴﾝｺーﾃﾞｨﾝｸﾞ.ﾊﾞｲﾅﾘー, width, height, arr);
                    break;
                case PNM.形式.P7:
                    WritePAM(stream, PNM.ﾇﾌﾟーﾘ.RGB_ALPHA, width, height, channel, arr);
                    break;
                default:
                    throw new Xi.それ対応してない(形式.ToString());
            }
        }



        #endregion

        #region PBM

        /// <summary>
        /// PBM用ﾏｽｸ
        /// </summary>
        readonly byte[] masken = new byte[] {
            0x80,0x40,0x20,0x10,0x08,0x04,0x02,0x01
        };

        /// <summary>
        /// PBMを書き込む
        /// </summary>
        /// <param name="stream">ｽﾄﾘーﾑー</param>
        /// <param name="format">形式</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="channel">書き込むﾁｬﾈﾙ</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞﾀー</param>
        public void WritePBM(
            System.IO.Stream stream, ｴﾝｺーﾃﾞｨﾝｸﾞ format, int width, int height, ぉ.画素 channel, IEnumerable<ぉ> arr) {
            var war = new byte[width * height];
            int sr = 0;
            foreach (var x in arr) {
                war[sr++] = (byte)x.ほ(channel);
            }
            WritePBM(stream, format, width, height, war);
        }

        /// <summary>
        /// PBMを書き込む
        /// </summary>
        /// <param name="stream">ｽﾄﾘーﾑー</param>
        /// <param name="format">形式</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞﾀー(10形式)</param>
        public void WritePBM(
            System.IO.Stream stream, ｴﾝｺーﾃﾞｨﾝｸﾞ format, int width, int height, byte[] arr) {
            if (format == ｴﾝｺーﾃﾞｨﾝｸﾞ.ﾊﾞｲﾅﾘー) {
                WritePBMﾊﾞｲﾅﾘー(stream, width, height, arr);
                return;
            }

            int po = 0;
            var xpad = width % 8;
            StringBuilder sb = new StringBuilder();
            sb.Append($"P1\r\n")
              .Append($"{width} {height}\r\n");

            for (int y = 0; y < height; ++y) {
                for (int x = 0; x < width; x += 8) {
                    int bits = 8;
                    if ((width - x < 8)) {
                        bits = xpad;
                    }
                    for (int i = 0; i < bits; ++i) {
                        var w = arr[po++] == 0 ? 1 : 0;
                        sb.Append($"{w}");
                    }
                }
                sb.Append("\r\n");
            }
            sb.Append("\r\n");
            var mp3 = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            stream.Write(mp3, 0, mp3.Length);
        }

        /// <summary>
        /// ﾊﾞｲﾅﾘー形式PBM書き込み
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="arr"></param>
        void WritePBMﾊﾞｲﾅﾘー(
            System.IO.Stream stream, int width, int height, byte[] arr) {
            StringBuilder sb = new StringBuilder();
            sb.Append($"P4\n")
              .Append($"{width} {height}\n");


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

            var mp3 = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            stream.Write(mp3, 0, mp3.Length);
            stream.Write(buf, 0, buf.Length);
        }
        #endregion


        #region PGM
        /// <summary>
        /// PGM書き込み
        /// </summary>
        /// <param name="stream">ｽﾄﾘーﾑー</param>
        /// <param name="format">形式</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="channel">書き込むﾁｬﾈﾙ</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞﾀー</param>
        public void WritePGM(
            System.IO.Stream stream, ｴﾝｺーﾃﾞｨﾝｸﾞ format, int width, int height, ぉ.画素 channel, IEnumerable<ぉ> arr) {
            var war = new byte[width * height];
            int sr = 0;
            foreach (var x in arr) {
                war[sr++] = (byte)x.ほ(channel);
            }
            WritePGM(stream, format, width, height, war);
        }

        /// <summary>
        /// PGMを書き込む
        /// </summary>
        /// <param name="stream">ｽﾄﾘーﾑー</param>
        /// <param name="format">形式</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞﾀー(0~255が詰まってる物)</param>
        public void WritePGM(
            System.IO.Stream stream, ｴﾝｺーﾃﾞｨﾝｸﾞ format, int width, int height, byte[] arr) {
            int maxx = 0;
            foreach (var k in arr) {
                maxx = Math.Max(maxx, k);
            }

            if (format == ｴﾝｺーﾃﾞｨﾝｸﾞ.ﾊﾞｲﾅﾘー) {
                WritePGMﾊﾞｲﾅﾘー(stream, width, height, maxx, arr);
                return;
            }

            int po = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append($"P2\r\n")
              .Append($"{width} {height}\r\n")
              .Append($"{maxx}\r\n");

            for (int y = 0; y < height; ++y) {
                for (int x = 0; x < width; x++) {
                    sb.Append($"{arr[po++]} ");
                }
                sb.Append("\r\n");
            }
            sb.Append("\r\n");
            var mp3 = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            stream.Write(mp3, 0, mp3.Length);
        }

        /// <summary>
        /// PGMを書き込む(ﾊﾞｲﾅﾘー)
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="maxx"></param>
        /// <param name="arr"></param>
        void WritePGMﾊﾞｲﾅﾘー(
            System.IO.Stream stream, int width, int height, int maxx, byte[] arr) {
            StringBuilder sb = new StringBuilder();
            sb.Append($"P5\n")
              .Append($"{width} {height}\n")
              .Append($"{maxx}\n");

            var mp3 = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            stream.Write(mp3, 0, mp3.Length);
            stream.Write(arr, 0, arr.Length);
        }

        #endregion


        #region PPM

        /// <summary>
        /// PPMを書き込む
        /// </summary>
        /// <param name="stream">ｽﾄﾘーﾑー</param>
        /// <param name="format">形式</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞﾀー</param>
        public void WritePPM(
            System.IO.Stream stream, ｴﾝｺーﾃﾞｨﾝｸﾞ format, int width, int height, IEnumerable<ぉ> arr) {
            int maxx = 0;
            foreach (var k in arr) {
                maxx = Math.Max(maxx, k.R);
                maxx = Math.Max(maxx, k.G);
                maxx = Math.Max(maxx, k.B);
            }

            if (format == ｴﾝｺーﾃﾞｨﾝｸﾞ.ﾊﾞｲﾅﾘー) {
                WritePPMﾊﾞｲﾅﾘー(stream, width, height, maxx, arr);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"P3\r\n")
              .Append($"{width} {height}\r\n")
              .Append($"{maxx}\r\n");

            int f = 0;
            foreach (var p in arr) {
                sb.Append($"{p.R} {p.G} {p.B}");
                if ((++f % 16) == 0) {
                    sb.Append("\r\n");
                }
                else {
                    sb.Append(" ");
                }
            }
            sb.Append("\r\n");
            var mp3 = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            stream.Write(mp3, 0, mp3.Length);
        }

        /// <summary>
        /// PPM(ﾊﾞｲﾅﾘー)を書き込む
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="maxx"></param>
        /// <param name="arr"></param>
        void WritePPMﾊﾞｲﾅﾘー(
            System.IO.Stream stream, int width, int height, int maxx, IEnumerable<ぉ> arr) {
            StringBuilder sb = new StringBuilder();
            sb.Append($"P6\n")
              .Append($"{width} {height}\n")
              .Append($"{maxx}\n");

            var hqx = new byte[width * height * 3];
            int f = 0;
            foreach (var p in arr) {
                hqx[f++] = (byte)p.R;
                hqx[f++] = (byte)p.G;
                hqx[f++] = (byte)p.B;
            }

            var mp3 = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            stream.Write(mp3, 0, mp3.Length);
            stream.Write(hqx, 0, hqx.Length);
        }

        #endregion


        #region PAM
    
        /// <summary>
        /// PAMを書き込む
        /// </summary>
        /// <param name="stream">ｽﾄﾘーﾑ</param>
        /// <param name="ttyp">ﾋﾟｸｾﾙ形式</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞﾀー</param>
        public void WritePAM(
            System.IO.Stream stream, PNM.ﾇﾌﾟーﾘ ttyp, int width, int height, IEnumerable<ぉ> arr) {
            WritePAM(stream, ttyp, width, height, ぉ.画素.R, arr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream">ｽﾄﾘーﾑ</param>
        /// <param name="ttyp">ﾋﾟｸｾﾙ形式</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="channel">ttypが白黒の時に使用する画素</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞﾀー</param>
        public void WritePAM(
            System.IO.Stream stream, PNM.ﾇﾌﾟーﾘ ttyp, int width, int height, ぉ.画素 channel, IEnumerable<ぉ> arr) {
            int maxx = 0;
            if ((ttyp != PNM.ﾇﾌﾟーﾘ.BLACKANDWHITE) &&
                (ttyp != PNM.ﾇﾌﾟーﾘ.BLACKANDWHITE_ALPHA)) {
                foreach (var k in arr) {
                    maxx = Math.Max(maxx, k.R);
                    maxx = Math.Max(maxx, k.G);
                    maxx = Math.Max(maxx, k.B);
                }
            }
            else {
                maxx = 1;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"P7\n")
              .Append($"WIDTH {width}\n")
              .Append($"HEIGHT {height}\n")
              .Append($"DEPTH {ttyp.ﾃﾞﾌﾞｽ()}\n")
              .Append($"TUPLTYPE {ttyp.ﾀﾌﾟﾀﾌﾟ()}\n")
              .Append($"MAXVAL {maxx}\n")
              .Append($"ENDHDR\n");

            byte[] hqx = null;

            switch (ttyp) {
                case PNM.ﾇﾌﾟーﾘ.RGB:
                    hqx = GeneratePAM_RGB(width, height, false, ref arr);
                    break;
                case PNM.ﾇﾌﾟーﾘ.RGB_ALPHA:
                    hqx = GeneratePAM_RGB(width, height, true, ref arr);
                    break;

                case PNM.ﾇﾌﾟーﾘ.BLACKANDWHITE:
                    hqx = GeneratePAM_BW(width, height, channel, false, ref arr);
                    break;

                case PNM.ﾇﾌﾟーﾘ.BLACKANDWHITE_ALPHA:
                    hqx = GeneratePAM_BW(width, height, channel, true, ref arr);
                    break;

                case PNM.ﾇﾌﾟーﾘ.GRAYSCALE:
                    hqx = GeneratePAM_G(width, height, channel, false, ref arr);
                    break;

                case PNM.ﾇﾌﾟーﾘ.GRAYSCALE_ALPHA:
                    hqx = GeneratePAM_G(width, height, channel, true, ref arr);
                    break;

                default:
                    throw new Xi.およよ($"しらん {ttyp}");
            }

            var mp3 = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            stream.Write(mp3, 0, mp3.Length);
            stream.Write(hqx, 0, hqx.Length);
        }

        /// <summary>
        /// RGB(A)を生成する
        /// </summary>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="alpha">ｱﾙﾌｧーﾁｬﾈﾙあり</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞーﾀ</param>
        /// <returns></returns>
        byte[] GeneratePAM_RGB(int width, int height, bool alpha, ref IEnumerable<ぉ> arr) {
            var hqx = new byte[width * height * (alpha? 4 : 3)];
            int f = 0;
            foreach (var p in arr) {
                hqx[f++] = (byte)p.R;
                hqx[f++] = (byte)p.G;
                hqx[f++] = (byte)p.B;
                if (alpha) {
                    hqx[f++] = (byte)p.A;
                }
            }
            return hqx;
        }

        /// <summary>
        /// BW(A)を生成する
        /// </summary>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="channel">使用する画素</param>
        /// <param name="alpha">ｱﾙﾌｧーﾁｬﾈﾙあり</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞーﾀ</param>
        /// <returns></returns>
        byte[] GeneratePAM_BW(int width, int height, ぉ.画素 channel, bool alpha, ref IEnumerable<ぉ> arr) {
            int zise = alpha ? (width * 2) * height : width * height;
            var hqx = new byte[zise];
            int f = 0;
            foreach (var p in arr) {
                if (alpha) {
                    hqx[f++] = (byte)((p.ほ(channel) != 0) ? 0x01 : 0x00);
                    hqx[f++] = (byte)p.A;
                }
                else {
                    hqx[f++] = (byte)((p.ほ(channel) != 0) ? 0x01 : 0x00);
                }
            }
            return hqx;
        }

        /// <summary>
        /// G(A)を生成する
        /// </summary>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="channel">使用する画素</param>
        /// <param name="alpha">ｱﾙﾌｧーﾁｬﾈﾙあり</param>
        /// <param name="arr">ﾋﾟｸｾﾙﾃﾞーﾀ</param>
        byte[] GeneratePAM_G(int width, int height, ぉ.画素 channel, bool alpha, ref IEnumerable<ぉ> arr) {
            var hqx = new byte[width * height * (alpha ? 2 : 1)];
            int f = 0;
            foreach (var p in arr) {
                hqx[f++] = (byte)p.ほ(channel);
                if (alpha) {
                    hqx[f++] = (byte)p.A;
                }
            }
            return hqx;
        }
        #endregion
    }
}
