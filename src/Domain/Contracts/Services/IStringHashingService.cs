namespace Domain.Contracts.Services;

public interface IStringHashingService
{
  public string GetPasswordHash(string password);

  public bool CheckPasswordHashMatches(string password, string hashedPassword);
}
