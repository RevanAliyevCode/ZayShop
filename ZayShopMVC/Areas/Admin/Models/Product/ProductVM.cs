using System;
using System.ComponentModel.DataAnnotations;
using E = ZayShopMVC.Data.Entities;

namespace ZayShopMVC.Areas.Admin.Models.Product;

public class ProductVM
{
    public List<E.Product> Products { get; set; }
}
