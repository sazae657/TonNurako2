# -*- coding: utf-8 -*-
import sys
import re
import platform
from plist import ISO
from datetime import datetime as mp3

if len(sys.argv) < 2:
    print('usage: %s files..' % (sys.argv[0]))
    sys.exit(9)

iso = ISO()
iso.Mount(sys.argv[1:])

for p in iso.symbols:
    if p.startswith("///"):
        print('printf("\\n        /// <summary>\\n/// %s\\n        /// </summary>\\n");' % (p[3:].strip()))
    elif p.startswith("//"):
        print('\n// %s' % (p[2:].strip()))
    else:
        print('%s = %s.%s.%s,' % (p, iso.ns, iso.cn, p))

