#include "TonNurako.h"

TNK_DECLARE_BEGIN

TNK_EXPORT void TNK_IMP_Xm_XmAddWMProtocolCallback(
	Widget widget, char *name, XtCallbackProc call )
{
	Atom atom = XmInternAtom( XtDisplay( widget ), name, False );

	XmAddWMProtocolCallback( widget, atom, call, NULL );
}

TNK_EXPORT void TNK_IMP_Xm_XmRemoveWMProtocolCallback(
	Widget widget, char *name, XtCallbackProc call )
{
	Atom atom = XmInternAtom( XtDisplay( widget ), name, False );

	XmRemoveWMProtocolCallback( widget, atom, call, NULL );
}

TNK_EXPORT Atom TNK_IMP_Xm_XmInternAtom( Display *d,String s, Boolean b)
{
	return XmInternAtom( d, s, b );
}

TNK_EXPORT XmTab XmTabCreate_TNK(float value, unsigned char units, XmOffsetModel offset_model, unsigned char alignment, char* decimal) {
    return XmTabCreate(value,units,offset_model,alignment,decimal);
}

TNK_EXPORT void XmTabFree_TNK(XmTab tab) {
    XmTabFree(tab);
}

TNK_EXPORT XmTabList XmTabListInsertTabs_TNK(XmTabList oldlist, XmTab* tabs, Cardinal tab_count, int position) {
    return XmTabListInsertTabs(oldlist,tabs,tab_count,position);
}

TNK_EXPORT void XmTabListFree_TNK(XmTabList tablist) {
    XmTabListFree(tablist);
}

TNK_EXPORT void XmRedisplayWidget_TNK(Widget widget) {
	XExposeEvent xev;
	Dimension ww , hh ;
    Widget w;

    w = widget;

    if( ! XtIsRealized(w)           ) return ;
    if( ! XtIsManaged(w)            ) return ;
	xev.window  = XtWindow(w) ; if( xev.window == (Window) NULL ) return ;
	xev.type    = Expose ;
	xev.display = XtDisplay(w) ;
	xev.x       = xev.y = 0 ;
	XtVaGetValues( w, XmNwidth, &ww, XmNheight, &hh, NULL ) ;
	if( ww <= 0 || hh <= 0 ) return ;
	xev.width   = ww ; xev.height  = hh ;
	XSendEvent (XtDisplay(w), XtWindow(w), True, ExposureMask, (XEvent *)&xev);
 	XClearArea (XtDisplay(w), XtWindow(w), 0, 0, ww, hh, True);
	XFlush( XtDisplay(w) ) ;
}

//
// XmRendition
//
TNK_EXPORT XmRendition XmRenditionCreate_TNK(Widget widget, XmStringTag tag, ArgList arglist, Cardinal argcount) {
    return XmRenditionCreate(widget,tag,arglist,argcount);
}

TNK_EXPORT void XmRenditionFree_TNK(XmRendition rendition) {
    XmRenditionFree(rendition);
}

TNK_EXPORT void XmRenditionRetrieve_TNK(XmRendition rendition, ArgList arglist, Cardinal argcount) {
    XmRenditionRetrieve(rendition,arglist,argcount);
}

TNK_EXPORT void XmRenditionUpdate_TNK(XmRendition rendition, ArgList arglist, Cardinal argcount) {
    XmRenditionUpdate(rendition,arglist,argcount);
}

TNK_EXPORT XmRenderTable XmRenderTableAddRenditions_TNK(XmRenderTable oldtable, XmRendition* renditions, Cardinal rendition_count, XmMergeMode merge_mode) {
    return XmRenderTableAddRenditions(oldtable,renditions,rendition_count,merge_mode);
}

TNK_EXPORT XmRenderTable XmRenderTableCopy_TNK(XmRenderTable table, XmStringTag* tags, int tag_count) {
    return XmRenderTableCopy(table,tags,tag_count);
}

TNK_EXPORT XmRenderTable XmRenderTableCvtFromProp_TNK(Widget widget, char* property, unsigned int length) {
    return XmRenderTableCvtFromProp(widget,property,length);
}

TNK_EXPORT uint XmRenderTableCvtToProp_TNK(Widget widget, XmRenderTable table, char** prop_return) {
    return XmRenderTableCvtToProp(widget,table, prop_return);
}

TNK_EXPORT void XmRenderTableFree_TNK(XmRenderTable table) {
    XmRenderTableFree(table);
}

TNK_EXPORT XmRendition XmRenderTableGetRendition_TNK(XmRenderTable table, XmStringTag tag) {
    return XmRenderTableGetRendition(table,tag);
}

TNK_EXPORT XmRendition* XmRenderTableGetRenditions_TNK(XmRenderTable table, XmStringTag* tags, Cardinal tag_count) {
    return XmRenderTableGetRenditions(table,tags,tag_count);
}

TNK_EXPORT int XmRenderTableGetTags_TNK(XmRenderTable table, XmStringTag** tag_list) {
    return XmRenderTableGetTags(table, tag_list);
}

TNK_EXPORT XmRenderTable XmRenderTableRemoveRenditions_TNK(XmRenderTable oldtable, XmStringTag* tags, int tag_count) {
    return XmRenderTableRemoveRenditions(oldtable,tags,tag_count);
}

//
//  XmToggleButton
//
TNK_EXPORT Boolean XmToggleButtonGadgetGetState_TNK(Widget widget) {
    return XmToggleButtonGadgetGetState(widget);
}

TNK_EXPORT void XmToggleButtonGadgetSetState_TNK(Widget widget, Boolean state, Boolean notify) {
    XmToggleButtonGadgetSetState(widget,state,notify);
}

TNK_EXPORT Boolean XmToggleButtonGetState_TNK(Widget widget) {
    return XmToggleButtonGetState(widget);
}

TNK_EXPORT void XmToggleButtonSetState_TNK(Widget widget, Boolean state, Boolean notify) {
    XmToggleButtonSetState(widget,state,notify);
}

TNK_EXPORT void XmToggleButtonSetValue_TNK(Widget widget, XmToggleButtonState state, Boolean notify) {
    XmToggleButtonSetValue(widget,state,notify);
}

// SimpleSpinBox
TNK_EXPORT void XmSimpleSpinBoxAddItem_TNK(Widget w, XmString item, int pos) {
    XmSimpleSpinBoxAddItem(w,item,pos);
}

TNK_EXPORT void XmSimpleSpinBoxDeletePos_TNK(Widget w, int pos) {
    XmSimpleSpinBoxDeletePos(w,pos);
}

TNK_EXPORT void XmSimpleSpinBoxSetItem_TNK(Widget w, XmString item) {
    XmSimpleSpinBoxSetItem(w,item);
}

//
// PIXMAP
//
TNK_EXPORT Pixmap
XmGetPixmap_TNK(
        Screen *screen,
        char *image_name,
        Pixel foreground,
        Pixel background)
{
    return XmGetPixmap(screen, image_name, foreground, background);
}


TNK_EXPORT Boolean
XmDestroyPixmap_TNK(Screen * screen,Pixmap pixmap) {
    return XmDestroyPixmap(screen, pixmap);
}

//
// XmString
//

TNK_EXPORT void
XmStringFree_TNK(XmString str) {
    XmStringFree(str);
}

TNK_EXPORT XmString
XmStringCreateLocalized_TNK(String str)
{
    return XmStringCreateLocalized(str);
}

TNK_EXPORT XtPointer
XmStringUnparse_TNK(
    XmString string,
    XmStringTag tag,
    XmTextType tag_type,
    XmTextType output_type,
    XmParseTable parse_table,
    Cardinal parse_count,
    XmParseModel parse_model)
{
    return XmStringUnparse(
    string,
    tag,
    tag_type,
    output_type,
    parse_table,
    parse_count,
    parse_model);
}

//
// XmMessageBox
//

TNK_EXPORT Widget
XmMessageBoxGetChild_TNK(
    Widget widget,
    unsigned char child)
{
    return XmMessageBoxGetChild(widget, child);
}

TNK_EXPORT Widget
XmSelectionBoxGetChild_TNK(
    Widget widget,
    unsigned char child)
{
    return XmSelectionBoxGetChild(widget, child);
}


TNK_EXPORT XmFontList XmFontListCreate_TNK(XFontStruct* font, XmStringCharSet charset) {
    return XmFontListCreate(font,charset);
}

TNK_EXPORT void XmMenuPosition_TNK(Widget menu, XButtonPressedEvent* event) {
    XmMenuPosition(menu,event);
}

/*
* Text API
*/

TNK_EXPORT void XmTextClearSelection_TNK(Widget widget, Time time) {
    XmTextClearSelection(widget,time);
}

TNK_EXPORT Boolean XmTextCopy_TNK(Widget widget, Time time) {
    return XmTextCopy(widget,time);
}

TNK_EXPORT Boolean XmTextCopyLink_TNK(Widget widget, Time time) {
    return XmTextCopyLink(widget,time);
}

TNK_EXPORT Boolean XmTextCut_TNK(Widget widget, Time time) {
    return XmTextCut(widget,time);
}

TNK_EXPORT void XmTextDisableRedisplay_TNK(Widget widget) {
    XmTextDisableRedisplay(widget);
}

TNK_EXPORT void XmTextEnableRedisplay_TNK(Widget widget) {
    XmTextEnableRedisplay(widget);
}
TNK_EXPORT Boolean XmTextFindString_TNK(Widget widget, XmTextPosition start, char* string, XmTextDirection direction, XmTextPosition* position) {
    return XmTextFindString(widget,start,string,direction,position);
}

TNK_EXPORT int XmTextGetBaseline_TNK(Widget widget) {
    return XmTextGetBaseline(widget);
}

TNK_EXPORT int XmTextGetCenterline_TNK(Widget widget) {
    return XmTextGetCenterline(widget);
}

TNK_EXPORT Boolean XmTextGetEditable_TNK(Widget widget) {
    return XmTextGetEditable(widget);
}

TNK_EXPORT XmTextPosition XmTextGetInsertionPosition_TNK(Widget widget) {
    return XmTextGetInsertionPosition(widget);
}

TNK_EXPORT XmTextPosition XmTextGetLastPosition_TNK(Widget widget) {
    return XmTextGetLastPosition(widget);
}

TNK_EXPORT int XmTextGetMaxLength_TNK(Widget widget) {
    return XmTextGetMaxLength(widget);
}

TNK_EXPORT char* XmTextGetSelection_TNK(Widget widget) {
    return XmTextGetSelection(widget);
}

TNK_EXPORT Boolean XmTextGetSelectionPosition_TNK(Widget widget, XmTextPosition* left, XmTextPosition* right) {
    return XmTextGetSelectionPosition(widget,left,right);
}

TNK_EXPORT XmTextSource XmTextGetSource_TNK(Widget widget) {
    return XmTextGetSource(widget);
}

TNK_EXPORT char* XmTextGetString_TNK(Widget widget) {
    return XmTextGetString(widget);
}

TNK_EXPORT int XmTextGetSubstring_TNK(Widget widget, XmTextPosition start, int num_chars, int buffer_size, char* buffer) {
    return XmTextGetSubstring(widget,start,num_chars,buffer_size,buffer);
}

TNK_EXPORT XmTextPosition XmTextGetTopCharacter_TNK(Widget widget) {
    return XmTextGetTopCharacter(widget);
}

TNK_EXPORT void XmTextInsert_TNK(Widget widget, XmTextPosition position, char* value) {
    XmTextInsert(widget,position,value);
}

TNK_EXPORT Boolean XmTextPaste_TNK(Widget widget) {
    return XmTextPaste(widget);
}

TNK_EXPORT Boolean XmTextPasteLink_TNK(Widget widget) {
    return XmTextPasteLink(widget);
}

TNK_EXPORT Boolean XmTextPosToXY_TNK(Widget widget, XmTextPosition position, Position* x, Position* y) {
    return XmTextPosToXY(widget,position,x,y);
}

TNK_EXPORT Boolean XmTextRemove_TNK(Widget widget) {
    return XmTextRemove(widget);
}

TNK_EXPORT void XmTextReplace_TNK(Widget widget, XmTextPosition from_pos, XmTextPosition to_pos, char* value) {
    XmTextReplace(widget,from_pos,to_pos,value);
}

TNK_EXPORT void XmTextScroll_TNK(Widget widget, int lines) {
    XmTextScroll(widget,lines);
}

TNK_EXPORT void XmTextSetAddMode_TNK(Widget widget, Boolean state) {
    XmTextSetAddMode(widget,state);
}

TNK_EXPORT void XmTextSetEditable_TNK(Widget widget, Boolean editable) {
    XmTextSetEditable(widget,editable);
}

TNK_EXPORT void XmTextSetHighlight_TNK(Widget widget, XmTextPosition left, XmTextPosition right, XmHighlightMode mode) {
    XmTextSetHighlight(widget,left,right,mode);
}

TNK_EXPORT void XmTextSetInsertionPosition_TNK(Widget widget, XmTextPosition position) {
    XmTextSetInsertionPosition(widget,position);
}

TNK_EXPORT void XmTextSetMaxLength_TNK(Widget widget, int max_length) {
    XmTextSetMaxLength(widget,max_length);
}

TNK_EXPORT void XmTextSetSelection_TNK(Widget widget, XmTextPosition first, XmTextPosition last, Time time) {
    XmTextSetSelection(widget,first,last,time);
}

TNK_EXPORT void XmTextSetSource_TNK(Widget widget, XmTextSource source, XmTextPosition top_character, XmTextPosition cursor_position) {
    XmTextSetSource(widget,source,top_character,cursor_position);
}

TNK_EXPORT void XmTextSetString_TNK(Widget widget, char* value) {
    XmTextSetString(widget,value);
}

TNK_EXPORT void XmTextSetTopCharacter_TNK(Widget widget, XmTextPosition top_character) {
    XmTextSetTopCharacter(widget,top_character);
}

TNK_EXPORT void XmTextShowPosition_TNK(Widget widget, XmTextPosition position) {
    XmTextShowPosition(widget,position);
}

TNK_EXPORT XmTextPosition XmTextXYToPos_TNK(Widget widget, Position x, Position y) {
    return XmTextXYToPos(widget,x,y);
}


/*
* TextField API
*/

TNK_EXPORT void XmTextFieldClearSelection_TNK(Widget widget, Time time) {
    XmTextFieldClearSelection(widget,time);
}

TNK_EXPORT Boolean XmTextFieldCopy_TNK(Widget widget, Time time) {
    return XmTextFieldCopy(widget,time);
}

TNK_EXPORT Boolean XmTextFieldCopyLink_TNK(Widget widget, Time time) {
    return XmTextFieldCopyLink(widget,time);
}

TNK_EXPORT Boolean XmTextFieldCut_TNK(Widget widget, Time time) {
    return XmTextFieldCut(widget,time);
}

TNK_EXPORT int XmTextFieldGetBaseline_TNK(Widget widget) {
    return XmTextFieldGetBaseline(widget);
}

TNK_EXPORT Boolean XmTextFieldGetEditable_TNK(Widget widget) {
    return XmTextFieldGetEditable(widget);
}

TNK_EXPORT XmTextPosition XmTextFieldGetInsertionPosition_TNK(Widget widget) {
    return XmTextFieldGetInsertionPosition(widget);
}

TNK_EXPORT XmTextPosition XmTextFieldGetLastPosition_TNK(Widget widget) {
    return XmTextFieldGetLastPosition(widget);
}

TNK_EXPORT int XmTextFieldGetMaxLength_TNK(Widget widget) {
    return XmTextFieldGetMaxLength(widget);
}

TNK_EXPORT char* XmTextFieldGetSelection_TNK(Widget widget) {
    return XmTextFieldGetSelection(widget);
}

TNK_EXPORT Boolean XmTextFieldGetSelectionPosition_TNK(Widget widget, XmTextPosition* left, XmTextPosition* right) {
    return XmTextFieldGetSelectionPosition(widget,left,right);
}

TNK_EXPORT char* XmTextFieldGetString_TNK(Widget widget) {
    return XmTextFieldGetString(widget);
}

TNK_EXPORT int XmTextFieldGetSubstring_TNK(Widget widget, XmTextPosition start, int num_chars, int buffer_size, char* buffer) {
    return XmTextFieldGetSubstring(widget,start,num_chars,buffer_size,buffer);
}

TNK_EXPORT void XmTextFieldInsert_TNK(Widget widget, XmTextPosition position, char* value) {
    XmTextFieldInsert(widget,position,value);
}

TNK_EXPORT Boolean XmTextFieldPaste_TNK(Widget widget) {
    return XmTextFieldPaste(widget);
}

TNK_EXPORT Boolean XmTextFieldPasteLink_TNK(Widget widget) {
    return XmTextFieldPasteLink(widget);
}

TNK_EXPORT Boolean XmTextFieldPosToXY_TNK(Widget widget, XmTextPosition position, Position* x, Position* y) {
    return XmTextFieldPosToXY(widget,position,x,y);
}

TNK_EXPORT Boolean XmTextFieldRemove_TNK(Widget widget) {
    return XmTextFieldRemove(widget);
}

TNK_EXPORT void XmTextFieldReplace_TNK(Widget widget, XmTextPosition from_pos, XmTextPosition to_pos, char* value) {
    XmTextFieldReplace(widget,from_pos,to_pos,value);
}

TNK_EXPORT void XmTextFieldSetAddMode_TNK(Widget widget, Boolean state) {
    XmTextFieldSetAddMode(widget,state);
}

TNK_EXPORT void XmTextFieldSetEditable_TNK(Widget widget, Boolean editable) {
    XmTextFieldSetEditable(widget,editable);
}

TNK_EXPORT void XmTextFieldSetHighlight_TNK(Widget widget, XmTextPosition left, XmTextPosition right, XmHighlightMode mode) {
    XmTextFieldSetHighlight(widget,left,right,mode);
}

TNK_EXPORT void XmTextFieldSetInsertionPosition_TNK(Widget widget, XmTextPosition position) {
    XmTextFieldSetInsertionPosition(widget,position);
}

TNK_EXPORT void XmTextFieldSetMaxLength_TNK(Widget widget, int max_length) {
    XmTextFieldSetMaxLength(widget,max_length);
}

TNK_EXPORT void XmTextFieldSetSelection_TNK(Widget widget, XmTextPosition first, XmTextPosition last, Time time) {
    XmTextFieldSetSelection(widget,first,last,time);
}

TNK_EXPORT void XmTextFieldSetString_TNK(Widget widget, char* value) {
    XmTextFieldSetString(widget,value);
}

TNK_EXPORT void XmTextFieldShowPosition_TNK(Widget widget, XmTextPosition position) {
    XmTextFieldShowPosition(widget,position);
}

TNK_EXPORT XmTextPosition XmTextFieldXYToPos_TNK(Widget widget, Position x, Position y) {
    return XmTextFieldXYToPos(widget,x,y);
}

/**
* List API
*/

TNK_EXPORT void XmListAddItem_TNK(Widget widget, XmString item, int position) {
    XmListAddItem(widget,item,position);
}

TNK_EXPORT void XmListAddItems_TNK(Widget widget, XmString* items, int item_count, int position) {
    XmListAddItems(widget,items,item_count,position);
}

TNK_EXPORT void XmListAddItemsUnselected_TNK(Widget widget, XmString* items, int item_count, int position) {
    XmListAddItemsUnselected(widget,items,item_count,position);
}

TNK_EXPORT void XmListAddItemUnselected_TNK(Widget widget, XmString item, int position) {
    XmListAddItemUnselected(widget,item,position);
}

TNK_EXPORT void XmListDeleteAllItems_TNK(Widget widget) {
    XmListDeleteAllItems(widget);
}

TNK_EXPORT void XmListDeleteItem_TNK(Widget widget, XmString item) {
    XmListDeleteItem(widget,item);
}

TNK_EXPORT void XmListDeleteItems_TNK(Widget widget, XmString* items, int item_count) {
    XmListDeleteItems(widget,items,item_count);
}

TNK_EXPORT void XmListDeleteItemsPos_TNK(Widget widget, int item_count, int position) {
    XmListDeleteItemsPos(widget,item_count,position);
}

TNK_EXPORT void XmListDeletePos_TNK(Widget widget, int position) {
    XmListDeletePos(widget,position);
}

TNK_EXPORT void XmListDeletePositions_TNK(Widget widget, int* position_list, int position_count) {
    XmListDeletePositions(widget,position_list,position_count);
}

TNK_EXPORT void XmListDeselectAllItems_TNK(Widget widget) {
    XmListDeselectAllItems(widget);
}

TNK_EXPORT void XmListDeselectItem_TNK(Widget widget, XmString item) {
    XmListDeselectItem(widget,item);
}

TNK_EXPORT void XmListDeselectPos_TNK(Widget widget, int position) {
    XmListDeselectPos(widget,position);
}

TNK_EXPORT int XmListGetKbdItemPos_TNK(Widget widget) {
    return XmListGetKbdItemPos(widget);
}

TNK_EXPORT Boolean XmListGetMatchPos_TNK(Widget widget, XmString item, int** position_list, int* position_count) {
    return XmListGetMatchPos(widget,item, position_list,position_count);
}

TNK_EXPORT Boolean XmListGetSelectedPos_TNK(Widget widget, int** position_list, int* position_count) {
    return XmListGetSelectedPos(widget, position_list, position_count);
}

TNK_EXPORT Boolean XmListItemExists_TNK(Widget widget, XmString item) {
    return XmListItemExists(widget,item);
}

TNK_EXPORT int XmListItemPos_TNK(Widget widget, XmString item) {
    return XmListItemPos(widget,item);
}

TNK_EXPORT Boolean XmListPosSelected_TNK(Widget widget, int position) {
    return XmListPosSelected(widget,position);
}

TNK_EXPORT Boolean XmListPosToBounds_TNK(Widget widget, int position, Position* x, Position* y, Dimension* width, Dimension* height) {
    return XmListPosToBounds(widget,position,x,y,width,height);
}

TNK_EXPORT void XmListReplaceItems_TNK(Widget widget, XmString* old_items, int item_count, XmString* new_items) {
    XmListReplaceItems(widget,old_items,item_count,new_items);
}

TNK_EXPORT void XmListReplaceItemsPos_TNK(Widget widget, XmString* new_items, int item_count, int position) {
    XmListReplaceItemsPos(widget,new_items,item_count,position);
}

TNK_EXPORT void XmListReplaceItemsPosUnselected_TNK(Widget widget, XmString* new_items, int item_count, int position) {
    XmListReplaceItemsPosUnselected(widget,new_items,item_count,position);
}

TNK_EXPORT void XmListReplaceItemsUnselected_TNK(Widget widget, XmString* old_items, int item_count, XmString* new_items) {
    XmListReplaceItemsUnselected(widget,old_items,item_count,new_items);
}

TNK_EXPORT void XmListReplacePositions_TNK(Widget widget, int* position_list, XmString* item_list, int item_count) {
    XmListReplacePositions(widget,position_list,item_list,item_count);
}

TNK_EXPORT void XmListSelectItem_TNK(Widget widget, XmString item, Boolean notify) {
    XmListSelectItem(widget,item,notify);
}

TNK_EXPORT void XmListSelectPos_TNK(Widget widget, int position, Boolean notify) {
    XmListSelectPos(widget,position,notify);
}

TNK_EXPORT void XmListSetAddMode_TNK(Widget widget, Boolean state) {
    XmListSetAddMode(widget,state);
}

TNK_EXPORT void XmListSetBottomItem_TNK(Widget widget, XmString item) {
    XmListSetBottomItem(widget,item);
}

TNK_EXPORT void XmListSetBottomPos_TNK(Widget widget, int position) {
    XmListSetBottomPos(widget,position);
}

TNK_EXPORT void XmListSetHorizPos_TNK(Widget widget, int position) {
    XmListSetHorizPos(widget,position);
}

TNK_EXPORT void XmListSetItem_TNK(Widget widget, XmString item) {
    XmListSetItem(widget,item);
}

TNK_EXPORT Boolean XmListSetKbdItemPos_TNK(Widget widget, int position) {
    return XmListSetKbdItemPos(widget,position);
}

TNK_EXPORT void XmListSetPos_TNK(Widget widget, int position) {
    XmListSetPos(widget,position);
}

TNK_EXPORT void XmListUpdateSelectedList_TNK(Widget widget) {
    XmListUpdateSelectedList(widget);
}

TNK_EXPORT int XmListYToPos_TNK(Widget widget, Position y) {
    return XmListYToPos(widget,y);
}

//
TNK_DECLARE_END

