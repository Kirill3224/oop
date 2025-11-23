using FifthLab.Main.Commands;
using FifthLab.Main.Menus;
using FifthLab.Core.Entities;
using FifthLab.Core.Interfaces;
using FifthLab.Core.Services;
using FifthLab.Data;

namespace FirstLab.Main;

class Program
{
    static void Main(string[] args)
    {
        IRepository<Student> studentRepository = new JsonRepository<Student>("PersonData.json");
        var studentService = new StudentService(studentRepository);

        var commands = new List<ICommand>
            {
                new CalculatePercentageCommand(studentService),

            };

        var menu = new ConsoleMenu(commands);

        System.Console.WriteLine("Ласкаво просимо до системи!");
        menu.Run();
        System.Console.WriteLine("До побачення!");
    }
}