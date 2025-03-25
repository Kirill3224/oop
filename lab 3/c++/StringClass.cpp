#include <iostream>
#include "String.h"
using namespace std;

String::String() : s1(""), s2(""), s3("") {}
String::String(string& s1, string& s2, string& s3) : s1(s1), s2(s2), s3(s3) {}
String::String(String& other) : s1(other.s1), s2(other.s2), s3(other.s3) {}


string String::getString1() {
	return s1;
}
string String::getString2() {
	return s2;
}
string String::getString3() {
	return s3;
}

string String::getMerge1() {
	return s2 + s3;
}

string String::getMerge2() {
	return getMerge1() + s1;
}

size_t String::getLength() {
	return getMerge2().length();
}

void String::removeChar(char ch) {
	s1.erase(remove(s1.begin(), s1.end(), ch), s1.end());
	s2.erase(remove(s2.begin(), s2.end(), ch), s2.end());
	s3.erase(remove(s3.begin(), s3.end(), ch), s3.end());
}



