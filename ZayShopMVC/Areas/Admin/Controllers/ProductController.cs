using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZayShopMVC.Areas.Admin.Models;
using ZayShopMVC.Areas.Admin.Models.Product;
using ZayShopMVC.Data;
using ZayShopMVC.Data.Entities;

namespace ZayShopMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Product> products = _context.Products.Include(p => p.Category).Include(p => p.Sizes).ToList();

            ProductVM model = new ProductVM
            {
                Products = products
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ProductCreateVM model = new ProductCreateVM();

            model.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();

            model.Sizes = _context.Sizes.Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateVM model)
        {
            if (!ModelState.IsValid)
                return View();

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Stock = model.Stock,
                CategoryId = model.CategoryId,
                Sizes = new List<Size>()
            };

            List<Size> sizes = _context.Sizes.Where(s => model.SizeIds.Contains(s.Id)).ToList();


            product.Sizes = sizes;

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Product? product = _context.Products.Include(p => p.Sizes).FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            ProductUpdateVM model = new ProductUpdateVM
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                SizeIds = product.Sizes.Select(s => s.Id).ToList(),
                Categories = _context.Categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList(),
                Sizes = _context.Sizes.Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, ProductUpdateVM model)
        {
            if (!ModelState.IsValid)
                return View();

            Product? product = _context.Products.Include(p => p.Sizes).FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product.Stock = model.Stock;
            product.CategoryId = model.CategoryId;

            List<Size> sizes = _context.Sizes.Where(s => model.SizeIds.Contains(s.Id)).ToList();

            product.Sizes = sizes;

            // _context.Products.Update(product);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Product? product = _context.Products.Find(id);

            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

