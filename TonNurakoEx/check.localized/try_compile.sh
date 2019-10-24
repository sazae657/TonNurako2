#!/bin/bash
PREFIX=(
"/usr"
"/usr/dt"
"/usr/openwin"
"/usr/ccs"
"/usr/ucb"
"/usr/local"
"/opt"
"/opt/oresama"
"/opt/local"
)

LIBDIR=(
"@"
"lib"
"lib64"
"lib/amd64"
"lib/sparcv9"
"lib/i386"
)

#RULES_OK="check.localized/rules.ok"
#RULES_INC="check.localized/rules.inc"
#RULES_LIB="check.localized/rules.lib"

rm -f ${RULES_OK}
rm -f ${RULES_INC}
rm -f ${RULES_LIB}

if [ ! -f "${TSRC}" ];then
   echo "<${TSRC}> がないよう"
   exit 9
fi

if [ "x" = "x${TLIB}" ];then
   echo "TLIB がないよう"
   exit 9
fi

FOUND_INC=""
FOUND_LIB=""
FK="NO"
for K in ${PREFIX[@]}
do
	#echo "PP $K"
	PP="-I${K}/include ${AIPP}"
	#echo "try ${PP}"
	cc -c -o ${KWD}/o.o ${PP} ${TSRC}  || continue
	FOUND_INC="-I${K}/include"
	#echo "LD $K"
	FK="NO"
	for W in ${LIBDIR[@]}
	do
		LL=""
		if [ "x@" != "x${W}" ];then
			LL="-L${K}/${W}"
		fi
		#echo "try ${LL}"
		cc -o ${KWD}/a.out ${PP} ${TSRC} ${LL} ${TLIB}  || continue
		if [ "x@" != "x${W}" ];then
			FOUND_LIB="-L${K}/${W}"
		fi
		FK="YES"
		break
	done
	if [ "xYES" = "x${FK}" ];then
		break
	fi
done
if [ "xYES" != "x${FK}" ];then
	exit 9
fi

echo ${FK} >${RULES_OK}

echo ${FOUND_INC} >${RULES_INC}
echo "${FOUND_LIB} ${TLIB}" >${RULES_LIB}
exit 0

