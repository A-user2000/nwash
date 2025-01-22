using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class ReservoirSanitary
{
    public int Id { get; set; }
    public string? Uuid { get; set; }

    public string? FormId { get; set; }
    public string? AddedBy { get; set; }
    public DateTime? AddedOn { get; set; }
    public string? EditedBy { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? ResorvoirSanitationCondition1 { get; set; }

    public string? ResorvoirSanitationCondition2 { get; set; }

    public string? ResorvoirSanitationCondition3 { get; set; }

    public string? ResorvoirSanitationCondition4 { get; set; }

    public string? ResorvoirSanitationCondition5 { get; set; }
    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string? VisitDate { get; set; }

    public Geometry? TheGeom { get; set; }
}
