using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TonNurakoTest.CoreFunction {

    public class ExtremeSports : IDisposable {

        public ExtremeSports() {

        }

        public void Dispose() {
        }

        [Fact]
        public void CheckSymbol() {
            Assert.True(TonNurako.Native.ExtremeSports.CheckLinkage((e)=>Console.Error.WriteLine($"SNF: {e}")));
        }
    }
}
