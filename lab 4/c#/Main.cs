using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Введіть довжину сторони a");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть довжину сторони b");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть довжину сторони c");
            int c = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введіть координати точки A (x,y)");
            int ax = Convert.ToInt32(Console.ReadLine());
            int ay = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть координати точки B (x,y)");
            int bx = Convert.ToInt32(Console.ReadLine());
            int by = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть координати точки C (x,y)");
            int cx = Convert.ToInt32(Console.ReadLine());
            int cy = Convert.ToInt32(Console.ReadLine());

            Triangle triangle = new Triangle(ax, ay, bx, by, cx, cy, a, b, c);
            Console.WriteLine($"Координати точок вершин: A ({ax};{ay}), B ({bx};{by}), C ({cx};{cy})");
            Console.WriteLine($"Довжини сторін: a = {a}, b = {b}, c = {c}");
            Console.WriteLine($"                                 ");
            Console.WriteLine($"Перемитер трикутника дорівнює {triangle.GetPerimeter()}");
            Console.WriteLine($"Площа трикутника дорівнює {triangle.GetArea()}");
        }
    }
}
