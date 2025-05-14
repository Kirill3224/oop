using System;

namespace ConsoleApp9
{
    class Program
    {
        static void Main()
        {

            BoolClass b = new BoolClass(6);
            b[0] = true;
            b[1] = false;
            b[2] = false;
            b[3] = true;
            b[4] = false;
            b[5] = true;

            Console.WriteLine($"Обернений елемент масиву: {b[0]}");
            Console.WriteLine($"Логічна сумма АБО: {b.logicalSum}");

        }
    }
}
