#ifndef STRINGCLASS_H
#define STRINGCLASS_H

#include <iostream>
#include <cstring>

class StringClass {
private:
    char* str;
    size_t length;

public:
    // Конструктор за замовчуванням
    StringClass();

    // Конструктор з параметрами
    StringClass(const char* s);

    // Конструктор копіювання
    StringClass(const StringClass& other);

    // Деструктор
    ~StringClass();

    // Метод обчислення довжини рядка
    size_t getLength() const;

    // Метод отримання значення рядка
    const char* getString() const;

    // Перевантаження оператора +
    StringClass operator+(const StringClass& other) const;

    // Перевантаження оператора -
    StringClass operator-(char ch) const;

    // Присвоєння (копіювання)
    StringClass& operator=(const StringClass& other);
};

#endif
