using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.WaterQuality
{
    public class WaterQualityUploadModel
    {
        public string UserEmail { get; set; }
        public IFormFile SwmzFile { get; set; }
    }
}
