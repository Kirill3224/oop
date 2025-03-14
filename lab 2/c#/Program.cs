using System;
using StringLibrary;

class Program
{
    static void Main()
    {
        // Використання класу
        StringClass str1 = new StringClass("Hello");
        StringClass str2 = new StringClass(str1); // Конструктор копіювання

        Console.WriteLine($"Рядок 1: {str1.Value} (довжина: {str1.Length})");
        Console.WriteLine($"Рядок 2 (копія): {str2.Value}");

        str1.Reverse();
        Console.WriteLine($"Перевернутий рядок 1: {str1.Value}");

        str1.Clear();
        Console.WriteLine($"Рядок 1 після очищення: {(str1.Value == "" ? "порожній" : str1.Value)}");
    }
}
