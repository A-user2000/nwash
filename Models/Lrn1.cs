using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class Lrn1
{
    public long Id { get; set; }

    public MultiLineString? Geom { get; set; }

    public string? Uuid { get; set; }

    public string? RoadUuid { get; set; }

    public string? RoadCode { get; set; }

    public decimal? FromCh { get; set; }

    public decimal? ToCh { get; set; }

    public decimal? SecLen { get; set; }

    public decimal? FromLong { get; set; }

    public decimal? FromLat { get; set; }

    public decimal? ToLong { get; set; }

    public decimal? ToLat { get; set; }

    public string? PaveType { get; set; }

    public decimal? PaveThick { get; set; }

    public decimal? BaseThick { get; set; }

    public decimal? SubbaseTh { get; set; }

    public decimal? PaveWidth { get; set; }

    public decimal? ForWidth { get; set; }

    public decimal? NoLanes { get; set; }

    public string? SubgradeT { get; set; }

    public decimal? LeftShoul { get; set; }

    public string? LeftSho1 { get; set; }

    public decimal? RightShou { get; set; }

    public string? RightSh1 { get; set; }

    public decimal? SdiValue { get; set; }

    public decimal? IriValue { get; set; }

    public decimal? AadtValue { get; set; }

    public string? SdiRating { get; set; }

    public string? IriRating { get; set; }

    public string? AadtClass { get; set; }

    public string? AccCon { get; set; }

    public string? Terrain { get; set; }

    public string? HorCur { get; set; }

    public string? Constructi { get; set; }

    public string? LastResur { get; set; }

    public string? Dyear { get; set; }

    public string? Iyear { get; set; }

    public string? Inotes { get; set; }

    public string? Iupdate { get; set; }

    public string? Iprogram { get; set; }

    public string? UploadBy { get; set; }

    public string? AddDate { get; set; }

    public long? Dcode { get; set; }

    public string? RoadCateg { get; set; }
}
