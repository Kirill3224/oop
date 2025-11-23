using FirstLab.Data.Database;

namespace FirstLab.Console.Commands;

public class FindByLastNameCommand : ICommand
{
    private readonly IDatabaseService _databaseService;

    public FindByLastNameCommand(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public CommandResult Execute()
    {
        try
        {
            System.Console.Write("Введіть прізвище для пошуку: ");
            string lastName = System.Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(lastName))
            {
                return new CommandResult
                {
                    Success = false,
                    Message = "Прізвище не може бути порожнім"
                };
            }

            var person = _databaseService.FindByLastName(lastName);

            if (person == null)
            {
                return new CommandResult
                {
                    Success = false,
                    Message = $"Особа з прізвищем '{lastName}' не знайдена"
                };
            }

            string message = $"Знайдено: {person.FirstName} {person.LastName}\n" +
                           $"Тип: {person.ObjectType}\n" +
                           $"Ім'я об'єкта: {person.ObjectName}\n" +
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

    public string Description => "Знайти людину за прізвищем";
}