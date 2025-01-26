using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wq_Surveillance.Models;
using Wq_Surveillance.Models.QueryTables;
using Wq_Surveillance.NwashModels;
using Wq_Surveillance.Service.WQS;

namespace Wq_Surveillance.Controllers
{
    public class WqsChartnTableController : Controller
    {
        private readonly WqsContext _wqsContext;
        private readonly IWQSservices _wqsservices;
        private readonly IHttpContextAccessor _sessionData;
        private readonly IMapper _mapper;


        public WqsChartnTableController(IHttpContextAccessor httpContextAccessor, WqsContext wqsContext, IWQSservices wqsservices)
        {
            _sessionData = httpContextAccessor;
            _wqsContext = wqsContext;
            _wqsservices = wqsservices;
           
        }


        public ActionResult Index()
        {
            ViewData["Province"] = _wqsservices.GetProvince();
            var pcode = _sessionData.HttpContext.Session.GetString("PProvince");
            var dcode = _sessionData.HttpContext.Session.GetString("PDistrict");
            ViewData["District"] = _wqsContext.Districts.Where(s => s.ProvinceCode == pcode).OrderBy(item => item.DistrictCode).ToList();
            ViewData["Municipality"] = _wqsContext.Municipalities.Where(s => s.DistrictCode == dcode).OrderBy(item => item.MunCode).ToList();
            return View();
        } 

        public PartialViewResult ChartView(string MunCode)
        {
            //chart 1 
            var Form1aWspStatusQ = $@"select * from wqs.get_from1a_wspinitiative_counts('{@MunCode}')";
            var Form1aWspStatus = _wqsContext.Form1aWspInitiativeCount.FromSqlRaw(Form1aWspStatusQ).ToList();
            ViewBag.Form1aWspStatus = Form1aWspStatus;
            //chart 2 and 3 data
            var Form1bWspScoreQ = $@"select * from wqs.get_form1b_wsp_score('{@MunCode}')";
            var Form1bWspScore = _wqsContext.Form1bWspScore.FromSqlRaw(Form1bWspScoreQ).ToList();
            ViewBag.Form1bWspScore = Form1bWspScore;
            return PartialView();
        }


        public ActionResult TablesViewIndex()
        {
            ViewData["Province"] = _wqsservices.GetProvince();
            var pcode = _sessionData.HttpContext.Session.GetString("PProvince");
            var dcode = _sessionData.HttpContext.Session.GetString("PDistrict");
            ViewData["District"] = _wqsContext.Districts.Where(s => s.ProvinceCode == pcode).OrderBy(item => item.DistrictCode).ToList();
            ViewData["Municipality"] = _wqsContext.Municipalities.Where(s => s.DistrictCode == dcode).OrderBy(item => item.MunCode).ToList();
            return View();

        }

        public PartialViewResult TableView(string MunCode, string TblName)
        {
            ViewBag.TblName = TblName;
            if (TblName == "Tbl1")
            {
                var Form1aWspStatusQ = $@"select * from wqs.get_from1a_wspinitiative_counts('{@MunCode}')";
                var Form1aWspStatus = _wqsContext.Form1aWspInitiativeCount.FromSqlRaw(Form1aWspStatusQ).ToList();
                return PartialView(Form1aWspStatus);
            }
            else if (TblName == "Tbl2" || TblName == "Tbl3")
            {
                var Form1bWspScoreQ = $@"select * from wqs.get_form1b_wsp_score('{@MunCode}')";
                var Form1bWspScore = _wqsContext.Form1bWspScore.FromSqlRaw(Form1bWspScoreQ).ToList();
                return PartialView(Form1bWspScore);
            }
            else
            {
                return PartialView();
            }

        }
    }
}
