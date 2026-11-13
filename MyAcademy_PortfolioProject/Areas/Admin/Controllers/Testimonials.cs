
using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly PortfolioContext _context;

        public TestimonialController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult TestimonialList()
        {
            var values = _context.Testimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            if (!ModelState.IsValid)
                return View(testimonial);

            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();

            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);

            if (value == null)
                return NotFound();

            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            if (!ModelState.IsValid)
                return View(testimonial);

            var existing = _context.Testimonials.Find(testimonial.TestimonialID);

            if (existing == null)
                return NotFound();

            existing.NameSurname = testimonial.NameSurname;
            existing.JobTitle = testimonial.JobTitle;
            existing.Comment = testimonial.Comment;
            existing.ImageUrl = testimonial.ImageUrl;
            existing.IsActive = testimonial.IsActive;

            _context.SaveChanges();

            return RedirectToAction("TestimonialList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);

            if (value == null)
                return NotFound();

            _context.Testimonials.Remove(value);
            _context.SaveChanges();

            return RedirectToAction("TestimonialList");
        }
    }
}
