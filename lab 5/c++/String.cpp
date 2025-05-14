#include "String.h"
#include <iostream>
using namespace std;

Strings::Strings(string S1) {
    this->s1 = S1;
}

string Strings::withoutChar() {
    string result = s1;
    result.erase(remove(result.begin(), result.end(), '\0'), result.end());
    return result;
}

int Strings::stringLength() {
    return s1.length();
}

string Strings::getString() {
    return s1;
}


Numbers::Numbers(string a) : Strings(a) {}

string Numbers::withoutChar() {
    string result = s1;
    result.erase(remove(result.begin(), result.end(), '5'), result.end());
    return result;
}

int Numbers::stringLength() {
    return withoutChar().length();
}

string Numbers::getString() {
    return s1;
}


Letters::Letters(string b) : Strings(b) {}

string Letters::withoutChar() {
    string result = s1;
    result.erase(remove(result.begin(), result.end(), 'a'), result.end());
    return result;
}

int Letters::stringLength() {
    return withoutChar().length();
}

std::string Letters::getString() {
    return s1;
}
