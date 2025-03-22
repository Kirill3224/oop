#ifndef string_h
#define string_h
#include <iostream>
using namespace std;

class String {
private:
	string s;

public:
	explicit String(string s);
	string getReturn();
	string getReversed();
	size_t getLength();
};

#endif