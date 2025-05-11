using System;

namespace ConsoleApp7
{
    class Program
    {

        static void Main()
        {
            string s1, s2, s3;


            Console.WriteLine("Введіть перший ваш рядок: ");
            s1 = Console.ReadLine();

            Console.WriteLine("Введіть другий ваш рядок: ");
            s2 = Console.ReadLine();

            Console.WriteLine("Введіть третій ваш рядок: ");
            s3 = Console.ReadLine();

            String str = new String(s1, s2, s3);
            str.RemoveChar('#');

            Console.WriteLine($"Ваш рядок: {str.aReturn()}, {str.bReturn()}, {str.cReturn()}");
            Console.WriteLine("                                  ");
            Console.WriteLine($"2 рядок + 3 рядок = {str.aGetMerge()}");
            Console.WriteLine($"Результат минулої дії + 1 рядок = {str.bGetMerge()}");
            Console.WriteLine("                                  ");
            Console.WriteLine($"Довжина фінальгого рядка: {str.stringLength()}");
        }
    }
}
