namespace ProjetSessionBackend.Core.DTOs.Auth;

public class RegisterRequest
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
}