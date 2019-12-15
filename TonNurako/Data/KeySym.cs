using System;
using TonNurako.X11;
using TonNurako.Xt;

namespace TonNurako.Data
{
    /// <summary>
    /// KeySym
    /// </summary>
    public class KeySym {
        public int NativeKeySym {
            get; internal set;
        }

        public string KeySymStr {
            get; internal set;
        }

        private KeySym() {
            KeySymStr = "";
        }

        public static KeySym FromName(string _Name) {
            var r = new KeySym();

            r.NativeKeySym = Xi.StringToKeysym(_Name);
            r.KeySymStr = Xi.KeysymToString(r.NativeKeySym);

            System.Diagnostics.Debug.WriteLine($"KeySym.FromName<{_Name}> KS={r.NativeKeySym} ST={r.KeySymStr}");

            return r;
        }
        public static KeySym FromKeySym(int _KeySym) {
            var r = new KeySym();

            r.NativeKeySym = _KeySym;
            r.KeySymStr = Xi.KeysymToString(r.NativeKeySym);
            System.Diagnostics.Debug.WriteLine($"KeySym.FromKeySym<{_KeySym}> KS={r.NativeKeySym} ST={r.KeySymStr}");

            return r;
        }

        public override string ToString() {
            return KeySymStr;
        }

    }

    public class Accelerators {
        internal Accelerators() {
        }

        internal System.IntPtr Binary {
            get; set;
        }

        public static Accelerators Compile(string source) {
            Accelerators r = new Accelerators();
            r.Binary = XtSports.XtParseAcceleratorTable(source);
            return r;
        }
    }


}
