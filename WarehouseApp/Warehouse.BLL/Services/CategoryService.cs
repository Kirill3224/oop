using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Core.Entities;
using Warehouse.Core.Interfaces;
using Warehouse.Core.Exceptions;

namespace Warehouse.BLL.Services;

public class CategoryService
{
    private readonly IRepository<Category> _repository;

    public CategoryService(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public void AddCategory(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException("Назва категорії не може бути порожньою.");

        var category = new Category { Name = name };
        _repository.Add(category);
    }

    public IEnumerable<Category> GetAll()
    {
        return _repository.GetAll();
    }

    public Category GetById(int id) => _repository.GetById(id);

    public void UpdateCategory(Category category)
    {
        if (string.IsNullOrWhiteSpace(category.Name)) throw new ValidationException("Назва не може бути порожньою");
        _repository.Update(category);
    }

    public void DeleteCategory(int id)
    {
        _repository.Delete(id);
    }
}
