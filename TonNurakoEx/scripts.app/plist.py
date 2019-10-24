# -*- coding: utf-8 -*-
import sys
import re

class ISO(object):
    def __init__(self):
        self.ns = None
        self.cn = None
        self.bn = None
        self.ifdef = False
        self.format = '%d'
        self.type = 'enum'
        self.vt = None
        self.symbols = []
        self.includes = []
        self.usinges = []

    def Umount(self, p):
        xp = p.split(' ')
        if '.namespace' == xp[0]:
            self.ns = xp[1]
        elif '.class' == xp[0]:
            self.cn = xp[1]
        elif '.base'  == xp[0]:
            self.bn = xp[1]
        elif '.format'  == xp[0]:
            self.format = xp[1]
        elif '.ifdef'  == xp[0]:
            self.ifdef = True
        elif '.type'  == xp[0]:
            self.type = xp[1]       
        elif '.vt'  == xp[0]:
            self.vt = xp[1]                     
        elif '.include' == xp[0]:
            self.includes.append(xp[1])
        elif '.using' == xp[0]:
            self.usinges.append(xp[1])
        else:
            raise NameError('UNKNOWN PARAM: %s' % (p))

    def Mount(self, argv):
        for arg in argv:
            for line in open(arg, 'r'):
                p = line.strip()
                if not p:
                    continue
                
                if '.' == p[0]:
                    self.Umount(p);
                elif '#' != p[0]:
                    self.symbols.append(p)
