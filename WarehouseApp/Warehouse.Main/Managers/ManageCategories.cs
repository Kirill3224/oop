using System.Text;
using Warehouse.BLL.Services;
using Warehouse.Core.Entities;
using Warehouse.Core.Exceptions;
using Warehouse.Data.Repositories;

namespace Warehouse.Main.Managers;

public class ManageCategories
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;

    public ManageCategories(ProductService productService, CategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public void Run()
    {
        if (_productService == null) throw new Exception("ManageProducts not initialized!");

        while (true)
        {
            Console.Clear();
            MinorMethods.PrintHeader("УПРАВЛІННЯ КАТЕГОРІЯМИ");
            Console.WriteLine("1. Список категорій");
            Console.WriteLine("2. Додати категорію");
            Console.WriteLine("3. Редагувати категорію");
            Console.WriteLine("4. Видалити категорію");
            Console.WriteLine("5. Деталі категорії");
            Console.WriteLine("0. Назад");
            Console.Write("\nДія: ");

            string choice = Console.ReadLine();
            if (choice == "0") break;

            try
            {
                switch (choice)
                {
                    case "1":
                        MinorMethods.PrintList(_categoryService.GetAll());
                        break;
                    case "2":
                        Console.Write("Назва категорії: ");
                        _categoryService.AddCategory(Console.ReadLine());
                        MinorMethods.ShowSuccess("Створено!");
                        break;
                    case "3":
                        Console.Write("ID категорії: ");
                        var cEdit = _categoryService.GetById(int.Parse(Console.ReadLine()));
                        if (cEdit == null) throw new ValidationException("Не знайдено");

                        Console.Write($"Нова назва ({cEdit.Name}): ");
                        string newName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newName)) cEdit.Name = newName;

                        _categoryService.UpdateCategory(cEdit);
                        MinorMethods.ShowSuccess("Оновлено!");
                        break;
                    case "4":
                        Console.Write("ID для видалення: ");
                        _categoryService.DeleteCategory(int.Parse(Console.ReadLine()));
                        MinorMethods.ShowSuccess("Видалено!");
                        break;
                    case "5":
                        Console.Write("ID категорії: ");
                        var cView = _categoryService.GetById(int.Parse(Console.ReadLine()));
                        if (cView != null) Console.WriteLine($"\n[ID: {cView.Id}] Категорія: {cView.Name}");
                        else MinorMethods.ShowError("Не знайдено");
                        Console.WriteLine("\nНатисніть будь-яку клавішу...");
                        Console.ReadKey();
                        break;
                }
            }
            catch (Exception ex) { MinorMethods.ShowError(ex.Message); Console.ReadKey(); }
        }
    }
}