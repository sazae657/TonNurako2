#include <X11/extensions/Xrender.h>

int main(argc, argv)
	int argc;
	char **argv;
{
	XRenderQueryExtension(NULL, NULL, NULL);
	return 0;
}

