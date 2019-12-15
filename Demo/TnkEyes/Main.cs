using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonNurako;
using TonNurako.Widgets;
using TonNurako.X11;
using TonNurako.Xt;

namespace TnkEyes {
    class Program : TonNurako.Widgets.Shell.TopLevel {
        EyesOptions options = new EyesOptions();

        public EyesOptions Options => options;

        void ParseOption(string key, string val) {
            if (null == key) {
                return;
            }

            var property = typeof(EyesOptions).GetProperty(key.Substring(1));
            if (null == property) {
                throw new ArgumentException($"しらないｵﾌﾟｼｮﾝ: {key}");
            }

            if (property.PropertyType == typeof(bool)) {
                property.SetValue(options, key.StartsWith("+"));
            }
            else if (property.PropertyType == typeof(string)) {
                if (null == val) {
                    throw new ArgumentException($"引数がないよう: {key}");
                }
                property.SetValue(options, val);
            }
            else {
                throw new ArgumentException($"なんだこれ: {key} {val}>");
            }
        }

        void ParseOption(string[] args) {
            string val = null;
            string key = null;
            foreach (var a in args) {
                if (a.StartsWith("-") || a.StartsWith("+")) {
                    if (null != key) {
                        ParseOption(key, val);
                    }
                    key = a;
                    val = null;
                    continue;
                }
                else if (val == null) {
                    val = a;
                }
                else {
                    throw new ArgumentException($"なんだこれ: {a}");
                }
                ParseOption(key, val);
                key = val = null;
            }
            ParseOption(key, val);
        }

        public override void ShellCreated() {
            base.ShellCreated();
            var c = new Eyes(options, this.AppContext);
            var wgt = TonNurako.Xt.Widget.CreateManagedWidget("EyesTnk", c, this);
        }

        static void Main(string[] args) {
            //System.Diagnostics.Debug.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(Console.Out));

            var app = new TonNurako.ApplicationContext();
            app.FallbackResource.Add("TnkEyes.geometry", "160x100+100+100");
            app.FallbackResource.Add("TnkEyes.title", "トンヌラコ");
            app.Name = "TnkEyes";
            var prog = new Program();
            try {
                prog.ParseOption(args);
            }
            catch (ArgumentException e) {
                Console.WriteLine($"ｺﾏﾝﾄﾞﾗｲﾝがおかしい\n{e.Message}");
                Console.WriteLine(
                    "つかいかた\n" +
                    "[-geometry [{width}][x{height}][{+-}{xoff}[{+-}{yoff}]]]\n" +
                    "[-fg { color}] [-bg {color}] [-bd {color}] [-bw {pixels}]\n" +
                    "[-shape | +shape][-outline { color}] [-center {color}]\n" +
                    "[-distance | +distance] [-render | +render]\n"
                    );
                return;
            }

            prog.Name = "TnkEyes";
            TonNurako.Application.Run(app, prog, args);
        }
    }
}
