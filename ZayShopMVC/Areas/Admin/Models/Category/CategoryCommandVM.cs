using System;
using System.ComponentModel.DataAnnotations;

namespace ZayShopMVC.Areas.Admin.Models.Category;

public class CategoryCommandVM
{
    [Required(ErrorMessage = "Please enter category name")]
    public string Name { get; set; }
}
