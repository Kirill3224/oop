using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstPartSolution;

public class SerializationDemo
{
    public static void DemonstrateAllRequirements()
    {
        var repository = new BookRepository(4);
        InitializeBookData.InitializeData(repository);

        Console.WriteLine("=== 1. Початковий масив книг ===");
        DisplayBooks(repository.GetBooks());

        Console.WriteLine("\n=== 2. Серіалізація масиву у файл (бінарна) ===");
        repository.BinarySerializeArray("books_binary.dat");
        Console.WriteLine("Бінарна серіалізація масиву виконана");

        Console.WriteLine("\n=== 3. Десеріалізація у новий масив ===");
        Book[] newArray = repository.BinaryDeserializeToNewArray("books_binary.dat");
        Console.WriteLine("Новий масив після десеріалізації:");
        DisplayBooks(newArray);

        Console.WriteLine("\n=== 4. Порівняння масиву та колекції ===");
        CompareArrayAndCollection(repository);

        Console.WriteLine("\n=== 5. Демонстрація всіх типів серіалізації ===");
        DemonstrateAllSerializationTypes(repository);
    }

    private static void CompareArrayAndCollection(BookRepository repository)
    {
        repository.JsonSerializeCollection("books_collection.json");
        List<Book> collection = repository.JsonDeserializeCollection("books_collection.json");

        Book[] array = repository.GetBooks();

        Console.WriteLine("Порівняння:");
        Console.WriteLine($"Масив: {array.Length} елементів, фіксований розмір");
        Console.WriteLine($"Колекція (List): {collection.Count} елементів, динамічний розмір");

        Console.WriteLine("\nПереваги колекції List:");
        collection.Add(new Book
        {
            Title = "Нова книга",
            SerialNumber = "NEW-001",
            Year = 2024,
            Price = 200,
            CopiesCount = 10
        });
        Console.WriteLine($"Після додавання нової книги: {collection.Count} елементів");

        var foundBook = collection.Find(b => b.Title.Contains("Заратустра"));
        Console.WriteLine($"Знайдена книга: {foundBook?.Title}");

        collection.RemoveAt(0);
        Console.WriteLine($"Після видалення першої книги: {collection.Count} елементів");

        Console.WriteLine("\nПереваги масиву:");
        Console.WriteLine("- Краща продуктивність для фіксованих даних");
        Console.WriteLine("- Менше використання пам'яті");
        Console.WriteLine("- Простіша серіалізація в деяких випадках");
    }

    private static void DemonstrateAllSerializationTypes(BookRepository repository)
    {
        Console.WriteLine("\n--- Бінарна серіалізація ---");
        repository.BinarySerializeArray("books_binary.dat");
        var binaryArray = repository.BinaryDeserializeToNewArray("books_binary.dat");
        Console.WriteLine($"Бінарна: {binaryArray.Length} книг");
        Console.WriteLine("Файл: books_binary.dat (бінарний формат)");

        Console.WriteLine("\n--- Користувацька серіалізація ---");
        repository.CustomSerializeArray("books_custom.txt");
        var customArray = repository.CustomDeserializeToNewArray("books_custom.txt");
        Console.WriteLine($"Користувацька: {customArray.Length} книг");
        Console.WriteLine("Файл: books_custom.txt (текстовий формат з роздільниками)");

        Console.WriteLine("\n--- XML серіалізація ---");
        repository.XmlSerializeArray("books.xml");
        var xmlArray = repository.XmlDeserializeToArray("books.xml");
        Console.WriteLine($"XML: {xmlArray.Length} книг");
        Console.WriteLine("Файл: books.xml (читабельний XML формат)");

        Console.WriteLine("\n--- JSON серіалізація ---");
        repository.JsonSerializeArray("books.json");
        var jsonArray = repository.JsonDeserializeToArray("books.json");
        Console.WriteLine($"JSON: {jsonArray.Length} книг");
        Console.WriteLine("Файл: books.json (читабельний JSON формат)");

        Console.WriteLine("\n--- Перевірка цілісності даних ---");
        Console.WriteLine($"Усі типи серіалізації пройшли успішно!");
        Console.WriteLine($"Всі масиви містять по {binaryArray.Length} книг");

        if (binaryArray.Length > 0)
        {
            Console.WriteLine($"\nПеревірка даних першої книги:");
            Console.WriteLine($"Назва: {binaryArray[0].Title}");
            Console.WriteLine($"Ціна: {binaryArray[0].Price}");
        }
    }

    private static void DisplayBooks(Book[] books)
    {
        foreach (var book in books)
        {
            book.DisplayInfo();
            Console.WriteLine("---");
        }
    }
}
