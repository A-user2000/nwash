using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class Form2datum
{
    public int Id { get; set; }

    public string? Formid { get; set; }

    public string? Sourcebasicevaluation { get; set; }

    public string? Sourcebasicevaluationremarks { get; set; }

    public string? Treatmentcenterbasicevaluation { get; set; }

    public string? Treatmentcenterbasicevaluationremarks { get; set; }

    public string? Waterreservoirbasicevaluation { get; set; }

    public string? Waterreservoirbasicevaluationremarks { get; set; }

    public string? Pipelinebasicevaluation { get; set; }

    public string? Pipelinebasicevaluationremarks { get; set; }

    public string? Storageusagebasicevaluation { get; set; }

    public string? Storageusagebasicevaluationremarks { get; set; }

    public string? Pollutionpossibility { get; set; }

    public string? Pollutionpossibilitytypes { get; set; }

    public string? Definfectedbydiarrhea { get; set; }

    public string? Defdiedbydiarrhea { get; set; }

    public string? Defwaterdisease { get; set; }

    public string? Defnoticesource { get; set; }

    public string? Defwrittenresult { get; set; }

    public string? Defsuggestion { get; set; }
}
