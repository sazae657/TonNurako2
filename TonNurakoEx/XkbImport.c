#include "TonNurako.h"
TNK_EXPORT KeySym XkbKeycodeToKeysym_TNK(Display *dpy, KeyCode kc, unsigned int group, unsigned int level) {
    return XkbKeycodeToKeysym (dpy, kc, group, level); 
}
