#include <iostream>
#include "String.h"
#include <windows.h>
using namespace std;

int main() {
	SetConsoleOutputCP(CP_UTF8);
	string s1, s2, s3;

	cout << "Придумайте перший рядок (на англійській мові): ";
	getline(cin, s1);

	cout << "Придумайте другий рядок (на англійській мові): ";
	getline(cin, s2);

	cout << "Придумайте третій рядок (на англійській мові): ";
	getline(cin, s3);

	String str(s1, s2, s3);

	cout << "Ваші рядки: " << str.getString(s1, s2) << " " << str.getString(s3) << endl;


	cout << "Результат складання рядку 3 та 2: " << str.getMerge(s3, s2) << endl;
	cout << "Результат додавання сумми рядків 2 та 3 до 1 рядка: " << str.getMerge(s1) << endl;
	cout << "Довжина об'єднаного рядка: " << str.getLength() << endl;


	return 0;
}