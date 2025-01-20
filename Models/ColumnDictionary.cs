using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class ColumnDictionary
{
    public int Id { get; set; }

    public int? TableId { get; set; }

    public string? SqliteAttr { get; set; }

    public string? PostgresCol { get; set; }

    public bool? Show { get; set; }

    public bool? Editable { get; set; }

    public string? ColType { get; set; }

    public string? Options { get; set; }

    public string? QbCols { get; set; }
}
