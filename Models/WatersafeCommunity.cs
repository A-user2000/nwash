using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class WatersafeCommunity
{
    public int Id { get; set; }

    public string? MunCode { get; set; }

    public string? ProName { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public Geometry? TheGeom { get; set; }

    public double? Test { get; set; }
}
