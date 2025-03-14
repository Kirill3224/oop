#include <iostream>
#include "StringClass.h"

int main() {
    // Використання класу
    StringClass str1("Hello");
    StringClass str2 = str1; // Виклик конструктора копіювання
    StringClass str3(std::move(str2)); // Виклик конструктора переміщення

    std::cout << "Рядок 1: " << str1.getString() << " (довжина: " << str1.getLength() << ")\n";
    std::cout << "Рядок 3: " << str3.getString() << " (довжина: " << str3.getLength() << ")\n";

    str1.reverse();
    std::cout << "Перевернутий рядок 1: " << str1.getString() << "\n";

    str1.clear();
    std::cout << "Рядок 1 після очищення: " << (str1.getString() ? str1.getString() : "порожній") << "\n";

    return 0;
}
