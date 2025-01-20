using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class Faq
{
    public int FaqId { get; set; }

    public string? Questions { get; set; }

    public string? Answers { get; set; }

    public string? Groups { get; set; }

    public string? Links { get; set; }
}
