using System.Text;
using Warehouse.BLL.Services;
using Warehouse.Core.Entities;
using Warehouse.Core.Exceptions;
using Warehouse.Data.Repositories;

namespace Warehouse.Main.Managers;

public class ManageProducts
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;

    public ManageProducts(ProductService productService, CategoryService categoryService)
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
            MinorMethods.PrintHeader("УПРАВЛІННЯ ТОВАРАМИ");
            Console.WriteLine("1. Список товарів (Сортування)");
            Console.WriteLine("2. Додати товар");
            Console.WriteLine("3. Редагувати товар / Змінити кількість");
            Console.WriteLine("4. Видалити товар");
            Console.WriteLine("5. Деталі товару");
            Console.WriteLine("0. Назад");
            Console.Write("\nДія: ");

            string choice = Console.ReadLine();
            if (choice == "0") break;

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nСортувати за: 1.Назвою, 2.Брендом, 3.Ціною (Enter - без сортування)");
                        string s = Console.ReadLine();
                        string sort = s == "1" ? "name" : s == "2" ? "brand" : s == "3" ? "price" : null;
                        MinorMethods.PrintList(_productService.GetAll(sort));
                        break;

                    case "2":
                        Console.WriteLine("\n--- Оберіть категорію (ID) ---");
                        MinorMethods.PrintList(_categoryService.GetAll());
                        Console.Write("ID Категорії: ");
                        int catId = int.Parse(Console.ReadLine());

                        Console.Write("Назва: "); string name = Console.ReadLine();
                        Console.Write("Бренд: "); string brand = Console.ReadLine();
                        Console.Write("Ціна: "); decimal price = decimal.Parse(Console.ReadLine());
                        Console.Write("Кількість: "); int qty = int.Parse(Console.ReadLine());

                        _productService.AddProduct(new Product
                        {
                            Name = name,
                            Brand = brand,
                            Price = price,
                            Quantity = qty,
                            CategoryId = catId
                        });
                        MinorMethods.ShowSuccess("Товар додано!");
                        break;

                    case "3":
                        Console.Write("Введіть ID товару для зміни: ");
                        int editId = int.Parse(Console.ReadLine());
                        var pEdit = _productService.GetById(editId);
                        if (pEdit == null) throw new ValidationException("Товар не знайдено");

                        Console.WriteLine($"\nРедагування '{pEdit.Name}'. Натисніть Enter, щоб залишити старе значення.");

                        Console.Write($"Нова назва ({pEdit.Name}): ");
                        string nName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nName)) pEdit.Name = nName;

                        Console.Write($"Новий бренд ({pEdit.Brand}): ");
                        string nBrand = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nBrand)) pEdit.Brand = nBrand;

                        Console.Write($"Нова ціна ({pEdit.Price}): ");
                        string nPrice = Console.ReadLine();
                        if (decimal.TryParse(nPrice, out decimal dPrice)) pEdit.Price = dPrice;

                        Console.Write($"Нова кількість ({pEdit.Quantity}): ");
                        string nQty = Console.ReadLine();
                        if (int.TryParse(nQty, out int dQty)) pEdit.Quantity = dQty;

                        _productService.UpdateProduct(pEdit);
                        MinorMethods.ShowSuccess("Товар оновлено!");
                        break;

                    case "4":
                        Console.Write("ID для видалення: ");
                        _productService.DeleteProduct(int.Parse(Console.ReadLine()));
                        MinorMethods.ShowSuccess("Товар видалено.");
                        break;

                    case "5":
                        Console.Write("Введіть ID товару: ");
                        var pView = _productService.GetById(int.Parse(Console.ReadLine()));
                        if (pView != null)
                        {
                            Console.WriteLine("\n-------------------------------");
                            Console.WriteLine($"ID:       {pView.Id}");
                            Console.WriteLine($"Назва:    {pView.Name}");
                            Console.WriteLine($"Бренд:    {pView.Brand}");
                            Console.WriteLine($"Категорія ID: {pView.CategoryId}");
                            Console.WriteLine($"Ціна:     {pView.Price} грн");
                            Console.WriteLine($"Склад:    {pView.Quantity} шт.");
                            Console.WriteLine("-------------------------------");
                        }
                        else MinorMethods.ShowError("Товар не знайдено");
                        Console.WriteLine("\nНатисніть будь-яку клавішу...");
                        Console.ReadKey();
                        break;
                }
            }
            catch (FormatException) { MinorMethods.ShowError("Невірний формат введення числа."); }
            catch (ValidationException ex) { MinorMethods.ShowError(ex.Message); }
            catch (Exception ex) { MinorMethods.ShowError($"Помилка: {ex.Message}"); }
        }
    }
}