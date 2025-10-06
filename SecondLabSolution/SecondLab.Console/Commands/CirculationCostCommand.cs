using SecondLab.Core.Item;
using SecondLab.Data.Repositories;

namespace SecondLab.Console.Commands;

public class CirculationCostCommand : ICommand
{
    private readonly IBookRepository _repository;

    public CirculationCostCommand(IBookRepository repository)
    {
        _repository = repository;
    }

    public static decimal GetTotalCirculationCost(Book book)
    {
        return book.CountOfCopys * book.CostOfCopy;
    }

    public CommandResult Execute()
    {
        try
        {
            var books = _repository.GetAllBooks();
            var result = new System.Text.StringBuilder();
            result.AppendLine("-- Вартість тиражу книг --");

            decimal totalCost = 0;

            foreach (var book in books)
            {
                decimal bookCost = GetTotalCirculationCost(book);
                totalCost += bookCost;

                result.AppendLine($"{book.Name}: {bookCost} грн");
            }

            result.AppendLine(new string('-', 30));
            result.AppendLine($"ЗАГАЛЬНА ВАРТІСТЬ: {totalCost} грн");

            return new CommandResult
            {
                Success = true,
                Message = result.ToString(),
                Data = totalCost
            };
        }
        catch (Exception ex)
        {
            return new CommandResult
            {
                Success = false,
                Message = $"Помилка: {ex.Message}"
            };
        }
    }

    public string Description => "Показати вартість тиражу всіх книг";
}

