using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZayShopMVC.Data.Entities;

[Table("sliders")]
public class Slider : BaseEntity
{
    [Column("title")]
    public string Title { get; set; }
    [Column("subtitle")]
    public string Subtitle { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("image_url")]
    public string ImageUrl { get; set; }
    [Column("sort_order")]
    public int SortOrder { get; set; }
}
