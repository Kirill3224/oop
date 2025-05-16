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
            TextContainer container = new TextContainer();

            container.addLine("   Це    приклад    рядка   з   пробілами.   ");
            container.addLine("  Ще  один   рядок  для   тесту. ");
            container.addLine("Без   змін, але   з   лишніми    пробілами. ");
            Console.WriteLine("До очищення:");
            container.printAll();

            container.cleanAll();
            Console.WriteLine("  ");
            Console.WriteLine("Після очищення:");
            container.printAll();
        }
    }
}
