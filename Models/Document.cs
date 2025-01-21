using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class Document
{
    public int Id { get; set; }

    public string? DocTitle { get; set; }

    public string? Filename { get; set; }

    public string? AddedBy { get; set; }

    public string? AddedDate { get; set; }
}
