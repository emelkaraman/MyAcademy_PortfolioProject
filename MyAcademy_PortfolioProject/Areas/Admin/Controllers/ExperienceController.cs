using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;

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
    }
}
