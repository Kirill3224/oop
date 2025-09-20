using FirstLab.Data.Database;
using FirstLab.Data.FileServices;

namespace FirstLab.Console.Commands;

public class LoadDataCommand : ICommand
{
    private readonly TextFileService _textFileService;
    private readonly IDatabaseService _databaseService;

    public LoadDataCommand(TextFileService textFileService, IDatabaseService databaseService)
    {
        _textFileService = textFileService;
        _databaseService = databaseService;
    }

    public CommandResult Execute()
    {
        try
        {
            if (!_textFileService.FileExists())
            {
                return new CommandResult
                {
                    Success = false,
                    Message = "Файл з даними не знайдено"
                };
            }

            var persons = _textFileService.ReadAllPersons().ToList();

            if (persons.Count == 0)
            {
                return new CommandResult
                {
                    Success = false,
                    Message = "Файл не містить валідних даних"
                };
            }

            _databaseService.Clear();

            int loadedCount = 0;
            int errorCount = 0;

            foreach (var person in persons)
            {
                try
                {
                    _databaseService.InsertPerson(person);
                    loadedCount++;
                }
                catch (Exception ex)
                {
                    errorCount++;
                    System.Console.WriteLine($"Помилка завантаження {person.ObjectName}: {ex.Message}");
                }
            }

            return new CommandResult
            {
                Success = loadedCount > 0,
                Message = $"Завантажено: {loadedCount}, Помилок: {errorCount}",
                Data = loadedCount
            };
        }
        catch (Exception ex)
        {
            return new CommandResult
            {
                Success = false,
                Message = $"Помилка завантаження даних: {ex.Message}"
            };
        }
    }

    public string Description => "Завантажити дані з файлу в БД";
}