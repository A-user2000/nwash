using Microsoft.AspNetCore.Mvc;

namespace Wq_Surveillance.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
