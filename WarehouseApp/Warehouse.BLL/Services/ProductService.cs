using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Core.Entities;
using Warehouse.Core.Interfaces;
using Warehouse.Core.Exceptions;

namespace Warehouse.BLL.Services;

public class ProductService
{
    private readonly IRepository<Product> _productRepo;
    private readonly IRepository<Category> _categoryRepo;

    public ProductService(IRepository<Product> productRepo, IRepository<Category> categoryRepo)
    {
        _productRepo = productRepo;
        _categoryRepo = categoryRepo;
    }

    public void AddProduct(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ValidationException("Назва товару обов'язкова.");

        if (product.Price < 0)
            throw new ValidationException("Ціна не може бути від'ємною.");

        if (product.Quantity < 0)
            throw new ValidationException("Кількість не може бути від'ємною.");

        var category = _categoryRepo.GetById(product.CategoryId);
        if (category == null)
            throw new ValidationException($"Категорії з ID {product.CategoryId} не існує.");

        _productRepo.Add(product);
    }

    public IEnumerable<Product> GetAll(string sortOrder = null)
    {
        var products = _productRepo.GetAll();

        return sortOrder?.ToLower() switch
        {
            "name" => products.OrderBy(p => p.Name),
            "brand" => products.OrderBy(p => p.Brand),
            "price" => products.OrderBy(p => p.Price),
            _ => products
        };
    }

    public IEnumerable<Product> Search(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword)) return new List<Product>();

        return _productRepo.GetAll()
            .Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        p.Brand.Contains(keyword, StringComparison.OrdinalIgnoreCase));
    }

    public Product GetById(int id)
    {
        return _productRepo.GetById(id);
    }

    public void UpdateProduct(Product product)
    {
        var existing = _productRepo.GetById(product.Id);
        if (existing == null) throw new ValidationException("Товар не знайдено.");

        if (string.IsNullOrWhiteSpace(product.Name)) throw new ValidationException("Назва не може бути порожньою");
        if (product.Price < 0) throw new ValidationException("Ціна не може бути менше 0");

        _productRepo.Update(product);
    }

    public void DeleteProduct(int id) => _productRepo.Delete(id);
}