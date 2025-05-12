#include <iostream>
#include <cmath>
#include "Triangle.h"
using namespace std;

Figure::Figure() : a(0), b(0), c(0), A(), B(), C() {}
Figure::Figure(double a, double b, double c, double ax, double ay, double bx, double by, double cx, double cy) {}

Triangle::Triangle(double a, double b, double c, double ax, double ay, double bx, double by, double cx, double cy) : Figure(a, b, c, ax, ay, bx, by, cx, cy) {}


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