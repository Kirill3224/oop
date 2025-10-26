using System;

namespace FirstPartSolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("-- Лабораторна робота 3 - Частина 1 --");
            Console.WriteLine("-- Дослідження механізму серіалізації --\n");

            SerializationDemo.DemonstrateAllRequirements();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
