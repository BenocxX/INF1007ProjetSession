using ProjetSessionBackend.Core.Database.Models;

namespace ProjetSessionBackend.Core.DTOs.User;

public class UserResponse
{
    public int UserId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
}