using SecondLab.Core.Item;
using SecondLab.Data.Repositories;


namespace SecondLab.Console.Commands;

public class FindByNameCommand : ICommand
{
    private readonly IBookRepository _repository;

    public FindByNameCommand(IBookRepository repository)
    {
        _repository = repository;
    }

    public CommandResult Execute()
    {
        try
        {
            var books = _repository.GetAllBooks();

            if (!books.Any())
            {
                return new CommandResult
                {
                    Success = true,
                    Message = "Список книг порожній"
                };
            }

            return new CommandResult
            {
                Success = true,
                Message = "Доступні книги отримані",
                Data = books
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

    public CommandResult Execute(string bookName)
    {
        try
        {
            var books = _repository.GetAllBooks();

            var foundBook = books.FirstOrDefault(b =>
                b.Name.Equals(bookName, StringComparison.OrdinalIgnoreCase));

            if (foundBook != null)
            {
                return new CommandResult
                {
                    Success = true,
                    Message = $"Книгу знайдено: {foundBook.Name}",
                    Data = foundBook
                };
            }
            else
            {
                return new CommandResult
                {
                    Success = false,
                    Message = $"Книгу з назвою '{bookName}' не знайдено"
                };
            }
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

    public string Description => "Знайти книгу по назві";
}

