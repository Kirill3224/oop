using SecondLab.Core.Item;
using SecondLab.Data.Validators;

namespace SecondLab.Data.Repositories;

public class BookListRepository : IBookRepository
{
    private List<Book> _books = new List<Book>();

    public void AddBook(Book book)
    {
        if (BookValidator.ValidateBook(book))
        {
            _books.Add(book);
        }
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _books.ToList();
    }
}