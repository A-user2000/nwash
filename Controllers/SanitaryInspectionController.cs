//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Nwash.Functionality;
//using Nwash.Models;
//using Nwash.Service.SanitaryInspection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Nwash.Controllers
//{
//    public class SanitaryInspectionController : Controller
//    {
//        private IFunctionalityQuery _funcservice;
//        private readonly IHttpContextAccessor _sessionData;
//        private string _sUID;
//        private readonly nwash_dnContext _nwashdnContext;
//        private IWashSanitaryInspection _sanitaryinspection;
//        public SanitaryInspectionController(IHttpContextAccessor contextAccessor, IFunctionalityQuery service, nwash_dnContext nwash_dnContext, IWashSanitaryInspection sanitaryinspection)
//        {
//            _nwashdnContext = nwash_dnContext;
//            _sessionData = contextAccessor;
//            _funcservice = service;
//            _sUID = _sessionData.HttpContext.Session.GetString("SUserID");
//            _sanitaryinspection = sanitaryinspection;
//        }
//        public IActionResult Index(string proCode)
//        {
//            if (_sUID == null)
//            {
//                return RedirectToAction("Index", "Login", new { area = "" });
//            }
//            else
//            {
//                ViewData["Province"] = _funcservice.GetProvince();
//                var pcode = _sessionData.HttpContext.Session.GetString("PProvince");
//                var dcode = _sessionData.HttpContext.Session.GetString("PDistrict");
//                ViewData["District"] = _nwashdnContext.District.Where(s => s.ProvinceCode == pcode).OrderBy(item => item.DistrictCode).ToList();
//                ViewData["Municipality"] = _nwashdnContext.Municipality.Where(s => s.DistrictCode == dcode).OrderBy(item => item.MunCode).ToList();
//                return View();
//            }
//        }

//        public PartialViewResult GetSanitaryInspectionList(string proCode)
//        {
//            var inspectionlist = _sanitaryinspection.SanitaryInspectionList(proCode);
//            return PartialView(inspectionlist);
//        }

//        public PartialViewResult SanitaryInspectionDetails(string Uuid, string Email, string PointId, string prouuid, string PointType)
//        {
//            var project = _nwashdnContext.ProjectDetails.Where(u => u.Uuid == prouuid);
//            ViewData["ProjectDetail"] = project;
//            ViewBag.ProjectName = project.OrderBy(S => S.Id).Select(x => x.ProName).FirstOrDefault();

//            var inceptiondetail = _sanitaryinspection.GetSanitaryInceptionDetails(Uuid, Email, PointId, prouuid, PointType);
//            return PartialView(inceptiondetail);

//        }

//        public IActionResult Edit(string Uuid, string Email, string PointId, string prouuid, string PointType)
//        {
//            if (_sUID == null)
//            {
//                return RedirectToAction("Index", "Login", new { area = "" });
//            }
//            else
//            {
//                var project = _nwashdnContext.ProjectDetails.Where(u => u.Uuid == prouuid);
//                ViewData["ProjectDetail"] = project;
//                ViewBag.ProjectName = project.OrderBy(S => S.Id).Select(x => x.ProName).FirstOrDefault();

//                var sTbl2 = from s in _nwashdnContext.SanitaryInspection
//                            join u in _nwashdnContext.Users on Convert.ToInt32(s.UserId) equals u.UserId
//                            join p in _nwashdnContext.ProjectDetails on s.ProjectUuid equals p.Uuid
//                            join v in _nwashdnContext.SanitaryInspectionValues on s.Uuid equals v.SampleUuid
//                            join t in _nwashdnContext.SanitaryInspectionTemplate on v.QuestionId equals t.Id

//                            where s.ProjectUuid == prouuid && PointId == s.PointId && PointType == s.PointType
//                            orderby t.Id
//                            //&& Email == u.Email && PointId == s.PointId
//                            select new SanitaryInspection
//                            {
//                                Time = s.Time,
//                                PointId = t.Question,
//                                UserId = v.Value,
//                                Id = v.Id
//                            };
//                return View(sTbl2.ToList());
//            }
//        }



//        // POST: SanitaryInspections/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

//        public string Update(int id, string answer)
//        {
//            SanitaryInspectionValues si = new SanitaryInspectionValues { Id = id };
//            si.Value = answer;

//            _nwashdnContext.Entry(si).Property("Value").IsModified = true;
//            _nwashdnContext.SaveChanges();

//            //_nwashdnContext.Update(si);
//            //        _nwashdnContext.SaveChangesAsync();


//            return "success";
//        }

//        // GET: SanitaryInspections/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var sanitaryInspection = await _nwashdnContext.SanitaryInspection.OrderBy(S => S.Id)
//                                            .FirstOrDefaultAsync(m => m.Id == id);
//            if (sanitaryInspection == null)
//            {
//                return NotFound();
//            }

//            return View(sanitaryInspection);
//        }
//    }
//}
