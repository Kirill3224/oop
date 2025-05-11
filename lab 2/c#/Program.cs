using System.ComponentModel.DataAnnotations;
using System.Linq;
 
namespace ConsoleApp7
{
    class String
    {
        private string a;

        public String()
        {
            a = "";
        }

        public String(string A)
        {
            a = A;
        }

        public String(String other)
        {
            a = other.a;
        }

        public string stringReturn()
        {
            return a;
        }
        public int stringLength()
        {
            return a.Length;
        }

        public string stringReversed()
        {
            string reversed = new string(a.Reverse().ToArray());
            return reversed;
        }

        ~String()
        {

        }
    }
}