using Microsoft.AspNetCore.Mvc;

namespace MyAcademy_PortfolioProject.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutMobileSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
