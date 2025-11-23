using SecondLab.Core.Item;

namespace SecondLab.Data.Repositories;

public interface IBookRepository
{
    public void AddBook(Book book);
    IEnumerable<Book> GetAllBooks();

}