
using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly PortfolioContext _context;

        public AboutController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult AboutList()
        {
            var values = _context.Abouts.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAbout(About about)
        {
            if (!ModelState.IsValid)
                return View(about);

            if (_context.Abouts.Any())
            {
                TempData["Error"] = "Hakkımda bilgisi zaten mevcut.";
                return RedirectToAction("AboutList");
            }

            _context.Abouts.Add(about);
            _context.SaveChanges();

            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var about = _context.Abouts.Find(id);

            if (about == null)
                return NotFound();

            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAbout(About about)
        {
            if (!ModelState.IsValid)
                return View(about);

            var existing = _context.Abouts.Find(about.AboutID);

            if (existing == null)
                return NotFound();

            existing.NameSurname = about.NameSurname;
            existing.JobTitle = about.JobTitle;
            existing.Location = about.Location;
            existing.Expert = about.Expert;
            existing.Email = about.Email;
            existing.Description = about.Description;
            existing.OpenToWork = about.OpenToWork;

            _context.SaveChanges();

            return RedirectToAction("AboutList");
        }
    }
}
