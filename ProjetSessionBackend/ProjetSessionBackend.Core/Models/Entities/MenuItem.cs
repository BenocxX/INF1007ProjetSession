using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetSessionBackend.Core.Models.Entities;

[Table("MenuItem")]
public class MenuItem : BaseEntity
{
    public int MenuItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    
    public int MenuId { get; set; }
    public List<Menu> Menus { get; set; } = new();
}