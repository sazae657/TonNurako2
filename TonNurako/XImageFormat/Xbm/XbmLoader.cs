using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonNurako.XImageFormat.Xi;

namespace TonNurako.XImageFormat {

    /// <summary>
    /// XBM読み込むﾀﾞー
    /// </summary>
    public class XbmLoader {

        enum STATE {
            None,
            Comment,
            Values,
            Pixels,
            EOF
        }

        /// <summary>
        /// 原色
        /// </summary>
        public I原色 ColorResolver { get; }

        /// <summary>
        /// ｺﾝｽ
        /// </summary>
        public XbmLoader() {
            ColorResolver = new Fallback原色();
        }

        /// <summary>
        /// ﾄﾗｸﾀー
        /// </summary>
        /// <param name="cr">原色</param>
        public XbmLoader(I原色 cr) {
            ColorResolver = cr;
        }

        /// <summary>
        /// 読み込む
        /// </summary>
        /// <param name="path">ﾌｧｲﾙ名</param>
        /// <returns>XBM</returns>
        public Xbm Load(string path) {
            var lines = new List<string>();
            using (var file =
                new System.IO.StreamReader(path, System.Text.Encoding.UTF8)) {
                string line = string.Empty;
                while ((line = file.ReadLine()) != null) {
                    lines.Add(line.Trim());
                }
            }
            return Load(System.IO.Path.GetFileNameWithoutExtension(path), lines);
        }

        /// <summary>
        /// 読み込む
        /// </summary>
        /// <param name="stream">ﾑ</param>
        /// <returns>XBM</returns>
        public Xbm Load(string name, System.IO.Stream stream) {
            var lines = new List<string>();
            using (var file =
                new System.IO.StreamReader(stream, System.Text.Encoding.UTF8)) {
                string line = string.Empty;
                while ((line = file.ReadLine()) != null) {
                    lines.Add(line.Trim());
                }
            }
            return Load(name, lines);
        }

        /// <summary>
        /// 読み込む
        /// </summary>
        /// <param name="name">XBM名</param>
        /// <param name="source">文字列</param>
        /// <returns></returns>
        public Xbm Load(string name, IEnumerable<string> source) {
            var xbm = new Xbm(ColorResolver);

            if (null != name) {
                xbm.Name = name;
            }

            var state = STATE.None;
            var stack = new Stack<STATE>();
            bool eof = false;
            int pos = 0;
            foreach (var _s in source) {
                var line = _s.TrimStart();
                if (line.EndsWith("};")) {
                    eof = true;
                }
                if (line.IndexOf("/*") >= 0) {
                    stack.Push(state);
                    state = STATE.Comment;
                }
                if ((state == STATE.Comment) &&
                    (line.IndexOf("*/") >= 0)) {
                    state = stack.Pop();
                    continue;
                }
                
                if (state == STATE.Comment) {
                    continue;
                }

                if ((state == STATE.None) && 
                    (line.StartsWith("#define")) && 
                    (line.Contains("_width") || line.Contains("_height")))
                {
                    var vs = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    var o = vs[1].LastIndexOf('_');
                    if (xbm.Name == String.Empty) {
                        xbm.Name = vs[1].Substring(0, o);
                    }
                    var pr = vs[1].Substring(o);
                    switch (pr) {
                        case "_width":
                            xbm.Width = int.Parse(vs[2]);
                            break;
                        case "_height":
                            xbm.Height = int.Parse(vs[2]);
                            break;
                        default:
                            throw new およよ($"ごめん、わからん => {vs[1]}");
                    }
                    continue;
                }

                if (line.Contains($"_bits")) {
                    state = STATE.Pixels;
                    xbm.AllocPixels();
                }
                if (state != STATE.Pixels) {
                    continue;
                }
                var br = line.IndexOf('{');
                if (br >= 0) {
                    line = line.Substring(br + 1);
                }
                br = line.IndexOf('}');
                if (br >= 0) {
                    line = line.Substring(0, br);
                }
                foreach (var b in line.Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                    var w = b;
                    if (w[0] == '\'') {
                        // ごく希に居るPerlっぽい書き方のやつ
                        var k = w.IndexOf('x');
                        var s = w.LastIndexOf('\'');
                        if (k > 0) {
                            w = "0" + w.Substring(k, s - k);
                        }
                    }
                    xbm.RawPixels[pos] = Convert.ToByte(w, 16);
                    if (++pos >= xbm.RawPixels.Length) {
                        eof = true; // たまに居る狂ったxbm(配列手書きで溢れてる)
                        break;
                    }
                }
                if (eof) {
                    break;
                }
            }
            if (state == STATE.None) {
                throw new それちがう($"XPMじゃないっぽい");
            }
            if (xbm.RawPixels.Length != pos) {
                throw new およよ($"bitsの長さがおかしい: 期待値=>{xbm.RawPixels.Length} 実際=>{pos}");
            }

            return xbm;
        }
    }
}
