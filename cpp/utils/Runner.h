/*
 * Created by Lucas Gracioso <contact@lbgracioso.net>
 * SPDX-License-Identifier: Apache-2.0
*/

#ifndef CPP_RUNNER_H
#define CPP_RUNNER_H


#include <string>
#include <fmt/format.h>
#include <filesystem>
#include <vector>
#include "Advent.h"
#include "Problem.h"

class Runner {
private:
    Advent m_advent;
    void loadAdvent(const int &year);

public:
    void solveAdvent(const int year);
    void solveAdvent(const int year, const int day);

    static void formatDayResult(const std::unique_ptr<Problem> &problem);
};

#endif //CPP_RUNNER_H
