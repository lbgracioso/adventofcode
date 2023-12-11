/*
 * Created by Lucas Gracioso <contact@lbgracioso.net>
 * SPDX-License-Identifier: Apache-2.0
*/

#include <regex>
#include "Day02.h"

std::string Day02::PartOne() {

    int possibleGames = 0;
    for (const auto& game: m_games) {
        if (verifyGameCubes(game))
            possibleGames += game.id;
    }

    return fmt::format("The sum of the possible game IDs is: {}", possibleGames);
}

std::string Day02::PartTwo() {
    return fmt::format("The power of the sets is: {}", sumPower());
}

int Day02::sumPower() {
    int power = 0;

    for (const auto& game : m_games) {
        int minRed = 0;
        int minBlue = 0;
        int minGreen = 0;

        for (const auto& set : game.sets) {
            if (minRed < set.red) minRed = set.red;
            if (minBlue < set.blue) minBlue = set.blue;
            if (minGreen < set.green) minGreen = set.green;
        }

        power += (minRed * minBlue * minGreen);
    }
    return power;
}

void Day02::sortGames() {
    for (auto input = readInput(); auto& line : input) {
        Game game;
        game.id = std::stoi(std::regex_replace(line.substr(0, line.find(":") + 1), std::regex("[^0-9]+"), ""));
        line.erase(0, line.find(":") + 1);

        for (std::vector<std::string> lineGame = splitString(line, ';'); const auto& formatLine : lineGame) {
            std::vector<std::string> sets = splitString(formatLine, ',');
            Set set;

            for (const auto& formatSets : sets) {
                auto cubes = std::stoi(std::regex_replace(formatSets, std::regex("[^0-9]"), ""));

                if (formatSets.find("red") != std::string::npos)
                    set.red += cubes;
                else if (formatSets.find("blue") != std::string::npos)
                    set.blue += cubes;
                else if (formatSets.find("green") != std::string::npos)
                    set.green += cubes;
            }

            game.sets.emplace_back(set);
        }

        m_games.emplace_back(game);
    }
}

std::vector<std::string> Day02::splitString(const std::string& input, char delimiter) {
    std::vector<std::string> result;
    size_t start = 0;
    size_t end = input.find(delimiter);

    while (end != std::string::npos) {
        result.push_back(input.substr(start, end - start));
        start = end + 1;
        end = input.find(delimiter, start);
    }

    result.push_back(input.substr(start));  // Add the last one that doesn't have a delimiter

    return result;
}

bool Day02::verifyGameCubes(const Game& game) {
    int counter = 0;

    for (const auto& set : game.sets) {
        if (set.red <= 12 && set.green <= 13 && set.blue <= 14)
            counter++;
    }

    return counter == game.sets.size();
}
