using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.XImageFormat {

    /// <summary>
    /// PNM読み込むﾀﾞー
    /// </summary>
    public class PNMLoader {


        enum STATE {
            None,
            Values,
            Colors,
            Pixels,
            Extensions,
            EOF
        }

        /// <summary>
        /// 原色
        /// </summary>
        public I原色 ColorResolver { get; }

        /// <summary>
        /// ｺﾝ
        /// </summary>
        public PNMLoader() {
            ColorResolver = new Fallback原色();
        }

        /// <summary>
        /// ｽﾄﾗｸﾀー
        /// </summary>
        /// <param name="cr">原色</param>
        public PNMLoader(I原色 cr) {
            ColorResolver = cr;
        }

        /// <summary>
        /// 読み込む
        /// </summary>
        /// <param name="path">ﾌｧｲﾙ名</param>
        /// <returns>PNM</returns>
        public PNM Load(string path) {
            var lines = new List<string>();
            using (var file =
                new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read)) {
                return Load(file);
            }
        }

        /// <summary>
        /// 読み込む
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>PNM</returns>
        public PNM Load(System.IO.Stream stream) {
            var pnm = new PNM();

            var x = ReadLine(stream);

            pnm.Format = 形式を割り出す(Encoding.ASCII.GetBytes(x));

            if (pnm.Format == PNM.形式.P7) {
                ﾚﾍﾞﾙ7ﾍｯﾀﾞーを読み込む(stream, pnm);
            }
            else if (pnm.Format == PNM.形式.PF) {
                throw new Xi.それ対応してない($"むり {pnm.Format}");
            }
            else {
                pnm.Width = int.Parse(ReadNine(stream));
                pnm.Height = int.Parse(ReadNine(stream));
                if (pnm.Format != PNM.形式.P1 && pnm.Format != PNM.形式.P4) {
                    pnm.Maxval = int.Parse(ReadNine(stream));
                }
            }
            using (var ms = new System.IO.MemoryStream()) {
                var rb = new byte[1024];
                int siz = 0;
                while ((siz = stream.Read(rb, 0, rb.Length - 1)) > 0) {
                    ms.Write(rb, 0, siz);
                }

                if (pnm.Format == PNM.形式.P1 ||
                    pnm.Format == PNM.形式.P2 ||
                    pnm.Format == PNM.形式.P3) {
                    pnm.Pixls = 平文ﾋﾟｸｾﾙ読み込み(ms.GetBuffer(), pnm);
                }
                else if (pnm.Format == PNM.形式.P4 ||
                    pnm.Format == PNM.形式.P5 ||
                    pnm.Format == PNM.形式.P6) {
                    pnm.Pixls = ﾊﾞｲﾅﾘーﾋﾟｸｾﾙ読み込み(ms.GetBuffer(), pnm);
                }
                else if (pnm.Format == PNM.形式.P7) {
                    pnm.Pixls = ﾚﾍﾞﾙ7のﾋﾟｸｾﾙﾃﾞﾀーを読み込む(ms.GetBuffer(), pnm);
                }
                else {
                    throw new Xi.それ対応してない($"むり {pnm.Format}");
                }
            }

            return pnm;
        }

        #region ﾋﾟｸｾﾘ
        /// <summary>
        /// ﾊﾞｲﾅﾘー形式のﾋﾟｸｾﾙﾃﾞーﾀを読み込む(P7除く)
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="pnm"></param>
        /// <returns></returns>
        private Xi.ぉ[] ﾊﾞｲﾅﾘーﾋﾟｸｾﾙ読み込み(byte[] buf, PNM pnm) {
            switch (pnm.Format) {
                case PNM.形式.P4:
                    return ﾚﾍﾞﾙ4を読み込む(ref buf, pnm);
                case PNM.形式.P5:
                    return ﾚﾍﾞﾙ5を読み込む(ref buf, pnm);
                case PNM.形式.P6:
                    return ﾚﾍﾞﾙ6を読み込む(ref buf, pnm);
                default:
                    throw new Xi.およよ($"しらん {pnm.Format}");
            }
        }

        /// <summary>
        /// 平文ﾋﾟｸｾﾙを読み込む
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="pnm"></param>
        /// <returns></returns>
        private Xi.ぉ[] 平文ﾋﾟｸｾﾙ読み込み(byte[] buf, PNM pnm) {
            pnm.現在位置 = 0;
            int cp = 0;
            var r = new Xi.ぉ[pnm.Width * pnm.Height];
            var kr = new Xi.ぉ(0, 0, 0);
            for (int i = 0; i < r.Count(); ++i) {
                var q = pnm.Format == PNM.形式.P1 ? ReadEPixel(ref buf, pnm) : ReadTPixel(ref buf, pnm);
                if (null == q) {
                    break;
                }
                r[i] = new Xi.ぉ(0, 0, 0, 0xFF);
                switch (pnm.Format) {
                    case PNM.形式.P1:
                        var v = (q.Value == 0) ? 0xff : 0x00;
                        r[i].ぃ(v, v, v);
                        break;
                    case PNM.形式.P2:
                        r[i].ぃ(q.Value, q.Value, q.Value);
                        break;
                    case PNM.形式.P3:
                        r[i].R = q.Value;
                        r[i].G = ReadTPixel(ref buf, pnm).Value;
                        r[i].B = ReadTPixel(ref buf, pnm).Value;
                        break;
                }
                if (cp++ >= r.Length) {
                    break;
                }

            }
            return r;
        }
        #endregion

        #region P4
        /// <summary>
        /// P4ﾋﾞｯﾄﾏｽｸ
        /// </summary>
        readonly byte[] masken = new byte[] {
            0x80,0x40,0x20,0x10,0x08,0x04,0x02,0x01
        };
        
        /// <summary>
        /// 黒
        /// </summary>
        readonly Xi.ぉ 黒 = new Xi.ぉ(0, 0, 0);

        /// <summary>
        /// 白
        /// </summary>
        readonly Xi.ぉ 白 = new Xi.ぉ(0xff, 0xff, 0xff);

        /// <summary>
        /// ﾏｽｸを掛けて白黒決着を付ける
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="b"></param>
        /// <returns>白黒</returns>
        private Xi.ぉ ぁゃιぃ(byte mask, byte b) => ((b & mask) == 0) ? 白 : 黒;
        
        /// <summary>
        /// P4ﾋﾞｯﾄﾏｯﾌﾟを原色に変換する
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="pnm"></param>
        /// <returns></returns>
        private Xi.ぉ[] ﾚﾍﾞﾙ4を読み込む(ref byte[] buf, PNM pnm) {
            pnm.現在位置 = 0;
            var r = new Xi.ぉ[pnm.Width * pnm.Height];
            int po = 0;
            int bo = 0;
            var xpad = pnm.Width % 8;
            for (int y = 0; y < pnm.Height; ++y) {
                for (int x = 0; x < pnm.Width; x += 8) {
                    var b = buf[bo];
                    int bits = 8;
                    if ((pnm.Width - x < 8) && xpad != 0) {
                        bits = xpad;
                    }
                    for (int i = 0; i < bits; ++i) {
                        r[po++] = ぁゃιぃ(masken[i], b);
                    }
                    bo++;
                }
            }
            return r;
        }
        #endregion

        #region P5

        /// <summary>
        /// P5ﾋﾞｯﾄﾏｯﾌﾟを原色に変換する
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="pnm"></param>
        /// <returns></returns>
        private Xi.ぉ[] ﾚﾍﾞﾙ5を読み込む(ref byte[] buf, PNM pnm) {
            pnm.現在位置 = 0;
            var r = new Xi.ぉ[pnm.Width * pnm.Height];
            int po = 0;
            int bo = 0;
            int ps = pnm.Maxval > 255 ? 2 : 1;
            for (int y = 0; y < pnm.Height; ++y) {
                for (int x = 0; x < pnm.Width; ++x) {
                    if (ps == 1) {
                        var b = buf[bo];
                        r[po++] = new Xi.ぉ(b, b, b);
                    }
                    else {
                        var b = buf[bo] | buf[bo + 1] << 8;
                        r[po++] = new Xi.ぉ(b, b, b);
                    }
                    bo += ps;
                }
            }
            return r;
        }
        #endregion

        #region P6

        /// <summary>
        /// P6ﾋﾞｯﾄﾏｯﾌﾟを原色に変換する
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="pnm"></param>
        /// <returns></returns>
        private Xi.ぉ[] ﾚﾍﾞﾙ6を読み込む(ref byte[] buf, PNM pnm) {
            pnm.現在位置 = 0;
            var r = new Xi.ぉ[pnm.Width * pnm.Height];
            int po = 0;
            int bo = 0;
            int ps = pnm.Maxval > 255 ? 2 : 1;
            for (int y = 0; y < pnm.Height; ++y) {
                for (int x = 0; x < pnm.Width; ++x) {
                    if (ps == 1) {
                        r[po++] = new Xi.ぉ(buf[bo++], buf[bo++], buf[bo++]);
                    }
                    else {
                        var s = buf[bo++] | buf[bo++] << 8;
                        var h = buf[bo++] | buf[bo++] << 8;
                        var c = buf[bo++] | buf[bo++] << 8;
                        r[po++] = new Xi.ぉ(s, h, c);
                    }
                }
            }
            return r;
        }
        #endregion

        #region P7
        /// <summary>
        /// P7ﾌｫーﾏｯﾄのﾍｯﾀﾞーを解析する
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="pnm"></param>
        private void ﾚﾍﾞﾙ7ﾍｯﾀﾞーを読み込む(System.IO.Stream stream, PNM pnm) {
            while (true) {
                var line = ReadLine(stream).Trim();
                if (line.Length == 0) {
                    continue;
                }
                var tok = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (tok[0].Equals("ENDHDR", StringComparison.CurrentCultureIgnoreCase)) {
                    break;
                }
                switch (tok[0].ToUpper()) {
                    case "WIDTH":
                        pnm.Width = int.Parse(tok[1]);
                        break;
                    case "HEIGHT":
                        pnm.Height = int.Parse(tok[1]);
                        break;
                    case "DEPTH":
                        pnm.Depth = int.Parse(tok[1]);
                        break;
                    case "MAXVAL":
                        pnm.Maxval = int.Parse(tok[1]);
                        break;
                    case "TUPLTYPE":
                        pnm.TupleType = ﾇﾌﾟーﾘに変換(tok[1]);
                        break;
                    default:
                        throw new Xi.およよ($"しらん {tok[0]}");
                }
            }
        }

        /// <summary>
        /// TUPLTYPEをﾇﾌﾟーﾘに変換
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        private PNM.ﾇﾌﾟーﾘ ﾇﾌﾟーﾘに変換(string T) {
            switch (T.ToUpper()) {
                case "BLACKANDWHITE":
                    return PNM.ﾇﾌﾟーﾘ.BLACKANDWHITE;
                case "GRAYSCALE":
                    return PNM.ﾇﾌﾟーﾘ.GRAYSCALE;
                case "RGB":
                    return PNM.ﾇﾌﾟーﾘ.RGB;
                case "BLACKANDWHITE_ALPHA":
                    return PNM.ﾇﾌﾟーﾘ.BLACKANDWHITE_ALPHA;
                case "GRAYSCALE_ALPHA":
                    return PNM.ﾇﾌﾟーﾘ.GRAYSCALE_ALPHA;
                case "RGB_ALPHA":
                    return PNM.ﾇﾌﾟーﾘ.RGB_ALPHA;
                default:
                    throw new Xi.およよ($"しらん {T}");
            }
        }

        /// <summary>
        /// P7ﾌｫーﾏｯﾄのﾋﾟｸｾﾙﾃﾞーﾀを読み込む
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="pnm"></param>
        /// <returns></returns>
        private Xi.ぉ[] ﾚﾍﾞﾙ7のﾋﾟｸｾﾙﾃﾞﾀーを読み込む(byte[] buf, PNM pnm) {
            switch (pnm.TupleType) {
                case PNM.ﾇﾌﾟーﾘ.BLACKANDWHITE:
                    return ﾚﾍﾞﾙ7白黒を読み込む(ref buf, pnm);
                case PNM.ﾇﾌﾟーﾘ.GRAYSCALE:
                    return ﾚﾍﾞﾙ7灰を読み込む(ref buf, pnm);
                case PNM.ﾇﾌﾟーﾘ.RGB:
                    return ﾚﾍﾞﾙ6を読み込む(ref buf, pnm);
                case PNM.ﾇﾌﾟーﾘ.RGB_ALPHA:
                    return ﾚﾍﾞﾙ7赤緑青透を読み込む(ref buf, pnm);
                case PNM.ﾇﾌﾟーﾘ.BLACKANDWHITE_ALPHA:
                    return ﾚﾍﾞﾙ7白黒透を読み込む(ref buf, pnm);
                case PNM.ﾇﾌﾟーﾘ.GRAYSCALE_ALPHA:
                    return ﾚﾍﾞﾙ7灰透を読み込む(ref buf, pnm);
                default:
                    break;
            }
            throw new Xi.およよ($"しらん {pnm.TupleType}");
        }

        /// <summary>
        /// P7(RGBA)
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="pnm"></param>
        /// <returns></returns>
        private Xi.ぉ[] ﾚﾍﾞﾙ7赤緑青透を読み込む(ref byte[] buf, PNM pnm) {
            pnm.現在位置 = 0;
            var r = new Xi.ぉ[pnm.Width * pnm.Height];
            int po = 0;
            int bo = 0;
            int ps = pnm.Maxval > 255 ? 2 : 1;
            for (int y = 0; y < pnm.Height; ++y) {
                for (int x = 0; x < pnm.Width; ++x) {
                    if (ps == 1) {
                        r[po++] = new Xi.ぉ(buf[bo++], buf[bo++], buf[bo++], buf[bo++]);
                    }
                    else {
                        r[po++] = new Xi.ぉ(
                            buf[bo++] | buf[bo++] << 8, 
                            buf[bo++] | buf[bo++] << 8, 
                            buf[bo++] | buf[bo++] << 8, 
                            buf[bo++] | buf[bo++] << 8);
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// P7(ﾍﾞｯﾄﾑｯﾋﾟ)
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="pnm"></param>
        /// <returns></returns>
        private Xi.ぉ[] ﾚﾍﾞﾙ7白黒を読み込む(ref byte[] buf, PNM pnm) {
            pnm.現在位置 = 0;
            var r = new Xi.ぉ[pnm.Width * pnm.Height];
            int po = 0;
            int bo = 0;
            int ps = pnm.Maxval > 255 ? 2 : 1;
            for (int y = 0; y < pnm.Height; ++y) {
                for (int x = 0; x < pnm.Width; ++x) {
                    if (ps == 1) {
                        var b = buf[bo] == 0 ? 0x00 : 0xFF;
                        r[po++] = new Xi.ぉ(b, b, b);
                    }
                    else {
                        var b = (buf[bo] | buf[bo + 1] << 8) == 0 ? 0x00 : 0xFF;
                        r[po++] = new Xi.ぉ(b, b, b);
                    }
                    bo += ps;
                }
            }
            return r;
        }

        /// <summary>
        /// P7(ﾍﾞｯﾄﾑｯﾋﾟ+ｱﾙﾌｧー)
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="pnm"></param>
        /// <returns></returns>
        private Xi.ぉ[] ﾚﾍﾞﾙ7白黒透を読み込む(ref byte[] buf, PNM pnm) {
            pnm.現在位置 = 0;
            var r = new Xi.ぉ[pnm.Width * pnm.Height];
            int po = 0;
            int bo = 0;
            int ps = pnm.Maxval > 255 ? 4 : 2;
            for (int y = 0; y < pnm.Height; ++y) {
                for (int x = 0; x < pnm.Width; ++x) {
                    if (ps == 2) {
                        var c = buf[bo] == 0 ? 0x00 : 0xff;
                        var a = buf[bo+1];
                        r[po++] = new Xi.ぉ(c, c, c, a);
                    }
                    else {
                        var a = (buf[bo] | buf[bo + 1] << 8) == 0 ? 0x00 : 0xff;
                        var c = (buf[bo+2] | buf[bo + 3] << 8);
                        r[po++] = new Xi.ぉ(c, c, c, a);
                    }
                    bo += ps;
                }
            }
            return r;
        }

        /// <summary>
        /// P7(ｸﾞﾚー)
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="pnm"></param>
        /// <returns></returns>
        private Xi.ぉ[] ﾚﾍﾞﾙ7灰を読み込む(ref byte[] buf, PNM pnm) {
            pnm.現在位置 = 0;
            var r = new Xi.ぉ[pnm.Width * pnm.Height];
            int po = 0;
            int bo = 0;
            int ps = pnm.Maxval > 255 ? 2 : 1;
            for (int y = 0; y < pnm.Height; ++y) {
                for (int x = 0; x < pnm.Width; ++x) {
                    if (ps == 1) {
                        var b = buf[bo];
                        r[po++] = new Xi.ぉ(b, b, b);
                    }
                    else {
                        var b = buf[bo] | buf[bo + 1] << 8;
                        r[po++] = new Xi.ぉ(b, b, b);
                    }
                    bo += ps;
                }
            }
            return r;
        }

        /// <summary>
        /// P7(ｸﾞﾚー+ｱﾙﾌｧー)
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="pnm"></p
        private Xi.ぉ[] ﾚﾍﾞﾙ7灰透を読み込む(ref byte[] buf, PNM pnm) {
            pnm.現在位置 = 0;
            var r = new Xi.ぉ[pnm.Width * pnm.Height];
            int po = 0;
            int bo = 0;
            int ps = pnm.Maxval > 255 ? 2 : 1;
            for (int y = 0; y < pnm.Height; ++y) {
                for (int x = 0; x < pnm.Width; ++x) {
                    if (ps == 1) {
                        var b = buf[bo];
                        var a = buf[bo + 1];
                        r[po++] = new Xi.ぉ(b, b, b, a);
                    }
                    else {
                        var b = buf[bo] | buf[bo + 1] << 8;
                        var a = buf[bo+2] | buf[bo + 3] << 8;
                        r[po++] = new Xi.ぉ(b, b, b, a);
                    }
                    bo += ps*2;
                }
            }
            return r;
        }
        #endregion

        #region 共通
        /// <summary>
        /// 先頭ﾊﾞｲﾄからﾌｫーﾏｯﾂを割り出す
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private PNM.形式 形式を割り出す(byte[] d) {
            if (d[0] != 0x50) {
                throw new Xi.およよ("Pじゃない");
            }
            if (d[1] == 0x46) {
                return PNM.形式.PF;
            }
            return (PNM.形式)(d[1] - 0x31);
        }

        bool それ区切り文字(byte a) => (a <= 0x20);

        /// <summary>
        /// 平文ﾋﾟｸｾﾙを読み出す
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="pnm"></param>
        /// <returns></returns>
        private int? ReadTPixel(ref byte[] buf, PNM pnm) {
            bool eof = false;
            bool boo = false;
            var i = pnm.現在位置;
            var len = 0;
            while (それ区切り文字(buf[i])) {
                i++;
            }
            if (i != pnm.現在位置) {
                pnm.現在位置 = i;
            }

            while (true) {
                if (i >= buf.Length) {
                    eof = true;
                    break;
                }
                byte a = buf[i++];
                if (それ区切り文字(a)) {
                    boo = true;
                    continue;
                }
                if (boo) {
                    i--;
                    break;
                }
                len++;
            }
            if (len == 0 && eof) {
                return null;
            }
            var gs = System.Text.Encoding.ASCII.GetString(buf, pnm.現在位置, len);
            var r = int.Parse(gs);
            pnm.現在位置 = i;
            return r;
        }

        /// <summary>
        /// ﾋﾞﾁﾋﾞﾁに詰まった平文ﾋﾟｸｾﾙを読み出す(P1)
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="pnm"></param>
        /// <returns></returns>
        private int? ReadEPixel(ref byte[] buf, PNM pnm) {
            bool eof = false;
            var i = pnm.現在位置;

            while (true) {
                if (i >= buf.Length - 1) {
                    eof = true;
                    break;
                }

                byte a = buf[i];
                if (!それ区切り文字(a)) {
                    break;
                }
                i++;
            }
            if (eof) {
                return null;
            }
            var gs = System.Text.Encoding.ASCII.GetString(buf, i, 1);
            var r = int.Parse(gs);
            pnm.現在位置 = i+1;
            return r;
        }

        /// <summary>
        /// 1行読み取り
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private string ReadLine(System.IO.Stream stream) {
            var sr = new StringBuilder();
            while (true) {
                var a = stream.ReadByte();
                if (a == -1 || a == 0x0A) {
                    break;
                }
                else if (a == 0x0D) {
                    continue;
                }
                sr.Append((char)a);
            }
            return sr.ToString();
        }

        /// <summary>
        /// 9行読み取り
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private string ReadNine(System.IO.Stream stream) {
            var sr = new StringBuilder();
            bool boo = false;
            int rc = 0;
            while (true) {
                var a = stream.ReadByte();
                if (0x23 == a) {
                    boo = true;
                    continue;
                }
                if (boo) {
                    if (a == 0x0A) {
                        boo = false;
                    }
                    continue;
                }

                if (a == -1 || a == 0x0A || a == 0x20 || a == 0x09) {
                    if (a != -1 && rc == 0) {
                        continue;
                    }
                    break;
                }
                else if (a == 0x0D) {
                    continue;
                }
                sr.Append((char)a);
                rc++;
            }
            return sr.ToString();
        }
        #endregion

    }
}
