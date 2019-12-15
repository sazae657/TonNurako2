using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.X11 {

    public enum XStatus :int{
        True = 1,
        False = 0
    }

    public delegate int XErrorHandler(Display display, Event.XErrorEvent ev);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int XErrorHandlerInt(IntPtr display, IntPtr ev);

    public delegate int XIOErrorHandler(Display display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int XIOErrorHandlerInt(IntPtr display);

    public enum ErrorCode : byte {
        Success = TonNurako.X11.Constant.Success,
        BadRequest = TonNurako.X11.Constant.BadRequest,
        BadValue = TonNurako.X11.Constant.BadValue,
        BadWindow = TonNurako.X11.Constant.BadWindow,
        BadPixmap = TonNurako.X11.Constant.BadPixmap,
        BadAtom = TonNurako.X11.Constant.BadAtom,
        BadCursor = TonNurako.X11.Constant.BadCursor,
        BadFont = TonNurako.X11.Constant.BadFont,
        BadMatch = TonNurako.X11.Constant.BadMatch,
        BadDrawable = TonNurako.X11.Constant.BadDrawable,
        BadAccess = TonNurako.X11.Constant.BadAccess,
        BadAlloc = TonNurako.X11.Constant.BadAlloc,
        BadColor = TonNurako.X11.Constant.BadColor,
        BadGC = TonNurako.X11.Constant.BadGC,
        BadIDChoice = TonNurako.X11.Constant.BadIDChoice,
        BadName = TonNurako.X11.Constant.BadName,
        BadLength = TonNurako.X11.Constant.BadLength,
        BadImplementation = TonNurako.X11.Constant.BadImplementation,
        FirstExtensionError = TonNurako.X11.Constant.FirstExtensionError,
        LastExtensionError = TonNurako.X11.Constant.LastExtensionError,
    }
}
