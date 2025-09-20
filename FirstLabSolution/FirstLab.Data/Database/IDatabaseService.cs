using FirstLab.Core.Interfaces;

namespace FirstLab.Data.Database;

public interface IDatabaseService
{
    void InsertPerson(IPerson person);
    List<IPerson> GetAllPersons();
    void Clear();
    IPerson FindByLastName(string lastName);
    IPerson FindByObjectName(string objectName);
}