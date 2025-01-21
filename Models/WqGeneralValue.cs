using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class WqGeneralValue
{
    public int Id { get; set; }

    public string? LocationUuid { get; set; }

    public int? ParameterId { get; set; }

    public string? Value { get; set; }
}
