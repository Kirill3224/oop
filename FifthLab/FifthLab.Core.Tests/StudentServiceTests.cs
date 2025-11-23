using Xunit;
using Moq;
using FifthLab.Core.Entities;
using FifthLab.Core.Interfaces;
using FifthLab.Core.Services;

namespace FirstLab.Core.Tests;

public class StudentServiceTests
{
    private readonly Mock<IRepository<Student>> _mockRepository;
    private readonly StudentService _studentService;

    public StudentServiceTests()
    {
        _mockRepository = new Mock<IRepository<Student>>();
        _studentService = new StudentService(_mockRepository.Object);
    }

    [Fact]
    public void CalculatePercentage_OneFirstYearFromOtherCity_ReturnsCorrectPercentage()
    {
        var fakeStudents = new List<Student>
            {
                new Student { Course = 1, ArrivalCity = "Львів" },
                new Student { Course = 2, ArrivalCity = "Одеса" },
                new Student { Course = 1, ArrivalCity = "Київ" }
            };
        _mockRepository.Setup(repo => repo.GetAll()).Returns(fakeStudents);

        double result = _studentService.CalculatePercentageOfFirstYearsFromOtherCities();
        Assert.Equal(33.33, result, precision: 2);
    }

    [Fact]
    public void CalculatePercentage_NoStudents_ReturnsZero()
    {
        var fakeStudents = new List<Student>();
        _mockRepository.Setup(repo => repo.GetAll()).Returns(fakeStudents);
        double result = _studentService.CalculatePercentageOfFirstYearsFromOtherCities();
        Assert.Equal(0, result);
    }

    [Fact]
    public void CanSettleInDormitory_StudentFromOtherCity_ReturnsTrue()
    {
        var student = new Student { ArrivalCity = "Одеса" };
        bool result = _studentService.CanSettleInDormitory(student);
        Assert.True(result, "Студент з іншого міста повинен могти поселитися.");
    }

    [Fact]
    public void CanSettleInDormitory_StudentFromLocalCity_ReturnsFalse()
    {
        var student = new Student { ArrivalCity = "Київ" };

        bool result = _studentService.CanSettleInDormitory(student);

        Assert.False(result, "Студент з Києва не повинен поселятися.");
    }
}