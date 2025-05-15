#include "Task.h"
#include <iostream>
using namespace std;

Data::Data(double a, double c, double d) {
    this->a = a;
    this->c = c;
    this->d = d;
}

double Log::getLog(double value) {
    if (value <= 0) {
        throw invalid_argument("Неможливо обчислити логарифм від непозитивного числа.");
    }
    else {
        return log10(value);
    }
}

Calculate::Calculate(double d, double c, double a) : Data(d, c, a) {}

double Calculate::Result() {
    double numerator = (2 * c - Log::getLog(d / 4));
    double denominator = a * a - 1;

    if (denominator == 0) {
        throw runtime_error("Ділення на нуль неможливе.");
    }
    else {
        return numerator / denominator;
    }
}

