using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class PopServed
{
    public int Id { get; set; }

    public string? ProUuid { get; set; }

    public int? DataYear { get; set; }

    public int? HhServerd { get; set; }

    public int? BcHh { get; set; }

    public int? JanHh { get; set; }

    public int? DalHh { get; set; }

    public int? MiHh { get; set; }

    public int? MalePop { get; set; }

    public int? FemPop { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? AddBy { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }
}
