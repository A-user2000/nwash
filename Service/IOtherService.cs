using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wq_Surveillance.Models;

namespace Wq_Surveillance.Service.OtherService
{
    public interface IOtherService
    {
    
        public System.Data.DataTable GetTblVal(string dbPath, string tblname);
        public string ImgGetUUid(string tblname);
        public int ResizeImage2(string inputImagePath, string outputImagePath, int desiredWidth, int desiredHeight, long compressionLevel);
        public string GetImgPath(string imguuid);
        public int ResizeImgMain(string imgpath, string outputpath);
        //public int DeleteImg(string uuid, string tblname, string imgFolder);
        public int DownloadFile(IFormFile file, string path, string fileName);
    }
}
