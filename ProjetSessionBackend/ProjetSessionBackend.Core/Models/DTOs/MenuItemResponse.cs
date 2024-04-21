namespace ProjetSessionBackend.Core.Models.DTOs;

public class MenuItemResponse
{
    public int MenuItemId { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public bool? Available { get; set; }
}