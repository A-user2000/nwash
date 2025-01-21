using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class LutWq
{
    public int Id { get; set; }

    public string? Index { get; set; }

    public string? Label { get; set; }

    public string? LabelText { get; set; }

    public string? Options { get; set; }

    public string? Scope { get; set; }

    public string? LabelDn { get; set; }

    public int? ScopeId { get; set; }

    public string? QbCols { get; set; }

    public string? TblName { get; set; }
}

