using System;

namespace ZayShopMVC.Models.Home;

public class SliderVM
{
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int SortOrder { get; set; }
}
