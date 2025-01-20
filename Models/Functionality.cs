using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class Functionality
{
    public int Id { get; set; }

    public string? Uuid { get; set; }

    public string? ProUuid { get; set; }

    public int? DataYear { get; set; }

    public int? TotalTap { get; set; }

    public string? YardTap { get; set; }

    public int? NoMeetDemand { get; set; }

    public int? TapNoTurbidity { get; set; }

    public int? NoVmw { get; set; }

    public int? NoVmwToolMeet { get; set; }

    public int? NoMonthsFlowAdequate { get; set; }

    public int? NoStr { get; set; }

    public int? NoStrRepair { get; set; }

    public double? PipeLen { get; set; }

    public int? NoLeakYear { get; set; }

    public double? SupHours { get; set; }

    public int? NoComplaints { get; set; }

    public double? AnExp { get; set; }

    public double? AnIncome { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? AddBy { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }
}
