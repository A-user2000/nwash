using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class Reservoir
{
    public int Id { get; set; }

    public string? ProUuid { get; set; }

    public string? Uuid { get; set; }

    public int? DataYear { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public double? Ele { get; set; }

    public string? RvtCons { get; set; }

    public string? RvtNo { get; set; }

    public string? RvtType { get; set; }

    public double? RvtCap { get; set; }

    public string? RvtQua { get; set; }

    public string? RvtCon { get; set; }

    public string? RvtEqk { get; set; }

    public string? RvtRem { get; set; }

    public string? Photo1Path { get; set; }

    public string? Photo1Desc { get; set; }

    public string? Photo2Path { get; set; }

    public string? Photo2Desc { get; set; }

    public Geometry? TheGeom { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? AddBy { get; set; }

    public int? ConsYear { get; set; }

    public int? CollectedBy { get; set; }

    public DateTime? CollectedOn { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }

    public string? Photo1PathUuid { get; set; }

    public string? Photo2PathUuid { get; set; }

    public virtual ProjectDetail? ProUu { get; set; }
}
