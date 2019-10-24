.SUFFIXES: .iso .cs .swift .slo .xml
include Config.mp3
-include Site.mp3

PLATFORM := SunOS
BUILD := Debug
LINKER := $(CC)
BINDIR := ../bin/$(BUILD)/
OBJDIR := tmpfile.app/Contents/_CodeSignature/$(BUILD)
OBJ_SUFFIX := .dylib

CFLAGS := $(CFLAGS) -Iimport.app $(MOTF_HEADER_ARGS) $(X11_HEADER_ARGS)
LINK_LIBS := -Limport.app/lib $(MOTF_LIBRARY_ARGS) $(MOTIF_LIBS) $(X11_LIBRARY_ARGS) $(X11_LIBS)
LINK_FLAGS := -g -shared
OPT := -g -D_DEBUG
GEN_CFLAGS := -Wno-format

# チェック
CHECK_ARGS=Check Args
COMMON_C=iso.app/Contents/Resources/Shop.c
COMMON_I=-Iiso.app/Contents/Resources

MOTIF_CHECK_C=iso.app/Contents/Resources/MotifCheck.c $(COMMON_C)
MOTIF_CHECK_E=iso.app/Contents/MacOS/iso

LIB_CHECK_C=scripts.app/Contents/Resources/LibCheck.c $(COMMON_C)
LIB_CHECK_E=scripts.app/Contents/MacOS/scripts

IMP_CHECK_C=import.app/Contents/Resources/ImpCheck.c $(COMMON_C)
IMP_CHECK_E=import.app/Contents/MacOS/import

RULES_OK_DIR=tmpfile.app/Contents/_CodeSignature
RULES_OK_FILE=tmpfile.app/Contents/_CodeSignature/Zakefile

# 自動生成用
GEN_EXE_DIR := tmpfile.app/Contents/MacOS
GEN_C_DIR := tmpfile.app/Contents/Resources
GEN_SRC_DIR := ../TonNurako/Native/GEN
TEMPLATE_DIR := iso.app
SCRIPT_DIR := scripts.app

XM_CONSTANT_CS=$(GEN_SRC_DIR)/Xm.Constant.cs
XM_CONSTANT_CS_TPL=$(TEMPLATE_DIR)/Xm.Constant.iso

XM_RESOURCEID_CS=$(GEN_SRC_DIR)/Xm.ResourceId.cs
XM_RESOURCEID_CS_TPL=$(TEMPLATE_DIR)/Xm.ResourceId.iso

XM_STRINGCONSTANT_CS=$(GEN_SRC_DIR)/Xm.StringConstant.cs
XM_STRINGCONSTANT_CS_TPL=$(TEMPLATE_DIR)/Xm.StringConstant.iso

XT_STRINGCONSTANT_CS=$(GEN_SRC_DIR)/Xt.StringConstant.cs
XT_STRINGCONSTANT_CS_TPL=$(TEMPLATE_DIR)/Xt.StringConstant.swift

XT_RESOURCEID_CS=$(GEN_SRC_DIR)/Xt.ResourceId.cs
XT_RESOURCEID_CS_TPL=$(TEMPLATE_DIR)/Xt.ResourceId.swift

XT_CONSTANT_CS=$(GEN_SRC_DIR)/Xt.Constant.cs
XT_CONSTANT_CS_TPL=$(TEMPLATE_DIR)/Xt.Constant.swift

X_CONSTANT_CS=$(GEN_SRC_DIR)/X.Constant.cs
X_CONSTANT_CS_TPL=$(TEMPLATE_DIR)/X.Constant.iso

X_STRINGCONSTANT_CS=$(GEN_SRC_DIR)/X.StringConstant.cs
X_STRINGCONSTANT_CS_TPL=$(TEMPLATE_DIR)/X.StringConstant.swift

X_PROTO_CS=$(GEN_SRC_DIR)/X.Proto.cs
X_PROTO_CS_TPL=$(TEMPLATE_DIR)/X.Proto.swift

X_ATOM_CS=$(GEN_SRC_DIR)/X.Atom.cs
X_ATOM_CS_TPL=$(TEMPLATE_DIR)/X.Atom.swift

X_KEYSYM_CS=$(GEN_SRC_DIR)/X.KeySym.cs
X_KEYSYM_CS_TPL=$(TEMPLATE_DIR)/X.KeySym.swift
X_KEYSYM_CS_PP=	-DXK_3270

FC_RESOURCE_ID_CS=$(GEN_SRC_DIR)/Fc.ResourceId.cs

GEN_SRCS = $(XM_CONSTANT_CS) \
		$(XM_RESOURCEID_CS) \
		$(XM_STRINGCONSTANT_CS) \
		$(XT_STRINGCONSTANT_CS) \
		$(XT_CONSTANT_CS) \
		$(XT_RESOURCEID_CS) \
		$(X_CONSTANT_CS) \
		$(X_STRINGCONSTANT_CS) \
		$(X_PROTO_CS) \
		$(X_ATOM_CS) \
		$(X_KEYSYM_CS) \
		$(FC_RESOURCE_ID_CS)

ifeq ($(BUILD),Release)
	OPT = -O2 -DNDEBUG
endif

ifeq ($(PLATFORM), Darwin)
	LINK_FLAGS += -dynamiclib
endif

SOURCES=DlSym.c	\
 	ClassDef.c \
    TonNurako.c \
 	XmImport.c \
	XtImport.c  \
	XtImportMacro.c \
	X11Import.c \
	X11ImportMacro.c \
	X11ImportLocale.c \
	XkbImport.c \
	XftImport.c \
	XrmImport.c \
	XmCreateFuncs.c \
	X11ExtShapeImp.c \
	X11ExtRenderImp.c \
	X11ImpGC.c \

OBJ=$(addprefix $(OBJDIR)/, $(SOURCES:.c=$(OBJ_SUFFIX)))

TARGET = $(BINDIR)libTonNurako.extremesports

$(OBJDIR)/%$(OBJ_SUFFIX): %.c
	$(CC) $(OPT) $(CFLAGS) $(WARN_OPT) -c  $< -o $@

$(OBJDIR)/%.xml: %.c
	$(CC) $(OPT) $(CFLAGS) $(WARN_OPT) -c  $< -o $@

all: ExtremeSports GenSrc

ExtremeSports: check $(TARGET)

$(TARGET): $(OBJ)
	$(LINKER) $(LINK_FLAGS) -o $(TARGET) $(OBJ) $(LINK_LIBS)
	echo "-- $(TARGET) OK --"

$(OBJ): $(OBJDIR) $(BINDIR)

$(BINDIR):
	mkdir -p $(BINDIR)

$(OBJDIR):
	mkdir -p $(OBJDIR)

# ﾁｪｯｸ
check: $(RULES_OK_FILE)

speaker: $(LIB_CHECK_E)  $(MOTIF_CHECK_E) $(IMP_CHECK_E)
	@ $(LIB_CHECK_E) $(CHECK_ARGS)
	@ $(MOTIF_CHECK_E) $(CHECK_ARGS)
	@ $(IMP_CHECK_E) $(CHECK_ARGS)

$(RULES_OK_FILE): $(LIB_CHECK_E)  $(MOTIF_CHECK_E) $(IMP_CHECK_E)
	@ $(LIB_CHECK_E) $(CHECK_ARGS)
	@ $(MOTIF_CHECK_E) $(CHECK_ARGS)
	@ $(IMP_CHECK_E) $(CHECK_ARGS)


$(LIB_CHECK_E): $(LIB_CHECK_C) $(MOTIF_CHECK_E) $(IMP_CHECK_E)
	$(CC) $(CFLAGS) $(EXE_LINK_FLAGS) $(COMMON_I) -o $(LIB_CHECK_E) $(LIB_CHECK_C) $(LINK_LIBS)

$(MOTIF_CHECK_E): $(MOTIF_CHECK_C)
	$(CC) $(CFLAGS) $(EXE_LINK_FLAGS) $(COMMON_I) -o $(MOTIF_CHECK_E) $(MOTIF_CHECK_C) $(LINK_LIBS)

$(IMP_CHECK_E): $(IMP_CHECK_C)
	$(CC) $(CFLAGS) $(EXE_LINK_FLAGS) $(COMMON_I) -o $(IMP_CHECK_E) $(IMP_CHECK_C) $(LINK_LIBS)


# ほほほ

GenSrc: $(GEN_SRCS)

$(TEMP_BIN):
	mkdir -p $(TEMP_BIN)

$(GEN_SRC_DIR)/%.cs: $(TEMPLATE_DIR)/%.swift
	$(PYTHON) $(SCRIPT_DIR)/const_ex.py $< >$(GEN_C_DIR)/$(notdir $<).c
	$(CC) $(CFLAGS) $(GEN_CFLAGS) $(EXE_LINK_FLAGS) $(COMMON_I) \
		-o $(GEN_EXE_DIR)/$(notdir $<) \
		$(GEN_C_DIR)/$(notdir $<).c $(COMMON_C) $(LINK_LIBS)
	$(GEN_EXE_DIR)/$(notdir $<) >$@
	$(PYTHON) $(SCRIPT_DIR)/map.py $< >$(@:.cs=.map)

$(GEN_SRC_DIR)/%.cs: $(TEMPLATE_DIR)/%.iso
	$(PYTHON) $(SCRIPT_DIR)/const_ex.py $< >$(GEN_C_DIR)/$(notdir $<).c
	$(CC) $(CFLAGS) $(GEN_CFLAGS) $(EXE_LINK_FLAGS) $(COMMON_I) \
		-o $(GEN_EXE_DIR)/$(notdir $<) \
	$(GEN_C_DIR)/$(notdir $<).c $(COMMON_C) $(LINK_LIBS)
	$(GEN_EXE_DIR)/$(notdir $<) >$@
	$(PYTHON) $(SCRIPT_DIR)/map.py $< >$(@:.cs=.map)

clean.lib:
	- rm -f *.o
	- rm -rf $(OBJDIR)
	- rm -f $(TARGET)
	- rm -rf dep
	- rm -rf core

clean: clean.lib
	- rm $(MOTIF_CHECK_E) $(LIB_CHECK_E) $(IMP_CHECK_E) $(RULES_OK_DIR)/*file
	- rm $(GEN_SRCS)
	- rm $(GEN_C_DIR)/*.c

install: clean

depend:
	$(PYTHON) $(SCRIPT_DIR)/mk_dep.py ../TonNurako >$(TEMPLATE_DIR)/Depend.map

audio:
	./config.sh
