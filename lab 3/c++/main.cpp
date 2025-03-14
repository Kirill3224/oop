#include <iostream>
#include "StringClass.h"

int main() {
    // Використання різних конструкторів
    StringClass S1;
    StringClass S2("Hello");
    StringClass S3 = S2; // Виклик конструктора копіювання

    // Вивід початкових значень
    std::cout << "S1: " << S1.getString() << std::endl;
    std::cout << "S2: " << S2.getString() << std::endl;
    std::cout << "S3: " << S3.getString() << std::endl;

    // "Вирахувати" з об'єкта S2 символ 'l'
    StringClass S4 = S2 - 'l';
    std::cout << "S2 після видалення 'l': " << S4.getString() << std::endl;

    // "Скласти" об'єкти S2 та S3
    StringClass S5 = S2 + S3;
    std::cout << "S2 + S3: " << S5.getString() << std::endl;

    // "Полистити" до S1
    S1 = S5;
    std::cout << "S1 після присвоєння: " << S1.getString() << std::endl;

    return 0;
}
