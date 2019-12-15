using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;
using TonNurako.X11.Event;

namespace TonNurako.X11 {
    public class ModifierMap {
        internal static class NativeMethods {
            #region ｱｸｾｯｻー
            // int: TNK_GetXModifierKeymap_MaxKeypermod const XModifierKeymap*:p
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetXModifierKeymap_MaxKeypermod", CharSet = CharSet.Auto)]
            internal static extern int TNK_GetXModifierKeymap_MaxKeypermod(IntPtr p);

            // void: TNK_SetXModifierKeymap_MaxKeypermod XModifierKeymap*:p  const KeyCode:val
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetXModifierKeymap_MaxKeypermod", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetXModifierKeymap_MaxKeypermod(IntPtr p, int val);

            // KeyCode: TNK_GetXModifierKeymap_Modifiermap const XModifierKeymap*:p  const int:index
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_GetXModifierKeymap_Modifiermap", CharSet = CharSet.Auto)]
            internal static extern byte TNK_GetXModifierKeymap_Modifiermap(IntPtr p, int index);

            // void: TNK_SetXModifierKeymap_Modifiermap XModifierKeymap*:p  const int:index  const KeyCode:val
            [DllImport(ExtremeSports.Lib, EntryPoint = "TNK_SetXModifierKeymap_Modifiermap", CharSet = CharSet.Auto)]
            internal static extern void TNK_SetXModifierKeymap_Modifiermap(IntPtr p, int index, byte val);
            #endregion
        }

        IntPtr handle = IntPtr.Zero;

        ModifierMap() {
        }
        internal ModifierMap(IntPtr p) {
            handle = p;
            VectorSzie = 8 * MaxKeyPerMod;
        }

        public int MaxKeyPerMod =>
            NativeMethods.TNK_GetXModifierKeymap_MaxKeypermod(handle);

        public int VectorSzie { get; private set; }

        //public static void TNK_SetXModifierKeymap_MaxKeypermod(ref XModifierKeymap p, int val) =>
        ///   NativeMethods.TNK_SetXModifierKeymap_MaxKeypermod(p, val);

        public byte this[int i] {
            get => GetAt(i);
            set => SetAt(i, value);
        }

        public byte GetAt(int index) {
            if (index > VectorSzie) {
                throw new IndexOutOfRangeException($"{index} > {VectorSzie}");
            }
            return NativeMethods.TNK_GetXModifierKeymap_Modifiermap(handle, index);
        }

        public void SetAt(int index, byte val) {
            if (index > VectorSzie) {
                throw new IndexOutOfRangeException($"{index} > {VectorSzie}");
            }
            NativeMethods.TNK_SetXModifierKeymap_Modifiermap(handle, index, val);
        }
    }

    public class XModifierKeymap :IX11Interop, IDisposable {
        internal static class NativeMethods {
            // XModifierKeymap*: XNewModifiermap int:max_keys_per_mod
            [DllImport(ExtremeSports.Lib, EntryPoint = "XNewModifiermap_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XNewModifiermap(int max_keys_per_mod);

            // XModifierKeymap*: XInsertModifiermapEntry XModifierKeymap*:modmap  KeyCode:keycode_entry  int:modifier
            [DllImport(ExtremeSports.Lib, EntryPoint = "XInsertModifiermapEntry_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XInsertModifiermapEntry(IntPtr modmap, int keycode_entry, int modifier);

            // XModifierKeymap*: XDeleteModifiermapEntry XModifierKeymap*:modmap  KeyCode:keycode_entry  int:modifier
            [DllImport(ExtremeSports.Lib, EntryPoint = "XDeleteModifiermapEntry_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XDeleteModifiermapEntry(IntPtr modmap, int keycode_entry, int modifier);

            // int: XFreeModifiermap XModifierKeymap*:modmap
            [DllImport(ExtremeSports.Lib, EntryPoint = "XFreeModifiermap_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XFreeModifiermap(IntPtr modmap);

            #region 保留
            // int: XChangeKeyboardMapping Display*:display  int:first_keycode  int:keysyms_per_keycode  KeySym*:keysyms  int:num_codes
            //[DllImport(ExtremeSports.Lib, EntryPoint = "XChangeKeyboardMapping_TNK", CharSet = CharSet.Auto)]
            //internal static extern int XChangeKeyboardMapping(IntPtr display, int first_keycode, int keysyms_per_keycode, IntPtr keysyms, int num_codes);

            // KeySym*: XGetKeyboardMapping Display*:display  KeyCode:first_keycode  int:keycode_count  int*:keysyms_per_keycode_return
            //[DllImport(ExtremeSports.Lib, EntryPoint = "XGetKeyboardMapping_TNK", CharSet = CharSet.Auto)]
            //internal static extern IntPtr XGetKeyboardMapping(IntPtr display, int first_keycode, int keycode_count, out IntPtr keysyms_per_keycode_return);
            #endregion

        }

        IntPtr handle = IntPtr.Zero;
        public IntPtr Handle => handle;

        ModifierMap modMap;
        public ModifierMap ModifierMap => modMap;

        internal XModifierKeymap(IntPtr ptr) {
            handle = ptr;
            modMap = new ModifierMap(ptr);
        }

        internal static XModifierKeymap WR(IntPtr ptr) =>
            (IntPtr.Zero != ptr) ? new XModifierKeymap(ptr) : null;

        public static XModifierKeymap NewModifiermap(int max_keys_per_mod) =>
            WR(NativeMethods.XNewModifiermap(max_keys_per_mod));

        public XModifierKeymap Insert(int keycode_entry, int modifier) =>
            WR(NativeMethods.XInsertModifiermapEntry(Handle, keycode_entry, modifier));


        public XModifierKeymap Delete(int keycode_entry, int modifier) =>
            WR(NativeMethods.XDeleteModifiermapEntry(Handle, keycode_entry, modifier));


        public XStatus Free() {
            if (IntPtr.Zero == handle) {
                return XStatus.True;
            }
            var r = NativeMethods.XFreeModifiermap(handle);
            handle = IntPtr.Zero;
            return r;
        }

        #region 保留
        //
        // TODO: 扱いが面倒臭いので保留
        //
        /*
        public static int XChangeKeyboardMapping(IntPtr display, int first_keycode, int keysyms_per_keycode, IntPtr keysyms, int num_codes) =>
            NativeMethods.XChangeKeyboardMapping(display, first_keycode, keysyms_per_keycode, keysyms, num_codes);


        public static IntPtr XGetKeyboardMapping(IntPtr display, int first_keycode, int keycode_count, out IntPtr keysyms_per_keycode_return) =>
            NativeMethods.XGetKeyboardMapping(display, first_keycode, keycode_count, keysyms_per_keycode_return);
        */
        #endregion


        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                Free();
                handle = IntPtr.Zero;
                disposedValue = true;
            }
        }

        #if RLE
        ~XModifierKeymap() {
            if (handle != IntPtr.Zero) {
                throw new ResourceLeakException(this);
            }
            Dispose(false);
        }
        #endif


        public void Dispose() {
            Dispose(true);
            #if RLE
            System.GC.SuppressFinalize(this);
            #endif
        }
        #endregion
    }
}
