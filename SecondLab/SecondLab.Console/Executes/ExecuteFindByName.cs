using SecondLab.Console.Commands;
using SecondLab.Core.Item;
using SecondLab.Data.Repositories;

namespace SecondLab.Console.Executes;

public static class ExecuteFindByName
{
    public static void ExecFindByName(IBookRepository repository)
    {
        try
        {
            var command = new FindByNameCommand(repository);

            var booksResult = command.Execute();
            var books = repository.GetAllBooks().ToList();

            if (books == null || !books.Any())
            {
                System.Console.WriteLine("Немає книг для пошуку");
                return;
            }

            System.Console.WriteLine("Доступні книги:");
            foreach (var book in books)
            {
                System.Console.WriteLine($"- {book.Name}");
            }
            System.Console.WriteLine(new string('-', 40));
            System.Console.Write("Введіть назву книги для пошуку: ");
            string? bookName = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(bookName))
            {
                System.Console.WriteLine("Назва книги не може бути порожньою");
                return;
            }

            var result = command.Execute(bookName);

            if (result.Success)
            {
                var foundBook = result.Data as Book;
                System.Console.WriteLine($"!! Книгу знайдено:");
                System.Console.WriteLine($"   Назва: {foundBook.Name}");
                System.Console.WriteLine($"   Серійний номер: {foundBook.SerialNumber}");
                System.Console.WriteLine($"   Рік видання: {foundBook.PublicationYear}");
                System.Console.WriteLine($"   Ціна: {foundBook.CostOfCopy} грн");
                System.Console.WriteLine($"   Тираж: {foundBook.CountOfCopys} прим.");
            }
            else
            {
                System.Console.WriteLine($"! {result.Message}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}