using FifthLab.Core.Services;

namespace FifthLab.Main.Commands;

public class CalculatePercentageCommand : ICommand
{
    public string Name => "1. Порахувати відсоток першокурсників з інших міст";
    private readonly StudentService _studentService;

    public CalculatePercentageCommand(StudentService studentService)
    {
        _studentService = studentService;
    }

    public void Execute()
    {
        double percentage = _studentService.CalculatePercentageOfFirstYearsFromOtherCities();
        Console.WriteLine($"Відсоток: {percentage:F2}%");
    }
}