using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Controllers
{
    public  class BlobImageWriter
    {
        public  bool SaveImageFile(byte[] imageBytes, string imagePath)
        {
            try
            {
                FileStream fs = new FileStream(imagePath, FileMode.Create);
                fs.Write(imageBytes, 0, imageBytes.Length);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
