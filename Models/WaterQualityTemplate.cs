using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class WaterQualityTemplate
{
    public int Id { get; set; }

    public string? Category { get; set; }

    public string? ParameterName { get; set; }

    public string? Unit { get; set; }

    public string? Range { get; set; }

    public string? DataType { get; set; }

    public decimal? LowerRange { get; set; }

    public decimal? UpperRange { get; set; }

    public string? MethodUsed { get; set; }
}
