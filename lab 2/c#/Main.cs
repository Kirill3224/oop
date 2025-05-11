using System;
using System.Linq;


namespace ConsoleApp7
{
    class Program
    {

        static void Main()
        {
            string a;

            Console.WriteLine("Введіть ваш рядок: ");
            a = Console.ReadLine();

            String str = new String(a);

            Console.WriteLine($"Ваш рядок: {str.stringReturn()}");
            Console.WriteLine($"Перевернутий рядок: {str.stringReversed()}");
            Console.WriteLine($"Ваш рядок: {str.stringLength()}");
        }
    }
}
