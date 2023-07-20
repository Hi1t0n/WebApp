using System.ComponentModel.DataAnnotations;

namespace ProductService.Domain.Entities;

/// <summary>
/// Описание товара
/// </summary>
public class Product
{
    [Key]
    public long Id { get; set; }

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public decimal? Price { get; set; }

    public decimal Quantity { get; set;}
    
}