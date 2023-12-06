/*
 * Created by Lucas Gracioso <contact@lbgracioso.net>
 * SPDX-License-Identifier: Apache-2.0
*/

#ifndef CPP_ADVENT2023_H
#define CPP_ADVENT2023_H

#include "../utils/Advent.h"
#include "Day01/Day01.h"

class Advent2023 : public Advent {
public:
    Advent2023() {
        setDay(1, std::make_unique<Day01>());
    }
};


#endif //CPP_ADVENT2023_H
