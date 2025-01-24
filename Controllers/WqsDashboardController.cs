//using DocumentFormat.OpenXml.Spreadsheet;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualBasic.FileIO;
//using System.Linq;
//using Wq_Surveillance.Models;

//namespace Wq_Surveillance
//{
//    public class WqsDashboardController : Controller
//    {
//        private readonly IHttpContextAccessor _sessionData;
//        private string _sUID;
//        private readonly WqsContext _context;
//        private static IWebHostEnvironment _hostEnvironment;
//        public WqsDashboardController(IHttpContextAccessor contextAccessor, WqsContext Contextdn, IWebHostEnvironment hostEnvironment)
//        {
//            _context = Contextdn;
//            _sessionData = contextAccessor;
//            _sUID = _sessionData.HttpContext.Session.GetString("SUserID");
//            _hostEnvironment = hostEnvironment;
//        }
//        public IActionResult Index()
//        {
//            ////form 1 b 
//            //var rangesummaryQ = "SELECT * FROM wqs.range_summary;";
//            //var rangesummary = _context.WqsRangeSummary.FromSqlRaw(rangesummaryQ);
//            //chart 1
//            var DataCollectionCountQ = "select * from wqs.mat_wqs_data_col";
//            var DataCollectionCount = _context.DateAndInt.FromSqlRaw(DataCollectionCountQ).ToList();
//            ViewBag.DataCollectionCount = DataCollectionCount;
            
//            //chart 3
//            var DataCollectionCountProvinceQ = "select * from wqs.mat_wqs_data_col_provincewise";
//            var DataCollectionCountProvince = _context.WqsDataCollProvincewise.FromSqlRaw(DataCollectionCountProvinceQ).ToList();
//            ViewBag.DataCollectionCountProvince = DataCollectionCountProvince;

<<<<<<< HEAD
            //card value
            var WspImlpementedPop = (from form1b in _context.Form1bs
                                     join wq in _context.WqSurveillanceMains
                                     on form1b.FormId equals wq.Uuid
                                     select wq.TotalBenificiaryPopulation)
                                 .Sum();
            var WspNotImlpementedPop = (from form1a in _context.Form1as
                                        join wq in _context.WqSurveillanceMains
                                        on form1a.FormId equals wq.Uuid
                                        select wq.TotalBenificiaryPopulation)
                                 .Sum();
            ViewBag.WspImlpementedPop = WspImlpementedPop;
            ViewBag.WspNotImlpementedPop = WspNotImlpementedPop;
=======
//            //card value
//            var WspImlpementedPop = (from form1b in _context.Form1bs
//                                     join wq in _context.WqSurvellianceMains
//                                     on form1b.FormId equals wq.Uuid
//                                     select wq.TotalBenificiaryPopulation)
//                                 .Sum();
//            var WspNotImlpementedPop = (from form1a in _context.Form1as
//                                        join wq in _context.WqSurvellianceMains
//                                        on form1a.FormId equals wq.Uuid
//                                        select wq.TotalBenificiaryPopulation)
//                                 .Sum();
//            ViewBag.WspImlpementedPop = WspImlpementedPop;
//            ViewBag.WspNotImlpementedPop = WspNotImlpementedPop;
>>>>>>> 0877ac2fec3764b8c9a05a754700235381e5d79c

//            //table
//            var wqtblQ = "select * from water_quality.mat_parameter_count_provincewise;";
//            ViewBag.WqTblProvince = _context.MatWqProvincewise.FromSqlRaw(wqtblQ).ToList(); 
//            return View();
//        }
//    }
//}
