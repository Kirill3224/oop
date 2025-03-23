#include <iostream>

#ifndef string_h
#define string_h
using namespace std;

class String {
private:
	string s;

public:
	String(); // За замовчуванням
	String(string s); // З параметром
	String(String& other); // Копіюючий
	String(String&& other) noexcept; // Переміщення
	~String();

	size_t getLength();
	string Reversed();
	string getString();
};

#endif