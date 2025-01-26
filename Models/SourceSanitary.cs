using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class SourceSanitary
{
    public int Id { get; set; }
    public string? Uuid { get; set; }

    public string? FormId { get; set; }
    public string? AddedBy { get; set; }
    public DateTime? AddedOn { get; set; }
    public string? EditedBy { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? SourceSanitationCondition1 { get; set; }

    public string? SourceSanitationCondition2 { get; set; }

    public string? SourceSanitationCondition3 { get; set; }

    public string? SourceSanitationCondition4 { get; set; }

    public string? SourceSanitationCondition5 { get; set; }

    public string? SourceSanitationCondition6 { get; set; }

    public string? SourceSanitationCondition7 { get; set; }

    public string? SourceSanitationCondition8 { get; set; }

    public string? SourceSanitationCondition9 { get; set; }

    public string? SourceSanitationCondition10 { get; set; }

    public string? SourceSanitationCondition11 { get; set; }

    public string? SourceSanitationCondition12 { get; set; }

    public string? SourceSanitationCondition13 { get; set; }

    public string? SourceSanitationCondition14 { get; set; }

    public string? SourceSanitationCondition15 { get; set; }
    public string? SourceDetails { get; set; }
    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string? VisitDate { get; set; }

    public Geometry? TheGeom { get; set; }
}
