using Warehouse.Core.Entities;

namespace Warehouse.Main;

public static class MinorMethods
{
    public static void PrintList<T>(IEnumerable<T> items, bool pause = true)
    {
        Console.WriteLine();
        int count = 0;
        foreach (var item in items)
        {
            int id = (item is BaseEntity entity) ? entity.Id : 0;
            Console.WriteLine($"#{count + 1} | ID:{id} | {item}");
            count++;
        }

        if (count == 0) Console.WriteLine("(Список порожній)");

        if (pause)
        {
            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }

    public static void PrintHeader(string title)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"=== {title} ===");
        Console.ResetColor();
    }

    public static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"!!! {message} !!!");

        Console.WriteLine("\nНатисніть будь-яку клавішу, щоб продовжити...");
        Console.ReadKey();
    }

    public static void ShowSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"OK: {message}");
        Console.ResetColor();

        Console.WriteLine("\nНатисніть будь-яку клавішу, щоб продовжити...");
        Console.ReadKey();
    }
}