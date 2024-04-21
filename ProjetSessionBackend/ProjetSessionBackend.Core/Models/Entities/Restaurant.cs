using System;
using System.Collections.Generic;

namespace ProjetSessionBackend.Core;

public partial class Restaurant
{
    public int RestaurantId { get; set; }

    public int? MenuId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual Menu? Menu { get; set; }
}
