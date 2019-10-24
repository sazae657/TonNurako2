#include "TonNurako.h"

TNK_EXPORT FcBool FcInit_TNK() {
    return FcInit();
}
TNK_EXPORT void FcFini_TNK() {
    FcFini();
}

TNK_EXPORT void FcPatternDestroy_TNK(FcPattern* p) {
    FcPatternDestroy(p);
}

TNK_EXPORT FcPattern* XftXlfdParse_TNK(char* xlfd_orig, Bool ignore_scalable, Bool complete) {
    return XftXlfdParse(xlfd_orig,ignore_scalable,complete);
}
TNK_EXPORT FcPattern* FcNameParse_TNK(FcChar8* name) {
    return FcNameParse(name);
}

TNK_EXPORT XftFont* XftFontOpenName_TNK(Display* dpy, int screen, const char* name) {
    return XftFontOpenName(dpy,screen,name);
}
TNK_EXPORT XftFont* XftFontOpenPattern_TNK(Display* dpy, FcPattern* fontpattern) {
    return XftFontOpenPattern(dpy,fontpattern);
}

TNK_EXPORT XftFont* XftFontOpenXlfd_TNK(Display* dpy, int screen, const char* xlfd) {
    return XftFontOpenXlfd(dpy,screen,xlfd);
}

TNK_EXPORT void XftFontClose_TNK(Display* dpy, XftFont* font) {
    XftFontClose(dpy,font);
}

TNK_EXPORT Bool XftColorAllocName_TNK(Display* dpy, Visual* visual, Colormap cmap, char* name, XftColor* result) {
    return XftColorAllocName(dpy,visual,cmap,name,result);
}
TNK_EXPORT Bool XftColorAllocValue_TNK(Display* dpy, Visual* visual, Colormap cmap, XRenderColor* color, XftColor* result) {
    return XftColorAllocValue(dpy,visual,cmap,color,result);
}
TNK_EXPORT void XftColorFree_TNK(Display* dpy, Visual* visual, Colormap cmap, XftColor* color) {
    XftColorFree(dpy,visual,cmap,color);
}

TNK_EXPORT XftDraw* XftDrawCreate_TNK(Display* dpy, Drawable drawable, Visual* visual, Colormap colormap) {
    return XftDrawCreate(dpy,drawable,visual,colormap);
}
TNK_EXPORT XftDraw* XftDrawCreateBitmap_TNK(Display* dpy, Pixmap bitmap) {
    return XftDrawCreateBitmap(dpy,bitmap);
}
TNK_EXPORT XftDraw* XftDrawCreateAlpha_TNK(Display* dpy, Pixmap pixmap, int depth) {
    return XftDrawCreateAlpha(dpy,pixmap,depth);
}
TNK_EXPORT void XftDrawChange_TNK(XftDraw* draw, Drawable drawable) {
    XftDrawChange(draw,drawable);
}
TNK_EXPORT Display* XftDrawDisplay_TNK(XftDraw* draw) {
    return XftDrawDisplay(draw);
}
TNK_EXPORT Drawable XftDrawDrawable_TNK(XftDraw* draw) {
    return XftDrawDrawable(draw);
}
TNK_EXPORT Colormap XftDrawColormap_TNK(XftDraw* draw) {
    return XftDrawColormap(draw);
}
TNK_EXPORT Visual* XftDrawVisual_TNK(XftDraw* draw) {
    return XftDrawVisual(draw);
}
TNK_EXPORT void XftDrawDestroy_TNK(XftDraw* draw) {
    XftDrawDestroy(draw);
}
TNK_EXPORT Picture XftDrawPicture_TNK(XftDraw* draw) {
    return XftDrawPicture(draw);
}
TNK_EXPORT Picture XftDrawSrcPicture_TNK(XftDraw* draw, XftColor* color) {
    return XftDrawSrcPicture(draw,color);
}

TNK_EXPORT void XftDrawString16_TNK(XftDraw* draw, XftColor* color, XftFont* pub, int x, int y, FcChar16* string, int len) {
    XftDrawString16(draw,color,pub,x,y,string,len);
}

TNK_EXPORT void XftDrawGlyphs_TNK(XftDraw* draw, XftColor* color, XftFont* pub, int x, int y, FT_UInt* glyphs, int nglyphs) {
    XftDrawGlyphs(draw,color,pub,x,y,glyphs,nglyphs);
}
TNK_EXPORT void XftDrawString8_TNK(XftDraw* draw, XftColor* color, XftFont* pub, int x, int y, FcChar8* string, int len) {
    XftDrawString8(draw,color,pub,x,y,string,len);
}
TNK_EXPORT void XftDrawString32_TNK(XftDraw* draw, XftColor* color, XftFont* pub, int x, int y, FcChar32* string, int len) {
    XftDrawString32(draw,color,pub,x,y,string,len);
}
TNK_EXPORT void XftDrawStringUtf8_TNK(XftDraw* draw, XftColor* color, XftFont* pub, int x, int y, FcChar8* string, int len) {
    XftDrawStringUtf8(draw,color,pub,x,y,string,len);
}
TNK_EXPORT void XftDrawStringUtf16_TNK(XftDraw* draw, XftColor* color, XftFont* pub, int x, int y, FcChar8* string, FcEndian endian, int len) {
    XftDrawStringUtf16(draw,color,pub,x,y,string,endian,len);
}
TNK_EXPORT void XftDrawCharSpec_TNK(XftDraw* draw, XftColor* color, XftFont* pub, XftCharSpec* chars, int len) {
    XftDrawCharSpec(draw,color,pub,chars,len);
}
TNK_EXPORT void XftDrawCharFontSpec_TNK(XftDraw* draw, XftColor* color, XftCharFontSpec* chars, int len) {
    XftDrawCharFontSpec(draw,color,chars,len);
}
TNK_EXPORT void XftDrawGlyphSpec_TNK(XftDraw* draw, XftColor* color, XftFont* pub, XftGlyphSpec* glyphs, int len) {
    XftDrawGlyphSpec(draw,color,pub,glyphs,len);
}
TNK_EXPORT void XftDrawGlyphFontSpec_TNK(XftDraw* draw, XftColor* color, XftGlyphFontSpec* glyphs, int len) {
    XftDrawGlyphFontSpec(draw,color,glyphs,len);
}
TNK_EXPORT void XftDrawRect_TNK(XftDraw* draw, XftColor* color, int x, int y, unsigned int width, unsigned int height) {
    XftDrawRect(draw,color,x,y,width,height);
}
TNK_EXPORT Bool XftDrawSetClip_TNK(XftDraw* draw, Region r) {
    return XftDrawSetClip(draw,r);
}
TNK_EXPORT Bool XftDrawSetClipRectangles_TNK(XftDraw* draw, int xOrigin, int yOrigin, XRectangle* rects, int n) {
    return XftDrawSetClipRectangles(draw,xOrigin,yOrigin,rects,n);
}
TNK_EXPORT void XftDrawSetSubwindowMode_TNK(XftDraw* draw, int mode) {
    XftDrawSetSubwindowMode(draw,mode);
}

TNK_EXPORT Bool XftDefaultHasRender_TNK(Display* dpy) {
    return XftDefaultHasRender(dpy);
}
TNK_EXPORT Bool XftDefaultSet_TNK(Display* dpy, FcPattern* defaults) {
    return XftDefaultSet(dpy,defaults);
}
TNK_EXPORT void XftDefaultSubstitute_TNK(Display* dpy, int screen, FcPattern* pattern) {
    XftDefaultSubstitute(dpy,screen,pattern);
}

TNK_EXPORT FcBool XftCharExists_TNK(Display* dpy, XftFont* pub, FcChar32 ucs4) {
    return XftCharExists(dpy,pub,ucs4);
}
TNK_EXPORT FT_UInt XftCharIndex_TNK(Display* dpy, XftFont* pub, FcChar32 ucs4) {
    return XftCharIndex(dpy,pub,ucs4);
}
TNK_EXPORT FcBool XftInit_TNK(_Xconst char* config) {
    return XftInit(config);
}
TNK_EXPORT int XftGetVersion_TNK() {
    return XftGetVersion();
}

TNK_EXPORT XftFontInfo* XftFontInfoCreate_TNK(Display* dpy, _Xconst FcPattern* pattern) {
    return XftFontInfoCreate(dpy,pattern);
}
TNK_EXPORT void XftFontInfoDestroy_TNK(Display* dpy, XftFontInfo* fi) {
    XftFontInfoDestroy(dpy,fi);
}
TNK_EXPORT FcChar32 XftFontInfoHash_TNK(XftFontInfo* fi) {
    return XftFontInfoHash(fi);
}
TNK_EXPORT FcBool XftFontInfoEqual_TNK(XftFontInfo* a, _Xconst XftFontInfo* b) {
    return XftFontInfoEqual(a,b);
}
TNK_EXPORT XftFont* XftFontOpenInfo_TNK(Display* dpy, FcPattern* pattern, XftFontInfo* fi) {
    return XftFontOpenInfo(dpy,pattern,fi);
}

TNK_EXPORT FcCharSet* FcCharSetCreate_TNK() {
    return FcCharSetCreate();
}
TNK_EXPORT void FcCharSetDestroy_TNK(FcCharSet* fcs) {
    FcCharSetDestroy(fcs);
}
TNK_EXPORT FcBool FcCharSetAddChar_TNK(FcCharSet* fcs, FcChar32 ucs4) {
    return FcCharSetAddChar(fcs,ucs4);
}
TNK_EXPORT FcBool FcCharSetDelChar_TNK(FcCharSet* fcs, FcChar32 ucs4) {
    return FcCharSetDelChar(fcs,ucs4);
}
TNK_EXPORT FcCharSet* FcCharSetCopy_TNK(FcCharSet* src) {
    return FcCharSetCopy(src);
}
TNK_EXPORT FcBool FcCharSetEqual_TNK(const FcCharSet* a, const FcCharSet* b) {
    return FcCharSetEqual(a,b);
}
TNK_EXPORT FcCharSet* FcCharSetIntersect_TNK(const FcCharSet* a, const FcCharSet* b) {
    return FcCharSetIntersect(a,b);
}
TNK_EXPORT FcCharSet* FcCharSetUnion_TNK(const FcCharSet* a, const FcCharSet* b) {
    return FcCharSetUnion(a,b);
}
TNK_EXPORT FcCharSet* FcCharSetSubtract_TNK(const FcCharSet* a, const FcCharSet* b) {
    return FcCharSetSubtract(a,b);
}
TNK_EXPORT FcBool FcCharSetMerge_TNK(FcCharSet* a, const FcCharSet* b, FcBool* changed) {
    return FcCharSetMerge(a,b,changed);
}
TNK_EXPORT FcBool FcCharSetHasChar_TNK(const FcCharSet* fcs, FcChar32 ucs4) {
    return FcCharSetHasChar(fcs,ucs4);
}
TNK_EXPORT FcChar32 FcCharSetCount_TNK(const FcCharSet* a) {
    return FcCharSetCount(a);
}
TNK_EXPORT FcChar32 FcCharSetIntersectCount_TNK(const FcCharSet* a, const FcCharSet* b) {
    return FcCharSetIntersectCount(a,b);
}
TNK_EXPORT FcChar32 FcCharSetSubtractCount_TNK(const FcCharSet* a, const FcCharSet* b) {
    return FcCharSetSubtractCount(a,b);
}
TNK_EXPORT FcBool FcCharSetIsSubset_TNK(const FcCharSet* a, const FcCharSet* b) {
    return FcCharSetIsSubset(a,b);
}
TNK_EXPORT FcChar32 FcCharSetFirstPage_TNK(const FcCharSet* a, FcChar32 map[FC_CHARSET_MAP_SIZE], FcChar32* next) {
    return FcCharSetFirstPage(a,map,next);
}
TNK_EXPORT FcChar32 FcCharSetNextPage_TNK(const FcCharSet* a, FcChar32 map[FC_CHARSET_MAP_SIZE], FcChar32* next) {
    return FcCharSetNextPage(a,map,next);
}

//FcPattern
TNK_EXPORT FcPattern* FcPatternCreate_TNK() {
    return FcPatternCreate();
}
TNK_EXPORT FcPattern* FcPatternDuplicate_TNK(const FcPattern* p) {
    return FcPatternDuplicate(p);
}
TNK_EXPORT void FcPatternReference_TNK(FcPattern* p) {
    FcPatternReference(p);
}
TNK_EXPORT FcPattern* FcPatternFilter_TNK(FcPattern* p, const FcObjectSet* os) {
    return FcPatternFilter(p,os);
}
TNK_EXPORT FcBool FcValueEqual_TNK(FcValue va, FcValue vb) {
    return FcValueEqual(va,vb);
}
TNK_EXPORT FcValue FcValueSave_TNK(FcValue v) {
    return FcValueSave(v);
}

TNK_EXPORT FcBool FcPatternEqual_TNK(const FcPattern* pa, const FcPattern* pb) {
    return FcPatternEqual(pa,pb);
}
TNK_EXPORT FcBool FcPatternEqualSubset_TNK(const FcPattern* pa, const FcPattern* pb, const FcObjectSet* os) {
    return FcPatternEqualSubset(pa,pb,os);
}
TNK_EXPORT FcChar32 FcPatternHash_TNK(const FcPattern* p) {
    return FcPatternHash(p);
}
TNK_EXPORT FcBool FcPatternAdd_TNK(FcPattern* p, const char* obzekt, FcValue value, FcBool append) {
    return FcPatternAdd(p,obzekt,value,append);
}
TNK_EXPORT FcBool FcPatternAddWeak_TNK(FcPattern* p, const char* obzekt, FcValue value, FcBool append) {
    return FcPatternAddWeak(p,obzekt,value,append);
}
TNK_EXPORT FcResult FcPatternGet_TNK(const FcPattern* p, const char* obzekt, int id, FcValue* v) {
    return FcPatternGet(p,obzekt,id,v);
}
TNK_EXPORT FcBool FcPatternDel_TNK(FcPattern* p, const char* obzekt) {
    return FcPatternDel(p,obzekt);
}
TNK_EXPORT FcBool FcPatternRemove_TNK(FcPattern* p, const char* obzekt, int id) {
    return FcPatternRemove(p,obzekt,id);
}
TNK_EXPORT FcBool FcPatternAddInteger_TNK(FcPattern* p, const char* obzekt, int i) {
    return FcPatternAddInteger(p,obzekt,i);
}
TNK_EXPORT FcBool FcPatternAddDouble_TNK(FcPattern* p, const char* obzekt, double d) {
    return FcPatternAddDouble(p,obzekt,d);
}
TNK_EXPORT FcBool FcPatternAddString_TNK(FcPattern* p, const char* obzekt, const FcChar8* s) {
    return FcPatternAddString(p,obzekt,s);
}
TNK_EXPORT FcBool FcPatternAddMatrix_TNK(FcPattern* p, const char* obzekt, const FcMatrix* s) {
    return FcPatternAddMatrix(p,obzekt,s);
}
TNK_EXPORT FcBool FcPatternAddCharSet_TNK(FcPattern* p, const char* obzekt, const FcCharSet* c) {
    return FcPatternAddCharSet(p,obzekt,c);
}
TNK_EXPORT FcBool FcPatternAddBool_TNK(FcPattern* p, const char* obzekt, FcBool b) {
    return FcPatternAddBool(p,obzekt,b);
}
TNK_EXPORT FcBool FcPatternAddLangSet_TNK(FcPattern* p, const char* obzekt, const FcLangSet* ls) {
    return FcPatternAddLangSet(p,obzekt,ls);
}


TNK_EXPORT FcResult FcPatternGetInteger_TNK(const FcPattern* p, const char* obzekt, int n, int* i) {
    return FcPatternGetInteger(p,obzekt,n,i);
}
TNK_EXPORT FcResult FcPatternGetDouble_TNK(const FcPattern* p, const char* obzekt, int n, double* d) {
    return FcPatternGetDouble(p,obzekt,n,d);
}
TNK_EXPORT FcResult FcPatternGetString_TNK(const FcPattern* p, const char* obzekt, int n, FcChar8** s) {
    return FcPatternGetString(p,obzekt,n,s);
}
TNK_EXPORT FcResult FcPatternGetMatrix_TNK(const FcPattern* p, const char* obzekt, int n, FcMatrix** s) {
    return FcPatternGetMatrix(p,obzekt,n,s);
}
TNK_EXPORT FcResult FcPatternGetCharSet_TNK(const FcPattern* p, const char* obzekt, int n, FcCharSet** c) {
    return FcPatternGetCharSet(p,obzekt,n,c);
}
TNK_EXPORT FcResult FcPatternGetBool_TNK(const FcPattern* p, const char* obzekt, int n, FcBool* b) {
    return FcPatternGetBool(p,obzekt,n,b);
}
TNK_EXPORT FcResult FcPatternGetLangSet_TNK(const FcPattern* p, const char* obzekt, int n, FcLangSet** ls) {
    return FcPatternGetLangSet(p,obzekt,n,ls);
}

#ifdef USE_FC22
TNK_EXPORT FcBool FcPatternAddRange_TNK(FcPattern* p, const char* obzekt, const FcRange* r) {
    return FcPatternAddRange(p,obzekt,r);
}

TNK_EXPORT FcResult FcPatternGetRange_TNK(const FcPattern* p, const char* obzekt, int id, FcRange** r) {
    return FcPatternGetRange(p,obzekt,id,r);
}
#endif

TNK_EXPORT FcChar8* FcPatternFormat_TNK(FcPattern* pat, const FcChar8* format) {
    return FcPatternFormat(pat,format);
}


TNK_EXPORT FcBlanks* FcBlanksCreate_TNK() {
    return FcBlanksCreate();
}
TNK_EXPORT void FcBlanksDestroy_TNK(FcBlanks* b) {
    FcBlanksDestroy(b);
}
TNK_EXPORT FcBool FcBlanksAdd_TNK(FcBlanks* b, FcChar32 ucs4) {
    return FcBlanksAdd(b,ucs4);
}
TNK_EXPORT FcBool FcBlanksIsMember_TNK(FcBlanks* b, FcChar32 ucs4) {
    return FcBlanksIsMember(b,ucs4);
}


TNK_EXPORT const FcChar8* FcCacheDir_TNK(const FcCache* c) {
    return FcCacheDir(c);
}
TNK_EXPORT FcFontSet* FcCacheCopySet_TNK(const FcCache* c) {
    return FcCacheCopySet(c);
}
TNK_EXPORT const FcChar8* FcCacheSubdir_TNK(const FcCache* c, int i) {
    return FcCacheSubdir(c,i);
}
TNK_EXPORT int FcCacheNumSubdir_TNK(const FcCache* c) {
    return FcCacheNumSubdir(c);
}
TNK_EXPORT int FcCacheNumFont_TNK(const FcCache* c) {
    return FcCacheNumFont(c);
}
TNK_EXPORT FcBool FcDirCacheUnlink_TNK(const FcChar8* dir, FcConfig* config) {
    return FcDirCacheUnlink(dir,config);
}
TNK_EXPORT FcBool FcDirCacheValid_TNK(const FcChar8* cache_file) {
    return FcDirCacheValid(cache_file);
}
TNK_EXPORT FcBool FcDirCacheClean_TNK(const FcChar8* cache_dir, FcBool verbose) {
    return FcDirCacheClean(cache_dir,verbose);
}
TNK_EXPORT void FcCacheCreateTagFile_TNK(const FcConfig* config) {
    FcCacheCreateTagFile(config);
}


TNK_EXPORT int FcGetVersion_TNK() {
    return FcGetVersion();
}
TNK_EXPORT FcBool FcInitReinitialize_TNK() {
    return FcInitReinitialize();
}
TNK_EXPORT FcBool FcInitBringUptoDate_TNK() {
    return FcInitBringUptoDate();
}

TNK_EXPORT FcChar8* FcConfigHome_TNK() {
    return FcConfigHome();
}
TNK_EXPORT FcBool FcConfigEnableHome_TNK(FcBool enable) {
    return FcConfigEnableHome(enable);
}
TNK_EXPORT FcChar8* FcConfigFilename_TNK(const FcChar8* url) {
    return FcConfigFilename(url);
}
TNK_EXPORT FcConfig* FcConfigCreate_TNK() {
    return FcConfigCreate();
}
TNK_EXPORT FcConfig* FcConfigReference_TNK(FcConfig* config) {
    return FcConfigReference(config);
}
TNK_EXPORT void FcConfigDestroy_TNK(FcConfig* config) {
    FcConfigDestroy(config);
}
TNK_EXPORT FcBool FcConfigSetCurrent_TNK(FcConfig* config) {
    return FcConfigSetCurrent(config);
}
TNK_EXPORT FcConfig* FcConfigGetCurrent_TNK() {
    return FcConfigGetCurrent();
}
TNK_EXPORT FcBool FcConfigUptoDate_TNK(FcConfig* config) {
    return FcConfigUptoDate(config);
}
TNK_EXPORT FcBool FcConfigBuildFonts_TNK(FcConfig* config) {
    return FcConfigBuildFonts(config);
}
TNK_EXPORT FcStrList* FcConfigGetFontDirs_TNK(FcConfig* config) {
    return FcConfigGetFontDirs(config);
}
TNK_EXPORT FcStrList* FcConfigGetConfigDirs_TNK(FcConfig* config) {
    return FcConfigGetConfigDirs(config);
}
TNK_EXPORT FcStrList* FcConfigGetConfigFiles_TNK(FcConfig* config) {
    return FcConfigGetConfigFiles(config);
}
TNK_EXPORT FcChar8* FcConfigGetCache_TNK(FcConfig* config) {
    return FcConfigGetCache(config);
}
TNK_EXPORT FcBlanks* FcConfigGetBlanks_TNK(FcConfig* config) {
    return FcConfigGetBlanks(config);
}
TNK_EXPORT FcStrList* FcConfigGetCacheDirs_TNK(const FcConfig* config) {
    return FcConfigGetCacheDirs(config);
}
TNK_EXPORT int FcConfigGetRescanInterval_TNK(FcConfig* config) {
    return FcConfigGetRescanInterval(config);
}
TNK_EXPORT FcBool FcConfigSetRescanInterval_TNK(FcConfig* config, int rescanInterval) {
    return FcConfigSetRescanInterval(config,rescanInterval);
}
TNK_EXPORT FcFontSet* FcConfigGetFonts_TNK(FcConfig* config, FcSetName set) {
    return FcConfigGetFonts(config,set);
}
TNK_EXPORT FcBool FcConfigAppFontAddFile_TNK(FcConfig* config, const FcChar8* file) {
    return FcConfigAppFontAddFile(config,file);
}
TNK_EXPORT FcBool FcConfigAppFontAddDir_TNK(FcConfig* config, const FcChar8* dir) {
    return FcConfigAppFontAddDir(config,dir);
}
TNK_EXPORT void FcConfigAppFontClear_TNK(FcConfig* config) {
    FcConfigAppFontClear(config);
}
TNK_EXPORT FcBool FcConfigSubstituteWithPat_TNK(FcConfig* config, FcPattern* p, FcPattern* p_pat, FcMatchKind kind) {
    return FcConfigSubstituteWithPat(config,p,p_pat,kind);
}
TNK_EXPORT FcBool FcConfigSubstitute_TNK(FcConfig* config, FcPattern* p, FcMatchKind kind) {
    return FcConfigSubstitute(config,p,kind);
}
TNK_EXPORT const FcChar8* FcConfigGetSysRoot_TNK(const FcConfig* config) {
    return FcConfigGetSysRoot(config);
}
TNK_EXPORT void FcConfigSetSysRoot_TNK(FcConfig* config, const FcChar8* sysroot) {
    FcConfigSetSysRoot(config,sysroot);
}

TNK_EXPORT FcConfig* FcInitLoadConfig_TNK() {
    return FcInitLoadConfig();
}
TNK_EXPORT FcConfig* FcInitLoadConfigAndFonts_TNK() {
    return FcInitLoadConfigAndFonts();
}

TNK_EXPORT FcBool FcConfigParseAndLoad_TNK(FcConfig* config, const FcChar8* file, FcBool complain) {
    return FcConfigParseAndLoad(config,file,complain);
}


TNK_EXPORT FcStrList* FcStrListCreate_TNK(FcStrSet* set) {
    return FcStrListCreate(set);
}
TNK_EXPORT void FcStrListFirst_TNK(FcStrList* list) {
    FcStrListFirst(list);
}
TNK_EXPORT FcChar8* FcStrListNext_TNK(FcStrList* list) {
    return FcStrListNext(list);
}
TNK_EXPORT void FcStrListDone_TNK(FcStrList* list) {
    FcStrListDone(list);
}

TNK_EXPORT FcStrSet* FcStrSetCreate_TNK() {
    return FcStrSetCreate();
}
TNK_EXPORT FcBool FcStrSetMember_TNK(FcStrSet* set, const FcChar8* s) {
    return FcStrSetMember(set,s);
}
TNK_EXPORT FcBool FcStrSetEqual_TNK(FcStrSet* sa, FcStrSet* sb) {
    return FcStrSetEqual(sa,sb);
}
TNK_EXPORT FcBool FcStrSetAdd_TNK(FcStrSet* set, const FcChar8* s) {
    return FcStrSetAdd(set,s);
}
TNK_EXPORT FcBool FcStrSetAddFilename_TNK(FcStrSet* set, const FcChar8* s) {
    return FcStrSetAddFilename(set,s);
}
TNK_EXPORT FcBool FcStrSetDel_TNK(FcStrSet* set, const FcChar8* s) {
    return FcStrSetDel(set,s);
}
TNK_EXPORT void FcStrSetDestroy_TNK(FcStrSet* set) {
    FcStrSetDestroy(set);
}

TNK_EXPORT FcFontSet* FcFontSetCreate_TNK() {
    return FcFontSetCreate();
}
TNK_EXPORT void FcFontSetDestroy_TNK(FcFontSet* s) {
    FcFontSetDestroy(s);
}
TNK_EXPORT FcBool FcFontSetAdd_TNK(FcFontSet* s, FcPattern* font) {
    return FcFontSetAdd(s,font);
}

TNK_EXPORT FcPattern* FcFontSetMatch_TNK(FcConfig* config, FcFontSet** sets, int nsets, FcPattern* p, FcResult* result) {
    return FcFontSetMatch(config,sets,nsets,p,result);
}
TNK_EXPORT FcPattern* FcFontMatch_TNK(FcConfig* config, FcPattern* p, FcResult* result) {
    return FcFontMatch(config,p,result);
}
TNK_EXPORT FcPattern* FcFontRenderPrepare_TNK(FcConfig* config, FcPattern* pat, FcPattern* font) {
    return FcFontRenderPrepare(config,pat,font);
}
TNK_EXPORT FcFontSet* FcFontSetSort_TNK(FcConfig* config, FcFontSet** sets, int nsets, FcPattern* p, FcBool trim, FcCharSet** csp, FcResult* result) {
    return FcFontSetSort(config,sets,nsets,p,trim,csp,result);
}
TNK_EXPORT FcFontSet* FcFontSort_TNK(FcConfig* config, FcPattern* p, FcBool trim, FcCharSet** csp, FcResult* result) {
    return FcFontSort(config,p,trim,csp,result);
}
TNK_EXPORT void FcFontSetSortDestroy_TNK(FcFontSet* fs) {
    FcFontSetSortDestroy(fs);
}

TNK_EXPORT FcStrSet* FcGetLangs_TNK() {
    return FcGetLangs();
}
TNK_EXPORT FcChar8* FcLangNormalize_TNK(const FcChar8* lang) {
    return FcLangNormalize(lang);
}
TNK_EXPORT const FcCharSet* FcLangGetCharSet_TNK(const FcChar8* lang) {
    return FcLangGetCharSet(lang);
}
TNK_EXPORT FcLangSet* FcLangSetCreate_TNK() {
    return FcLangSetCreate();
}
TNK_EXPORT void FcLangSetDestroy_TNK(FcLangSet* ls) {
    FcLangSetDestroy(ls);
}
TNK_EXPORT FcLangSet* FcLangSetCopy_TNK(const FcLangSet* ls) {
    return FcLangSetCopy(ls);
}
TNK_EXPORT FcBool FcLangSetAdd_TNK(FcLangSet* ls, const FcChar8* lang) {
    return FcLangSetAdd(ls,lang);
}
TNK_EXPORT FcBool FcLangSetDel_TNK(FcLangSet* ls, const FcChar8* lang) {
    return FcLangSetDel(ls,lang);
}
TNK_EXPORT FcLangResult FcLangSetHasLang_TNK(const FcLangSet* ls, const FcChar8* lang) {
    return FcLangSetHasLang(ls,lang);
}
TNK_EXPORT FcLangResult FcLangSetCompare_TNK(const FcLangSet* lsa, const FcLangSet* lsb) {
    return FcLangSetCompare(lsa,lsb);
}
TNK_EXPORT FcBool FcLangSetContains_TNK(const FcLangSet* lsa, const FcLangSet* lsb) {
    return FcLangSetContains(lsa,lsb);
}
TNK_EXPORT FcBool FcLangSetEqual_TNK(const FcLangSet* lsa, const FcLangSet* lsb) {
    return FcLangSetEqual(lsa,lsb);
}
TNK_EXPORT FcChar32 FcLangSetHash_TNK(const FcLangSet* ls) {
    return FcLangSetHash(ls);
}
TNK_EXPORT FcStrSet* FcLangSetGetLangs_TNK(const FcLangSet* ls) {
    return FcLangSetGetLangs(ls);
}
TNK_EXPORT FcLangSet* FcLangSetUnion_TNK(const FcLangSet* a, const FcLangSet* b) {
    return FcLangSetUnion(a,b);
}
TNK_EXPORT FcLangSet* FcLangSetSubtract_TNK(const FcLangSet* a, const FcLangSet* b) {
    return FcLangSetSubtract(a,b);
}


TNK_EXPORT void FcMatrixInit_TNK(FcMatrix* mat) {
    FcMatrixInit(mat);
}

TNK_EXPORT FcMatrix* FcMatrixCopy_TNK(const FcMatrix* mat) {
    return FcMatrixCopy(mat);
}
TNK_EXPORT FcBool FcMatrixEqual_TNK(const FcMatrix* mat1, const FcMatrix* mat2) {
    return FcMatrixEqual(mat1,mat2);
}
TNK_EXPORT void FcMatrixMultiply_TNK(FcMatrix* result, const FcMatrix* a, const FcMatrix* b) {
    FcMatrixMultiply(result,a,b);
}
TNK_EXPORT void FcMatrixRotate_TNK(FcMatrix* m, double c, double s) {
    FcMatrixRotate(m,c,s);
}
TNK_EXPORT void FcMatrixScale_TNK(FcMatrix* m, double sx, double sy) {
    FcMatrixScale(m,sx,sy);
}
TNK_EXPORT void FcMatrixShear_TNK(FcMatrix* m, double sh, double sv) {
    FcMatrixShear(m,sh,sv);
}

TNK_EXPORT FcStrSet* FcGetDefaultLangs_TNK() {
    return FcGetDefaultLangs();
}
TNK_EXPORT void FcDefaultSubstitute_TNK(FcPattern* pattern) {
    FcDefaultSubstitute(pattern);
}


#ifdef USE_FC22
TNK_EXPORT FcRange* FcRangeCreateDouble_TNK(double begin, double end) {
    return FcRangeCreateDouble(begin,end);
}
TNK_EXPORT FcRange* FcRangeCreateInteger_TNK(FcChar32 begin, FcChar32 end) {
    return FcRangeCreateInteger(begin,end);
}
TNK_EXPORT void FcRangeDestroy_TNK(FcRange* range) {
    FcRangeDestroy(range);
}
TNK_EXPORT FcRange* FcRangeCopy_TNK(const FcRange* r) {
    return FcRangeCopy(r);
}
TNK_EXPORT FcBool FcRangeGetDouble_TNK(const FcRange* range, double* begin, double* end) {
    return FcRangeGetDouble(range,begin,end);
}
#endif

//XftFont ｱｸｾｯｻー
int TNK_GetXftFontAscent(XftFont* ptr) { return ptr->ascent; }
void TNK_SetXftFontAscent(XftFont* ptr, int value) { ptr->ascent = value; }

int TNK_GetXftFontDescent(XftFont* ptr) { return ptr->descent; }
void TNK_SetXftFontDescent(XftFont* ptr, int value) { ptr->descent = value; }

int TNK_GetXftFontHeight(XftFont* ptr) { return ptr->height; }
void TNK_SetXftFontHeight(XftFont* ptr, int value) { ptr->height = value; }

int TNK_GetXftFontMaxAdvanceWidth(XftFont* ptr) { return ptr->max_advance_width; }
void TNK_SetXftFontMaxAdvanceWidth(XftFont* ptr, int value) { ptr->max_advance_width = value; }

FcCharSet* TNK_GetXftFontCharset(XftFont* ptr) { return ptr->charset; }
void TNK_SetXftFontCharset(XftFont* ptr, FcCharSet* value) { ptr->charset = value; }

FcPattern* TNK_GetXftFontPattern(XftFont* ptr) { return ptr->pattern; }
void TNK_SetXftFontPattern(XftFont* ptr, FcPattern* value) { ptr->pattern = value; }
