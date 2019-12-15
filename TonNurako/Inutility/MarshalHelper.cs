using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.Inutility {
    public class MarshalHelper {
        public delegate T MarshalPounterDelegaty<T>(IntPtr op);

        public static T_v [] ToStructArray<T_v>(IntPtr ptr, int num)
            where T_v : struct
        {
            var arr = new IntPtr[num];
            var tr = new T_v[num];
            int size = Marshal.SizeOf(typeof(T_v));
            Marshal.Copy(ptr, arr, 0, num);
            for (int i = 0; i < num; ++i) {
                IntPtr current = new IntPtr(ptr.ToInt64() + (size * i));
                tr[i] = Marshal.PtrToStructure<T_v>(current);
            }
            return tr;
        }

        public static string[] ToStringArray(IntPtr ptr, int num) {
            var arr = new IntPtr[num];
            var tr = new string[num];
            Marshal.Copy(ptr, arr, 0, num);
            for (int i = 0; i < num; ++i) {
                if(arr[i] == IntPtr.Zero) {
                    tr[i] = null;
                    continue;
                }
                tr[i] = Marshal.PtrToStringAnsi(arr[i]);
            }
            return tr;
        }

        public static T_v[] AsArray<T_v>(IntPtr ptr, Type type, int num, MarshalPounterDelegaty<T_v> delegaty)
        {
            var size = Marshal.SizeOf(type);
            var tr = new T_v[num];
            for (int i = 0; i < num; ++i) {
                IntPtr current = new IntPtr(ptr.ToInt64() + (size * i));
                tr[i] = delegaty(current);
            }
            return tr;
        }
    }
}
