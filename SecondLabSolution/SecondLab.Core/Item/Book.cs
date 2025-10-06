using SecondLab.Core.Interfaces;

namespace SecondLab.Core.Item;

public class Book : IBook, IComparable<Book>
{
    public string Name { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public int CostOfCopy { get; set; }
    public int CountOfCopys { get; set; }

    public int CompareTo(Book other)
    {
        if (other == null)
        {
            return 1;
        }
        ;
        return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"{Name} ({PublicationYear}) - {CostOfCopy} грн";
    }
}