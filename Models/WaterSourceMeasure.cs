using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class WaterSourceMeasure
{
    public int Id { get; set; }

    public string? ProUuid { get; set; }

    public string? SourceUuid { get; set; }

    public double? MeaDis { get; set; }

    public string? MeaDate { get; set; }

    public string? Photo1Path { get; set; }

    public string? Photo1Desc { get; set; }

    public string? Photo2Path { get; set; }

    public string? Photo2Desc { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }

    public string? Photo1PathUuid { get; set; }

    public string? Photo2PathUuid { get; set; }

    public virtual ProjectDetail? ProUu { get; set; }
}
