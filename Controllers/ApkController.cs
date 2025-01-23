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
        public IActionResult DownloadAPK(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return NotFound("File name is required.");
            }

            // Construct the file path
            var filePath = Path.Combine(_env.WebRootPath, "apks", "wqs.apk");

            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            // Determine the MIME type for the APK file
            var mimeType = "application/vnd.android.package-archive";

            // Return the file for download
            var fileStream = System.IO.File.OpenRead(filePath);
            return File(fileStream, mimeType, fileName);
        }
    }
}

