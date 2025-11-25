using Warehouse.Main.Managers;

namespace Warehouse.Main.Menus;

public class MainMenu
{
    private readonly ManageCategories _manageCategories;
    private readonly ManageProducts _manageProducts;
    private readonly ManageSuppliers _manageSuppliers;
    private readonly GlobalSearch _globalSearch;

    public MainMenu(ManageCategories manageCategories, ManageProducts manageProducts, ManageSuppliers manageSuppliers, GlobalSearch globalSearch)
    {
        _manageCategories = manageCategories;
        _manageProducts = manageProducts;
        _manageSuppliers = manageSuppliers;
        _globalSearch = globalSearch;
    }

    public void Show()
    {
        Console.Title = "Warehouse Management System";
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            MinorMethods.PrintHeader("ГОЛОВНЕ МЕНЮ");
            Console.WriteLine("1. Управління Товарами");
            Console.WriteLine("2. Управління Категоріями");
            Console.WriteLine("3. Управління Постачальниками");
            Console.WriteLine("4. Пошук");
            Console.WriteLine("0. Вихід");
            Console.Write("\nВаш вибір: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": _manageProducts.Run(); break;
                case "2": _manageCategories.Run(); break;
                case "3": _manageSuppliers.Run(); break;
                case "4": _globalSearch.Run(); break;
                case "0": exit = true; break;
                default:
                    MinorMethods.ShowError("Невірний вибір, спробуйте ще раз.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}