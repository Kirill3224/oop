#include <iostream>

#ifndef string_h
#define string_h
using namespace std;

class String {
private:
	string s1;
	string s2;
	string s3;


public:
	String();
	String(string& s1, string& s2, string& s3);
	String(String& other);

	size_t getLength();
	string getString1();
	string getString2();
	string getString3();
	string getMerge1();
	string getMerge2();

	void removeChar(char ch);

};

#endif