using System;
using E = ZayShopMVC.Data.Entities;

namespace ZayShopMVC.Areas.Admin.Models.Slider;

public class SliderVM
{
    public List<E.Slider> Sliders { get; set; }
}
