cmake_minimum_required(VERSION 3.10)

project(TonNurakoExtremeSports)
set(CMAKE_CONFIGURATION_TYPES "Debug;Release" CACHE STRING "limited configs" FORCE)
set(CMAKE_C_STANDARD 11)
set(CMAKE_CXX_STANDARD 11)
set(CMAKE_POSITION_INDEPENDENT_CODE ON)

file(GLOB s1 "${PROJECT_SOURCE_DIR}/*.cpp")
file(GLOB s2 "${PROJECT_SOURCE_DIR}/*.c")
list(APPEND tonnurako_sources ${s1} ${s2})

add_library(TonNurakoExtremeSports SHARED ${tonnurako_sources})

# python
find_package(Python REQUIRED)
set(BISON ${Python_EXECUTABLE})

# X11
find_package(X11 REQUIRED)

# Xt
if(NOT ${X11_Xt_FOUND})
    message(FATAL_ERROR "Xt Not Found")
endif()
include_directories(${X11_Xt_INCLUDE_PATH})
target_link_libraries(TonNurakoExtremeSports PRIVATE ${X11_Xt_LIB})

# Xft
if(NOT ${X11_Xft_FOUND})
    message(FATAL_ERROR "Xft Not Found")
endif()
include_directories(${X11_Xft_INCLUDE_PATH})
target_link_libraries(TonNurakoExtremeSports PRIVATE ${X11_Xft_LIB})

# Xft
if(NOT ${X11_Xft_FOUND})
    message(FATAL_ERROR "Xmu Not Found")
endif()
include_directories(${X11_Xmu_INCLUDE_PATH})
target_link_libraries(TonNurakoExtremeSports PRIVATE ${X11_Xmu_LIB})

# Xext
if(NOT ${X11_Xext_FOUND})
    message(FATAL_ERROR "Xext Not Found")
endif()
include_directories(${X11_Xext_INCLUDE_PATH})
target_link_libraries(TonNurakoExtremeSports PRIVATE ${X11_Xext_LIB})

# Xrender
if(NOT ${X11_Xrender_FOUND})
    message(FATAL_ERROR "Xrender Not Found")
endif()
include_directories(${X11_Xrender_INCLUDE_PATH})
target_link_libraries(TonNurakoExtremeSports PRIVATE ${X11_Xrender_LIB})

# Motif
find_package(Motif REQUIRED)
include_directories(${MOTIF_INCLUDE_DIR})
target_link_libraries(TonNurakoExtremeSports PRIVATE ${MOTIF_LIBRARIES})

# Ft
find_package(Fontconfig REQUIRED)
include_directories(${Fontconfig_INCLUDE_DIRS})
target_link_libraries(TonNurakoExtremeSports PRIVATE ${Fontconfig_LIBRARIES})

# FreeType

find_package(Freetype REQUIRED)
include_directories(${FREETYPE_INCLUDE_DIR_ft2build} ${FREETYPE_INCLUDE_DIR_freetype2})
target_link_libraries(TonNurakoExtremeSports PRIVATE ${FREETYPE_LIBRARIES})