namespace ProjetSessionBackend.Core.DTOs.User;

public class CreateUserRequest
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int RoleId { get; set; }
}