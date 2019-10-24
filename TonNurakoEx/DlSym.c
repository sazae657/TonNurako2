#ifdef __TNK_PORT_WINDOWS__
#   include <stdio.h>
#	include <windows.h>
#   include <stdarg.h>
#else
#	include "TonNurako.h"
#	include <dlfcn.h>
static const char LLES[]="ﾄﾝﾇﾗｺ";
#endif

#ifdef WIN32

void
XTRACE(FILE* fd, LPCTSTR lpszFormat, ...)
{
    va_list args;
    va_start(args, lpszFormat);
    int nBuf;
    char szBuffer[512];
    memset(szBuffer, 0x00, sizeof(szBuffer));

    nBuf = vsnprintf(szBuffer, 511, lpszFormat, args);
    if(0 != nBuf) {
        OutputDebugString(szBuffer);
    }
    va_end(args);

}

BOOL WINAPI DllMain(HINSTANCE hinstDll, DWORD dwReason, LPVOID lpReserved) {
    CONS25W(stderr, "DllMain call\n");
	return TRUE;
}

#endif

void* LoadLibraryExtremeSports(const char* fn) {
	#ifdef WIN32
	return (void*)LoadLibrary(fn);
	#else
    return (void*)LLES;
	#endif
}

void FreeLibraryExtremeSports(const void* handle) {
	#ifdef WIN32
	FreeLibrary((HMODULE)handle);
	#endif
}

void* GetProcAddressExtremeSports(const void* handle, const char* fn) {
	#ifdef WIN32
    CONS25W(stderr, "GetProcAddressExtremeSports:<%p> %s\n", handle, fn);
	return GetProcAddress((HINSTANCE)handle, fn);
	#else
    return dlsym(RTLD_DEFAULT, fn);
	#endif
}

