using Moq;
using Warehouse.BLL.Services;
using Warehouse.Core.Entities;
using Warehouse.Core.Interfaces;
using Warehouse.Core.Exceptions;

namespace Warehouse.Tests
{
    public class CategoryServiceTests
    {
        private readonly Mock<IRepository<Category>> _mockCategoryRepo;
        private readonly CategoryService _service;

        public CategoryServiceTests()
        {
            _mockCategoryRepo = new Mock<IRepository<Category>>();

            _service = new CategoryService(_mockCategoryRepo.Object);
        }

        [Fact]
        public void AddCategory_WithValidName_ShouldCallRepositoryAdd()
        {
            string categoryName = "Laptops";

            _service.AddCategory(categoryName);

            _mockCategoryRepo.Verify(r => r.Add(It.Is<Category>(c => c.Name == categoryName)), Times.Once);
        }

        [Fact]
        public void AddCategory_WithEmptyName_ShouldThrowValidationException()
        {
            string emptyName = "";

            var ex = Assert.Throws<ValidationException>(() => _service.AddCategory(emptyName));

            Assert.Contains("Назва", ex.Message);
        }

        [Fact]
        public void GetAll_ShouldReturnAllCategories()
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Phones" },
                new Category { Id = 2, Name = "Food" }
            };

            _mockCategoryRepo.Setup(r => r.GetAll()).Returns(categories);

            var result = _service.GetAll().ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("Phones", result[0].Name);
            Assert.Equal("Food", result[1].Name);
        }

        [Fact]
        public void UpdateCategory_WithValidData_ShouldCallRepositoryUpdate()
        {
            var categoryToUpdate = new Category { Id = 1, Name = "Updated Name" };

            _service.UpdateCategory(categoryToUpdate);

            _mockCategoryRepo.Verify(r => r.Update(categoryToUpdate), Times.Once);
        }

        [Fact]
        public void UpdateCategory_WithEmptyName_ShouldThrowValidationException()
        {
            var invalidCategory = new Category { Id = 1, Name = "   " }; // Пробіли теж вважаються порожнім рядком

            Assert.Throws<ValidationException>(() => _service.UpdateCategory(invalidCategory));
        }

        [Fact]
        public void DeleteCategory_ShouldCallRepositoryDelete()
        {
            int categoryId = 5;

            _service.DeleteCategory(categoryId);

            _mockCategoryRepo.Verify(r => r.Delete(categoryId), Times.Once);
        }
    }
}