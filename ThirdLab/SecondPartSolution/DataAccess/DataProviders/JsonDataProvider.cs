using System.Text.Json;

namespace SecondPartSolution.DataAccess.DataProviders;

public class JsonDataProvider<T> : IDataProvider<T>
{
    public void Serialize(IEnumerable<T> data, string filePath)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        string json = JsonSerializer.Serialize(data, options);
        File.WriteAllText(filePath, json);
    }

    public IEnumerable<T> Deserialize(string filePath)
    {
        if (!File.Exists(filePath))
            return Enumerable.Empty<T>();

        string json = File.ReadAllText(filePath);
        var result = JsonSerializer.Deserialize<List<T>>(json);
        return result ?? Enumerable.Empty<T>();
    }
}
