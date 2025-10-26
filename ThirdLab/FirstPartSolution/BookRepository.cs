using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;


namespace FirstPartSolution;

public class BookRepository
{
    private Book[] _books;
    private int _count;

    public BookRepository(int capacity = 4)
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

    public Book[] GetBooks() => _books.Take(_count).ToArray();
    public int Count => _count;

    public void BinarySerializeArray(string filePath)
    {
        Book[] booksArray = GetBooks();
        using (var writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            writer.Write(booksArray.Length);
            foreach (var book in booksArray)
            {
                writer.Write(book.SerialNumber ?? "");
                writer.Write(book.Title ?? "");
                writer.Write(book.Year);
                writer.Write(book.Price);
                writer.Write(book.CopiesCount);
            }
        }
    }

    public Book[] BinaryDeserializeToNewArray(string filePath)
    {
        using (var reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            int length = reader.ReadInt32();
            Book[] newArray = new Book[length];

            for (int i = 0; i < length; i++)
            {
                newArray[i] = new Book
                {
                    SerialNumber = reader.ReadString(),
                    Title = reader.ReadString(),
                    Year = reader.ReadInt32(),
                    Price = reader.ReadDecimal(),
                    CopiesCount = reader.ReadInt32()
                };
            }
            return newArray;
        }
    }

    public void CustomSerializeArray(string filePath)
    {
        Book[] booksArray = GetBooks();
        using (var writer = new StreamWriter(filePath))
        {
            foreach (var book in booksArray)
            {
                writer.WriteLine($"{book.SerialNumber}|{book.Title}|{book.Year}|{book.Price}|{book.CopiesCount}");
            }
        }
    }

    public Book[] CustomDeserializeToNewArray(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        Book[] newArray = new Book[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            var parts = lines[i].Split('|');
            if (parts.Length == 5)
            {
                newArray[i] = new Book
                {
                    SerialNumber = parts[0],
                    Title = parts[1],
                    Year = int.Parse(parts[2]),
                    Price = decimal.Parse(parts[3]),
                    CopiesCount = int.Parse(parts[4])
                };
            }
        }
        return newArray;
    }

    public void XmlSerializeArray(string filePath)
    {
        Book[] booksArray = GetBooks();
        var serializer = new XmlSerializer(typeof(Book[]));
        using (var writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, booksArray);
        }
    }

    public Book[] XmlDeserializeToArray(string filePath)
    {
        var serializer = new XmlSerializer(typeof(Book[]));
        using (var reader = new StreamReader(filePath))
        {
            return (Book[])serializer.Deserialize(reader);
        }
    }

    public void JsonSerializeArray(string filePath)
    {
        Book[] booksArray = GetBooks();
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(booksArray, options);
        File.WriteAllText(filePath, json);
    }

    public Book[] JsonDeserializeToArray(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Book[]>(json);
    }

    public void JsonSerializeCollection(string filePath)
    {
        List<Book> booksList = _books.Take(_count).ToList();
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(booksList, options);
        File.WriteAllText(filePath, json);
    }

    public List<Book> JsonDeserializeCollection(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Book>>(json);
    }
}