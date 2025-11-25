using Warehouse.BLL.Services;
using Warehouse.Core.Entities;
using Warehouse.Core.Exceptions;

namespace Warehouse.Main.Managers;

public class ManageSuppliers
{
    private readonly ProductService _productService;
    private readonly SupplierService _supplierService;

    public ManageSuppliers(ProductService productService, SupplierService supplierService)
    {
        _productService = productService;
        _supplierService = supplierService;
    }

    public void Run()
    {
        if (_productService == null) throw new Exception("ManageProducts not initialized!");

        while (true)
        {
            Console.Clear();
            MinorMethods.PrintHeader("УПРАВЛІННЯ ПОСТАЧАЛЬНИКАМИ");
            Console.WriteLine("1. Список (Сортування)");
            Console.WriteLine("2. Додати");
            Console.WriteLine("3. Редагувати");
            Console.WriteLine("4. Видалити");
            Console.WriteLine("5. Деталі");
            Console.WriteLine("0. Назад");
            Console.Write("\nДія: ");

            string choice = Console.ReadLine();
            if (choice == "0") break;

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Сортувати: 1.Ім'я, 2.Прізвище");
                        string s = Console.ReadLine();
                        string sort = s == "1" ? "name" : s == "2" ? "lastname" : null;
                        MinorMethods.PrintList(_supplierService.GetAll(sort));
                        break;
                    case "2":
                        Console.Write("Ім'я: "); string fn = Console.ReadLine();
                        Console.Write("Прізвище: "); string ln = Console.ReadLine();
                        Console.Write("Телефон: "); string ph = Console.ReadLine();
                        Console.Write("Email: "); string em = Console.ReadLine();
                        _supplierService.AddSupplier(new Supplier { FirstName = fn, LastName = ln, Phone = ph, Email = em });
                        MinorMethods.ShowSuccess("Додано!");
                        break;
                    case "3":
                        Console.Write("ID постачальника: ");
                        var sEdit = _supplierService.GetById(int.Parse(Console.ReadLine()));
                        if (sEdit == null) throw new ValidationException("Не знайдено");

                        Console.Write($"Ім'я ({sEdit.FirstName}): ");
                        string nFn = Console.ReadLine(); if (!string.IsNullOrWhiteSpace(nFn)) sEdit.FirstName = nFn;

                        Console.Write($"Прізвище ({sEdit.LastName}): ");
                        string nLn = Console.ReadLine(); if (!string.IsNullOrWhiteSpace(nLn)) sEdit.LastName = nLn;

                        Console.Write($"Телефон ({sEdit.Phone}): ");
                        string nPh = Console.ReadLine(); if (!string.IsNullOrWhiteSpace(nPh)) sEdit.Phone = nPh;

                        _supplierService.UpdateSupplier(sEdit);
                        MinorMethods.ShowSuccess("Оновлено!");
                        break;
                    case "4":
                        Console.Write("ID для видалення: ");
                        _supplierService.DeleteSupplier(int.Parse(Console.ReadLine()));
                        MinorMethods.ShowSuccess("Видалено!");
                        break;
                    case "5":
                        Console.Write("ID постачальника: ");
                        var sView = _supplierService.GetById(int.Parse(Console.ReadLine()));
                        if (sView != null)
                            Console.WriteLine($"\nПостачальник: {sView.FullName}\nКонтакти: {sView.Phone}, {sView.Email}");
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