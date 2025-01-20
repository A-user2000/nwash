using System;
using System.Collections.Generic;

namespace Wq_Surveillance.NwashModels;

public partial class UsersAccessDistrict
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? District { get; set; }
}
