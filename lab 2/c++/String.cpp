#include <iostream>
#include "String.h"
using namespace std;

String::String() : s(s) {}
String::String(string s) : s(s) {}
String::String(String& other) : s(other.s) {}
String::~String() {}

string String::getString() {
	return s;
}

size_t String::getLength() {
	return s.length();
}

string String::Reversed() {
	string re = s;
	reverse(re.begin(), re.end());
	return re;
}
