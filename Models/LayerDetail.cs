using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class LayerDetail
{
    public int LayerId { get; set; }

    public string? TblName { get; set; }

    public string? GeomColName { get; set; }

    public string? AttributesCol { get; set; }

    public string? ObjType { get; set; }

    public string? ObjColorRgbOpacity { get; set; }

    public int? LineWidth { get; set; }

    public int? PointRadius { get; set; }

    public string? PointStrokeColor { get; set; }

    public string? PointImg { get; set; }

    public string? Status { get; set; }

    public string? ProjectName { get; set; }

    public string? LayerGroup { get; set; }

    public string? LayerDisplayName { get; set; }

    public string? LayerType { get; set; }

    public string? AttributesDisplayName { get; set; }

    public string? AttributesShow { get; set; }

    public string? AttributesEditable { get; set; }

    public string? Sector { get; set; }

    public string? GeoserverTbl { get; set; }
}
