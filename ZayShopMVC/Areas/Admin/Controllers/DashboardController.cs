using Microsoft.AspNetCore.Mvc;
using ZayShopMVC.Areas.Admin.Models.Category;
using ZayShopMVC.Data;
using ZayShopMVC.Data.Entities;

namespace ZayShopMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = new CategoryVM
            {
                Categories = _context.Categories.ToList()
            };


            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCommandVM model)
        {
            if (!ModelState.IsValid)
                return View();

            if (_context.Categories.Any(c => c.Name.ToLower() == model.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Category already exists");
                return View();
            }

            var category = new Category
            {
                Name = model.Name
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
                return NotFound();

            var model = new CategoryCommandVM
            {
                Name = category.Name
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, CategoryCommandVM model)
        {
            if (!ModelState.IsValid)
                return View();

            var category = _context.Categories.Find(id);

            if (category == null)
                return NotFound();

            if (_context.Categories.Any(c => c.Name.ToLower() == model.Name.ToLower() && c.Id != id))
            {
                ModelState.AddModelError("Name", "Category already exists");
                return View();
            }

            category.Name = model.Name;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
