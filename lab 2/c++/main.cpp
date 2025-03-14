#include <iostream>
#include "Triangle.h"

int main()
{
    // // Змінні для зчитування координат
    // double x1, y1, x2, y2, x3, y3;

    // std::cout << "Введіть координати трикутника (x1, y1, x2, y2, x3, y3): ";
    // std::cin >> x1 >> y1 >> x2 >> y2 >> x3 >> y3;

    // // Створення об'єкта трикутника з введеними координатами
    // Triangle triangle(x1, y1, x2, y2, x3, y3);
    // Triangle triangle2(x1, y1, x2, y2, x3, y3);
    // Triangle triangle3(x1, y1, x2, y2, x3, y3);

    // // Виведення збережених координат
    // std::cout << "\nТрикутник має координати:\n";
    // std::cout << triangle << std::endl;

    // // Обчислення та виведення периметра
    // double perimeter = triangle.getPerimeter();
    // std::cout << "\nПериметр: " << perimeter << std::endl;

    // // Обчислення та виведення площі
    // double area = triangle.getArea();
    // std::cout << "Площа: " << area << std::endl;

    // // Виклик деструктора в heap
    // Triangle *triangle4 = new Triangle(x1, y1, x2, y2, x3, y3);
    // delete triangle4;

    // // Виклик конструктора копії
    // Triangle tCopy = triangle;
    // // Виведення збережених координат
    // std::cout << "\nТрикутник копія має координати:\n";
    // std::cout << tCopy << std::endl;

    // Створення двох трикутників
    Triangle t1(1, 2, 3, 4, 5, 6);
    Triangle t2(6, 5, 4, 3, 2, 1);

    std::cout << "Трикутник 1:\n";
    std::cout << t1 << std::endl;
    std::cout << "Трикутник 2:\n";
    std::cout << t2 << std::endl;

    // Масштабування трикутника t1 на 2
    Triangle tScaled = t1 * 2;
    std::cout << "Після масштабування t1 на 2:\n";
    std::cout << tScaled << std::endl;

    // Додавання двох трикутників
    Triangle tSum = t1 + t2;
    std::cout << "\nСума t1 і t2:\n";
    std::cout << tSum << std::endl;

    // Масштабування трикутника t2 на 2 за посиланням
    t1.scale(t2, 2);
    std::cout << "Після масштабування t2 на 2:\n";
    std::cout << t2 << std::endl;

    // Масштабування трикутника t2 на 2
    Triangle tScaled2 = t1.scale(2, t2);
    std::cout << "Після масштабування t2 на 2:\n";
    std::cout << tScaled2 << std::endl;

    return 0;
}
