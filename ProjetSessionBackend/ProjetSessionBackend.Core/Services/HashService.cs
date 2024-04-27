using DevOne.Security.Cryptography.BCrypt;
using ProjetSessionBackend.Core.Interfaces.Services;

namespace ProjetSessionBackend.Core.Services;

public class HashService : IHashService
{
    public string Hash(string raw)
    {
        var salt = BCryptHelper.GenerateSalt(12);
        return BCryptHelper.HashPassword(raw, salt);
    }

    public bool Compare(string raw, string hash)
    {
        return BCryptHelper.CheckPassword(raw, hash);
    }
}