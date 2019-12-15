using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TonNurako.XImageFormat.Xi;

namespace TonNurako.XImageFormat {

    /// <summary>
    /// XPMを読むぞい
    /// </summary>
    public class XpmLoader {
        enum STATE {
            None,
            Comment,
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
        /// ｺﾝｽﾄﾗｸﾀー
        /// </summary>
        public XpmLoader() {
            ColorResolver = new Fallback原色();
        }

        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀー
        /// </summary>
        /// <param name="cr">原色</param>
        public XpmLoader(I原色 cr) {
            ColorResolver = cr;
        }

        /// <summary>
        /// ﾌｧｲﾙから読み込む
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Xpm Load(string path) {
            var lines = new List<string>();
            using (var file = 
                new System.IO.FileStream(path, System.IO.FileMode.Open)) {
                return Load(file);
            }
        }

        /// <summary>
        /// ｽﾄﾘーﾑーから読み込む
        /// </summary>
        /// <param name="stream">ｽﾄﾘーﾑー</param>
        /// <returns></returns>
        public Xpm Load(System.IO.Stream stream) {
            var lines = new List<string>();
            using (var file =
                new System.IO.StreamReader(stream, System.Text.Encoding.UTF8)) {
                string line = string.Empty;
                while ((line = file.ReadLine()) != null) {
                    lines.Add(line.Trim());
                }
            }
            return Load(lines);
        }

        Regex START_LINE = new Regex(@"static[\t\s]+.*\[\]([\t\s]+)?=([\t\s]+)?{");
    
        /// <summary>
        /// 文字列から読み込む
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Xpm Load(IEnumerable<string> source) {
            var xpm = new Xpm();
            xpm.ColorResolver = ColorResolver;

            var state = STATE.None;
            var stack = new Stack<STATE>();
            int colors = 0;
            int pixels = 0;
            bool eof = false;
            foreach (var _s in source) {
                var line = _s.TrimStart();
                if (line.EndsWith("};")) {
                    eof = true;
                }
                if (! line.StartsWith("\"")) {
                    if (line.IndexOf("/*") >= 0) {
                        stack.Push(state);
                        state = STATE.Comment;
                    }
                    if ((state == STATE.Comment) && 
                        (line.IndexOf("*/") >= 0)) {
                        state = stack.Pop();
                        continue;
                    }
                }
                if (state == STATE.Comment) {
                    continue;
                }
                if (line.StartsWith("\"")) {
                    line = line.Substring(line.IndexOf('\"') + 1);
                    line = line.Substring(0, line.IndexOf('\"'));
                }
                if (line.Length == 0) {
                    continue;
                }

                switch (state) {
                    case STATE.None:
                        if (START_LINE.IsMatch(line)) {
                            if (!ParseStartLine(xpm, line)) {
                                continue;
                            }
                            state = STATE.Values;
                        }
                        continue;
                    case STATE.Values:
                        ParseValues(xpm, line);
                        state = STATE.Colors;
                        break;
                    case STATE.Colors:
                        ParseColors(xpm, line);
                        if (++colors >= xpm.NumColors) {
                            state = STATE.Pixels;
                            break;
                        }
                        break;
                    case STATE.Pixels:
                        ParsePixels(xpm, pixels, line);
                        if (++pixels >= xpm.Rows) {
                            state = STATE.Extensions;
                            break;
                        }
                        break;
                    case STATE.Extensions:
                        // わからん
                        break;
                    default:
                        if (eof) {
                            break;
                        }
                        throw new およよ("ありえない");
                }
                if (eof) {
                    break;
                }
            }
            if (state == STATE.None) {
                throw new それちがう($"XPMじゃないっぽい");
            }

            if (state != STATE.Extensions) {
                throw new およよ($"STATEが {state} で終わった");
            }


            return xpm;
        }

        /// <summary>
        /// 先頭行を読む
        /// </summary>
        /// <param name="xpm">xpm</param>
        /// <param name="s">ぉ</param>
        /// <returns></returns>
        private bool ParseStartLine(Xpm xpm, string s) {
            var p = s.IndexOf('*');
            if (p < 0) {
                return false;
            }
            s = s.Substring(p).Trim();
            s = s.Substring(1, s.IndexOf('[')-1).Trim();
            xpm.Name = s;

            return true;
        }

        /// <summary>
        /// VALUESを読む
        /// </summary>
        /// <param name="xpm">xpm</param>
        /// <param name="s">ぉ</param>
        /// <returns></returns>
        private bool ParseValues(Xpm xpm, string s) {
            var vs = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (vs.Length < (int)Xpm.VulkanIndex.XHotSpot) {
                throw new およよ($"Values {vs.Length} < {(int)Xpm.VulkanIndex.XHotSpot}");
            }

            for (int i = 0; i < vs.Length; ++i) {
                xpm.Values[i] = Int32.Parse(vs[i]);
            }
            
            xpm.AllocPixels();
            return true;
        }

        /// <summary>
        /// 色定義を読む
        /// </summary>
        /// <param name="xpm">xpm</param>
        /// <param name="s">ぉ</param>
        /// <returns></returns>
        private bool ParseColors(Xpm xpm, string s) {
            var c = 総天然色.Parse(xpm, s);
            xpm.AddColor(c);
            return true;
        }

        /// <summary>
        /// ﾋﾟｸｾﾙﾃﾞﾀーを読む
        /// </summary>
        /// <param name="xpm">xpm</param>
        /// <param name="row">現在の行</param>
        /// <param name="s">ぉ</param>
        /// <returns></returns>
        private bool ParsePixels(Xpm xpm, int row, string s) {
            int x = 0;
            for (int i = 0; i < xpm.Columns * xpm.CharsPerPixel; i+= xpm.CharsPerPixel, x++) {
                xpm.SetPixel(x, row, s.Substring(i, xpm.CharsPerPixel));
            }

            return true;
        }
    }
}
