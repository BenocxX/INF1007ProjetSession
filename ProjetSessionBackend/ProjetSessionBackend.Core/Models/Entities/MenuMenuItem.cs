namespace ProjetSessionBackend.Core;

public class MenuMenuItem
{
    public int MenuItemId { get; set; }
    public int MenuId { get; set; }
    public MenuItem MenuItem { get; set; }
    public Menu Menu { get; set; }
}