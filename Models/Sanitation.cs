using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class Sanitation
{
    public int Id { get; set; }

    public string? ProUuid { get; set; }

    public string? Uuid { get; set; }

    public int? DataYear { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public double? Ele { get; set; }

    public string? SanOwner { get; set; }

    public string? OwnerName { get; set; }

    public string? OwnerContact { get; set; }

    public string? ToiletType { get; set; }

    public string? ToiletTreatment { get; set; }

    public string? SanRem { get; set; }

    public string? Photo1Path { get; set; }

    public string? Photo1Desc { get; set; }

    public string? Photo2Path { get; set; }

    public string? Photo2Desc { get; set; }

    public Geometry? TheGeom { get; set; }

    public string? AddBy { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? EditedBy { get; set; }

    public DateOnly? EditedOn { get; set; }

    public string? Photo1PathUuid { get; set; }

    public string? Photo2PathUuid { get; set; }

    public virtual ProjectDetail? ProUu { get; set; }
}
