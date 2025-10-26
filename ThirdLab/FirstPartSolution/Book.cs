using System.Runtime.Serialization;

namespace FirstPartSolution;

[Serializable]
public class Book : ISerializable
{
    public string SerialNumber { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public int CopiesCount { get; set; }

    public Book() { }

    protected Book(SerializationInfo info, StreamingContext context)
    {
        SerialNumber = info.GetString("SerialNumber");
        Title = info.GetString("Title");
        Year = info.GetInt32("Year");
        Price = info.GetDecimal("Price");
        CopiesCount = info.GetInt32("CopiesCount");
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("SerialNumber", SerialNumber);
        info.AddValue("Title", Title);
        info.AddValue("Year", Year);
        info.AddValue("Price", Price);
        info.AddValue("CopiesCount", CopiesCount);
    }

    public void IncreasePrice(decimal percentage)
    {
        Price += Price * (percentage / 100);
    }

    public decimal GetTotalValue()
    {
        return Price * CopiesCount;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Серійний номер: {SerialNumber}");
        Console.WriteLine($"Назва: {Title}");
        Console.WriteLine($"Рік видання: {Year}");
        Console.WriteLine($"Вартість: {Price}");
        Console.WriteLine($"Кількість примірників: {CopiesCount}");
        Console.WriteLine($"Загальна вартість тиражу: {GetTotalValue()}");
    }
}