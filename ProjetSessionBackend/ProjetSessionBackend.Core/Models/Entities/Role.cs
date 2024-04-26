using System;
using System.Collections.Generic;

namespace ProjetSessionBackend.Core.Models.Entities;

public partial class Role
{
    public int RoleId { get; set; }

    public string? Name { get; set; }

    public virtual User? User { get; set; }
}
