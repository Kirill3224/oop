using SecondPartSolution.PersonEntities.Entities;
using SecondPartSolution.DataAccess.DataProviders;

namespace SecondPartSolution.DataAccess.Contexts;

public class StudentContext
{
    private readonly IDataProvider<Student> _dataProvider;

    public StudentContext(IDataProvider<Student> dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public void SaveStudents(IEnumerable<Student> students, string filePath)
    {
        _dataProvider.Serialize(students, filePath);
    }

    public IEnumerable<Student> LoadStudents(string filePath)
    {
        return _dataProvider.Deserialize(filePath);
    }
}