using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class LabRegistration
{
    public int Id { get; set; }

    public string? Uuid { get; set; }

    public string? LabName { get; set; }

    public string? Province { get; set; }

    public string? District { get; set; }

    public string? Municipality { get; set; }

    public string? Address { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public Geometry? TheGeom { get; set; }

    public string? Telephone { get; set; }

    public string? Email { get; set; }

    public string? LogoPath { get; set; }

    public string? AddedBy { get; set; }

    public string? AddedOn { get; set; }

    public int? Status { get; set; }

    public int? LabType { get; set; }

    public string? LabRegNo { get; set; }

    public string? SubName { get; set; }

    public int? LabSubType { get; set; }

    public string? FocalPerson { get; set; }

    public string? FocalPersonNumber { get; set; }

    public string? ModuleFocalPerson { get; set; }

    public string? ModuleFocalPersonNumber { get; set; }
}
