# -*- coding: utf-8 -*-
import sys
import re
import os

IMP=re.compile(r'EntryPoint(\s+)?=(\s+)?"[a-zA-Z0-9]+_TNK"')

def collect(file):
    k = open(file,'rt')
    lines = k.readlines()
    k.close()
    kumment = False
    for v in lines:
        s = re.search(IMP, v)
        if not s:
            continue

        c = s.group()
        p = c.find('"')+1
        cc = v.find('//')
        if cc > 0 and cc < s.start():
            continue

        sym=c[p:c.find('"',p)]
        yield sym

def oppai(directory):
    for root, dirs, files in os.walk(directory):
        yield root
        for file in files:
            yield os.path.join(root, file)

for a in sys.argv:
    for file in oppai(a):
        if file.endswith('.cs'):
            for r in collect(file):
                print(r)

