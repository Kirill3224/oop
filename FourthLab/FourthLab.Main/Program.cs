using FourthLab.Logic;

namespace Lab.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new string('-', 30));
            RunTask1();
            Console.WriteLine(new string('-', 30));
            RunTasks2And3();
        }

        private static void RunTask1()
        {
            Console.WriteLine("--- Задание 1: Анонімний метод та Лямбда ---");

            CharCounter counterAnonymous = delegate (string text, char symbol)
            {
                int count = 0;
                foreach (char c in text)
                {
                    if (c == symbol) count++;
                }
                return count;
            };

            CharCounter counterLambda = (text, symbol) =>
            {
                int count = 0;
                foreach (char c in text)
                {
                    if (c == symbol) count++;
                }
                return count;
            };

            string testString = "Привіт, світе! Це моя лабораторна робота.";
            char searchChar = 'о';

            int result1 = counterAnonymous(testString, searchChar);
            Console.WriteLine($"Анонімний метод: Символ '{searchChar}' знайдено {result1} разів.");

            int result2 = counterLambda(testString, searchChar);
            Console.WriteLine($"Лямбда-вираз: Символ '{searchChar}' знайдено {result2} разів.");
        }

        private static void RunTasks2And3()
        {
            Console.WriteLine("--- Завдання 2 та 3: Події ---");

            MathOperations math = new MathOperations();

            math.DivisionPerformed += Math_DivisionPerformed;

            try
            {
                Console.WriteLine("\nВиконуємо 10 / 3...");
                int res1 = math.IntegerDivide(10, 3);
                Console.WriteLine($"Результат в Main: {res1}");


                Console.WriteLine("\nВиконуємо 100 / 5...");
                int res2 = math.IntegerDivide(100, 5);
                Console.WriteLine($"Результат в Main: {res2}");

                Console.WriteLine("\nВиконуємо 8 / 0...");
                math.IntegerDivide(8, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Помилка в Main: {ex.Message}");
                Console.ResetColor();
            }
        }

        private static void Math_DivisionPerformed(object sender, IntegerDivisionEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[ПОДІЯ!] Стався цілий поділ:");
            Console.WriteLine($"  > Ділене: {e.Dividend}");
            Console.WriteLine($"  > Дільник: {e.Divisor}");
            Console.WriteLine($"  > Результат: {e.Result}");

            if (sender is MathOperations)
            {
                Console.WriteLine("  > Джерело: MathOperations");
            }
            Console.ResetColor();
        }
    }
}