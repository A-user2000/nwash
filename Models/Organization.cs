using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class Organization
{
    public int Id { get; set; }

    public string? OrgUuid { get; set; }

    public string? OrgName { get; set; }

    public string? PrgShortName { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? AddBy { get; set; }

    public string? Address { get; set; }
}
