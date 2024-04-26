using System;
using System.Collections.Generic;

namespace ProjetSessionBackend.Core.Models.Entities;

public partial class Person
{
    public int PersonId { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual Client? Client { get; set; }

    public virtual User? User { get; set; }
}
