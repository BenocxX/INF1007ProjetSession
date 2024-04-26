namespace ProjetSessionBackend.Core.Database.Models;

public class Person
{
    public int PersonId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}