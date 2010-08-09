
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG_X86
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

if ENABLE_RELEASE_X86
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
	$(GOWK_DESKTOP) \
	$(GOWK_ICON_PNG) \
	$(ANCULUS_CORE_DLL) \
	$(GOWK_EXE_MDB)  

BINARIES = \
	$(GOWK)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES) 

FILES =  \
	AssemblyInfo.cs \
	Gowk.Gui/AboutDialog.cs \
	Gowk.Gui/MainWindow.cs \
	Gowk.Security/CertificateValidation.cs \
	Gowk.Security/Crypter.cs \
	Gowk.Services/SettingsService.cs \
	Gowk.Services/TelemeterService.cs \
	Gowk.Services/UpdateMeterService.cs \
	gtk-gui/generated.cs \
	gtk-gui/Gowk.Gui.MainWindow.cs \
	Main.cs 

DATA_FILES = 

RESOURCES =  \
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

EXTRAS =  \
	gowk.desktop \
	gowk-icon.png 

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

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

include $(top_srcdir)/Makefile.include

ICON_PNG = $(BUILD_DIR)/icon.png
GOWK_DESKTOP = $(BUILD_DIR)/gowk.desktop
GOWK_ICON_PNG = $(BUILD_DIR)/gowk-icon.png
ANCULUS_CORE_DLL = $(BUILD_DIR)/Anculus.Core.dll
GOWK = $(BUILD_DIR)/gowk

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
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
