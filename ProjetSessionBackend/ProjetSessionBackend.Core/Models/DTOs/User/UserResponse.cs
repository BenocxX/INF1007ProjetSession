using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Models.DTOs.User;

public class UserResponse
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
}