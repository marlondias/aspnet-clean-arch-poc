using System.Security.Cryptography;
using System.Text;
using CleanArchPOC.Domain.Contracts.Services;

namespace CleanArchPOC.Adapters.Services;

public sealed class StringHashingService : IStringHashingService
{
    public bool CheckPasswordHashMatches(string password, string hashedPassword)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
            return false;

        string passwordHash = GetPasswordHash(password);
        return passwordHash.Equals(hashedPassword, StringComparison.OrdinalIgnoreCase);
    }

    public string GetPasswordHash(string password)
    {
        if (string.IsNullOrEmpty(password))
            return string.Empty;

        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] hashBytes = SHA256.HashData(passwordBytes);

        return Convert.ToHexString(hashBytes);
    }
}
