using FirstLab.Data.Database;
using FirstLab.Core.Entities;

namespace FirstLab.Console.Commands;

public class ShowAllCommand : ICommand
{
    private readonly IDatabaseService _databaseService;

    public ShowAllCommand(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public CommandResult Execute()
    {
        try
        {
            var persons = _databaseService.GetAllPersons().ToList();

            if (persons.Count == 0)
                return new CommandResult { Success = false, Message = "База даних порожня" };

            var result = new System.Text.StringBuilder();
            result.AppendLine("=== Всі люди в базі даних ===");

            foreach (var person in persons)
            {
                result.AppendLine($"Тип: {person.ObjectType}");
                result.AppendLine($"Ім'я: {person.FirstName}, Прізвище: {person.LastName}");
                result.AppendLine($"Вік: {person.Age}");

                if (person is Student student)
                {
                    result.AppendLine($"Курс: {student.Course}");
                    result.AppendLine($"Місто: {student.City}");
                    result.AppendLine($"Id Cтудентського: {student.StudentId}");
                    result.AppendLine($"Id Пасопрта: {student.PassportId}");
                }

                result.AppendLine();
            }

            return new CommandResult
            {
                Success = true,
                Message = result.ToString(),
                Data = persons.Count
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

    public string Description => "Показати всіх людей в базі даних";
}