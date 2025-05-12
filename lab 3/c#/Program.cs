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

        public string Return(string a, string b) => s1 + " " + s2;
        public string Return(string c) => s3;
        public string GetMerge(string s3, string s2) => s3 + s2;
        public string GetMerge(string s1) => s1 + GetMerge(s3, s2);

        public int stringLength() => GetMerge(s1).Length;

        public void RemoveChar(char ch)
        {
            s1 = s1.Replace(ch.ToString(), "");
            s2 = s2.Replace(ch.ToString(), "");
            s3 = s3.Replace(ch.ToString(), "");
        }

        ~String()
        {

        }

    }
}