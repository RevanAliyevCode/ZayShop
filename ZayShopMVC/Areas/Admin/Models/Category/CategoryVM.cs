using System;
using System.ComponentModel.DataAnnotations;
using E = ZayShopMVC.Data.Entities;

namespace ZayShopMVC.Areas.Admin.Models.Category;


public class CategoryVM
{
    public List<E.Category> Categories { get; set; }
}
