using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class MunicipalityWiseHhPop
{
    public int Id { get; set; }

    public string? ProvinceCode { get; set; }

    public string? DistrictCode { get; set; }

    public string? MunCode { get; set; }

    public string? WardNo { get; set; }

    public long? Hh { get; set; }

    public long? TotalPop { get; set; }

    public long? Male { get; set; }

    public long? Female { get; set; }

    public int? CensusYear { get; set; }
}
