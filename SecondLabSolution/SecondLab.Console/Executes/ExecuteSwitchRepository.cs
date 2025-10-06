using System.Diagnostics;
using SecondLab.Console.Commands;
using SecondLab.Console.Manager;
using SecondLab.Core.Item;
using SecondLab.Data.Repositories;

namespace SecondLab.Console.Executes;

public static class ExecuteSwitchRepository
{
    public static void ExecSwitchRepository(BookRepositoryManager _repositoryManager)
    {
        try
        {

            var command = new SwitchRepositoryCommand(_repositoryManager);

            System.Console.WriteLine("\n" + new string('-', 40));
            System.Console.WriteLine("ВИБІР ТИПУ КОЛЕКЦІЇ");
            System.Console.WriteLine(new string('-', 40));
            System.Console.WriteLine("1. Список (List) - динамічний розмір");
            System.Console.WriteLine("2. Масив (Array) - фіксований розмір (4 книги)");
            System.Console.WriteLine("3. Назад");
            System.Console.WriteLine(new string('-', 40));

            System.Console.Write("Оберіть тип колекції: ");
            string input = System.Console.ReadLine() ?? "";

            var result = command.Execute(input);
            System.Console.WriteLine(result.Message);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }
}