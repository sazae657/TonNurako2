using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.X11 {

    [Serializable]
    public class ResourceLeakException : System.Exception {

        public ResourceLeakException()
            : base() 
        {
        }

        public ResourceLeakException(IX11Interop klass,
            [CallerFilePath] string file = "",
            [CallerLineNumber] int line = 0,
            [CallerMemberName] string member = "")
            : base(klass.GetType().ToString()) {
            Console.Error.WriteLine($"ResourceLeakException {klass.ToString()} {file}:{line} {member}");
        }

        public ResourceLeakException(Type klass)
            : base(klass.ToString()) {
        }


        public ResourceLeakException(string message)
            : base(message)
        {
        }

        public ResourceLeakException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
