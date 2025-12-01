

#include <cstddef>
#include <fstream>
#include <iostream>
#include <string>
#include <utility>

enum Direction { LEFT, RIGHT };

class LinkedList {
public:
  LinkedList(int value, LinkedList *prev, LinkedList *next) {
    this->value = value;
    this->next = next;
    this->prev = prev;
  }

  int value;
  LinkedList *next;
  LinkedList *prev;

  static void printList(LinkedList *curr) {
    int startIndex = curr->value;
    while (curr->next != NULL && curr->next->value != startIndex) {
      std::cout << "{ prev:" << curr->prev->value
                << ", current: " << curr->value
                << ", next: " << curr->next->value << "}" << "\n";
      curr = curr->next;
    }
  }

  static void traverse(Direction dir, int step, LinkedList **node) {
    int count = 0;
    if (dir == RIGHT) {
      while ((*node)->next != NULL) {
        if (count >= step)
          return;
        *node = (*node)->next;
        count++;
      }
    } else {
      while ((*node)->prev != NULL) {
        if (count >= step)
          return;
        *node = (*node)->prev;
        count++;
      }
    }
  }
};

std::pair<Direction, int> getRotation(const std::string &line) {
  if (line.at(0) == 'L') {
    return {LEFT, std::stoi(line.substr(1))};
  }
  return {RIGHT, std::stoi(line.substr(1))};
}

int main() {

  LinkedList start(0, NULL, NULL);
  LinkedList *head = &start;
  for (int i = 1; i < 100; i++) {
    LinkedList *number = new LinkedList(i, head, NULL);
    head->next = number;
    head = number;
  }
  head->next = &start;
  start.prev = head;

  // LinkedList::printList(&start);
  LinkedList::traverse(LEFT, 49, &head);

  std::ifstream inputFile("rotations.txt");

  if (!inputFile.is_open()) {
    throw "File couldnt be opened.";
  }

  int password = 0;

  std::string line;
  while (std::getline(inputFile, line)) {
    auto rotation = getRotation(line);
    LinkedList::traverse(rotation.first, rotation.second, &head);
    if (head->value == 0) {
      password++;
    }
  }

  inputFile.close();
  delete head;

  std::cout << "\n\nPassword: " << password;
}