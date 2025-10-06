using SecondLab.Core.Item;
using SecondLab.Data.Validators;

namespace SecondLab.Data.Repositories;

public class BookArrayRepository : IBookRepository
{
    private Book[] _books;
    private int _count;

    public BookArrayRepository(int capacity = 4)
    {
        _books = new Book[capacity];
        _count = 0;
    }

    public void AddBook(Book book)
    {
        if (_count >= _books.Length)
        {
            throw new InvalidOperationException($"Масив заповнений! Максимальна кількість книг: {_books.Length}");
        }

        if (BookValidator.ValidateBook(book))
        {
            _books[_count] = book;
            _count++;
        }
    }

    public IEnumerable<Book> GetAllBooks()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _books[i];
        }
    }
}