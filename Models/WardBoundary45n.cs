using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class WardBoundary45n
{
    public int Id { get; set; }

    public MultiPolygon? Geom { get; set; }

    public int? Wno { get; set; }

    public int? Dcode { get; set; }

    public string? District { get; set; }

    public string? Zone { get; set; }

    public string? LocBodies { get; set; }

    public double? AreaHa { get; set; }

    public string? WardNepali { get; set; }

    public long? DcodeNew { get; set; }

    public string? GapaNapa { get; set; }

    public string? TypeGn { get; set; }

    public string? Province { get; set; }

    public long? LocCode { get; set; }

    public long? Pcode { get; set; }

    public string? ProtectAr { get; set; }
}
