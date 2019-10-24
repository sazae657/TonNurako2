#include <Xm/XmAll.h>
#include <X11/Xlib.h>
#include <X11/Intrinsic.h>
#include <stdio.h>
#include <string.h>
#include <AssertMacros.h>
#if defined(__nullable)
# undef __nullable
#endif
static void
XtTestDC(Widget widget, XtPointer client_data, XtPointer call_data)
{
    XtAppSetExitFlag((XtAppContext)client_data);
}

int
XtTest(int argc, char** argv)
{
    Widget toplevel;
    Display* display;
    XtAppContext context;
    Widget form, label, label1, label2, button;
    Screen* screen;
    String swap;

    if (NULL == (swap = strrchr(argv[0], '/'))) {
        swap = argv[0];
    }
    else {
        swap++;
    }

    context = XtCreateApplicationContext();

    display = XtOpenDisplay(
        context, NULL, NULL, NULL, NULL, 0, &argc, argv);
    if (NULL == display) {
        return 0;
    }
    screen = XDefaultScreenOfDisplay(display);

    toplevel = XtVaAppCreateShell("k",
                    "XtTest", applicationShellWidgetClass, display,
                    XtNtitle, swap,
                    XtNx, (screen->width /3),
                    XtNy, (screen->height /3),
                    NULL
                    );
    if (NULL == toplevel) {
        return -2;
    }

    if (3 != argc) {
        form = XtVaCreateManagedWidget("form", xmFormWidgetClass, toplevel,
            XmNhorizontalSpacing, 5,
            XmNmarginHeight, 10,
            XmNmarginWidth, 10,
            NULL
        );

        label = XtVaCreateManagedWidget("label", xmLabelGadgetClass, form,
            XmNlabelString, XmStringCreateLocalized("Usage"),
            XmNalignment, XmALIGNMENT_BEGINNING,
            XmNtopAttachment, XmATTACH_FORM,
            XmNleftAttachment, XmATTACH_FORM,
            XmNrightAttachment, XmATTACH_FORM,
            NULL
        );

        label1 = XtVaCreateManagedWidget("label1", xmLabelGadgetClass, form,
            XmNlabelString, XmStringCreateLocalized(swap),
            XmNtopAttachment, XmATTACH_WIDGET,
            XmNtopWidget, label,
            XmNleftAttachment, XmATTACH_FORM,
            XmNbottomAttachment, XmATTACH_FORM,
            NULL
        );

        label2 = XtVaCreateManagedWidget("label2", xmLabelGadgetClass, form,
            XmNlabelString, XmStringCreateLocalized(": arg1 arg2"),
            XmNtopAttachment, XmATTACH_WIDGET,
            XmNtopWidget, label,
            XmNleftAttachment, XmATTACH_WIDGET,
            XmNleftWidget, label1,
            XmNbottomAttachment, XmATTACH_FORM,
            NULL);

        button = XtVaCreateManagedWidget("button", xmPushButtonWidgetClass, form,
            XmNlabelString, XmStringCreateLocalized("Close"),
            XmNtopAttachment, XmATTACH_WIDGET,
            XmNtopWidget, label,
            XmNleftAttachment, XmATTACH_WIDGET,
            XmNleftWidget, label2,
            XmNbottomAttachment, XmATTACH_FORM,
            XmNrightAttachment, XmATTACH_FORM,
            NULL);
        XtAddCallback(button, XmNactivateCallback, XtTestDC, context);

        XtRealizeWidget(toplevel);
        XtAppMainLoop(context);
    }
    XtDestroyWidget(toplevel);
    XtDestroyApplicationContext(context);
    return 0;
}

int
AkefileTest(const char* __nullable, size_t offset)
{
    char path[1024];
    FILE* fp;
    char csv = 0x41;

    memset(path, 0x00, sizeof(path));
    strncpy(path, __nullable, strlen(__nullable));

    for (csv = 0x41; csv < 0x5b; csv++) {
        path[offset] = csv;
        if (NULL == (fp = fopen(path, "w"))) {
            fprintf(stderr, "Open FAILED<%s> sig=%c\n", path, (char)csv);
            return -1;
        }
        if (strlen(path) != fwrite((const void*)path, sizeof(char), strlen(path), fp)) {
            fprintf(stderr, "Write FAILED<%s> sig=%c\n", path, (char)csv);
            return -2;
        }
        fclose(fp);
    }
    return 0;
}
