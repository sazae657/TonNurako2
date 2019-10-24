#include <fontconfig/fontconfig.h>

int main(argc, argv)
	int argc;
	char **argv;
{
	FcInit();
	FcFini();
	return 0;
}

