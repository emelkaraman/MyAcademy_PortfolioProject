
using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingController : Controller
    {
        private readonly PortfolioContext _context;
        private readonly IWebHostEnvironment _environment;

        public SettingController(PortfolioContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var setting = _context.Settings.FirstOrDefault();

            if (setting == null)
            {
                setting = new Setting();
            }

            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(11 * 1024 * 1024)]
        public async Task<IActionResult> Index(
            [Bind(nameof(Setting.SiteTitle), nameof(Setting.SiteDescription))] Setting model, IFormFile? cvFile)
        {
            if (cvFile != null)
            {
                if (cvFile.Length < 5 || cvFile.Length > 10 * 1024 * 1024 ||
                    !string.Equals(Path.GetExtension(cvFile.FileName), ".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("cvFile", "En fazla 10 MB boyutunda bir PDF seçin.");
                }
                else
                {
                    using var input = cvFile.OpenReadStream();
                    var signature = new byte[5];
                    await input.ReadExactlyAsync(signature);
                    if (!signature.AsSpan().SequenceEqual("%PDF-"u8))
                    {
                        ModelState.AddModelError("cvFile", "Dosya geçerli bir PDF başlığı içermiyor.");
                    }
                }
            }

            if (!ModelState.IsValid)
                return View(model);

            var setting = _context.Settings.OrderBy(x => x.SettingID).FirstOrDefault();

            if (setting == null)
            {
                setting = new Setting();
                _context.Settings.Add(setting);
            }

            setting.SiteTitle = model.SiteTitle;
            setting.SiteDescription = model.SiteDescription;

            string? uploadedPath = null;
            try
            {
                if (cvFile != null)
                {
                    var directory = Path.Combine(_environment.WebRootPath, "cv");
                    Directory.CreateDirectory(directory);
                    var fileName = $"{Guid.NewGuid():N}.pdf";
                    uploadedPath = Path.Combine(directory, fileName);
                    await using (var output = System.IO.File.Create(uploadedPath))
                    {
                        await cvFile.CopyToAsync(output);
                    }
                    setting.CvFilePath = $"cv/{fileName}";
                }

                await _context.SaveChangesAsync();
            }
            catch
            {
                if (uploadedPath != null)
                {
                    System.IO.File.Delete(uploadedPath);
                }
                throw;
            }

            TempData["Success"] = "Ayarlar başarıyla kaydedildi.";

            return RedirectToAction(nameof(Index));
        }
    }
}
