using SecondPartSolution.StudentBusinessLogic.Services;
using SecondPartSolution.StudentPresentation.Menus;

namespace SecondPartSolution.StudentPresentation;

class Program
{
    static void Main()
    {
        try
        {
            var studentService = new StudentService();
            var mainMenu = new MainMenu(studentService);

            mainMenu.Show();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Критична помилка: {ex.Message}");
            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}