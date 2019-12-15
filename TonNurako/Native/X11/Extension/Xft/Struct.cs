using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft
{

    [StructLayout(LayoutKind.Sequential)]
    public struct XftCharSpec {
        public uint Ucs4;//FcChar32
        public short X;
        public short Y;

        public XftCharSpec(uint ucs4, short x, short y) {
            Ucs4 = ucs4;
            X = x;
            Y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XftCharFontSpec {
        internal IntPtr Font; //XftFont*
        public uint Ucs4; //FcChar32
        public short X;
        public short Y;

        public XftCharFontSpec(XftFont font, uint ucs4, short x, short y) {
            Font = font.Handle;
            Ucs4 = ucs4;
            X = x;
            Y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XftGlyphSpec {
        public uint Glyph; //FT_UInt
        public short X;
        public short Y;

        public XftGlyphSpec(uint glyph, short x, short y) {
            Glyph = glyph;
            X = x;
            Y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XftGlyphFontSpec {
        internal IntPtr Font; //XftFont*
        public uint Glyph; //FT_UInt
        public short X;
        public short Y;

        public XftGlyphFontSpec(XftFont font, uint glyph, short x, short y) {
            Font = font.Handle;
            Glyph = glyph;
            X = x;
            Y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FcObjectSet {
        public int nobject;
        public int sobject;
        internal IntPtr objects; //const char**
    }

    [StructLayout(LayoutKind.Sequential)]
    struct _FcValue {
        FcType type;
        /* TODO:どーすっかなｺﾚ
        union {
		const FcChar8* s;
        int i;
        FcBool b;
        double d;
        const FcMatrix* m;
        const FcCharSet* c;
        void* f;
        const FcLangSet* l;
        const FcRange* r;
        }unchecked;
        */
    }

}


