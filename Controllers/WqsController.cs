using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using System.Text;
using System.Xml.Linq;
using Wq_Surveillance.Models;
using System.Data.Entity;
using Wq_Surveillance.Models.Dto;
using AutoMapper;
using NetTopologySuite.Index.HPRtree;
using Microsoft.SqlServer.Server;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using Microsoft.Extensions.Hosting;
using System.Data.Common;
using System.Data;
using System.Diagnostics;
using Wq_Surveillance.NwashModels;
using Wq_Surveillance.Service.WQS;
namespace Wq_Surveillance.Controllers
{
    public class WqsController : Controller
    {
        private readonly WqsContext _wqsContext;
        private readonly NwashContext _nwashContext;
        private readonly IWQSservices _wqsservices;
        private readonly IHttpContextAccessor _sessionData;
        private readonly IMapper _mapper;
        private static IWebHostEnvironment _hostEnvironment;




        public WqsController(IWQSservices wqsservices, IMapper mapper, IHttpContextAccessor httpContextAccessor, WqsContext wqsContext, IWebHostEnvironment hostEnvironment,NwashContext nwashContext)
        {
            _sessionData = httpContextAccessor;
            _wqsContext = wqsContext;
            _mapper = mapper;
            _wqsservices = wqsservices;
            _hostEnvironment = hostEnvironment;
            _nwashContext = nwashContext;

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





        //public PartialViewResult Wqdata(string munCode)
        //{

        //    ViewData["munCode"] = munCode;

        //    var data = _wqsContext.WqSurveillanceMains
        //        .AsEnumerable() // Converts to in-memory collection
        //        .Where(s => s.Municipality != null && _wqsservices.ExtractNumber(s.Municipality) == munCode)
        //        .OrderByDescending(item => item.Id)
        //        .ToList();

        //    List<WQDto> dto = new();

        //    foreach (var item in data)
        //    {
        //        WQDto val = _mapper.Map<WQDto>(item);
        //        var pd = _wqsContext.ProjectDetails.FirstOrDefault(p => p.ProCode.Equals(_wqsservices.ExtractNumber(item.ProjectName)));

        //        if (pd != null)
        //        {
        //            var projectData = _wqsContext.Taps
        //            .Where(t => t.ProUuid.Equals(pd.Uuid)).ToList();

        //            if (projectData != null)
        //            {
        //                val.TotalPop = 0;
        //                val.TotalHh = 0;
        //                foreach (var pdl in projectData)
        //                {
        //                    val.TotalPop += (pdl.MalePop ?? 0) + (pdl.FemalePop ?? 0);
        //                    val.TotalHh += (pdl.HhServerd ?? 0);

        //                }
        //            }
        //            else
        //            {
        //                val.TotalPop = null;  // Or 0 if it's an int
        //                val.TotalHhServed = null;  // Or 0 if it's an int
        //            }
        //        }
        //        else
        //        {
        //            val.TotalPop = null;  // Or 0 if it's an int
        //            val.TotalHh = null;  // Or 0 if it's an int
        //        }
        //        dto.Add(val);
        //    }
        //}

        public PartialViewResult Wqdata(string munCode)
        {

            ViewData["munCode"] = munCode;

            var data = _wqsContext.WqSurveillanceMains
                .AsEnumerable() // Converts to in-memory collection
                .Where(s => s.Municipality != null && _wqsservices.ExtractNumber(s.Municipality) == munCode)
                .OrderByDescending(item => item.Id)
                .ToList();

            List<WQDto> dto = new();

            foreach (var item in data)
            {
                WQDto val = _mapper.Map<WQDto>(item);
                var pd = _wqsContext.ProjectDetails.FirstOrDefault(p => p.ProCode.Equals(item.ProjectName));

                if (pd != null)
                {
                    var projectData = _nwashContext.Taps
                    .Where(t => t.ProUuid.Equals(pd.Uuid)).ToList();

                    if (projectData != null)
                    {
                        val.TotalPop = 0;
                        val.TotalHhServed = 0;
                        foreach (var pdl in projectData)
                        {
                            val.TotalPop += (pdl.MalePop ?? 0) + (pdl.FemalePop ?? 0);
                            //val.TotalHhServed += (pdl.HhServerd ?? 0);

                        }
                    }
                    else
                    {
                        val.TotalPop = null;  // Or 0 if it's an int
                        val.TotalHhServed = null;  // Or 0 if it's an int
                    }
                }
                else
                {
                    val.TotalPop = null;  // Or 0 if it's an int
                    val.TotalHhServed = null;  // Or 0 if it's an int
                }
                dto.Add(val);
            }





            var hhData = data;


            return PartialView("~/Views/Wqs/Wq_Surveillance/Wq_Main.cshtml", dto);
        }
        public PartialViewResult SanData(string munCode)
        {
            ViewData["munCode"] = munCode;

            // Query the data and project into the ViewModel
            var data = _wqsContext.WqSurveillanceMains
                .AsEnumerable()
                .Where(s => s.Municipality != null && _wqsservices.ExtractNumber(s.Municipality) == munCode)
                .OrderByDescending(item => item.Id)
                .Select(item => new SanitaryIndexVm
                {
                    Id = item.Id,
                    Uuid = item.Uuid,
                    Municipality = item.Municipality,
                    ProjectName = item.ProjectName,
                    Surveyor = item.Surveyor,
                    AddedBy=item.AddedBy,
                    ReservoirExists = _wqsContext.ReservoirSanitaries.Any(f => f.FormId == item.Uuid),
                    SourceExists = _wqsContext.SourceSanitaries.Any(f => f.FormId == item.Uuid),
                    StructureExists = _wqsContext.StructureSanitaries.Any(f => f.FormId == item.Uuid),
                    TapExists = _wqsContext.TapSanitaries.Any(f => f.FormId == item.Uuid)
                })
                .ToList();

            // Pass the ViewModel to the view
            return PartialView("~/Views/Wqs/Sanitary_Inspection/SanitaryIndex.cshtml", data);
        }





        public WqSurveillanceMain GetAddressFromId(string Id)
        {
            return _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Id.Equals(Id));

        }
 
        public PartialViewResult F1AData(string munCode)
        {
            //var name= _wqsservices.GetName(munCode);
            var data = _wqsservices.GetFormId(munCode);
            var address= _wqsservices.GetAddress(munCode);
                var householdData = _wqsservices.GetHH(munCode);
                var population = _wqsservices.GetPop(munCode);
                var f1Data = _wqsContext.Form1as
                .Where(p => data.Keys.Contains(p.FormId))
                .ToList();

            List<Form1ADto> result = new List<Form1ADto>();

            foreach(var val in f1Data)
            {
                Form1ADto item = _mapper.Map<Form1ADto>(val);
                //item.ProName = (name[item.ProName]);
                item.ProCode = (data[item.FormId]);
                item.Address = (address[item.FormId]);
                    item.TotalHhServed = householdData.ContainsKey(item.FormId) ? householdData[item.FormId] : 0;
                    item.TotalBenificiaryPopulation = population.ContainsKey(item.FormId) ? population[item.FormId] : 0;
                    result.Add(item);
            }
            ViewData["munCode"] = munCode;

            return PartialView("~/Views/Wqs/Form1A/GetForm1A.cshtml", result);
        }

        public PartialViewResult F1BData(string munCode)
        {
            ViewData["munCode"] = munCode;

            var data = _wqsservices.GetFormId(munCode);
            var address = _wqsservices.GetAddress(munCode);
            var f1bData = _wqsContext.Form1bs
                .Where(p => data.Keys.Contains(p.FormId))
                .ToList();
            var householdData = _wqsservices.GetHH(munCode);
            var population = _wqsservices.GetPop(munCode);
            List<Form1BDto> result = new List<Form1BDto>();

            foreach (var val in f1bData)
            {
                Form1BDto item = _mapper.Map<Form1BDto>(val);
                item.ProCode = (data[item.FormId]);
                item.Address = (address[item.FormId]);
                item.TotalHhServed = householdData.ContainsKey(item.FormId) ? householdData[item.FormId] : 0;
                item.TotalBenificiaryPopulation = population.ContainsKey(item.FormId) ? population[item.FormId] : 0;
                result.Add(item);
            }


            return PartialView("~/Views/Wqs/Form1B/GetForm1B.cshtml", result);
        }

        public PartialViewResult F2Data(string munCode)
        {
            ViewData["munCode"] = munCode;

            var data = _wqsservices.GetFormId(munCode);
            var address = _wqsservices.GetAddress(munCode);
            var householdData = _wqsservices.GetHH(munCode);
            var population = _wqsservices.GetPop(munCode);
            var f2Data = _wqsContext.Form2s
               .Where(p => data.Keys.Contains(p.FormId))
               .ToList();
            List<Form2Dto> result = new List<Form2Dto>();

            foreach (var val in f2Data)
            {
                Form2Dto item = _mapper.Map<Form2Dto>(val);
                item.ProCode = (data[item.FormId]);
                item.Address = (address[item.FormId]);
                item.TotalHhServed = householdData.ContainsKey(item.FormId) ? householdData[item.FormId] : 0;
                item.TotalBenificiaryPopulation = population.ContainsKey(item.FormId) ? population[item.FormId] : 0;
                result.Add(item);
            }


            return PartialView("~/Views/Wqs/Form2/GetForm2.cshtml", result);;
        }

        public PartialViewResult F3Data(string munCode)
        {
            ViewData["munCode"] = munCode;

            var data = _wqsservices.GetFormId(munCode);
            var address = _wqsservices.GetAddress(munCode);
            var householdData = _wqsservices.GetHH(munCode);
            var population = _wqsservices.GetPop(munCode);
            var f3Data = _wqsContext.Form3s
               .Where(p => data.Keys.Contains(p.FormId))
               .ToList();
            List<Form3Dto> result = new List<Form3Dto>();

            foreach (var val in f3Data)
            {
                Form3Dto item = _mapper.Map<Form3Dto>(val);
                item.ProCode = (data[item.FormId]);
                item.Address = (address[item.FormId]);
                item.TotalHhServed = householdData.ContainsKey(item.FormId) ? householdData[item.FormId] : 0;
                item.TotalBenificiaryPopulation = population.ContainsKey(item.FormId) ? population[item.FormId] : 0;
                result.Add(item);
            }



            return PartialView("~/Views/Wqs/Form3/GetForm3.cshtml", result);
        }

  
        public PartialViewResult ReservoirSan(string munCode)
        {
            ViewData["munCode"] = munCode;

            var data = _wqsservices.GetFormId(munCode);
            var address = _wqsservices.GetAddress(munCode);
            var householdData = _wqsservices.GetHH(munCode);
            var population = _wqsservices.GetPop(munCode);
            var ResData = _wqsContext.ReservoirSanitaries
               .Where(p => data.Keys.Contains(p.FormId))
               .ToList();
            List<FormResDto> result = new List<FormResDto>();

            foreach (var val in ResData)
            {
                FormResDto item = _mapper.Map<FormResDto>(val);
                item.ProCode =(data[item.FormId]);
                item.Address = (address[item.FormId]);
                item.TotalHhServed = householdData.ContainsKey(item.FormId) ? householdData[item.FormId] : 0;
                item.TotalBenificiaryPopulation = population.ContainsKey(item.FormId) ? population[item.FormId] : 0;
                result.Add(item);
            }


            return PartialView("~/Views/Wqs/Reservoir_Sanitary/GetFormRes.cshtml", result); ;
        }
         public PartialViewResult SourceSan(string munCode)
        {
            ViewData["munCode"] = munCode;

            var data = _wqsservices.GetFormId(munCode);
            var address = _wqsservices.GetAddress(munCode);
            var householdData = _wqsservices.GetHH(munCode);
            var population = _wqsservices.GetPop(munCode);
            var ResData = _wqsContext.SourceSanitaries
               .Where(p => data.Keys.Contains(p.FormId))
               .ToList();
            List<FormSouDto> result = new List<FormSouDto>();

            foreach (var val in ResData)
            {
                FormSouDto item = _mapper.Map<FormSouDto>(val);
                item.ProCode = (data[item.FormId]);
                item.Address = (address[item.FormId]);
                item.TotalHhServed = householdData.ContainsKey(item.FormId) ? householdData[item.FormId] : 0;
                item.TotalBenificiaryPopulation = population.ContainsKey(item.FormId) ? population[item.FormId] : 0;
                result.Add(item);
            }

            return PartialView("~/Views/Wqs/Source_Sanitary/GetFormSou.cshtml", result);
        }
         public PartialViewResult StructureSan(string munCode)
        {
            ViewData["munCode"] = munCode;

            var data = _wqsservices.GetFormId(munCode);
            var address = _wqsservices.GetAddress(munCode);
            var householdData = _wqsservices.GetHH(munCode);
            var population = _wqsservices.GetPop(munCode);
            var ResData = _wqsContext.StructureSanitaries
               .Where(p => data.Keys.Contains(p.FormId))
               .ToList();
            List<FormStrDto> result = new List<FormStrDto>();

            foreach (var val in ResData)
            {
                FormStrDto item = _mapper.Map<FormStrDto>(val);
                item.ProCode =(data[item.FormId]);
                item.Address = (address[item.FormId]);
                item.TotalHhServed = householdData.ContainsKey(item.FormId) ? householdData[item.FormId] : 0;
                item.TotalBenificiaryPopulation = population.ContainsKey(item.FormId) ? population[item.FormId] : 0;
                result.Add(item);
            }

            return PartialView("~/Views/Wqs/Structure_Sanitary/GetFormStr.cshtml", result);
        }
         public PartialViewResult TapSan(string munCode)
        {
            ViewData["munCode"] = munCode;

            var data = _wqsservices.GetFormId(munCode);
            var address = _wqsservices.GetAddress(munCode);
            var householdData = _wqsservices.GetHH(munCode);
            var population = _wqsservices.GetPop(munCode);
            var ResData = _wqsContext.TapSanitaries
               .Where(p => data.Keys.Contains(p.FormId))
               .ToList();
            List<FormTapDto> result = new List<FormTapDto>();

            foreach (var val in ResData)
            {
                FormTapDto item = _mapper.Map<FormTapDto>(val);
                item.ProCode = (data[item.FormId]);
                item.Address = (address[item.FormId]);
                item.TotalHhServed = householdData.ContainsKey(item.FormId) ? householdData[item.FormId] : 0;
                item.TotalBenificiaryPopulation = population.ContainsKey(item.FormId) ? population[item.FormId] : 0;
                result.Add(item);
            }

            return PartialView("~/Views/Wqs/Tap_Sanitary/GetFormTap.cshtml", result);
        }
      

      
        public IActionResult FormViewA(string encode)
        {
            // Decode the base64 encoded FormId
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            // Get the Form1a data based on the decoded FormId
            var hhData = _wqsContext.Form1as
                              .Where(s => (s.FormId == uuid))
                              .FirstOrDefault();

            // If no data is found, handle the case gracefully
            if (hhData == null)
            {
                return NotFound(); // or return an error view
            }

            // Map the data to the DTO (Form1ADto) and add ProCode and Address
            var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address
            //var data = GetFormId(uuid); // Assuming GetFormId is a method that provides ProCode
            var formData = _mapper.Map<Form1ADto>(hhData);


            formData.ProName = _wqsservices.GetName(data.ProjectName);
            formData.ProCode = (data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;

            return View("~/Views/Wqs/Form1A/1AView.cshtml", formData);
        }

        public IActionResult FormViewB(string encode)
        {
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);
            var hhData = _wqsContext.Form1bs
                            .Where(s => (s.FormId == uuid))
                            .FirstOrDefault();

            //ViewData["AddedBy"] = _wqsContext.Users.Where(s => s.Email == hhData.AddBy).Select(s => s.Name).SingleOrDefault();
            var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address
            var formData = _mapper.Map<Form1BDto>(hhData);


            formData.ProName = _wqsservices.GetName(data.ProjectName);
            formData.ProCode = (data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;

            return View("~/Views/Wqs/Form1B/1BView.cshtml", formData);
        }
        public IActionResult FormView2(string encode)
        {
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);
            var hhData = _wqsContext.Form2s
                            .Where(s => (s.FormId == uuid))
                            .FirstOrDefault();

            //ViewData["AddedBy"] = _wqsContext.Users.Where(s => s.Email == hhData.AddBy).Select(s => s.Name).SingleOrDefault();
            var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address
            //var data = GetFormId(uuid); // Assuming GetFormId is a method that provides ProCode
            var formData = _mapper.Map<Form2Dto>(hhData);


            formData.ProName = _wqsservices.GetName(data.ProjectName);
            formData.ProCode =(data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;

            return View("~/Views/Wqs/Form2/2View.cshtml", formData);
        }
        public IActionResult FormView3(string encode)
        {
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            // Fetch multiple Form3 records based on some filter (adjust as needed)
            var hhDataList = _wqsContext.Form3s
                               .Where(s => s.FormId == uuid) // Adjust the filter logic as per your requirement
                               .ToList();

            // Map each Form3 entity to Form3Dto and enrich with additional data
            var formDataList = hhDataList.Select(hhData =>
            {
                var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));
                var formData = _mapper.Map<Form3Dto>(hhData);
                formData.ProName = _wqsservices.GetName(data.ProjectName);
                formData.ProCode = data != null ? (data.ProjectName) : string.Empty;
                formData.Address = data?.Address;
                var res = _wqsservices.GetPopandHH(formData.ProCode);
                formData.TotalPop = data.TotalBenificiaryPopulation;

                formData.TotalHhServed = data.TotalHhServed;


                return formData;
            }).ToList();

            // Pass the list of Form3Dto to the view
            return View("Form3/3View", formDataList);
        }

        public IActionResult FormViewRes(string encode)
        {
            // Decode the base64 encoded FormId
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            // Get all Form1a data with the matching FormId
            var hhDataList = _wqsContext.ReservoirSanitaries
                                  .Where(s => s.FormId == uuid)
                                  .ToList();

            // If no data is found, handle the case gracefully
            if (!hhDataList.Any())
            {
                return NotFound(); // or return an error view
            }

            // Create a list to hold the mapped DTOs
            var formDataList = new List<FormResDto>();

            foreach (var hhData in hhDataList)
            {
                // Get the corresponding WqSurveillanceMain data
                var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));

                // If data is found, map and populate the DTO
                if (data != null)
                {
                    var formData = _mapper.Map<FormResDto>(hhData);

                    formData.ProName = _wqsservices.GetName(data.ProjectName);
                    formData.ProCode = data.ProjectName;
                    formData.Address = data.Address;

                    var res = _wqsservices.GetPopandHH(formData.ProCode);
                    formData.TotalPop = data.TotalBenificiaryPopulation;
                    formData.TotalHhServed = data.TotalHhServed;

                    formDataList.Add(formData);
                }
            }

            // Pass the list of form data to the view
            return View("~/Views/Wqs/Reservoir_Sanitary/ResView.cshtml", formDataList);
        }

        public IActionResult FormViewSou(string encode)
        {
            // Decode the base64 encoded FormId
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            // Get all SourceSanitaries data with the matching FormId
            var hhDataList = _wqsContext.SourceSanitaries
                                  .Where(s => s.FormId == uuid)
                                  .ToList();

            // If no data is found, handle the case gracefully
            if (!hhDataList.Any())
            {
                return NotFound(); // or return an error view
            }

            // Create a list to hold the mapped DTOs
            var formDataList = new List<FormSouDto>();

            foreach (var hhData in hhDataList)
            {
                // Get the corresponding WqSurveillanceMain data
                var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));

                // If data is found, map and populate the DTO
                if (data != null)
                {
                    var formData = _mapper.Map<FormSouDto>(hhData);

                    formData.ProCode = data.ProjectName;
                    formData.Address = data.Address;
                    formData.ProName = _wqsservices.GetName(data.ProjectName);

                    var res = _wqsservices.GetPopandHH(formData.ProCode);
                    formData.TotalPop = data.TotalBenificiaryPopulation;
                    formData.TotalHhServed = data.TotalHhServed;

                    formDataList.Add(formData);
                }
            }

            // Pass the list of form data to the view
            return View("~/Views/Wqs/Source_Sanitary/SouView.cshtml", formDataList);
        }

        public IActionResult FormViewStr(string encode)
        {
            // Decode the base64 encoded FormId
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            // Get all StructureSanitaries data with the matching FormId
            var hhDataList = _wqsContext.StructureSanitaries
                                .Where(s => s.FormId == uuid)
                                .ToList();

            // If no data is found, handle the case gracefully
            if (!hhDataList.Any())
            {
                return NotFound(); // or return an error view
            }

            // Create a list to hold the mapped DTOs
            var formDataList = new List<FormStrDto>();

            foreach (var hhData in hhDataList)
            {
                // Get the corresponding WqSurveillanceMain data
                var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));

                // If data is found, map and populate the DTO
                if (data != null)
                {
                    var formData = _mapper.Map<FormStrDto>(hhData);

                    formData.ProCode = data.ProjectName;
                    formData.Address = data.Address;
                    formData.ProName = _wqsservices.GetName(data.ProjectName);

                    var res = _wqsservices.GetPopandHH(formData.ProCode);
                    formData.TotalPop = data.TotalBenificiaryPopulation;
                    formData.TotalHhServed = data.TotalHhServed;

                    formDataList.Add(formData);
                }
            }

            // Pass the list of form data to the view
            return View("~/Views/Wqs/Structure_Sanitary/StrView.cshtml", formDataList);
        }
        public IActionResult FormViewTap(string encode)
        {
            // Decode the base64 encoded FormId
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            // Get all TapSanitaries data with the matching FormId
            var hhDataList = _wqsContext.TapSanitaries
                                .Where(s => s.FormId == uuid)
                                .ToList();

            // If no data is found, handle the case gracefully
            if (!hhDataList.Any())
            {
                return NotFound(); // or return an error view
            }

            // Create a list to hold the mapped DTOs
            var formDataList = new List<FormTapDto>();

            foreach (var hhData in hhDataList)
            {
                // Get the corresponding WqSurveillanceMain data
                var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));

                // If data is found, map and populate the DTO
                if (data != null)
                {
                    var formData = _mapper.Map<FormTapDto>(hhData);

                    formData.ProCode = data.ProjectName;
                    formData.Address = data.Address;
                    formData.ProName = _wqsservices.GetName(data.ProjectName);

                    var res = _wqsservices.GetPopandHH(formData.ProCode);
                    formData.TotalPop = data.TotalBenificiaryPopulation;
                    formData.TotalHhServed = data.TotalHhServed;

                    formDataList.Add(formData);
                }
            }

            // Pass the list of form data to the view
            return View("~/Views/Wqs/Tap_Sanitary/TapView.cshtml", formDataList);
        }

        public IActionResult SanView(string encode)
        {
            // Decode the base64 encoded FormId
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            // Retrieve Main Data (common for all forms)
            var resMainData = _wqsContext.WqSurveillanceMains
                              .FirstOrDefault(p => p.Uuid.Equals(uuid));

            if (resMainData == null)
            {
                return NotFound(); // Return 404 if the main data is not found
            }

            // Initialize the combined data model
            var combinedData = new FormCombinedDto
            {
                WqData = _mapper.Map<WQDto>(resMainData), // Populate the common data
                ReservoirSanitationData = new List<FormResDto>(), // Initialize as empty list
                SourceSanitationData = new List<FormSouDto>(), // Initialize as empty list
                StructureSanitationData = new List<FormStrDto>(), // Initialize as empty list
                TapSanitationData = new List<FormTapDto>() // Initialize as empty list
            };
            combinedData.WqData.ProName = _wqsservices.GetName(resMainData.ProjectName);

            // Retrieve Reservoir Sanitation Data
            var hhData = _wqsContext.ReservoirSanitaries
                         .Where(s => s.FormId == uuid)
                         .ToList(); // Retrieve all matching records
            if (hhData != null && hhData.Any())
            {
                combinedData.ReservoirSanitationData = _mapper.Map<List<FormResDto>>(hhData);
            }

            // Retrieve Source Sanitation Data
            var sourceData = _wqsContext.SourceSanitaries
                             .Where(s => s.FormId == uuid)
                             .ToList(); // Retrieve all matching records
            if (sourceData != null && sourceData.Any())
            {
                combinedData.SourceSanitationData = _mapper.Map<List<FormSouDto>>(sourceData);
            }

            // Retrieve Structure Sanitation Data
            var StructureData = _wqsContext.StructureSanitaries
                                .Where(s => s.FormId == uuid)
                                .ToList(); // Retrieve all matching records
            if (StructureData != null && StructureData.Any())
            {
                combinedData.StructureSanitationData = _mapper.Map<List<FormStrDto>>(StructureData);
            }

            // Retrieve Tap Sanitation Data
            var TapData = _wqsContext.TapSanitaries
                          .Where(s => s.FormId == uuid)
                          .ToList(); // Retrieve all matching records
            if (TapData != null && TapData.Any())
            {
                combinedData.TapSanitationData = _mapper.Map<List<FormTapDto>>(TapData);
            }

            return View("~/Views/Wqs/Sanitary_Inspection/SanitaryView.cshtml", combinedData);
        }
        public IActionResult Form1AEdit(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var FormId = Encoding.UTF8.GetString(base64EncodedBytes);

            var hhData = _wqsContext.Form1as
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            //ViewData["AddedBy"] = _wqsContext.Users.Where(s => s.Email == hhDataList.AddBy).Select(s => s.Name).SingleOrDefault();
            var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address
            //var data = GetFormId(uuid); // Assuming GetFormId is a method that provides ProCode
            var formData = _mapper.Map<Form1ADto>(hhData);



            formData.ProCode = (data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;

        
            return View("Form1A/F1AEdit", formData);
        }
         public IActionResult Form1BEdit(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var FormId = Encoding.UTF8.GetString(base64EncodedBytes);

            var hhData = _wqsContext.Form1bs
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address
            //var data = GetFormId(uuid); // Assuming GetFormId is a method that provides ProCode
            var formData = _mapper.Map<Form1BDto>(hhData);



            formData.ProCode = (data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;

            return View("Form1B/F1BEdit", formData);
        }
         public IActionResult Form2Edit(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var FormId = Encoding.UTF8.GetString(base64EncodedBytes);

            var hhData = _wqsContext.Form2s
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            var formData = _mapper.Map<Form2Dto>(hhData);

            var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address


            formData.ProCode = (data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;
            return View("Form2/F2Edit", formData);
        }
        public IActionResult Form3Edit(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var FormId = Encoding.UTF8.GetString(base64EncodedBytes);

            // Fetch multiple Form3 records based on the FormId
            var hhDataList = _wqsContext.Form3s
                                .Where(s => s.FormId == FormId) // Adjust the filter logic as per your requirement
                                .ToList();

            // Map each Form3 entity to Form3Dto and enrich with additional data


            Form3EditDto formData = new()
            {
                UpdateData = new(),
                Data = new()
            };


            var formDataList = hhDataList.Select(hhData =>
            {
                var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));
                
                
                var dt = _mapper.Map<Form3Dto>(hhData);
                dt.ProCode = data != null ? (data.ProjectName) : string.Empty;
                dt.Address = data?.Address;
                var res = _wqsservices.GetPopandHH(dt.ProCode);
                dt.TotalPop = data.TotalBenificiaryPopulation;

                dt.TotalHhServed = data.TotalHhServed;
                formData.Data.Add(dt);
                formData.UpdateData.FormId = hhData.FormId;

                return formData;
            }).ToList();

            // Pass the list of Form3Dto to the view
            return View("Form3/F3Edit", formData);
        }
        public IActionResult FormResEdit(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var FormId = Encoding.UTF8.GetString(base64EncodedBytes);

            var hhData = _wqsContext.ReservoirSanitaries
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            //ViewData["AddedBy"] = _wqsContext.Users.Where(s => s.Email == hhDataList.AddBy).Select(s => s.Name).SingleOrDefault();
            var formData = _mapper.Map<FormResDto>(hhData);

            var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address


            formData.ProCode = (data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;


            return View("Reservoir_Sanitary/ResEdit", formData);
        }
         public IActionResult FormSouEdit(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var FormId = Encoding.UTF8.GetString(base64EncodedBytes);

            var hhData = _wqsContext.SourceSanitaries
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            //ViewData["AddedBy"] = _wqsContext.Users.Where(s => s.Email == hhDataList.AddBy).Select(s => s.Name).SingleOrDefault();
            var formData = _mapper.Map<FormSouDto>(hhData);

            var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address


            formData.ProCode = (data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;


            return View("Source_Sanitary/SouEdit", formData);
        }
         public IActionResult FormStrEdit(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var FormId = Encoding.UTF8.GetString(base64EncodedBytes);

            var hhData = _wqsContext.StructureSanitaries
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            //ViewData["AddedBy"] = _wqsContext.Users.Where(s => s.Email == hhDataList.AddBy).Select(s => s.Name).SingleOrDefault();
            var formData = _mapper.Map<FormStrDto>(hhData);

            var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address


            formData.ProCode =(data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;

            return View("Structure_Sanitary/StrEdit", formData);
        }
         public IActionResult FormTapEdit(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var FormId = Encoding.UTF8.GetString(base64EncodedBytes);

            var hhData = _wqsContext.TapSanitaries
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            //ViewData["AddedBy"] = _wqsContext.Users.Where(s => s.Email == hhDataList.AddBy).Select(s => s.Name).SingleOrDefault();
            var formData = _mapper.Map<FormTapDto>(hhData);

            var data = _wqsContext.WqSurveillanceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address


            formData.ProCode =(data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;


            return View("Tap_Sanitary/TapEdit", formData);
        }

        public PartialViewResult SanEdit(string encode)
        {
            // Decode the base64 encoded FormId
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);
            ViewData["uuid"] = uuid;

            // Initialize the combined data model
            var combinedData = new FormCombinedDto
            {
                ReservoirSanitationData = new List<FormResDto>(), 
                SourceSanitationData = new List<FormSouDto>(),    
                StructureSanitationData = new List<FormStrDto>(), 
                TapSanitationData = new List<FormTapDto>()        
            };

            // Retrieve Main Data (common for all forms)
            var resMainData = _wqsContext.WqSurveillanceMains
                              .FirstOrDefault(p => p.Uuid.Equals(uuid));

            if (resMainData == null)
            {
                // Handle the case where main data is not found
                return PartialView("~/Views/Wqs/Sanitary_Inspection/SanEdit.cshtml", combinedData);
            }

            // Retrieve Reservoir Sanitation Data
            var hhData = _wqsContext.ReservoirSanitaries
                         .Where(s => s.FormId == uuid)
                         .ToList(); // Retrieve all matching records
            if (hhData != null && hhData.Any())
            {
                combinedData.ReservoirSanitationData = _mapper.Map<List<FormResDto>>(hhData);
            }

            // Retrieve Source Sanitation Data
            var sourceData = _wqsContext.SourceSanitaries
                             .Where(s => s.FormId == uuid)
                             .ToList(); // Retrieve all matching records
            if (sourceData != null && sourceData.Any())
            {
                combinedData.SourceSanitationData = _mapper.Map<List<FormSouDto>>(sourceData);
            }

            // Retrieve Structure Sanitation Data
            var StructureData = _wqsContext.StructureSanitaries
                                .Where(s => s.FormId == uuid)
                                .ToList(); // Retrieve all matching records
            if (StructureData != null && StructureData.Any())
            {
                combinedData.StructureSanitationData = _mapper.Map<List<FormStrDto>>(StructureData);
            }

            // Retrieve Tap Sanitation Data
            var TapData = _wqsContext.TapSanitaries
                          .Where(s => s.FormId == uuid)
                          .ToList(); // Retrieve all matching records
            if (TapData != null && TapData.Any())
            {
                combinedData.TapSanitationData = _mapper.Map<List<FormTapDto>>(TapData);
            }

            return PartialView("~/Views/Wqs/Sanitary_Inspection/SanEdit.cshtml", combinedData);
        }
        public PartialViewResult ShowData(string valueis, string uuid)
        {
            ViewData["uuid"] = uuid;

            if (valueis == "tap")
            {
                var Tap = _wqsContext.TapSanitaries
                            .Where(s => s.FormId == uuid)
                            .ToList();
                if (Tap == null)
                {
                    // Return a partial view with a message for empty Tap form
                    return PartialView("~/Views/Wqs/Sanitary_Inspection/_EmptyForm.cshtml", "Tap form data is not available.");
                }
                return PartialView("~/Views/Wqs/Sanitary_Inspection/_tapedit.cshtml", Tap);
            }
            else if (valueis == "reservoir")
            {
                var Reservoir = _wqsContext.ReservoirSanitaries
                            .Where(s => s.FormId == uuid)
                            .ToList();
                if (Reservoir == null)
                {
                    // Return a partial view with a message for empty Reservoir form
                    return PartialView("~/Views/Wqs/Sanitary_Inspection/_EmptyForm.cshtml", "Reservoir form data is not available.");
                }
                return PartialView("~/Views/Wqs/Sanitary_Inspection/_resedit.cshtml", Reservoir);
            }
            else if (valueis == "source")
            {
                var Source = _wqsContext.SourceSanitaries
                            .Where(s => s.FormId == uuid)
                            .ToList();
                if (Source == null)
                {
                    // Return a partial view with a message for empty Source form
                    return PartialView("~/Views/Wqs/Sanitary_Inspection/_EmptyForm.cshtml", "Source form data is not available.");
                }
                return PartialView("~/Views/Wqs/Sanitary_Inspection/_souedit.cshtml", Source);
            }
            else if (valueis == "structure")
            {
                var Structure = _wqsContext.StructureSanitaries
                            .Where(s => s.FormId == uuid)
                            .ToList();
                if (Structure == null)
                {
                    // Return a partial view with a message for empty Structure form
                    return PartialView("~/Views/Wqs/Sanitary_Inspection/_EmptyForm.cshtml", "Structure form data is not available.");
                }
                return PartialView("~/Views/Wqs/Sanitary_Inspection/_stredit.cshtml", Structure);
            }
            else
            {
                // Default view if valueis is invalid
                return PartialView("~/Views/Wqs/show.cshtml");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormAEditPost(Form1a WData)
        {
            var username = User.Identity.Name;

            var updateData = _wqsservices.UpdateWQSDataFA(WData,  username);
            string formid = WData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("Form1AEdit", "Wqs", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("Form1AEdit", "Wqs", new { @id = encodedUUID });
            }
        }
         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormBEditPost(Form1b WData)
        {
            var username = User.Identity.Name;
            var updateData = _wqsservices.UpdateWQSDataFB(WData, username);
            string formid = WData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("Form1BEdit", "Wqs", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("Form1BEdit", "Wqs", new { @id = encodedUUID });
            }
        }
           [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form2EditPost(Form2 WData)
        {
            var username = User.Identity.Name;

            var updateData = _wqsservices.UpdateWQSDataF2(WData, username);

            string formid = WData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("Form2Edit", "Wqs", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("Form2Edit", "Wqs", new { @id = encodedUUID });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form3EditPost(Form3EditDto WData)
        {
            var username = User.Identity.Name;

            var fId = _wqsservices.UpdateWQSDataF3(WData.UpdateData, username);

            string formid = fId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (fId != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("Form3Edit", "Wqs", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("Form3Edit", "Wqs", new { @id = encodedUUID });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormSanResEditPost(ReservoirSanitary WData)
        {
            if (WData == null)
            {
                return Json(new { success = false, message = "Invalid data submitted." });
            }

            var username = User.Identity.Name;
            var updateData = _wqsservices.UpdateWQSDataRes(WData, username);

            if (updateData != null)
            {
                return Json(new { success = true, message = "Data Updated Successfully" });
            }
            else
            {
                return Json(new { success = false, message = "Something Went Wrong. Please try again later." });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormSanSouEditPost(SourceSanitary WData)
        {
            if (WData == null)
            {
                return Json(new { success = false, message = "Invalid data submitted." });
            }

            var username = User.Identity.Name;
            var updateData = _wqsservices.UpdateWQSDataSou(WData, username);

            if (updateData != null)
            {
                return Json(new { success = true, message = "Data Updated Successfully" });
            }
            else
            {
                return Json(new { success = false, message = "Something Went Wrong. Please try again later." });
            }
        }
          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormSanStrEditPost(StructureSanitary WData)
        {
            if (WData == null)
            {
                return Json(new { success = false, message = "Invalid data submitted." });
            }

            var username = User.Identity.Name;
            var updateData = _wqsservices.UpdateWQSDataStr(WData, username);

            if (updateData != null)
            {
                return Json(new { success = true, message = "Data Updated Successfully" });
            }
            else
            {
                return Json(new { success = false, message = "Something Went Wrong. Please try again later." });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormSanTapEditPost(TapSanitary WData)
        {
            if (WData == null)
            {
                return Json(new { success = false, message = "Invalid data submitted." });
            }

            var username = User.Identity.Name;
            var updateData = _wqsservices.UpdateWQSDataTap(WData, username);

            if (updateData != null)
            {
                return Json(new { success = true, message = "Data Updated Successfully" });
            }
            else
            {
                return Json(new { success = false, message = "Something Went Wrong. Please try again later." });
            }
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormResEditPost(ReservoirSanitary WData)
        {
            var username = User.Identity.Name;

            var updateData = _wqsservices.UpdateWQSDataRes(WData, username);

            string formid = WData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("FormResEdit", "Wqs", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("FormResEdit", "Wqs", new { @id = encodedUUID });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormSouEditPost(SourceSanitary WData)
        {
            var username = User.Identity.Name;

            var updateData = _wqsservices.UpdateWQSDataSou(WData, username);

            string formid = WData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("FormSouEdit", "Wqs", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("FormSouEdit", "Wqs", new { @id = encodedUUID });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormStrEditPost(StructureSanitary WData)
        {
            var username = User.Identity.Name;

            var updateData = _wqsservices.UpdateWQSDataStr(WData, username);

            string formid = WData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("FormStrEdit", "Wqs", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("FormStrEdit", "Wqs", new { @id = encodedUUID });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormTapEditPost(TapSanitary WData)
        {
            var username = User.Identity.Name;

            var updateData = _wqsservices.UpdateWQSDataTap(WData,  username);

            string formid = WData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("FormTapEdit", "Wqs", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("FormTapEdit", "Wqs", new { @id = encodedUUID });
            }
        }


        [HttpPost]
        public int DeleteDataFA(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            var delData = _wqsservices.DeleteFA(uuid);
            return delData;
        }
        [HttpPost]
        public int DeleteDataFB(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            var delData = _wqsservices.DeleteFB(uuid);
            return delData;
        }
        [HttpPost]
        public int DeleteData2(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            var delData = _wqsservices.Delete2(uuid);
            return delData;
        }
        [HttpPost]
        public int DeleteData3(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            var delData = _wqsservices.Delete3(uuid);
            return delData;
        }
        [HttpPost]
        public int DeleteDataRes(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            var delData = _wqsservices.DeleteRes(uuid);
            return delData;
        }
        [HttpPost]
        public int DeleteDataSou(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            var delData = _wqsservices.DeleteSou(uuid);
            return delData;
        }
        [HttpPost]
        public int DeleteDataStr(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            var delData = _wqsservices.DeleteStr(uuid);
            return delData;
        }
        [HttpPost]
        public int DeleteDataTap(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            var delData = _wqsservices.DeleteTap(uuid);
            return delData;
        }

     



        public ActionResult ExportForm1aToExcel(string MunCode)
        {
            string[] pgsQuerys;
            List<DataTable> dts = new List<DataTable>();
            List<string> tbls = new List<string>();
            if (MunCode != "")
            {
                tbls = new List<string>()
        {
            "Form 1a"
        };

                // Join the necessary tables with 'form1_a' based on the 'MunCode' or 'FormId'
                pgsQuerys = new string[1]
   {
    $@"
    SELECT 
        ROW_NUMBER() OVER(ORDER BY f.id) AS SN, 
        wm.province AS Province, 
        wm.district AS District, 
        wm.municipality AS Municipality, 
        f.added_by AS AddedBy,
        f.added_on AS AddedOn,
        f.edited_by AS EditedBy,
        f.edited_on AS EditedOn,
        f.wsp_initiative_status_1 AS WspInitiativeStatus1,
        f.wsp_initiative_remarks_1 AS WspInitiativeRemarks1,
        f.wsp_initiative_status_2 AS WspInitiativeStatus2,
        f.wsp_initiative_remarks_2 AS WspInitiativeRemarks2,
        f.wsp_initiative_status_3 AS WspInitiativeStatus3,
        f.wsp_initiative_remarks_3 AS WspInitiativeRemarks3,
        f.wsp_initiative_status_4 AS WspInitiativeStatus4,
        f.wsp_initiative_remarks_4 AS WspInitiativeRemarks4,
        f.wsp_initiative_status_5 AS WspInitiativeStatus5,
        f.wsp_initiative_remarks_5 AS WspInitiativeRemarks5,
        f.wsp_initiative_status_6 AS WspInitiativeStatus6,
        f.wsp_initiative_remarks_6 AS WspInitiativeRemarks6,
        f.wsp_initiative_status_7 AS WspInitiativeStatus7,
        f.wsp_initiative_remarks_7 AS WspInitiativeRemarks7,
        f.wsp_initiative_security_plan AS WspInitiativeSecurityPlan,
        f.wsp_initiative_water_quality_status AS WspInitiativeWaterQualityStatus,
        f.wsp_initiative_infected_by_diarrhea AS WspInitiativeInfectedByDiarrhea,
        f.wsp_initiative_died_by_diarrhea AS WspInitiativeDiedByDiarrhea,
        f.wsp_initiative_water_disease AS WspInitiativeWaterDisease,
        f.wsp_initiative_notice_source AS WspInitiativeNoticeSource,
        f.wsp_initiative_written_result AS WspInitiativeWrittenResult,
        f.wsp_initiative_suggestion AS WspInitiativeSuggestion
    FROM 
        wqs.form_1a f
    LEFT JOIN 
        wqs.wq_Surveillance_main wm 
    ON 
        f.form_id = wm.uuid
    WHERE 
        SPLIT_PART(wm.municipality, ' - ', 1) = '{MunCode}'
    ORDER BY 
        f.id;"
   };





            }
            else
            {
                pgsQuerys = new string[1] { "SELECT" };
            }

            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = MunCode + "_form1a_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
            string pathDownload = Path.Combine(_hostEnvironment.WebRootPath, "TEMP");

            if (!Directory.Exists(pathDownload))
            {
                Directory.CreateDirectory(pathDownload);
            }

            using var workbook = new XLWorkbook();
            workbook.Properties.Company = "WQS";

            for (int item = 1; item <= tbls.Count; item++)  // or do pgsQuerys.Count
            {
                DataTable dt = new DataTable();
                DbConnection connection = _wqsContext.Database.GetDbConnection();
                DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);

                using (var cmd = dbFactory.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = pgsQuerys[item - 1];

                    using DbDataAdapter adapter = dbFactory.CreateDataAdapter();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }

                IXLWorksheet worksheet = workbook.Worksheets.Add(tbls[item - 1]);
                IXLCell xcl;
                int row = 1;

                // Adding headers to Excel
                for (int i = 1; i <= dt.Columns.Count; i++)
                {
                    xcl = worksheet.Cell(1, i);
                    xcl.Value = dt.Columns[i - 1].ToString();
                    xcl.Style.Font.Bold = true;
                    xcl.Style.Font.Italic = false;
                    xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    xcl.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    xcl.Style.Fill.BackgroundColor = XLColor.Aqua;
                }
                row++;

                // Adding data rows to Excel
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 1; i <= dt.Columns.Count; i++)
                    {
                        xcl = worksheet.Cell(row, i);
                        decimal itemVal;
                        DateTime dateText;

                        if (Decimal.TryParse(dr[i - 1].ToString(), out itemVal))
                        {
                            xcl.Value = itemVal;
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        else if (DateTime.TryParse(dr[i - 1].ToString(), out dateText))
                        {
                            xcl.Value = $"'{dr[i - 1].ToString().Split(" ")[0]}";
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }
                        else
                        {
                            xcl.Value = $"{dr[i - 1]}";
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }

                        xcl.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    }
                    row++;
                }

                // Adjusting column width to fit content
                worksheet.Columns().AdjustToContents();
            }

            // Save and return the file
            using var stream = new MemoryStream();
            var content = stream.ToArray();
            string actualFilePath = pathDownload + "\\" + fileName;
            workbook.SaveAs(actualFilePath);
            workbook.Dispose();
            byte[] fileBytes = System.IO.File.ReadAllBytes(actualFilePath);
            System.IO.File.Delete(actualFilePath);

            return File(fileBytes, contentType, fileName);
        } 
        
        
        public ActionResult ExportForm1bToExcel(string MunCode)
        {
            string[] pgsQuerys;
            List<DataTable> dts = new List<DataTable>();
            List<string> tbls = new List<string>();
            if (MunCode != "")
            {
                tbls = new List<string>()
        {
            "Form 1b"
        };

                // Join the necessary tables with 'form1_a' based on the 'MunCode' or 'FormId'
                pgsQuerys = new string[1]
   {
    $@"
    SELECT 
        ROW_NUMBER() OVER(ORDER BY f.id) AS SN, 
        wm.province AS Province, 
        wm.district AS District, 
        wm.municipality AS Municipality, 
        f.""added_by"" AS AddedBy,
        f.""added_on"" AS AddedOn,
        f.""edited_by"" AS EditedBy,
        f.""edited_on"" AS EditedOn,
        f.""certification_photo"" AS CertificationPhoto,
        f.""certification_score"" AS CertificationScore,
        f.""collaborative_activitiesPhoto"" AS CollaborativeActivitiesPhoto,
        f.""collaborative_activitiesScore"" AS CollaborativeActivitiesScore,
        f.""improvement_plan_photo"" AS ImprovementPlanPhoto,
        f.""improvement_plan_score"" AS ImprovementPlanScore,
        f.""monitoring_photo"" AS MonitoringPhoto,
        f.""monitoring_score"" AS MonitoringScore,
        f.""pollution_risk_control_measure_score"" AS PollutionRiskControlMeasureScore,
        f.""pollution_risk_control_photo"" AS PollutionRiskControlPhoto,
        f.""review_photo"" AS ReviewPhoto,
        f.""review_score"" AS ReviewScore,
        f.""system_analysis_photo"" AS SystemAnalysisPhoto,
        f.""system_analysis_score"" AS SystemAnalysisScore,
        f.""team_formation_photo"" AS TeamFormationPhoto,
        f.""team_formation_score"" AS TeamFormationScore,
        f.""total_score"" AS TotalScore
    FROM 
        wqs.""form_1b"" f
    LEFT JOIN 
        wqs.wq_Surveillance_main wm 
    ON 
        f.""form_id"" = wm.""uuid""
    WHERE 
        SPLIT_PART(wm.""municipality"", ' - ', 1) = '{MunCode}'
    ORDER BY 
        f.id;"
   };





            }
            else
            {
                pgsQuerys = new string[1] { "SELECT" };
            }

            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = MunCode + "_form1b_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
            string pathDownload = Path.Combine(_hostEnvironment.WebRootPath, "TEMP");

            if (!Directory.Exists(pathDownload))
            {
                Directory.CreateDirectory(pathDownload);
            }

            using var workbook = new XLWorkbook();
            workbook.Properties.Company = "WQS";

            for (int item = 1; item <= tbls.Count; item++)  // or do pgsQuerys.Count
            {
                DataTable dt = new DataTable();
                DbConnection connection = _wqsContext.Database.GetDbConnection();
                DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);

                using (var cmd = dbFactory.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = pgsQuerys[item - 1];

                    using DbDataAdapter adapter = dbFactory.CreateDataAdapter();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }

                IXLWorksheet worksheet = workbook.Worksheets.Add(tbls[item - 1]);
                IXLCell xcl;
                int row = 1;

                // Adding headers to Excel
                for (int i = 1; i <= dt.Columns.Count; i++)
                {
                    xcl = worksheet.Cell(1, i);
                    xcl.Value = dt.Columns[i - 1].ToString();
                    xcl.Style.Font.Bold = true;
                    xcl.Style.Font.Italic = false;
                    xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    xcl.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    xcl.Style.Fill.BackgroundColor = XLColor.Aqua;
                }
                row++;

                // Adding data rows to Excel
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 1; i <= dt.Columns.Count; i++)
                    {
                        xcl = worksheet.Cell(row, i);
                        decimal itemVal;
                        DateTime dateText;

                        if (Decimal.TryParse(dr[i - 1].ToString(), out itemVal))
                        {
                            xcl.Value = itemVal;
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        else if (DateTime.TryParse(dr[i - 1].ToString(), out dateText))
                        {
                            xcl.Value = $"'{dr[i - 1].ToString().Split(" ")[0]}";
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }
                        else
                        {
                            xcl.Value = $"{dr[i - 1]}";
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }

                        xcl.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    }
                    row++;
                }

                // Adjusting column width to fit content
                worksheet.Columns().AdjustToContents();
            }

            // Save and return the file
            using var stream = new MemoryStream();
            var content = stream.ToArray();
            string actualFilePath = pathDownload + "\\" + fileName;
            workbook.SaveAs(actualFilePath);
            workbook.Dispose();
            byte[] fileBytes = System.IO.File.ReadAllBytes(actualFilePath);
            System.IO.File.Delete(actualFilePath);

            return File(fileBytes, contentType, fileName);
        } 
        
        public ActionResult ExportForm2ToExcel(string MunCode)
        {
            string[] pgsQuerys;
            List<DataTable> dts = new List<DataTable>();
            List<string> tbls = new List<string>();
            if (MunCode != "")
            {
                tbls = new List<string>()
        {
            "Form 2"
        };

                // Join the necessary tables with 'form1_a' based on the 'MunCode' or 'FormId'
                pgsQuerys = new string[1]
 {
    $@"
    SELECT 
        ROW_NUMBER() OVER(ORDER BY f.id) AS SN, 
        wm.province AS Province, 
        wm.district AS District, 
        wm.municipality AS Municipality, 
        f.""added_by"" AS AddedBy,
        f.""added_on"" AS AddedOn,
        f.""edited_by"" AS EditedBy,
        f.""edited_on"" AS EditedOn,
        f.""def_died_by_diarrhea"" AS DefDiedByDiarrhea,
        f.""def_infected_by_diarrhea"" AS DefInfectedByDiarrhea,
        f.""def_notice_source"" AS DefNoticeSource,
        f.""def_suggestion"" AS DefSuggestion,
        f.""def_water_disease"" AS DefWaterDisease,
        f.""def_written_result"" AS DefWrittenResult,
        f.""pipeline_basic_evaluation"" AS PipelineBasicEvaluation,
        f.""pipeline_basic_evaluation_remarks"" AS PipelineBasicEvaluationRemarks,
        f.""pollution_possibility"" AS PollutionPossibility,
        f.""pollution_possibility_types"" AS PollutionPossibilityTypes,
        f.""source_basic_evaluation"" AS SourceBasicEvaluation,
        f.""source_basic_evaluation_remarks"" AS SourceBasicEvaluationRemarks,
        f.""storage_usage_basic_evaluation"" AS StorageUsageBasicEvaluation,
        f.""storage_usage_basic_evaluation_remarks"" AS StorageUsageBasicEvaluationRemarks,
        f.""treatment_center_basic_evaluation"" AS TreatmentCenterBasicEvaluation,
        f.""treatment_center_basic_evaluation_remarks"" AS TreatmentCenterBasicEvaluationRemarks,
        f.""water_reservoir_basic_evaluation"" AS WaterReservoirBasicEvaluation,
        f.""water_reservoir_basic_evaluation_remarks"" AS WaterReservoirBasicEvaluationRemarks
    FROM 
        wqs.""form_2"" f
    LEFT JOIN 
        wqs.wq_Surveillance_main wm 
    ON 
        f.""form_id"" = wm.""uuid""
    WHERE 
        SPLIT_PART(wm.""municipality"", ' - ', 1) = '{MunCode}'
    ORDER BY 
        f.id;"
 };




            }
            else
            {
                pgsQuerys = new string[1] { "SELECT" };
            }

            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = MunCode + "_form2_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
            string pathDownload = Path.Combine(_hostEnvironment.WebRootPath, "TEMP");

            if (!Directory.Exists(pathDownload))
            {
                Directory.CreateDirectory(pathDownload);
            }

            using var workbook = new XLWorkbook();
            workbook.Properties.Company = "WQS";

            for (int item = 1; item <= tbls.Count; item++)  // or do pgsQuerys.Count
            {
                DataTable dt = new DataTable();
                DbConnection connection = _wqsContext.Database.GetDbConnection();
                DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);

                using (var cmd = dbFactory.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = pgsQuerys[item - 1];

                    using DbDataAdapter adapter = dbFactory.CreateDataAdapter();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }

                IXLWorksheet worksheet = workbook.Worksheets.Add(tbls[item - 1]);
                IXLCell xcl;
                int row = 1;

                // Adding headers to Excel
                for (int i = 1; i <= dt.Columns.Count; i++)
                {
                    xcl = worksheet.Cell(1, i);
                    xcl.Value = dt.Columns[i - 1].ToString();
                    xcl.Style.Font.Bold = true;
                    xcl.Style.Font.Italic = false;
                    xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    xcl.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    xcl.Style.Fill.BackgroundColor = XLColor.Aqua;
                }
                row++;

                // Adding data rows to Excel
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 1; i <= dt.Columns.Count; i++)
                    {
                        xcl = worksheet.Cell(row, i);
                        decimal itemVal;
                        DateTime dateText;

                        if (Decimal.TryParse(dr[i - 1].ToString(), out itemVal))
                        {
                            xcl.Value = itemVal;
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        else if (DateTime.TryParse(dr[i - 1].ToString(), out dateText))
                        {
                            xcl.Value = $"'{dr[i - 1].ToString().Split(" ")[0]}";
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }
                        else
                        {
                            xcl.Value = $"{dr[i - 1]}";
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }

                        xcl.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    }
                    row++;
                }

                // Adjusting column width to fit content
                worksheet.Columns().AdjustToContents();
            }

            // Save and return the file
            using var stream = new MemoryStream();
            var content = stream.ToArray();
            string actualFilePath = pathDownload + "\\" + fileName;
            workbook.SaveAs(actualFilePath);
            workbook.Dispose();
            byte[] fileBytes = System.IO.File.ReadAllBytes(actualFilePath);
            System.IO.File.Delete(actualFilePath);

            return File(fileBytes, contentType, fileName);
        } 
        
        public ActionResult ExportForm3ToExcel(string MunCode)
        {
            string[] pgsQuerys;
            List<DataTable> dts = new List<DataTable>();
            List<string> tbls = new List<string>();
            if (MunCode != "")
            {
                tbls = new List<string>()
        {
            "Form 3"
        };

                // Join the necessary tables with 'form1_a' based on the 'MunCode' or 'FormId'
                pgsQuerys = new string[1]
{
    $@"
    SELECT 
        ROW_NUMBER() OVER(ORDER BY f.id) AS SN, 
        wm.province AS Province, 
        wm.district AS District, 
        wm.municipality AS Municipality, 
        f.""added_by"" AS AddedBy,
        f.""added_on"" AS AddedOn,
        f.""edited_by"" AS EditedBy,
        f.""edited_on"" AS EditedOn,
        f.""cholera_count"" AS CholeraCount,
        f.""diarrhea_count"" AS DiarrheaCount,
        f.""hepatitis_count"" AS HepatitisCount,
        f.""month"" AS Month,
        f.""typhoid_count"" AS TyphoidCount,
        f.""dysentery_count"" AS DysenteryCount,
        f.""form_id"" AS FormId
    FROM 
        wqs.""form_3"" f
    LEFT JOIN 
        wqs.wq_Surveillance_main wm 
    ON 
        f.""form_id"" = wm.""uuid""
    WHERE 
        SPLIT_PART(wm.""municipality"", ' - ', 1) = '{MunCode}'
    ORDER BY 
        f.id;"
};



            }
            else
            {
                pgsQuerys = new string[1] { "SELECT" };
            }

            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = MunCode + "_form3_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
            string pathDownload = Path.Combine(_hostEnvironment.WebRootPath, "TEMP");

            if (!Directory.Exists(pathDownload))
            {
                Directory.CreateDirectory(pathDownload);
            }

            using var workbook = new XLWorkbook();
            workbook.Properties.Company = "WQS";

            for (int item = 1; item <= tbls.Count; item++)  // or do pgsQuerys.Count
            {
                DataTable dt = new DataTable();
                DbConnection connection = _wqsContext.Database.GetDbConnection();
                DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);

                using (var cmd = dbFactory.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = pgsQuerys[item - 1];

                    using DbDataAdapter adapter = dbFactory.CreateDataAdapter();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }

                IXLWorksheet worksheet = workbook.Worksheets.Add(tbls[item - 1]);
                IXLCell xcl;
                int row = 1;

                // Adding headers to Excel
                for (int i = 1; i <= dt.Columns.Count; i++)
                {
                    xcl = worksheet.Cell(1, i);
                    xcl.Value = dt.Columns[i - 1].ToString();
                    xcl.Style.Font.Bold = true;
                    xcl.Style.Font.Italic = false;
                    xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    xcl.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    xcl.Style.Fill.BackgroundColor = XLColor.Aqua;
                }
                row++;

                // Adding data rows to Excel
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 1; i <= dt.Columns.Count; i++)
                    {
                        xcl = worksheet.Cell(row, i);
                        decimal itemVal;
                        DateTime dateText;

                        if (Decimal.TryParse(dr[i - 1].ToString(), out itemVal))
                        {
                            xcl.Value = itemVal;
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        else if (DateTime.TryParse(dr[i - 1].ToString(), out dateText))
                        {
                            xcl.Value = $"'{dr[i - 1].ToString().Split(" ")[0]}";
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }
                        else
                        {
                            xcl.Value = $"{dr[i - 1]}";
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }

                        xcl.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    }
                    row++;
                }

                // Adjusting column width to fit content
                worksheet.Columns().AdjustToContents();
            }

            // Save and return the file
            using var stream = new MemoryStream();
            var content = stream.ToArray();
            string actualFilePath = pathDownload + "\\" + fileName;
            workbook.SaveAs(actualFilePath);
            workbook.Dispose();
            byte[] fileBytes = System.IO.File.ReadAllBytes(actualFilePath);
            System.IO.File.Delete(actualFilePath);

            return File(fileBytes, contentType, fileName);
        }

         public ActionResult ExportAllSanitationToExcel(string MunCode)
        {
            // List of table names (will be used as sheet names in Excel)
            List<string> tbls = new List<string>()
    {
        "Reservoir Sanitation",
        "Source Sanitary",
        "Structure Sanitation",
        "Tap Sanitation"
    };

            // List of SQL queries for each table
            List<string> pgsQuerys = new List<string>()
    {
        $@"
       SELECT 
        ROW_NUMBER() OVER(ORDER BY r.""id"") AS SN, 
        wm.province AS Province, 
        wm.district AS District, 
        wm.municipality AS Municipality, 
        r.""added_by"" AS AddedBy,
        r.""added_on"" AS AddedOn,
        r.""edited_by"" AS EditedBy,
        r.""edited_on"" AS EditedOn,
        r.""latitude"" AS Latitude,
        r.""longitude"" AS Longitude,
        r.""resorvoir_sanitation_condition_1"" AS ResorvoirSanitationCondition1,
        r.""resorvoir_sanitation_condition_2"" AS ResorvoirSanitationCondition2,
        r.""resorvoir_sanitation_condition_3"" AS ResorvoirSanitationCondition3,
        r.""resorvoir_sanitation_condition_4"" AS ResorvoirSanitationCondition4,
        r.""resorvoir_sanitation_condition_5"" AS ResorvoirSanitationCondition5,
        r.""the_geom"" AS TheGeom,
        r.""visit_date"" AS VisitDate
    FROM 
        wqs.""reservoir_sanitary"" r
    LEFT JOIN 
        wqs.wq_Surveillance_main wm 
    ON 
        r.""form_id"" = wm.""uuid""
    WHERE 
        SPLIT_PART(wm.""municipality"", ' - ', 1) = '{MunCode}'
    ORDER BY 
        r.""id"";",

        $@"
        SELECT 
        ROW_NUMBER() OVER(ORDER BY s.""id"") AS SN, 
        wm.province AS Province, 
        wm.district AS District, 
        wm.municipality AS Municipality, 
        s.""added_by"" AS AddedBy,
        s.""added_on"" AS AddedOn,
        s.""edited_by"" AS EditedBy,
        s.""edited_on"" AS EditedOn,
        s.""latitude"" AS Latitude,
        s.""longitude"" AS Longitude,
        s.""source_sanitation_condition_1"" AS SourceSanitationCondition1,
        s.""source_sanitation_condition_2"" AS SourceSanitationCondition2,
        s.""source_sanitation_condition_3"" AS SourceSanitationCondition3,
        s.""source_sanitation_condition_4"" AS SourceSanitationCondition4,
        s.""source_sanitation_condition_5"" AS SourceSanitationCondition5,
        s.""source_sanitation_condition_6"" AS SourceSanitationCondition6,
        s.""source_sanitation_condition_7"" AS SourceSanitationCondition7,
        s.""source_sanitation_condition_8"" AS SourceSanitationCondition8,
        s.""source_sanitation_condition_9"" AS SourceSanitationCondition9,
        s.""source_sanitation_condition_10"" AS SourceSanitationCondition10,
        s.""source_sanitation_condition_11"" AS SourceSanitationCondition11,
        s.""source_sanitation_condition_12"" AS SourceSanitationCondition12,
        s.""source_sanitation_condition_13"" AS SourceSanitationCondition13,
        s.""source_sanitation_condition_14"" AS SourceSanitationCondition14,
        s.""source_sanitation_condition_15"" AS SourceSanitationCondition15,
        s.""the_geom"" AS TheGeom,
        s.""visit_date"" AS VisitDate
        
    FROM 
        wqs.""source_sanitary"" s
    LEFT JOIN 
        wqs.wq_Surveillance_main wm 
    ON 
        s.""form_id"" = wm.""uuid""
    WHERE 
        SPLIT_PART(wm.""municipality"", ' - ', 1) = '{MunCode}'
    ORDER BY 
        s.""id"";",
        $@"
        SELECT 
        ROW_NUMBER() OVER(ORDER BY s.""id"") AS SN, 
        wm.province AS Province, 
        wm.district AS District, 
        wm.municipality AS Municipality, 
        s.""added_by"" AS AddedBy,
        s.""added_on"" AS AddedOn,
        s.""edited_by"" AS EditedBy,
        s.""edited_on"" AS EditedOn,
        s.""latitude"" AS Latitude,
        s.""longitude"" AS Longitude,
        s.""source_sanitation_condition_1"" AS SourceSanitationCondition1,
        s.""source_sanitation_condition_2"" AS SourceSanitationCondition2,
        s.""source_sanitation_condition_3"" AS SourceSanitationCondition3,
        s.""source_sanitation_condition_4"" AS SourceSanitationCondition4,
        s.""source_sanitation_condition_5"" AS SourceSanitationCondition5,
        s.""source_sanitation_condition_6"" AS SourceSanitationCondition6,
        s.""source_sanitation_condition_7"" AS SourceSanitationCondition7,
        s.""source_sanitation_condition_8"" AS SourceSanitationCondition8,
        s.""source_sanitation_condition_9"" AS SourceSanitationCondition9,
        s.""source_sanitation_condition_10"" AS SourceSanitationCondition10,
        s.""source_sanitation_condition_11"" AS SourceSanitationCondition11,
        s.""source_sanitation_condition_12"" AS SourceSanitationCondition12,
        s.""source_sanitation_condition_13"" AS SourceSanitationCondition13,
        s.""source_sanitation_condition_14"" AS SourceSanitationCondition14,
        s.""source_sanitation_condition_15"" AS SourceSanitationCondition15,
        s.""the_geom"" AS TheGeom,
        s.""visit_date"" AS VisitDate
       
    FROM 
        wqs.""source_sanitary"" s
    LEFT JOIN 
        wqs.wq_Surveillance_main wm 
    ON 
        s.""form_id"" = wm.""uuid""
    WHERE 
        SPLIT_PART(wm.""municipality"", ' - ', 1) = '{MunCode}'
    ORDER BY 
        s.""id"";",
        $@"
       SELECT 
        ROW_NUMBER() OVER(ORDER BY t.""id"") AS SN, 
        wm.province AS Province, 
        wm.district AS District, 
        wm.municipality AS Municipality, 
        t.""added_by"" AS AddedBy,
        t.""added_on"" AS AddedOn,
        t.""edited_by"" AS EditedBy,
        t.""edited_on"" AS EditedOn,
        t.""latitude"" AS Latitude,
        t.""longitude"" AS Longitude,
        t.""tap_sanitation_condition_1"" AS TapSanitationCondition1,
        t.""tap_sanitation_condition_2"" AS TapSanitationCondition2,
        t.""tap_sanitation_condition_3"" AS TapSanitationCondition3,
        t.""tap_sanitation_condition_4"" AS TapSanitationCondition4,
        t.""tap_sanitation_condition_5"" AS TapSanitationCondition5,
        t.""tap_sanitation_condition_6"" AS TapSanitationCondition6,
        t.""tap_sanitation_condition_7"" AS TapSanitationCondition7,
        t.""the_geom"" AS TheGeom,
        t.""visit_date"" AS VisitDate
    FROM 
        wqs.""tap_sanitary"" t
    LEFT JOIN 
        wqs.wq_Surveillance_main wm 
    ON 
        t.""form_id"" = wm.""uuid""
    WHERE 
        SPLIT_PART(wm.""municipality"", ' - ', 1) = '{MunCode}'
    ORDER BY 
        t.""id"";"
    };

            // Set up the Excel file
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = MunCode + "_AllSanitation_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
            string pathDownload = Path.Combine(_hostEnvironment.WebRootPath, "TEMP");

            if (!Directory.Exists(pathDownload))
            {
                Directory.CreateDirectory(pathDownload);
            }

            // Create the Excel workbook
            using var workbook = new XLWorkbook();
            workbook.Properties.Company = "WQS";

            // Loop through each table and create a sheet in the Excel file
            for (int i = 0; i < tbls.Count; i++)
            {
                DataTable dt = new DataTable();
                DbConnection connection = _wqsContext.Database.GetDbConnection();
                DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);

                using (var cmd = dbFactory.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = pgsQuerys[i];

                    using DbDataAdapter adapter = dbFactory.CreateDataAdapter();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }

                IXLWorksheet worksheet = workbook.Worksheets.Add(tbls[i]);
                IXLCell xcl;
                int row = 1;

                // Adding headers to Excel
                for (int col = 1; col <= dt.Columns.Count; col++)
                {
                    xcl = worksheet.Cell(1, col);
                    xcl.Value = dt.Columns[col - 1].ToString();
                    xcl.Style.Font.Bold = true;
                    xcl.Style.Font.Italic = false;
                    xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    xcl.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    xcl.Style.Fill.BackgroundColor = XLColor.Aqua;
                }
                row++;

                // Adding data rows to Excel
                foreach (DataRow dr in dt.Rows)
                {
                    for (int col = 1; col <= dt.Columns.Count; col++)
                    {
                        xcl = worksheet.Cell(row, col);
                        decimal itemVal;
                        DateTime dateText;

                        if (Decimal.TryParse(dr[col - 1].ToString(), out itemVal))
                        {
                            xcl.Value = itemVal;
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        else if (DateTime.TryParse(dr[col - 1].ToString(), out dateText))
                        {
                            xcl.Value = $"'{dr[col - 1].ToString().Split(" ")[0]}";
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }
                        else
                        {
                            xcl.Value = $"{dr[col - 1]}";
                            xcl.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }

                        xcl.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    }
                    row++;
                }

                // Adjusting column width to fit content
                worksheet.Columns().AdjustToContents();
            }

            // Save and return the file
            using var stream = new MemoryStream();
            var content = stream.ToArray();
            string actualFilePath = pathDownload + "\\" + fileName;
            workbook.SaveAs(actualFilePath);
            workbook.Dispose();
            byte[] fileBytes = System.IO.File.ReadAllBytes(actualFilePath);
            System.IO.File.Delete(actualFilePath);

            return File(fileBytes, contentType, fileName);
        }
        }

}
