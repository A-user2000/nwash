using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wq_Surveillance.Functionality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using System.Text;
using Wq_Surveillance.Service;
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
namespace Wq_Surveillance.Controllers
{
    public class HomeController : Controller
    {
        private readonly WqsContext _wqsContext;
        private readonly NwashContext _nwashContext;
        private readonly IWQSservices _wqsservices;
        private readonly IHttpContextAccessor _sessionData;
        private readonly IMapper _mapper;
        private static IWebHostEnvironment _hostEnvironment;




        public HomeController(IWQSservices wqsservices, IMapper mapper, IHttpContextAccessor httpContextAccessor, WqsContext wqsContext, IWebHostEnvironment hostEnvironment,NwashContext nwashContext)
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

        //    var data = _wqsContext.WqSurvellianceMains
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

            var data = _wqsContext.WqSurvellianceMains
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
                    var projectData = _wqsContext.Taps
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


            return PartialView("~/Views/Home/Wq_Survelliance/Wq_Main.cshtml", dto);
        }
        public PartialViewResult SanData(string munCode)
        {
            ViewData["munCode"] = munCode;

            // Query the data and project into the ViewModel
            var data = _wqsContext.WqSurvellianceMains
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
                    ReservoirExists = _wqsContext.ReservoirSanitaries.Any(f => f.FormId == item.Uuid),
                    SourceExists = _wqsContext.SourceSanitaries.Any(f => f.FormId == item.Uuid),
                    StructureExists = _wqsContext.StructureSanitaries.Any(f => f.FormId == item.Uuid),
                    TapExists = _wqsContext.TapSanitaries.Any(f => f.FormId == item.Uuid)
                })
                .ToList();

            // Pass the ViewModel to the view
            return PartialView("~/Views/Home/Sanitary_Inspection/SanitaryIndex.cshtml", data);
        }





        public WqSurvellianceMain GetAddressFromId(string Id)
        {
            return _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Id.Equals(Id));

        }
 
        public PartialViewResult F1AData(string munCode)
        {
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
                item.ProCode = (data[item.FormId]);
                item.Address = (address[item.FormId]);
                    item.TotalHhServed = householdData.ContainsKey(item.FormId) ? householdData[item.FormId] : 0;
                    item.TotalBenificiaryPopulation = population.ContainsKey(item.FormId) ? population[item.FormId] : 0;
                    result.Add(item);
            }
            ViewData["munCode"] = munCode;

            return PartialView("~/Views/Home/Form1A/GetForm1A.cshtml", result);
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


            return PartialView("~/Views/Home/Form1B/GetForm1B.cshtml", result);
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


            return PartialView("~/Views/Home/Form2/GetForm2.cshtml", result);;
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



            return PartialView("~/Views/Home/Form3/GetForm3.cshtml", result);
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


            return PartialView("~/Views/Home/Reservoir_Sanitary/GetFormRes.cshtml", result); ;
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

            return PartialView("~/Views/Home/Source_Sanitary/GetFormSou.cshtml", result);
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

            return PartialView("~/Views/Home/Structure_Sanitary/GetFormStr.cshtml", result);
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

            return PartialView("~/Views/Home/Tap_Sanitary/GetFormTap.cshtml", result);
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
            var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address
            //var data = GetFormId(uuid); // Assuming GetFormId is a method that provides ProCode
            var formData = _mapper.Map<Form1ADto>(hhData);

         

            formData.ProCode = (data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;

            return View("~/Views/Home/Form1A/1AView.cshtml", formData);
        }

        public IActionResult FormViewB(string encode)
        {
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);
            var hhData = _wqsContext.Form1bs
                            .Where(s => (s.FormId == uuid))
                            .FirstOrDefault();

            //ViewData["AddedBy"] = _wqsContext.Users.Where(s => s.Email == hhData.AddBy).Select(s => s.Name).SingleOrDefault();
            var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address
            var formData = _mapper.Map<Form1BDto>(hhData);



            formData.ProCode = (data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;

            return View("~/Views/Home/Form1B/1BView.cshtml", formData);
        }
        public IActionResult FormView2(string encode)
        {
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);
            var hhData = _wqsContext.Form2s
                            .Where(s => (s.FormId == uuid))
                            .FirstOrDefault();

            //ViewData["AddedBy"] = _wqsContext.Users.Where(s => s.Email == hhData.AddBy).Select(s => s.Name).SingleOrDefault();
            var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address
            //var data = GetFormId(uuid); // Assuming GetFormId is a method that provides ProCode
            var formData = _mapper.Map<Form2Dto>(hhData);



            formData.ProCode =(data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;

            return View("~/Views/Home/Form2/2View.cshtml", formData);
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
                var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));
                var formData = _mapper.Map<Form3Dto>(hhData);

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

            // Get the Form1a data based on the decoded FormId
            var hhData = _wqsContext.ReservoirSanitaries
                              .Where(s => (s.FormId == uuid))
                              .FirstOrDefault();

            // If no data is found, handle the case gracefully
            if (hhData == null)
            {
                return NotFound(); // or return an error view
            }

            // Map the data to the DTO (Form1ADto) and add ProCode and Address
            var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address
            //var data = GetFormId(uuid); // Assuming GetFormId is a method that provides ProCode
            var formData = _mapper.Map<FormResDto>(hhData);



            formData.ProCode = (data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;

            return View("~/Views/Home/Reservoir_Sanitary/ResView.cshtml", formData);
        }
        public IActionResult FormViewSou(string encode)
        {
            // Decode the base64 encoded FormId
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            // Get the Form1a data based on the decoded FormId
            var hhData = _wqsContext.SourceSanitaries
                              .Where(s => (s.FormId == uuid))
                              .FirstOrDefault();

            // If no data is found, handle the case gracefully
            if (hhData == null)
            {
                return NotFound(); // or return an error view
            }

            // Map the data to the DTO (Form1ADto) and add ProCode and Address
            var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address
            //var data = GetFormId(uuid); // Assuming GetFormId is a method that provides ProCode
            var formData = _mapper.Map<FormSouDto>(hhData);



            formData.ProCode = (data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;

            return View("~/Views/Home/Source_Sanitary/SouView.cshtml", formData);
        }
        public IActionResult FormViewStr(string encode)
        {
            // Decode the base64 encoded FormId
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            // Get the Form1a data based on the decoded FormId
            var hhData = _wqsContext.StructureSanitaries
                              .Where(s => (s.FormId == uuid))
                              .FirstOrDefault();

            // If no data is found, handle the case gracefully
            if (hhData == null)
            {
                return NotFound(); // or return an error view
            }

            // Map the data to the DTO (Form1ADto) and add ProCode and Address
            var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address
            //var data = GetFormId(uuid); // Assuming GetFormId is a method that provides ProCode
            var formData = _mapper.Map<FormStrDto>(hhData);



            formData.ProCode = (data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;

            return View("~/Views/Home/Structure_Sanitary/StrView.cshtml", formData);
        }
        public IActionResult FormViewTap(string encode)
        {
            // Decode the base64 encoded FormId
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            // Get the Form1a data based on the decoded FormId
            var hhData = _wqsContext.TapSanitaries
                              .Where(s => (s.FormId == uuid))
                              .FirstOrDefault();

            // If no data is found, handle the case gracefully
            if (hhData == null)
            {
                return NotFound(); // or return an error view
            }

            // Map the data to the DTO (Form1ADto) and add ProCode and Address
            var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address
            //var data = GetFormId(uuid); // Assuming GetFormId is a method that provides ProCode
            var formData = _mapper.Map<FormTapDto>(hhData);



            formData.ProCode = (data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;

            return View("~/Views/Home/Tap_Sanitary/TapView.cshtml", formData);
        }
       

        public IActionResult Form1AEdit(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var FormId = Encoding.UTF8.GetString(base64EncodedBytes);

            var hhData = _wqsContext.Form1as
                            .Where(s => (s.FormId == FormId))
                            .FirstOrDefault();
            //ViewData["AddedBy"] = _wqsContext.Users.Where(s => s.Email == hhDataList.AddBy).Select(s => s.Name).SingleOrDefault();
            var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address
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
            //ViewData["AddedBy"] = _wqsContext.Users.Where(s => s.Email == hhDataList.AddBy).Select(s => s.Name).SingleOrDefault();
            var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address
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
            //ViewData["AddedBy"] = _wqsContext.Users.Where(s => s.Email == hhDataList.AddBy).Select(s => s.Name).SingleOrDefault();
            var formData = _mapper.Map<Form2Dto>(hhData);

            var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address


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
                var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));
                
                
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

            var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address


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

            var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address


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

            var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address


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

            var data = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));  // Assuming GetAddress is a method that provides the address


            formData.ProCode =(data.ProjectName);
            formData.Address = data.Address;  // Assuming GetAddress provides the address

            var res = _wqsservices.GetPopandHH(formData.ProCode);// Assuming ExtractNumber is a method to get the ProCode
            formData.TotalPop = data.TotalBenificiaryPopulation;

            formData.TotalHhServed = data.TotalHhServed;


            return View("Tap_Sanitary/TapEdit", formData);
        }
        public IActionResult SanEdit(string encode)
        {
            // Decode the base64 encoded FormId
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            // Retrieve Reservoir Sanitation Data
            var hhData = _wqsContext.ReservoirSanitaries
                           .Where(s => (s.FormId == uuid))
                           .FirstOrDefault();
            if (hhData == null)
            {
                return NotFound();
            }

            var resData = _mapper.Map<FormResDto>(hhData);
            var resMainData = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));
            resData.ProCode = resMainData.ProjectName;
            resData.Address = resMainData.Address;
            resData.TotalPop = resMainData.TotalBenificiaryPopulation;
            resData.TotalHhServed = resMainData.TotalHhServed;

            // Retrieve Source Sanitation Data
            var sourceData = _wqsContext.SourceSanitaries
                             .Where(s => s.FormId == uuid)
                             .FirstOrDefault();
            var souData = _mapper.Map<FormSouDto>(sourceData);
            var StructureData = _wqsContext.StructureSanitaries
                            .Where(s => s.FormId == uuid)
                            .FirstOrDefault();
            var StrData = _mapper.Map<FormStrDto>(StructureData);
            var TapData = _wqsContext.TapSanitaries
                            .Where(s => s.FormId == uuid)
                            .FirstOrDefault();
            var TapDatas = _mapper.Map<FormTapDto>(TapData);

            // Combine both data models
            var combinedData = new FormCombinedDto
            {
                ReservoirSanitationData = resData,
                SourceSanitationData = souData,
                StructureSanitationData = StrData,
                TapSanitationData = TapDatas
            };

            return View("~/Views/Home/Sanitary_Inspection/SanitaryEdit.cshtml", combinedData);
        }
        public PartialViewResult ShowEdit(string encode)
        {
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);
            ViewData["uuid"] = uuid;

            var hhData = _wqsContext.ReservoirSanitaries
                           .Where(s => (s.FormId == uuid))
                           .FirstOrDefault();
           

            var resData = _mapper.Map<FormResDto>(hhData);
            var resMainData = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));
            resData.ProCode = resMainData.ProjectName;
            resData.Address = resMainData.Address;
            resData.TotalPop = resMainData.TotalBenificiaryPopulation;
            resData.TotalHhServed = resMainData.TotalHhServed;

            var sourceData = _wqsContext.SourceSanitaries
                             .Where(s => s.FormId == uuid)
                             .FirstOrDefault();
            var souData = _mapper.Map<FormSouDto>(sourceData);
            var StructureData = _wqsContext.StructureSanitaries
                            .Where(s => s.FormId == uuid)
                            .FirstOrDefault();
            var StrData = _mapper.Map<FormStrDto>(StructureData);
            var TapData = _wqsContext.TapSanitaries
                            .Where(s => s.FormId == uuid)
                            .FirstOrDefault();
            var TapDatas = _mapper.Map<FormTapDto>(TapData);

            // Combine both data models
            var combinedData = new FormCombinedDto
            {
                ReservoirSanitationData = resData,
                SourceSanitationData = souData,
                StructureSanitationData = StrData,
                TapSanitationData = TapDatas

            };
             return PartialView("~/Views/Home/Sanitary_Inspection/show.cshtml", combinedData);
        }

        public PartialViewResult ShowData(string valueis, string uuid)
        {
            ViewData["uuid"] = uuid;

            if (valueis == "tap")
            {
                var Tap = _wqsContext.TapSanitaries
                            .Where(s => s.FormId == uuid)
                            .FirstOrDefault();
                if (Tap == null)
                {
                    return PartialView("~/Views/Shared/NotFound.cshtml"); 
                }
                return PartialView("~/Views/Home/Sanitary_Inspection/_tapedit.cshtml", Tap); 
            }
            else if (valueis == "reservoir")
            {
                var Reservoir = _wqsContext.ReservoirSanitaries
                            .Where(s => s.FormId == uuid)
                            .FirstOrDefault();
                return PartialView("~/Views/Home/Sanitary_Inspection/_resedit.cshtml", Reservoir);
            }
            else if (valueis == "source")
            {
                var Source = _wqsContext.SourceSanitaries
                            .Where(s => s.FormId == uuid)
                            .FirstOrDefault();
                return PartialView("~/Views/Home/Sanitary_Inspection/_souedit.cshtml", Source);
            }
            else if (valueis == "structure")
            {
                var Structure = _wqsContext.StructureSanitaries
                            .Where(s => s.FormId == uuid)
                            .FirstOrDefault();
                return PartialView("~/Views/Home/Sanitary_Inspection/_stredit.cshtml", Structure);
            }
            else
            {
                return PartialView("~/Views/Home/show.cshtml");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormAEditPost(Form1a WData)
        {
            var updateData = _wqsservices.UpdateWQSDataFA(WData);

            string formid = WData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("Form1AEdit", "Home", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("Form1AEdit", "Home", new { @id = encodedUUID });
            }
        }
         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormBEditPost(Form1b WData)
        {
            var updateData = _wqsservices.UpdateWQSDataFB(WData);

            string formid = WData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("Form1BEdit", "Home", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("Form1BEdit", "Home", new { @id = encodedUUID });
            }
        }
           [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form2EditPost(Form2 WData)
        {
            var updateData = _wqsservices.UpdateWQSDataF2(WData);

            string formid = WData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("Form2Edit", "Home", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("Form2Edit", "Home", new { @id = encodedUUID });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form3EditPost(Form3EditDto WData)
        {
            var fId = _wqsservices.UpdateWQSDataF3(WData.UpdateData);

            string formid = fId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (fId != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("Form3Edit", "Home", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("Form3Edit", "Home", new { @id = encodedUUID });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormSanResEditPost(FormCombinedDto WData)
        {
            var updateData = _wqsservices.UpdateWQSDataRes(WData.ReservoirSanitationData);

            string formid = WData.ReservoirSanitationData.FormId;
            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            // Check if it's an AJAX request by checking the X-Requested-With header
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                if (updateData != null)
                {
                    // Return a success JSON response
                    return Json(new { success = true, message = "Data Updated Successfully", redirectUrl = Url.Action("SanEdit", "Home", new { encode = encodedUUID }) });
                }
                else
                {
                    // Return an error JSON response
                    return Json(new { success = false, message = "Something Went Wrong. Please try again later." });
                }
            }

            // If it's not an AJAX request, fall back to the original logic
            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("SanEdit", "Home", new { encode = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("FormSanResEdit", "Home", new { encode = encodedUUID });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormSanSouEditPost(FormCombinedDto WData)
        {
            var updateData = _wqsservices.UpdateWQSDataSou(WData.SourceSanitationData);

            string formid = WData.SourceSanitationData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("SanEdit", "Home", new { encode = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("FormSanResEdit", "Home", new { encode = encodedUUID });
            }
        }
          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormSanStrEditPost(FormCombinedDto WData)
        {
            var updateData = _wqsservices.UpdateWQSDataStr(WData.StructureSanitationData);

            string formid = WData.StructureSanitationData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("SanEdit", "Home", new { encode = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("FormSanResEdit", "Home", new { encode = encodedUUID });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormSanTapEditPost(TapSanitary WData)
        {
            if (WData == null)
            {
                TempData["ErrorMessage"] = "Invalid data submitted.";
                return RedirectToAction("FormSanResEdit", "Home");
            }

            var updateData = _wqsservices.UpdateWQSDataTap(WData);

            string formid = WData.FormId;
            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("FormSanTapEdit", "Home", new { encode = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("FormSanResEdit", "Home", new { encode = encodedUUID });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormResEditPost(ReservoirSanitary WData)
        {
            var updateData = _wqsservices.UpdateWQSDataRes(WData);

            string formid = WData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("FormResEdit", "Home", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("FormResEdit", "Home", new { @id = encodedUUID });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormSouEditPost(SourceSanitary WData)
        {
            var updateData = _wqsservices.UpdateWQSDataSou(WData);

            string formid = WData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("FormSouEdit", "Home", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("FormSouEdit", "Home", new { @id = encodedUUID });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormStrEditPost(StructureSanitary WData)
        {
            var updateData = _wqsservices.UpdateWQSDataStr(WData);

            string formid = WData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("FormStrEdit", "Home", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("FormStrEdit", "Home", new { @id = encodedUUID });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormTapEditPost(TapSanitary WData)
        {
            var updateData = _wqsservices.UpdateWQSDataTap(WData);

            string formid = WData.FormId;

            var plainTextBytes = Encoding.UTF8.GetBytes(formid);
            string encodedUUID = Convert.ToBase64String(plainTextBytes);

            if (updateData != null)
            {
                TempData["SuccessMessage"] = "Data Updated Successfully";
                return RedirectToAction("FormTapEdit", "Home", new { @id = encodedUUID });
            }
            else
            {
                TempData["ErrorMessage"] = "Something Went Wrong. Please try again later.";
                return RedirectToAction("FormTapEdit", "Home", new { @id = encodedUUID });
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

        public IActionResult SanView(string encode)
        {
            // Decode the base64 encoded FormId
            var base64EncodedBytes = Convert.FromBase64String(encode);
            var uuid = Encoding.UTF8.GetString(base64EncodedBytes);

            // Retrieve Reservoir Sanitation Data
            var hhData = _wqsContext.ReservoirSanitaries
                           .Where(s => (s.FormId == uuid))
                           .FirstOrDefault();
            if (hhData == null)
            {
                return NotFound();
            }

            var resData = _mapper.Map<FormResDto>(hhData);
            var resMainData = _wqsContext.WqSurvellianceMains.FirstOrDefault(p => p.Uuid.Equals(hhData.FormId));
            resData.ProCode = resMainData.ProjectName;
            resData.Address = resMainData.Address;
            resData.TotalPop = resMainData.TotalBenificiaryPopulation;
            resData.TotalHhServed = resMainData.TotalHhServed;

            // Retrieve Source Sanitation Data
            var sourceData = _wqsContext.SourceSanitaries
                             .Where(s => s.FormId == uuid)
                             .FirstOrDefault();
            var souData = _mapper.Map<FormSouDto>(sourceData);
             var StructureData = _wqsContext.StructureSanitaries
                             .Where(s => s.FormId == uuid)
                             .FirstOrDefault();
            var StrData = _mapper.Map<FormStrDto>(StructureData);
             var TapData = _wqsContext.TapSanitaries
                             .Where(s => s.FormId == uuid)
                             .FirstOrDefault();
            var TapDatas = _mapper.Map<FormTapDto>(TapData);

            // Combine both data models
            var combinedData = new FormCombinedDto
            {
                ReservoirSanitationData = resData,
                SourceSanitationData = souData,
                StructureSanitationData = StrData,
                TapSanitationData = TapDatas
            };

            return View("~/Views/Home/Sanitary_Inspection/SanitaryView.cshtml", combinedData);
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
       f.*
   FROM 
       wqs.form_1a f
   LEFT JOIN 
       wqs.wq_survelliance_main wm 
   ON 
       f.form_Id = wm.Uuid
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
       f.*
   FROM 
       wqs.form_1b f
   LEFT JOIN 
       wqs.wq_survelliance_main wm 
   ON 
       f.form_Id = wm.Uuid
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
       f.*
   FROM 
       wqs.form_2 f
   LEFT JOIN 
       wqs.wq_survelliance_main wm 
   ON 
       f.form_Id = wm.Uuid
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
        f.*
    FROM 
        wqs.form_3 f
    LEFT JOIN 
        wqs.wq_survelliance_main wm 
    ON 
        f.""form_Id"" = wm.""uuid""
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

        public ActionResult ExportResSanToExcel(string MunCode) 
        {
            string[] pgsQuerys;
            List<DataTable> dts = new List<DataTable>();
            List<string> tbls = new List<string>();
            if (MunCode != "")
            {
                tbls = new List<string>()
        {
            "Reservoir Sanitation"
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
       f.*
   FROM 
       wqs.reservoir_sanitary f
   LEFT JOIN 
       wqs.wq_survelliance_main wm 
   ON 
       f.form_Id = wm.Uuid
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
            string fileName = MunCode + "_ResSan_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
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
        public ActionResult ExportSouSanToExcel(string MunCode)
        {
            string[] pgsQuerys;
            List<DataTable> dts = new List<DataTable>();
            List<string> tbls = new List<string>();
            if (MunCode != "")
            {
                tbls = new List<string>()
        {
            "Source Sanitary"
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
       f.*
   FROM 
       wqs.source_sanitary f
   LEFT JOIN 
       wqs.wq_survelliance_main wm 
   ON 
       f.form_Id = wm.Uuid
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
            string fileName = MunCode + "_SouSan_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
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
        public ActionResult ExportStrSanToExcel(string MunCode)
        {
            string[] pgsQuerys;
            List<DataTable> dts = new List<DataTable>();
            List<string> tbls = new List<string>();
            if (MunCode != "")
            {
                tbls = new List<string>()
        {
            "Structure Sanitation"
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
       f.*
   FROM 
       wqs.structure_sanitary f
   LEFT JOIN 
       wqs.wq_survelliance_main wm 
   ON 
       f.form_Id = wm.Uuid
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
            string fileName = MunCode + "_StrSan_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
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
        public ActionResult ExportTapSanToExcel(string MunCode)
        {
            string[] pgsQuerys;
            List<DataTable> dts = new List<DataTable>();
            List<string> tbls = new List<string>();
            if (MunCode != "")
            {
                tbls = new List<string>()
        {
            "Tap Sanitation"
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
       f.*
   FROM 
       wqs.tap_sanitary f
   LEFT JOIN 
       wqs.wq_survelliance_main wm 
   ON 
       f.form_Id = wm.Uuid
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
            string fileName = MunCode + "_TapSan_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
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
    }
}
