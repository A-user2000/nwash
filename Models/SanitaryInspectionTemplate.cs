using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class SanitaryInspectionTemplate
{
    public int Id { get; set; }

    public int? Qn { get; set; }

    public string? Layer { get; set; }

    public string? Attribute { get; set; }

    public string? Question { get; set; }

    public string? Options { get; set; }
}
