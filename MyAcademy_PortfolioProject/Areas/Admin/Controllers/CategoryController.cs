
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly PortfolioContext _context;

        public CategoryController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Category category)
        {
            ModelState.Remove(nameof(Category.Projects));

            if (!ModelState.IsValid)
                return View(category);

            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCategory(Category category)
        {
            ModelState.Remove(nameof(Category.Projects));

            if (!ModelState.IsValid)
                return View(category);

            var existing = _context.Categories.Find(category.CategoryID);

            if (existing == null)
                return NotFound();

            existing.CategoryName = category.CategoryName;
            _context.SaveChanges();

            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories
                .Include(x => x.Projects)
                .FirstOrDefault(x => x.CategoryID == id);

            if (category == null)
                return NotFound();

            if (category.Projects.Any())
            {
                TempData["Error"] =
                    "Bu kategoriye bağlı projeler olduğu için silinemez.";

                return RedirectToAction("CategoryList");
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("CategoryList");
        }
    }
}
