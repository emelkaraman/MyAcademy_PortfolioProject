
using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly PortfolioContext _context;

        public SocialMediaController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SocialMediaList()
        {
            var values = _context.SocialMedias.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
                return View(socialMedia);

            _context.SocialMedias.Add(socialMedia);
            _context.SaveChanges();

            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);

            if (value == null)
                return NotFound();

            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
                return View(socialMedia);

            var existing = _context.SocialMedias.Find(socialMedia.SocialMediaID);

            if (existing == null)
                return NotFound();

            existing.PlatformName = socialMedia.PlatformName;
            existing.Url = socialMedia.Url;
            existing.Icon = socialMedia.Icon;
            existing.IsActive = socialMedia.IsActive;

            _context.SaveChanges();

            return RedirectToAction("SocialMediaList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);

            if (value == null)
                return NotFound();

            _context.SocialMedias.Remove(value);
            _context.SaveChanges();

            return RedirectToAction("SocialMediaList");
        }
    }
}
