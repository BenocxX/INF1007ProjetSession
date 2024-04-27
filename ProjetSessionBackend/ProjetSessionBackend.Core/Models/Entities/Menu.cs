namespace ProjetSessionBackend.Core.Models.Entities;

public class Menu : BaseEntity
{
    public string Name { get; set; }

    public List<MenuItem> MenuItems { get; set; } = new();
}