using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.Inutility {
    public class Unity {
        Stack<IDisposable> stack;

        public Unity() {
            stack = new Stack<IDisposable>();
        }

        public T Store<T>(T t)
            where T : IDisposable {
            if (null == t) {
                return t;
            }
            if (stack.Contains(t)) {
                throw new DuplicateWaitObjectException("Unity");
            }
            stack.Push(t);
            return t;
        }

        public void Store<T>(IEnumerable<T> t)
            where T : IDisposable {
            foreach (var s in t) {
                if (null == s) {
                    continue;
                }
                Store(s);
            }
        }

        public void Asset() {
            while (stack.Count > 0) {
                stack.Pop().Dispose();
            }
        }
    }
}
