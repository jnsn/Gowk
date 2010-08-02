
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=../..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/Gowk.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

STAGE_1_PNG_SOURCE=Data/64/stage-1.png
STAGE_2_PNG_SOURCE=Data/64/stage-2.png
STAGE_3_PNG_SOURCE=Data/64/stage-3.png
STAGE_4_PNG_SOURCE=Data/64/stage-4.png
STAGE_5_PNG_SOURCE=Data/64/stage-5.png
STAGE_6_PNG_SOURCE=Data/64/stage-6.png
STAGE_7_PNG_SOURCE=Data/64/stage-7.png
STAGE_8_PNG_SOURCE=Data/64/stage-8.png
COPYING_SOURCE=Data/COPYING
ICON_PNG_SOURCE=Data/icon.png
ANCULUS_CORE_DLL_SOURCE=../../lib/Anculus.Core.dll
GOWK_EXE_MDB_SOURCE=bin/Debug/Gowk.exe.mdb
GOWK_EXE_MDB=$(BUILD_DIR)/Gowk.exe.mdb

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/Gowk.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

STAGE_1_PNG_SOURCE=Data/64/stage-1.png
STAGE_2_PNG_SOURCE=Data/64/stage-2.png
STAGE_3_PNG_SOURCE=Data/64/stage-3.png
STAGE_4_PNG_SOURCE=Data/64/stage-4.png
STAGE_5_PNG_SOURCE=Data/64/stage-5.png
STAGE_6_PNG_SOURCE=Data/64/stage-6.png
STAGE_7_PNG_SOURCE=Data/64/stage-7.png
STAGE_8_PNG_SOURCE=Data/64/stage-8.png
COPYING_SOURCE=Data/COPYING
ICON_PNG_SOURCE=Data/icon.png
ANCULUS_CORE_DLL_SOURCE=../../lib/Anculus.Core.dll
GOWK_EXE_MDB=

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES_DATA_64 = \
	$(STAGE_1_PNG) \
	$(STAGE_2_PNG) \
	$(STAGE_3_PNG) \
	$(STAGE_4_PNG) \
	$(STAGE_5_PNG) \
	$(STAGE_6_PNG) \
	$(STAGE_7_PNG) \
	$(STAGE_8_PNG)  

PROGRAMFILES_DATA = \
	$(COPYING) \
	$(ICON_PNG)  

PROGRAMFILES = \
	$(ANCULUS_CORE_DLL) \
	$(GOWK_EXE_MDB)  

BINARIES = \
	$(GOWK)  


RESGEN=resgen2

STAGE_1_PNG = $(BUILD_DIR)/Data/64/stage-1.png
STAGE_2_PNG = $(BUILD_DIR)/Data/64/stage-2.png
STAGE_3_PNG = $(BUILD_DIR)/Data/64/stage-3.png
STAGE_4_PNG = $(BUILD_DIR)/Data/64/stage-4.png
STAGE_5_PNG = $(BUILD_DIR)/Data/64/stage-5.png
STAGE_6_PNG = $(BUILD_DIR)/Data/64/stage-6.png
STAGE_7_PNG = $(BUILD_DIR)/Data/64/stage-7.png
STAGE_8_PNG = $(BUILD_DIR)/Data/64/stage-8.png
COPYING = $(BUILD_DIR)/Data/COPYING
ICON_PNG = $(BUILD_DIR)/Data/icon.png
ANCULUS_CORE_DLL = $(BUILD_DIR)/Anculus.Core.dll
GOWK = $(BUILD_DIR)/gowk

FILES =  \
	AboutDialog.cs \
	AssemblyInfo.cs \
	gtk-gui/generated.cs \
	gtk-gui/Gowk.MainWindow.cs \
	Main.cs \
	MainWindow.cs \
	Security/CertificateValidation.cs \
	Services/SettingsService.cs \
	Services/TelemeterService.cs 

DATA_FILES = 

RESOURCES = gtk-gui/gui.stetic 

EXTRAS = \
	Security \
	Services \
	Data \
	Data/64 \
	Data/64/stage-1.png \
	Data/64/stage-2.png \
	Data/64/stage-3.png \
	Data/64/stage-4.png \
	Data/64/stage-5.png \
	Data/64/stage-6.png \
	Data/64/stage-7.png \
	Data/64/stage-8.png \
	Data/COPYING \
	Data/icon.png \
	gowk.in 

REFERENCES =  \
	../../lib/Anculus.Core.dll \
	Mono.Posix \
	-pkg:gconf-sharp-2.0 \
	-pkg:glade-sharp-2.0 \
	-pkg:glib-sharp-2.0 \
	-pkg:gtk-sharp-2.0 \
	-pkg:notify-sharp \
	System \
	System.Web.Services \
	System.Xml

DLL_REFERENCES =  \
	../../lib/Anculus.Core.dll

CLEANFILES = $(PROGRAMFILES_DATA_64) $(PROGRAMFILES_DATA) $(PROGRAMFILES) $(BINARIES) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES_DATA_64) $(PROGRAMFILES_DATA) $(PROGRAMFILES) $(BINARIES)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-target,STAGE_1_PNG))
$(eval $(call emit-deploy-target,STAGE_2_PNG))
$(eval $(call emit-deploy-target,STAGE_3_PNG))
$(eval $(call emit-deploy-target,STAGE_4_PNG))
$(eval $(call emit-deploy-target,STAGE_5_PNG))
$(eval $(call emit-deploy-target,STAGE_6_PNG))
$(eval $(call emit-deploy-target,STAGE_7_PNG))
$(eval $(call emit-deploy-target,STAGE_8_PNG))
$(eval $(call emit-deploy-target,COPYING))
$(eval $(call emit-deploy-target,ICON_PNG))
$(eval $(call emit-deploy-target,ANCULUS_CORE_DLL))
$(eval $(call emit-deploy-wrapper,GOWK,gowk,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64'
	$(call cp,$(STAGE_1_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call cp,$(STAGE_2_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call cp,$(STAGE_3_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call cp,$(STAGE_4_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call cp,$(STAGE_5_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call cp,$(STAGE_6_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call cp,$(STAGE_7_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call cp,$(STAGE_8_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)/Data'
	$(call cp,$(COPYING),$(DESTDIR)$(libdir)/$(PACKAGE)/Data)
	$(call cp,$(ICON_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data)
	$(call cp,$(ANCULUS_CORE_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(GOWK_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(bindir)'
	$(call cp,$(GOWK),$(DESTDIR)$(bindir))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(STAGE_1_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call rm,$(STAGE_2_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call rm,$(STAGE_3_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call rm,$(STAGE_4_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call rm,$(STAGE_5_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call rm,$(STAGE_6_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call rm,$(STAGE_7_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call rm,$(STAGE_8_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data/64)
	$(call rm,$(COPYING),$(DESTDIR)$(libdir)/$(PACKAGE)/Data)
	$(call rm,$(ICON_PNG),$(DESTDIR)$(libdir)/$(PACKAGE)/Data)
	$(call rm,$(ANCULUS_CORE_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(GOWK_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(GOWK),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
