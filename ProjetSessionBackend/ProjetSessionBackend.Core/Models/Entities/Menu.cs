using System;
using System.Collections.Generic;

namespace ProjetSessionBackend.Core;

public partial class Menu
{
    public int MenuId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    
    public ICollection<MenuMenuItem>? MenuItems { get; set; }
}
