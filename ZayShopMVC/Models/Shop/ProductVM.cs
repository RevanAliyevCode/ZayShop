using System;

namespace ZayShopMVC.Models.Shop;

public class ProductVM
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int Rating { get; set; }
    public List<string> Sizes { get; set; }
}
