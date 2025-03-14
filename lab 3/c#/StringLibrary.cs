using System;
using System.Text;

namespace StringLibrary
{
    public class StringClass
    {
        private string str;

        // Конструктор за замовчуванням
        public StringClass()
        {
            str = string.Empty;
        }

        // Конструктор з параметрами
        public StringClass(string s)
        {
            str = s;
        }

        // Конструктор копіювання
        public StringClass(StringClass other)
        {
            str = other.str;
        }

        // Властивість для отримання значення рядка (без можливості змінювати)
        public string Value => str;

        // Властивість для отримання довжини рядка
        public int Length => str.Length;

        // Перевантаження оператора +
        public static StringClass operator +(StringClass a, StringClass b)
        {
            return new StringClass(a.str + b.str);
        }

        // Перевантаження оператора -
        public static StringClass operator -(StringClass a, char ch)
        {
            return new StringClass(a.str.Replace(ch.ToString(), ""));
        }

        // Присвоєння (копіювання)
        public StringClass Copy()
        {
            return new StringClass(this);
        }
    }
}
