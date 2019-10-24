#include "TonNurako.h"
#include <X11/extensions/Xrender.h>

TNK_EXPORT int XDoubleToFixed_TNK(XDouble f) {
    return XDoubleToFixed(f);
}

TNK_EXPORT double XFixedToDouble_TNK(XFixed f) {
    return XFixedToDouble(f);
}

TNK_EXPORT Bool XRenderQueryExtension_TNK(Display* dpy, int* event_basep, int* error_basep) {
    return XRenderQueryExtension(dpy,event_basep,error_basep);
}

TNK_EXPORT Status XRenderQueryVersion_TNK(Display* dpy, int* major_versionp, int* minor_versionp) {
    return XRenderQueryVersion(dpy,major_versionp,minor_versionp);
}

TNK_EXPORT Status XRenderQueryFormats_TNK(Display* dpy) {
    return XRenderQueryFormats(dpy);
}

TNK_EXPORT int XRenderQuerySubpixelOrder_TNK(Display* dpy, int screen) {
    return XRenderQuerySubpixelOrder(dpy,screen);
}

TNK_EXPORT Bool XRenderSetSubpixelOrder_TNK(Display* dpy, int screen, int subpixel) {
    return XRenderSetSubpixelOrder(dpy,screen,subpixel);
}

TNK_EXPORT Status XRenderParseColor_TNK(Display* dpy, char* spec, XRenderColor* def) {
    return XRenderParseColor(dpy,spec,def);
}

TNK_EXPORT XRenderPictFormat* XRenderFindVisualFormat_TNK(Display* dpy, Visual* visual) {
    return XRenderFindVisualFormat(dpy,visual);
}

TNK_EXPORT XRenderPictFormat* XRenderFindFormat_TNK(Display* dpy, unsigned long mask, XRenderPictFormat* templ, int count) {
    return XRenderFindFormat(dpy,mask,templ,count);
}

TNK_EXPORT XRenderPictFormat* XRenderFindStandardFormat_TNK(Display* dpy, int format) {
    return XRenderFindStandardFormat(dpy,format);
}
TNK_EXPORT XIndexValue* XRenderQueryPictIndexValues_TNK(Display* dpy, XRenderPictFormat* format, int* num) {
    return XRenderQueryPictIndexValues(dpy,format,num);
}

TNK_EXPORT XFilters* XRenderQueryFilters_TNK(Display* dpy, Drawable drawable) {
    return XRenderQueryFilters(dpy,drawable);
}

TNK_EXPORT void XRenderFreePicture_TNK(Display* dpy, Picture picture) {
    XRenderFreePicture(dpy,picture);
}

TNK_EXPORT Picture XRenderCreatePicture_TNK(Display* dpy, Drawable drawable, XRenderPictFormat* format, unsigned long valuemask, XRenderPictureAttributes* attributes) {
    return XRenderCreatePicture(dpy,drawable,format,valuemask,attributes);
}

TNK_EXPORT void XRenderChangePicture_TNK(Display* dpy, Picture picture, unsigned long valuemask, XRenderPictureAttributes* attributes) {
    XRenderChangePicture(dpy,picture,valuemask,attributes);
}

TNK_EXPORT void XRenderSetPictureFilter_TNK(Display* dpy, Picture picture, char* filter, XFixed* params, int nparams) {
    XRenderSetPictureFilter(dpy,picture,filter,params,nparams);
}

TNK_EXPORT void XRenderSetPictureClipRectangles_TNK(Display* dpy, Picture picture, int xOrigin, int yOrigin, XRectangle* rects, int n) {
    XRenderSetPictureClipRectangles(dpy,picture,xOrigin,yOrigin,rects,n);
}

TNK_EXPORT void XRenderSetPictureClipRegion_TNK(Display* dpy, Picture picture, Region r) {
    XRenderSetPictureClipRegion(dpy,picture,r);
}

TNK_EXPORT void XRenderSetPictureTransform_TNK(Display* dpy, Picture picture, XTransform* transform) {
    XRenderSetPictureTransform(dpy,picture,transform);
}

TNK_EXPORT void XRenderFillRectangle_TNK(Display* dpy, int op, Picture dst, XRenderColor* color, int x, int y, unsigned int width, unsigned int height) {
    XRenderFillRectangle(dpy,op,dst,color,x,y,width,height);
}

TNK_EXPORT void XRenderFillRectangles_TNK(Display* dpy, int op, Picture dst, XRenderColor* color, XRectangle* rectangles, int n_rects) {
    XRenderFillRectangles(dpy,op,dst,color,rectangles,n_rects);
}

TNK_EXPORT void XRenderComposite_TNK(Display* dpy, int op, Picture src, Picture mask, Picture dst, int src_x, int src_y, int mask_x, int mask_y, int dst_x, int dst_y, unsigned int width, unsigned int height) {
    XRenderComposite(dpy,op,src,mask,dst,src_x,src_y,mask_x,mask_y,dst_x,dst_y,width,height);
}

TNK_EXPORT void XRenderCompositeTrapezoids_TNK(Display* dpy, int op, Picture src, Picture dst, XRenderPictFormat* maskFormat, int xSrc, int ySrc, XTrapezoid* traps, int ntrap) {
    XRenderCompositeTrapezoids(dpy,op,src,dst,maskFormat,xSrc,ySrc,traps,ntrap);
}

TNK_EXPORT void XRenderCompositeTriangles_TNK(Display* dpy, int op, Picture src, Picture dst, XRenderPictFormat* maskFormat, int xSrc, int ySrc, XTriangle* triangles, int ntriangle) {
    XRenderCompositeTriangles(dpy,op,src,dst,maskFormat,xSrc,ySrc,triangles,ntriangle);
}

TNK_EXPORT void XRenderCompositeTriStrip_TNK(Display* dpy, int op, Picture src, Picture dst, XRenderPictFormat* maskFormat, int xSrc, int ySrc, XPointFixed* points, int npoint) {
    XRenderCompositeTriStrip(dpy,op,src,dst,maskFormat,xSrc,ySrc,points,npoint);
}

TNK_EXPORT void XRenderCompositeTriFan_TNK(Display* dpy, int op, Picture src, Picture dst, XRenderPictFormat* maskFormat, int xSrc, int ySrc, XPointFixed* points, int npoint) {
    XRenderCompositeTriFan(dpy,op,src,dst,maskFormat,xSrc,ySrc,points,npoint);
}

TNK_EXPORT void XRenderCompositeDoublePoly_TNK(Display* dpy, int op, Picture src, Picture dst, XRenderPictFormat* maskFormat, int xSrc, int ySrc, int xDst, int yDst, XPointDouble* fpoints, int npoints, int winding) {
    XRenderCompositeDoublePoly(dpy,op,src,dst,maskFormat,xSrc,ySrc,xDst,yDst,fpoints,npoints,winding);
}

TNK_EXPORT Picture XRenderCreateSolidFill_TNK(Display* dpy, XRenderColor* color) {
    return XRenderCreateSolidFill(dpy,color);
}

TNK_EXPORT Picture XRenderCreateLinearGradient_TNK(Display* dpy, XLinearGradient* gradient, XFixed* stops, XRenderColor* colors, int nstops) {
    return XRenderCreateLinearGradient(dpy,gradient,stops,colors,nstops);
}

TNK_EXPORT Picture XRenderCreateRadialGradient_TNK(Display* dpy, XRadialGradient* gradient, XFixed* stops, XRenderColor* colors, int nstops) {
    return XRenderCreateRadialGradient(dpy,gradient,stops,colors,nstops);
}

TNK_EXPORT Picture XRenderCreateConicalGradient_TNK(Display* dpy, XConicalGradient* gradient, XFixed* stops, XRenderColor* colors, int nstops) {
    return XRenderCreateConicalGradient(dpy,gradient,stops,colors,nstops);
}
