using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;


namespace ProductService.Infrastructure.Context;

public sealed class ProductContext : DbContext
{
    public DbSet<Product>  Products => Set<Product>();

    public ProductContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }
}