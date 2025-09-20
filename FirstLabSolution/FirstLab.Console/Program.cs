using FirstLab.Console.Menus;

namespace FirstLab.Console;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var menu = new ConsoleMenu();
            menu.Show();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Критична помилка: {ex.Message}");
            System.Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            System.Console.ReadKey();
        }
    }
}