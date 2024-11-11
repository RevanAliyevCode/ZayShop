using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayShopMVC.Data.Entities;

public class BaseEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("created_date")]
    public DateTime CreatedDate { get; set; }
    [Column("updated_date")]
    public DateTime? UpdatedDate { get; set; }
}
