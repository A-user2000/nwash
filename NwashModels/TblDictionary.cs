using System;
using System.Collections.Generic;

namespace Wq_Surveillance.NwashModels;

public partial class TblDictionary
{
    public int Id { get; set; }

    public string? FieldName { get; set; }

    public string? FieldText { get; set; }

    public string? ReturnIfNull { get; set; }
}
