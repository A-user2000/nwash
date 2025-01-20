using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class Structure
{
    public int Id { get; set; }

    public string? ProUuid { get; set; }

    public string? Uuid { get; set; }

    public int? DataYear { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public double? Ele { get; set; }

    public string? StrCons { get; set; }

    public string? StrNo { get; set; }

    public string? StrType { get; set; }

    public string? StrOther { get; set; }

    public string? StrNrp { get; set; }

    public string? StrCond { get; set; }

    public string? StrDim { get; set; }

    public string? StrEqk { get; set; }

    public string? StrRem { get; set; }

    public string? Photo1Path { get; set; }

    public string? Photo1Desc { get; set; }

    public string? Photo2Path { get; set; }

    public string? Photo2Desc { get; set; }

    public Geometry? TheGeom { get; set; }

    public string? AddBy { get; set; }

    public DateOnly? AddDate { get; set; }

    public double? StrDimLen { get; set; }

    public double? StrDimWidth { get; set; }

    public double? StrDimHeight { get; set; }

    public int? ConsYear { get; set; }

    public int? CollectedBy { get; set; }

    public DateTime? CollectedOn { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }

    public string? Photo1PathUuid { get; set; }

    public string? Photo2PathUuid { get; set; }

    public virtual ProjectDetail? ProUu { get; set; }
}
