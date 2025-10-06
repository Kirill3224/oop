using SecondLab.Data.Repositories;
using SecondLab.Core.Item;

namespace SecondLab.Data.Initializations;

public static class InitializeListData
{
    public static void InitializeList(IBookRepository repository)
    {
        repository.AddBook(new Book
        {
            Name = "C# Programming",
            SerialNumber = "978-966-555-2003-0",
            PublicationYear = 2024,
            CostOfCopy = 100,
            CountOfCopys = 500
        });

        repository.AddBook(new Book
        {
            Name = "OOP Principles",
            SerialNumber = "978-966-555-1004-3",
            PublicationYear = 2022,
            CostOfCopy = 180,
            CountOfCopys = 250
        });

        repository.AddBook(new Book
        {
            Name = "Data Structures",
            SerialNumber = "978-966-555-1005-0",
            PublicationYear = 2024,
            CostOfCopy = 120,
            CountOfCopys = 400
        });

        repository.AddBook(new Book
        {
            Name = "Algorithms",
            SerialNumber = "978-966-555-2005-4",
            PublicationYear = 2023,
            CostOfCopy = 150,
            CountOfCopys = 300
        });
    }
}