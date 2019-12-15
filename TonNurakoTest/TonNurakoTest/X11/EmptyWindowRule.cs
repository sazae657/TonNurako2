using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using Xunit;

namespace TonNurakoTest.X11 {
    public class EmptyWindowRule : IClassFixture<WindowFixture>, IDisposable {
        WindowFixture fix;
        Unity unity;
        public EmptyWindowRule(WindowFixture fixture) {
            fix = fixture;
            unity = new Unity();
        }

        public void Dispose() {
            unity.Asset();
        }

        [Fact]
        public void EmptyRule() {
        }
    }
}
