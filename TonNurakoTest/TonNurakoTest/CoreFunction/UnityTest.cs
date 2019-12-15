using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TonNurakoTest.CoreFunction {
    public class Unity : IDisposable {

        TonNurako.Inutility.Unity unity;
        public Unity() {
            unity = new TonNurako.Inutility.Unity();
        }

        public void Dispose() {
            unity.Asset();
        }

        [Fact]
        public void AssetStore() {
            unity.Asset();
        }
    }
}

