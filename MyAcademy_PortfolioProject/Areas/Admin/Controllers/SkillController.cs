
using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SkillList()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
                return View(skill);

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var skill = _context.Skills.Find(id);

            if (skill == null)
                return NotFound();

            return View(skill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
                return View(skill);

            var existing = _context.Skills.Find(skill.SkillID);

            if (existing == null)
                return NotFound();

            existing.SkillName = skill.SkillName;
            existing.SkillLevel = skill.SkillLevel;

            _context.SaveChanges();

            return RedirectToAction("SkillList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSkill(int id)
        {
            var skill = _context.Skills.Find(id);

            if (skill == null)
                return NotFound();

            _context.Skills.Remove(skill);
            _context.SaveChanges();

            return RedirectToAction("SkillList");
        }
    }
}
