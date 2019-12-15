using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TonNurako.Data.Resource
{
    /// <summary>
    /// ｱｸｾｽﾀｲﾐﾝｸﾞ
    /// </summary>
    [Flags]
    public enum  Access {
            /// <summary>
            /// 生成時
            /// </summary>
            C = 0x00000001,
            
            /// <summary>
            /// ｾｯﾄできるよ
            /// </summary>
            S = 0x00000002,
            /// <summary>
            /// ｹﾞｯﾄできるよ
            /// </summary>
            G = 0x00000004,

            // 以下そこそこ

            /// <summary>
            /// 生成時と生成後にｾｯﾄ出来るよ
            /// </summary>
            CS = C|S,
            
            /// <summary>
            /// 生成時ｾｯﾄ出来て生成後にｹﾞｯﾄできるよ
            /// </summary>
            CG = C|G,

            /// <summary>
            /// 生成時にも生成後にもｾｯﾄ出来て生成後にはｹﾞｯﾄもできるよ
            /// </summary>
            CSG = C|S|G,

            /// <summary>
            /// 生成後にｾｯﾄとｹﾞｯﾄができるよ
            /// </summary>
            SG = S|G,
    }

    /// <summary>
    /// ﾘｿーｽ扱いのﾌﾟﾛﾊﾟﾁーの属性
    /// </summary>
    [AttributeUsage(
        AttributeTargets.Method|AttributeTargets.Property,
        AllowMultiple = false,
        Inherited = false)]
    public class SportyResourceAttribute : Attribute
    {
        /// <summary>
        /// ｱｸｾｽﾀｲﾐﾝｸﾞ
        /// </summary>
        public Access Access {
            get; private set;
        }
        
        /// <summary>
        /// 割り振るのかね
        /// </summary>
        /// <param name="access">ｱｸｾｽﾀｲﾐﾝｸﾞ</param>
        public SportyResourceAttribute(Access access) { this.Access = access; }
        
    }
}
