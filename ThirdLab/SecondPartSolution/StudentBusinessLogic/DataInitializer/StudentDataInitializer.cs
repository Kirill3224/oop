using SecondPartSolution.PersonEntities.Entities;

namespace SecondPartSolution.StudentBusinessLogic.DataInitializer;

public static class StudentDataInitializer
{
    public static IList<Student> InitializeStudents()
    {
        return new List<Student>
        {
        new Student
            {
                LastName = "Іваненко",
                FirstName = "Петро",
                Course = 1,
                StudentId = "KB123456",
                City = "Львів",
                PassportId = "AA123456",
            },
            new Student
            {
                LastName = "Петренко",
                FirstName = "Марія",
                Course = 1,
                StudentId = "KB209456",
                City = "Київ",
                PassportId = "BB978456",
            },
            new Student
            {
                LastName = "Сидоренко",
                FirstName = "Олексій",
                Course = 2,
                StudentId = "KB323345",
                City = "Одеса",
                PassportId = "CC980802",
            },
            new Student
            {
                LastName = "Коваленко",
                FirstName = "Анна",
                Course = 1,
                StudentId = "KB488456",
                City = "Харків",
                PassportId = "DD980342",
            }
        };
    }
}