using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class WqGeneralLocation
{
    public int Id { get; set; }

    public string? Uuid { get; set; }

    public int? IdentityId { get; set; }

    public string? MunCode { get; set; }

    public string? WqCode { get; set; }

    public string? PointType { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public double? Elevation { get; set; }

    public DateTime? SamplingTime { get; set; }

    public DateTime? TestingTime { get; set; }

    public string? InstrumentsUsed { get; set; }

    public string? Photo1 { get; set; }

    public string? DescPhoto1 { get; set; }

    public string? Photo2 { get; set; }

    public string? DescPhoto2 { get; set; }

    public string? Photo3 { get; set; }

    public string? DescPhoto3 { get; set; }

    public string? Photo4 { get; set; }

    public string? DescPhoto4 { get; set; }

    public string? UserId { get; set; }

    public string? Photo1Uuid { get; set; }

    public string? Photo2Uuid { get; set; }

    public string? Photo3Uuid { get; set; }

    public string? Photo4Uuid { get; set; }
}
