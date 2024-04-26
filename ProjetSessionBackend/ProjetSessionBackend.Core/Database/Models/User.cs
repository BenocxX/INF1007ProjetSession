namespace ProjetSessionBackend.Core.Database.Models;

public class User
{
    public int UserId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    
    public int RoleId { get; set; }
    public Role Role { get; set; }
}