namespace ProjetSessionBackend.Core.Interfaces.Services;

public interface IHashService
{
    public string Hash(string raw);
    public bool Compare(string raw, string hash);
}