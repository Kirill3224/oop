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

            Console.WriteLine("������ ��� �����: ");
            string a = Console.ReadLine();

            String str = new String(a);

            Console.WriteLine($"��� �����: {str.stringReturn()}");
            Console.WriteLine($"������������ �����: {str.stringReversed()}");
            Console.WriteLine($"��� �����: {str.stringLength()}");

        }
    }
}

