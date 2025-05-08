#include <iostream>

#ifndef triangle_h
#define triangle_h
using namespace std;

class Triangle {
private:
	double a, b, c;
	double A, B, C;


public:
	Triangle();
	Triangle(double a, double b, double c, double ax, double ay, double bx, double by, double cx, double cy);

	double getPerimeter() const;
	double getArea() const;
	double getLength() const;
	double getCoords() const;

};

#endif#
