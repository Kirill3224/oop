using System;

namespace ConsoleApp9
{
    class BoolClass
    {
        private bool[] data;

        public BoolClass(int Data)
        {
            data = new bool[Data];
        }

        public bool this[int index]
        {
            get
            {
                if (index >= 0 && index < data.Length)
                    return !data[index];
                else throw new IndexOutOfRangeException();
            }

            set
            {
                if (index >= 0 && index < data.Length)
                    data[index] = value;
                else
                    Console.WriteLine("Індекс виходить за межі масиву"); ;
            }
        }
        public bool logicalSum
        {
            get
            {
                bool result = false;
                foreach (var element in data)
                {
                    result = result | element;
                }
                return result;
            }
        }
    }
}
