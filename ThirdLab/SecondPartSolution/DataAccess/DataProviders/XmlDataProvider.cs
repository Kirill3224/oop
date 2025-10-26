using System.Xml.Serialization;

namespace SecondPartSolution.DataAccess.DataProviders;

public class XmlDataProvider<T> : IDataProvider<T>
{
    public void Serialize(IEnumerable<T> data, string filePath)
    {
        var serializer = new XmlSerializer(typeof(List<T>));
        using var writer = new StreamWriter(filePath);
        serializer.Serialize(writer, data.ToList());
    }

    public IEnumerable<T> Deserialize(string filePath)  // Змінили тип повернення
    {
        if (!File.Exists(filePath))
            return Enumerable.Empty<T>();

        var serializer = new XmlSerializer(typeof(List<T>));
        using var reader = new StreamReader(filePath);
        var result = (List<T>?)serializer.Deserialize(reader);
        return result ?? Enumerable.Empty<T>();
    }
}