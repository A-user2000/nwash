using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class UsersAccessProCode
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? ProCode { get; set; }
}
