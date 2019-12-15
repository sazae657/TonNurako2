//
// ﾄﾝﾇﾗｺ
// 
// ｴｸｽﾄﾘーﾑｽﾎﾟーﾂ
//
using System;

namespace TonNurako.Native {

    /// <summary>
    /// ﾄﾝﾇﾗｺ名 - ﾂーﾙｷｯﾄ名のﾏｯﾋﾟﾝｸﾞ用
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class ToolkitOptionAttribute : System.Attribute
    {

        public class Permission {
            public bool Create {
                get; set;
            }
            public bool Get {
                get; set;
            }
            public bool Set {
                get; set;
            }

            public Permission() {
                Create = true;
                Get = true;
                Set = true;
            }
        }

        public string Label {
            get ; set;
        }

        public bool Create {
            get {return this.Access.Create;}
            set {this.Access.Create = value;}
        }
        public bool Get {
            get {return this.Access.Get;}
            set {this.Access.Get = value;}
        }
        public bool Set {
            get {return this.Access.Set;}
            set {this.Access.Set = value;}
        }

        public Permission Access {
            get; internal set;
        }

        public ToolkitOptionAttribute(string label)
        {
            this.Label = label;
            this.Access = new Permission();
        }

        public static T GetEnum<T>(string label) where T : struct, IComparable, IConvertible, IFormattable
        {
            foreach (var e in typeof(T).GetFields())
            {
                var attr = System.Attribute.GetCustomAttribute(e, typeof(ToolkitOptionAttribute)) as ToolkitOptionAttribute;

                if (attr != null && attr.Label == label)
                {
                    return (T)e.GetValue(null);
                }
            }
            return default(T);
        }

        public static string GetToolkitName(Enum value)
        {
            Type enumType = value.GetType();
            string name = Enum.GetName(enumType, value);
            ToolkitOptionAttribute[] attrs =
                (ToolkitOptionAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(ToolkitOptionAttribute), false);
            return attrs[0].Label;
        }

        public static Permission GetPermission(Enum value)
        {
            Type enumType = value.GetType();
            string name = Enum.GetName(enumType, value);
            ToolkitOptionAttribute[] attrs =
                (ToolkitOptionAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(ToolkitOptionAttribute), false);
            return attrs[0].Access;
        }
    }
}
