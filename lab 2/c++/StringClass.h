#ifndef STRINGCLASS_H
#define STRINGCLASS_H

#include <iostream>
#include <cstring>

class StringClass {
private:
    char* str;
    size_t length;

public:
    // Конструктори
    StringClass();                      // Конструктор за замовчуванням
    StringClass(const char* input);      // Конструктор із параметром
    StringClass(const StringClass& other); // Конструктор копіювання
    StringClass(StringClass&& other) noexcept; // Конструктор переміщення

    // Деструктор
    ~StringClass();

    // Методи
    size_t getLength() const;
    const char* getString() const;
    void reverse();
    void clear();

    // Оператори
    StringClass& operator=(const StringClass& other); // Оператор присвоєння
    StringClass& operator=(StringClass&& other) noexcept; // Оператор переміщення
};

#endif // STRINGCLASS_H
