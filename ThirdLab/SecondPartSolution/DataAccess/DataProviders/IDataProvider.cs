

namespace SecondPartSolution.DataAccess.DataProviders;

public interface IDataProvider<T>
{
    void Serialize(IEnumerable<T> data, string filePath);
    IEnumerable<T> Deserialize(string filePath);
}