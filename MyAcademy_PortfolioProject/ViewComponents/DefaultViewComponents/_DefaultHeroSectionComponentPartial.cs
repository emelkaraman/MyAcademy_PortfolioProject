using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;

namespace MyAcademy_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultHeroSectionComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _context;
        public _DefaultHeroSectionComponentPartial(PortfolioContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(MyAcademy_PortfolioProject.Models.PortfolioHomeViewModel home)
        {
            var values = _context.HeroSections.Where(x => x.IsActive).OrderBy(x => x.HeroSectionId).FirstOrDefault();
            ViewBag.title = values?.Title;
            ViewBag.subtitle = values?.Subtitle;
            ViewBag.description = values?.Description;
            ViewBag.image = values?.ImageUrl;
            return View(home);
        }
    }
}
