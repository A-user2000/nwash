using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.NwashModels;

public partial class Municipality
{
    public int Id { get; set; }

    public string? MunUuid { get; set; }

    public string? MunName { get; set; }

    public string? MunNameNep { get; set; }

    public string? MunType { get; set; }

    public string? MunCode { get; set; }

    public string? ProvinceCode { get; set; }

    public string? DistrictCode { get; set; }

    public Polygon? TheGeom { get; set; }

    public int? DataYear { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? AddBy { get; set; }
}
