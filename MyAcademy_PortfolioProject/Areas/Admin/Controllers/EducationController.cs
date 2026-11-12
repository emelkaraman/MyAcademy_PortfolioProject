using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller
    {
        private readonly PortfolioContext _context;
        public EducationController(PortfolioContext context)
        {
            _context = context;
        }
        public IActionResult EducationList()
        {
            var values = _context.Educations.ToList();
            if(values.Count == 0)
            {
                ViewBag.Message = "No education records found.";
            }
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View(education);
            }

            _context.Educations.Add(education);
            _context.SaveChanges();

            return RedirectToAction("EducationList");
        }


        [HttpGet]
        public IActionResult UpdateEducation(int id)
        {
            var education = _context.Educations.Find(id);

            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View(education);
            }

            var existingEducation = _context.Educations.Find(education.EducationId);

            if (existingEducation == null)
            {
                return NotFound();
            }

            existingEducation.Title = education.Title;
            existingEducation.SubTitle = education.SubTitle;
            existingEducation.Description = education.Description;
            existingEducation.Duration = education.Duration;
            existingEducation.IsActive = education.IsActive;

            _context.SaveChanges();

            return RedirectToAction("EducationList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEducation(int id)
        {
            var education = _context.Educations.Find(id);

            if (education == null)
            {
                return NotFound();
            }

            _context.Educations.Remove(education);
            _context.SaveChanges();

            return RedirectToAction("EducationList");
        }

    }
}
