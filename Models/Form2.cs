using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class Form2
{
    public int Id { get; set; }
    public string? Uuid { get; set; }

    public string? AddedBy { get; set; }
    public DateTime? AddedOn { get; set; }
    public string? EditedBy { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? FormId { get; set; }

    public string? SourceBasicEvaluation { get; set; }

    public string? SourceBasicEvaluationRemarks { get; set; }

    public string? TreatmentCenterBasicEvaluation { get; set; }

    public string? TreatmentCenterBasicEvaluationRemarks { get; set; }

    public string? WaterReservoirBasicEvaluation { get; set; }

    public string? WaterReservoirBasicEvaluationRemarks { get; set; }

    public string? PipelineBasicEvaluation { get; set; }

    public string? PipelineBasicEvaluationRemarks { get; set; }

    public string? StorageUsageBasicEvaluation { get; set; }

    public string? StorageUsageBasicEvaluationRemarks { get; set; }

    public string? PollutionPossibility { get; set; }

    public string? PollutionPossibilityTypes { get; set; }

    public string? DefInfectedByDiarrhea { get; set; }

    public string? DefDiedByDiarrhea { get; set; }

    public string? DefWaterDisease { get; set; }

    public string? DefNoticeSource { get; set; }

    public string? DefWrittenResult { get; set; }

    public string? DefSuggestion { get; set; }
}
