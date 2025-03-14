#include "StringClass.h"

// Конструктор за замовчуванням
StringClass::StringClass() : str(new char[1]), length(0) {
    str[0] = '\0';
}

// Конструктор з параметрами
StringClass::StringClass(const char* s) {
    length = strlen(s);
    str = new char[length + 1];
    strcpy(str, s);
}

// Конструктор копіювання
StringClass::StringClass(const StringClass& other) {
    length = other.length;
    str = new char[length + 1];
    strcpy(str, other.str);
}

// Деструктор
StringClass::~StringClass() {
    delete[] str;
}

// Метод отримання довжини рядка
size_t StringClass::getLength() const {
    return length;
}

// Метод отримання значення рядка
const char* StringClass::getString() const {
    return str;
}

// Перевантаження оператора +
StringClass StringClass::operator+(const StringClass& other) const {
    size_t newLength = length + other.length;
    char* newStr = new char[newLength + 1];

    strcpy(newStr, str);
    strcat(newStr, other.str);

    StringClass result(newStr);
    delete[] newStr;
    return result;
}

// Перевантаження оператора -
StringClass StringClass::operator-(char ch) const {
    size_t newLength = length;
    char* newStr = new char[length + 1];
    size_t index = 0;

    for (size_t i = 0; i < length; i++) {
        if (str[i] != ch) {
            newStr[index++] = str[i];
        }
        else {
            newLength--;
        }
    }
    newStr[newLength] = '\0';

    StringClass result(newStr);
    delete[] newStr;
    return result;
}

// Присвоєння (копіювання)
StringClass& StringClass::operator=(const StringClass& other) {
    if (this != &other) {
        delete[] str;
        length = other.length;
        str = new char[length + 1];
        strcpy(str, other.str);
    }
    return *this;
}
