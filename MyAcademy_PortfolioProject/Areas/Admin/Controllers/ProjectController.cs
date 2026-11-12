
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly PortfolioContext _context;

        public ProjectController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ProjectList()
        {
            var values = _context.Projects
                .Include(x => x.Category)
                .ToList();

            return View(values);
        }

        private void LoadCategories()
        {
            ViewBag.Categories = new SelectList(
                _context.Categories.ToList(),
                "CategoryID",
                "CategoryName"
            );
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProject(Project project)
        {
            ModelState.Remove(nameof(Project.Category));

            if (!_context.Categories.Any(x => x.CategoryID == project.CategoryID))
            {
                ModelState.AddModelError("CategoryID", "Geçerli bir kategori seçiniz.");
            }

            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(project);
            }

            _context.Projects.Add(project);
            _context.SaveChanges();

            return RedirectToAction("ProjectList");
        }

        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            var project = _context.Projects.Find(id);

            if (project == null)
                return NotFound();

            LoadCategories();
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProject(Project project)
        {
            ModelState.Remove(nameof(Project.Category));

            if (!_context.Categories.Any(x => x.CategoryID == project.CategoryID))
            {
                ModelState.AddModelError("CategoryID", "Geçerli bir kategori seçiniz.");
            }

            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(project);
            }

            var existing = _context.Projects.Find(project.ProjectID);

            if (existing == null)
                return NotFound();

            existing.Title = project.Title;
            existing.Description = project.Description;
            existing.GithubUrl = project.GithubUrl;
            existing.CoverImgUrl = project.CoverImgUrl;
            existing.CategoryID = project.CategoryID;
            existing.IsActive = project.IsActive;

            _context.SaveChanges();

            return RedirectToAction("ProjectList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);

            if (project == null)
                return NotFound();

            _context.Projects.Remove(project);
            _context.SaveChanges();

            return RedirectToAction("ProjectList");
        }
    }
}
