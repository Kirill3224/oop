using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main()
        {
            int ax, ay, bx, by, cx, cy, a, b, c;

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Введіть довжину сторони a");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть довжину сторони b");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть довжину сторони c");
            c = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введіть координати точки A (x,y)");
            ax = Convert.ToInt32(Console.ReadLine());
            ay = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть координати точки B (x,y)");
            bx = Convert.ToInt32(Console.ReadLine());
            by = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть координати точки C (x,y)");
            cx = Convert.ToInt32(Console.ReadLine());
            cy = Convert.ToInt32(Console.ReadLine());

            Triangle triangle = new Triangle(ax, ay, bx, by, cx, cy, a, b, c);

            Console.WriteLine($"Периметер трикутника = {triangle.GetPerimeter()}");
            Console.WriteLine($"Площа трикутника = {triangle.GetArea()}");
        }
    }
}
