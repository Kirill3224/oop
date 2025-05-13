#include <iostream>

#ifndef string_h
#define string_h
using namespace std;

class String {
private:
	string s;

public:
	String();
	String(string s);
	String(String& other);
	~String();

	size_t getLength();
	string Reversed();
	string getString();
};

#endif