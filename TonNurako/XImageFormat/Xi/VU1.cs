using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.XImageFormat.Xi {

    /// <summary>
    /// およよ
    /// </summary>
    [Serializable]
    public class およよ : System.Exception {
        public およよ() {
        }

        public およよ(string message)
        : base(message)
        {
        }

        public およよ(string message, Exception inner)
        : base(message, inner)
        {
        }
    }

    /// <summary>
    /// それちがう
    /// </summary>
    [Serializable]
    public class それちがう : およよ {
        public それちがう() {
        }

        public それちがう(string message)
        : base(message) {
        }

        public それちがう(string message, Exception inner)
        : base(message, inner) {
        }
    }

    /// <summary>
    /// それ対応してない
    /// </summary>
    [Serializable]
    public class それ対応してない : およよ {
        public それ対応してない() {
        }

        public それ対応してない(string message)
        : base(message) {
        }

        public それ対応してない(string message, Exception inner)
        : base(message, inner) {
        }
    }
}
