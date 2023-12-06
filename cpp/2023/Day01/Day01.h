/*
 * Created by Lucas Gracioso <contact@lbgracioso.net>
 * SPDX-License-Identifier: Apache-2.0
*/

#ifndef CPP_DAY01_H
#define CPP_DAY01_H

#include "../../utils/Problem.h"

class Day01 : public Problem {
private:
    static std::string replaceTextWithNumbers(std::string& input);
public:
    Day01() { m_problemName = "Trebuchet?!"; m_problemYear = 2023; m_problemDay = 1; }
    std::string PartOne() override;
    std::string PartTwo();

    std::string cleanInput(bool replaceTextWithNumbers);
};


#endif //CPP_DAY01_H
