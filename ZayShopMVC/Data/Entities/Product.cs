using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayShopMVC.Data.Entities;

[Table("products")]
public class Product : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("price")]
    public decimal Price { get; set; }
    [Column("image_url")]
    public string ImageUrl { get; set; }
    [Column("rating")]
    public int Rating { get; set; }
    [Column("stock")]
    public int Stock { get; set; }
    [Column("category_id")]
    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public ICollection<Size> Sizes { get; set; }
}

[Table("sizes")]
public class Size : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}