using FifthLab.Core.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace FifthLab.Data;

public class JsonRepository<T> : IRepository<T> where T : class
{
    private readonly string _filePath;

    public JsonRepository(string filePath)
    {
        _filePath = filePath;
    }

    public IEnumerable<T> GetAll()
    {
        if (!File.Exists(_filePath))
        {
            return Enumerable.Empty<T>();
        }
        string json = File.ReadAllText(_filePath);

        if (string.IsNullOrWhiteSpace(json))
        {
            return Enumerable.Empty<T>();
        }

        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }

    public void SaveAll(IEnumerable<T> entities)
    {
        string json = JsonSerializer.Serialize(entities, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}
