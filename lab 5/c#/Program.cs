using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace ConsoleApp9
{
    class Strings
    {
        protected string s1;

        protected Strings(string S1)
        {
            this.s1 = S1;
        }

        public virtual string withoutChar()
        {
            return s1.Replace("", "");
        }

        public virtual int stringLength()
        {
            return s1.Length;
        }

        public virtual string getString()
        {
            return s1;
        }

    }

    class Numbers : Strings
    {
        public Numbers(string a) : base(a) { }

        public override string withoutChar()
        {
            return s1.Replace("5", "");
        }

        public override int stringLength()
        {
            return withoutChar().Length;
        }

        public override string getString()
        {
            return s1;
        }
    }

    class Letters : Strings
    {
        public Letters(string b) : base(b) { }

        public override string withoutChar()
        {
            return s1.Replace("a", "");
        }

        public override int stringLength()
        {
            return withoutChar().Length;
        }

        public virtual string getString()
        {
            return s1;
        }
    }

}