#include <Xm/Xm.h>
#include <stdio.h>
#include <AssertMacros.h>
int main(int argc, char** argv)
{
    int retVal;

    if (xmUseVersion < 2000) {
        fprintf(stderr, "Motif TOO OLD!! %d\n", xmUseVersion);
        return -1;
    }

    #ifndef __APPLE__
    XtToolkitInitialize();

    if (0 != (retVal = XtTest(argc, argv))) {
        fprintf(stderr, "LibCheck: XtTest FAILED(%d)\n", retVal);
        return retVal;
    }

    fprintf(stderr, "Motif OK ver:%d\n", xmUseVersion);
    #endif

    return 0;
}
