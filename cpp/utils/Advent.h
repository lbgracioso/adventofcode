/*
 * Created by Lucas Gracioso <contact@lbgracioso.net>
 * SPDX-License-Identifier: Apache-2.0
*/

#ifndef CPP_ADVENT_H
#define CPP_ADVENT_H

#include <array>
#include "Problem.h"

class Advent {
private:
    std::array<std::unique_ptr<Problem>, 25> m_days;

public:
    Advent() : m_days({nullptr}) {}

    void setDay(int dayNumber, std::unique_ptr<Problem> problem) {
        if (dayNumber >= 1 && dayNumber <= 25) {
            m_days[dayNumber - 1] = std::move(problem);
        }
    }

    void setAllDays(std::array<std::unique_ptr<Problem>, 25>& problems) {
        m_days = std::move(problems);
    }

    std::array<std::unique_ptr<Problem>, 25> &getDays() {
        return m_days;
    }

    std::unique_ptr<Problem> &getDay(int day) {
        if (!m_days[day - 1])
            throw std::runtime_error("The specified day has not been completed yet.");

        return m_days[day - 1];
    }
};


#endif //CPP_ADVENT_H
