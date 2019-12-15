//
// ﾄﾝﾇﾗｺ
//
// 色
//

using System;
using System.Runtime.InteropServices;
using TonNurako.Native;

namespace TonNurako.GC
{
    public class Color {
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint="TNK_IMP_Xt_XAllocColorD", CharSet=CharSet.Auto)]
            internal static extern int TNK_IMP_Xt_XAllocColorD(out TonNurako.X11.XColor color, IntPtr d, int cm, int r, int g, int b, int a);
        }

        public byte R { get; set;}
        public byte G { get; set;}
        public byte B { get; set;}

        public uint Pixel {
            get; set;
        }

        private X11.Display Display {
            get;
        }

        //private Widgets.IWidget Widget {
        //    get; set;
        //}

        public Color(Widgets.IWidget widget) {
            this.Display = widget.Handle.Display;
        }

        public Color(byte r, byte g, byte b) {
            R = r;
            G = g;
            B = b;
            Pixel =(uint)(((R & 0xff) << 16) | ((G & 0xff) << 8) | (B & 0xff));
        }

        public Color(TonNurako.Widgets.IWidget widget, string xcolor) {
            TonNurako.X11.XColor c = Native.ExtremeSports.XParseColor(widget, xcolor);
            SetWidgetColor((uint)c.Pixel);
            this.Display = widget.Handle.Display;
        }

        public static Color FromName(TonNurako.Widgets.IWidget widget, string name) {
            return new Color(widget, name);
        }

        public TonNurako.X11.XColor ToXColor(TonNurako.Widgets.IWidget widget) {
            int cm = 0;
            widget.ToolkitResources.GetValue(TonNurako.Motif.ResourceId.XmNcolormap, out cm);
            var color = new TonNurako.X11.XColor();
            NativeMethods.TNK_IMP_Xt_XAllocColorD(out color, Display.Handle, cm,  R, G, B, 255);
            return color;
            //return Native.ExtremeSports.XAllocColor((null == widget.Handle) ? this.Widget : widget, R, G, B, 255);
        }

        public TonNurako.X11.XColor ToXColor(X11.Display d, X11.Colormap cm) {
            var color = new TonNurako.X11.XColor();
            NativeMethods.TNK_IMP_Xt_XAllocColorD(out color, d.Handle, cm.Handle, R, G, B, 255);
            return color;
        }

        public override string ToString() {
            return $"#{R:x2}{G:x2}{B:x2}";
        }

        internal Color(uint wgtColor) {
            SetWidgetColor(wgtColor);
            Pixel = wgtColor;
        }

        internal void SetWidgetColor(uint wgtColor) {
                R = (byte)((wgtColor >> 16) & 0xff);
                G = (byte)((wgtColor >> 8) & 0xff);
                B = (byte)((wgtColor) & 0xff);
                Pixel = wgtColor;
        }
    }
}
