#include <iostream>
#ifndef string_h
#define string_h
using namespace std;

class Strings {
protected:
    string s1;

public:
    Strings(string S1);
    virtual string withoutChar();
    virtual int stringLength();
    virtual string getString();
};

class Numbers : public Strings {
public:
    Numbers(string a);
    string withoutChar() override;
    int stringLength() override;
    string getString() override;
};

class Letters : public Strings {
public:
    Letters(string b);
    string withoutChar() override;
    int stringLength() override;
    string getString() override;
};

#endif
