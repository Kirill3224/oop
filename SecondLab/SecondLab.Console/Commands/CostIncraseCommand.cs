using SecondLab.Core.Item;
using SecondLab.Data.Repositories;

namespace SecondLab.Console.Commands;

public class CostIncraseCommand : ICommand
{
    private readonly IBookRepository _repository;

    public CostIncraseCommand(IBookRepository repository)
    {
        _repository = repository;
    }

    public static decimal CalculateIncreasedCost(decimal currentCost, decimal percentage)
    {
        return currentCost * (1 + percentage / 100);
    }

    public CommandResult Execute()
    {
        return new CommandResult
        {
            Success = false,
            Message = "Для цієї команди потрібно вказати назву книги та відсоток. Використовуйте Execute(string bookName, decimal percentage)."
        };
    }

    public CommandResult Execute(string bookName, decimal percentage)
    {
        var book = _repository.GetAllBooks()
            .FirstOrDefault(b => b.Name.Equals(bookName, StringComparison.OrdinalIgnoreCase));

        if (book == null)
            return new CommandResult { Success = false, Message = "Книга не знайдена" };

        decimal oldPrice = book.CostOfCopy;
        decimal newPrice = CalculateIncreasedCost(oldPrice, percentage);
        book.CostOfCopy = (int)newPrice;

        return new CommandResult
        {
            Success = true,
            Message = $"Ціну збільшено: {oldPrice} → {newPrice} грн (+{percentage}%)"
        };
    }

    public string Description => "Підвищити ціну на книгу";

}