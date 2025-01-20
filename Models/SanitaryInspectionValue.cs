using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class SanitaryInspectionValue
{
    public int Id { get; set; }

    public string? SampleUuid { get; set; }

    public int? QuestionId { get; set; }

    public string? Value { get; set; }
}
