using SecondPartSolution.PersonEntities.Entities;

namespace SecondPartSolution.DataAccess.DataProviders;

public class CustomDataProvider<T> : IDataProvider<T> where T : class
{
    public void Serialize(IEnumerable<T> data, string filePath)
    {
        using var writer = new StreamWriter(filePath);
        foreach (var item in data)
        {
            if (item is Student student)
            {
                writer.WriteLine(
                    $"{student.LastName}|{student.FirstName}|{student.Course}|" +
                    $"{student.StudentId}|{student.City}|" +
                    $"{student.PassportId}"
                );
            }
        }
    }

    public IEnumerable<T> Deserialize(string filePath)
    {
        if (!File.Exists(filePath))
            return Enumerable.Empty<T>();

        var lines = File.ReadAllLines(filePath);
        var result = new List<T>();

        foreach (var line in lines)
        {
            var parts = line.Split('|');
            if (parts.Length == 7)
            {
                var student = new Student
                {
                    LastName = parts[0],
                    FirstName = parts[1],
                    Course = int.Parse(parts[2]),
                    StudentId = parts[3],
                    City = parts[4],
                    PassportId = parts[5],
                };

                if (student is T typedStudent)
                {
                    result.Add(typedStudent);
                }
            }
        }

        return result;
    }
}