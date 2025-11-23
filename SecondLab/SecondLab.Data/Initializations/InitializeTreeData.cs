using SecondLab.Data.Sturctures;
using SecondLab.Core.Item;

namespace SecondLab.Data.Initializations;

public static class InitializeTreeData
{
    public static void InitializeTree(BinaryTree<Book> tree)
    {
        tree.Add(new Book
        {
            Name = "Кобзар",
            SerialNumber = "978-966-000-0001-3",
            PublicationYear = 1840,
            CostOfCopy = 220,
            CountOfCopys = 500
        });

        tree.Add(new Book
        {
            Name = "Темні води",
            SerialNumber = "978-966-123-4507-9",
            PublicationYear = 2015,
            CostOfCopy = 100,
            CountOfCopys = 900
        });

        tree.Add(new Book
        {
            Name = "Так казав Заратустра",
            SerialNumber = "978-966-123-4508-6",
            PublicationYear = 1885,
            CostOfCopy = 330,
            CountOfCopys = 230
        });

        tree.Add(new Book
        {
            Name = "Практика створення REST API на .NET",
            SerialNumber = "978-966-555-2002-3",
            PublicationYear = 2023,
            CostOfCopy = 600,
            CountOfCopys = 200
        });
    }
}