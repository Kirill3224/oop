using FirstLab.Data.Database;

namespace FirstLab.Console.Commands;

public class FindByObjectNameCommand : ICommand
{
    private readonly IDatabaseService _databaseService;

    public FindByObjectNameCommand(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public CommandResult Execute()
    {
        try
        {
            System.Console.Write("Введіть ім'я об'єкта для пошуку: ");
            string objectName = System.Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(objectName))
            {
                return new CommandResult
                {
                    Success = false,
                    Message = "Ім'я об'єкта не може бути порожнім"
                };
            }

            var person = _databaseService.FindByObjectName(objectName);

            if (person == null)
            {
                return new CommandResult
                {
                    Success = false,
                    Message = $"Об'єкт з ім'ям '{objectName}' не знайдений"
                };
            }

            string message = $"Знайдено: {person.ObjectName}\n" +
                           $"Тип: {person.ObjectType}\n" +
                           $"Ім'я: {person.FirstName} {person.LastName}\n" +
                           $"Вік: {person.Age}";

            if (person is Core.Entities.Student student)
            {
                message += $"\nКурс: {student.Course}\nМісто: {student.City}";
            }

            return new CommandResult
            {
                Success = true,
                Message = message,
                Data = person
            };
        }
        catch (Exception ex)
        {
            return new CommandResult
            {
                Success = false,
                Message = $"Помилка пошуку: {ex.Message}"
            };
        }
    }

    public string Description => "Знайти людину за ім'ям об'єкта";
}