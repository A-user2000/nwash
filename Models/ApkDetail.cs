using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class ApkDetail
{
    public int Id { get; set; }

    public string AppName { get; set; } = null!;

    public string? ApkPath { get; set; }

    public string? Requirements { get; set; }

    public string? Size { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public string? LogoPath { get; set; }

    public string? AppVersion { get; set; }

    public string? OtherDocs { get; set; }

    public string? AppDesc { get; set; }

    public int? Status { get; set; }

    public int VersionCode { get; set; }

    public int? ApkIndex { get; set; }

    public long? DownloadCount { get; set; }
}
