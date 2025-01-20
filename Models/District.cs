using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class District
{
    public int Id { get; set; }

    public string? DistrictUuid { get; set; }

    public string? DistrictCode { get; set; }

    public string? DistrictName { get; set; }

    public string? DistrictNameNep { get; set; }

    public string? ProvinceCode { get; set; }

    public Geometry? TheGeom { get; set; }

    public int? DataYear { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? AddBy { get; set; }
}
