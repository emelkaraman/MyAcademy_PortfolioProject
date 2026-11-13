
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Models;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly PortfolioContext _context;

        public DashboardController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var messageCounts = _context.Messages
                .GroupBy(message => message.IsRead)
                .Select(group => new { IsRead = group.Key, Count = group.Count() })
                .ToDictionary(group => group.IsRead, group => group.Count);
            int readMessages = messageCounts.GetValueOrDefault(true);
            int unreadMessages = messageCounts.GetValueOrDefault(false);

            var model = new DashboardViewModel
            {
                TotalProjects = _context.Projects.Count(),
                ActiveProjects = _context.Projects.Count(x => x.IsActive),
                TotalSkills = _context.Skills.Count(),
                TotalExperiences = _context.Experiences.Count(),
                TotalEducations = _context.Educations.Count(),

                TotalMessages = readMessages + unreadMessages,
                ReadMessages = readMessages,
                UnreadMessages = unreadMessages,

                RecentMessages = _context.Messages
                    .AsNoTracking()
                    .OrderByDescending(x => x.SendDate)
                    .ThenByDescending(x => x.MessageID)
                    .Take(5)
                    .ToList(),

                RecentProjects = _context.Projects
                    .AsNoTracking()
                    .Include(x => x.Category)
                    .OrderByDescending(x => x.ProjectID)
                    .Take(3)
                    .ToList(),

                ProjectsByCategory = _context.Projects
                    .AsNoTracking()
                    .GroupBy(x => x.Category.CategoryName)
                    .Select(x => new
                    {
                        CategoryName = x.Key,
                        Count = x.Count()
                    })
                    .ToDictionary(x => x.CategoryName, x => x.Count)
            };

            return View(model);
        }
    }
}
