/*
 * Created by Lucas Gracioso <contact@lbgracioso.net>
 * SPDX-License-Identifier: Apache-2.0
*/

#ifndef CPP_PROBLEM_H
#define CPP_PROBLEM_H

#include <string>
#include <filesystem>
#include <fstream>
#include <vector>
#include <fmt/format.h>

class Problem {
protected:
    std::string m_problemName;
    int m_problemYear;
    int m_problemDay;

     std::vector<std::string> readInput() {
        std::filesystem::path path = std::filesystem::current_path().parent_path() / fmt::format("{}/Day{:02d}/input", m_problemYear, m_problemDay);

        try {
            std::ifstream inputFile(path);

            if (!inputFile.is_open()) {
                throw std::runtime_error(fmt::format("Unable to open the file: {}", path.c_str()));
            }

            std::vector<std::string> lines;
            std::string line;
            while (std::getline(inputFile, line)) {
                lines.push_back(line);
            }

            inputFile.close();
            return lines;
        } catch (const std::exception& e) {
            throw;
        }

    }

public:
    virtual std::string PartOne() = 0;
    virtual std::string PartTwo() = 0;

    const std::string &getProblemName() const {
        return m_problemName;
    }
};

#endif //CPP_PROBLEM_H
