using SecondPartSolution.DataAccess.Contexts;
using SecondPartSolution.DataAccess.DataProviders;
using SecondPartSolution.PersonEntities.Entities;
using SecondPartSolution.StudentBusinessLogic.Validators;
using SecondPartSolution.StudentBusinessLogic.DataInitializer;
using SecondPartSolution.PersonEntites.Enums;

namespace SecondPartSolution.StudentBusinessLogic.Services;

public class StudentService
{
    private List<Student> _students;
    private readonly StudentContext _context;

    public StudentService()
    {
        _students = StudentDataInitializer.InitializeStudents().ToList();
        IDataProvider<Student> dataProvider = new JsonDataProvider<Student>();
        _context = new StudentContext(dataProvider);
    }

    public bool AddStudent(Student student)
    {
        if (!StudentValidator.ValidateStudent(student))
            return false;

        if (_students.Any(s => s.StudentId == student.StudentId))
            return false;

        _students.Add(student);
        return true;
    }

    public bool RemoveStudent(string studentId)
    {
        var student = _students.FirstOrDefault(s => s.StudentId == studentId);
        if (student == null)
            return false;

        _students.Remove(student);
        return true;
    }

    public Student FindStudent(string studentId)
    {
        var student = _students.FirstOrDefault(s => s.StudentId == studentId);
        if (student == null)
        {
            return null;
        }
        return student;
    }

    public List<Student> GetAllStudents()
    {
        return _students.ToList();
    }

    public (double percentage, List<Student> students) GetFirstCourseFromOtherCitiesStats()
    {
        var firstCourseStudents = _students.Where(s => s.Course == 1).ToList();
        var fromOtherCities = firstCourseStudents
            .Where(s => !string.IsNullOrEmpty(s.City) &&
                       !s.City.Equals("Київ", StringComparison.OrdinalIgnoreCase))
            .ToList();

        double percentage = firstCourseStudents.Count > 0
            ? (double)fromOtherCities.Count / firstCourseStudents.Count * 100
            : 0;

        return (percentage, fromOtherCities);
    }

    public void SaveStudents(string filePath, SerializationType type)
    {
        var dataProvider = CreateDataProvider(type);
        var context = new StudentContext(dataProvider);
        context.SaveStudents(_students, filePath);
    }

    public void LoadStudents(string filePath, SerializationType type)
    {
        var dataProvider = CreateDataProvider(type);
        var context = new StudentContext(dataProvider);
        _students = context.LoadStudents(filePath).ToList();
    }

    private IDataProvider<Student> CreateDataProvider(SerializationType type)
    {
        return type switch
        {
            SerializationType.Json => new JsonDataProvider<Student>(),
            SerializationType.Xml => new XmlDataProvider<Student>(),
            SerializationType.Binary => new BinaryDataProvider<Student>(),
            SerializationType.Custom => new CustomDataProvider<Student>(),
            _ => new JsonDataProvider<Student>()
        };
    }
}