namespace ProjetSessionBackend.Core.Models.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; }
    
    public static int Admin => 1;
    public static int Employee => 2;
    public static int User => 3;
}