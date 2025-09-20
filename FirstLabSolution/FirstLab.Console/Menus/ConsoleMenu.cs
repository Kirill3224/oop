using FirstLab.Console.Commands;
using FirstLab.Data.Database;
using FirstLab.Data.FileServices;
using FirstLab.Data.Parsers;
using FirstLab.Data.Services;

namespace FirstLab.Console.Menus;

public class ConsoleMenu
{
    private readonly List<ICommand> _commands = new();

    public ConsoleMenu()
    {
        string filePath = "/home/xxkdl/Projects/CSLabs/FirstLabSolution/StudentData.txt";

        IFileService fileService = new FileService();
        IPersonParser personParser = new PersonParser();
        TextFileService textFileService = new TextFileService(filePath, fileService, personParser);
        IDatabaseService databaseService = new FileDatabaseService(textFileService);

        _commands.Add(new LoadDataCommand(textFileService, databaseService));
        _commands.Add(new ShowAllCommand(databaseService));
        _commands.Add(new CalculatePrecentageCommand(databaseService));
        _commands.Add(new FindByLastNameCommand(databaseService));
        _commands.Add(new FindByObjectNameCommand(databaseService));
        _commands.Add(new ClearDatabaseCommand(databaseService));
        _commands.Add(new StudyCommand(databaseService));
        _commands.Add(new DriveCommand(databaseService));
        _commands.Add(new DanceCommand(databaseService));
    }

    public void Show()
    {
        System.Console.WriteLine("=== Система управління персонами ===");

        while (true)
        {
            try
            {
                System.Console.WriteLine("\n" + new string('=', 40));
                System.Console.WriteLine("ГОЛОВНЕ МЕНЮ");
                System.Console.WriteLine(new string('=', 40));

                for (int i = 0; i < _commands.Count; i++)
                {
                    System.Console.WriteLine($"{i + 1}. {_commands[i].Description}");
                }
                System.Console.WriteLine($"{_commands.Count + 1}. Вихід");
                System.Console.WriteLine(new string('=', 40));

                System.Console.Write("Оберіть дію: ");
                string input = System.Console.ReadLine() ?? "";

                if (input.ToLower() == "exit" || input.ToLower() == "вихід")
                    break;

                if (int.TryParse(input, out int choice))
                {
                    if (choice == _commands.Count + 1)
                        break;

                    if (choice > 0 && choice <= _commands.Count)
                    {
                        System.Console.WriteLine();
                        var result = _commands[choice - 1].Execute();

                        if (result.Success)
                            System.Console.WriteLine($"{result.Message}");
                        else
                            System.Console.WriteLine($"{result.Message}");
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