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
            Console.WriteLine("Введіть перший рядок: ");
            string s1 = Console.ReadLine();

            Console.WriteLine("Введіть другий рядок: ");
            string s2 = Console.ReadLine();

            Console.WriteLine("Введіть третій рядок: ");
            string s3 = Console.ReadLine();

            String str = new String(s1, s2, s3);

            Console.WriteLine("                                  ");
            Console.WriteLine($"Ваші рядки: {str.Return(s1, s2)} {str.Return(s3)}");
            Console.WriteLine($"2 рядок + 3 рядок = {str.GetMerge(s2, s3)}");
            Console.WriteLine($"Результат минулої дії + 1 рядок = {str.GetMerge(s1)}");
            Console.WriteLine("                                  ");
            Console.WriteLine($"Довжина фінальгого рядка: {str.stringLength()}");
        }
    }
}
