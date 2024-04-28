using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetSessionBackend.Core.Models.Entities;

[Table("MenuMenuItem")]
public class MenuMenuItem
{
    public int MenuId { get; set; }
    public Menu Menu { get; set; }
    
    public int MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }
}