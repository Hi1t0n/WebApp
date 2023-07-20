using ProductService.Domain.Entities;

namespace ProductService.Domain.Interfaces;

public interface IProductManager
{

    List<Product> GetAllProducts();
    Product CreateProduct(Product product);

    Product GetById(long id);
    
    Product? UpdateById(Product product);
    Product? DeleteById(long id);

}