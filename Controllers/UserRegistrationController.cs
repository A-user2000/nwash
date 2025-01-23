using Microsoft.AspNetCore.Mvc;

namespace Wq_Surveillance.Controllers
{
    public class UserRegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
