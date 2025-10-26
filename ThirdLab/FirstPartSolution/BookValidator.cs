using System.Text.RegularExpressions;

namespace FirstPartSolution;

class BookValidator
{
    public static bool ValidateTitle(string Title)
    {
        if (string.IsNullOrEmpty(Title))
        {
            return false;
        }

        return Regex.IsMatch(Title, @"^[A-Za-zА-Яа-яҐґЄєІіЇї\s\-\#\d]+$");
    }

    public static bool ValidateSerialNumber(string SerialNumber)
    {
        if (string.IsNullOrEmpty(SerialNumber))
        {
            return false;
        }

        return Regex.IsMatch(SerialNumber, @"^[A-Z0-9\-]{3,20}$", RegexOptions.IgnoreCase);
    }

    public static bool ValidatePublicationYear(int Year)
    {
        return Year > 0 && Year <= DateTime.Now.Year + 1; ;
    }

    public static bool ValidatePrice(decimal Price)
    {
        return Price > 0;
    }

    public static bool ValidateCopiesCount(int CopiesCount)
    {
        return CopiesCount > 0;
    }

    public static bool ValidateBook(Book book)
    {
        return ValidateTitle(book.Title) && ValidateSerialNumber(book.SerialNumber) && ValidatePublicationYear(book.Year) && ValidatePrice(book.Price) && ValidateCopiesCount(book.CopiesCount);
    }
}