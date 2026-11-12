
using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeroSectionController : Controller
    {
        private readonly PortfolioContext _context;

        public HeroSectionController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult HeroSectionList()
        {
            var values = _context.HeroSections.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateHeroSection()
        {
            if (_context.HeroSections.Any())
                return RedirectToAction("HeroSectionList");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateHeroSection(HeroSection hero)
        {
            if (!ModelState.IsValid)
                return View(hero);

            if (_context.HeroSections.Any())
                return RedirectToAction("HeroSectionList");

            _context.HeroSections.Add(hero);
            _context.SaveChanges();

            return RedirectToAction("HeroSectionList");
        }

        [HttpGet]
        public IActionResult UpdateHeroSection(int id)
        {
            var hero = _context.HeroSections.Find(id);

            if (hero == null)
                return NotFound();

            return View(hero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateHeroSection(HeroSection hero)
        {
            if (!ModelState.IsValid)
                return View(hero);

            var existing = _context.HeroSections.Find(hero.HeroSectionId);

            if (existing == null)
                return NotFound();

            existing.Title = hero.Title;
            existing.Subtitle = hero.Subtitle;
            existing.Description = hero.Description;
            existing.ImageUrl = hero.ImageUrl;
            existing.IsActive = hero.IsActive;

            _context.SaveChanges();

            return RedirectToAction("HeroSectionList");
        }
    }
}
