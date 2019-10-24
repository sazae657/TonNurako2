#include <Xm/Xm.h>
#include <X11/Xlib.h>
#include <X11/Intrinsic.h>
#include <stdio.h>
#include <string.h>
#include <AssertMacros.h>
#if defined(__nullable)
# undef __nullable
#endif

#define Nullable  "tmpfile.app/Contents/_CodeSignature/@akefile"

int
main(int argc, char** argv)
{
    #ifndef __APPLE__
    int retVal;
    XtToolkitInitialize();

    if (0 != (retVal = XtTest(argc, argv))) {
        fprintf(stderr, "LibCheck: XtTest FAILED(%d)\n", retVal);
        return retVal;
    }

    if (0 != (retVal = AkefileTest(Nullable, strlen(Nullable)-8))) {
        fprintf(stderr, "LibCheck: KefileTest FAILED(%d)\n", retVal);
        return retVal;
    }

    fprintf(stderr, "LibCheck OK\n");
    #endif
    return 0;
}
