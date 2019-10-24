#include "TonNurako.h"

//
// XModifierKeymapｱｸｾｻー
//
TNK_EXPORT int TNK_GetXModifierKeymap_MaxKeypermod(const XModifierKeymap* p) {
    return p->max_keypermod;
}

TNK_EXPORT void TNK_SetXModifierKeymap_MaxKeypermod(XModifierKeymap* p, const KeyCode val) {
    p->max_keypermod = val;
}

TNK_EXPORT KeyCode TNK_GetXModifierKeymap_Modifiermap(const XModifierKeymap* p, const int index) {
    return p->modifiermap[index];
}

TNK_EXPORT void TNK_SetXModifierKeymap_Modifiermap(XModifierKeymap* p, const int index, const KeyCode val) {
    p->modifiermap[index] = val;
}

TNK_EXPORT void TNK_AssembleEventArg(XAnyEvent* e, int type, Display *display, Window window) {
    e->type = type;
    e->display = display;
    e->window = window;
}



TNK_EXPORT Status XStringListToTextProperty_TNK(char* *list, int count, XTextProperty* text_prop_return) {
    return XStringListToTextProperty(list,count,text_prop_return);
}

TNK_EXPORT Status XTextPropertyToStringList_TNK(XTextProperty* text_prop, char ***list_return, int* count_return) {
    return XTextPropertyToStringList(text_prop,list_return,count_return);
}


TNK_EXPORT int ConnectionNumber_TNK(Display* dpy) {
    return ConnectionNumber(dpy);
}

TNK_EXPORT int DefaultScreen_TNK(Display* dpy) {
    return DefaultScreen(dpy);
}

TNK_EXPORT int QLength_TNK(Display* dpy) {
    return QLength(dpy);
}

TNK_EXPORT int ScreenCount_TNK(Display* dpy) {
    return ScreenCount(dpy);
}

TNK_EXPORT char* ServerVendor_TNK(Display* dpy) {
    return ServerVendor(dpy);
}

TNK_EXPORT int ProtocolVersion_TNK(Display* dpy) {
    return ProtocolVersion(dpy);
}

TNK_EXPORT int ProtocolRevision_TNK(Display* dpy) {
    return ProtocolRevision(dpy);
}

TNK_EXPORT int VendorRelease_TNK(Display* dpy) {
    return VendorRelease(dpy);
}

TNK_EXPORT char* DisplayString_TNK(Display* dpy) {
    return DisplayString(dpy);
}

TNK_EXPORT int BitmapUnit_TNK(Display* dpy) {
    return BitmapUnit(dpy);
}

TNK_EXPORT int BitmapBitOrder_TNK(Display* dpy) {
    return BitmapBitOrder(dpy);
}

TNK_EXPORT int BitmapPad_TNK(Display* dpy) {
    return BitmapPad(dpy);
}

TNK_EXPORT int ImageByteOrder_TNK(Display* dpy) {
    return ImageByteOrder(dpy);
}

TNK_EXPORT int NextRequest_TNK(Display* dpy) {
    return NextRequest(dpy);
}

TNK_EXPORT u_long LastKnownRequestProcessed_TNK(Display* dpy) {
    return LastKnownRequestProcessed(dpy);
}

TNK_EXPORT Window RootWindow_TNK(Display* dpy, int scr) {
    return RootWindow(dpy,scr);
}

TNK_EXPORT Window DefaultRootWindow_TNK(Display* dpy) {
    return DefaultRootWindow(dpy);
}

TNK_EXPORT Visual* DefaultVisual_TNK(Display* dpy, int scr) {
    return DefaultVisual(dpy,scr);
}

TNK_EXPORT GC DefaultGC_TNK(Display* dpy, int scr) {
    return DefaultGC(dpy,scr);
}

TNK_EXPORT u_long BlackPixel_TNK(Display* dpy, int scr) {
    return BlackPixel(dpy,scr);
}

TNK_EXPORT u_long WhitePixel_TNK(Display* dpy, int scr) {
    return WhitePixel(dpy,scr);
}

TNK_EXPORT int DisplayWidth_TNK(Display* dpy, int scr) {
    return DisplayWidth(dpy,scr);
}

TNK_EXPORT int DisplayHeight_TNK(Display* dpy, int scr) {
    return DisplayHeight(dpy,scr);
}

TNK_EXPORT int DisplayWidthMM_TNK(Display* dpy, int scr) {
    return DisplayWidthMM(dpy,scr);
}

TNK_EXPORT int DisplayHeightMM_TNK(Display* dpy, int scr) {
    return DisplayHeightMM(dpy,scr);
}

TNK_EXPORT int DisplayPlanes_TNK(Display* dpy, int scr) {
    return DisplayPlanes(dpy,scr);
}

TNK_EXPORT int DisplayCells_TNK(Display* dpy, int scr) {
    return DisplayCells(dpy,scr);
}

TNK_EXPORT int DefaultDepth_TNK(Display* dpy, int scr) {
    return DefaultDepth(dpy,scr);
}

TNK_EXPORT int DefaultColormap_TNK(Display* dpy, int scr) {
    return DefaultColormap(dpy,scr);
}

TNK_EXPORT Screen* ScreenOfDisplay_TNK(Display* dpy, int scr) {
    return ScreenOfDisplay(dpy,scr);
}

TNK_EXPORT Screen* DefaultScreenOfDisplay_TNK(Display* dpy) {
    return DefaultScreenOfDisplay(dpy);
}

TNK_EXPORT Display* DisplayOfScreen_TNK(Screen* s) {
    return DisplayOfScreen(s);
}

TNK_EXPORT Window RootWindowOfScreen_TNK(Screen* s) {
    return RootWindowOfScreen(s);
}

TNK_EXPORT u_long BlackPixelOfScreen_TNK(Screen* s) {
    return BlackPixelOfScreen(s);
}

TNK_EXPORT u_long WhitePixelOfScreen_TNK(Screen* s) {
    return WhitePixelOfScreen(s);
}

TNK_EXPORT Colormap DefaultColormapOfScreen_TNK(Screen* s) {
    return DefaultColormapOfScreen(s);
}

TNK_EXPORT int DefaultDepthOfScreen_TNK(Screen* s) {
    return DefaultDepthOfScreen(s);
}

TNK_EXPORT GC DefaultGCOfScreen_TNK(Screen* s) {
    return DefaultGCOfScreen(s);
}

TNK_EXPORT Visual* DefaultVisualOfScreen_TNK(Screen* s) {
    return DefaultVisualOfScreen(s);
}

TNK_EXPORT int WidthOfScreen_TNK(Screen* s) {
    return WidthOfScreen(s);
}

TNK_EXPORT int HeightOfScreen_TNK(Screen* s) {
    return HeightOfScreen(s);
}

TNK_EXPORT int WidthMMOfScreen_TNK(Screen* s) {
    return WidthMMOfScreen(s);
}

TNK_EXPORT int HeightMMOfScreen_TNK(Screen* s) {
    return HeightMMOfScreen(s);
}

TNK_EXPORT int PlanesOfScreen_TNK(Screen* s) {
    return PlanesOfScreen(s);
}

TNK_EXPORT int CellsOfScreen_TNK(Screen* s) {
    return CellsOfScreen(s);
}

TNK_EXPORT int MinCmapsOfScreen_TNK(Screen* s) {
    return MinCmapsOfScreen(s);
}

TNK_EXPORT int MaxCmapsOfScreen_TNK(Screen* s) {
    return MaxCmapsOfScreen(s);
}

TNK_EXPORT Bool DoesSaveUnders_TNK(Screen* s) {
    return DoesSaveUnders(s);
}

TNK_EXPORT int DoesBackingStore_TNK(Screen* s) {
    return DoesBackingStore(s);
}

TNK_EXPORT long EventMaskOfScreen_TNK(Screen* s) {
    return EventMaskOfScreen(s);
}


/*
TNK_EXPORT Colormap DefaultColormap_TNK(Display* display, int screen_num) {
    return DefaultColormap(display,screen_num);
}

TNK_EXPORT char* ServerVendor_TNK(Display* display) {
    return ServerVendor(display);
}

TNK_EXPORT int DisplayWidth_TNK(Display* display, int screen_number) {
    return DisplayWidth(display,screen_number);
}

TNK_EXPORT int DisplayHeight_TNK(Display* display, int screen_number) {
    return DisplayHeight(display,screen_number);
}

TNK_EXPORT int DisplayWidthMM_TNK(Display* display, int screen_number) {
    return DisplayWidthMM(display,screen_number);
}

TNK_EXPORT int DisplayHeightMM_TNK(Display* display, int screen_number) {
    return DisplayHeightMM(display,screen_number);
}

TNK_EXPORT int DefaultScreen_TNK(Display* display) {
    return DefaultScreen(display);
}

TNK_EXPORT int ProtocolVersion_TNK(Display* display) {
    return ProtocolVersion(display);
}

TNK_EXPORT int ProtocolRevision_TNK(Display* display) {
    return ProtocolRevision(display);
}

TNK_EXPORT Window RootWindowOfScreen_TNK(Screen *screen) {
    return RootWindowOfScreen(screen);
}
TNK_EXPORT Window DefaultRootWindow_TNK(Display* display) {
    return DefaultRootWindow(display);
}
*/

