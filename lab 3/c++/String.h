#ifndef STRING_H
#define STRING_H

#include <iostream>
#include <string>
using namespace std;

class String {
private:
    string s1;
    string s2;
    string s3;

public:
    String();
    String(string s1, string s2, string s3);
    String(const String& other);

    string getString(string s1, string s2) const;
    string getString(string s3) const;

    string getMerge(string s3, string s2) const;
    string getMerge(string s1) const;
    size_t getLength() const;

    char ch = '#';
    string withoutChar(string s3, string s2) const;
    string withoutChar(string s1) const;
};

#endif
