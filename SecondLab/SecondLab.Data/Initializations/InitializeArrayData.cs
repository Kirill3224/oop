using SecondLab.Data.Repositories;
using SecondLab.Core.Item;

namespace SecondLab.Data.Initializations;

public static class InitializeArrayData
{
    public static void InitializeArray(IBookRepository repository)
    {
        repository.AddBook(new Book
        {
            Name = "C# для крутих чуваків",
            SerialNumber = "CSH-001",
            PublicationYear = 2021,
            CostOfCopy = 250,
            CountOfCopys = 200
        });

        repository.AddBook(new Book
        {
            Name = "Алгоритми та структури даних",
            SerialNumber = "ALG-001",
            PublicationYear = 2023,
            CostOfCopy = 300,
            CountOfCopys = 150
        });

        repository.AddBook(new Book
        {
            Name = "Бази даних",
            SerialNumber = "DB-001",
            PublicationYear = 2024,
            CostOfCopy = 280,
            CountOfCopys = 180
        });

        repository.AddBook(new Book
        {
            Name = "Веб-програмування",
            SerialNumber = "WEB-001",
            PublicationYear = 2024,
            CostOfCopy = 320,
            CountOfCopys = 120
        });
    }
}