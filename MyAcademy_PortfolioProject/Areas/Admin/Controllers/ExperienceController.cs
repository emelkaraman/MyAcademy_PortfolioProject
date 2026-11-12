using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly PortfolioContext _context;

        public ExperienceController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ExperienceList()
        {
            var values=_context.Experiences.ToList();
            return View(values);

        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateExperience(Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return View(experience);
            }

            _context.Experiences.Add(experience);
            _context.SaveChanges();

            return RedirectToAction("ExperienceList");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteExperience(int id)
        {
            var experience = _context.Experiences.Find(id);

            if (experience == null)
            {
                return NotFound();
            }

            _context.Experiences.Remove(experience);
            _context.SaveChanges();

            return RedirectToAction("ExperienceList");
        }

        public IActionResult UpdateExperience(int id)
        {
            var value = _context.Experiences.Find(id);
            if(value == null)
            {
                return NotFound();
            }
            return View(value);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateExperience(Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return View(experience);
            }

            _context.Experiences.Update(experience);
            _context.SaveChanges();

            return RedirectToAction("ExperienceList");
        }
    }
}
