using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.X11 {
    public interface IX11Interop {
        /// <summary>
        /// ﾄﾞﾙﾊﾝ
        /// </summary>
        IntPtr Handle { get; }
    }

    public interface IX11Interop<T> {
        /// <summary>
        /// ﾄﾞﾙﾊﾝ
        /// </summary>
        T Handle { get; }
    }


    /// <summary>
    /// IntPtrを返すﾃﾞﾘｹﾞーﾃｨー
    /// </summary>
    /// <returns>IntPtr</returns>
    public delegate IntPtr ReturnPointerDelegaty();

    /// <summary>
    /// なんか返すﾃﾞﾘｹﾞーﾃｨー
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public delegate T ReturnPointerDelegaty<T>();
}
