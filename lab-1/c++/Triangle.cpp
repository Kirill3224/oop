#include "Triangle.h"
#include <cmath>  // для sqrt
#include <iostream>

// Конструктор за замовчуванням (задає координати 0,0,0,0,0,0)
Triangle::Triangle()
    : x1(0), y1(0), x2(0), y2(0), x3(0), y3(0)
{
}

// Конструктор з параметрами
Triangle::Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
    : x1(x1), y1(y1), x2(x2), y2(y2), x3(x3), y3(y3)
{
}

// Конструктор копії
Triangle::Triangle(const Triangle &other)
    : x1(other.x1), y1(other.y1), x2(other.x2), y2(other.y2), x3(other.x3), y3(other.y3)
{
}

// Делегування конструктора
Triangle::Triangle(double x1, double y1) : Triangle(x1, y1, 0, 0, 0, 0)
{
}

// Деструктор
Triangle::~Triangle()
{
    // std::cout << "Destructor called" << std::endl;
}

// Сетери
void Triangle::setCoordinates(double X1, double Y1, double X2, double Y2, double X3, double Y3)
{
    x1 = X1;
    y1 = Y1;
    x2 = X2;
    y2 = Y2;
    x3 = X3;
    y3 = Y3;
}

// Перевантаження: встановлення координат через масив з 6 елементів
void Triangle::setCoordinates(const double coords[6]) {
    x1 = coords[0]; y1 = coords[1];
    x2 = coords[2]; y2 = coords[3];
    x3 = coords[4]; y3 = coords[5];
}

// Гетери
double Triangle::getX1() const { return x1; }
double Triangle::getY1() const { return y1; }
double Triangle::getX2() const { return x2; }
double Triangle::getY2() const { return y2; }
double Triangle::getX3() const { return x3; }
double Triangle::getY3() const { return y3; }

// Обчислення периметра
double Triangle::getPerimeter() const
{
    // Довжини сторін
    double sideA = std::sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
    double sideB = std::sqrt((x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2));
    double sideC = std::sqrt((x1 - x3) * (x1 - x3) + (y1 - y3) * (y1 - y3));

    return sideA + sideB + sideC;
}

// Обчислення площі (за формулою Герона)
double Triangle::getArea() const
{
    double sideA = std::sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
    double sideB = std::sqrt((x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2));
    double sideC = std::sqrt((x1 - x3) * (x1 - x3) + (y1 - y3) * (y1 - y3));

    double p = (sideA + sideB + sideC) / 2.0; // півпериметр
    return std::sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
}

// Метод масштабування з аргументом за умовчанням
void Triangle::scale(double factor)
{
    x1 *= factor;
    y1 *= factor;
    x2 *= factor;
    y2 *= factor;
    x3 *= factor;
    y3 *= factor;
}

Triangle Triangle::scale(double factor, Triangle other)
{
    other.x1 *= factor;
    other.y1 *= factor;
    other.x2 *= factor;
    other.y2 *= factor;
    other.x3 *= factor;
    other.y3 *= factor;
    return other;
}

void Triangle::scale(Triangle &other, double factor)
{
    other.x1 *= factor;
    other.y1 *= factor;
    other.x2 *= factor;
    other.y2 *= factor;
    other.x3 *= factor;
    other.y3 *= factor;
}

// Перевантаження оператора множення
Triangle Triangle::operator*(double scalar) const {
    return Triangle(x1 * scalar, y1 * scalar,
                    x2 * scalar, y2 * scalar,
                    x3 * scalar, y3 * scalar);
}

// Перевантаження оператора додавання
Triangle Triangle::operator+(const Triangle &other) const {
    return Triangle(x1 + other.x1, y1 + other.y1,
                    x2 + other.x2, y2 + other.y2,
                    x3 + other.x3, y3 + other.y3);
}

// Перевантаження оператора виведення
std::ostream &operator<<(std::ostream &os, const Triangle &triangle) {
    os << "Triangle(" << triangle.x1 << ", " << triangle.y1 << ", " << triangle.x2 << ", " << triangle.y2 << ", " << triangle.x3 << ", " << triangle.y3 << ")";
    return os;
}
