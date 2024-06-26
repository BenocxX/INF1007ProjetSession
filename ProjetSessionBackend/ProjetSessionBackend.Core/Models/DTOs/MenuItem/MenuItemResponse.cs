namespace ProjetSessionBackend.Core.Models.DTOs.MenuItem;

public class MenuItemResponse : BaseEntityResponse
{
    public int MenuItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}