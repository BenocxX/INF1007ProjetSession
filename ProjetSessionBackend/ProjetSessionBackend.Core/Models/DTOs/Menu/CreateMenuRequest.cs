namespace ProjetSessionBackend.Core.Models.DTOs.Menu;

public class CreateMenuRequest
{
    public string Name { get; set; }
    public List<int> MenuItemsId { get; set; } = new();
}