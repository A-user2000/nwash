using Microsoft.AspNetCore.Mvc;

namespace Wq_Surveillance.Controllers
{
    public class WqsChartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
