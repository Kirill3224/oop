using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введіть ваш рядок: ");
            string a = Console.ReadLine();

            String str = new String(a);
            //str.a = a;

            Console.WriteLine($"Ваш рядок: {str.stringReturn()}");
            Console.WriteLine($"Перевернутий рядок: {str.stringReversed()}");
            Console.WriteLine($"Ваш рядок: {str.stringLength()}");
        }
    }
}
