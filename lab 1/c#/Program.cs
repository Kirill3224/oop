using System;

namespace TriangleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть координати трикутника (x1, y1, x2, y2, x3, y3):");

            // Зчитуємо введення користувача та перетворюємо в double
            Console.Write("x1 = ");
            double x1 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("y1 = ");
            double y1 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("x2 = ");
            double x2 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("y2 = ");
            double y2 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("x3 = ");
            double x3 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("y3 = ");
            double y3 = double.Parse(Console.ReadLine() ?? "0");

            // Створюємо об'єкт трикутника з заданими координатами
            Triangle triangle = new Triangle(x1, y1, x2, y2, x3, y3);

            // Виводимо збережені координати
            Console.WriteLine("\nТрикутник має координати:");
            Console.WriteLine($"  A({triangle.X1}, {triangle.Y1})");
            Console.WriteLine($"  B({triangle.X2}, {triangle.Y2})");
            Console.WriteLine($"  C({triangle.X3}, {triangle.Y3})");

            // Обчислюємо та виводимо периметр
            double perimeter = triangle.GetPerimeter();
            Console.WriteLine($"\nПериметр: {perimeter}");

            // Обчислюємо та виводимо площу
            double area = triangle.GetArea();
            Console.WriteLine($"Площа: {area}");

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}
