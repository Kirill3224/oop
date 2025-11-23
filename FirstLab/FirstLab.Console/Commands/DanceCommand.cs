using FirstLab.Core.Entities;
using FirstLab.Data.Database;

namespace FirstLab.Console.Commands;

public class DanceCommand : ICommand
{
    private readonly IDatabaseService _databaseService;

    public DanceCommand(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public CommandResult Execute()
    {
        try
        {
            var allPersons = _databaseService.GetAllPersons();
            var acrobats = allPersons.OfType<Acrobat>().ToList();

            if (acrobats.Count == 0)
            {
                return new CommandResult
                {
                    Success = false,
                    Message = "У базі нема акробатів"
                };
            }

            foreach (var acrobat in acrobats)
            {
                acrobat.Dance();
            }

            return new CommandResult
            {
                Success = true,
                Message = $"Акробати провели демонстрацію свого танцу",
                Data = acrobats.Count
            };
        }
        catch (Exception ex)
        {
            return new CommandResult
            {
                Success = false,
                Message = $"Помилка виконання танцю: {ex.Message}"
            };
        }
    }

    public string Description => "Виконати танець для всіх Акробатів";
}