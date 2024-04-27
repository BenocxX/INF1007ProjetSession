namespace ProjetSessionBackend.Core.Models.DTOs.Restaurant;

public class CreateRestaurantRequest
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int MenuId { get; set; }
}