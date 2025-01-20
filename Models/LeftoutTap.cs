using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class LeftoutTap
{
    public int Id { get; set; }

    public string? ProUuid { get; set; }

    public string? Uuid { get; set; }

    public int? DataYear { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public double? Ele { get; set; }

    public string? TapOwner { get; set; }

    public string? TapContact { get; set; }

    public string? TapType { get; set; }

    public decimal? HhServed { get; set; }

    public decimal? BcHh { get; set; }

    public decimal? JanHh { get; set; }

    public decimal? DalHh { get; set; }

    public decimal? MiHh { get; set; }

    public int? MalePop { get; set; }

    public int? FemalePop { get; set; }

    public int HhToilet { get; set; }

    public string? LeftoutReason { get; set; }

    public Geometry? TheGeom { get; set; }

    public string? AddBy { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? TapNo { get; set; }

    public string? CurrentSource { get; set; }

    public string? PhotoPath { get; set; }

    public int? CollectedBy { get; set; }

    public DateTime? CollectedOn { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }

    public string? PhotoPathUuid { get; set; }

    public virtual ProjectDetail? ProUu { get; set; }
}
