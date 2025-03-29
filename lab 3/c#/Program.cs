using System;

class StringHandler
{
    private string s1;
    private string s2;
    private string s3;

    public StringHandler()
    {
        s1 = "";
        s2 = "";
        s3 = "";
    }

    public StringHandler(string s1, string s2, string s3)
    {
        this.s1 = s1;
        this.s2 = s2;
        this.s3 = s3;
    }

    public string GetString1() => s1;
    public string GetString2() => s2;
    public string GetString3() => s3;
    public string GetMerge1() => s2 + s3;
    public string GetMerge2() => GetMerge1() + s1;
    public int GetLength() => GetMerge2().Length;

    public void RemoveChar(char ch)
    {
        s1 = s1.Replace(ch.ToString(), "");
        s2 = s2.Replace(ch.ToString(), "");
        s3 = s3.Replace(ch.ToString(), "");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Придумайте перший рядок (на англійській мові): ");
        string s1 = Console.ReadLine();

        Console.Write("Придумайте другий рядок (на англійській мові): ");
        string s2 = Console.ReadLine();

        Console.Write("Придумайте третій рядок (на англійській мові): ");
        string s3 = Console.ReadLine();

        StringHandler str = new StringHandler(s1, s2, s3);

        Console.WriteLine($"Ваші рядки: {str.GetString1()}, {str.GetString2()}, {str.GetString3()}");
        str.RemoveChar('#');

        Console.WriteLine($"Результат складання рядку 2 та 3: {str.GetMerge1()}");
        Console.WriteLine($"Результат додавання сумми рядків 2 та 3 до 1 рядка: {str.GetMerge2()}");
        Console.WriteLine($"Довжина об'єднаного рядка: {str.GetLength()}");
    }
}