using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ConsoleApp7
{
    class String
    {
        private string a;

        public String(string A)
        {
            a = A;
        }

        public string stringReturn() => a;
        public int stringLength() => a.Length;

        public string stringReversed()
        {
            string reversed = new string(a.Reverse().ToArray());
            return reversed;
        }

        static void Main()
        {

            Console.WriteLine("Введіть ваш рядок: ");
            string a = Console.ReadLine();

            String str = new String(a);

            Console.WriteLine($"Ваш рядок: {str.stringReturn()}");
            Console.WriteLine($"Перевернутий рядок: {str.stringReversed()}");
            Console.WriteLine($"Ваш рядок: {str.stringLength()}");

        }
    }
}

