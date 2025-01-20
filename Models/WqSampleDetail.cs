using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class WqSampleDetail
{
    public int Id { get; set; }

    public string? SampleUuid { get; set; }

    public string? ClientName { get; set; }

    public string? SampledBy { get; set; }

    public string? SamplingPoint { get; set; }

    public string? SampledByLabUuid { get; set; }

    public string? SampleCollectionDate { get; set; }

    public string? AnalysisDate { get; set; }

    public string? CompletionDate { get; set; }

    public string? SampleLocation { get; set; }

    public string? Gps { get; set; }

    public string? ReportDate { get; set; }

    public string? EnteredBy { get; set; }

    public int? Status { get; set; }

    public string? AnalyzedBy { get; set; }

    public string? AnalyzedDate { get; set; }

    public string? ApprovedBy { get; set; }

    public string? ApprovedDate { get; set; }

    public int? Dyear { get; set; }
}
