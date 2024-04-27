using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetSessionBackend.Core.Models.Entities;

[Table("Menu")]
public class Menu : BaseEntity
{
    public int MenuId { get; set; }
    public string Name { get; set; }

    public List<MenuItem> MenuItems { get; set; } = new();
}