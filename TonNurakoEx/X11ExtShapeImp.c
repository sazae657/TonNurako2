#include "TonNurako.h"
#include <X11/extensions/shape.h>

TNK_EXPORT Bool XShapeQueryExtension_TNK(Display* dpy, int* event_basep, int* error_basep) {
    return XShapeQueryExtension(dpy,event_basep,error_basep);
}

TNK_EXPORT Status XShapeQueryVersion_TNK(Display* dpy, int* major_versionp, int* minor_versionp) {
    return XShapeQueryVersion(dpy,major_versionp,minor_versionp);
}

TNK_EXPORT void XShapeCombineRegion_TNK(Display* dpy, Window dest, int destKind, int xOff, int yOff, Region r, int op) {
    XShapeCombineRegion(dpy,dest,destKind,xOff,yOff,r,op);
}

TNK_EXPORT void XShapeCombineRectangles_TNK(Display* dpy, XID dest, int destKind, int xOff, int yOff, XRectangle* rects, int n_rects, int op, int ordering) {
    XShapeCombineRectangles(dpy,dest,destKind,xOff,yOff,rects,n_rects,op,ordering);
}

TNK_EXPORT void XShapeCombineMask_TNK(Display* dpy, XID dest, int destKind, int xOff, int yOff, Pixmap src, int op) {
    XShapeCombineMask(dpy,dest,destKind,xOff,yOff,src,op);
}

TNK_EXPORT void XShapeCombineShape_TNK(Display* dpy, XID dest, int destKind, int xOff, int yOff, Pixmap src, int srcKind, int op) {
    XShapeCombineShape(dpy,dest,destKind,xOff,yOff,src,srcKind,op);
}

TNK_EXPORT void XShapeOffsetShape_TNK(Display* dpy, XID dest, int destKind, int xOff, int yOff) {
    XShapeOffsetShape(dpy,dest,destKind,xOff,yOff);
}

TNK_EXPORT Status XShapeQueryExtents_TNK(Display* dpy, Window window, int* bShaped, int* xbs, int* ybs, unsigned int* wbs, unsigned int* hbs, int* cShaped, int* xcs, int* ycs, unsigned int* wcs, unsigned int* hcs) {
    return XShapeQueryExtents(dpy,window,bShaped,xbs,ybs,wbs,hbs,cShaped,xcs,ycs,wcs,hcs);
}

TNK_EXPORT void XShapeSelectInput_TNK(Display* dpy, Window window, unsigned long mask) {
    XShapeSelectInput(dpy,window,mask);
}

TNK_EXPORT unsigned long XShapeInputSelected_TNK(Display* dpy, Window window) {
    return XShapeInputSelected(dpy,window);
}

TNK_EXPORT XRectangle* XShapeGetRectangles_TNK(Display* dpy, Window window, int kind, int* count, int* ordering) {
    return XShapeGetRectangles(dpy,window,kind,count,ordering);
}
