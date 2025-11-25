

using Warehouse.BLL.Services;

namespace Warehouse.Main.Managers;

public class GlobalSearch
{
    private readonly ProductService _productService;
    private readonly SupplierService _supplierService;

    public GlobalSearch(ProductService productService, SupplierService supplierService)
    {
        _productService = productService;
        _supplierService = supplierService;
    }
    public void Run()
    {
        Console.Clear();
        MinorMethods.PrintHeader("ГЛОБАЛЬНИЙ ПОШУК");
        Console.Write("Введіть ключове слово: ");
        string keyword = Console.ReadLine();

        Console.WriteLine("\n=== Знайдені Товари ===");
        var products = _productService.Search(keyword);
        foreach (var p in products) Console.WriteLine($"ID:{p.Id} | {p.Name} ({p.Brand}) - {p.Price} грн");

        Console.WriteLine("\n=== Знайдені Постачальники ===");
        var suppliers = _supplierService.Search(keyword);
        foreach (var s in suppliers) Console.WriteLine($"ID:{s.Id} | {s.FullName}");

        Console.WriteLine("\nНатисніть Enter...");
        Console.ReadKey();
    }
}