using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class Srn
{
    public int Orderid { get; set; }

    public LineString? TheGeom { get; set; }

    public string? RoadCode { get; set; }

    public string? Dyear { get; set; }

    public string? Iyear { get; set; }

    public string? Inotes { get; set; }

    public string? Iupdate { get; set; }

    public string? Iprogram { get; set; }

    public double? FromCh { get; set; }

    public double? ToCh { get; set; }

    public double? FromLong { get; set; }

    public double? FromLat { get; set; }

    public double? ToLong { get; set; }

    public double? ToLat { get; set; }

    public string? PaveType { get; set; }

    public double? PaveThick { get; set; }

    public double? BaseThick { get; set; }

    public double? SubbaseThick { get; set; }

    public string? UploadBy { get; set; }

    public string? AddDate { get; set; }

    public double? PaveWidth { get; set; }

    public double? ForWidth { get; set; }

    public double? NoLanes { get; set; }

    public string? SubgradeType { get; set; }

    public double? LeftShoulderWidth { get; set; }

    public string? LeftShoulderType { get; set; }

    public double? RightShoulderWidth { get; set; }

    public string? RightShoulderType { get; set; }

    public string? ConstructionYear { get; set; }

    public string? LastResurface { get; set; }

    public int? Dcode { get; set; }

    public double? SdiValue { get; set; }

    public double? IriValue { get; set; }

    public double? AadtValue { get; set; }

    public double? ComVeh { get; set; }
}
