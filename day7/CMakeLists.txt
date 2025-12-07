cmake_minimum_required(VERSION 3.15)
project(Day7 VERSION 1.0.0 LANGUAGES CXX)

# Set C++ standard
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)

# Add common source files
set(COMMON_SOURCES

)

# Add common header files
set(COMMON_HEADERS

)

# Include directories
include_directories(${PROJECT_SOURCE_DIR}/src)

# Server executable
add_executable(main
    src/main.cpp
    ${COMMON_SOURCES}
)

target_compile_options(main PRIVATE -Wall -Wextra -Wpedantic)

# Optional: Link libraries (uncomment and modify as needed)
# find_package(Threads REQUIRED)
# target_link_libraries(server PRIVATE Threads::Threads)
# target_link_libraries(client PRIVATE Threads::Threads)

# Optional: Set output directories
set_target_properties(main PROPERTIES
    RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin
)

# Installation rules
install(TARGETS main
    RUNTIME DESTINATION bin
)