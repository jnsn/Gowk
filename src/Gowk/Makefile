
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=../..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = ../../build/Debug/Gowk.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = ../../build/Debug

ICON_PNG_SOURCE=Resources/icon.png
GOWK_DESKTOP_SOURCE=gowk.desktop
GOWK_ICON_PNG_SOURCE=gowk-icon.png
ANCULUS_CORE_DLL_SOURCE=../../lib/Anculus.Core.dll
GOWK_EXE_MDB_SOURCE=../../build/Debug/Gowk.exe.mdb
GOWK_EXE_MDB=$(BUILD_DIR)/Gowk.exe.mdb

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = ../../build/Release/Gowk.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = ../../build/Release

ICON_PNG_SOURCE=Resources/icon.png
GOWK_DESKTOP_SOURCE=gowk.desktop
GOWK_ICON_PNG_SOURCE=gowk-icon.png
ANCULUS_CORE_DLL_SOURCE=../../lib/Anculus.Core.dll
GOWK_EXE_MDB=

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(ICON_PNG) \
	$(ANCULUS_CORE_DLL) \
	$(GOWK_EXE_MDB)  

LINUX_DESKTOPAPPLICATIONS = \
	$(GOWK_DESKTOP)  

COMMONAPPLICATIONDATAROOT = \
	$(GOWK_ICON_PNG)  

BINARIES = \
	$(GOWK)  


RESGEN=resgen2

ICON_PNG = $(BUILD_DIR)/icon.png
GOWK_DESKTOP = $(BUILD_DIR)/gowk.desktop
GOWK_ICON_PNG = $(BUILD_DIR)/gowk-icon.png
ANCULUS_CORE_DLL = $(BUILD_DIR)/Anculus.Core.dll
GOWK = $(BUILD_DIR)/gowk

FILES = \
	gtk-gui/generated.cs \
	Main.cs \
	AssemblyInfo.cs \
	Gowk.Security/CertificateValidation.cs \
	Gowk.Security/Crypter.cs \
	Gowk.Services/SettingsService.cs \
	Gowk.Services/TelemeterService.cs \
	Gowk.Gui/MainWindow.cs \
	gtk-gui/Gowk.Gui.MainWindow.cs \
	Gowk.Gui/AboutDialog.cs \
	Gowk.Services/UpdateMeterService.cs 

DATA_FILES = 

RESOURCES = \
	gtk-gui/gui.stetic \
	Resources/COPYING \
	Resources/icon.png \
	Resources/stage-1.png \
	Resources/stage-2.png \
	Resources/stage-3.png \
	Resources/stage-4.png \
	Resources/stage-5.png \
	Resources/stage-6.png \
	Resources/stage-7.png \
	Resources/stage-8.png \
	Resources/stage-9.png 

EXTRAS = \
	gowk.desktop \
	gowk-icon.png \
	gowk.in 

REFERENCES =  \
	System \
	-pkg:gtk-sharp-2.0 \
	-pkg:glib-sharp-2.0 \
	-pkg:glade-sharp-2.0 \
	Mono.Posix \
	-pkg:gconf-sharp-2.0 \
	System.Web.Services \
	System.Xml \
	-pkg:notify-sharp

DLL_REFERENCES =  \
	../../lib/Anculus.Core.dll

CLEANFILES = $(PROGRAMFILES) $(LINUX_DESKTOPAPPLICATIONS) $(COMMONAPPLICATIONDATAROOT) $(BINARIES) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_DESKTOPAPPLICATIONS) $(COMMONAPPLICATIONDATAROOT) $(BINARIES)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-target,ICON_PNG))
$(eval $(call emit-deploy-target,GOWK_DESKTOP))
$(eval $(call emit-deploy-target,GOWK_ICON_PNG))
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
	$(call cp,$(ICON_PNG),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(datadir)/applications'
	$(call cp,$(GOWK_DESKTOP),$(DESTDIR)$(datadir)/applications)
	mkdir -p '$(DESTDIR)$(datadir)'
	$(call cp,$(GOWK_ICON_PNG),$(DESTDIR)$(datadir))
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
	$(call rm,$(ICON_PNG),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(GOWK_DESKTOP),$(DESTDIR)$(datadir)/applications)
	$(call rm,$(GOWK_ICON_PNG),$(DESTDIR)$(datadir))
	$(call rm,$(ANCULUS_CORE_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(GOWK_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(GOWK),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
