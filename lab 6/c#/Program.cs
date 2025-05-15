using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace ConsoleApp9
{
    class Data
    {
        protected double a { get; set; }
        protected double c { get; set; }
        protected double d { get; set; }

        public Data(double a, double c, double d)
        {
            this.a = a;
            this.c = c;
            this.d = d;
        }
    }

    static class Log
    {
        public static double getLog(double value)
        {
            if (value <= 0)
                throw new ArgumentException("Неможливо обчислити логарифм від непозитивного числа.");
            else return Math.Log10(value);
        }
    }

    class Calculate : Data
    {
        public Calculate(double d, double c, double a) : base(d, c, a)
        {
        }

        public double Result()
        {
            double numerator = (2 * c - Log.getLog(d / 4));
            double denominator = a * a - 1;

            if (denominator == 0)
                throw new DivideByZeroException("Ділення на нуль неможливе.");
            else return numerator / denominator;
        }
    }
}
