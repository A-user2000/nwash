using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class Sustainability
{
    public int Id { get; set; }

    public string? ProUuid { get; set; }

    public string? Uuid { get; set; }

    public int? DataYear { get; set; }

    public string? SusNoMeeting { get; set; }

    public string? SusAgm { get; set; }

    public string? SusAcc { get; set; }

    public string? SusWaterQuality { get; set; }

    public string? SusSop { get; set; }

    public string? SusSourceReg { get; set; }

    public string? SusSourceSafety { get; set; }

    public string? SusPerHh { get; set; }

    public int? NoWuscMem { get; set; }

    public int? NoWomenWuscMem { get; set; }

    public string? SusBookeeping { get; set; }

    public string? SusVmw { get; set; }

    public string? SusInsurance { get; set; }

    public string? AddBy { get; set; }

    public DateOnly? AddDate { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }
}
