using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wq_Surveillance.Models;
using Wq_Surveillance.Service;
using Wq_Surveillance.Service.WaterQuality;

namespace Wq_Surveillance.Controllers
{
    public class WaterQualityDataController : Controller
    {
        private readonly IHttpContextAccessor _sessionData;
        private readonly IWQSservices _wqsservices;
        private string _sUID;
        private readonly WqsContext _Context;
        //private ILabService _service;
        //private IFunctionalityQuery _funcservice;
        private IWaterQualityData _wqservice;
        private static IWebHostEnvironment _hostEnvironment;

        public WaterQualityDataController(IWQSservices wqsservices, IHttpContextAccessor contextAccessor,  WqsContext dnContext, IWaterQualityData wqservice, /*ILabService labservice*/ IWebHostEnvironment hostEnvironment)
        {
            _wqsservices = wqsservices;

            //_funcservice = service;
            _Context = dnContext;
            _sessionData = contextAccessor;
            _wqservice = wqservice;
            //_service = labservice;
            _sUID = _sessionData.HttpContext.Session.GetString("SUserID");
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            if (_sUID != null)
            //if (_sUID == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                ViewData["Province"] = _wqsservices.GetProvince();
                var pcode = _sessionData.HttpContext.Session.GetString("PProvince");
                var dcode = _sessionData.HttpContext.Session.GetString("PDistrict");
                ViewData["District"] = _Context.Districts.Where(s => s.ProvinceCode == pcode).OrderBy(item => item.DistrictCode).ToList();
                ViewData["Municipality"] = _Context.Municipalities.Where(s => s.DistrictCode == dcode).OrderBy(item => item.MunCode).ToList();
                return View();
            }
        }

        [HttpPost]
        public PartialViewResult GetWQSampleList(string proCode)
        {
            var sd = from s in _Context.WaterQualitySamples
                     join u in _Context.Users on Convert.ToInt32(s.UserId) equals u.UserId
                     join p in _Context.ProjectDetails on s.ProjectUuid equals p.Uuid
                     join q in _Context.WqSampleDetails on s.Uuid equals q.SampleUuid
                     where proCode == p.ProCode

                     select new WaterQualitySample
                     {
                         Id = s.Id,
                         TestingTime = s.TestingTime,
                         UserId = s.UserId,
                         Photo1 = q.SampledBy,
                         ProjectUuid = s.ProjectUuid,
                         PointId = s.PointId,
                         PointType = s.PointType,
                         SampleCode = s.SampleCode,
                         Completed = 0

                     };
            var sTbl = sd.Distinct();
            return PartialView(sTbl);
        }

        public PartialViewResult WQDetails(string sId, string Email, string PointId, string prouuid, string PointType)
        {
            var project = _Context.ProjectDetails.Where(u => u.Uuid == prouuid);
            ViewData["ProjectDetail"] = project;
            ViewBag.ProjectName = project.OrderBy(S => S.Id).Select(x => x.ProName).FirstOrDefault();

            var sTbl2 = from s in _Context.WaterQualitySamples
                        join u in _Context.Users on Convert.ToInt32(s.UserId) equals u.UserId
                        join p in _Context.ProjectDetails on s.ProjectUuid equals p.Uuid
                        join v in _Context.WaterQualityValues on s.Uuid equals v.SampleUuid
                        join t in _Context.WaterQualityTemplates on v.ParameterId equals t.Id
                        where s.ProjectUuid == prouuid && PointId == s.PointId && PointType == s.PointType
                        orderby t.Id, t.Category
                        select new WaterQualitySample
                        {
                            DescPhoto1 = t.ParameterName,
                            DescPhoto2 = t.Category,
                            DescPhoto3 = v.Value,
                            DescPhoto4 = t.Unit,
                            TestingTime = s.TestingTime,
                            Photo1Uuid = s.Photo1Uuid,
                            Photo2Uuid = s.Photo2Uuid,
                            Photo3Uuid = s.Photo3Uuid,
                            Photo4Uuid = s.Photo4Uuid,
                            InstrumentsUsed = s.InstrumentsUsed
                        };
            return PartialView(sTbl2.ToList());
        }

        //public ActionResult WQDetailData(string encode)
        //{
        //    var base64EncodedBytes = Convert.FromBase64String(encode);
        //    var code = Encoding.UTF8.GetString(base64EncodedBytes);

        //    var sampleData = _Context.WaterQualitySamples
        //                      .Where(s => (s.SampleCode == code)).OrderBy(S => S.Id)
        //                      .FirstOrDefault();
        //    var returnval = 0;
        //    if (sampleData != null)
        //    {
        //        var projectData = from s in _Context.ProjectDetails
        //                          join d in _Context.Districts on s.DistrictCode equals d.DistrictCode
        //                          join p in _Context.Municipalities on s.MunicipalityCode equals p.MunCode
        //                          where s.Uuid == sampleData.ProjectUuid
        //                          select new ProjectDetail
        //                          {
        //                              ProCode = s.ProCode,
        //                              ProName = s.ProName,
        //                              DistrictCode = d.DistrictName,
        //                              MunicipalityCode = p.MunName
        //                          };

        //        var data = _service.GetLabValue(sampleData.Uuid);
        //        var info = _Context.WqSampleDetails
        //                    .Where(s => (s.SampleUuid == sampleData.Uuid)).OrderBy(S => S.Id)
        //                    .FirstOrDefault();
        //        var labDetails = _Context.LabRegistration
        //                   .Where(s => (s.Uuid == sampleData.LabUuid)).OrderBy(S => S.Id)
        //                   .FirstOrDefault();
        //        dynamic sdata = new ExpandoObject();
        //        sdata.proDetails = projectData.FirstOrDefault();
        //        sdata.labDetails = labDetails;

        //        if (info != null)
        //        {
        //            sdata.data = data;
        //            sdata.info = info;

        //            returnval = 1;

        //            ViewData["SampleCode"] = code;
        //            ViewData["value"] = returnval;
        //            return View(sdata);
        //        }
        //        else
        //        {
        //            returnval = 3;                              // Sample Entry not done yet by Lab.
        //            ViewData["SampleCode"] = code;
        //            ViewData["value"] = returnval;
        //            return View(sdata);
        //        }
        //    }
        //    else
        //    {
        //        returnval = 2;
        //        ViewData["value"] = returnval;
        //        return View();
        //    }
        //}

        //*//*
        // * Water Quality Report
        // * Parameter Wise
        // *//*

        public IActionResult WQScheme()
        {
            if (_sUID != null)
                //if (_sUID == null)
                {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                ViewData["Province"] = _wqsservices.GetProvince();
                var pcode = _sessionData.HttpContext.Session.GetString("PProvince");
                var dcode = _sessionData.HttpContext.Session.GetString("PDistrict");
                ViewData["District"] = _Context.Districts.Where(s => s.ProvinceCode == pcode).OrderBy(item => item.DistrictCode).ToList();
                ViewData["Municipality"] = _Context.Municipalities.Where(s => s.DistrictCode == dcode).OrderBy(item => item.MunCode).ToList();
                return View();
            }
        }

        [HttpPost]
        public PartialViewResult GetWQSchemeReport(string proCode, int parId)
        {
            dynamic wqModel = new ExpandoObject();
            wqModel.sumData = _wqservice.GetParameterData(proCode, parId);
            return PartialView(wqModel);
        }

        //*//*
        // * Scheme Wise
        // *//*

        public IActionResult WQParameter()
        {
            if (_sUID != null)
            //if (_sUID == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                dynamic wqModel = new ExpandoObject();
                ViewData["Province"] = _wqsservices.GetProvince();
                wqModel.Groups = _Context.WaterQualityTemplates
                                        .OrderBy(item => item.Id)
                                        .Select(s => s.Category)
                                        .Distinct()
                                        .ToList();
                var pcode = _sessionData.HttpContext.Session.GetString("PProvince");
                var dcode = _sessionData.HttpContext.Session.GetString("PDistrict");
                ViewData["District"] = _Context.Districts.Where(s => s.ProvinceCode == pcode).OrderBy(item => item.DistrictCode).ToList();
                ViewData["Municipality"] = _Context.Municipalities.Where(s => s.DistrictCode == dcode).OrderBy(item => item.MunCode).ToList();
                return View(wqModel);
            }
        }


        [HttpPost]
        public JsonResult GetSelectedParameters(string grpName)
        {
            var dict = _Context.WaterQualityTemplates.Where(s => s.Category == grpName).OrderBy(item => item.Id);
            return Json(dict);
        }

        [HttpPost]
        public PartialViewResult GetSelectedParameterData(string province, string district, string munCode, string proCode, int parameter, int dyear)
        {
            dynamic wqModel = new ExpandoObject();
            ViewData["Year"] = dyear;
            if (proCode != "0")                                  // project wise parameter summary
            {
                wqModel.pData = _wqservice.GetProjectParameterData(proCode, parameter, dyear);
            }

            if (proCode == "0" && munCode != "0")                // municipality wise parameter summary
            {
                wqModel.pData = _wqservice.GetMunParameterData(munCode, parameter, dyear);
            }
            if (munCode == "0" && district != "0")                // district wise parameter summary
            {
                wqModel.pData = _wqservice.GetDistrictParameterData(district, parameter, dyear);
            }
            if (district == "0" && province != "0")                // province wise parameter summary
            {
                wqModel.pData = _wqservice.GetProvinceParameterData(province, parameter, dyear);
            }
            return PartialView(wqModel);
        }

        public ActionResult Edit(string sId, string Email, string PointId, string prouuid, string PointType)
        {
            if (_sUID != null)
            //if (_sUID == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                var project = _Context.ProjectDetails.Where(u => u.Uuid == prouuid);
                ViewData["ProjectDetail"] = project;
                ViewBag.ProjectName = project.OrderBy(S => S.Id).Select(x => x.ProName).FirstOrDefault();
                var sTbl2 = from s in _Context.WaterQualitySamples
                            join u in _Context.Users on Convert.ToInt32(s.UserId) equals u.UserId
                            join p in _Context.ProjectDetails on s.ProjectUuid equals p.Uuid
                            join v in _Context.WaterQualityValues on s.Uuid equals v.SampleUuid
                            join t in _Context.WaterQualityTemplates on v.ParameterId equals t.Id
                            where s.ProjectUuid == prouuid && s.PointId == PointId && s.PointType == PointType
                            orderby s.TestingTime, t.Category, t.Id
                            select new WaterQualitySample
                            {
                                DescPhoto1 = t.ParameterName,
                                PointId = t.Range,
                                DescPhoto2 = t.Category,
                                DescPhoto3 = v.Value,
                                DescPhoto4 = t.Unit,
                                TestingTime = s.TestingTime,
                                Photo1Uuid = s.Photo1Uuid,
                                Photo2Uuid = s.Photo2Uuid,
                                Photo3Uuid = s.Photo3Uuid,
                                Photo4Uuid = s.Photo4Uuid,
                                InstrumentsUsed = s.InstrumentsUsed,
                                Id = v.Id,
                                Uuid = Convert.ToString(s.Id)
                            };
                return View(sTbl2.ToList());
            }
        }

        public string Update(int id, string answer)
        {
            var uid = (int)_sessionData.HttpContext.Session.GetInt32("SUserID");
            WaterQualityValue si = new WaterQualityValue { Id = id };
            si.Value = answer;
            si.EditedOn = DateTime.UtcNow;
            si.EditedBy = _Context.Users.Where(s => s.UserId == uid).OrderBy(s => s.UserId).Select(s => s.Name).FirstOrDefault();

            _Context.Entry(si).Property("Value").IsModified = true;
            _Context.SaveChanges();
            return "success";
        }

        public string UpdateInstrument(int id, string answer)
        {
            WaterQualitySample si = new WaterQualitySample { Id = id };
            si.InstrumentsUsed = answer;

            _Context.Entry(si).Property("InstrumentsUsed").IsModified = true;
            _Context.SaveChanges();

            return "success";
        }

        public string Delete(int id, string photoindex)
        {
            WaterQualitySample f = _Context.WaterQualitySamples.OrderBy(S => S.Id).FirstOrDefault(x => x.Id == id);
            if (photoindex == "photo1")
            {
                f.Photo1 = null;
                f.Photo1Uuid = null;
            }
            else if (photoindex == "photo2")
            {
                f.Photo2 = "";
                f.Photo2Uuid = "";
            }
            else if (photoindex == "photo3")
            {
                f.Photo3 = null;
                f.Photo3Uuid = null;
            }
            else
            {
                f.Photo4 = null;
                f.Photo4Uuid = null;
            }
            _Context.Update(f);
            _Context.SaveChanges();
            return "success";
        }

        //*//*
        // * Historical Arsenic Data View
        // *//*

        public IActionResult HHArsenicResult()
        {
            if (_sUID != null)
            //if (_sUID == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                ViewData["Province"] = _wqsservices.GetProvince();
                var pcode = _sessionData.HttpContext.Session.GetString("PProvince");
                var dcode = _sessionData.HttpContext.Session.GetString("PDistrict");
                ViewData["District"] = _Context.Districts.Where(s => s.ProvinceCode == pcode).OrderBy(item => item.DistrictCode).ToList();
                ViewData["Municipality"] = _Context.Municipalities.Where(s => s.DistrictCode == dcode).OrderBy(item => item.MunCode).ToList();
                return View("ArsenicData/Index");
            }
        }
        [HttpPost]
        public PartialViewResult GetArsenicData(string munCode, string dCode)
        {
            var aData = new List<ArsenicHi>();
            if (munCode != "All")
            {
                ViewData["munCode"] = munCode;
                ViewData["dCode"] = "0";
                aData = _Context.ArsenicHis.Where(s => s.Mcode == munCode).ToList();
            }
            else
            {
                ViewData["munCode"] = "0";
                ViewData["dCode"] = dCode;
                aData = _Context.ArsenicHis.Where(s => s.Dcode == dCode).ToList();
            }


            return PartialView("ArsenicData/DetailView", aData);
        }

        public ActionResult ArsenicDataToExcel(string table_name, string munCode, string dCode)
        {
            string[] headers;
            string pgsQuery;
            //List<DataTable> dts = new List<DataTable>();
            DataTable dt = new DataTable();
            var whereCond = "";
            string fileName;

            if (munCode != "0")
            {
                whereCond = " where mcode='" + munCode + "'";
                fileName = munCode + "_" + table_name + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
            }
            else
            {
                whereCond = " where dcode='" + dCode + "'";
                fileName = dCode + "_" + table_name + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
            }

            headers = new string[17] { "Municipality", "House Owner", "Community", "Old VDC-Ward", "Point Id", "Point Type", "Depth (m)", "HH Served", "Population", "Construction Year(BS/AD)", "Constructed By", "Agency", "Latitude", "Longitude", "Test Type", "Other Test", "Arsenic Conc" };
            pgsQuery = @"select m.mun_name,owner_name,community,concat(vdc_name,' - ',old_ward) vdc_ward,point_id,ptype,ROUND(depth_m::numeric,2) depth,no_hh,no_pop,concat(con_year_bs,'/',con_year_ad) cons_year,con_by,agency,ROUND(lat::numeric,6) lat,ROUND(lon::numeric,6) lon,test_type,other_test,arc_conc
                                 from water_quality.arsenic_his ah
	                             join system.municipality m on m.mun_code=ah.mcode " +
                                 whereCond +
                                 "order by m.mun_name";

            // trying lavs link
            DbConnection connection = _Context.Database.GetDbConnection();
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);
            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = pgsQuery;
                //if(pa) -- parameters here.. <where conditions?>
                using DbDataAdapter adapter = dbFactory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
            }

            string contentType = "application /vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            string pathDownload = Path.Combine(_hostEnvironment.WebRootPath, "ArsenicData");

            if (!Directory.Exists(pathDownload))
            {
                Directory.CreateDirectory(pathDownload);
            }

            using var workbook = new XLWorkbook();
            workbook.Properties.Company = "Softwel Pvt. Ltd.";

            IXLWorksheet worksheet =
            workbook.Worksheets.Add(table_name.ToUpper());
            IXLCell xcl;
            int row = 1;
            for (int i = 1; i <= headers.Length; i++)
            {
                xcl = worksheet.Cell(1, i);
                xcl.Value = headers[i - 1];
                xcl.Style.Font.Bold = true;
                xcl.Style.Font.Italic = true;
                xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                xcl.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                xcl.Style.Fill.BackgroundColor = XLColor.AliceBlue;
            }
            row++;

            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 1; i <= headers.Length; i++)
                {
                    xcl = worksheet.Cell(row, i);
                    xcl.Value = $"{dr[i - 1]}";

                    xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                    xcl.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                }
                row++;
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            var content = stream.ToArray();
            string actualFilePath = pathDownload + fileName;
            workbook.SaveAs(actualFilePath);
            workbook.Dispose();
            byte[] fileBytes = System.IO.File.ReadAllBytes(actualFilePath);
            System.IO.File.Delete(actualFilePath);
            return File(fileBytes, contentType, fileName);
        }
    }
}