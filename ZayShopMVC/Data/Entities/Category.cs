using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayShopMVC.Data.Entities;

[Table("categories")]
public class Category : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}
