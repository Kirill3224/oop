using Moq;
using Warehouse.BLL.Services;
using Warehouse.Core.Entities;
using Warehouse.Core.Interfaces;
using Warehouse.Core.Exceptions;

namespace Warehouse.Tests
{
    public class SupplierServiceTests
    {
        private readonly Mock<IRepository<Supplier>> _mockRepo;
        private readonly SupplierService _service;

        public SupplierServiceTests()
        {
            _mockRepo = new Mock<IRepository<Supplier>>();
            _service = new SupplierService(_mockRepo.Object);
        }

        [Fact]
        public void AddSupplier_ValidData_ShouldCallRepository()
        {
            var supplier = new Supplier { FirstName = "John", LastName = "Doe", Phone = "123" };

            _service.AddSupplier(supplier);

            _mockRepo.Verify(r => r.Add(supplier), Times.Once);
        }

        [Fact]
        public void AddSupplier_EmptyName_ShouldThrowValidationException()
        {
            var badSupplier = new Supplier { FirstName = "", LastName = "Doe" };

            Assert.Throws<ValidationException>(() => _service.AddSupplier(badSupplier));
        }

        [Fact]
        public void GetAll_SortedByLastName_ShouldReturnCorrectOrder()
        {
            var suppliers = new List<Supplier>
            {
                new Supplier { FirstName = "A", LastName = "Zeta" },
                new Supplier { FirstName = "B", LastName = "Alpha" },
                new Supplier { FirstName = "C", LastName = "Beta" }
            };
            _mockRepo.Setup(r => r.GetAll()).Returns(suppliers);

            var result = _service.GetAll("lastname").ToList();

            Assert.Equal("Alpha", result[0].LastName);
            Assert.Equal("Beta", result[1].LastName);
            Assert.Equal("Zeta", result[2].LastName);
        }

        [Fact]
        public void Search_ByKeyword_ShouldReturnMatchingSuppliers()
        {
            var suppliers = new List<Supplier>
            {
                new Supplier { FirstName = "Ivan", LastName = "Ivanov" },
                new Supplier { FirstName = "Petro", LastName = "Petrenko" },
                new Supplier { FirstName = "Ivan", LastName = "Sidorov" } // Ще один Іван
            };
            _mockRepo.Setup(r => r.GetAll()).Returns(suppliers);

            var result = _service.Search("Ivan").ToList();

            Assert.Equal(2, result.Count);
            Assert.True(result.All(s => s.FirstName == "Ivan" || s.LastName == "Ivan"));
        }

        [Fact]
        public void UpdateSupplier_ValidData_ShouldCallRepositoryUpdate()
        {
            var supplier = new Supplier { Id = 1, FirstName = "NewName", LastName = "NewLast" };

            _service.UpdateSupplier(supplier);

            _mockRepo.Verify(r => r.Update(supplier), Times.Once);
        }

        [Fact]
        public void DeleteSupplier_ShouldCallRepositoryDelete()
        {
            _service.DeleteSupplier(99);

            _mockRepo.Verify(r => r.Delete(99), Times.Once);
        }
    }
}