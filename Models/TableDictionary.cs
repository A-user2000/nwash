using System;
using System.Collections.Generic;

namespace Wq_Surveillance.Models;

public partial class TableDictionary
{
    public int Id { get; set; }

    public string? SqliteLayer { get; set; }

    public string? PostgresTable { get; set; }

    public string? PostgresSchema { get; set; }

    public string? LayerType { get; set; }

    public int? Status { get; set; }
}
