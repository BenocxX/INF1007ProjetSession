using System;
using System.Collections.Generic;

namespace ProjetSessionBackend.Core.Models.Entities;

public partial class MenuItem
{
    public int MenuItemId { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public bool? Available { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Menu> Menus { get; } = new List<Menu>();
}
