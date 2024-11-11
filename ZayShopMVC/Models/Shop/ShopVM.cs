using System;

namespace ZayShopMVC.Models.Shop;

public class ShopVM
{
    public List<CategoryVM> Categories { get; set; }
    public List<ProductVM> Products { get; set; }
}
