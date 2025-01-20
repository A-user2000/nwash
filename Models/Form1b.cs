using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class Form1b
{
    public int Id { get; set; }
    public string? Uuid { get; set; }

    public string? AddedBy { get; set; }
    public DateTime? AddedOn { get; set; }

    public string? FormId { get; set; }

    public string? TeamFormationScore { get; set; }

    public string? TeamFormationPhoto { get; set; }

    public string? SystemAnalysisScore { get; set; }

    public string? SystemAnalysisPhoto { get; set; }

    public string? PollutionRiskControlMeasureScore { get; set; }

    public string? PollutionRiskControlPhoto { get; set; }

    public string? ImprovementPlanScore { get; set; }

    public string? ImprovementPlanPhoto { get; set; }

    public string? MonitoringScore { get; set; }

    public string? MonitoringPhoto { get; set; }

    public string? CertificationScore { get; set; }

    public string? CertificationPhoto { get; set; }

    public string? CollaborativeActivitiesScore { get; set; }

    public string? CollaborativeActivitiesPhoto { get; set; }

    public string? ReviewScore { get; set; }

    public string? ReviewPhoto { get; set; }

    public int? TotalScore { get; set; }
}
