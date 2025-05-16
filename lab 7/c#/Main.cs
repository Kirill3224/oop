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
            try
            {
                Calculate[] numbers = new Calculate[3];
                {
                    numbers[0] = new Calculate(2, 5, 8);
                    numbers[1] = new Calculate(3, 6, 12);
                    numbers[2] = new Calculate(4, 7, 16);
                };

                foreach (var calc in numbers)
                {
                    double result = calc.Result();

                    Console.WriteLine($"Результат: {result}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }


        }

    }
}

