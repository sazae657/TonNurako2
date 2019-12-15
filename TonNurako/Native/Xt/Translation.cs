using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonNurako.X11;

namespace TonNurako.Xt {
    public class Translations : IX11Interop {
        internal Translations() {
        }

        internal IntPtr handle;
        public IntPtr Handle => handle;

        public static Translations ParseTranslationTable(string source) {
            Translations r = new Translations();
            r.handle = XtSports.XtParseTranslationTable(source);
            return r;
        }
    }
}
