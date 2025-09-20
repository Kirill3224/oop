using FirstLab.Core.Interfaces;
using FirstLab.Core.Entities;

namespace FirstLab.Core.Utilities.Calculators;

public static class StudentCalculator
{
    public static double CalculatePrecentage(IEnumerable<IPerson> allPersons)
    {
        var students = allPersons.OfType<Student>().ToList();

        if (students.Count == 0)
            return 0;

        int firstCourseOtherCity = 0;

        foreach (var s in students)
        {
            if (s.Course == 1 && !string.Equals(s.City, "Kyiv", StringComparison.OrdinalIgnoreCase))
            {
                firstCourseOtherCity++;
            }
        }

        return (double)firstCourseOtherCity / students.Count * 100;
    }
}

