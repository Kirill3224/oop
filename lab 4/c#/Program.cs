using System;
using System.Drawing;

namespace ConsoleApp5
{
    class Figure
    {
        protected Point A;
        protected Point B;
        protected Point C;
        protected int a, b, c;

        protected Figure(int ax, int ay, int bx, int by, int cx, int cy, int a, int b, int c)
        {
            A = new Point(ax, ay);
            B = new Point(bx, by);
            C = new Point(cx, cy);
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }
    class Triangle : Figure
    {

        public Triangle(int ax, int ay, int bx, int by, int cx, int cy, int a, int b, int c) : base(ax, ay, bx, by, cx, cy, a, b, c) { }

        public int GetPerimeter() => a + b + c;

        public double GetArea()
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        static void Main()
        {
            int ax, ay, bx, by, cx, cy, a, b, c;

            Console.WriteLine("������ ������� ������� a");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("������ ������� ������� b");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("������ ������� ������� c");
            c = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("������ ���������� ����� A (x,y)");
            ax = Convert.ToInt32(Console.ReadLine());
            ay = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("������ ���������� ����� B (x,y)");
            bx = Convert.ToInt32(Console.ReadLine());
            by = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("������ ���������� ����� C (x,y)");
            cx = Convert.ToInt32(Console.ReadLine());
            cy = Convert.ToInt32(Console.ReadLine());

            Triangle triangle = new Triangle(ax, ay, bx, by, cx, cy, a, b, c);

            Console.WriteLine($"��������� ���������� = {triangle.GetPerimeter()}");
            Console.WriteLine($"����� ���������� = {triangle.GetArea()}");
        }
    }
}