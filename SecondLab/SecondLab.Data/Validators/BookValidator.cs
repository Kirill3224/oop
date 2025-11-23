using SecondLab.Core.Item;
using System.Text.RegularExpressions;

namespace SecondLab.Data.Validators;

class BookValidator
{
    public static bool ValidateName(string Name)
    {
        if (string.IsNullOrEmpty(Name))
        {
            return false;
        }

        return Regex.IsMatch(Name, @"^[A-Za-zА-Яа-яҐґЄєІіЇї\s\-\#\d]+$");
    }

    public static bool ValidateSerialNumber(string SerialNumber)
    {
        if (string.IsNullOrEmpty(SerialNumber))
        {
            return false;
        }

        return Regex.IsMatch(SerialNumber, @"^[A-Z0-9\-]{3,20}$", RegexOptions.IgnoreCase);
    }

    public static bool ValidatePublicationYear(int PublicationYear)
    {
        return PublicationYear > 0 && PublicationYear <= DateTime.Now.Year + 1; ;
    }

    public static bool ValidateCostOfCopy(int CostOfCopy)
    {
        return CostOfCopy > 0;
    }

    public static bool ValidateCountOfCopys(int CountOfCopys)
    {
        return CountOfCopys > 0;
    }

    public static bool ValidateBook(Book book)
    {
        return ValidateName(book.Name) && ValidateSerialNumber(book.SerialNumber) && ValidatePublicationYear(book.PublicationYear) && ValidateCostOfCopy(book.CostOfCopy) && ValidateCountOfCopys(book.CountOfCopys);
    }
}