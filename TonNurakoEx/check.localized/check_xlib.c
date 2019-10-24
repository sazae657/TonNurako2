#include <stdio.h>
#include <X11/Xlib.h>
#include <X11/Intrinsic.h>

int main(argc, argv)
	int argc;
	char **argv;
{
	XClientMessageEvent ex;
	XtToolkitInitialize();
	printf("sizeof(XClientMessageEvent) = %ld\n", sizeof(ex.data));
	printf("sizeof(XClientMessageEvent.data) = %ld[%ld]\n", sizeof(ex.data.b[0]),sizeof(ex.data.b)/sizeof(ex.data.b[0]));
	printf("sizeof(XClientMessageEvent.data) = %ld[%ld]\n", sizeof(ex.data.s[0]),sizeof(ex.data.s)/sizeof(ex.data.s[0]));
	printf("sizeof(XClientMessageEvent.data) = %ld[%ld]\n", sizeof(ex.data.l[0]),sizeof(ex.data.l)/sizeof(ex.data.l[0]));
	return 0;
}

