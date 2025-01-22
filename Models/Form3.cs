using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class Form3
{
    public int Id { get; set; }
    public string? Uuid { get; set; }

    public string? AddedBy { get; set; }
    public DateTime? AddedOn { get; set; }
    public string? EditedBy { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? FormId { get; set; }

    public string? Month { get; set; }

    public string? DiarrheaCount { get; set; }

    public string? CholeraCount { get; set; }

    public string? TyphoidCount { get; set; }

    public string? DysenteryCount { get; set; }

    public string? HepatitisCount { get; set; }
}
