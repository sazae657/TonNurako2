using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.XImageFormat.Xi {
    
    /// <summary>
    /// 原色画像
    /// </summary>
    public interface 原色画像 
    {
        /// <summary>
        /// 名前
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 幅
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// 高さ
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// ﾋﾟｸｾﾙﾃﾞﾀー
        /// </summary>
        /// <returns>ﾋﾟｸｾﾙﾃﾞﾀー</returns>
        ぉ[] Toぉ();
    }
}
