using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class SanitaryInspection
{
    public int Id { get; set; }

    public string? Uuid { get; set; }

    public string? PointId { get; set; }

    public string? PointType { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public double? Elevation { get; set; }

    public DateTime? Time { get; set; }

    public string? UserId { get; set; }

    public string? ProjectUuid { get; set; }
}
