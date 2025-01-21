using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Wq_Surveillance.Models;

public partial class ProjectDetail
{
    public int Id { get; set; }

    public string Uuid { get; set; } = null!;

    public int? DataYear { get; set; }

    public string? ProName { get; set; }

    public string? ProCode { get; set; }

    public string? ProCodeNmip { get; set; }

    public string? ProType { get; set; }

    public string? ProvinceCode { get; set; }

    public string? DistrictCode { get; set; }

    public string? MunicipalityCode { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public double? Ele { get; set; }

    public int? ConsYear { get; set; }

    public int? ConsAgencyId { get; set; }

    public DateOnly? AddDate { get; set; }

    public string? AddBy { get; set; }

    public Geometry? TheGeom { get; set; }

    public double ProSus { get; set; }

    public double ProFun { get; set; }

    public string? Photo1Path { get; set; }

    public string? Photo2Path { get; set; }

    public string? Photo3Path { get; set; }

    public string? Photo1Desc { get; set; }

    public string? Photo2Desc { get; set; }

    public string? Photo3Desc { get; set; }

    public string? ProNameNep { get; set; }

    public string? SettlementName { get; set; }

    public string? ConsAgency { get; set; }

    public string? SupAgency { get; set; }

    public int? RehabYear { get; set; }

    public string? RehabAgency { get; set; }

    public string? Photo4Path { get; set; }

    public string? Photo4Desc { get; set; }

    public string? Photo5Path { get; set; }

    public string? Photo5Desc { get; set; }

    public string? WardNo { get; set; }

    public string? Photo6Path { get; set; }

    public string? Photo6Desc { get; set; }

    public string? InvAgency { get; set; }

    public string? ProCodeOther { get; set; }

    public string? ProCodeOtherProvider { get; set; }

    public string? ConsAgencyOther { get; set; }

    public string? SupAgencyOther { get; set; }

    public string? RehabAgencyOther { get; set; }

    public string? SoCode { get; set; }

    public string? ProjectStatus { get; set; }

    public int? CollectedBy { get; set; }

    public DateTime? CollectedOn { get; set; }

    public string? ClimateResilience { get; set; }

    public string? WaterSafetyApproach { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? EditedBy { get; set; }

    public string? Photo1PathUuid { get; set; }

    public string? Photo2PathUuid { get; set; }

    public string? Photo3PathUuid { get; set; }

    public string? Photo4PathUuid { get; set; }

    public string? Photo5PathUuid { get; set; }

    public string? Photo6PathUuid { get; set; }

  

  
}
