using SecondLab.Console.Manager;

namespace SecondLab.Console.Commands;

public class SwitchRepositoryCommand : ICommand
{
    private readonly BookRepositoryManager _repositoryManager;

    public SwitchRepositoryCommand(BookRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public CommandResult Execute()
    {
        return new CommandResult
        {
            Success = false,
            Message = ""
        };
    }

    public CommandResult Execute(string input)
    {
        try
        {

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        _repositoryManager.SwitchToListRepository();
                        return new CommandResult
                        {
                            Success = true,
                            Message = "!! Переключено на СПИСОК (List)"
                        };
                    case 2:
                        _repositoryManager.SwitchToArrayRepository();
                        return new CommandResult
                        {
                            Success = true,
                            Message = "!! Переключено на МАССИВ (Array)"
                        };
                    case 3:
                        return new CommandResult
                        {
                            Success = true,
                            Message = "Повернення назад"
                        };
                    default:
                        return new CommandResult
                        {
                            Success = false,
                            Message = "Невірний вибір!"
                        };
                }
            }

            else
            {
                return new CommandResult
                {
                    Success = false,
                    Message = "Введіть число!"
                };
            }
        }
        catch (Exception ex)
        {
            return new CommandResult
            {
                Success = false,
                Message = $"❌ Помилка: {ex.Message}"
            };
        }
    }
    public string Description => "Змінити колекцію книг";
}