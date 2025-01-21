using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wq_Surveillance.Models;

namespace Wq_Surveillance.Controllers
{
    public class SystemController : Controller
    {
        private readonly WqsContext _wqsContext;
        private readonly ISession session;

        public SystemController(WqsContext nwash_dnContext, IHttpContextAccessor HttpContextAccessor)
        {
            _wqsContext = nwash_dnContext;
            this.session = HttpContextAccessor.HttpContext.Session;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetDistrict(string provinceCode)
        {
            this.session.SetString("PProvince", provinceCode);
            var dict = _wqsContext.Districts.Where(s => s.ProvinceCode == provinceCode).OrderBy(item => item.DistrictCode);
            return Json(dict);
        }

        [HttpPost]
        public JsonResult GetMunicipality(string dCode)
        {
            this.session.SetString("PDistrict", dCode);
            var dict = _wqsContext.Municipalities.Where(s => s.DistrictCode == dCode).OrderBy(item => item.MunCode);
            return Json(dict);
        }

        [HttpPost]
        public JsonResult GetProjectList(string munCode)
        {
            this.session.SetString("PMunicipality", munCode);
            var dict = _wqsContext.ProjectDetails
                            .Where(s => (s.MunicipalityCode == munCode))
                            .Where(s => (s.TheGeom != null))
                            .Select(s => new { s.ProCode, s.ProName, s.Uuid })
                            .OrderBy(item => item.ProCode);
            return Json(dict);
        }

        [HttpPost]
        public JsonResult GetLabList(string munCode)
        {
            this.session.SetString("PMunicipality", munCode);
            var dict = _wqsContext.LabRegistration
                            .Where(s => (s.Municipality == munCode))
                            //.Where(s => (s.TheGeom != null))      // checking for empty geometry.
                            .Select(s => new { s.Id, s.LabName, s.Uuid })
                            .OrderBy(item => item.LabName);
            return Json(dict);
        }

        [HttpPost]
        public string GetProjectInvAgency(string proUuid)
        {
            var dict = _wqsContext.ProjectDetails.OrderBy(S => S.Id)
                            .Where(s => (s.Uuid == proUuid))
                            .Select(s => s.InvAgency)
                            .FirstOrDefault();
            return dict;
        }

        [HttpPost]
        public JsonResult GetProjectTapList(string proUuid)
        {
            var dict = _wqsContext.Taps
                            .Where(s => (s.ProUuid == proUuid))
                            .Where(s => (!(s.Lat == null) && !(s.Lon == null)))      // checking for empty geometry.
                            .Select(s => new { s.ProUuid, s.Uuid, s.TapNo })
                            .OrderBy(item => item.TapNo);
            return Json(dict);
        }

        [HttpPost]
        public JsonResult GetProjectDetails(string proUuid)
        {
            var query = @"select pd.uuid,pd.province_code,pd.district_code,pd.municipality_code,pd.pro_name,pd.pro_code,d.district_name,d.dcode,m.mun_name,m.mun_code,inv_agency,pd.pro_type,coalesce(pd.lat,0) lat,coalesce(pd.lon,0) lon,coalesce(pd.ele,0) ele,pd.cons_agency,
	                        coalesce(pd.cons_year,0) cons_year,pd.sup_agency,pd.settlement_name,pd.ward_no
	                        from existing_projects.project_details pd
	                        left join (select district_code as dcode,district_name from system.district)d on d.dcode=pd.district_code
	                        left join (select mun_code,mun_name from system.municipality)m on m.mun_code=pd.municipality_code
	                        where pd.uuid='" + proUuid + "' order by pd.pro_name asc";

            var proDetails = _wqsContext.ProjectDetailData
                              .FromSqlRaw(query)
                              .FirstOrDefault();
            return Json(proDetails);

        }
        [HttpPost]
        //public PartialViewResult InventoryReport(string munCode, string province, string district)
        //{
        //    ViewData["munCode"] = munCode;
        //    var inventoryData = _projectDataInventory.GetInventoryData(munCode, province, district);

        //    if ((district != "0") && (munCode != "0"))
        //    {
        //        //Testing to divide multiple file
        //        /*if (inventoryData.Count > 0)
        //        {
        //            foreach (var inv in inventoryData)
        //            {
        //                var v = inv.uuid;
        //                var NoOfTap = (int)_nwashdbContext.Tap.Where(s => s.ProUuid == inv.uuid).Select(s => s.Id).Count();
        //                var NoOfPipe = _nwashdbContext.Pipe.Where(s => s.ProUuid == inv.uuid).Select(s => s.Id).Count();
        //                var noofrowsT = 0.0;
        //                var noofrowsP = 0.0;
        //                var noofrows=0;
        //                if (NoOfPipe > 1000 || NoOfTap > 1000)
        //                {
        //                    noofrowsT = Math.Ceiling(Convert.ToDouble(NoOfTap / 1000));
        //                    noofrowsP = Math.Ceiling(Convert.ToDouble(NoOfTap / 1000));
        //                }
        //                if(noofrowsT > noofrowsP)
        //                {
        //                    noofrows = Convert.ToInt32(noofrowsT);
        //                }
        //                if (noofrowsT < noofrowsP)
        //                {
        //                    noofrows = Convert.ToInt32(noofrowsP);
        //                }
        //                else
        //                {
        //                    noofrows = Convert.ToInt32(noofrowsT);
        //                }
        //                for (var t = noofrows; t < 1; t--)
        //                {
        //                    inventoryData.Add(inv);
        //                }
        //            }
        //        }*/
        //        return PartialView(inventoryData);
        //    }
        //    else if ((district != "0") && (munCode == "0"))
        //    {
        //        return PartialView("Inventory/InventoryReport_District", inventoryData);
        //    }
        //    else
        //    {
        //        return PartialView("Inventory/InventoryReport_Province", inventoryData);
        //    }
        //}



        public string HashPassword(string Password)
        {
            HashAlgorithm MD5 = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(Password);
            bs = MD5.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
                s.Append(b.ToString("x2").ToLower());
            string hash = s.ToString();
            return hash;
        }
    }
}