namespace ProjetSessionBackend.Core.Models.Entities;

public class Role
{
    public int RoleId { get; set; }
    
    public static int Admin => 1;
    public static int Employee => 2;
    public static int User => 3;
    
    public static string GetRoleName(int roleId)
    {
        return roleId switch
        {
            1 => "Admin",
            2 => "Employee",
            3 => "User",
            _ => "User"
        };
    }
}