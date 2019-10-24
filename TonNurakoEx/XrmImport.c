#include "TonNurako.h"

TNK_EXPORT XrmDatabase XrmGetFileDatabase_TNK(char* filename) {
    return XrmGetFileDatabase(filename);
}
TNK_EXPORT void XrmPutFileDatabase_TNK(XrmDatabase database, char* stored_db) {
    XrmPutFileDatabase(database,stored_db);
}
TNK_EXPORT XrmDatabase XrmGetStringDatabase_TNK(char* data) {
    return XrmGetStringDatabase(data);
}
TNK_EXPORT XrmDatabase XrmGetDatabase_TNK(Display* display) {
    return XrmGetDatabase(display);
}
TNK_EXPORT void XrmSetDatabase_TNK(Display* display, XrmDatabase database) {
    XrmSetDatabase(display,database);
}
TNK_EXPORT void XrmDestroyDatabase_TNK(XrmDatabase database) {
    XrmDestroyDatabase(database);
}

TNK_EXPORT void XrmMergeDatabases_TNK(XrmDatabase source_db, XrmDatabase target_db) {
    XrmMergeDatabases(source_db,&target_db);
}
TNK_EXPORT void XrmCombineDatabase_TNK(XrmDatabase source_db, XrmDatabase target_db, Bool override) {
    XrmCombineDatabase(source_db,&target_db,override);
}
TNK_EXPORT Status XrmCombineFileDatabase_TNK(char* filename, XrmDatabase target_db, Bool override) {
    return XrmCombineFileDatabase(filename,&target_db,override);
}

