#include <iostream>
#include <stdexcept>

class IntArray {
private:
    int* array;
    int size;

public:
    IntArray(int size) {
        if (size <= 0)
            throw std::invalid_argument("Розмір масиву повинен бути більше нуля");

        this->size = size;
        array = new int[size]();
    }

    ~IntArray() {
        delete[] array;
    }

    // Перевантаження оператора [] для доступу до елементів
    int& operator[](int index) {
        if (index < 0 || index >= size)
            throw std::out_of_range("Індекс виходить за межі масиву");
        return array[index];
    }

    // Геттер для довжини масиву (аналог властивості `Length` у C#)
    int getLength() const {
        return size;
    }
};

int main() {
    try {
        IntArray arr(5);

        // Запис значень у масив
        for (int i = 0; i < arr.getLength(); i++)
            arr[i] = i * 10;

        // Вивід значень масиву
        std::cout << "Елементи масиву:\n";
        for (int i = 0; i < arr.getLength(); i++)
            std::cout << "arr[" << i << "] = " << arr[i] << "\n";

        std::cout << "Довжина масиву: " << arr.getLength() << "\n";

        // Спроба звернутися за межі масиву
        std::cout << arr[10] << "\n"; // Викине виняток

    } catch (const std::exception& ex) {
        std::cout << "Помилка: " << ex.what() << "\n";
    }

    return 0;
}
