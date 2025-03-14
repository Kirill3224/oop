using System;

namespace StringLibrary
{
    public class StringClass
    {
        private string _str;

        // Конструктор за замовчуванням
        public StringClass()
        {
            _str = string.Empty;
        }

        // Конструктор із параметром
        public StringClass(string input)
        {
            _str = input;
        }

        // Конструктор копіювання
        public StringClass(StringClass other)
        {
            _str = other._str;
        }

        // Властивість для отримання рядка (тільки для читання)
        public string Value => _str;

        // Властивість для отримання довжини рядка
        public int Length => _str.Length;

        // Метод для перевертання рядка
        public void Reverse()
        {
            char[] arr = _str.ToCharArray();
            Array.Reverse(arr);
            _str = new string(arr);
        }

        // Метод очищення рядка
        public void Clear()
        {
            _str = string.Empty;
        }
    }
}
