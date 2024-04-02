using System.ComponentModel.DataAnnotations;

namespace ProjetSessionBackend.Core.Models.Entities;

public class Menu
{
    [Key]
    public int id { get; set; }
    
    public string name { get; set; }
    
    public string description { get; set; }
    
    public double price { get; set; }
}