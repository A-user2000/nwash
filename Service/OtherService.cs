using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Wq_Surveillance.Controllers;
using Wq_Surveillance.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wq_Surveillance.Service.OtherService;

namespace wq.Service.OtherService
{
    public class OtherService : IOtherService
    {
        private static IWebHostEnvironment _hostEnvironment;
        private readonly WqsContext _wqsContext;
        private readonly IOtherService _otherservice;
        public OtherService(WqsContext nwash_dnContext,/*IOtherService ot,*/ IWebHostEnvironment hostEnvironment)
        {
            _wqsContext = nwash_dnContext;
            //_otherservice=ot;
            _hostEnvironment = hostEnvironment;
        }

       
       
        public System.Data.DataTable GetTblVal(string dbPath, string tblname)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string cs = $"Data Source={dbPath};";
            using (SQLiteConnection connection = new SQLiteConnection(cs))
            {
                connection.Open();
                try
                {
                    string sql = $"SELECT * FROM {tblname};";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return dt;
            }
        }
        public int ResizeImgMain(string imgpath, string outputpath)
        {
            int width = 0; int height = 0;
            try
            {
                var status = 0;
                using (var image = Image.FromFile(imgpath))
                {
                    width = image.Width;
                    height = image.Height;
                }

                int desiredWidth;
                int desiredHeight;
                if (width > height)
                {
                    desiredWidth = 800; // Adjust this value as needed
                    desiredHeight = 0;
                }
                else if (width < height)
                {
                    desiredWidth = 0;
                    desiredHeight = 800;
                }
                else if (width == height)
                {
                    desiredWidth = 800;
                    desiredHeight = 800;
                }
                else
                {
                    desiredWidth = 0;
                    desiredHeight = 0;
                }
                long compressionLevel = 75;
                status = ResizeImage2(imgpath, outputpath, desiredWidth, desiredHeight, compressionLevel);
                return status;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }

        }

        public string GetImgPath(string imguuid)
        {
            if (imguuid != null)
            {
                string Folder1 = imguuid[0].ToString(); string Folder2 = imguuid[1].ToString(); string Folder3 = imguuid[2].ToString();
                var path = Folder1 + "\\" + Folder2 + "\\" + Folder3;
                return path;
            }
            return "";
        }


        public int ResizeImage2(string inputImagePath, string outputImagePath, int desiredWidth, int desiredHeight, long compressionLevel)
        {
            try
            {
                using (Image originalImage = Image.FromFile(inputImagePath))
                {
                    int newWidth, newHeight;

                    if (desiredHeight == 0)
                    {
                        // Calculate new height based on the aspect ratio
                        double aspectRatio = (double)originalImage.Width / originalImage.Height;
                        newWidth = desiredWidth;
                        newHeight = (int)(desiredWidth / aspectRatio);
                    }
                    else if (desiredWidth == 0)
                    {
                        // Calculate new width based on the aspect ratio
                        double aspectRatio = (double)originalImage.Height / originalImage.Width;
                        newWidth = (int)(desiredHeight / aspectRatio);
                        newHeight = desiredHeight;
                    }
                    else
                    {
                        newWidth = desiredWidth;
                        newHeight = desiredHeight;
                    }

                    // Create a new Bitmap with the new dimensions
                    using (Bitmap resizedImage = new Bitmap(newWidth, newHeight))
                    {
                        using (Graphics graphics = Graphics.FromImage(resizedImage))
                        {
                            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
                        }

                        // Set compression level
                        EncoderParameters encoderParameters = new EncoderParameters(1);
                        encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, compressionLevel);

                        // Get the JPEG codec
                        ImageCodecInfo jpegCodec = GetEncoderInfo(ImageFormat.Jpeg);

                        // Save the resized and compressed image
                        resizedImage.Save(outputImagePath, jpegCodec, encoderParameters);
                    }
                }
                System.IO.File.Delete(inputImagePath);
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
        static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        public string ImgGetUUid(string tblname) //generate uuid for images
        {
            var uuid = (Guid.NewGuid()).ToString("D").ToLower(); var result = 0; var count = 0;
            //if (tblname != "existing_projects" && tblname != "water_quality" && tblname != "sustainability")
            //{
            //    var columsQ = @$"SELECT column_name as  coll, table_schema FROM information_schema.columns WHERE table_name = '{tblname}' AND (column_name LIKE '%photo%_uuid%' or column_name LIKE '%image%_uuid%')";
            //    var columnsR = _wqsContext.TxtOnlyVals.FromSqlRaw(columsQ).OrderBy(s => s.coll).AsNoTracking().ToList();
            //    foreach (var column in columnsR)
            //    {
            //        var Q = $@"select coalesce(count({column.coll}),0)::integer returnval from {column.table_schema}.{tblname} where {column.coll} = '{uuid}'";
            //        result = Convert.ToInt32(_wqsContext.WgDelReturn.FromSqlRaw(Q).OrderBy(s => s.returnval).FirstOrDefault().returnval);
            //        if (result != 0)
            //        {
            //            count = count + 1;
            //        }
            //    }
            //}
            //else
            //{
            //    var schemaname = tblname;
            //    var GetUsedTblQ = $@"SELECT table_name as table_schema, column_name as coll
            //                        FROM information_schema.columns
            //                        WHERE table_schema = '{schemaname}'
            //                        AND (column_name LIKE '%photo%_uuid%' or column_name LIKE '%image%_uuid%')
            //                        order by table_name, column_name";
            //    var columnsR = _wqsContext.TxtOnlyVals.FromSqlRaw(GetUsedTblQ).OrderBy(s => s.coll).ToList(); //here table_schema name = table name
            //    foreach (var column in columnsR)
            //    {
            //        var Q = $@"select coalesce(count({column.coll}),0)::integer returnval from {schemaname}.{column.table_schema} where {column.coll} = '{uuid}'";
            //        result = Convert.ToInt32(_wqsContext.WgDelReturn.FromSqlRaw(Q).OrderBy(s => s.returnval).FirstOrDefault().returnval);
            //        if (result != 0)
            //        {
            //            count = count + 1;
            //        }
            //    }
            //}
            //if (count != 0)
            //{
            //    ImgGetUUid(tblname);
            //}

            return uuid;
        }


        //public int DeleteImg(string uuid, string tblname, string imgFolder) //wash data elements and sustanibility
        //{
        //    // return 1;
        //    try
        //    {
        //        var ColumnsQ = @$"SELECT table_schema,column_name as  coll FROM information_schema.columns WHERE table_name = '{tblname}' AND (column_name LIKE '%photo%_uuid%' or column_name LIKE '%image%_uuid%')";
        //        var columnsR = _wqsContext.TxtOnlyVals.FromSqlRaw(ColumnsQ).OrderBy(s => s.coll).AsNoTracking().ToList();
        //        foreach (var column in columnsR)
        //        {
        //            var ImgUuidQ = $@"select coalesce({column.coll},'') as txt from {column.table_schema}.{tblname} where uuid like '{uuid}%' order by id";
        //            var ImguuidP = _wqsContext.SingleTxt.FromSqlRaw(ImgUuidQ).OrderBy(s => s.txt).FirstOrDefault();

        //            if (ImguuidP != null && ImguuidP.txt != "" && ImguuidP.txt != null)
        //            {
        //                var temppath = GetImgPath(ImguuidP.txt);
        //                var path = Path.Combine(_hostEnvironment.ContentRootPath, "nwash_images", imgFolder, temppath, ImguuidP.txt);
        //                if (System.IO.File.Exists(path))
        //                {
        //                    System.IO.File.Delete(path);
        //                }
        //            }
        //        }
        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return 0;
        //    }
        //}

        public int DownloadFile(IFormFile file, string path, string fileName)
        {
            try
            {
                var uploadfilepath = Path.Combine(path, fileName);
                if (System.IO.File.Exists(uploadfilepath))
                {
                    System.IO.File.Delete(uploadfilepath);
                }
                using (FileStream stream = new FileStream(uploadfilepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }

    }
}
