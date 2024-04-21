using ProjetSessionBackend.Core.Models;

namespace ProjetSessionBackend.Core.Models.DTOs;

public class MenuResponse
{
    public int? MenuId { get; set; }

    public string Name { get; set; }

    public MenuItem[]? MenuItems { get; set; }

}