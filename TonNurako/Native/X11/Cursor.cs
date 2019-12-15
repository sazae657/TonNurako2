using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11 {

    public class Cursor : IX11Interop<int>, IDisposable {
        #region ﾈ－ﾁﾌﾞ
        internal static class NativeMethods {
            // Cursor: XCreateFontCursor Display*:display  unsigned int:shape
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCreateFontCursor_TNK", CharSet = CharSet.Auto)]
            internal static extern int XCreateFontCursor(IntPtr display, XCursorShape shape);

            // Cursor: XCreatePixmapCursor Display*:display  Pixmap:source  Pixmap:mask  XColor*:foreground_color  XColor*:background_color  unsigned int:x  unsigned int:y
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCreatePixmapCursor_TNK", CharSet = CharSet.Auto)]
            internal static extern int XCreatePixmapCursor(IntPtr display, IntPtr source, IntPtr mask, ref XColor foreground_color, ref XColor background_color, uint x, uint y);

            // Cursor: XCreateGlyphCursor Display*:display  Font:source_font  Font:mask_font  unsigned int:source_char  unsigned int:mask_char  XColor*:foreground_color  XColor*:background_color
            [DllImport(ExtremeSports.Lib, EntryPoint = "XCreateGlyphCursor_TNK", CharSet = CharSet.Auto)]
            internal static extern int XCreateGlyphCursor(IntPtr display, int source_font, int mask_font, uint source_char, uint mask_char, ref XColor foreground_color, ref XColor background_color);


            // Status: XRecolorCursor Display*:display  Cursor:cursor  XColor*:foreground_color  XColor*:background_color
            [DllImport(ExtremeSports.Lib, EntryPoint = "XRecolorCursor_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XRecolorCursor(IntPtr display, int cursor, ref XColor foreground_color, ref XColor background_color);

            // Status: XFreeCursor Display*:display  Cursor:cursor
            [DllImport(ExtremeSports.Lib, EntryPoint = "XFreeCursor_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XFreeCursor(IntPtr display, int cursor);

            // Status: XQueryBestCursor Display*:display  Drawable:d  unsigned int:width  unsigned int:height  unsigned int*:width_return  unsigned int*:height_return
            [DllImport(ExtremeSports.Lib, EntryPoint = "XQueryBestCursor_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XQueryBestCursor(IntPtr display, IntPtr d, uint width, uint height, out uint width_return, out uint height_return);

        }
        #endregion

        int handle = 0;
        public int Handle => handle;
        Display display;

        internal Cursor(Display display, int ptr) {
            handle = ptr;
            this.display = display;
        }


        public static Cursor CreateFontCursor(Display display, XCursorShape shape) =>
            new Cursor(display, NativeMethods.XCreateFontCursor(display.Handle, shape));

        public XStatus FreeCursor() {
            if (handle > 0) {
                var r = NativeMethods.XFreeCursor(display.Handle, handle);
                handle = 0;
                return r;
            }
            return XStatus.True;
        }

        public static Cursor CreatePixmapCursor(Display display, Pixmap source, Pixmap mask, Color foreground_color, Color background_color, uint x, uint y) =>
            new Cursor(display,
                NativeMethods.XCreatePixmapCursor(display.Handle, source.Handle, mask.Handle, ref foreground_color.Record, ref background_color.Record, x, y));


        public static int CreateGlyphCursor(Display display, int source_font, int mask_font, uint source_char, uint mask_char, Color foreground_color, Color background_color) =>
            NativeMethods.XCreateGlyphCursor(display.Handle, source_font, mask_font, source_char, mask_char, ref foreground_color.Record, ref background_color.Record);

        public static XStatus QueryBestCursor(Display display, IDrawable d, uint width, uint height, out uint width_return, out uint height_return) =>
            NativeMethods.XQueryBestCursor(display.Handle, d.Drawable, width, height, out width_return, out height_return);


        public XStatus RecolorCursor(Color foreground_color, Color background_color) =>
            NativeMethods.XRecolorCursor(display.Handle, handle, ref foreground_color.Record, ref background_color.Record);

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                FreeCursor();
                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(true);
        }
        #endregion
    }

    public enum XCursorShape :int {
        XC_X_cursor = TonNurako.X11.Constant.XC_X_cursor,
        XC_arrow = TonNurako.X11.Constant.XC_arrow,
        XC_based_arrow_down = TonNurako.X11.Constant.XC_based_arrow_down,
        XC_based_arrow_up = TonNurako.X11.Constant.XC_based_arrow_up,
        XC_boat = TonNurako.X11.Constant.XC_boat,
        XC_bogosity = TonNurako.X11.Constant.XC_bogosity,
        XC_bottom_left_corner = TonNurako.X11.Constant.XC_bottom_left_corner,
        XC_bottom_right_corner = TonNurako.X11.Constant.XC_bottom_right_corner,
        XC_bottom_side = TonNurako.X11.Constant.XC_bottom_side,
        XC_bottom_tee = TonNurako.X11.Constant.XC_bottom_tee,
        XC_box_spiral = TonNurako.X11.Constant.XC_box_spiral,
        XC_center_ptr = TonNurako.X11.Constant.XC_center_ptr,
        XC_circle = TonNurako.X11.Constant.XC_circle,
        XC_clock = TonNurako.X11.Constant.XC_clock,
        XC_coffee_mug = TonNurako.X11.Constant.XC_coffee_mug,
        XC_cross = TonNurako.X11.Constant.XC_cross,
        XC_cross_reverse = TonNurako.X11.Constant.XC_cross_reverse,
        XC_crosshair = TonNurako.X11.Constant.XC_crosshair,
        XC_diamond_cross = TonNurako.X11.Constant.XC_diamond_cross,
        XC_dot = TonNurako.X11.Constant.XC_dot,
        XC_dotbox = TonNurako.X11.Constant.XC_dotbox,
        XC_double_arrow = TonNurako.X11.Constant.XC_double_arrow,
        XC_draft_large = TonNurako.X11.Constant.XC_draft_large,
        XC_draft_small = TonNurako.X11.Constant.XC_draft_small,
        XC_draped_box = TonNurako.X11.Constant.XC_draped_box,
        XC_exchange = TonNurako.X11.Constant.XC_exchange,
        XC_fleur = TonNurako.X11.Constant.XC_fleur,
        XC_gobbler = TonNurako.X11.Constant.XC_gobbler,
        XC_gumby = TonNurako.X11.Constant.XC_gumby,
        XC_hand1 = TonNurako.X11.Constant.XC_hand1,
        XC_hand2 = TonNurako.X11.Constant.XC_hand2,
        XC_heart = TonNurako.X11.Constant.XC_heart,
        XC_icon = TonNurako.X11.Constant.XC_icon,
        XC_iron_cross = TonNurako.X11.Constant.XC_iron_cross,
        XC_left_ptr = TonNurako.X11.Constant.XC_left_ptr,
        XC_left_side = TonNurako.X11.Constant.XC_left_side,
        XC_left_tee = TonNurako.X11.Constant.XC_left_tee,
        XC_leftbutton = TonNurako.X11.Constant.XC_leftbutton,
        XC_ll_angle = TonNurako.X11.Constant.XC_ll_angle,
        XC_lr_angle = TonNurako.X11.Constant.XC_lr_angle,
        XC_man = TonNurako.X11.Constant.XC_man,
        XC_middlebutton = TonNurako.X11.Constant.XC_middlebutton,
        XC_mouse = TonNurako.X11.Constant.XC_mouse,
        XC_pencil = TonNurako.X11.Constant.XC_pencil,
        XC_pirate = TonNurako.X11.Constant.XC_pirate,
        XC_plus = TonNurako.X11.Constant.XC_plus,
        XC_question_arrow = TonNurako.X11.Constant.XC_question_arrow,
        XC_right_ptr = TonNurako.X11.Constant.XC_right_ptr,
        XC_right_side = TonNurako.X11.Constant.XC_right_side,
        XC_right_tee = TonNurako.X11.Constant.XC_right_tee,
        XC_rightbutton = TonNurako.X11.Constant.XC_rightbutton,
        XC_rtl_logo = TonNurako.X11.Constant.XC_rtl_logo,
        XC_sailboat = TonNurako.X11.Constant.XC_sailboat,
        XC_sb_down_arrow = TonNurako.X11.Constant.XC_sb_down_arrow,
        XC_sb_h_double_arrow = TonNurako.X11.Constant.XC_sb_h_double_arrow,
        XC_sb_left_arrow = TonNurako.X11.Constant.XC_sb_left_arrow,
        XC_sb_right_arrow = TonNurako.X11.Constant.XC_sb_right_arrow,
        XC_sb_up_arrow = TonNurako.X11.Constant.XC_sb_up_arrow,
        XC_sb_v_double_arrow = TonNurako.X11.Constant.XC_sb_v_double_arrow,
        XC_shuttle = TonNurako.X11.Constant.XC_shuttle,
        XC_sizing = TonNurako.X11.Constant.XC_sizing,
        XC_spider = TonNurako.X11.Constant.XC_spider,
        XC_spraycan = TonNurako.X11.Constant.XC_spraycan,
        XC_star = TonNurako.X11.Constant.XC_star,
        XC_target = TonNurako.X11.Constant.XC_target,
        XC_tcross = TonNurako.X11.Constant.XC_tcross,
        XC_top_left_arrow = TonNurako.X11.Constant.XC_top_left_arrow,
        XC_top_left_corner = TonNurako.X11.Constant.XC_top_left_corner,
        XC_top_right_corner = TonNurako.X11.Constant.XC_top_right_corner,
        XC_top_side = TonNurako.X11.Constant.XC_top_side,
        XC_top_tee = TonNurako.X11.Constant.XC_top_tee,
        XC_trek = TonNurako.X11.Constant.XC_trek,
        XC_ul_angle = TonNurako.X11.Constant.XC_ul_angle,
        XC_umbrella = TonNurako.X11.Constant.XC_umbrella,
        XC_ur_angle = TonNurako.X11.Constant.XC_ur_angle,
        XC_watch = TonNurako.X11.Constant.XC_watch,
        XC_xterm = TonNurako.X11.Constant.XC_xterm,
    }

}
