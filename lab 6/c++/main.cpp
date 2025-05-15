#include "Task.h"
#include <iostream>
#include <windows.h>
using namespace std;

int main() {
    try {
        Calculate* numbers[3];
        numbers[0] = new Calculate(2, 5, 8);
        numbers[1] = new Calculate(3, 6, 12);
        numbers[2] = new Calculate(4, 7, 16);

        for (int i = 0; i < 3; ++i) {
            SetConsoleOutputCP(65001);
            double result = numbers[i]->Result();
            cout << "Результат: " << result << endl;
            delete numbers[i];
        }
    }
    catch (const std::exception& ex) {
        SetConsoleOutputCP(65001);
        cout << "Помилка: " << ex.what() << endl;
    }

    return 0;
}
