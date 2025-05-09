#include <iostream>

#ifndef triangle_h
#define triangle_h
using namespace std;

class Figure {
protected:
	double a, b, c;
	double A, B, C;

public:
	Figure();
	Figure(double a, double b, double c, double ax, double ay, double bx, double by, double cx, double cy);
};

class Triangle : public Figure {
public:
	Triangle();
	Triangle(double a, double b, double c, double ax, double ay, double bx, double by, double cx, double cy);

	double getPerimeter() const;
	double getArea() const;
	double getLength() const;
	double getCoords() const;

};

#endif#
