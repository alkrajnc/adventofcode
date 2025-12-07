#include <cstdlib>
#include <fstream>
#include <iostream>
#include <set>
#include <string>
#include <utility>
#include <vector>

std::vector<std::string> parseFile(std::string filename) {
  std::ifstream file(filename);

  if (!file.is_open()) {
    std::cout << "Error: File not found.";
    exit(-1);
  }

  std::vector<std::string> lines;

  std::string line;
  while (std::getline(file, line)) {
    lines.push_back(line);
  }

  return lines;
}

void debugPrint(const std::vector<std::string> &lines, int row, int col) {
  for (int i = 0; i < lines.size(); i++) {
    for (int j = 0; j < lines[i].size(); j++) {
      if (i == row && col == j) {
        std::cout << "\033[31m" << lines[i][j] << "\033[0m";
      } else {
        std::cout << lines[i][j];
      }
    }
    std::cout << "\n";
  }
  std::cout << "\n";
}

bool beamExists(const std::vector<std::pair<int, int>> &beam, int x, int y) {
  for (const auto part : beam) {
    if (part.first == x && part.second == y) {
      return true;
    }
  }
  return false;
}

int split(const std::vector<std::string> &lines, int depth, int offset,
          std::set<std::pair<int, int>> &visited) {

  for (int i = depth; i < lines.size(); i++) {
    if (offset < 0 || offset >= lines[i].size()) {
      return 0;
    }

    if (visited.count({i, offset})) {
      return 0;
    }
    visited.insert({i, offset});

    if (lines[i][offset] == '^') {
      int left = split(lines, i + 1, offset - 1, visited);
      int right = split(lines, i + 1, offset + 1, visited);

      return 1 + left + right;
    }
  }

  return 0;
}

int partOne(const std::vector<std::string> &lines) {
  int beamEmitter = (lines.size() - 1) / 2;

  std::set<std::pair<int, int>> visited;
  int leftSplits = split(lines, 2, beamEmitter - 1, visited);
  int rightSplits = split(lines, 2, beamEmitter + 1, visited);

  return 1 + leftSplits + rightSplits;
}

int main() {

  std::vector<std::string> lines = parseFile("input.txt");

  std::cout << partOne(lines) << "\n";
}