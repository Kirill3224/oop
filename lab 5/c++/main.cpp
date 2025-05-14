#include <iostream>
#include <string>
#include <windows.h>
#include "String.h"
using namespace std;

void ShowInfo(Strings* str) {
    SetConsoleOutputCP(65001);
    std::cout << "\nОригинальний рядок: " << str->getString() << std::endl;
    std::cout << "Без заборонених символів: " << str->withoutChar() << std::endl;
    std::cout << "Довжина фінального рядка: " << str->stringLength() << std::endl;
}

int main() {
    SetConsoleOutputCP(65001);
    string a, b;

    cout << "Введіть перший рядок: ";
    getline(cin, a);

    cout << "Введіть другий рядок: ";
    getline(cin, b);

    Strings* n = new Numbers(a);
    Strings* l = new Letters(b);

    ShowInfo(n);
    ShowInfo(l);

    delete n;
    delete l;

    return 0;
}
