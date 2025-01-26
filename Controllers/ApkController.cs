using Microsoft.AspNetCore.Mvc;

namespace Wq_Surveillance.Controllers
{
    public class ApkController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public ApkController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DownloadApk()
        {
            // Path to the APK file in the wwwroot/apks folder
            var filePath = Path.Combine(_env.WebRootPath, "apks", "wqs.apk");

            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            // Serve the file for download
            var fileStream = System.IO.File.OpenRead(filePath);
            return File(fileStream, "application/vnd.android.package-archive", "wqs.apk");
        }
    }
}

