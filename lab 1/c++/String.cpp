#include "String.h"
#include <iostream>
#include <algorithm>
using namespace std;

String::String(string s) : s(s) {}

string String::getReturn() {
	return s;
}

size_t String::getLength() {
	return s.length();
}

string String::getReversed() {
	string reverse = s;
	std::reverse(reverse.begin(), reverse.end());
	return reverse;

}