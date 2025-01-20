using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class Pipe
{
    public int Id { get; set; }

    public string? ProUuid { get; set; }

    public string? Uuid { get; set; }

    public int? DataYear { get; set; }

    public string? PipePart { get; set; }

    public string? PipeCons { get; set; }

    public string? PipeType { get; set; }

    public string? PipeClass { get; set; }

    public double? PipeDia { get; set; }

    public string? PipeCond { get; set; }

    public string? PipeLcon { get; set; }

    public string? PipeEqk { get; set; }

    public string? PipeRem { get; set; }

    public string? PipeName { get; set; }

    public string? PipeLayCon { get; set; }

    public string? Photo1Path { get; set; }

    public string? Photo1Desc { get; set; }

    public string? Photo2Path { get; set; }

    public string? Photo2Desc { get; set; }

    public Geometry? TheGeom { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? AddBy { get; set; }

    public double? PipeLen { get; set; }

    public int? LeakageCount { get; set; }

    public int? CollectedBy { get; set; }

    public DateTime? CollectedOn { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }

    public string? Photo1PathUuid { get; set; }

    public string? Photo2PathUuid { get; set; }

    public virtual ProjectDetail? ProUu { get; set; }
}
