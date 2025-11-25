using System.Collections.Generic;
using Warehouse.Core.Entities;

namespace Warehouse.Core.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll();

    T GetById(int id);

    void Add(T item);

    void Update(T item);

    void Delete(int id);
}
