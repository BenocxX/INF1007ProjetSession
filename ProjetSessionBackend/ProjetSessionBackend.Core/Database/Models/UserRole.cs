namespace ProjetSessionBackend.Core.Database.Models;

public enum UserRole
{
    Admin,
    Employee,
    User
}

public class Role
{
    public int RoleId { get; set; }
    public UserRole UserRole { get; set; }
}