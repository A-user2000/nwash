using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class ArsenicHi
{
    public int Id { get; set; }

    public string? Uuid { get; set; }

    public string? PointId { get; set; }

    public string? Ptype { get; set; }

    public string? PtypeDes { get; set; }

    public string? District { get; set; }

    public string? VdcCode { get; set; }

    public string? VdcName { get; set; }

    public string? OldWard { get; set; }

    public string? Community { get; set; }

    public string? DepthM { get; set; }

    public string? OwnerName { get; set; }

    public string? Ownership { get; set; }

    public int? NoPop { get; set; }

    public int? NoHh { get; set; }

    public string? UserType { get; set; }

    public int? ConYearBs { get; set; }

    public int? ConYearAd { get; set; }

    public string? ConBy { get; set; }

    public string? SamDateBs { get; set; }

    public DateOnly? SamDateAd { get; set; }

    public string? Agency { get; set; }

    public double? WellAge { get; set; }

    public string? OtherTest { get; set; }

    public string? TestType { get; set; }

    public double? ArcConc { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public string? Pcode { get; set; }

    public string? Mcode { get; set; }

    public string? Dcode { get; set; }

    public int? WardNo { get; set; }

    public Point? TheGeom { get; set; }
}
