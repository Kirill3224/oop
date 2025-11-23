using FifthLab.Main.Commands;

namespace FifthLab.Main.Menus;

public class ConsoleMenu
{
    private readonly List<ICommand> _commands;

    public ConsoleMenu(IEnumerable<ICommand> commands)
    {
        _commands = commands.ToList();
    }

    public void Run()
    {
        while (true)
        {
            System.Console.WriteLine("\n--- Головне Меню ---");

            foreach (var cmd in _commands)
            {
                System.Console.WriteLine(cmd.Name);
            }
            System.Console.WriteLine("x. Вихід");

            System.Console.Write("Ваш вибір: ");
            string choice = System.Console.ReadLine();

            if (choice == "x")
            {
                break;
            }

            var command = _commands.FirstOrDefault(c => c.Name.Trim().StartsWith(choice));

            if (command != null)
            {
                command.Execute();
            }
            else
            {
                System.Console.WriteLine("Невідома команда. Спробуйте ще раз.");
            }
        }
    }
}
