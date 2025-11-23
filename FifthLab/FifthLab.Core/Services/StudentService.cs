using FifthLab.Core.Entities;
using FifthLab.Core.Interfaces;

namespace FifthLab.Core.Services;

public class StudentService
{
    private readonly IRepository<Student> _repository;
    private const string LOCAL_CITY = "Київ";

    public StudentService(IRepository<Student> repository)
    {
        _repository = repository;
    }

    public double CalculatePercentageOfFirstYearsFromOtherCities()
    {
        var allStudents = _repository.GetAll();
        if (!allStudents.Any()) return 0;

        var firstYearsFromOtherCities = allStudents
            .Where(s => s.Course == 1 && s.ArrivalCity != LOCAL_CITY)
            .Count();

        return (double)firstYearsFromOtherCities / allStudents.Count() * 100.0;
    }

    public bool CanSettleInDormitory(Student student)
    {
        return student.ArrivalCity != LOCAL_CITY;
    }

    public IEnumerable<Student> GetAllStudents() => _repository.GetAll();
    public void AddStudent(Student student) { /*...тут валідація і збереження...*/ }
}