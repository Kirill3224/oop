#include <iostream>
#include "String.h"

String::String() : s1(""), s2(""), s3("") {}
String::String(string s1, string s2, string s3) : s1(s1), s2(s2), s3(s3) {}
String::String(const String& other) : s1(other.s1), s2(other.s2), s3(other.s3) {}


string String::getString(string s1, string s2) const {
    return s1 + " " + s2;
}

string String::getString(string s3) const {
    return s3;
}

string String::withoutChar(string s3, string s2) const {
    s3.erase(remove(s3.begin(), s3.end(), ch), s3.end());
    s2.erase(remove(s2.begin(), s2.end(), ch), s2.end());
    return s3 + s2;
}

string String::withoutChar(string s1) const {
    s1.erase(remove(s1.begin(), s1.end(), ch), s1.end());
    return s1;
}

string String::getMerge(string s3, string s2) const {
    return withoutChar(s3, s2);
}

string String::getMerge(string s1) const {
    return withoutChar(s1) + getMerge(s3, s2);
}

size_t String::getLength() const {
    return getMerge(s1).length();
}

