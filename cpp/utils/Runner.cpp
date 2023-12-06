#include <iostream>
#include <dlfcn.h> // for dynamic loading on Linux

#include "Runner.h"
#include "../2023/Advent2023.h"

void Runner::solveAdvent(const int year) {
    loadAdvent(year);

    for (const auto& problem : m_advent.getDays()) {
        formatDayResult(problem);
    }
}

void Runner::solveAdvent(const int year, const int day) {
    loadAdvent(year);
    formatDayResult(m_advent.getDay(day));
}

void Runner::formatDayResult(const std::unique_ptr<Problem> &problem) {
    auto partOne = problem->PartOne();
    auto partTwo = problem->PartTwo();

    fmt::println("Problem name: {}\nPart one: {}\nPart two: {} ", problem->getProblemName(), partOne, partTwo);
}

void Runner::loadAdvent(const int &year) {
    switch (year) {
        case 2023: {
            m_advent.setAllDays(std::make_unique<Advent2023>().get()->getDays());
            break;
        }
        default:
            throw std::runtime_error("Unsupported year.");
    }

    fmt::println("Loading Advent of Code - Year {}", year);
}
