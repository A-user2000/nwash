using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class Support
{
    public int Id { get; set; }

    public string? ProUuid { get; set; }

    public int? SupportAgencyId { get; set; }

    public int? SupportTypeId { get; set; }

    public double? SupportAmount { get; set; }

    public int? SupportYear { get; set; }

    public string? SupportNote { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? AddBy { get; set; }

    public int? DataYear { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }
}
