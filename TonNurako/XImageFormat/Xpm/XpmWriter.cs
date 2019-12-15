using System.Collections.Generic;
using System.Text;
using TonNurako.XImageFormat.Xi;

namespace TonNurako.XImageFormat {
    public class XpmWriter {
        const string CHARS = " .+@#$%&*=-;>,')!~{]^/(_:<[}|1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ`";

        public XpmWriter() {
        }
        
        public void Write(System.IO.Stream stream, Xpm xpm) {
            StringBuilder sb = new StringBuilder();

            sb.Append("/* XPM */\n")
                .Append($"static const char* {xpm.Name}[] = {{\n");

            if (xpm.XHotSpot > 0 && xpm.YHotSpot > 0) {
                sb.Append("/* columns rows colors chars-per-pixel x-hotspot y-hotspot */\n")
                  .Append($"\"{xpm.Columns} {xpm.Rows} {xpm.NumColors} {xpm.CharsPerPixel} {xpm.XHotSpot} {xpm.YHotSpot}\",\n");
            }
            else {
                sb.Append("/* columns rows colors chars-per-pixel */\n")
                  .Append($"\"{xpm.Columns} {xpm.Rows} {xpm.NumColors} {xpm.CharsPerPixel}\",\n");
            }

            foreach (var c in xpm.ColorLookupTable) {
                sb.Append($"\"{c.ToColorString()}\",\n");
            }
            sb.Append("/* pixels */\n");

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
            var pix = xpm.Toぉ();
            for (int y = 0; y < xpm.Rows; ++y) {
                sb.Append("\"");
                for (int x = 0; x < xpm.Columns; ++x) {
                    var ck = rt[pix[pos]];
                    sb.Append(ck);
                    pos++;
                }
                sb.Append("\"");
                if (y < xpm.Rows - 1) {
                    sb.Append(",");
                }
                else {
                    sb.Append("}");
                }
                sb.Append("\n");
            }
            var b = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            stream.Write(b, 0, b.Length);
        }

        public void Write(System.IO.Stream stream, string name, int width, int height, ぉ[] arr) {
            var cmap = new Dictionary<ぉ, int>();

            cmap.Add(new ぉ(0, 0, 0, 0), 0);
            int pi = 1;
            foreach (var c in arr) {
                if (!cmap.ContainsKey(c)) {
                    cmap.Add(c, pi++);
                }
            }
            var dik = CHARS.Length - 1;
            // 桁数
            int cn = cmap.Count < dik ? 1 : (cmap.Count / (CHARS.Length*CHARS.Length))+2;
            var keys = new string[cmap.Count];
            int [] ack = new int[cn];
            int vc = 0;

            for (int j = 0; j < cn; j++) {
                ack[j] = j;
            }
            int cni = 0;

            for (int i = 0; i < cmap.Count; i++) {
                keys[i] = CHARS[vc].ToString();
                for (int j = 1; j < cn; j++) {
                    keys[i] += CHARS[ack[j-1]];
                }
                vc++;
                if (vc > dik) {
                    vc = 0;
                    if (++ack[cni] >= dik) {
                        cni++;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("/* XPM */\n")
                .Append($"static const char* {name}[] = {{\n")
                .Append("/* columns rows colors chars-per-pixel */\n")
                .Append($"\"{width} {height} {cmap.Count} {cn}\",\n");

            foreach (var c in cmap.Keys) {
                var k = keys[cmap[c]];
                if (cmap[c] == 0) {
                    sb.Append($"\"{k} c None\",\n");
                }
                else {
                    sb.Append($"\"{k} c {c.ToXRGB8()}\",\n");
                }
            }
            sb.Append("/* pixels */\n");

            int pos = 0;
            for (int y = 0; y < height; ++y) {
                sb.Append("\"");
                for (int x = 0; x < width; ++x) {
                    var ck = keys[cmap[arr[pos]]];
                    sb.Append(ck);
                    pos++;
                }
                sb.Append("\"");
                if (y < height - 1) {
                    sb.Append(",");
                }
                else {
                    sb.Append("}");
                }
                sb.Append("\n");
            }
            var b = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            stream.Write(b, 0, b.Length);
        }
       
    }
}
