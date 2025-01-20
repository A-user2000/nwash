using System;
using System.Collections.Generic;

namespace Wq_Surveillance.NwashModels;

public partial class TrainingHeld
{
    public int Id { get; set; }

    public bool TrainingHappening { get; set; }

    public DateOnly? StartDate { get; set; }

    public string? StartedBy { get; set; }
}
