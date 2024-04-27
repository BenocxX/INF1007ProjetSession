using Microsoft.EntityFrameworkCore;

namespace ProjetSessionBackend.Core.Models.Entities;

public class MenuItem : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    [Precision(10, 2)]
    public decimal Price { get; set; }
    
    public int MenuId { get; set; }
    public List<Menu> Menus { get; set; } = new();
}