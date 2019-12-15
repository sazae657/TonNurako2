//
// ﾄﾝﾇﾗｺ
//
// Xlibﾗｯﾊﾟー
//
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TonNurako.Native;

namespace TonNurako.X11
{
    public enum XLocale : int {
        LC_CTYPE = TonNurako.X11.Constant.LC_CTYPE,
        LC_NUMERIC = TonNurako.X11.Constant.LC_NUMERIC,
        LC_TIME = TonNurako.X11.Constant.LC_TIME,
        LC_COLLATE = TonNurako.X11.Constant.LC_COLLATE,
        LC_MONETARY = TonNurako.X11.Constant.LC_MONETARY,
        LC_MESSAGES = TonNurako.X11.Constant.LC_MESSAGES,
        LC_ALL = TonNurako.X11.Constant.LC_ALL,
    }

    /// <summary>
    /// Xlibﾛーﾀﾞー
    /// </summary>
    public class Xi : Native.ExtremeSportsLoader {
        private static Xi Instance {
            get;
            set;
        }

        private Stack<IntPtr> XErrorHandlerStack = new Stack<IntPtr>();
        private Stack<IntPtr> XIOErrorHandlerStack = new Stack<IntPtr>();

        public static void Register(string libXtName) {
            if (null != Instance) {
                return;
            }
            Instance = new Xi(libXtName);
        }

        public static void Unregister() {
            if (null == Instance) {
                return;
            }
            System.Diagnostics.Debug.WriteLine("X11: unregister");
            Instance.Dispose();
            Instance = null;
        }

        private Xi(string lib) : base(lib) {

        }

        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "XStringToKeysym_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            public static extern int XStringToKeysym([MarshalAs(UnmanagedType.LPStr)] string xstring);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XKeysymToString_TNK", CharSet = CharSet.Auto)]
            public static extern IntPtr XKeysymToString(int keysym);


            [DllImport(ExtremeSports.Lib, EntryPoint = "XFree_TNK", CharSet = CharSet.Auto)]
            public static extern int XFree([In] IntPtr data);

            // Bool: XSupportsLocale []
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSupportsLocale_TNK", CharSet = CharSet.Auto)]
            internal static extern bool XSupportsLocale();

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetLocaleModifiers_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr XSetLocaleModifiers([MarshalAs(UnmanagedType.LPStr)] string modifier_list);

            // int*: XSetErrorHandler []
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetErrorHandler_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XSetErrorHandler([MarshalAs(UnmanagedType.FunctionPtr)] XErrorHandlerInt handler);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetErrorHandler_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XSetErrorHandler([In]IntPtr handler);


            // int*: XSetIOErrorHandler []
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetIOErrorHandler_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XSetIOErrorHandler([MarshalAs(UnmanagedType.FunctionPtr)] XIOErrorHandlerInt handler);

            // int*: XSetIOErrorHandler []
            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetIOErrorHandler_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr XSetIOErrorHandler([In]IntPtr handler);

            [DllImport(ExtremeSports.Lib, EntryPoint = "setlocale_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            internal static extern IntPtr setlocale_TNK(XLocale category, [MarshalAs(UnmanagedType.LPStr)] string locale);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFreeStringList_TNK", CharSet = CharSet.Auto)]
            internal static extern void XFreeStringList([In]IntPtr list);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDoubleToFixed_TNK", CharSet = CharSet.Auto)]
            public static extern int XDoubleToFixed(double f);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFixedToDouble_TNK", CharSet = CharSet.Auto)]
            public static extern double XFixedToDouble(int f);


            [DllImport(ExtremeSports.Lib, EntryPoint = "RootWindowOfScreen_TNK", CharSet = CharSet.Auto)]
            public static extern IntPtr RootWindowOfScreen(IntPtr screen);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XCreateGC_TNK", CharSet = CharSet.Auto)]
            public static extern IntPtr XCreateGC(IntPtr display, IntPtr d, GCMask valuemask, [In, Out]ref XGCValuesRec values);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XCreateGC_TNK", CharSet = CharSet.Auto)]
            public static extern IntPtr XCreateGC(IntPtr display, IntPtr d, GCMask valuemask, IntPtr values);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFreeGC_TNK", CharSet = CharSet.Auto)]
            public static extern int XFreeGC(IntPtr display, IntPtr gc);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetGCValues_TNK", CharSet = CharSet.Auto)]
            internal static extern XStatus XGetGCValues(IntPtr display, IntPtr gc, GCMask valuemask, out XGCValuesRec values_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XCreatePixmap_TNK", CharSet = CharSet.Auto)]
            public static extern IntPtr XCreatePixmap(IntPtr display, IntPtr d, uint width, uint height, uint depth);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFreePixmap_TNK", CharSet = CharSet.Auto)]
            public static extern int XFreePixmap(IntPtr display, IntPtr pixmap);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetForeground_TNK", CharSet = CharSet.Auto)]
            public static extern int XSetForeground(IntPtr display, IntPtr gc, ulong foreground);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetBackground_TNK", CharSet = CharSet.Auto)]
            public static extern int XSetBackground(IntPtr display, IntPtr gc, ulong background);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XCopyPlane_TNK", CharSet = CharSet.Auto)]
            public static extern int XCopyPlane(IntPtr display, IntPtr src, IntPtr dest, IntPtr gc, int src_x, int src_y, uint width, uint height, int dest_x, int dest_y, ulong plane);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XCopyArea_TNK", CharSet = CharSet.Auto)]
            public static extern int XCopyArea(IntPtr display, IntPtr src, IntPtr dest, IntPtr gc, int src_x, int src_y, uint width, uint height, int dest_x, int dest_y);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XClearWindow_TNK", CharSet = CharSet.Auto)]
            public static extern int XClearWindow(IntPtr display, IntPtr w);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XClearArea_TNK", CharSet = CharSet.Auto)]
            public static extern int XClearArea(IntPtr display, IntPtr w, int x, int y, uint width, uint height, [MarshalAs(UnmanagedType.U1)] bool exposures);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDrawPoint_TNK", CharSet = CharSet.Auto)]
            public static extern int XDrawPoint(IntPtr display, IntPtr d, IntPtr gc, int x, int y);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDrawPoints_TNK", CharSet = CharSet.Auto)]
            public static extern int XDrawPoints(IntPtr display, IntPtr d, IntPtr gc, TonNurako.X11.XPoint[] points, int npoints, int mode);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDrawLine_TNK", CharSet = CharSet.Auto)]
            public static extern int XDrawLine(IntPtr display, IntPtr d, IntPtr gc, int x1, int y1, int x2, int y2);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDrawLines_TNK", CharSet = CharSet.Auto)]
            public static extern int XDrawLines(IntPtr display, IntPtr d, IntPtr gc, TonNurako.X11.XPoint[] points, int npoints, int mode);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDrawSegments_TNK", CharSet = CharSet.Auto)]
            public static extern int XDrawSegments(IntPtr display, IntPtr d, IntPtr gc, TonNurako.X11.XSegment[] segments, int nsegments);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDrawRectangle_TNK", CharSet = CharSet.Auto)]
            public static extern int XDrawRectangle(IntPtr display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDrawRectangles_TNK", CharSet = CharSet.Auto)]
            public static extern int XDrawRectangles(IntPtr display, IntPtr d, IntPtr gc, TonNurako.X11.XRectangle[] rectangles, int nrectangles);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFillRectangle_TNK", CharSet = CharSet.Auto)]
            public static extern int XFillRectangle(IntPtr display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFillRectangles_TNK", CharSet = CharSet.Auto)]
            public static extern int XFillRectangles(IntPtr display, IntPtr d, IntPtr gc, TonNurako.X11.XRectangle[] rectangles, int nrectangles);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFillPolygon_TNK", CharSet = CharSet.Auto)]
            public static extern int XFillPolygon(IntPtr display, IntPtr d, IntPtr gc, TonNurako.X11.XPoint[] points, int npoints, int shape, int mode);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFillArc_TNK", CharSet = CharSet.Auto)]
            public static extern int XFillArc(IntPtr display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height, int angle1, int angle2);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFillArcs_TNK", CharSet = CharSet.Auto)]
            public static extern int XFillArcs(IntPtr display, IntPtr d, IntPtr gc, TonNurako.X11.XArc[] arcs, int narcs);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDrawArc_TNK", CharSet = CharSet.Auto)]
            public static extern int XDrawArc(IntPtr display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height, int angle1, int angle2);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XDrawArcs_TNK", CharSet = CharSet.Auto)]
            public static extern int XDrawArcs(IntPtr display, IntPtr d, IntPtr gc, TonNurako.X11.XArc[] arcs, int narcs);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetLineAttributes_TNK", CharSet = CharSet.Auto)]
            public static extern XStatus XSetLineAttributes(IntPtr display, IntPtr gc, uint line_width, int line_style, int cap_style, int join_style);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XSetDashes_TNK", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            public static extern XStatus XSetDashes(IntPtr display, IntPtr gc, int dash_offset, byte[] dash_list, int n);


            [DllImport(ExtremeSports.Lib, EntryPoint = "XGetGeometry_TNK", CharSet = CharSet.Auto)]
            public static extern int XGetGeometry(IntPtr display, IntPtr d, out IntPtr root_return, out IntPtr x_return,
                out IntPtr y_return, out IntPtr width_return, out IntPtr height_return, out IntPtr border_width_return, out IntPtr depth_return);

            //[DllImport(ExtremeSports.Lib, EntryPoint="XGetWindowAttributes_TNK", CharSet=CharSet.Auto)]
            //public static extern int XGetWindowAttributes(IntPtr display, IntPtr w, out XWindowAttributes window_attributes_return);

            /*[DllImport(ExtremeSports.Lib, EntryPoint = "XStringListToTextProperty_TNK", CharSet = CharSet.Auto)]
            internal static extern int XStringListToTextProperty(IntPtr list, int count, out IntPtr text_prop_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XTextPropertyToStringList_TNK", CharSet = CharSet.Auto)]
            internal static extern int XTextPropertyToStringList(ref XTextProperty text_prop, out IntPtr list_return, out IntPtr count_return);

            [DllImport(ExtremeSports.Lib, EntryPoint = "XFreeStringList_TNK", CharSet = CharSet.Auto)]
            internal static extern void XFreeStringList([In]IntPtr list);

            */
       }

        public static void SetErrorHandler(XErrorHandler handler) {
            if (null == handler) {
                if (0 == Instance.XErrorHandlerStack.Count) {
                    NativeMethods.XSetErrorHandler(IntPtr.Zero);
                    return;
                }
                NativeMethods.XSetErrorHandler(Instance.XErrorHandlerStack.Pop());
                return;
            }
            var h = NativeMethods.XSetErrorHandler((dpy, code) => {
                return handler(new Display(dpy, false), Marshal.PtrToStructure<Event.XErrorEvent>(code));
            });
            Instance.XErrorHandlerStack.Push(h);
        }

        public static void SetIOErrorHandler(XIOErrorHandler handler) {
            if (null == handler) {
                if (0 == Instance.XIOErrorHandlerStack.Count) {
                    NativeMethods.XSetIOErrorHandler(IntPtr.Zero);
                    return;
                }
                NativeMethods.XSetIOErrorHandler(Instance.XIOErrorHandlerStack.Pop());
                return;
            }
            var h = NativeMethods.XSetIOErrorHandler((dpy) => {
                return handler(new Display(dpy, false));
            });
            Instance.XIOErrorHandlerStack.Push(h);
        }

        public static int Free(IntPtr data) =>
            NativeMethods.XFree(data);


        public static string SetLocale(XLocale category, string locale) {
            var r = NativeMethods.setlocale_TNK(category, locale);
            if (IntPtr.Zero == r) {
                return null;
            }
            return Marshal.PtrToStringAnsi(r);
        }

        public static string SetLocaleModifiers(string modifier_list) {
            var r = NativeMethods.XSetLocaleModifiers(modifier_list);
            if (IntPtr.Zero == r) {
                return null;
            }
            return Marshal.PtrToStringAnsi(r);
        }

        public static bool SupportsLocale() => NativeMethods.XSupportsLocale();


        public static int StringToKeysym(string _String) =>
            NativeMethods.XStringToKeysym(_String);


        public static string KeysymToString(int keysym) =>
            Marshal.PtrToStringAnsi(NativeMethods.XKeysymToString(keysym));


        public static void FreeStringList(IntPtr list) => NativeMethods.XFreeStringList(list);


        // TODO: 置き場に困る
        public static int DoubleToFixed(double f) => NativeMethods.XDoubleToFixed(f);
        public static double FixedToDouble(int f) => NativeMethods.XFixedToDouble(f);



        /*public static int XStringListToTextProperty(IntPtr list, int count, out IntPtr text_prop_return)
            => NativeMethods.XStringListToTextProperty(list, count, out text_prop_return);


        public static int XTextPropertyToStringList(XTextProperty text_prop, out IntPtr list_return, out IntPtr count_return)
            => NativeMethods.XTextPropertyToStringList(ref text_prop, out list_return, out count_return);


        public static void XFreeStringList(IntPtr list) => NativeMethods.XFreeStringList(list);*/

        #region 描画関連
        public static IntPtr XCreateGC(Display display, IntPtr d, GCMask valuemask, XGCValues values) {
            var v = new XGCValuesRec();
            var r = NativeMethods.XCreateGC(display.Handle,d,valuemask,ref v);
            values.Record = v;
            return r;
        }

        public static IntPtr XCreateGC(Display display, IntPtr d) {
            return NativeMethods.XCreateGC(display.Handle, d, 0, IntPtr.Zero);
        }

        public static int XFreeGC(Display display, IntPtr gc) {
            return NativeMethods.XFreeGC(display.Handle, gc);
        }

        public static XStatus XGetGCValues(Display display, IntPtr gc, GCMask valuemask, XGCValues values_return) {
            var v = new XGCValuesRec();
            var r = NativeMethods.XGetGCValues(display.Handle, gc, valuemask, out v);
            values_return.Record = v;
            return r;
        }

        public static IntPtr XCreatePixmap(Display display, IntPtr d, uint width, uint height, uint depth) {
            return NativeMethods.XCreatePixmap(display.Handle, d,width,height,depth);
        }

        public static int XFreePixmap(Display display, IntPtr pixmap) {
            return NativeMethods.XFreePixmap(display.Handle, pixmap);
        }

        public static int XSetForeground(Display display, IntPtr gc, ulong foreground) {
            return NativeMethods.XSetForeground(display.Handle, gc,foreground);
        }

        public static int XSetBackground(Display display, IntPtr gc, ulong background) {
            return NativeMethods.XSetBackground(display.Handle, gc,background);
        }

        public static int XCopyPlane(Display display, IntPtr src, IntPtr dest, IntPtr gc, int src_x, int src_y, uint width, uint height, int dest_x, int dest_y, ulong plane) {
            return NativeMethods.XCopyPlane(display.Handle, src,dest,gc,src_x,src_y,width,height,dest_x,dest_y,plane);
        }

        public static int XCopyArea(Display display, IntPtr src, IntPtr dest, IntPtr gc, int src_x, int src_y, uint width, uint height, int dest_x, int dest_y) {
            return NativeMethods.XCopyArea(display.Handle, src,dest,gc,src_x,src_y,width,height,dest_x,dest_y);
        }

        public static int XClearWindow(Display display, IntPtr w) {
            return NativeMethods.XClearWindow(display.Handle, w);
        }

        public static int XClearArea(Display display, IntPtr w, int x, int y, uint width, uint height, [MarshalAs(UnmanagedType.U1)] bool exposures) {
            return NativeMethods.XClearArea(display.Handle, w,x,y,width,height,exposures);
        }

        public static int XDrawPoint(Display display, IntPtr d, IntPtr gc, int x, int y) {
            return NativeMethods.XDrawPoint(display.Handle, d,gc,x,y);
        }

        public static int XDrawPoints(Display display, IntPtr d, IntPtr gc, TonNurako.X11.XPoint [] points, int npoints, int mode) {
            return NativeMethods.XDrawPoints(display.Handle, d,gc,points,npoints,mode);
        }

        public static int XDrawLine(Display display, IntPtr d, IntPtr gc, int x1, int y1, int x2, int y2) {
            return NativeMethods.XDrawLine(display.Handle, d,gc,x1,y1,x2,y2);
        }

        public static int XDrawLines(Display display, IntPtr d, IntPtr gc, TonNurako.X11.XPoint [] points, int npoints, int mode) {
            return NativeMethods.XDrawLines(display.Handle, d,gc,points,npoints,mode);
        }


        public static int XDrawSegments(Display display, IntPtr d, IntPtr gc, TonNurako.X11.XSegment [] segments, int nsegments) {
            return NativeMethods.XDrawSegments(display.Handle, d,gc,segments,nsegments);
        }


        public static int XDrawRectangle(Display display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height) {
            return NativeMethods.XDrawRectangle(display.Handle, d,gc,x,y,width,height);
        }


        public static int XDrawRectangles(Display display, IntPtr d, IntPtr gc, TonNurako.X11.XRectangle [] rectangles, int nrectangles) {
            return NativeMethods.XDrawRectangles(display.Handle, d,gc,rectangles,nrectangles);
        }


        public static int XFillRectangle(Display display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height) {
            return NativeMethods.XFillRectangle(display.Handle, d,gc,x,y,width,height);
        }


        public static int XFillRectangles(Display display, IntPtr d, IntPtr gc, TonNurako.X11.XRectangle [] rectangles, int nrectangles) {
            return NativeMethods.XFillRectangles(display.Handle, d,gc,rectangles,nrectangles);
        }


        public static int XFillPolygon(Display display, IntPtr d, IntPtr gc, TonNurako.X11.XPoint [] points, int npoints, int shape, int mode) {
            return NativeMethods.XFillPolygon(display.Handle, d,gc,points,npoints,shape,mode);
        }


        public static int XFillArc(Display display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height, int angle1, int angle2) {
            return NativeMethods.XFillArc(display.Handle, d,gc,x,y,width,height,angle1,angle2);
        }


        public static int XFillArcs(Display display, IntPtr d, IntPtr gc, TonNurako.X11.XArc [] arcs, int narcs) {
            return NativeMethods.XFillArcs(display.Handle, d,gc,arcs,narcs);
        }


        public static int XDrawArc(Display display, IntPtr d, IntPtr gc, int x, int y, uint width, uint height, int angle1, int angle2) {
            return NativeMethods.XDrawArc(display.Handle, d,gc,x,y,width,height,angle1,angle2);
        }


        public static int XDrawArcs(Display display, IntPtr d, IntPtr gc, TonNurako.X11.XArc [] arcs, int narcs) {
            return NativeMethods.XDrawArcs(display.Handle, d,gc,arcs,narcs);
        }


        public static XStatus XSetLineAttributes(Display display, IntPtr gc, uint line_width, int line_style, int cap_style, int join_style) {
            return NativeMethods.XSetLineAttributes(display.Handle, gc,line_width,line_style,cap_style,join_style);
        }


        public static XStatus XSetDashes(Display display, IntPtr gc, int dash_offset, byte[] dash_list) {
            return NativeMethods.XSetDashes(display.Handle, gc, dash_offset, dash_list, dash_list.Length);
        }

       /* たぶんやらない
        public static int XGetGeometry(IntPtr display, IntPtr gc) {
            IntPtr root_return;
            IntPtr x_return;
            IntPtr y_return;
            IntPtr width_return;
            IntPtr height_return;
            IntPtr border_width_return;
            IntPtr depth_return;
            int r = NativeMethods.XGetGeometry(
                display, gc, out root_return,out x_return,out y_return, out width_return,out height_return,out border_width_return,out depth_return);
            string msg = $"XGetGeometry<{r}> => \n";
            if (IntPtr.Zero != root_return) msg += $"    root_return = {(root_return)} \n";
            if (IntPtr.Zero != x_return) msg += $"    x_return = {(x_return)} \n" ;
            if (IntPtr.Zero != y_return) msg += $"    y_return = {(y_return)} \n";
            if (IntPtr.Zero != width_return) msg += $"    width_return = {(width_return)} \n";
            if (IntPtr.Zero != height_return) msg += $"    height_return = {(height_return)} \n";
            if (IntPtr.Zero != border_width_return) msg += $"    border_width_return = {(border_width_return)}\n";
            if (IntPtr.Zero != depth_return) msg += $"    depth_return = {(depth_return)} \n";

            return r;
        }
        */


        //public static int XGetWindowAttributes(IntPtr display, IntPtr w, out XWindowAttributes window_attributes_return) {
        //    return NativeMethods.XGetWindowAttributes(display,w,window_attributes_return);
        //}

        #endregion
    }
}
