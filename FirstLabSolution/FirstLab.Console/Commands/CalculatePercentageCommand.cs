using System.Data;
using FirstLab.Core.Utilities.Calculators;
using FirstLab.Data.Database;

namespace FirstLab.Console.Commands;

public class CalculatePrecentageCommand : ICommand
{
    private readonly IDatabaseService _databaseService;

    public CalculatePrecentageCommand(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public CommandResult Execute()
    {
        try
        {
            var persons = _databaseService.GetAllPersons();
            double precentage = StudentCalculator.CalculatePrecentage(persons);

            return new CommandResult
            {
                Success = true,
                Message = $"Відсоток студентів першого курсу не з Києва: {precentage:F2}%",
                Data = precentage
            };
        }
        catch (Exception ex)
        {
            return new CommandResult
            {
                Success = false,
                Message = $"Сталася помилка під час підрахунку відстотку: {ex.Message}"
            };
        }
    }
    public string Description => "Показати відсоток студентів першого курсу не з Києва";
}

