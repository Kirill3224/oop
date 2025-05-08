#include <iostream>
#include <cmath>
#include "Triangle.h"
using namespace std;

Triangle::Triangle() : a(0), b(0), c(0), A(), B(), C() {}

Triangle::Triangle(double a, double b, double c,
	double ax, double ay,
	double bx, double by,
	double cx, double cy)
	: a(a), b(b), c(c), A(ax&& ay), B(bx&& by), C(cx&& cy) {}

double Triangle::getPerimeter() const {
	return a + b + c;
}

double Triangle::getArea() const {
	double s = (a + b + c) / 2;
	return sqrt(s * (s - a) * (s - b) * (s - c));
}

double Triangle::getCoords() const {
	return getCoords();
}

double Triangle::getLength() const {
	return getLength();
}