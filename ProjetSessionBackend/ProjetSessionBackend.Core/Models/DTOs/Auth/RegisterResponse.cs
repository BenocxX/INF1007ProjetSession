namespace ProjetSessionBackend.Core.Models.DTOs;

public class RegisterResponse
{
    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }
    
    public string? Password { get; set; }
}