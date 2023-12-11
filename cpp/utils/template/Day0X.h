/*
 * Created by Lucas Gracioso <contact@lbgracioso.net>
 * SPDX-License-Identifier: Apache-2.0
*/

#ifndef CPP_DAY0X_H
#define CPP_DAY0X_H

#include "../Problem.h"

class Day0X : public Problem {
public:
    Day0X() { m_problemName = "X"; m_problemYear = 0; m_problemDay = 0; }
    std::string PartOne() override;
    std::string PartTwo() override;
};


#endif //CPP_DAY0X_H
