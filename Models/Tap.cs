using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class Tap
{
    public int Id { get; set; }

    public string? ProUuid { get; set; }

    public string? Uuid { get; set; }

    public int? DataYear { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public double? Ele { get; set; }

    public string? TapCons { get; set; }

    public string? TapNrp { get; set; }

    public string? TapTur { get; set; }

    public double? TapFhours { get; set; }

    public string? TapNo { get; set; }

    public string? TapType { get; set; }

    public string? TapOwner { get; set; }

    public decimal? HhServerd { get; set; }

    public decimal? BcHh { get; set; }

    public decimal? JanHh { get; set; }

    public decimal? DalHh { get; set; }

    public decimal? MiHh { get; set; }

    public string? TapCond { get; set; }

    public string? TapEqk { get; set; }

    public string? TapRem { get; set; }

    public string? Photo1Path { get; set; }

    public string? Photo1Desc { get; set; }

    public string? Photo2Path { get; set; }

    public string? Photo2Desc { get; set; }

    public Geometry? TheGeom { get; set; }

    public string? AddBy { get; set; }

    public DateOnly? AddDate { get; set; }

    public int? MalePop { get; set; }

    public int? FemalePop { get; set; }

    public string? TapFlowCon { get; set; }

    public string? TapMeter { get; set; }

    public string? TapContact { get; set; }

    public string? TapWaterQuality { get; set; }

    public int? TapComplaint { get; set; }

    public int? NoLeakage { get; set; }

    public int HhToilet { get; set; }

    public string? TankAvailable { get; set; }

    public int? CollectedBy { get; set; }

    public DateTime? CollectedOn { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }

    public string? Photo1PathUuid { get; set; }

    public string? Photo2PathUuid { get; set; }

    public virtual ProjectDetail? ProUu { get; set; }
}
