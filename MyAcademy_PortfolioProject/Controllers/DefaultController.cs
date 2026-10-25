using Microsoft.AspNetCore.Mvc;

namespace MyAcademy_PortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
