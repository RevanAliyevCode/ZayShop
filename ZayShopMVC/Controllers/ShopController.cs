using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZayShopMVC.Data;
using ZayShopMVC.Models.Shop;

namespace ZayShopMVC.Controllers
{
    public class ShopController : Controller
    {
        readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ShopVM model = new ShopVM();

            List<CategoryVM> categories = _context.Categories.Select(x => new CategoryVM
            {
                Name = x.Name
            }).ToList();

            model.Categories = categories;

            List<ProductVM> products = _context.Products.Include(p => p.Sizes).Select(x => new ProductVM
            {
                Name = x.Name,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                Rating = x.Rating,
                Sizes = x.Sizes.Select(s => s.Name).ToList()
            }).ToList();

            model.Products = products;

            return View(model);
        }

    }
}
