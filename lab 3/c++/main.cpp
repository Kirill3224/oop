#include <iostream>
#include "String.h"
#include <string>
using namespace std;

int main() {
	setlocale(LC_ALL, "ru");
	string s1, s2, s3;

	cout << "Придумайте перший рядок (на англійській мові): ";
	getline(cin, s1);

	cout << "Придумайте другий рядок (на англійській мові): ";
	getline(cin, s2);

	cout << "Придумайте третій рядок (на англійській мові): ";
	getline(cin, s3);

	String str(s1, s2, s3);


	cout << "Ваші рядки: " << str.getString1() << ", " << str.getString2() << ", " << str.getString3() << endl;

	str.removeChar('#');

	cout << "Результат складання рядку 2 та 3: " << str.getMerge1() << endl;
	cout << "Результат додавання сумми рядків 2 та 3 до 1 рядка: " << str.getMerge2() << endl;
	cout << "Довжина об'єднаного рядка: " << str.getLength() << endl;


	return 0;
}