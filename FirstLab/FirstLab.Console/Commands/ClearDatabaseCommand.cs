using FirstLab.Data.Database;

namespace FirstLab.Console.Commands;

public class ClearDatabaseCommand : ICommand
{
    private readonly IDatabaseService _databaseService;

    public ClearDatabaseCommand(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public CommandResult Execute()
    {
        try
        {
            _databaseService.Clear();
            return new CommandResult
            {
                Success = true,
                Message = "Базу даних очищено"
            };
        }
        catch (Exception ex)
        {
            return new CommandResult
            {
                Success = false,
                Message = $"Помилка: {ex.Message}"
            };
        }
    }

    public string Description => "Очистити базу даних";
}