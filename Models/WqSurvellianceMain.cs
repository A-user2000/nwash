using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class WqSurvellianceMain
{
    public int Id { get; set; }

    public string? Uuid { get; set; }

    public string? DbName { get; set; }

    public string? Surveyor { get; set; }

    public string? Province { get; set; }

    public string? District { get; set; }

    public string? Municipality { get; set; }

    public string? FiscalYear { get; set; }

    public string? ProjectName { get; set; }

    public string? SystemType { get; set; }

    public string? Address { get; set; }

    public string? SourceName { get; set; }

    public string? SourceType { get; set; }

    public string? Others { get; set; }

    public int? TotalBenificiaryPopulation { get; set; }
    public int? TotalHhServed { get; set; }

    public string? SopCondition { get; set; }

    public string? WspCondtion { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string? VisitDate { get; set; }

    public Geometry? TheGeom { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? AddedOn { get; set; }

    public string? SopPhoto { get; set; }

    public string? WspPhoto { get; set; }

    public double? Altitude { get; set; }
}
