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

        public int GetPerimeter()
        {
            return a + b + c;
        }

        public double GetArea()
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }
}