namespace FirstPartSolution;

public static class InitializeBookData
{
    public static void InitializeData(BookRepository repository)
    {
        repository.AddBook(new Book
        {
            Title = "Так казав Заратустра",
            SerialNumber = "CSH-001",
            Year = 1883,
            Price = 250,
            CopiesCount = 200
        });

        repository.AddBook(new Book
        {
            Title = "Бази даних",
            SerialNumber = "DB-39",
            Year = 2024,
            Price = 140,
            CopiesCount = 350
        });

        repository.AddBook(new Book
        {
            Title = "Веб-програмування",
            SerialNumber = "WEB-041",
            Year = 2021,
            Price = 90,
            CopiesCount = 1000
        });

        repository.AddBook(new Book
        {
            Title = "Алгоритми та структури даних",
            SerialNumber = "ALG-029",
            Year = 2023,
            Price = 567,
            CopiesCount = 150
        });
    }
}