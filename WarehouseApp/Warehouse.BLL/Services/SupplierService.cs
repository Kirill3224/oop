using System.Collections.Generic;
using Warehouse.Core.Entities;
using Warehouse.Core.Interfaces;
using Warehouse.Core.Exceptions;

namespace Warehouse.BLL.Services;

public class SupplierService
{
    private readonly IRepository<Supplier> _repository;

    public SupplierService(IRepository<Supplier> repository)
    {
        _repository = repository;
    }

    public void AddSupplier(Supplier supplier)
    {
        if (string.IsNullOrWhiteSpace(supplier.FirstName) || string.IsNullOrWhiteSpace(supplier.LastName))
            throw new ValidationException("Ім'я та прізвище постачальника обов'язкові.");

        _repository.Add(supplier);
    }

    public IEnumerable<Supplier> GetAll(string sortOrder = null)
    {
        var suppliers = _repository.GetAll();

        return sortOrder?.ToLower() switch
        {
            "name" => suppliers.OrderBy(s => s.FirstName),
            "lastname" => suppliers.OrderBy(s => s.LastName),
            _ => suppliers
        };
    }

    public IEnumerable<Supplier> Search(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword)) return new List<Supplier>();

        return _repository.GetAll()
           .Where(s => s.FirstName.Contains(keyword, System.StringComparison.OrdinalIgnoreCase) ||
                       s.LastName.Contains(keyword, System.StringComparison.OrdinalIgnoreCase));
    }

    public Supplier GetById(int id) => _repository.GetById(id);

    public void UpdateSupplier(Supplier supplier)
    {
        if (string.IsNullOrWhiteSpace(supplier.FirstName)) throw new ValidationException("Ім'я обов'язкове");
        _repository.Update(supplier);
    }

    public void DeleteSupplier(int id) => _repository.Delete(id);
}
