// #ifndef TRIANGLE_H
// #define TRIANGLE_H

#pragma once
#include <iostream>

class Triangle
{
private:
    double x1, y1;
    double x2, y2;
    double x3, y3;

public:
    // Конструктори
    Triangle();
    Triangle(double x1, double y1, double x2, double y2, double x3, double y3);
    Triangle(const Triangle &other);
    // Делегування конструктора
    Triangle(double x1, double y1);
    // Triangle(Vector2D vec1, Vector2D vec2, Vector2D vec3);

    ~Triangle();

    // Сетери
    void setCoordinates(double x1, double y1, double x2, double y2, double x3, double y3);
    void setCoordinates(const double coords[6]);

    // Гетери
    double getX1() const;
    double getY1() const;
    double getX2() const;
    double getY2() const;
    double getX3() const;
    double getY3() const;

    // Методи обчислення
    double getPerimeter() const;
    double getArea() const;

    // Метод масштабування з аргументом за умовчанням
    void scale(double factor = 2.0);
    Triangle scale(double factor, Triangle other);
    void scale(Triangle &other, double factor = 2.0);

    // Перевантаження оператора множення (масштабування)
    Triangle operator*(double scalar) const;

    // Перевантаження оператора додавання
    Triangle operator+(const Triangle &other) const;

    // Перевантаження оператора виведення
    friend std::ostream &operator<<(std::ostream &os, const Triangle &triangle);
};

// #endif // TRIANGLE_H


// перевантаження класів в TS
// що таке мережеве програмування