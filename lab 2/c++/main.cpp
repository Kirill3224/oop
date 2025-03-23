#include <iostream>
#include "String.h"
#include <string>
using namespace std;

int main() {
	setlocale(LC_ALL, "ru");
	string s;

	cout << "Придумайте рядок (на англійській мові): ";
	getline(cin, s);

	String str(s);
	cout << "Ваш рядок: " << str.getString() << endl;
	cout << "Довжина рядка: " << str.getLength() << endl;
	cout << "Перевернутий рядок: " << str.Reversed() << endl;

	return 0;
}