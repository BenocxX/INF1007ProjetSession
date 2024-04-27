namespace ProjetSessionBackend.Core.Models.Entities;

public class Restaurant : BaseEntity
{
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    
    public int MenuId { get; set; }
    public Menu Menu { get; set; }
}