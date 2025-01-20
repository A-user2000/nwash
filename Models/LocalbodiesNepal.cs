using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class LocalbodiesNepal
{
    public int Id { get; set; }

    public MultiPolygon? Geom { get; set; }

    public int? Dcode { get; set; }

    public string? District { get; set; }

    public string? Zone { get; set; }

    public double? AreaHa { get; set; }

    public int? Province { get; set; }

    public string? LocBodies { get; set; }

    public int? LocCode { get; set; }

    public double? AreaHa1 { get; set; }

    public string? LocNepali { get; set; }
}
