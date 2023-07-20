using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProductService.Infrastructure.Context;

namespace ProductService.Infrastructure.Managers;



//TODO: Сделать реализацию в ProductManager

public sealed class ProductManager : IProductManager
{
    private readonly ProductContext _productContext;

    public ProductManager(ProductContext context)
    {
        _productContext = context;
    }


    public List<Product> GetAllProducts()
    {
        return _productContext.Products.ToList();
    }

    public Product CreateProduct(Product product)
    {
        var productData = _productContext.Add(product);
        _productContext.SaveChanges();
        return productData.Entity;
    }
    
    public Product? GetById(long id)
    {
        return _productContext.Products.FirstOrDefault(x => x.Id == id);
    }
    
    public Product? UpdateById(Product product)
    {
        var existingProduct = _productContext.Products.FirstOrDefault(x=>x.Id == product.Id);

        if (existingProduct is null) { return null; }

        existingProduct.Price = product.Price;
        existingProduct.Title = product.Title;
        existingProduct.Quantity = product.Quantity;
        existingProduct.Description = product.Description;

        var productData = _productContext.Update(product);
        _productContext.SaveChanges();

        return productData.Entity;
    }

    
    public Product? DeleteById(long id)
    {
        var existingProduct = _productContext.Products.FirstOrDefault(x=>x.Id==id);
        if (existingProduct is null) { return null; }

        var productData = _productContext.Remove(existingProduct);
        _productContext.SaveChanges();
        return productData.Entity;

    }

}