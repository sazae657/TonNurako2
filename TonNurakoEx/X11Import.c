#include "TonNurako.h"
//

TNK_EXPORT void XwcDrawString_TNK(Display* display, Drawable d, XFontSet font_set, GC gc, int x, int y, wchar_t* string, int num_wchars) {
    XwcDrawString(display,d,font_set,gc,x,y,string,num_wchars);
}

TNK_EXPORT void XwcDrawImageString_TNK(Display* display, Drawable d, XFontSet font_set, GC gc, int x, int y, wchar_t* string, int num_wchars) {
    XwcDrawImageString(display,d,font_set,gc,x,y,string,num_wchars);
}

TNK_EXPORT void XmbDrawString_TNK(Display* display, Drawable d, XFontSet font_set, GC gc, int x, int y, char* string, int num_bytes) {
    XmbDrawString(display,d,font_set,gc,x,y,string,num_bytes);
}

TNK_EXPORT XVisualInfo* XGetVisualInfo_TNK(Display* display, long vinfo_mask, XVisualInfo* vinfo_template, int* nitems_return) {
    return XGetVisualInfo(display,vinfo_mask,vinfo_template,nitems_return);
}

TNK_EXPORT Status XMatchVisualInfo_TNK(Display* display, int screen, int depth, int class, XVisualInfo* vinfo_return) {
    return XMatchVisualInfo(display,screen,depth,class,vinfo_return);
}

TNK_EXPORT VisualID XVisualIDFromVisual_TNK(Visual* visual) {
    return XVisualIDFromVisual(visual);
}

TNK_EXPORT int XFree_TNK(void *data) {
    return XFree(data);
}

TNK_EXPORT XClassHint* XAllocClassHint_TNK() {
    return XAllocClassHint();
}

TNK_EXPORT  XWMHints *XAllocWMHints_TNK() {
    return XAllocWMHints();
}

TNK_EXPORT Bool XTranslateCoordinates_TNK(Display* display, Window src_w, Window dest_w, int src_x, int src_y, int* dest_x_return, int* dest_y_return, Window* child_return) {
    return XTranslateCoordinates(display,src_w,dest_w,src_x,src_y,dest_x_return,dest_y_return,child_return);
}

TNK_EXPORT Status XSetClassHint_TNK(Display* display, Window w, XClassHint* class_hints) {
    return XSetClassHint(display,w,class_hints);
}

TNK_EXPORT Status XGetClassHint_TNK(Display* display, Window w, XClassHint* class_hints_return) {
    return XGetClassHint(display,w,class_hints_return);
}

TNK_EXPORT int XAllowEvents_TNK(Display* display, int event_mode, Time time) {
    return XAllowEvents(display,event_mode,time);
}

TNK_EXPORT int XGrabKey_TNK(Display* display, int keycode, unsigned int modifiers, Window grab_window, Bool owner_events, int pointer_mode, int keyboard_mode) {
    return XGrabKey(display,keycode,modifiers,grab_window,owner_events,pointer_mode,keyboard_mode);
}

TNK_EXPORT int XUngrabKey_TNK(Display* display, int keycode, unsigned int modifiers, Window grab_window) {
    return XUngrabKey(display,keycode,modifiers,grab_window);
}



TNK_EXPORT int XUnmapWindow_TNK(Display* display, Window w) {
    return XUnmapWindow(display,w);
}

TNK_EXPORT int XUnmapSubwindows_TNK(Display* display, Window w) {
    return XUnmapSubwindows(display,w);
}


TNK_EXPORT Bool XQueryPointer_TNK(Display* display, Window w, Window* root_return, Window* child_return, int* root_x_return, int* root_y_return, int* win_x_return, int* win_y_return, unsigned int* mask_return) {
    return XQueryPointer(display,w,root_return,child_return,root_x_return,root_y_return,win_x_return,win_y_return,mask_return);
}

TNK_EXPORT int XGrabButton_TNK(Display* display, unsigned int button, unsigned int modifiers, Window grab_window, Bool owner_events, unsigned int event_mask, int pointer_mode, int keyboard_mode, Window confine_to, Cursor cursor) {
    return XGrabButton(display,button,modifiers,grab_window,owner_events,event_mask,pointer_mode,keyboard_mode,confine_to,cursor);
}

TNK_EXPORT int XUngrabButton_TNK(Display* display, unsigned int button, unsigned int modifiers, Window grab_window) {
    return XUngrabButton(display,button,modifiers,grab_window);
}

TNK_EXPORT int XGrabServer_TNK(Display* display) {
    return XGrabServer(display);
}

TNK_EXPORT int XUngrabServer_TNK(Display* display) {
    return XUngrabServer(display);
}

TNK_EXPORT int XWarpPointer_TNK(Display* display, Window src_w, Window dest_w, int src_x, int src_y, unsigned int src_width, unsigned int src_height, int dest_x, int dest_y) {
    return XWarpPointer(display,src_w,dest_w,src_x,src_y,src_width,src_height,dest_x,dest_y);
}

TNK_EXPORT Status XSendEvent_TNK(Display* display, Window w, Bool propagate, long event_mask, XEvent* event_send) {
    return XSendEvent(display,w,propagate,event_mask,event_send);
}

TNK_EXPORT u_long XDisplayMotionBufferSize_TNK(Display* display) {
    return XDisplayMotionBufferSize(display);
}

TNK_EXPORT XTimeCoord* XGetMotionEvents_TNK(Display* display, Window w, Time start, Time stop, int* nevents_return) {
    return XGetMotionEvents(display,w,start,stop,nevents_return);
}


TNK_EXPORT Cursor XCreateFontCursor_TNK(Display* display, unsigned int shape) {
    return XCreateFontCursor(display,shape);
}
TNK_EXPORT Cursor XCreatePixmapCursor_TNK(Display* display, Pixmap source, Pixmap mask, XColor* foreground_color, XColor* background_color, unsigned int x, unsigned int y) {
    return XCreatePixmapCursor(display,source,mask,foreground_color,background_color,x,y);
}
TNK_EXPORT Cursor XCreateGlyphCursor_TNK(Display* display, Font source_font, Font mask_font, unsigned int source_char, unsigned int mask_char, XColor* foreground_color, XColor* background_color) {
    return XCreateGlyphCursor(display,source_font,mask_font,source_char,mask_char,foreground_color,background_color);
}
TNK_EXPORT Status XDefineCursor_TNK(Display* display, Window w, Cursor cursor) {
    return XDefineCursor(display,w,cursor);
}
TNK_EXPORT Status XUndefineCursor_TNK(Display* display, Window w) {
    return XUndefineCursor(display,w);
}
TNK_EXPORT Status XRecolorCursor_TNK(Display* display, Cursor cursor, XColor* foreground_color, XColor* background_color) {
    return XRecolorCursor(display,cursor,foreground_color,background_color);
}
TNK_EXPORT Status XFreeCursor_TNK(Display* display, Cursor cursor) {
    return XFreeCursor(display,cursor);
}
TNK_EXPORT Status XQueryBestCursor_TNK(Display* display, Drawable d, unsigned int width, unsigned int height, unsigned int* width_return, unsigned int* height_return) {
    return XQueryBestCursor(display,d,width,height,width_return,height_return);
}


TNK_EXPORT int XChangeKeyboardMapping_TNK(Display* display, int first_keycode, int keysyms_per_keycode, KeySym* keysyms, int num_codes) {
    return XChangeKeyboardMapping(display,first_keycode,keysyms_per_keycode,keysyms,num_codes);
}

TNK_EXPORT KeySym* XGetKeyboardMapping_TNK(Display* display, KeyCode first_keycode, int keycode_count, int* keysyms_per_keycode_return) {
    return XGetKeyboardMapping(display,first_keycode,keycode_count,keysyms_per_keycode_return);
}

TNK_EXPORT int XDisplayKeycodes_TNK(Display* display, int* min_keycodes_return, int* max_keycodes_return) {
    return XDisplayKeycodes(display,min_keycodes_return,max_keycodes_return);
}

TNK_EXPORT int XSetModifierMapping_TNK(Display* display, XModifierKeymap* modmap) {
    return XSetModifierMapping(display,modmap);
}

TNK_EXPORT XModifierKeymap* XGetModifierMapping_TNK(Display* display) {
    return XGetModifierMapping(display);
}

TNK_EXPORT XModifierKeymap* XNewModifiermap_TNK(int max_keys_per_mod) {
    return XNewModifiermap(max_keys_per_mod);
}

TNK_EXPORT XModifierKeymap* XInsertModifiermapEntry_TNK(XModifierKeymap* modmap, KeyCode keycode_entry, int modifier) {
    return XInsertModifiermapEntry(modmap,keycode_entry,modifier);
}

TNK_EXPORT XModifierKeymap* XDeleteModifiermapEntry_TNK(XModifierKeymap* modmap, KeyCode keycode_entry, int modifier) {
    return XDeleteModifiermapEntry(modmap,keycode_entry,modifier);
}

TNK_EXPORT int XFreeModifiermap_TNK(XModifierKeymap* modmap) {
    return XFreeModifiermap(modmap);
}




/*deprecatedだそうだ
TNK_EXPORT KeySym XKeycodeToKeysym_TNK(Display* display, KeyCode keycode, int index) {
    return XKeycodeToKeysym(display,keycode,index);
}
*/
TNK_EXPORT KeyCode XKeysymToKeycode_TNK(Display* display, KeySym keysym) {
    return XKeysymToKeycode(display,keysym);
}

TNK_EXPORT void XConvertCase_TNK(KeySym keysym, KeySym* lower_return, KeySym* upper_return) {
    XConvertCase(keysym,lower_return,upper_return);
}

TNK_EXPORT XSizeHints* XAllocSizeHints_TNK() {
    return XAllocSizeHints();
}

TNK_EXPORT void XSetWMNormalHints_TNK(Display* display, Window w, XSizeHints* hints) {
    XSetWMNormalHints(display,w,hints);
}

TNK_EXPORT Status XGetWMNormalHints_TNK(Display* display, Window w, XSizeHints* hints_return, long* supplied_return) {
    return XGetWMNormalHints(display,w,hints_return,supplied_return);
}

TNK_EXPORT void XSetWMSizeHints_TNK(Display* display, Window w, XSizeHints* hints, Atom property) {
    XSetWMSizeHints(display,w,hints,property);
}

TNK_EXPORT Status XGetWMSizeHints_TNK(Display* display, Window w, XSizeHints* hints_return, long* supplied_return, Atom property) {
    return XGetWMSizeHints(display,w,hints_return,supplied_return,property);
}


//

TNK_EXPORT Status XAllocColor_TNK(Display* display, Colormap colormap, XColor* screen_in_out) {
    return XAllocColor(display,colormap,screen_in_out);
}

TNK_EXPORT Status XAllocNamedColor_TNK(Display* display, Colormap colormap, char* color_name, XColor* screen_def_return, XColor* exact_def_return) {
    return XAllocNamedColor(display,colormap,color_name,screen_def_return,exact_def_return);
}

TNK_EXPORT Status XAllocColorCells_TNK(Display* display, Colormap colormap, Bool contig, unsigned long plane_masks_return[], unsigned int nplanes, unsigned long pixels_return[], unsigned int npixels) {
    return XAllocColorCells(display,colormap,contig,plane_masks_return,nplanes,pixels_return,npixels);
}

TNK_EXPORT Status XAllocColorPlanes_TNK(Display* display, Colormap colormap, Bool contig, unsigned long pixels_return[], int ncolors, int nreds, int ngreens, int nblues, unsigned long* rmask_return, unsigned long* gmask_return, unsigned long* bmask_return) {
    return XAllocColorPlanes(display,colormap,contig,pixels_return,ncolors,nreds,ngreens,nblues,rmask_return,gmask_return,bmask_return);
}

TNK_EXPORT int XFreeColors_TNK(Display* display, Colormap colormap, unsigned long pixels[], int npixels, unsigned long planes) {
    return XFreeColors(display,colormap,pixels,npixels,planes);
}


TNK_EXPORT int XDestroyWindow_TNK(Display* display, Window w) {
    return XDestroyWindow(display,w);
}

TNK_EXPORT int XDestroySubwindows_TNK(Display* display, Window w) {
    return XDestroySubwindows(display,w);
}

TNK_EXPORT int XSetCloseDownMode_TNK(Display* display, int close_mode) {
    return XSetCloseDownMode(display,close_mode);
}

TNK_EXPORT int XKillClient_TNK(Display* display, XID resource) {
    return XKillClient(display,resource);
}

TNK_EXPORT Window XCreateSimpleWindow_TNK(Display* display, Window parent, int x, int y, unsigned int width, unsigned int height, unsigned int border_width, unsigned long border, unsigned long background) {
    return XCreateSimpleWindow(display,parent,x,y,width,height,border_width,border,background);
}

TNK_EXPORT Window XCreateWindow_TNK(Display* display, Window parent, int x, int y, unsigned int width, unsigned int height, unsigned int border_width, int depth, unsigned int class, Visual* visual, unsigned long valuemask, XSetWindowAttributes* attributes) {
    return XCreateWindow(display,parent,x,y,width,height,border_width,depth,class,visual,valuemask,attributes);
}


TNK_EXPORT void XSetTextProperty_TNK(Display* display, Window w, XTextProperty* text_prop, Atom property) {
    XSetTextProperty(display,w,text_prop,property);
}

TNK_EXPORT Status XGetTextProperty_TNK(Display* display, Window w, XTextProperty* text_prop_return, Atom property) {
    return XGetTextProperty(display,w,text_prop_return,property);
}

TNK_EXPORT Display* XOpenDisplay_TNK(const char *dpy) {
    return XOpenDisplay(dpy);
}

TNK_EXPORT int XCloseDisplay_TNK(Display *screen) {
    return XCloseDisplay(screen);
}

TNK_EXPORT char* XDisplayName_TNK(char* string) {
    return XDisplayName(string);
}

typedef int (*XSynchronizeDelegaty)(Display*);
//int (*XSynchronize(Display *display, Bool onoff))();
XSynchronizeDelegaty XSynchronize_TNK(Display* display, Bool onoff) {
    return XSynchronize(display, onoff);
}

//int (*XSetAfterFunction(Display *display, int (*procedure)()))();
typedef int(*XSetAfterFunctionDelegaty)();
XSetAfterFunctionDelegaty XSetAfterFunction_TNK(Display* display, XSetAfterFunctionDelegaty proc) {
    return XSetAfterFunction(display, proc);
}

TNK_EXPORT XErrorHandler XSetErrorHandler_TNK(XErrorHandler handler) {
    return XSetErrorHandler(handler);
}

TNK_EXPORT XIOErrorHandler XSetIOErrorHandler_TNK(XIOErrorHandler handler) {
    return XSetIOErrorHandler(handler);
}

TNK_EXPORT int XGetErrorDatabaseText_TNK(Display* display, char* name, char* message, char* default_string, char* buffer_return, int length) {
    return XGetErrorDatabaseText(display,name,message,default_string,buffer_return,length);
}

TNK_EXPORT int XGetErrorText_TNK(Display* display, int code, char* buffer_return, int length) {
    return XGetErrorText(display,code,buffer_return,length);
}

TNK_EXPORT Colormap XCreateColormap_TNK(Display* display, Window w, Visual* visual, int alloc) {
    return XCreateColormap(display,w,visual,alloc);
}

TNK_EXPORT Colormap XCopyColormapAndFree_TNK(Display* display, Colormap colormap) {
    return XCopyColormapAndFree(display,colormap);
}

TNK_EXPORT int XFreeColormap_TNK(Display* display, Colormap colormap) {
    return XFreeColormap(display,colormap);
}

TNK_EXPORT Status XSetWMProtocols_TNK(Display* display, Window w, Atom* protocols, int count) {
    return XSetWMProtocols(display,w,protocols,count);
}

TNK_EXPORT Status XGetWMProtocols_TNK(Display* display, Window w, Atom **protocols_return, int* count_return) {
    return XGetWMProtocols(display,w,protocols_return,count_return);
}

TNK_EXPORT Atom XInternAtom_TNK(Display* display, char* atom_name, Bool only_if_exists) {
    return XInternAtom(display,atom_name,only_if_exists);
}

TNK_EXPORT Status XInternAtoms_TNK(Display* display, char* *names, int count, Bool only_if_exists, Atom* atoms_return) {
    return XInternAtoms(display,names,count,only_if_exists,atoms_return);
}

TNK_EXPORT char* XGetAtomName_TNK(Display* display, Atom atom) {
    return XGetAtomName(display,atom);
}

TNK_EXPORT Status XGetAtomNames_TNK(Display* display, Atom* atoms, int count, char **names_return) {
    return XGetAtomNames(display,atoms,count,names_return);
}

TNK_EXPORT int XFlush_TNK(Display* display) {
    return XFlush(display);
}

TNK_EXPORT int XSync_TNK(Display* display, Bool discard) {
    return XSync(display,discard);
}

TNK_EXPORT int XEventsQueued_TNK(Display* display, int mode) {
    return XEventsQueued(display,mode);
}

TNK_EXPORT int XPending_TNK(Display* display) {
    return XPending(display);
}

TNK_EXPORT int XNextEvent_TNK(Display* display, XEvent* event_return) {
    return XNextEvent(display,event_return);
}

TNK_EXPORT int XPeekEvent_TNK(Display* display, XEvent* event_return) {
    return XPeekEvent(display,event_return);
}

TNK_EXPORT int XWindowEvent_TNK(Display* display, Window w, long event_mask, XEvent* event_return) {
    return XWindowEvent(display,w,event_mask,event_return);
}

TNK_EXPORT Bool XCheckWindowEvent_TNK(Display* display, Window w, long event_mask, XEvent* event_return) {
    return XCheckWindowEvent(display,w,event_mask,event_return);
}

TNK_EXPORT int XMaskEvent_TNK(Display* display, long event_mask, XEvent* event_return) {
    return XMaskEvent(display,event_mask,event_return);
}

TNK_EXPORT Bool XCheckMaskEvent_TNK(Display* display, long event_mask, XEvent* event_return) {
    return XCheckMaskEvent(display,event_mask,event_return);
}

TNK_EXPORT Bool XCheckTypedEvent_TNK(Display* display, int event_type, XEvent* event_return) {
    return XCheckTypedEvent(display,event_type,event_return);
}

TNK_EXPORT Bool XCheckTypedWindowEvent_TNK(Display* display, Window w, int event_type, XEvent* event_return) {
    return XCheckTypedWindowEvent(display,w,event_type,event_return);
}


TNK_EXPORT int XSelectInput_TNK(Display* display, Window w, long event_mask) {
    return XSelectInput(display,w,event_mask);
}

TNK_EXPORT int XGetWindowProperty_TNK(Display* display, Window w, Atom property, long long_offset, long long_length, Bool delete, Atom req_type, Atom* actual_type_return, int* actual_format_return, unsigned long* nitems_return, unsigned long* bytes_after_return, unsigned char **prop_return) {
    return XGetWindowProperty(display,w,property,long_offset,long_length,delete,req_type,actual_type_return,actual_format_return,nitems_return,bytes_after_return,prop_return);
}

TNK_EXPORT Atom* XListProperties_TNK(Display* display, Window w, int* num_prop_return) {
    return XListProperties(display,w,num_prop_return);
}

TNK_EXPORT int XChangeProperty_TNK(Display* display, Window w, Atom property, Atom type, int format, int mode, unsigned char* data, int nelements) {
    return XChangeProperty(display,w,property,type,format,mode,data,nelements);
}

TNK_EXPORT int XRotateWindowProperties_TNK(Display* display, Window w, Atom properties[], int num_prop, int npositions) {
    return XRotateWindowProperties(display,w,properties,num_prop,npositions);
}

TNK_EXPORT int XDeleteProperty_TNK(Display* display, Window w, Atom property) {
    return XDeleteProperty(display,w,property);
}

TNK_EXPORT int XSetInputFocus_TNK(Display* display, Window focus, int revert_to, Time time) {
    return XSetInputFocus(display,focus,revert_to,time);
}

TNK_EXPORT int XGetInputFocus_TNK(Display* display, Window* focus_return, int* revert_to_return) {
    return XGetInputFocus(display,focus_return,revert_to_return);
}

TNK_EXPORT int XMapWindow_TNK(Display* display, Window w) {
    return XMapWindow(display,w);
}

TNK_EXPORT int XMapRaised_TNK(Display* display, Window w) {
    return XMapRaised(display,w);
}

TNK_EXPORT int XMapSubwindows_TNK(Display* display, Window w) {
    return XMapSubwindows(display,w);
}

TNK_EXPORT int XRaiseWindow_TNK(Display* display, Window w) {
    return XRaiseWindow(display,w);
}

TNK_EXPORT int XLowerWindow_TNK(Display* display, Window w) {
    return XLowerWindow(display,w);
}

TNK_EXPORT int XCirculateSubwindows_TNK(Display* display, Window w, int direction) {
    return XCirculateSubwindows(display,w,direction);
}

TNK_EXPORT int XCirculateSubwindowsUp_TNK(Display* display, Window w) {
    return XCirculateSubwindowsUp(display,w);
}

TNK_EXPORT int XCirculateSubwindowsDown_TNK(Display* display, Window w) {
    return XCirculateSubwindowsDown(display,w);
}

TNK_EXPORT int XRestackWindows_TNK(Display* display, Window windows[], int nwindows) {
    return XRestackWindows(display,windows,nwindows);
}

TNK_EXPORT int XConfigureWindow_TNK(Display* display, Window w, unsigned value_mask, XWindowChanges* changes) {
    return XConfigureWindow(display,w,value_mask,changes);
}

TNK_EXPORT int XMoveWindow_TNK(Display* display, Window w, int x, int y) {
    return XMoveWindow(display,w,x,y);
}

TNK_EXPORT int XResizeWindow_TNK(Display* display, Window w, unsigned width, unsigned height) {
    return XResizeWindow(display,w,width,height);
}

TNK_EXPORT int XMoveResizeWindow_TNK(Display* display, Window w, int x, int y, unsigned width, unsigned height) {
    return XMoveResizeWindow(display,w,x,y,width,height);
}

TNK_EXPORT int XSetWindowBorderWidth_TNK(Display* display, Window w, unsigned width) {
    return XSetWindowBorderWidth(display,w,width);
}


TNK_EXPORT Status XQueryTree_TNK(Display* display, Window w, Window* root_return, Window* parent_return, Window* *children_return, unsigned int* nchildren_return) {
    return XQueryTree(display,w,root_return,parent_return,children_return,nchildren_return);
}

TNK_EXPORT int XSetTransientForHint_TNK(Display* display, Window w, Window prop_window) {
    return XSetTransientForHint(display,w,prop_window);
}

TNK_EXPORT Status XGetTransientForHint_TNK(Display* display, Window w, Window* prop_window_return) {
    return XGetTransientForHint(display,w,prop_window_return);
}



TNK_EXPORT int XChangeWindowAttributes_TNK(Display* display, Window w, unsigned long valuemask, XSetWindowAttributes* attributes) {
    return XChangeWindowAttributes(display,w,valuemask,attributes);
}

TNK_EXPORT int XSetWindowBackground_TNK(Display* display, Window w, unsigned long background_pixel) {
    return XSetWindowBackground(display,w,background_pixel);
}

TNK_EXPORT int XSetWindowBackgroundPixmap_TNK(Display* display, Window w, Pixmap background_pixmap) {
    return XSetWindowBackgroundPixmap(display,w,background_pixmap);
}

TNK_EXPORT int XSetWindowBorder_TNK(Display* display, Window w, unsigned long border_pixel) {
    return XSetWindowBorder(display,w,border_pixel);
}

TNK_EXPORT int XSetWindowBorderPixmap_TNK(Display* display, Window w, Pixmap border_pixmap) {
    return XSetWindowBorderPixmap(display,w,border_pixmap);
}

TNK_EXPORT int XSetWindowColormap_TNK(Display* display, Window w, Colormap colormap) {
    return XSetWindowColormap(display,w,colormap);
}

/** GC */

TNK_EXPORT GC XCreateGC_TNK(Display* display, Drawable d, unsigned long valuemask, XGCValues* values) {
    return XCreateGC(display,d,valuemask,values);
}
TNK_EXPORT int XFreeGC_TNK(Display* display, GC gc) {
    return XFreeGC(display,gc);
}

TNK_EXPORT Status XGetGCValues_TNK(Display* display, GC gc, unsigned long valuemask, XGCValues* values_return) {
    return XGetGCValues(display,gc,valuemask,values_return);
}

TNK_EXPORT Pixmap XCreatePixmap_TNK(Display* display, Drawable d, unsigned int width, unsigned int height, unsigned int depth) {
    return XCreatePixmap(display,d,width,height,depth);
}
TNK_EXPORT int XFreePixmap_TNK(Display* display, Pixmap pixmap) {
    return XFreePixmap(display,pixmap);
}
TNK_EXPORT int XSetForeground_TNK(Display* display, GC gc, unsigned long foreground) {
    return XSetForeground(display,gc,foreground);
}
TNK_EXPORT int XSetBackground_TNK(Display* display, GC gc, unsigned long background) {
    return XSetBackground(display,gc,background);
}
TNK_EXPORT int XCopyPlane_TNK(Display* display, Drawable src, Drawable dest, GC gc, int src_x, int src_y, unsigned int width, unsigned int height, int dest_x, int dest_y, unsigned long plane) {
    return XCopyPlane(display,src,dest,gc,src_x,src_y,width,height,dest_x,dest_y,plane);
}
TNK_EXPORT int XCopyArea_TNK(Display* display, Drawable src, Drawable dest, GC gc, int src_x, int src_y, unsigned int width, unsigned int height, int dest_x, int dest_y) {
    return XCopyArea(display,src,dest,gc,src_x,src_y,width,height,dest_x,dest_y);
}
TNK_EXPORT int XClearWindow_TNK(Display* display, Window w) {
    return XClearWindow(display,w);
}
TNK_EXPORT int XClearArea_TNK(Display* display, Window w, int x, int y, unsigned width, unsigned height, Bool exposures) {
    return XClearArea(display,w,x,y,width,height,exposures);
}
TNK_EXPORT int XDrawPoint_TNK(Display* display, Drawable d, GC gc, int x, int y) {
    return XDrawPoint(display,d,gc,x,y);
}
TNK_EXPORT int XDrawPoints_TNK(Display* display, Drawable d, GC gc, XPoint* points, int npoints, int mode) {
    return XDrawPoints(display,d,gc,points,npoints,mode);
}
TNK_EXPORT int XDrawLine_TNK(Display* display, Drawable d, GC gc, int x1, int y1, int x2, int y2) {
    return XDrawLine(display,d,gc,x1,y1,x2,y2);
}
TNK_EXPORT int XDrawLines_TNK(Display* display, Drawable d, GC gc, XPoint* points, int npoints, int mode) {
    return XDrawLines(display,d,gc,points,npoints,mode);
}
TNK_EXPORT int XDrawSegments_TNK(Display* display, Drawable d, GC gc, XSegment* segments, int nsegments) {
    return XDrawSegments(display,d,gc,segments,nsegments);
}
TNK_EXPORT int XDrawRectangle_TNK(Display* display, Drawable d, GC gc, int x, int y, unsigned int width, unsigned int height) {
    return XDrawRectangle(display,d,gc,x,y,width,height);
}
TNK_EXPORT int XDrawRectangles_TNK(Display* display, Drawable d, GC gc, XRectangle* rectangles, int nrectangles) {
    return XDrawRectangles(display,d,gc,rectangles,nrectangles);
}
TNK_EXPORT int XFillRectangle_TNK(Display* display, Drawable d, GC gc, int x, int y, unsigned int width, unsigned int height) {
    return XFillRectangle(display,d,gc,x,y,width,height);
}
TNK_EXPORT int XFillRectangles_TNK(Display* display, Drawable d, GC gc, XRectangle* rectangles, int nrectangles) {
    return XFillRectangles(display,d,gc,rectangles,nrectangles);
}
TNK_EXPORT int XFillPolygon_TNK(Display* display, Drawable d, GC gc, XPoint* points, int npoints, int shape, int mode) {
    return XFillPolygon(display,d,gc,points,npoints,shape,mode);
}
TNK_EXPORT int XFillArc_TNK(Display* display, Drawable d, GC gc, int x, int y, unsigned int width, unsigned int height, int angle1, int angle2) {
    return XFillArc(display,d,gc,x,y,width,height,angle1,angle2);
}
TNK_EXPORT int XFillArcs_TNK(Display* display, Drawable d, GC gc, XArc* arcs, int narcs) {
    return XFillArcs(display,d,gc,arcs,narcs);
}
TNK_EXPORT int XDrawArc_TNK(Display* display, Drawable d, GC gc, int x, int y, unsigned int width, unsigned int height, int angle1, int angle2) {
    return XDrawArc(display,d,gc,x,y,width,height,angle1,angle2);
}
TNK_EXPORT int XDrawArcs_TNK(Display* display, Drawable d, GC gc, XArc* arcs, int narcs) {
    return XDrawArcs(display,d,gc,arcs,narcs);
}
TNK_EXPORT int XSetLineAttributes_TNK(Display* display, GC gc, unsigned int line_width, int line_style, int cap_style, int join_style) {
    return XSetLineAttributes(display,gc,line_width,line_style,cap_style,join_style);
}
TNK_EXPORT int XSetDashes_TNK(Display* display, GC gc, int dash_offset, char* dash_list, int n) {
    return XSetDashes(display,gc,dash_offset,dash_list,n);
}

TNK_EXPORT Status XGetGeometry_TNK(Display* display, Drawable d, Window* root_return, int* x_return, int* y_return, unsigned int* width_return, unsigned int* height_return, unsigned int* border_width_return, unsigned int* depth_return) {
    return XGetGeometry(display,d,root_return,x_return,y_return,width_return,height_return,border_width_return,depth_return);
}

TNK_EXPORT Status XGetWindowAttributes_TNK(Display* display, Window w, XWindowAttributes* window_attributes_return) {
    return XGetWindowAttributes(display,w,window_attributes_return);
}

TNK_EXPORT KeySym XStringToKeysym_TNK(char* string) {
    return XStringToKeysym(string);
}

TNK_EXPORT char *XKeysymToString_TNK(KeySym keysym) {
    return XKeysymToString(keysym);
}



//
// XImage
//

TNK_EXPORT XImage* XCreateImage_TNK(Display* display, Visual* visual, unsigned int depth, int format, int offset, char* data, unsigned int width, unsigned int height, int bitmap_pad, int bytes_per_line) {
    return XCreateImage(display,visual,depth,format,offset,data,width,height,bitmap_pad,bytes_per_line);
}

TNK_EXPORT unsigned long XGetPixel_TNK(XImage* ximage, int x, int y) {
    return XGetPixel(ximage,x,y);
}

TNK_EXPORT int XPutPixel_TNK(XImage* ximage, int x, int y, unsigned long pixel) {
    return XPutPixel(ximage,x,y,pixel);
}

TNK_EXPORT XImage* XSubImage_TNK(XImage* ximage, int x, int y, unsigned int subimage_width, unsigned int subimage_height) {
    return XSubImage(ximage,x,y,subimage_width,subimage_height);
}

TNK_EXPORT int XAddPixel_TNK(XImage* ximage, long value) {
    return XAddPixel(ximage,value);
}

TNK_EXPORT int XDestroyImage_TNK(XImage* ximage) {
    ximage->data = NULL;
    return XDestroyImage(ximage);
}

TNK_EXPORT int XPutImage_TNK(Display* display, Drawable d, GC gc, XImage* image, int src_x, int src_y, int dest_x, int dest_y, unsigned int width, unsigned int height) {
    return XPutImage(display,d,gc,image,src_x,src_y,dest_x,dest_y,width,height);
}

TNK_EXPORT XImage* XGetImage_TNK(Display* display, Drawable d, int x, int y, unsigned int width, unsigned int height, unsigned long plane_mask, int format) {
    return XGetImage(display,d,x,y,width,height,plane_mask,format);
}

TNK_EXPORT XImage* XGetSubImage_TNK(Display* display, Drawable d, int x, int y, unsigned int width, unsigned int height, unsigned long plane_mask, int format, XImage* dest_image, int dest_x, int dest_y) {
    return XGetSubImage(display,d,x,y,width,height,plane_mask,format,dest_image,dest_x,dest_y);
}
