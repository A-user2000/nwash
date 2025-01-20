using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class DistrictBoundary
{
    public int Id { get; set; }

    public MultiPolygon? Geom { get; set; }

    public int? Objectid { get; set; }

    public string? District { get; set; }

    public string? Zone { get; set; }

    public string? Distname { get; set; }

    public string? Region { get; set; }

    public int? Dcode { get; set; }

    public int? NewDcode { get; set; }

    public short? Province { get; set; }

    public string? DisNepali { get; set; }
}
