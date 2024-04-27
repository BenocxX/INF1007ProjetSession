namespace ProjetSessionBackend.Core.Database.Models;

public class Role
{
    public int RoleId { get; set; }
    
    public static int Admin => 1;
    public static int Employee => 2;
    public static int User => 3;
}