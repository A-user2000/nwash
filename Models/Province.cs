using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class Province
{
    public int Id { get; set; }

    public string? ProvinceUuid { get; set; }

    public string? ProvinceName { get; set; }

    public string? ProvinceNameNep { get; set; }

    public string? ProvinceCode { get; set; }

    public Polygon? TheGeom { get; set; }

    public int? DataYear { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? AddBy { get; set; }
}
