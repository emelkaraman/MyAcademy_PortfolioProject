using Microsoft.AspNetCore.Mvc;

namespace MyAcademy_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke(MyAcademy_PortfolioProject.Entities.Setting? settings)
        {
            return View(settings);
        }
    }
}
