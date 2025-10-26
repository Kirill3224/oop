using System.Text.RegularExpressions;
using SecondPartSolution.PersonEntities.Entities;

namespace SecondPartSolution.StudentBusinessLogic.Validators;

public class StudentValidator
{
    public static bool ValidatePassportId(string passpId)
    {
        if (string.IsNullOrEmpty(passpId))
        {
            return false;
        }

        var regex = new Regex(@"^[A-Z]{2}\d{6}$");
        return regex.IsMatch(passpId);
    }

    public static bool ValidateStudentId(string studId)
    {
        {
            if (string.IsNullOrEmpty(studId))
            {
                return false;
            }

            var regex = new Regex(@"^[A-Z]{2}\d{6}$");
            return regex.IsMatch(studId);
        }
    }

    public static bool ValidateCourse(int course)
    {
        return course >= 1 && course <= 6;
    }

    public static bool ValidateCity(string city)
    {
        if (string.IsNullOrEmpty(city))
            return false;

        var regex = new Regex(@"^[A-Za-zА-Яа-яҐґЄєІіЇї\s\-]+$");
        return regex.IsMatch(city);
    }

    public static bool ValidateStudent(Student student)
    {
        return ValidateCity(student.City) && ValidateCourse(student.Course) && ValidateStudentId(student.StudentId) && ValidatePassportId(student.PassportId);
    }
}