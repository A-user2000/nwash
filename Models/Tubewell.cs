using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class Tubewell
{
    public int Id { get; set; }

    public string? Uuid { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public double? Ele { get; set; }

    public Geometry? TheGeom { get; set; }

    public DateTime? RecTime { get; set; }

    public DateTime? UploadTime { get; set; }

    public string? AddBy { get; set; }

    public string? Remarks { get; set; }

    public string? MunCode { get; set; }

    public string? TubewellType { get; set; }

    public int? WardNo { get; set; }

    public string? CommunityName { get; set; }

    public string? OwnerName { get; set; }

    public int? MalePop { get; set; }

    public int? FemalePop { get; set; }

    public double? DepthFt { get; set; }

    public int? ConsYear { get; set; }

    public string? Condition { get; set; }

    public string? PlatformCondition { get; set; }

    public bool? WsSchemePresent { get; set; }

    public bool? ProjectBeingConstructed { get; set; }

    public decimal? HhServed { get; set; }

    public decimal? PopServed { get; set; }

    public string? Photo1 { get; set; }

    public string? Photo2 { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }

    public string? Photo1Uuid { get; set; }

    public string? Photo2Uuid { get; set; }
    [NotMapped]
    public string WsSchemePresentVal { get; set; }
    [NotMapped]
    public string ProjectBeingConstructedVal { get; set; }
}
