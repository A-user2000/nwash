using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wq_Surveillance.Models;
using Wq_Surveillance.Service.WashSanitaryInspections;
using Wq_Surveillance.Service.WQS;

namespace Wq_Surveillance.Controllers
{
    public class SanitaryInspectionController : Controller
    {
        private readonly IWQSservices _wqsservices;
        private readonly IHttpContextAccessor _sessionData;
        private string _sUID;
        private readonly WqsContext _Context;
        private IWashSanitaryInspection _sanitaryinspection;
        public SanitaryInspectionController(IHttpContextAccessor contextAccessor, IWQSservices wqsservices, WqsContext dnContext, IWashSanitaryInspection sanitaryinspection)
        {
            _Context = dnContext;
            _sessionData = contextAccessor;
            _wqsservices = wqsservices;
            _sUID = _sessionData.HttpContext.Session.GetString("SUserID");
            _sanitaryinspection = sanitaryinspection;
        }
        public IActionResult Index(string proCode)
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

        public PartialViewResult GetSanitaryInspectionList(string proCode)
        {
            var inspectionlist = _sanitaryinspection.SanitaryInspectionList(proCode);
            return PartialView(inspectionlist);
        }

        public PartialViewResult SanitaryInspectionDetails(string Uuid, string Email, string PointId, string prouuid, string PointType)
        {
            var project = _Context.ProjectDetails.Where(u => u.Uuid == prouuid);
            ViewData["ProjectDetail"] = project;
            ViewBag.ProjectName = project.OrderBy(S => S.Id).Select(x => x.ProName).FirstOrDefault();

            var inceptiondetail = _sanitaryinspection.GetSanitaryInceptionDetails(Uuid, Email, PointId, prouuid, PointType);
            return PartialView(inceptiondetail);

        }

        public IActionResult Edit(string Uuid, string Email, string PointId, string prouuid, string PointType)
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

                var sTbl2 = from s in _Context.SanitaryInspections
                            join u in _Context.Users on Convert.ToInt32(s.UserId) equals u.UserId
                            join p in _Context.ProjectDetails on s.ProjectUuid equals p.Uuid
                            join v in _Context.SanitaryInspectionValues on s.Uuid equals v.SampleUuid
                            join t in _Context.SanitaryInspectionTemplates on v.QuestionId equals t.Id

                            where s.ProjectUuid == prouuid && PointId == s.PointId && PointType == s.PointType
                            orderby t.Id
                            //&& Email == u.Email && PointId == s.PointId
                            select new SanitaryInspection
                            {
                                Time = s.Time,
                                PointId = t.Question,
                                UserId = v.Value,
                                Id = v.Id
                            };
                return View(sTbl2.ToList());
            }
        }



        // POST: SanitaryInspections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        public string Update(int id, string answer)
        {
            SanitaryInspectionValue si = new SanitaryInspectionValue { Id = id };
            si.Value = answer;

            _Context.Entry(si).Property("Value").IsModified = true;
            _Context.SaveChanges();

            //_Context.Update(si);
            //        _Context.SaveChangesAsync();


            return "success";
        }

        // GET: SanitaryInspections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanitaryInspection = await _Context.SanitaryInspections.OrderBy(S => S.Id)
                                            .FirstOrDefaultAsync(m => m.Id == id);
            if (sanitaryInspection == null)
            {
                return NotFound();
            }

            return View(sanitaryInspection);
        }
    }
}
