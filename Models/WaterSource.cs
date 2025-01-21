using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class WaterSource
{
    public int Id { get; set; }

    public string? ProUuid { get; set; }

    public string? Uuid { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public double? Ele { get; set; }

    public string? SouName { get; set; }

    public string? SouReg { get; set; }

    public int? RegYear { get; set; }

    public string? SouType { get; set; }

    public string? IntType { get; set; }

    public string? SouUse { get; set; }

    public double? MeaDis { get; set; }

    public string? MeaDate { get; set; }

    public double? MinYield { get; set; }

    public double? SouDist { get; set; }

    public string? NeaCmu { get; set; }

    public string? WatQua { get; set; }

    public string? FlowReg { get; set; }

    public string? SouPro { get; set; }

    public string? SouCon { get; set; }

    public string? SouEqk { get; set; }

    public string? StaEqk { get; set; }

    public string? TreReq { get; set; }

    public string? SouRem { get; set; }

    public string? SouLoc { get; set; }

    public string? Photo1Path { get; set; }

    public string? Photo1Desc { get; set; }

    public string? Photo2Path { get; set; }

    public string? Photo2Desc { get; set; }

    public string? Photo3Path { get; set; }

    public string? Photo3Desc { get; set; }

    public Geometry? TheGeom { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? AddBy { get; set; }

    public double? RtipTime { get; set; }

    public int? DataYear { get; set; }

    public double? TubewellDepth { get; set; }

    public int? TrtConsYear { get; set; }

    public int? CollectedBy { get; set; }

    public DateTime? CollectedOn { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }

    public string? Photo1PathUuid { get; set; }

    public string? Photo2PathUuid { get; set; }

    public string? Photo3PathUuid { get; set; }

    public virtual ProjectDetail? ProUu { get; set; }
}
