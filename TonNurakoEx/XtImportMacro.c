#include "TonNurako.h"


TNK_EXPORT WidgetClass TNK_GetUltraSuperWidgetClass(void) {
    return &widgetClassRec;
}

// C#ではどーにもならねえので構造体に詰める
typedef struct
tagXtInheritTNK
{
    String              InheritTranslations;
    XtRealizeProc       InheritRealize;
    XtWidgetProc        InheritResize;
    XtExposeProc        InheritExpose;
    XtAlmostProc        InheritSetValuesAlmost;
    XtAcceptFocusProc   InheritAcceptFocus;
    XtGeometryHandler   InheritQueryGeometry;
    XtStringProc        InheritDisplayAccelerator;
}XtInheritTNK;

TNK_EXPORT void TNK_GetXtInheritance(XtInheritTNK* p)
{
    p->InheritTranslations = XtInheritTranslations;
    p->InheritRealize =XtInheritRealize;
    p->InheritResize =XtInheritResize;
    p->InheritExpose =XtInheritExpose;
    p->InheritSetValuesAlmost =XtInheritSetValuesAlmost;
    p->InheritAcceptFocus =XtInheritAcceptFocus;
    p->InheritQueryGeometry =XtInheritQueryGeometry;
    p->InheritDisplayAccelerator =XtInheritDisplayAccelerator;
}

TNK_EXPORT void TNK_InitializeXtWidgetClass(WidgetClassRec* p)
{
    (p->core_class).tm_table = XtInheritTranslations;
    (p->core_class).realize = XtInheritRealize;
    (p->core_class).resize = XtInheritResize;
    (p->core_class).expose = XtInheritExpose;
    (p->core_class).set_values_almost = XtInheritSetValuesAlmost;
    (p->core_class).accept_focus = XtInheritAcceptFocus;
    (p->core_class).query_geometry = XtInheritQueryGeometry;
    (p->core_class).display_accelerator = XtInheritDisplayAccelerator;
    (p->core_class).version = XtVersion;
}

TNK_EXPORT Widget XtCreateManagedWidget_TNK(String name, WidgetClass widget_class, Widget parent, ArgList args, Cardinal num_args) {
    return XtCreateManagedWidget(name,widget_class,parent,args,num_args);
}

TNK_EXPORT Widget XtCreateWidget_TNK(String name, WidgetClass widget_class, Widget parent, ArgList args, Cardinal num_args) {
    return XtCreateWidget(name,widget_class,parent,args,num_args);
}

TNK_EXPORT void XtCreateWindow_TNK(Widget widget, int window_class, Visual* visual, XtValueMask value_mask, XSetWindowAttributes* attributes) {
    XtCreateWindow(widget,window_class,visual,value_mask,attributes);
}

TNK_EXPORT XtIntervalId XtAppAddTimeOut_TNK(XtAppContext app_context, long interval, XtTimerCallbackProc proc, XtPointer client_data) {
    return XtAppAddTimeOut(app_context,interval,proc,client_data);
}
TNK_EXPORT void XtRemoveTimeOut_TNK(XtIntervalId timer) {
    XtRemoveTimeOut(timer);
}

TNK_EXPORT Widget XtParent_TNK(Widget w) {
    return XtParent(w);
}

//
// WidgetRec用のｱｸｾｯｻー
//

Widget TNK_GetWidgetRecSelf(WidgetRec* ptr) { return ptr->core.self; }
void TNK_SetWidgetRecSelf(WidgetRec* ptr, Widget value) { ptr->core.self = value; }

WidgetClass TNK_GetWidgetRecWidgetClass(WidgetRec* ptr) { return ptr->core.widget_class; }
void TNK_SetWidgetRecWidgetClass(WidgetRec* ptr, WidgetClass value) { ptr->core.widget_class = value; }

Widget TNK_GetWidgetRecParent(WidgetRec* ptr) { return ptr->core.parent; }
void TNK_SetWidgetRecParent(WidgetRec* ptr, Widget value) { ptr->core.parent = value; }

XrmName TNK_GetWidgetRecXrmName(WidgetRec* ptr) { return ptr->core.xrm_name; }
void TNK_SetWidgetRecXrmName(WidgetRec* ptr, XrmName value) { ptr->core.xrm_name = value; }

Boolean TNK_GetWidgetRecBeingDestroyed(WidgetRec* ptr) { return ptr->core.being_destroyed; }
void TNK_SetWidgetRecBeingDestroyed(WidgetRec* ptr, Boolean value) { ptr->core.being_destroyed = value; }

XtCallbackList TNK_GetWidgetRecDestroyCallbacks(WidgetRec* ptr) { return ptr->core.destroy_callbacks; }
void TNK_SetWidgetRecDestroyCallbacks(WidgetRec* ptr, XtCallbackList value) { ptr->core.destroy_callbacks = value; }

XtPointer TNK_GetWidgetRecConstraints(WidgetRec* ptr) { return ptr->core.constraints; }
void TNK_SetWidgetRecConstraints(WidgetRec* ptr, XtPointer value) { ptr->core.constraints = value; }

Position TNK_GetWidgetRecX(WidgetRec* ptr) { return ptr->core.x; }
void TNK_SetWidgetRecX(WidgetRec* ptr, Position value) { ptr->core.x = value; }

Position TNK_GetWidgetRecY(WidgetRec* ptr) { return ptr->core.y; }
void TNK_SetWidgetRecY(WidgetRec* ptr, Position value) { ptr->core.y = value; }

Dimension TNK_GetWidgetRecWidth(WidgetRec* ptr) { return ptr->core.width; }
void TNK_SetWidgetRecWidth(WidgetRec* ptr, Dimension value) { ptr->core.width = value; }

Dimension TNK_GetWidgetRecHeight(WidgetRec* ptr) { return ptr->core.height; }
void TNK_SetWidgetRecHeight(WidgetRec* ptr, Dimension value) { ptr->core.height = value; }

Dimension TNK_GetWidgetRecBorderWidth(WidgetRec* ptr) { return ptr->core.border_width; }
void TNK_SetWidgetRecBorderWidth(WidgetRec* ptr, Dimension value) { ptr->core.border_width = value; }

Boolean TNK_GetWidgetRecManaged(WidgetRec* ptr) { return ptr->core.managed; }
void TNK_SetWidgetRecManaged(WidgetRec* ptr, Boolean value) { ptr->core.managed = value; }

Boolean TNK_GetWidgetRecSensitive(WidgetRec* ptr) { return ptr->core.sensitive; }
void TNK_SetWidgetRecSensitive(WidgetRec* ptr, Boolean value) { ptr->core.sensitive = value; }

Boolean TNK_GetWidgetRecAncestorSensitive(WidgetRec* ptr) { return ptr->core.ancestor_sensitive; }
void TNK_SetWidgetRecAncestorSensitive(WidgetRec* ptr, Boolean value) { ptr->core.ancestor_sensitive = value; }

XtEventTable TNK_GetWidgetRecEventTable(WidgetRec* ptr) { return ptr->core.event_table; }
void TNK_SetWidgetRecEventTable(WidgetRec* ptr, XtEventTable value) { ptr->core.event_table = value; }

XtTMRec TNK_GetWidgetRecTm(WidgetRec* ptr) { return ptr->core.tm; }
void TNK_SetWidgetRecTm(WidgetRec* ptr, XtTMRec value) { ptr->core.tm = value; }

XtTranslations TNK_GetWidgetRecAccelerators(WidgetRec* ptr) { return ptr->core.accelerators; }
void TNK_SetWidgetRecAccelerators(WidgetRec* ptr, XtTranslations value) { ptr->core.accelerators = value; }

Pixel TNK_GetWidgetRecBorderPixel(WidgetRec* ptr) { return ptr->core.border_pixel; }
void TNK_SetWidgetRecBorderPixel(WidgetRec* ptr, Pixel value) { ptr->core.border_pixel = value; }

Pixmap TNK_GetWidgetRecBorderPixmap(WidgetRec* ptr) { return ptr->core.border_pixmap; }
void TNK_SetWidgetRecBorderPixmap(WidgetRec* ptr, Pixmap value) { ptr->core.border_pixmap = value; }

WidgetList TNK_GetWidgetRecPopupList(WidgetRec* ptr) { return ptr->core.popup_list; }
void TNK_SetWidgetRecPopupList(WidgetRec* ptr, WidgetList value) { ptr->core.popup_list = value; }

Cardinal TNK_GetWidgetRecNumPopups(WidgetRec* ptr) { return ptr->core.num_popups; }
void TNK_SetWidgetRecNumPopups(WidgetRec* ptr, Cardinal value) { ptr->core.num_popups = value; }

String TNK_GetWidgetRecName(WidgetRec* ptr) { return ptr->core.name; }
void TNK_SetWidgetRecName(WidgetRec* ptr, String value) { ptr->core.name = value; }

Screen* TNK_GetWidgetRecScreen(WidgetRec* ptr) { return ptr->core.screen; }
void TNK_SetWidgetRecScreen(WidgetRec* ptr, Screen* value) { ptr->core.screen = value; }

Colormap TNK_GetWidgetRecColormap(WidgetRec* ptr) { return ptr->core.colormap; }
void TNK_SetWidgetRecColormap(WidgetRec* ptr, Colormap value) { ptr->core.colormap = value; }

Window TNK_GetWidgetRecWindow(WidgetRec* ptr) { return ptr->core.window; }
void TNK_SetWidgetRecWindow(WidgetRec* ptr, Window value) { ptr->core.window = value; }

Cardinal TNK_GetWidgetRecDepth(WidgetRec* ptr) { return ptr->core.depth; }
void TNK_SetWidgetRecDepth(WidgetRec* ptr, Cardinal value) { ptr->core.depth = value; }

Pixel TNK_GetWidgetRecBackgroundPixel(WidgetRec* ptr) { return ptr->core.background_pixel; }
void TNK_SetWidgetRecBackgroundPixel(WidgetRec* ptr, Pixel value) { ptr->core.background_pixel = value; }

Pixmap TNK_GetWidgetRecBackgroundPixmap(WidgetRec* ptr) { return ptr->core.background_pixmap; }
void TNK_SetWidgetRecBackgroundPixmap(WidgetRec* ptr, Pixmap value) { ptr->core.background_pixmap = value; }

Boolean TNK_GetWidgetRecVisible(WidgetRec* ptr) { return ptr->core.visible; }
void TNK_SetWidgetRecVisible(WidgetRec* ptr, Boolean value) { ptr->core.visible = value; }

Boolean TNK_GetWidgetRecMappedWhenManaged(WidgetRec* ptr) { return ptr->core.mapped_when_managed; }
void TNK_SetWidgetRecMappedWhenManaged(WidgetRec* ptr, Boolean value) { ptr->core.mapped_when_managed = value; }
