using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class ProjectCoverage
{
    public int Id { get; set; }

    public string? ProUuid { get; set; }

    public int? DataYear { get; set; }

    public string? AddBy { get; set; }

    public DateOnly? AddDate { get; set; }

    public Geometry? TheGeom { get; set; }

    public double? Area { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }

    public virtual ProjectDetail? ProUu { get; set; }
}
