using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ZayShopMVC.Data;
using ZayShopMVC.Models.Home;

namespace ZayShopMVC.Controllers;

public class HomeController : Controller
{
    readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        HomeVM model = new HomeVM();

        List<SliderVM> sliders = _context.Sliders.OrderBy(s => s.SortOrder).Select(x => new SliderVM
        {
            Title = x.Title,
            Subtitle = x.Subtitle,
            Description = x.Description,
            ImageUrl = x.ImageUrl,
            SortOrder = x.SortOrder
        }).ToList();

        model.Sliders = sliders;

        return View(model);
    }
}
