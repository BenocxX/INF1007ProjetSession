namespace ProjetSessionBackend.Core.Models.Entities;

public class User : BaseEntity
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    
    public int RoleId { get; set; }
    public Role Role { get; set; }
}