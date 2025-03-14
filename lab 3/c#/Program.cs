using System;
using StringLibrary;

class Program
{
    static void Main()
    {
        // Використання різних конструкторів
        StringClass S1 = new StringClass();
        StringClass S2 = new StringClass("Hello");
        StringClass S3 = new StringClass(S2); // Конструктор копіювання

        // Вивід початкових значень
        Console.WriteLine($"S1: \"{S1.Value}\"");
        Console.WriteLine($"S2: \"{S2.Value}\"");
        Console.WriteLine($"S3: \"{S3.Value}\"");

        // "Вирахувати" з об'єкта S2 символ 'l'
        StringClass S4 = S2 - 'l';
        Console.WriteLine($"S2 після видалення 'l': \"{S4.Value}\"");

        // "Скласти" об'єкти S2 та S3
        StringClass S5 = S2 + S3;
        Console.WriteLine($"S2 + S3: \"{S5.Value}\"");

        // "Полистити" до S1
        S1 = S5.Copy();
        Console.WriteLine($"S1 після присвоєння: \"{S1.Value}\"");
    }
}
