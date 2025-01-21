using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class ProvinceNepal
{
    public long Id { get; set; }

    public MultiPolygon? Geom { get; set; }

    public string? Province { get; set; }

    public string? State { get; set; }

    public string? ProvNepali { get; set; }
}
