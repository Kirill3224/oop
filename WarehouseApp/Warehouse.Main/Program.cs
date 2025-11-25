using System.Text;
using Warehouse.BLL.Services;
using Warehouse.Core.Entities;
using Warehouse.Data.Repositories;
using Warehouse.Main.Managers;
using Warehouse.Main.Menus;

namespace Warehouse.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Warehouse System";

            try
            {
                var productRepo = new JsonRepository<Product>("products.json");
                var categoryRepo = new JsonRepository<Category>("categories.json");
                var supplierRepo = new JsonRepository<Supplier>("suppliers.json");

                var categoryService = new CategoryService(categoryRepo);
                var productService = new ProductService(productRepo, categoryRepo);
                var supplierService = new SupplierService(supplierRepo);

                var manageCategories = new ManageCategories(productService, categoryService);
                var manageProducts = new ManageProducts(productService, categoryService);
                var manageSuppliers = new ManageSuppliers(productService, supplierService);
                var globalSearch = new GlobalSearch(productService, supplierService);

                var mainMenu = new MainMenu(manageCategories, manageProducts, manageSuppliers, globalSearch);

                mainMenu.Show();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Критична помилка запуску: {ex.Message}");
                Console.ReadKey();
            }
        }
    }

}