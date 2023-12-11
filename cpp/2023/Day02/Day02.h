/*
 * Created by Lucas Gracioso <contact@lbgracioso.net>
 * SPDX-License-Identifier: Apache-2.0
*/

#ifndef CPP_DAY02_H
#define CPP_DAY02_H

#include "../../utils/Problem.h"

class Day02 : public Problem {
private:
    struct Set {
        int blue = 0;
        int green = 0;
        int red = 0;
    };

    struct Game {
        int id;
        std::vector<Set> sets;
    };

    std::vector<Game> m_games;
    static std::vector<std::string> splitString(const std::string& input, char delimiter);
    static bool verifyGameCubes(const Game& game);
    void sortGames();
    int sumPower();

public:
    Day02() { m_problemName = "Cube Conundrum"; m_problemYear = 2023; m_problemDay = 2; sortGames(); }
    std::string PartOne() override;
    std::string PartTwo() override;
};


#endif //CPP_DAY02_H
