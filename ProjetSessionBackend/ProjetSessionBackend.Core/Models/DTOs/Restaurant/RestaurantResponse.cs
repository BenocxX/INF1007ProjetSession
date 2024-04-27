namespace ProjetSessionBackend.Core.Models.DTOs.Restaurant;

public class RestaurantResponse : BaseEntityResponse
{
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    
    public int MenuId { get; set; }
}