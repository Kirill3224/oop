using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введіть пешрий рядок: ");
            string a = Console.ReadLine();

            Console.Write("Введіть другий рядок: ");
            string b = Console.ReadLine();

            Strings n = new Numbers(a);
            Strings l = new Letters(b);
            ShowInfo(n); 
            ShowInfo(l); 
        }

        static void ShowInfo(Strings str)
        {
            Console.WriteLine();
            Console.WriteLine("Оригинальний рядок: " + str.getString());
            Console.WriteLine("Без заборонених символів: " + str.withoutChar());
            Console.WriteLine("Довжина рядка: " + str.stringLength());
        }
    }
}
