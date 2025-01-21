using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Salt { get; set; }

    public string? UserType { get; set; }

    public int? Groups { get; set; }

    public int? Status { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public int? District { get; set; }

    public string? InvAgency { get; set; }

    public int? Municipality { get; set; }

    public string? Province { get; set; }

    public int? TrainingUser { get; set; }

    public double? LastLogin { get; set; }

    public string? CreatedBy { get; set; }

    public int? UserCategory { get; set; }

    public string? AssignedArea { get; set; }
}
