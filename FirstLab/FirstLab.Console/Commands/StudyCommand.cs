using FirstLab.Core.Entities;
using FirstLab.Data.Database;

namespace FirstLab.Console.Commands;

public class StudyCommand : ICommand
{
    private readonly IDatabaseService _databaseService;

    public StudyCommand(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public CommandResult Execute()
    {
        try
        {
            var allPersons = _databaseService.GetAllPersons();
            var students = allPersons.OfType<Student>().ToList();

            if (students.Count == 0)
            {
                return new CommandResult
                {
                    Success = false,
                    Message = "У базі нема студентів"
                };
            }

            foreach (var student in students)
            {
                student.Study();
            }

            return new CommandResult
            {
                Success = true,
                Message = $"Студенти почали навчання",
                Data = students.Count
            };
        }
        catch (Exception ex)
        {
            return new CommandResult
            {
                Success = false,
                Message = $"Помилка початку навчання: {ex.Message}"
            };
        }
    }

    public string Description => "Почати навчання для всіх студентів";
}