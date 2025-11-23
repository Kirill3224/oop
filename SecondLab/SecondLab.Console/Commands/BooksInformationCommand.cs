using SecondLab.Data.Repositories;
using SecondLab.Core.Item;

namespace SecondLab.Console.Commands;

public class BookInformationCommand : ICommand
{
    private readonly IBookRepository _repository;

    public BookInformationCommand(IBookRepository repository)
    {
        _repository = repository;
    }

    public CommandResult Execute()
    {
        try
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine("-- Вся інформація про кожну книгу --");

            var books = _repository.GetAllBooks();

            if (!books.Any())
            {
                return new CommandResult
                {
                    Success = true,
                    Message = "Список книг порожній"
                };
            }

            foreach (var book in books)
            {
                result.AppendLine();
                result.AppendLine($"Назва: {book.Name}");
                result.AppendLine($"Серійний номер ISBN: {book.SerialNumber}");
                result.AppendLine($"Рік видавництва: {book.PublicationYear}");
                result.AppendLine($"Ціна за копію: {book.CostOfCopy}");
                result.AppendLine($"Кулькість копій: {book.CountOfCopys}");
                result.AppendLine();
            }

            return new CommandResult
            {
                Success = true,
                Message = result.ToString(),
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

    public string Description => "Показати всю інформацію про кожну книгу";
}