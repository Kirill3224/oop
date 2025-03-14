using System;

class IntArray
{
    private int[] array;

    public IntArray(int size)
    {
        if (size <= 0)
            throw new ArgumentException("Розмір масиву повинен бути більше нуля");
        
        array = new int[size];
    }

    // Індексатор для доступу до елементів масиву
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= array.Length)
                throw new IndexOutOfRangeException("Індекс виходить за межі масиву");
            return array[index];
        }
        set
        {
            if (index < 0 || index >= array.Length)
                throw new IndexOutOfRangeException("Індекс виходить за межі масиву");
            array[index] = value;
        }
    }

    // Властивість тільки для читання довжини масиву
    public int Length
    {
        get { return array.Length; }
    }
}

// Тестування класу
class Program
{
    static void Main()
    {
        try
        {
            IntArray arr = new IntArray(5);

            // Запис значень у масив
            for (int i = 0; i < arr.Length; i++)
                arr[i] = i * 10;

            // Вивід значень масиву
            Console.WriteLine("Елементи масиву:");
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine($"arr[{i}] = {arr[i]}");

            Console.WriteLine($"Довжина масиву: {arr.Length}");

            // Спроба звернутися до виходу за межі
            Console.WriteLine(arr[10]); // Викине виняток
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
