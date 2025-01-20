using System;
using System.Collections.Generic;

namespace Wq_Surveillance.NwashModels;

public partial class MunicipalityWardFormation
{
    public int Id { get; set; }

    public string? MunCode { get; set; }

    public string? NewWardE { get; set; }

    public string? OldWardE { get; set; }

    public string? NewWardN { get; set; }

    public string? OldWardN { get; set; }

    public string? OldVdcE { get; set; }

    public string? OldVdcN { get; set; }
}
