#!/bin/bash
cwd=$(dirname $0)
echo $cwd
SITE_MP3="${cwd}/Site.mp3"

export KWD=${cwd}
export RULES_OK="${KWD}/check.localized/rules.ok"
export RULES_INC="${KWD}/check.localized/rules.inc"
export RULES_LIB="${KWD}/check.localized/rules.lib"

function cleanup {
	rm -f ${RULES_OK} ${RULES_INC} ${RULES_LIB} ${KWD}/a.out ${KWD}/*.o
}

function error_exit {
	echo "**  $@ ***"
	cleanup
	rm ${SITE_MP3}
	exit 9
}

OS=$(uname -s)
if [ -f "${KWD}/check.localized/Template_${OS}.mp3" ];then
	cp ${KWD}/check.localized/Template_${OS}.mp3 ${SITE_MP3}
else
	cp ${KWD}/check.localized/Template.mp3 ${SITE_MP3}
fi

SITE_MP3=${SITE_MP3} ${KWD}/check.localized/find_Xlib.sh || error_exit "Xlibが見つからないよう"
SITE_MP3=${SITE_MP3} ${KWD}/check.localized/find_Motif.sh || error_exit "Motifが見つからないよう"

echo
echo "-- AUDIO OK --"
echo
cleanup
