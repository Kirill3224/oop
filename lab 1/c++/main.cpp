#include "String.h"
#include <iostream>
#include <string>
using namespace std;

int main() {
	setlocale(LC_ALL, "ru");
	string s;
	cout << "Придумайте рядок (на англійскькій мові): ";
	getline(std::cin, s);

	String str(s);
	cout << "Ваш рядок: " << str.getReturn() << endl;
	cout << "Довжина рядка: " << str.getLength() << endl;
	cout << "Перевернутий рядок: " << str.getReversed() << endl;

	return 0;
}