#include <X11/extensions/shape.h>

int main(argc, argv)
	int argc;
	char **argv;
{
	XShapeQueryExtension(NULL, NULL, NULL);
	return 0;
}

