using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class ReportDatum
{
    public int Id { get; set; }

    public string? ProCode { get; set; }

    public string? MunicipalityCode { get; set; }

    public string? DistrictCode { get; set; }

    public string? ProvinceCode { get; set; }

    public string? SchemeCondition { get; set; }

    public string? SchemePrioritizationScore { get; set; }

    public string? TotalPopulation { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }
}
