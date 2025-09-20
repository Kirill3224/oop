using FirstLab.Core.Entities;
using FirstLab.Data.Database;

namespace FirstLab.Console.Commands;

public class DriveCommand : ICommand
{
    private readonly IDatabaseService _databaseService;

    public DriveCommand(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public CommandResult Execute()
    {
        try
        {
            var allPersons = _databaseService.GetAllPersons();
            var drivers = allPersons.OfType<TaxiDriver>().ToList();

            if (drivers.Count == 0)
            {
                return new CommandResult
                {
                    Success = false,
                    Message = "У базі нема водіїв таксі"
                };
            }

            foreach (var driver in drivers)
            {
                driver.Drive();
            }

            return new CommandResult
            {
                Success = true,
                Message = $"Водії ведуть свої машини",
                Data = drivers.Count
            };
        }
        catch (Exception ex)
        {
            return new CommandResult
            {
                Success = false,
                Message = $"Помилка початку руху: {ex.Message}"
            };
        }
    }

    public string Description => "Почати рух для всіх Водіїв таксі";
}