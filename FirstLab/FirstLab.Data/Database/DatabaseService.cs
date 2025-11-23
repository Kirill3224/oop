using MySql.Data.MySqlClient;
using FirstLab.Core.Interfaces;
using FirstLab.Core.Entities;
using FirstLab.Data.FileServices;

namespace FirstLab.Data.Database;

public class FileDatabaseService : IDatabaseService
{
    private readonly TextFileService _textFileService;
    private List<IPerson> _persons;

    public FileDatabaseService(TextFileService textFileService)
    {
        _textFileService = textFileService;
        _persons = _textFileService.ReadAllPersons().ToList();
    }

    public void InsertPerson(IPerson person)
    {
        _persons.Add(person);
        _textFileService.WriteAllPersons(_persons);
    }

    public List<IPerson> GetAllPersons()
    {
        return _persons;
    }

    public void Clear()
    {
        _persons.Clear();
        _textFileService.WriteAllPersons(_persons);
    }

    public IPerson FindByLastName(string lastName)
    {
        foreach (var person in _persons)
        {
            if (string.Equals(person.LastName, lastName, StringComparison.OrdinalIgnoreCase))
            {
                return person;
            }
        }

        return null;
    }

    public IPerson FindByObjectName(string objectName)
    {
        foreach (var person in _persons)
        {
            if (string.Equals(person.ObjectName, objectName, StringComparison.OrdinalIgnoreCase))
            {
                return person;
            }
        }

        return null;
    }
}