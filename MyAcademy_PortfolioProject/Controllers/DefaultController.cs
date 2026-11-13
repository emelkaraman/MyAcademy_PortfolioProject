using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.RateLimiting;
using MyAcademy_PortfolioProject.Entities;
using MyAcademy_PortfolioProject.Models;

namespace MyAcademy_PortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly MyAcademy_PortfolioProject.Context.PortfolioContext _context;

        public DefaultController(MyAcademy_PortfolioProject.Context.PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await LoadHomeAsync(new Message()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [EnableRateLimiting("contact")]
        [RequestSizeLimit(32 * 1024)]
        public async Task<IActionResult> SendMessage(
            [Bind("NameSurname,Email,Subject,MessageDetail", Prefix = nameof(PortfolioHomeViewModel.ContactMessage))] Message message,
            [FromForm] string? website)
        {
            if (!string.IsNullOrWhiteSpace(website))
            {
                return RedirectToAction(nameof(Index), null, "contact");
            }

            if (!ModelState.IsValid)
            {
                return View(nameof(Index), await LoadHomeAsync(message));
            }

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            TempData["ContactSuccess"] = "Mesajınız başarıyla iletildi!";
            return RedirectToAction(nameof(Index), null, "contact");
        }

        [HttpGet]
        public async Task<IActionResult> DownloadCv([FromServices] IWebHostEnvironment environment)
        {
            var storedPath = await _context.Settings.AsNoTracking().OrderBy(x => x.SettingID)
                .Select(x => x.CvFilePath).FirstOrDefaultAsync();
            var path = "cv/emel-nur-karaman.pdf";
            if (storedPath is not null && storedPath.StartsWith("cv/", StringComparison.Ordinal) &&
                storedPath.EndsWith(".pdf", StringComparison.Ordinal) &&
                Guid.TryParseExact(storedPath[3..^4], "N", out _))
            {
                path = storedPath;
            }
            if (!environment.WebRootFileProvider.GetFileInfo(path).Exists)
            {
                return NotFound();
            }

            return File(path, "application/pdf", "Emel-Nur-Karaman-CV.pdf");
        }

        private async Task<PortfolioHomeViewModel> LoadHomeAsync(Message message)
        {
            return new PortfolioHomeViewModel
            {
                About = await _context.Abouts.AsNoTracking().OrderBy(x => x.AboutID).FirstOrDefaultAsync(),
                Contact = await _context.Contacts.AsNoTracking().OrderBy(x => x.ContactId).FirstOrDefaultAsync(),
                Settings = await _context.Settings.AsNoTracking().OrderBy(x => x.SettingID).FirstOrDefaultAsync(),
                Educations = await _context.Educations.AsNoTracking().Where(x => x.IsActive)
                    .OrderByDescending(x => x.Duration).ThenByDescending(x => x.EducationId).ToListAsync(),
                Experiences = await _context.Experiences.AsNoTracking().Where(x => x.IsActive)
                    .OrderByDescending(x => x.Duration).ThenByDescending(x => x.ExperienceID).ToListAsync(),
                Skills = await _context.Skills.AsNoTracking().OrderBy(x => x.SkillName).ToListAsync(),
                SocialLinks = await _context.SocialMedias.AsNoTracking().Where(x => x.IsActive)
                    .OrderBy(x => x.PlatformName).ToListAsync(),
                ContactMessage = message
            };
        }
    }
}
