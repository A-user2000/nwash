using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class Settlement
{
    public int Id { get; set; }

    public Point? Geom { get; set; }

    public string? Name { get; set; }
}
