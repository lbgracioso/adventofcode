#include <iostream>
#include <CLI/CLI.hpp>
#include "utils/Runner.h"
#include "utils/Global.h"

int main(int argc, char** argv) {
    CLI::App app {"Advent of Code"};

    app.add_option("-y,--year", global::year, "Run a specific Advent of Code year. If not specified, it'll run the last year.");
    app.add_option("-d,--day", global::day, "Run a specific Advent of Code day from a year. If not specified, it'll run all days from the -y flag.");

    CLI11_PARSE(app, argc, argv);

    try {
        Runner runner;
        if (global::day != 0)
            runner.solveAdvent(global::year, global::day);
        else
            runner.solveAdvent(global::year);
    } catch (std::exception& ex) {
        fmt::println("Something went wrong. Error message: {}", ex.what());
    }

    return 0;
}
