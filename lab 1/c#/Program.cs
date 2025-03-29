using System;

class StringClass
{
    private string s;

    public StringClass()
    {
        s = "";
    }

    public StringClass(string s)
    {
        this.s = s;
    }

    public StringClass(StringClass other)
    {
        s = other.s;
    }

    public int GetLength()
    {
        return s.Length;
    }

    public string Reversed()
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public string GetString()
    {
        return s;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Придумайте рядок (на англійській мові): ");
        string input = Console.ReadLine();

        StringClass str = new StringClass(input);
        Console.WriteLine("Ваш рядок: " + str.GetString());
        Console.WriteLine("Довжина рядка: " + str.GetLength());
        Console.WriteLine("Перевернутий рядок: " + str.Reversed());
    }
}