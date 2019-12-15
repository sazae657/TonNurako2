using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Inutility;
using TonNurako.X11;
using TonNurako.X11.Extension.Xft;
using Xunit;


namespace TonNurakoTestEx {
    public class FontConfigTest : IClassFixture<DisplayFixture>, IDisposable {

        DisplayFixture fix;
        Unity unity;
        public FontConfigTest(DisplayFixture fixture) {
            fix = fixture;
            unity = new Unity();
        }

        void BeforeCreateWindow() {
            Assert.True(FontConfig.Init());
            //Assert.True(FontConfig.Reinitialize());
            Assert.True(FontConfig.BringUptoDate());
            using (var fc = FontConfig.LoadConfig()) {
                Assert.NotNull(fc);
            }
            using (var fc = FontConfig.LoadConfigAndFonts()) {
                Assert.NotNull(fc);
            }
            using (var fc = FontConfig.GetLangs()) {
                Assert.NotNull(fc);
            }
        }

        public void Dispose() {
            unity.Asset();
        }

        const string UNICODE_STR = "【神】俺様が考えた最強文字列【降臨】";
        const string LANG_STR = "【神】俺様が考えた最強公用語【降臨】";

        [Fact]
        public void PatternTest() {
            Assert.NotNull(unity.Store(FcPattern.Create()));
            //Assert.NotNull(unity.Store(FcPattern.ParseXlfd("*misc*", false, false)));
            Assert.NotNull(unity.Store(FcPattern.Parse(":14")));
            unity.Asset();
            using (var c = FcPattern.Create()) {
                Assert.NotNull(c);
                Assert.NotNull(unity.Store(c.Duplicate()));
                Assert.True(c.AddBool(FcObjectId.FC_SCALABLE, true));
                Assert.True(c.AddInteger(FcObjectId.FC_PIXEL_SIZE, 14));
                Assert.True(c.AddString(FcObjectId.FC_FAMILY, "misc"));
                Assert.True(c.AddMatrix(FcObjectId.FC_MATRIX, new FcMatrix()));
                Assert.True(c.AddCharSet(FcObjectId.FC_CHARSET, unity.Store(FcCharSet.Create())));
                Assert.True(c.AddLangSet(FcObjectId.FC_LANG, unity.Store(FcLangSet.Create())));
            }
            using (var c = FcPattern.Parse(":14")) {
                Assert.NotNull(c);
                var cs = unity.Store(FcCharSet.Create());
                Assert.NotNull(cs);
                Assert.True(cs.AddChar(0x0001F4A9));

                Assert.True(c.AddCharSet(FcObjectId.FC_CHARSET, cs));
                Assert.True(c.AddBool(FcObjectId.FC_SCALABLE, true));
                using (var cf = FcConfig.GetCurrent()) {
                    Assert.True(cf.Substitute(c, FcMatchKind.FcMatchPattern));
                    Assert.NotNull(unity.Store(FcDefault.GetDefaultLangs()));
                    FcDefault.Substitute(c);
                }
            }
        }

        [Fact]
        public void MatrixSetTest() {
            var m1 = new FcMatrix();
            var m2 = new FcMatrix();
            m1.Init();
            m2.Init();
            Assert.NotNull(m1.Copy());
            Assert.True(m1.Equal(m2));
            //Assert.NotNull(m1.Multiply(m2));
            m1.Rotate(10, 10);
            m1.Scale(10, 10);
            m1.Shear(10, 10);
        }

        [Fact]
        public void StrSetTest() {
            var s1 = unity.Store(FcStrSet.Create());
            var s2 = unity.Store(FcStrSet.Create());
            Assert.True(s1.Add(UNICODE_STR));
            Assert.True(s1.Add(LANG_STR));
            Assert.True(s1.Del(LANG_STR));
            Assert.False(s1.Del(LANG_STR));
            Assert.True(s1.Member(UNICODE_STR));
            Assert.False(s1.Member(LANG_STR));

            Assert.False(s1.Equal(s2));
            Assert.True(s2.Add(UNICODE_STR));
            Assert.True(s1.Equal(s2));

            s1.Add(LANG_STR);
            var l1 = unity.Store(FcStrList.Create(s1));
            l1.First();
            Assert.Equal(UNICODE_STR, l1.Next());
            Assert.Equal(LANG_STR, l1.Next());
            Assert.Null(l1.Next());

            unity.Asset();
        }

        [Fact]
        public void LangSetTest() {
            Assert.NotNull(FcLangSet.Normalize("ja"));
            Assert.Null(FcLangSet.Normalize(LANG_STR));
            using(var o = FcLangSet.FcLangGetCharSet("ja")) {
                Assert.NotNull(o);
            }
            using (var o = FcLangSet.FcLangGetCharSet(LANG_STR)) {
                Assert.Null(o);
            }
            var fc = unity.Store(FcLangSet.Create());
            Assert.NotNull(fc);
            using (var o = fc.Copy()) {
                Assert.NotNull(o);
            }

            Assert.True(fc.Add("ja"));
            Assert.True(fc.Add("en"));
            Assert.True(fc.Del("en"));

            Assert.Equal(FcLangResult.FcLangEqual, fc.HasLang("ja"));
            Assert.NotEqual(FcLangResult.FcLangEqual, fc.HasLang("en"));

            unity.Asset();
        }


        [Fact]
        public void FontSetTest() {
            using (var fs = FcFontSet.Create()) {
                Assert.NotNull(fs);
            }
        }

        [Fact]
        public void ConfigTest() {
            Assert.NotEmpty(FcConfig.Home());
            Assert.True(FcConfig.EnableHome(false));
            Assert.False(FcConfig.EnableHome(true));

            var cf = unity.Store(FcConfig.GetCurrent());
            Assert.NotNull(cf);
            Assert.True(cf.SetCurrent());
            Assert.True(cf.UptoDate());
            Assert.True(cf.BuildFonts());

            using (var o = cf.GetFontDirs()) {
                Assert.NotNull(o);
            }
            using (var o = cf.GetConfigDirs()) {
                Assert.NotNull(o);
            }
            using (var o = cf.GetConfigFiles()) {
                Assert.NotNull(o);
            }
            using (var o = cf.GetBlanks()) {
                Assert.NotNull(o);
            }
            using (var o = cf.GetCacheDirs()) {
                Assert.NotNull(o);
            }

            int k = cf.GetRescanInterval();
            Assert.True(cf.SetRescanInterval(10000));
            Assert.Equal(10000, cf.GetRescanInterval());
            Assert.True(cf.SetRescanInterval(k));
        }

        [Fact]
        public void BlanksTest() {
            var br = unity.Store(FcBlanks.Create());
            Assert.NotNull(br);
            Assert.True(br.Add(0x0001F4A9));
            Assert.True(br.IsMember(0x0001F4A9));
            Assert.False(br.IsMember(0x0001F4AA));
        }

        [Fact]
        public void CharSetTest() {
            var cs = unity.Store(FcCharSet.Create());
            Assert.NotNull(cs);
            Assert.True(cs.AddChar(0x0001F4A9));
            Assert.True(cs.DelChar(0x0001F4A9));
            Assert.True(cs.AddChar(0x0001F4A9));

            Assert.True(cs.AddChar(0x0001F4AA));
            Assert.True(cs.DelChar(0x0001F4AA));
            using (var iso = cs.Copy()) {
                Assert.NotNull(iso);
            }
            Assert.True(cs.HasChar(0x0001F4A9));
            Assert.False(cs.HasChar(0x0001F4AA));
            Assert.Equal(1, (int)cs.Count());

            using (var iso = FcCharSet.Create()) {
                Assert.NotNull(iso);
                Assert.False(iso.Equal(cs));
                Assert.True(iso.AddChar(0x0001F4A9));
                Assert.True(iso.Equal(cs));
            }

            var cs2 = unity.Store(FcCharSet.Create());
            Assert.NotNull(cs2);
            Assert.True(cs2.AddChar(0x0001F4AB));
            using (var iso = cs.Intersect(cs2)) {
                Assert.NotNull(iso);
            }
            using (var iso = cs.Union(cs2)) {
                Assert.NotNull(iso);
                Assert.Equal(2, (int)iso.Count());
            }
            using (var iso = cs.Subtract(cs2)) {
                Assert.NotNull(iso);
                Assert.Equal(1, (int)iso.Count());
            }
            bool boo = false;
            Assert.True(cs.Merge(cs2, out boo));
            Assert.True(boo);

            var cs3 = unity.Store(FcCharSet.Create());
            Assert.NotNull(cs3);
            Assert.True(cs3.AddChar(0x0001F4A9));
            Assert.Equal(1, (int)cs.IntersectCount(cs3));
            Assert.Equal(1, (int)cs.SubtractCount(cs3));
            Assert.True(cs3.IsSubset(cs));

            unity.Asset();
        }
    }
}
