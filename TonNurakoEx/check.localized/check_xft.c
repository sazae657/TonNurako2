#include <X11/Xft/Xft.h>

int main(argc, argv)
	int argc;
	char **argv;
{
	XftDefaultHasRender(NULL);
	XftLockFace(NULL);
	return 0;
}

