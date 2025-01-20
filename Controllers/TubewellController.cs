using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Wq_Surveillance.Models;
using Wq_Surveillance.Service;

namespace Nwash.Controllers
{
    public class TubewellController : Controller
    {
        private readonly IHttpContextAccessor _sessionData;
        private string _sUID;
        private readonly WqsContext _wqsContext;
        private ITubewellData _tdata;
        public TubewellController(IHttpContextAccessor contextAccessor, WqsContext nwash_dnContext, ITubewellData tdata)
        {
            _wqsContext = nwash_dnContext;
            _sessionData = contextAccessor;
            _sUID = _sessionData.HttpContext.Session.GetString("SUserID");
            _tdata = tdata;
        }

        public IActionResult Index()
        {
            if (_sUID == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                ViewData["Province"] = _wqsContext.Provinces.OrderBy(s => s.ProvinceCode).ToList();
                var pcode = _sessionData.HttpContext.Session.GetString("PProvince");
                var dcode = _sessionData.HttpContext.Session.GetString("PDistrict");
                ViewData["District"] = _wqsContext.Districts.Where(s => s.ProvinceCode == pcode).OrderBy(item => item.DistrictCode).ToList();
                ViewData["Municipality"] = _wqsContext.Municipalities.Where(s => s.DistrictCode == dcode).OrderBy(item => item.MunCode).ToList();
                return View();
            }
        }

        [HttpPost]
        public PartialViewResult TubewellData(string munCode)
        {
            ViewData["munCode"] = munCode;
            var hhData = _tdata.GetTubewellData(munCode);

            return PartialView("~/Views/Home/Form1B/Form1BData.cshtml", hhData);
        }

        public IActionResult TubewellDetailView(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            var hhDataList = _tdata.TubewellDetailList(uuid);
            ViewData["AddedBy"] = _wqsContext.Users.Where(s => s.Email == hhDataList.AddBy).Select(s => s.Name).SingleOrDefault();
            return View(hhDataList);
        }

        public IActionResult TubewellDataEdit(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            var hhDataList = _tdata.TubewellDetailList(uuid);
            ViewData["AddedBy"] = _wqsContext.Users.Where(s => s.Email == hhDataList.AddBy).Select(s => s.Name).SingleOrDefault();
            return View("~/Views/Home/Tubewell/TubewellDataEdit.cshtml",hhDataList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TubewellEditPost(Tubewell tdata)
        {
            var updateData = _tdata.UpdateTubewellData(tdata);

            string uuid = tdata.Uuid;

            var plainTextBytes = Encoding.UTF8.GetBytes(uuid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("TubewellDataEdit", "Tubewell", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("TubewellDataEdit", "Tubewell", new { @id = encodedUUID });
            }
        }
        [HttpPost]
        public int TubewellDataDelete(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            var delData = _tdata.DeleteTubewellData(uuid);
            return delData;
        }
    }
}
