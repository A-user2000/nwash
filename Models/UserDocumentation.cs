using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class UserDocumentation
{
    public int Id { get; set; }

    public string? DocumentTitle { get; set; }

    public string? DocumentPath { get; set; }

    public string? MunCode { get; set; }

    public string? UploadedBy { get; set; }

    public DateOnly? UploadedDate { get; set; }
}
