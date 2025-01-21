using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class WardboundaryLine
{
    public int Id { get; set; }

    public MultiLineString? Geom { get; set; }

    public int? LeftFid { get; set; }

    public int? RightFid { get; set; }
}
