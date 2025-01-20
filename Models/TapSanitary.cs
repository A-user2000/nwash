using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;   

namespace Wq_Surveillance.Models;

public partial class TapSanitary
{
    public int Id { get; set; }
    public string? Uuid { get; set; }

    public string? FormId { get; set; }
    public string? AddedBy { get; set; }

    public DateTime? AddedOn { get; set; }

    public string? TapSanitationCondition1 { get; set; }

    public string? TapSanitationCondition2 { get; set; }

    public string? TapSanitationCondition3 { get; set; }

    public string? TapSanitationCondition4 { get; set; }

    public string? TapSanitationCondition5 { get; set; }

    public string? TapSanitationCondition6 { get; set; }

    public string? TapSanitationCondition7 { get; set; }
    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string? VisitDate { get; set; }

    public Geometry? TheGeom { get; set; }
}
