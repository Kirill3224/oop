using SecondLab.Core.Item;

namespace SecondLab.Data.Sturctures;

public class BinaryPriceComparer : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;

        return x.CostOfCopy.CompareTo(y.CostOfCopy);
    }
}