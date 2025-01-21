using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wq_Surveillance.Models;

public partial class Form1a
{
    public int Id { get; set; }
    public string? Uuid { get; set; }

    public string? AddedBy { get; set; }
    public DateTime? AddedOn { get; set; }

    public string? FormId { get; set; }

    public string? WspInitiativeStatus1 { get; set; }

    public string? WspInitiativeRemarks1 { get; set; }

    public string? WspInitiativeStatus2 { get; set; }

    public string? WspInitiativeRemarks2 { get; set; }

    public string? WspInitiativeStatus3 { get; set; }

    public string? WspInitiativeRemarks3 { get; set; }

    public string? WspInitiativeStatus4 { get; set; }

    public string? WspInitiativeRemarks4 { get; set; }

    public string? WspInitiativeStatus5 { get; set; }

    public string? WspInitiativeRemarks5 { get; set; }

    public string? WspInitiativeStatus6 { get; set; }

    public string? WspInitiativeRemarks6 { get; set; }

    public string? WspInitiativeStatus7 { get; set; }

    public string? WspInitiativeRemarks7 { get; set; }

    public string? WspInitiativeSecurityPlan { get; set; }

    public string? WspInitiativeWaterQualityStatus { get; set; }

    public string? WspInitiativeInfectedByDiarrhea { get; set; }

    public string? WspInitiativeDiedByDiarrhea { get; set; }

    public string? WspInitiativeWaterDisease { get; set; }

    public string? WspInitiativeNoticeSource { get; set; }

    public string? WspInitiativeWrittenResult { get; set; }

    public string? WspInitiativeSuggestion { get; set; }
 
}
