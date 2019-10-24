#include "TonNurako.h"

TNK_EXPORT int XReadBitmapFile_TNK(Display* display, Drawable d, char* filename, unsigned int* width_return, unsigned int* height_return, Pixmap* bitmap_return, int* x_hot_return, int* y_hot_return) {
    return XReadBitmapFile(display,d,filename,width_return,height_return,bitmap_return,x_hot_return,y_hot_return);
}

TNK_EXPORT int XReadBitmapFileData_TNK(char* filename, unsigned int* width_return, unsigned int* height_return, unsigned char** data_return, int* x_hot_return, int* y_hot_return) {
    return XReadBitmapFileData(filename,width_return,height_return,data_return,x_hot_return,y_hot_return);
}

TNK_EXPORT int XWriteBitmapFile_TNK(Display* display, char* filename, Pixmap bitmap, unsigned int width, unsigned int height, int x_hot, int y_hot) {
    return XWriteBitmapFile(display,filename,bitmap,width,height,x_hot,y_hot);
}

TNK_EXPORT Pixmap XCreatePixmapFromBitmapData_TNK(Display* display, Drawable d, char* data, unsigned int width, unsigned int height, unsigned long fg, unsigned long bg, unsigned int depth) {
    return XCreatePixmapFromBitmapData(display,d,data,width,height,fg,bg,depth);
}

TNK_EXPORT Pixmap XCreateBitmapFromData_TNK(Display* display, Drawable d, char* data, unsigned int width, unsigned int height) {
    return XCreateBitmapFromData(display,d,data,width,height);
}

TNK_EXPORT Region XCreateRegion_TNK() {
    return XCreateRegion();
}

TNK_EXPORT int XSetRegion_TNK(Display* display, GC gc, Region r) {
    return XSetRegion(display,gc,r);
}

TNK_EXPORT int XDestroyRegion_TNK(Region r) {
    return XDestroyRegion(r);
}

TNK_EXPORT Bool XEmptyRegion_TNK(Region r) {
    return XEmptyRegion(r);
}

TNK_EXPORT Bool XEqualRegion_TNK(Region r1, Region r2) {
    return XEqualRegion(r1,r2);
}

TNK_EXPORT Bool XPointInRegion_TNK(Region r, int x, int y) {
    return XPointInRegion(r,x,y);
}

TNK_EXPORT int XRectInRegion_TNK(Region r, int x, int y, unsigned int width, unsigned int height) {
    return XRectInRegion(r,x,y,width,height);
}

TNK_EXPORT int XIntersectRegion_TNK(Region sra, Region srb, Region dr_return) {
    return XIntersectRegion(sra,srb,dr_return);
}

TNK_EXPORT int XUnionRegion_TNK(Region sra, Region srb, Region dr_return) {
    return XUnionRegion(sra,srb,dr_return);
}

TNK_EXPORT int XUnionRectWithRegion_TNK(XRectangle* rectangle, Region src_region, Region dest_region_return) {
    return XUnionRectWithRegion(rectangle,src_region,dest_region_return);
}

TNK_EXPORT int XSubtractRegion_TNK(Region sra, Region srb, Region dr_return) {
    return XSubtractRegion(sra,srb,dr_return);
}

TNK_EXPORT int XXorRegion_TNK(Region sra, Region srb, Region dr_return) {
    return XXorRegion(sra,srb,dr_return);
}

TNK_EXPORT int XOffsetRegion_TNK(Region r, int dx, int dy) {
    return XOffsetRegion(r,dx,dy);
}

TNK_EXPORT int XShrinkRegion_TNK(Region r, int dx, int dy) {
    return XShrinkRegion(r,dx,dy);
}

TNK_EXPORT Region XPolygonRegion_TNK(XPoint points[], int n, int fill_rule) {
    return XPolygonRegion(points,n,fill_rule);
}

TNK_EXPORT int XClipBox_TNK(Region r, XRectangle* rect_return) {
    return XClipBox(r,rect_return);
}

TNK_EXPORT int XQueryColor_TNK(Display* display, Colormap colormap, XColor* def_in_out) {
    return XQueryColor(display,colormap,def_in_out);
}
TNK_EXPORT int XQueryColors_TNK(Display* display, Colormap colormap, XColor defs_in_out[], int ncolors) {
    return XQueryColors(display,colormap,defs_in_out,ncolors);
}
TNK_EXPORT Status XLookupColor_TNK(Display* display, Colormap colormap, char* color_name, XColor* exact_def_return, XColor* screen_def_return) {
    return XLookupColor(display,colormap,color_name,exact_def_return,screen_def_return);
}
TNK_EXPORT Status XParseColor_TNK(Display* display, Colormap colormap, char* spec, XColor* exact_def_return) {
    return XParseColor(display,colormap,spec,exact_def_return);
}
