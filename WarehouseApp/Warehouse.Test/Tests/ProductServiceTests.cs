using Xunit; // Головний namespace
using Moq;
using Warehouse.BLL.Services;
using Warehouse.Core.Entities;
using Warehouse.Core.Interfaces;
using Warehouse.Core.Exceptions;

namespace Warehouse.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IRepository<Product>> _mockProductRepo;
        private readonly Mock<IRepository<Category>> _mockCategoryRepo;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _mockProductRepo = new Mock<IRepository<Product>>();
            _mockCategoryRepo = new Mock<IRepository<Category>>();
            _service = new ProductService(_mockProductRepo.Object, _mockCategoryRepo.Object);
        }

        [Fact]
        public void AddProduct_WithValidData_ShouldCallRepositoryAdd()
        {
            var validCategory = new Category { Id = 1, Name = "Test Category" };
            var validProduct = new Product
            {
                Name = "Laptop",
                Price = 1000,
                Quantity = 5,
                CategoryId = 1
            };

            _mockCategoryRepo.Setup(r => r.GetById(1)).Returns(validCategory);

            _service.AddProduct(validProduct);

            _mockProductRepo.Verify(x => x.Add(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void AddProduct_WithNegativePrice_ShouldThrowValidationException()
        {
            var badProduct = new Product { Name = "Phone", Price = -50 };

            var ex = Assert.Throws<ValidationException>(() => _service.AddProduct(badProduct));

            Assert.Contains("Ціна не може бути від'ємною", ex.Message);
        }

        [Fact]
        public void AddProduct_WithEmptyName_ShouldThrowValidationException()
        {
            var badProduct = new Product { Name = "", Price = 100 };
            Assert.Throws<ValidationException>(() => _service.AddProduct(badProduct));
        }

        [Fact]
        public void AddProduct_WithNonExistentCategory_ShouldThrowValidationException()
        {
            var product = new Product { Name = "Mouse", Price = 50, CategoryId = 999 };
            _mockCategoryRepo.Setup(r => r.GetById(999)).Returns((Category)null);

            var ex = Assert.Throws<ValidationException>(() => _service.AddProduct(product));
            Assert.Contains("Категорії з ID 999 не існує", ex.Message);
        }

        [Fact]
        public void GetAll_WithSortByName_ShouldReturnSortedProducts()
        {
            var products = new List<Product>
            {
                new Product { Name = "Zebra" },
                new Product { Name = "Apple" },
                new Product { Name = "Banana" }
            };
            _mockProductRepo.Setup(r => r.GetAll()).Returns(products);

            var result = _service.GetAll("name").ToList();

            Assert.Equal("Apple", result[0].Name);
            Assert.Equal("Banana", result[1].Name);
            Assert.Equal("Zebra", result[2].Name);
        }

        [Fact]
        public void DeleteProduct_ShouldCallRepositoryDelete()
        {
            int productId = 10;
            _service.DeleteProduct(productId);
            _mockProductRepo.Verify(r => r.Delete(productId), Times.Once);
        }
    }
}