using CleanArchPOC.Domain.Contracts.Services;

namespace CleanArchPOC.Adapters.Services;

public sealed class StringHashingService : IStringHashingService
{
    public bool CheckPasswordHashMatches(string password, string hashedPassword)
    {
        throw new NotImplementedException();
    }

    public string GetPasswordHash(string password)
    {
        throw new NotImplementedException();
    }
}
