#include <iostream>
#ifndef task_h
#define task_h

class Data {
protected:
    double a;
    double c;
    double d;

public:
    Data(double a, double c, double d);
};

class Log {
public:
    static double getLog(double value);
};

class Calculate : public Data {
public:
    Calculate(double d, double c, double a);

    double Result();
};
#endif

