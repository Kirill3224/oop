using System.Text.Json;
using Warehouse.Core.Entities;
using Warehouse.Core.Interfaces;

namespace Warehouse.Data.Repositories;

public class JsonRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly string _filePath;
    private List<T> _items;

    public JsonRepository(string fileName)
    {
        _filePath = fileName;
        _items = LoadData();
    }


    public IEnumerable<T> GetAll()
    {
        return _items;
    }

    public T GetById(int id)
    {
        return _items.FirstOrDefault(x => x.Id == id);
    }

    public void Add(T item)
    {
        item.Id = _items.Any() ? _items.Max(x => x.Id) + 1 : 1;

        _items.Add(item);
        SaveData();
    }

    public void Update(T item)
    {
        var index = _items.FindIndex(x => x.Id == item.Id);
        if (index != -1)
        {
            _items[index] = item;
            SaveData();
        }
    }

    public void Delete(int id)
    {
        var item = GetById(id);
        if (item != null)
        {
            _items.Remove(item);
            SaveData();
        }
    }

    private List<T> LoadData()
    {
        if (!File.Exists(_filePath))
        {
            return new List<T>();
        }

        try
        {
            var json = File.ReadAllText(_filePath);
            if (string.IsNullOrWhiteSpace(json)) return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
        catch
        {
            return new List<T>();
        }
    }

    private void SaveData()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(_items, options);
        File.WriteAllText(_filePath, json);
    }
}
