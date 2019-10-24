#!/bin/sh

LIBS=""
CFLAGS=""

XA=$(cat ${SITE_MP3} | grep X11_HEADER_ARGS | perl -pe 's/X11_HEADER_ARGS :=//')
XL=$(cat ${SITE_MP3} | grep X11_LIBS | perl -pe 's/X11_LIBS :=//')

TLIB="-lXm" AIPP=${XA} TSRC=${KWD}/check.localized/check_motif.c ${KWD}/check.localized/try_compile.sh
if [ ! -f ${RULES_OK} ];then
	echo "Motifがないよう"
	exit 9
fi
LIBS="${LIBS} $(cat ${RULES_LIB})"
CFLAGS="${CFLAGS} $(cat ${RULES_INC})"


cc ${CFLAGS} ${XA} ${KWD}/check.localized/check_motif.c -o ${KWD}/a.out ${LIBS} || exit 9

echo "Xm:LIBS=$LIBS"
echo "Xm:CFLAGS=$CFLAGS"
echo "-- Motif check OK --"

echo "MOTF_HEADER_ARGS := ${CFLAGS}" >>${SITE_MP3}
echo "MOTIF_LIBS := ${LIBS}" >>${SITE_MP3}

