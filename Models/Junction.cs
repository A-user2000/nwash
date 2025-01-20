using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class Junction
{
    public int Id { get; set; }

    public string? ProUuid { get; set; }

    public string? Uuid { get; set; }

    public int? DataYear { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public double? Ele { get; set; }

    public string? JuncNo { get; set; }

    public string? JuncType { get; set; }

    public Geometry? TheGeom { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? AddBy { get; set; }

    public string? Photo1Path { get; set; }

    public string? Photo1Desc { get; set; }

    public string? Photo2Path { get; set; }

    public string? Photo2Desc { get; set; }

    public int? CollectedBy { get; set; }

    public DateTime? CollectedOn { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }

    public string? Photo1PathUuid { get; set; }

    public string? Photo2PathUuid { get; set; }

    public virtual ProjectDetail? ProUu { get; set; }
}
