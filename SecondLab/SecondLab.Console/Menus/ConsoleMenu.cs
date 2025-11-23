using SecondLab.Console.Commands;
using SecondLab.Console.Manager;
using SecondLab.Console.Executes;

namespace SecondLab.Console.Menus;

public class ConsoleMenu
{
    private readonly List<ICommand> _commands = new();
    private readonly BookRepositoryManager _repositoryManager;

    public ConsoleMenu()
    {
        _repositoryManager = new BookRepositoryManager();
        UpdateCommands();
    }

    private void UpdateCommands()
    {
        _commands.Clear();
        var currentRepo = _repositoryManager.GetCurrentRepository();

        _commands.Add(new SwitchRepositoryCommand(_repositoryManager));
        _commands.Add(new BinaryTreeDemoCommand());
        _commands.Add(new BookInformationCommand(currentRepo));
        _commands.Add(new CirculationCostCommand(currentRepo));
        _commands.Add(new CostIncraseCommand(currentRepo));
        _commands.Add(new FindByNameCommand(currentRepo));
    }

    public void Show()
    {
        System.Console.WriteLine("-- Система управління книгами --");

        while (true)
        {
            try
            {
                System.Console.WriteLine(new string('-', 40));
                System.Console.WriteLine("ГОЛОВНЕ МЕНЮ");
                System.Console.WriteLine(new string('-', 40));
                System.Console.WriteLine($"Поточна колекція: {_repositoryManager.GetCurrentRepositoryType()}");
                System.Console.WriteLine(new string('-', 40));

                for (int i = 0; i < _commands.Count; i++)
                {
                    System.Console.WriteLine($"{i + 1}. {_commands[i].Description}");
                }
                System.Console.WriteLine($"{_commands.Count + 1}. Вихід");
                System.Console.WriteLine(new string('-', 40));

                System.Console.Write("Оберіть дію: ");
                string input = System.Console.ReadLine() ?? "";

                if (int.TryParse(input, out int choice))
                {
                    if (choice == _commands.Count + 1)
                        break;

                    if (choice > 0 && choice <= _commands.Count)
                    {
                        System.Console.WriteLine();
                        var command = _commands[choice - 1];

                        if (command is CostIncraseCommand costIncreaseCommand)
                        {
                            ExecuteCostIncrase.ExecCostIncrase(_repositoryManager.GetCurrentRepository());
                        }
                        else if (command is FindByNameCommand findByNameCommand)
                        {
                            ExecuteFindByName.ExecFindByName(_repositoryManager.GetCurrentRepository());
                        }
                        else if (command is SwitchRepositoryCommand switchRepositoryCommand)
                        {
                            ExecuteSwitchRepository.ExecSwitchRepository(_repositoryManager);
                            UpdateCommands();
                        }
                        else
                        {
                            var result = command.Execute();
                            System.Console.WriteLine(result.Message);
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Невірний вибір!");
                    }
                }
                else
                {
                    System.Console.WriteLine("Введіть число!");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        System.Console.WriteLine("\nДо побачення!");
    }
}