using Microsoft.AspNetCore.Mvc;

namespace LegendMotor.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
