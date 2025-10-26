using SecondPartSolution.PersonEntities.Entities;

namespace SecondPartSolution.DataAccess.DataProviders;

public class BinaryDataProvider<T> : IDataProvider<T> where T : class
{
    public void Serialize(IEnumerable<T> data, string filePath)
    {
        using var writer = new BinaryWriter(File.Open(filePath, FileMode.Create));
        var list = data.ToList();

        writer.Write(list.Count);
        foreach (var item in list)
        {
            if (item is Student student)
            {
                WriteStudent(writer, student);
            }
        }
    }

    public IEnumerable<T> Deserialize(string filePath)
    {
        if (!File.Exists(filePath))
            return Enumerable.Empty<T>();

        using var reader = new BinaryReader(File.Open(filePath, FileMode.Open));
        var count = reader.ReadInt32();
        var result = new List<T>();

        for (int i = 0; i < count; i++)
        {
            var student = ReadStudent(reader);
            if (student is T typedStudent)
            {
                result.Add(typedStudent);
            }
        }

        return result;
    }

    private void WriteStudent(BinaryWriter writer, Student student)
    {
        writer.Write(student.LastName ?? "");
        writer.Write(student.FirstName ?? "");
        writer.Write(student.Course);
        writer.Write(student.StudentId ?? "");
        writer.Write(student.City ?? "");
        writer.Write(student.PassportId ?? "");
    }

    private Student ReadStudent(BinaryReader reader)
    {
        return new Student
        {
            LastName = reader.ReadString(),
            FirstName = reader.ReadString(),
            Course = reader.ReadInt32(),
            StudentId = reader.ReadString(),
            City = reader.ReadString(),
            PassportId = reader.ReadString(),
        };
    }
}