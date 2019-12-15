//
// ﾄﾝﾇﾗｺ
//
// Xlibﾗｯﾊﾟー
//
using System;
using System.Runtime.InteropServices;

namespace TonNurako.X11
{

    [StructLayout(LayoutKind.Sequential)]
    internal struct XWindowChanges{
            int x, y;
            int width, height;
            int border_width;
            IntPtr sibling; //Window
            int stack_mode;
    }
/*
    [StructLayout(LayoutKind.Sequential)]
    internal struct XModifierKeymap {
            int max_keypermod;
            IntPtr modifiermap;  // KeyCode *
    } ;
    */

    [StructLayout(LayoutKind.Sequential)]
    public struct XTimeCoord{
        public uint Time;
        public short X;
        public short Y;
    }
}
