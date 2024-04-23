using System;
using System.Collections.Generic;

namespace ProjetSessionBackend.Core.Models.Entities;

public partial class Menu
{
    public int MenuId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Restaurant? Restaurant { get; set; }

    public virtual ICollection<MenuItem> MenuItems { get; } = new List<MenuItem>();
}
