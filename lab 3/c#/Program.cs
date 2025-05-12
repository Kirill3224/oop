using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace ConsoleApp7
{
    class String
    {
        private string s1;
        private string s2;
        private string s3;

        public String()
        {
            s1 = "";
            s2 = "";
            s3 = "";
        }

        public String(string S1, string S2, string S3)
        {
            s1 = S1;
            s2 = S2;
            s3 = S3;
        }

        public String(String other)
        {
            s1 = other.s1;
            s2 = other.s2;
            s3 = other.s3;

        }

        public string aReturn() => s1;
        public string bReturn() => s2;
        public string cReturn() => s3;
        public string aGetMerge() => s3 + s2;
        public string bGetMerge() => s1 + aGetMerge();
        public int stringLength() => bGetMerge().Length;

        public void RemoveChar(char ch)
        {
            s1 = s1.Replace(ch.ToString(), "");
            s2 = s2.Replace(ch.ToString(), "");
            s3 = s3.Replace(ch.ToString(), "");
        }

        ~String()
        {

        }

        static void Main()
        {
            Console.WriteLine("������ ������ ��� �����: ");
            string s1 = Console.ReadLine();

            Console.WriteLine("������ ������ ��� �����: ");
            string s2 = Console.ReadLine();

            Console.WriteLine("������ ����� ��� �����: ");
            string s3 = Console.ReadLine();

            String str = new String(s1, s2, s3);
            str.RemoveChar('#');

            Console.WriteLine($"��� �����: {str.aReturn()}, {str.bReturn()}, {str.cReturn()}");
            Console.WriteLine("                                  ");
            Console.WriteLine($"2 ����� + 3 ����� = {str.aGetMerge()}");
            Console.WriteLine($"��������� ������ 䳿 + 1 ����� = {str.bGetMerge()}");
            Console.WriteLine("                                  ");
            Console.WriteLine($"������� ���������� �����: {str.stringLength()}");
        }

    }
}