namespace SecondLab.Core.Interfaces;

public interface IBook
{
    string Name { get; set; }
    string SerialNumber { get; set; }
    int PublicationYear { get; set; }
    int CostOfCopy { get; set; }
    int CountOfCopys { get; set; }
}