using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;


namespace Wq_Surveillance.Models;

public partial class StructureSanitary
{
    public int Id { get; set; }
    public string? Uuid { get; set; }

    public string? FormId { get; set; }
    public string? AddedBy { get; set; }
    public DateTime? AddedOn { get; set; }


    public string? StructureSanitationCondition1 { get; set; }

    public string? StructureSanitationCondition2 { get; set; }

    public string? StructureSanitationCondition3 { get; set; }

    public string? StructureSanitationCondition4 { get; set; }

    public string? StructureSanitationCondition5 { get; set; }

    public string? StructureSanitationCondition6 { get; set; }

    public string? StructureSanitationCondition7 { get; set; }

    public string? StructureSanitationCondition8 { get; set; }

    public string? StructureSanitationCondition9 { get; set; }

    public string? StructureSanitationCondition10 { get; set; }
    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string? VisitDate { get; set; }

    public Geometry? TheGeom { get; set; }
}
