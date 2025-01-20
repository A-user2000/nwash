using System;
using System.Collections.Generic;

namespace Wq_Surveillance.NwashModels;

public partial class UsersAccessProCode
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? ProCode { get; set; }
}
