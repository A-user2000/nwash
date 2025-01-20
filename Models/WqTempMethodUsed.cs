using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class WqTempMethodUsed
{
    public int Id { get; set; }

    public string? Options { get; set; }

    public int? WqTempId { get; set; }
}
