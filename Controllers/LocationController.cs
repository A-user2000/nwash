using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Wq_Surveillance.Models;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly WqsContext _wqsContext;

    public LocationController(WqsContext wqsContext)
    {
        _wqsContext = wqsContext;
    }

    [HttpPost("SyncData")]
    public string SyncData()
    {
        // Fetch all provinces, districts, municipalities, and projects
        var provinces = _wqsContext.Provinces.OrderBy(item => item.ProvinceCode).ToList();
        var districts = _wqsContext.Districts.OrderBy(item => item.DistrictCode).ToList();
        var municipalities = _wqsContext.Municipalities.OrderBy(item => item.MunCode).ToList();
        var projects = _wqsContext.ProjectDetails
            .Select(p => new
            {
                ProCode = p.ProCode,
                ProName = p.ProName,
                MunicipalityCode = p.MunicipalityCode,
                ProType = p.ProType
            })
            .OrderBy(item => item.ProCode)
            .Cast<object>()
            .ToList();

        // Create a tuple containing the data
        Tuple<bool, List<Province>, List<District>, List<Municipality>, List<object>> returnTuple =
            new Tuple<bool, List<Province>, List<District>, List<Municipality>, List<object>>(true, provinces, districts, municipalities, projects);

        // Serialize the tuple into JSON
        string json = JsonConvert.SerializeObject(returnTuple);
        Console.WriteLine(json);

        // Replace tuple property names with descriptive names
        json = json.Replace("Item1", "result");
        json = json.Replace("Item2", "Province");
        json = json.Replace("Item3", "District");
        json = json.Replace("Item4", "Municipality");
        json = json.Replace("Item5", "Project");

        return json;
    }



}
