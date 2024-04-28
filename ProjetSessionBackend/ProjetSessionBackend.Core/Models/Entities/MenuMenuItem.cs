namespace ProjetSessionBackend.Core.Models.Entities;

public class MenuMenuItem
{
    public int MenuId { get; set; }
    public Menu Menu { get; set; }
    
    public int MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }
}