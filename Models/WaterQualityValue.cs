using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class WaterQualityValue
{
    public int Id { get; set; }

    public string? SampleUuid { get; set; }

    public int? ParameterId { get; set; }

    public string? Value { get; set; }

    public bool? LabTest { get; set; }

    public int? MethodUsed { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }
}
