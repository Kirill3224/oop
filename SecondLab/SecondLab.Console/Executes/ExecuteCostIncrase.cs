using SecondLab.Console.Commands;
using SecondLab.Data.Repositories;

namespace SecondLab.Console.Executes;

public static class ExecuteCostIncrase
{
    public static void ExecCostIncrase(IBookRepository _repository)
    {
        var books = _repository.GetAllBooks().ToList();

        System.Console.WriteLine("Доступні книги:");
        for (int i = 0; i < books.Count; i++)
        {
            System.Console.WriteLine($"{i + 1}. {books[i].Name}");
        }
        System.Console.WriteLine(new string('-', 40));

        System.Console.Write("Оберіть номер книги: ");
        string? input = System.Console.ReadLine();

        if (!int.TryParse(input, out int choice) || choice < 1 || choice > books.Count)
        {
            System.Console.WriteLine("Некоректний вибір!");
            return;
        }

        string _selectedBookName = books[choice - 1].Name;
        System.Console.WriteLine(new string('-', 40));
        System.Console.Write("Введіть відсоток збільшення: ");
        decimal _percentage = decimal.Parse(System.Console.ReadLine());
        if (!decimal.TryParse(input, out decimal percentage) || percentage < 0)
        {
            System.Console.WriteLine("Некоректний відсоток!");
            return;
        }

        var command = new CostIncraseCommand(_repository);
        var result = command.Execute(_selectedBookName, _percentage);

        System.Console.WriteLine(result.Message);
    }
}