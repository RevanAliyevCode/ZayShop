using System;
using System.ComponentModel.DataAnnotations;

namespace ZayShopMVC.Areas.Admin.Models.Slider;

public class SliderCommandVM
{
    [Required(ErrorMessage = "Please enter title")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Please enter subtitle")]
    public string Subtitle { get; set; }
    [Required(ErrorMessage = "Please enter description")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Please enter image url")]
    public string ImageUrl { get; set; }

    [Required(ErrorMessage = "Please enter sort order")]
    [Range(1, int.MaxValue, ErrorMessage = "Sort order must be greater than 0")]
    public int SortOrder { get; set; }
}
