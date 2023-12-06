/*
 * Created by Lucas Gracioso <contact@lbgracioso.net>
 * SPDX-License-Identifier: Apache-2.0
*/

#include <regex>
#include "Day01.h"

std::string Day01::PartOne() {
    return cleanInput(false);
}

std::string Day01::PartTwo() {
    return cleanInput(true);
}

std::string Day01::cleanInput(bool replaceTextWithNumbers) {
    auto input = readInput();
    int counter = 0;
    std::string total = "";

    for (auto& line : input) {
        if (replaceTextWithNumbers) line = Day01::replaceTextWithNumbers(line);
        std::string format = std::regex_replace(line, std::regex(R"([\D])"), "");
        if(!format.empty()) counter += std::stoi((format.substr(0, 1)) + (format.substr(format.length() - 1, 1)));
        total += format + " ";
    }

    return std::to_string(counter);
}

std::string Day01::replaceTextWithNumbers(std::string &input) {
    const std::vector<std::pair<std::string, std::string>> replacements = {
            {"one", "1"},
            {"two", "2"},
            {"three", "3"},
            {"four", "4"},
            {"five", "5"},
            {"six", "6"},
            {"seven", "7"},
            {"eight", "8"},
            {"nine", "9"}
    };

    std::string result = input;
    for (const auto& pair : replacements) {
        result = std::regex_replace(result, std::regex(pair.first), fmt::format("{}{}{}", pair.first, pair.second, pair.first));

    }

    return result;
}
