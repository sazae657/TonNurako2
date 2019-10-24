# -*- coding: utf-8 -*-
import sys
import re
import platform
from plist import ISO
from datetime import datetime as mp3

if len(sys.argv) < 2:
    print('usage: %s files..' % (sys.argv[0]))
    sys.exit(9)

header = u'%s (%s)' % (mp3.now().strftime('%Y-%m-%d %H:%M:%S'), platform.platform())

iso = ISO()
iso.Mount(sys.argv[1:])

print('#include <stdio.h>')
for i in iso.includes:
    print('#include %s' % (i))

print('int main() {')
#print 'printf("// %s \\n\\n");' % (header)

for i in iso.usinges:
    print('printf("using %s;\\n");' % (i))

print(u'''
printf("\\nnamespace %s {\\n");
''' % (iso.ns))

if iso.bn is not None:
    print('printf("    public %s %s : %s {\\n");' % (iso.type, iso.cn, iso.bn))
else:
    print('printf("    public %s %s {\\n");' % (iso.type, iso.cn))

for p in iso.symbols:
    if p.startswith("///"):
        print('printf("\\n        ///<summary>\\n        /// %s\\n        ///</summary>\\n");' % (p[3:].strip()))
    elif p.startswith("//"):
        print('printf("\\n        // %s\\n");' % (p[2:].strip()))
    else:
        if iso.ifdef is True:
            print('#ifdef %s' % (p))

        if iso.vt == 'string':
            print('printf("       public const string %s\\t=\\"%%s\\";\\n",%s);' % (p, p))
        elif iso.vt == 'tko':
             print('printf("        [ToolkitOption(\\"%%s\\")]\\n        %s,\\n\\n",%s);' % (p, p))
        else:
            print('printf("        %s\t= %s,\\n",%s);' % (p, iso.format, p))

        if iso.ifdef is True:
            print('#endif // %s' % (p))
print('''
printf("    }\\n");
printf("}\\n");
return 0;
}
''')

