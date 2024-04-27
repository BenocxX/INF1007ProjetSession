using ProjetSessionBackend.Core.Models.DTOs.MenuItem;

namespace ProjetSessionBackend.Core.Models.DTOs.Menu;

public class MenuResponse : BaseEntityResponse
{
    public int MenuId { get; set; }
    public string Name { get; set; }

    public List<MenuItemResponse> MenuItems { get; set; } = new();
}