using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class DashboardNotice
{
    public int Id { get; set; }

    public string? Notices { get; set; }

    public DateOnly? AddedOn { get; set; }

    public string? AddedBy { get; set; }

    public int? Status { get; set; }
}
