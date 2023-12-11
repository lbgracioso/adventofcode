cmake_minimum_required(VERSION 3.26)
project(cpp)

set(CMAKE_CXX_STANDARD 20)

include(cmake/CPM.cmake)
CPMAddPackage("gh:fmtlib/fmt#10.1.1")
CPMAddPackage("gh:CLIUtils/CLI11@2.3.2")

add_executable(cpp main.cpp
        utils/Global.h
        utils/Runner.cpp
        utils/Runner.h
        2023/Day01/Day01.cpp
        utils/Advent.h
        2023/Advent2023.h
        utils/Problem.h
        utils/template/Day0X.cpp
        2023/Day02/Day02.h
        2023/Day02/Day02.cpp)

target_link_libraries(cpp fmt CLI11)