#ifndef _TONNURAKO_H_9F6F3F92_9548_4DBA_5927_805048C79EC1_
#define _TONNURAKO_H_9F6F3F92_9548_4DBA_5927_805048C79EC1_
#if !defined(_GNU_SOURCE)
#   define _GNU_SOURCE
#endif

#include <locale.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/utsname.h>

#include <X11/XKBlib.h>
#include <X11/Xlocale.h>

#include <X11/Intrinsic.h>
#include <X11/IntrinsicP.h>
#include <X11/Xmu/Editres.h>

#include <Xm/XmAll.h>
#include <Xm/ButtonBox.h>
#include <Xm/ColorS.h>
#include <Xm/FontS.h>
#include <Xm/DropDown.h>
#include <Xm/IconBox.h>
#include <Xm/MultiList.h>
#include <Xm/Outline.h>
#include <Xm/Tree.h>

#include <X11/Xft/Xft.h>
#include <X11/XKBlib.h>
#include <fontconfig/fontconfig.h>


#define TONNURAKO_EX_MAJOR_VERSION 1
#define TONNURAKO_EX_MINOR_VERSION 0

//ｴﾃﾞｨﾀのｵーﾄｲﾝﾃﾞﾝﾄが邪魔
#ifdef __cplusplus
#   define TNK_DECLARE_BEGIN extern "C" {
#   define TNK_DECLARE_END }
extern "C"{
#else
#   define TNK_DECLARE_BEGIN
#   define TNK_DECLARE_END
#endif

#ifdef __APPLE__
#   define GARBAGE_PLATFORM 1
#endif

#ifdef __TNK_PORT_WINDOWS__
    extern void XTRACE(FILE*, const char *format, ...);
#   define CONS25W XTRACE
#else
#   if (defined(TRADITIONAL_PRINTF_DEBUG))
#       define CONS25W fprintf
#       define CONS25_ENTER fprintf(stderr, "Enter %s\n", __func__)
#       define CONS25_LEAVE fprintf(stderr, "Leave %s\n", __func__)
#   else
#       define CONS25W(...)
#       define CONS25_ENTER
#       define CONS25_LEAVE
#   endif
#endif
#ifndef TNK_EXPORT
#   define TNK_EXPORT_NR
#   define TNK_EXPORT
#endif
typedef enum
tagTNK_CODE {
    TNK_OK          = 0,
    TNK_ALLOC_FAILED,
    TNK_ERR_CREATE_CONTEXT_FAILED,
    TNK_ERR_CANNOT_OPEN_DISPLAY,
}TNK_CODE;

/*----------------------------------------------------------------------------
ﾀﾞｻいﾌﾟﾘﾌﾟﾛｾｯｻ
-----------------------------------------------------------------------------*/
#ifndef XM_CREATE_ARG_IN
#define XM_CREATE_ARG_IN Widget parent, String name, ArgList arg , Cardinal argc
#endif

#ifndef XM_CREATE_ARG
#define XM_CREATE_ARG parent, name, arg , argc
#endif

#define TNK_ARRAY_SIZE(X) (sizeof(X)/sizeof(X[0]))
#define NSString(X) (sizeof(X))

/*----------------------------------------------------------------------------
"C"ｽﾀｲﾙのﾀﾞｻい関数群
-----------------------------------------------------------------------------*/

//AppContext周りの情報を格納する
typedef struct
_tagTNK_APP_CONTEXT{
	XtAppContext context;
    Display      *display;
    String       display_string;
    XtPointer    comm; // long
    Colormap     colormap; //int
} TNK_APP_CONTEXT, *LPTNK_APP_CONTEXT;

typedef enum
_tagRESOURCE_TYPE {
    TNK_RT_UNDEFINED = 0,
    TNK_RT_INT = 1,
    TNK_RT_UINT = 2,
    TNK_RT_LONG = 3,
    TNK_RT_ULONG = 4,
    TNK_RT_OBJECT = 5,
    TNK_RT_STRING = 6,
    TNK_RT_COMPOUND_STRING = 7,
    TNK_RT_XCOLOR = 8,
    TNK_RT_CALLBACK = 9
}TNK_RESOURCE_TYPE;

typedef struct
_tagTNK_RESOURCE {
    const char* name;
    TNK_RESOURCE_TYPE type;

    /* TODO: ここから下を共用体にしたいがちょっと出来ない */
    int intVal;
    uint uintVal;
    long longVal;
    unsigned long ulongVal;
    void* ptrVal;
    const char* strVal;
    XmString xmStr;
    Pixel   color;
    XtCallbackProc callback;
}TNK_RESOURCE, *LPTNK_RESOURCE_TYPE;

typedef struct
_tagTNK_COLOR_CONTEXT {
    XColor color;
}TNK_COLOR_CONTEXT, *LPTNK_COLOR_CONTEXT;

/* XClientMessageEvent 分離用　*/
typedef struct
_tagTNK_XClientMessageEventData
{
    XClientMessageEvent event;
    struct {
        char b[20];
        short s[10];
        long l[5];
    } data;
}TNK_XClientMessageEventData;

typedef union
_tagTNK_XClientMessageEventStudio
{
    char b[20];
    short s[10];
    long l[5];
}TNK_XClientMessageEventStudio;


typedef struct
_tagTNK_UtsnameStudio {
    struct _tagTNK_UtsnameStudio* _this;
    char* sysname;
    char* nodename;
    char* release;
    char* version;
    char* machine;
}TNK_UtsnameStudio;

#ifdef __cplusplus
}
#endif


#endif

