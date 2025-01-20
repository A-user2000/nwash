using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class WqIdentity
{
    public int Id { get; set; }

    public string? Uuid { get; set; }

    public string? OrgUuid { get; set; }

    public string? ProjectName { get; set; }
}
