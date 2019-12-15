using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.Inutility {
    public class Dumper {
        public delegate void Delegaty(string p);

        static void DumpPropertyR(object obzekt, string prefix, int depth, int maxDepth, Delegaty delegaty) {
            var infoArray = obzekt.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            depth++;
            foreach (var info in infoArray) {
                if (info.PropertyType.Namespace.StartsWith("TonNurako") &&
                    depth < maxDepth && info.PropertyType.IsClass)
                {
                    var sv = "(NULL)";
                    var v = info.GetValue(obzekt, null);
                    if (null == v) {
                        delegaty($"{obzekt.GetType().Name}# {info.Name}={sv}");
                    }
                    else {
                        DumpPropertyR(v, $"{prefix}.{info.Name}", depth, maxDepth, delegaty);
                    }
                    continue;
                }
                var xsv = "(NULL)";
                var xv = info.GetValue(obzekt, null);
                if (null != xv) {
                    xsv = xv.ToString();
                }
                delegaty($"{obzekt.GetType().Name}#{prefix} {info.Name}={xv}");
            }
        }

        public static void DumpProperty(object obzekt, Delegaty delegaty) {
            int depth = 0;
            DumpPropertyR(obzekt, "", depth, 2, delegaty);
        }

        public static void DumpProperty(object obzekt, int max, Delegaty delegaty) {
            int depth = 0;
            DumpPropertyR(obzekt, "", depth, max, delegaty);
        }

        public static void DumpStruct(object obzekt, Delegaty delegaty) {
            if (null == obzekt) {
                throw new NullReferenceException("obzekt is NULL!!");
            }
            var infoArray = obzekt.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var m in infoArray) {
                var v = m.GetValue(obzekt);
                var sv = "(NULL)";
                if (null != v) {
                    sv = v.ToString();
                    if(m.FieldType.IsArray) {
                        var ar = (System.Collections.IList)m.GetValue(obzekt);
                        sv = $"{ar[0].GetType()}[{ar.Count}] {{";
                        foreach(var b in ar) {
                            sv += $"{b}, ";
                        }
                        sv += "}";
                    }
                }
                delegaty($"{obzekt.GetType().Name}# {m.Name}={sv}");
            }
        }
    }
}
