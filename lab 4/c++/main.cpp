#include <iostream>
#include <windows.h>
#include "Triangle.h"
using namespace std;

int main() {
	SetConsoleOutputCP(65001);
	double a, b, c;
	double ax, ay, bx, by, cx, cy;

	cout << "Введіть довжину сторони a" << endl;
	cin >> a;

	cout << "Введіть довжину сторони b" << endl;
	cin >> b;

	cout << "Введіть довжину сторони c" << endl;
	cin >> c;

	cout << "Введіть координати точки A (x,y)" << endl;
	cin >> ax;
	cin >> ay;

	cout << "Введіть координати точки B (x,y)" << endl;
	cin >> bx;
	cin >> by;

	cout << "Введіть координати точки C (x,y)" << endl;
	cin >> cx;
	cin >> cy;

	Triangle triangle(a, b, c, ax, ay, bx, by, cx, cy);

	cout << "Довжини сторін: a = " << a << ", b = " << b << ", c = " << c << endl;
	cout << "Координати точок вершин:  A (" << ax << ";" << ay << "), " << "B (" << bx << ";" << by << "), " << "C (" << cx << ";" << cy << ")" << endl;

	cout << "                          " << endl;

	cout << "Периметр: " << triangle.getPerimeter() << endl;
	cout << "Площа: " << triangle.getArea() << endl;
}