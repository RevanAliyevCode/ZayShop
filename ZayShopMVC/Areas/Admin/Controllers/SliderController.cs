using Microsoft.AspNetCore.Mvc;
using ZayShopMVC.Areas.Admin.Models.Slider;
using ZayShopMVC.Data;
using ZayShopMVC.Data.Entities;

namespace ZayShopMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var model = new SliderVM
            {
                Sliders = _context.Sliders.ToList()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SliderCommandVM model)
        {
            if (!ModelState.IsValid)
                return View();

            if (_context.Sliders.Any(s => s.SortOrder == model.SortOrder))
            {
                ModelState.AddModelError("SortOrder", "Order already exists");
                return View();
            }

            var slider = new Slider
            {
                Title = model.Title,
                Subtitle = model.Subtitle,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                SortOrder = model.SortOrder
            };

            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var slider = _context.Sliders.Find(id);

            if (slider == null)
                return NotFound();

            var model = new SliderCommandVM
            {
                Title = slider.Title,
                Subtitle = slider.Subtitle,
                Description = slider.Description,
                ImageUrl = slider.ImageUrl,
                SortOrder = slider.SortOrder
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(int id, SliderCommandVM model)
        {
            if (!ModelState.IsValid)
                return View();

            var slider = _context.Sliders.Find(id);

            if (slider == null)
                return NotFound();

            if (_context.Sliders.Any(s => s.SortOrder == model.SortOrder && s.Id != id))
            {
                ModelState.AddModelError("SortOrder", "Order already exists");
                return View();
            }

            slider.Title = model.Title;
            slider.Subtitle = model.Subtitle;
            slider.Description = model.Description;
            slider.ImageUrl = model.ImageUrl;
            slider.SortOrder = model.SortOrder;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var slider = _context.Sliders.Find(id);

            if (slider == null)
                return NotFound();

            _context.Sliders.Remove(slider);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
